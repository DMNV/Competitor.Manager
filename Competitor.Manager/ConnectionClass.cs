using Microsoft.Extensions.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace Competitor.Manager
{
    public static class ConnectionClass
    {
        //public static string ConVal(string name)
        //{
        //    var currentDirectory = Directory.GetCurrentDirectory();

        //    return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        //}

        public static string ConVal(string name)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }
            catch (Exception ex)
            {
                // Log or print the exception details
                Console.WriteLine("Error: " + ex.Message);
                return null; // or throw the exception again if you want to handle it higher up
            }
        }
    }
}
