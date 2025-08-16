namespace Mario2026
{
    partial class FormAdemicoTesting
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
            TabControlVariousTools = new TabControl();
            TabActions = new TabPage();
            ButtonGetPeppolRegistrations = new Button();
            ButtonCheckConnectivity = new Button();
            TabEntities = new TabPage();
            ButtonLookUp = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            TextBoxGeographicalInformation = new TextBox();
            TextBoxIdentifier = new TextBox();
            TextBoxCompanyName = new TextBox();
            ButtonEntityNew = new Button();
            TabResponse = new TabPage();
            LabelResult = new Label();
            StatusStrip = new StatusStrip();
            ToolStripStatusLabel = new ToolStripStatusLabel();
            ButtonClose = new Button();
            TabControlVariousTools.SuspendLayout();
            TabActions.SuspendLayout();
            TabEntities.SuspendLayout();
            TabResponse.SuspendLayout();
            StatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // TabControlVariousTools
            // 
            TabControlVariousTools.Controls.Add(TabActions);
            TabControlVariousTools.Controls.Add(TabEntities);
            TabControlVariousTools.Controls.Add(TabResponse);
            TabControlVariousTools.Dock = DockStyle.Fill;
            TabControlVariousTools.Location = new Point(0, 0);
            TabControlVariousTools.Name = "TabControlVariousTools";
            TabControlVariousTools.SelectedIndex = 0;
            TabControlVariousTools.Size = new Size(457, 350);
            TabControlVariousTools.TabIndex = 3;
            // 
            // TabActions
            // 
            TabActions.Controls.Add(ButtonGetPeppolRegistrations);
            TabActions.Controls.Add(ButtonCheckConnectivity);
            TabActions.Location = new Point(4, 24);
            TabActions.Name = "TabActions";
            TabActions.Padding = new Padding(3);
            TabActions.Size = new Size(449, 322);
            TabActions.TabIndex = 0;
            TabActions.Text = "Opzoekingen";
            TabActions.UseVisualStyleBackColor = true;
            // 
            // ButtonGetPeppolRegistrations
            // 
            ButtonGetPeppolRegistrations.Location = new Point(3, 35);
            ButtonGetPeppolRegistrations.Name = "ButtonGetPeppolRegistrations";
            ButtonGetPeppolRegistrations.Size = new Size(119, 40);
            ButtonGetPeppolRegistrations.TabIndex = 3;
            ButtonGetPeppolRegistrations.Text = "Registratie(s) Opzoeken";
            ButtonGetPeppolRegistrations.UseVisualStyleBackColor = true;
            ButtonGetPeppolRegistrations.Click += ButtonGetPeppolRegistrations_Click;
            // 
            // ButtonCheckConnectivity
            // 
            ButtonCheckConnectivity.Location = new Point(3, 6);
            ButtonCheckConnectivity.Name = "ButtonCheckConnectivity";
            ButtonCheckConnectivity.Size = new Size(122, 23);
            ButtonCheckConnectivity.TabIndex = 1;
            ButtonCheckConnectivity.Text = "Verbinding Testen";
            ButtonCheckConnectivity.UseVisualStyleBackColor = true;
            ButtonCheckConnectivity.Click += ButtonCheckConnectivity_Click;
            // 
            // TabEntities
            // 
            TabEntities.Controls.Add(ButtonLookUp);
            TabEntities.Controls.Add(label3);
            TabEntities.Controls.Add(label2);
            TabEntities.Controls.Add(label1);
            TabEntities.Controls.Add(TextBoxGeographicalInformation);
            TabEntities.Controls.Add(TextBoxIdentifier);
            TabEntities.Controls.Add(TextBoxCompanyName);
            TabEntities.Controls.Add(ButtonEntityNew);
            TabEntities.Location = new Point(4, 24);
            TabEntities.Name = "TabEntities";
            TabEntities.Size = new Size(449, 322);
            TabEntities.TabIndex = 2;
            TabEntities.Text = "Entities";
            TabEntities.UseVisualStyleBackColor = true;
            // 
            // ButtonLookUp
            // 
            ButtonLookUp.Location = new Point(360, 36);
            ButtonLookUp.Name = "ButtonLookUp";
            ButtonLookUp.Size = new Size(75, 23);
            ButtonLookUp.TabIndex = 17;
            ButtonLookUp.Text = "Opzoeken";
            ButtonLookUp.UseVisualStyleBackColor = true;
            ButtonLookUp.Click += ButtonLookUp_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 98);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 16;
            label3.Text = "Volledig Adres";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(206, 18);
            label2.Name = "label2";
            label2.Size = new Size(126, 15);
            label2.TabIndex = 15;
            label2.Text = "KBO Ondernemingsnr.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 54);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 14;
            label1.Text = "Bedrijfsnaam (zie KBO!)";
            // 
            // TextBoxGeographicalInformation
            // 
            TextBoxGeographicalInformation.Location = new Point(8, 116);
            TextBoxGeographicalInformation.Name = "TextBoxGeographicalInformation";
            TextBoxGeographicalInformation.Size = new Size(346, 23);
            TextBoxGeographicalInformation.TabIndex = 13;
            // 
            // TextBoxIdentifier
            // 
            TextBoxIdentifier.Location = new Point(206, 36);
            TextBoxIdentifier.Name = "TextBoxIdentifier";
            TextBoxIdentifier.Size = new Size(148, 23);
            TextBoxIdentifier.TabIndex = 12;
            // 
            // TextBoxCompanyName
            // 
            TextBoxCompanyName.Location = new Point(8, 72);
            TextBoxCompanyName.Name = "TextBoxCompanyName";
            TextBoxCompanyName.Size = new Size(347, 23);
            TextBoxCompanyName.TabIndex = 8;
            // 
            // ButtonEntityNew
            // 
            ButtonEntityNew.Enabled = false;
            ButtonEntityNew.Location = new Point(8, 14);
            ButtonEntityNew.Name = "ButtonEntityNew";
            ButtonEntityNew.Size = new Size(122, 23);
            ButtonEntityNew.TabIndex = 5;
            ButtonEntityNew.Text = "Nieuwe Registratie";
            ButtonEntityNew.UseVisualStyleBackColor = true;
            ButtonEntityNew.Click += ButtonEntityNew_Click;
            // 
            // TabResponse
            // 
            TabResponse.Controls.Add(LabelResult);
            TabResponse.Location = new Point(4, 24);
            TabResponse.Name = "TabResponse";
            TabResponse.Size = new Size(449, 322);
            TabResponse.TabIndex = 1;
            TabResponse.Text = "Resultaat";
            TabResponse.UseVisualStyleBackColor = true;
            // 
            // LabelResult
            // 
            LabelResult.Dock = DockStyle.Fill;
            LabelResult.Location = new Point(0, 0);
            LabelResult.Name = "LabelResult";
            LabelResult.Size = new Size(449, 322);
            LabelResult.TabIndex = 7;
            LabelResult.Text = "Result";
            // 
            // StatusStrip
            // 
            StatusStrip.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel });
            StatusStrip.Location = new Point(0, 328);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(457, 22);
            StatusStrip.TabIndex = 4;
            // 
            // ToolStripStatusLabel
            // 
            ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            ToolStripStatusLabel.Size = new Size(39, 17);
            ToolStripStatusLabel.Text = "Ready";
            // 
            // ButtonClose
            // 
            ButtonClose.Location = new Point(535, 339);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(75, 23);
            ButtonClose.TabIndex = 5;
            ButtonClose.Text = "Close";
            ButtonClose.UseVisualStyleBackColor = true;
            // 
            // FormAdemicoTesting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = ButtonClose;
            ClientSize = new Size(457, 350);
            Controls.Add(StatusStrip);
            Controls.Add(TabControlVariousTools);
            Controls.Add(ButtonClose);
            Name = "FormAdemicoTesting";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAdemicoTesting";
            TabControlVariousTools.ResumeLayout(false);
            TabActions.ResumeLayout(false);
            TabEntities.ResumeLayout(false);
            TabEntities.PerformLayout();
            TabResponse.ResumeLayout(false);
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl TabControlVariousTools;
        private TabPage TabActions;
        private TabPage TabResponse;
        private Button ButtonGetPeppolRegistrations;
        private Button ButtonCheckConnectivity;
        private Label LabelResult;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel ToolStripStatusLabel;
        private TabPage TabEntities;
        private Button ButtonEntityNew;
        private TextBox TextBoxCompanyName;
        private TextBox TextBoxGeographicalInformation;
        private TextBox TextBoxIdentifier;
        private Label label1;
        private Label label3;
        private Label label2;
        private Button ButtonClose;
        private Button ButtonLookUp;
    }
}