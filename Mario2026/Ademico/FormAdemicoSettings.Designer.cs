namespace Mario2026
{
    partial class FormAdemicoSettings
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
            TextBoxUrl = new TextBox();
            LabelUrl = new Label();
            label1 = new Label();
            TextBoxAccessToken = new TextBox();
            label2 = new Label();
            TextBoxUsername = new TextBox();
            label3 = new Label();
            TextBoxPassword = new TextBox();
            ButtonSaveSettings = new Button();
            ButtonClose = new Button();
            SuspendLayout();
            // 
            // TextBoxUrl
            // 
            TextBoxUrl.Location = new Point(99, 12);
            TextBoxUrl.Name = "TextBoxUrl";
            TextBoxUrl.Size = new Size(361, 23);
            TextBoxUrl.TabIndex = 0;
            // 
            // LabelUrl
            // 
            LabelUrl.Location = new Point(12, 12);
            LabelUrl.Name = "LabelUrl";
            LabelUrl.Size = new Size(81, 23);
            LabelUrl.TabIndex = 1;
            LabelUrl.Text = "Url";
            // 
            // label1
            // 
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(81, 23);
            label1.TabIndex = 3;
            label1.Text = "AccessToken";
            // 
            // TextBoxAccessToken
            // 
            TextBoxAccessToken.Location = new Point(99, 41);
            TextBoxAccessToken.Name = "TextBoxAccessToken";
            TextBoxAccessToken.Size = new Size(361, 23);
            TextBoxAccessToken.TabIndex = 2;
            // 
            // label2
            // 
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(81, 23);
            label2.TabIndex = 5;
            label2.Text = "Username";
            // 
            // TextBoxUsername
            // 
            TextBoxUsername.Location = new Point(99, 70);
            TextBoxUsername.Name = "TextBoxUsername";
            TextBoxUsername.Size = new Size(361, 23);
            TextBoxUsername.TabIndex = 4;
            // 
            // label3
            // 
            label3.Location = new Point(12, 102);
            label3.Name = "label3";
            label3.Size = new Size(81, 23);
            label3.TabIndex = 7;
            label3.Text = "Password";
            // 
            // TextBoxPassword
            // 
            TextBoxPassword.Location = new Point(99, 99);
            TextBoxPassword.Name = "TextBoxPassword";
            TextBoxPassword.Size = new Size(361, 23);
            TextBoxPassword.TabIndex = 6;
            // 
            // ButtonSaveSettings
            // 
            ButtonSaveSettings.Location = new Point(99, 128);
            ButtonSaveSettings.Name = "ButtonSaveSettings";
            ButtonSaveSettings.Size = new Size(75, 23);
            ButtonSaveSettings.TabIndex = 8;
            ButtonSaveSettings.Text = "Bewaren";
            ButtonSaveSettings.UseVisualStyleBackColor = true;
            ButtonSaveSettings.Click += ButtonSaveSettings_Click;
            // 
            // ButtonClose
            // 
            ButtonClose.Location = new Point(385, 128);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(75, 23);
            ButtonClose.TabIndex = 9;
            ButtonClose.Text = "Sluiten";
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // FormAdemicoSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = ButtonClose;
            ClientSize = new Size(476, 159);
            Controls.Add(ButtonClose);
            Controls.Add(ButtonSaveSettings);
            Controls.Add(label3);
            Controls.Add(TextBoxPassword);
            Controls.Add(label2);
            Controls.Add(TextBoxUsername);
            Controls.Add(label1);
            Controls.Add(TextBoxAccessToken);
            Controls.Add(LabelUrl);
            Controls.Add(TextBoxUrl);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormAdemicoSettings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAdemicoSettings";
            Load += FormAdemicoSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxUrl;
        private Label LabelUrl;
        private Label label1;
        private TextBox TextBoxAccessToken;
        private Label label2;
        private TextBox TextBoxUsername;
        private Label label3;
        private TextBox TextBoxPassword;
        private Button ButtonSaveSettings;
        private Button ButtonClose;
    }
}