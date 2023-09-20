namespace Competitor.Manager
{
    partial class CompetitorManagerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxCompetitorListPath = new TextBox();
            button1 = new Button();
            textBoxCompetitorList = new TextBox();
            comboBoxCompetition = new ComboBox();
            comboBoxSports = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            Sport = new Label();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxCompetitorListPath
            // 
            textBoxCompetitorListPath.BackColor = SystemColors.Control;
            textBoxCompetitorListPath.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCompetitorListPath.Location = new Point(1007, 296);
            textBoxCompetitorListPath.Margin = new Padding(4, 3, 4, 3);
            textBoxCompetitorListPath.Multiline = true;
            textBoxCompetitorListPath.Name = "textBoxCompetitorListPath";
            textBoxCompetitorListPath.ScrollBars = ScrollBars.Both;
            textBoxCompetitorListPath.Size = new Size(1003, 810);
            textBoxCompetitorListPath.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(1822, 190);
            button1.Name = "button1";
            button1.Size = new Size(188, 54);
            button1.TabIndex = 14;
            button1.Text = "Check";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxCompetitorList
            // 
            textBoxCompetitorList.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCompetitorList.Location = new Point(37, 296);
            textBoxCompetitorList.Margin = new Padding(4, 3, 4, 3);
            textBoxCompetitorList.Multiline = true;
            textBoxCompetitorList.Name = "textBoxCompetitorList";
            textBoxCompetitorList.ScrollBars = ScrollBars.Both;
            textBoxCompetitorList.Size = new Size(913, 810);
            textBoxCompetitorList.TabIndex = 13;
            // 
            // comboBoxCompetition
            // 
            comboBoxCompetition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCompetition.CausesValidation = false;
            comboBoxCompetition.FlatStyle = FlatStyle.Popup;
            comboBoxCompetition.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxCompetition.FormattingEnabled = true;
            comboBoxCompetition.Location = new Point(802, 94);
            comboBoxCompetition.Margin = new Padding(4, 3, 4, 3);
            comboBoxCompetition.Name = "comboBoxCompetition";
            comboBoxCompetition.Size = new Size(1208, 56);
            comboBoxCompetition.TabIndex = 12;
            // 
            // comboBoxSports
            // 
            comboBoxSports.AccessibleRole = AccessibleRole.ScrollBar;
            comboBoxSports.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxSports.CausesValidation = false;
            comboBoxSports.FlatStyle = FlatStyle.Popup;
            comboBoxSports.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxSports.FormattingEnabled = true;
            comboBoxSports.Location = new Point(37, 94);
            comboBoxSports.Margin = new Padding(4, 3, 4, 3);
            comboBoxSports.Name = "comboBoxSports";
            comboBoxSports.Size = new Size(699, 56);
            comboBoxSports.TabIndex = 8;
            comboBoxSports.SelectedIndexChanged += comboBoxSports_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.9000006F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(37, 224);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(243, 51);
            label1.TabIndex = 9;
            label1.Text = "Competitor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.9000006F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(802, 30);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(264, 51);
            label2.TabIndex = 10;
            label2.Text = "Competition";
            // 
            // Sport
            // 
            Sport.AutoSize = true;
            Sport.Font = new Font("Microsoft Sans Serif", 15.9000006F, FontStyle.Bold, GraphicsUnit.Point);
            Sport.Location = new Point(37, 30);
            Sport.Margin = new Padding(4, 0, 4, 0);
            Sport.Name = "Sport";
            Sport.Size = new Size(130, 51);
            Sport.TabIndex = 11;
            Sport.Text = "Sport";
            // 
            // button2
            // 
            button2.Location = new Point(772, 229);
            button2.Name = "button2";
            button2.Size = new Size(148, 46);
            button2.TabIndex = 15;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLightLight;
            pictureBox1.Image = Properties.Resources.LoadingMicroAnimation;
            pictureBox1.Location = new Point(7, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(10, 118);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // CompetitorManagerForm
            // 
            AutoScaleDimensions = new SizeF(19F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(600, 400);
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(2055, 1145);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBoxCompetitorList);
            Controls.Add(comboBoxCompetition);
            Controls.Add(comboBoxSports);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(Sport);
            Controls.Add(textBoxCompetitorListPath);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CompetitorManagerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxCompetitorListPath;
        private Button button1;
        private TextBox textBoxCompetitorList;
        private ComboBox comboBoxCompetition;
        private ComboBox comboBoxSports;
        private Label label1;
        private Label label2;
        private Label Sport;
        private Button button2;
        private PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}