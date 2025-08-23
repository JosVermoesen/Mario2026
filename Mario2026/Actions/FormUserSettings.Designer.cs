namespace Mario2026.Actions
{
    partial class FormUserSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LabelMimDataLocation = new Label();
            ListBoxCompanies = new ListBox();
            ButtonClose = new Button();
            SuspendLayout();
            // 
            // LabelMimDataLocation
            // 
            LabelMimDataLocation.AutoSize = true;
            LabelMimDataLocation.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelMimDataLocation.Location = new Point(23, 21);
            LabelMimDataLocation.Name = "LabelMimDataLocation";
            LabelMimDataLocation.Size = new Size(0, 21);
            LabelMimDataLocation.TabIndex = 0;
            // 
            // ListBoxCompanies
            // 
            ListBoxCompanies.FormattingEnabled = true;
            ListBoxCompanies.ItemHeight = 15;
            ListBoxCompanies.Location = new Point(23, 56);
            ListBoxCompanies.Name = "ListBoxCompanies";
            ListBoxCompanies.Size = new Size(492, 94);
            ListBoxCompanies.TabIndex = 1;
            ListBoxCompanies.Click += ListBoxCompanies_Click;
            // 
            // ButtonClose
            // 
            ButtonClose.Location = new Point(440, 386);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(75, 23);
            ButtonClose.TabIndex = 2;
            ButtonClose.Text = "Sluiten";
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // FormUserSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = ButtonClose;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonClose);
            Controls.Add(ListBoxCompanies);
            Controls.Add(LabelMimDataLocation);
            Name = "FormUserSettings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormUserSettings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelMimDataLocation;
        private ListBox ListBoxCompanies;
        private Button ButtonClose;
    }
}