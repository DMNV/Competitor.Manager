using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Blackstream.Common.Models;
using Dapper;
using Newtonsoft.Json.Linq;
using ProtoBuf;
using Sports.BetGenius.Models.Fixture;
using Sports.Engine.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Competitor.Manager
{
    public partial class CompetitorManagerForm : Form
    {
        public CompetitorManagerForm()
        {
            InitializeComponent();

            textBoxCompetitorListPath.ReadOnly = true;
            textBoxCompetitorListPath.BackColor = SystemColors.Window;

            comboBoxSports.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCompetition.DropDownStyle = ComboBoxStyle.DropDownList;

            this.pictureBox1.Size = new Size(Size.Width - 32, Size.Height - 52);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Hide();

            LoadSports();
        }

        private void LoadSports()
        {
            List<Sports.Engine.Models.Sport> sports = new();
            List<ComboBoxModel> data = new List<ComboBoxModel>();

            sports.AddRange(GetSportsDataBase().Select(oneData => new Sports.Engine.Models.Sport
            {
                Name = oneData
            }).ToList());

            data.AddRange(sports.Select(oneData => new ComboBoxModel
            {
                Value = oneData.Name,
                Text = oneData.Name
            }).ToList());

            var sortedData = data.DistinctBy(c => c.Text).OrderBy(c => c.Text).ToList();

            comboBoxSports.ValueMember = "Value";
            comboBoxSports.DisplayMember = "Text";
            comboBoxSports.DataSource = sortedData;
        }

        private void GetCompetition(string? sportName)
        {
            List<Sports.Engine.Models.Competition> competitions = new();
            List<ComboBoxModel> data = new List<ComboBoxModel>();

            competitions.AddRange(GetCompetitionDataBase(sportName).Select(oneData => new Sports.Engine.Models.Competition
            {
                Name = oneData
            }).ToList());

            var competitionsDistinct = competitions.DistinctBy(c => c.Name).OrderBy(c => c.Name);

            data.AddRange(competitionsDistinct.Select(oneData => new ComboBoxModel
            {
                Value = oneData.Name,
                Text = oneData.Name
            }).ToList());

            comboBoxCompetition.ValueMember = "Value";
            comboBoxCompetition.DisplayMember = "Text";
            comboBoxCompetition.DataSource = data;
        }

        private FixtureCompetitorData GetConvertCompetitorData(string? competitorData)
        {
            if (string.IsNullOrEmpty(competitorData))
                return new();

            byte[] data = Convert.FromBase64String(competitorData);

            var memoryStream = new MemoryStream(data);
            return Serializer.Deserialize<FixtureCompetitorData>(memoryStream);
        }

        private void comboBoxSports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSports.SelectedIndex != 0)
            {
                object obj = comboBoxSports.SelectedValue;
                string? sport = Convert.ToString(obj);

                if (!string.IsNullOrWhiteSpace(sport))
                    GetCompetition(sport);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = textBoxCompetitorList.Text;
            textBoxCompetitorListPath.Text = string.Empty;

            // Split the values by \r\n
            List<string> splitValues = values.Split("\r\n").ToList();

            if (splitValues.Count <= 0) return;
            foreach (var splitValue in splitValues)
            {
                var imageFileName = GetCompetitor(splitValue);

                if (!string.IsNullOrWhiteSpace(imageFileName))
                    textBoxCompetitorListPath.Text += imageFileName + Environment.NewLine;
                else
                    textBoxCompetitorListPath.Text += "No image file name" + Environment.NewLine;
            }

            Clipboard.SetText(textBoxCompetitorListPath.Text);
        }

        private string? GetCompetitor(string competitorText)
        {
            if (string.IsNullOrEmpty(competitorText))
            {
                MessageBox.Show(" Competitor cannot be null or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string? sportName = Convert.ToString(comboBoxSports.Text);
                string? competitionName = Convert.ToString(comboBoxCompetition.Text);

                var competitorData = GetCompetitorData(competitorText, sportName, competitionName);

                FixtureCompetitorData fixtureCompetitorData = GetConvertCompetitorData(competitorData);
                return GetImageFileName(fixtureCompetitorData, competitorText);
            }

            return string.Empty;
        }

        private st

        private string GetImageFileName(FixtureCompetitorData fixtureCompetitorData, string competitorText)
        {
            Sports.Engine.Models.Competitor? competitor1 = MapCompetitor(fixtureCompetitorData.Competitor1);
            Sports.Engine.Models.Competitor? competitor2 = MapCompetitor(fixtureCompetitorData.Competitor2);

            return TryGetNameToBuildImageUrl(competitor1, competitor2, competitorText);
        }

        private string TryGetNameToBuildImageUrl(Sports.Engine.Models.Competitor? competitor1,
            Sports.Engine.Models.Competitor? competitor2, string competitorName)
        {

            if (competitor1 != null && competitor1.Name.CaseInsensitiveContains(competitorName))
                return competitor1.Name.ToSlug();

            if (competitor2 != null && competitor2.Name.CaseInsensitiveContains(competitorName))
                return competitor2.Name.ToSlug();

            return string.Empty;
        }

        private static Sports.Engine.Models.Competitor MapCompetitor(Sports.BetGenius.Models.Fixture.Competitor competitor)
            => competitor != null
                ? new Sports.Engine.Models.Competitor
                {
                    CompetitorId = competitor.Id,
                    Name = competitor.Name,
                    ChildCompetitorIds = competitor.Competitors?
                                             .Select(c => c.Id)
                                             .ToList()
                                         ?? new List<int>()
                }
                : null;

        private string? GetCompetitorData(string masterEventName, string? sportName, string? competitionName)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionClass.ConVal("TbsDB"));

                var query = "SELECT CompetitorData FROM dbo.MasterEvent " +
                            "WHERE CategoryId in (select CategoryId from dbo.Category where MasterCategoryID in " +
                            "(SELECT MasterCategoryID FROM dbo.MasterCategory WHERE EventTypeID in " +
                            $"(select EventTypeID from dbo.LEventType where EventTypeDesc like '{sportName}') and MasterCategoryName like '{competitionName}')) and " +
                            $"CompetitorData is not null and UPPER(MasterEventName) LIKE UPPER('%{masterEventName}%')";

                IEnumerable<string?> results = connection.QueryAsync<string>(query, commandTimeout: 3000).Result;

                return results.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<string> GetSportsDataBase()
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionClass.ConVal("TbsDB"));
                var query = $"select EventTypeDesc from dbo.LEventType where MasterEventTypeId = 2";


                return connection.Query<string>(query, commandTimeout: 3000).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<string> GetCompetitionDataBase(string? sportName)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionClass.ConVal("TbsDB"));
                var query = $"Select MasterCategoryName from dbo.MasterCategory where EventTypeId in (select EventTypeId from dbo.LEventType where EventTypeDesc like '%{sportName}%')";


                return connection.Query<string>(query, commandTimeout: 3000).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxCompetitorList.Text = string.Empty;
            textBoxCompetitorListPath.Text = string.Empty;
        }
    }

    public static class StringExtensions
    {
        public static string ToSlug(this string input)
            => input
                .Replace(" ", "-")
                .ToLower();

        public static bool CaseInsensitiveContains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }
    }

    

    public class ComboBoxModel
    {
        public string Value { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}