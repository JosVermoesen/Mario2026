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
            ButtonNotifications = new Button();
            label8 = new Label();
            TextBoxLegalEntityId = new TextBox();
            label7 = new Label();
            TextBoxSupportedDocument = new TextBox();
            label6 = new Label();
            TextBoxRegIdentifier = new TextBox();
            label5 = new Label();
            TextBoxRegScheme = new TextBox();
            label4 = new Label();
            TextBoxCountryCode = new TextBox();
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
            RichTextBoxResult = new RichTextBox();
            TabInvoiceSend = new TabPage();
            TabInvoiceReceive = new TabPage();
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
            TabControlVariousTools.Controls.Add(TabInvoiceSend);
            TabControlVariousTools.Controls.Add(TabInvoiceReceive);
            TabControlVariousTools.Dock = DockStyle.Fill;
            TabControlVariousTools.Location = new Point(0, 0);
            TabControlVariousTools.Name = "TabControlVariousTools";
            TabControlVariousTools.SelectedIndex = 0;
            TabControlVariousTools.Size = new Size(473, 350);
            TabControlVariousTools.TabIndex = 3;
            // 
            // TabActions
            // 
            TabActions.Controls.Add(ButtonNotifications);
            TabActions.Controls.Add(label8);
            TabActions.Controls.Add(TextBoxLegalEntityId);
            TabActions.Controls.Add(label7);
            TabActions.Controls.Add(TextBoxSupportedDocument);
            TabActions.Controls.Add(label6);
            TabActions.Controls.Add(TextBoxRegIdentifier);
            TabActions.Controls.Add(label5);
            TabActions.Controls.Add(TextBoxRegScheme);
            TabActions.Controls.Add(label4);
            TabActions.Controls.Add(TextBoxCountryCode);
            TabActions.Controls.Add(ButtonGetPeppolRegistrations);
            TabActions.Controls.Add(ButtonCheckConnectivity);
            TabActions.Location = new Point(4, 24);
            TabActions.Name = "TabActions";
            TabActions.Padding = new Padding(3);
            TabActions.Size = new Size(465, 322);
            TabActions.TabIndex = 0;
            TabActions.Text = "Opzoekingen";
            TabActions.UseVisualStyleBackColor = true;
            // 
            // ButtonNotifications
            // 
            ButtonNotifications.Location = new Point(314, 191);
            ButtonNotifications.Name = "ButtonNotifications";
            ButtonNotifications.Size = new Size(140, 45);
            ButtonNotifications.TabIndex = 6;
            ButtonNotifications.Text = "Notificaties";
            ButtonNotifications.UseVisualStyleBackColor = true;
            ButtonNotifications.Click += ButtonNotifications_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(0, 165);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 13;
            label8.Text = "LegalEntityId";
            // 
            // TextBoxLegalEntityId
            // 
            TextBoxLegalEntityId.Location = new Point(92, 162);
            TextBoxLegalEntityId.Name = "TextBoxLegalEntityId";
            TextBoxLegalEntityId.Size = new Size(54, 23);
            TextBoxLegalEntityId.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 78);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 11;
            label7.Text = "RegScheme";
            // 
            // TextBoxSupportedDocument
            // 
            TextBoxSupportedDocument.Location = new Point(92, 133);
            TextBoxSupportedDocument.Name = "TextBoxSupportedDocument";
            TextBoxSupportedDocument.Size = new Size(202, 23);
            TextBoxSupportedDocument.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 107);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 9;
            label6.Text = "RegId";
            // 
            // TextBoxRegIdentifier
            // 
            TextBoxRegIdentifier.Location = new Point(92, 104);
            TextBoxRegIdentifier.Name = "TextBoxRegIdentifier";
            TextBoxRegIdentifier.Size = new Size(202, 23);
            TextBoxRegIdentifier.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 136);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 7;
            label5.Text = "SupportedDoc";
            // 
            // TextBoxRegScheme
            // 
            TextBoxRegScheme.Location = new Point(92, 75);
            TextBoxRegScheme.Name = "TextBoxRegScheme";
            TextBoxRegScheme.Size = new Size(202, 23);
            TextBoxRegScheme.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 47);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 5;
            label4.Text = "LandCode";
            // 
            // TextBoxCountryCode
            // 
            TextBoxCountryCode.Location = new Point(92, 44);
            TextBoxCountryCode.Name = "TextBoxCountryCode";
            TextBoxCountryCode.Size = new Size(54, 23);
            TextBoxCountryCode.TabIndex = 4;
            // 
            // ButtonGetPeppolRegistrations
            // 
            ButtonGetPeppolRegistrations.Location = new Point(3, 191);
            ButtonGetPeppolRegistrations.Name = "ButtonGetPeppolRegistrations";
            ButtonGetPeppolRegistrations.Size = new Size(291, 40);
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
            TabEntities.Size = new Size(452, 322);
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
            TabResponse.Controls.Add(RichTextBoxResult);
            TabResponse.Location = new Point(4, 24);
            TabResponse.Name = "TabResponse";
            TabResponse.Size = new Size(452, 322);
            TabResponse.TabIndex = 1;
            TabResponse.Text = "Resultaat";
            TabResponse.UseVisualStyleBackColor = true;
            // 
            // RichTextBoxResult
            // 
            RichTextBoxResult.Dock = DockStyle.Fill;
            RichTextBoxResult.Location = new Point(0, 0);
            RichTextBoxResult.Name = "RichTextBoxResult";
            RichTextBoxResult.ReadOnly = true;
            RichTextBoxResult.Size = new Size(452, 322);
            RichTextBoxResult.TabIndex = 8;
            RichTextBoxResult.Text = "";
            // 
            // TabInvoiceSend
            // 
            TabInvoiceSend.Location = new Point(4, 24);
            TabInvoiceSend.Name = "TabInvoiceSend";
            TabInvoiceSend.Size = new Size(465, 322);
            TabInvoiceSend.TabIndex = 3;
            TabInvoiceSend.Text = "Facturen Sturen";
            TabInvoiceSend.UseVisualStyleBackColor = true;
            // 
            // TabInvoiceReceive
            // 
            TabInvoiceReceive.Location = new Point(4, 24);
            TabInvoiceReceive.Name = "TabInvoiceReceive";
            TabInvoiceReceive.Size = new Size(465, 322);
            TabInvoiceReceive.TabIndex = 4;
            TabInvoiceReceive.Text = "Facturen Ontvangen";
            TabInvoiceReceive.UseVisualStyleBackColor = true;
            // 
            // StatusStrip
            // 
            StatusStrip.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel });
            StatusStrip.Location = new Point(0, 328);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(473, 22);
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
            ClientSize = new Size(473, 350);
            Controls.Add(StatusStrip);
            Controls.Add(TabControlVariousTools);
            Controls.Add(ButtonClose);
            Name = "FormAdemicoTesting";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAdemicoTesting";
            TabControlVariousTools.ResumeLayout(false);
            TabActions.ResumeLayout(false);
            TabActions.PerformLayout();
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
        private Label label4;
        private TextBox TextBoxCountryCode;
        private Label label8;
        private TextBox TextBoxLegalEntityId;
        private Label label7;
        private TextBox TextBoxSupportedDocument;
        private Label label6;
        private TextBox TextBoxRegIdentifier;
        private Label label5;
        private TextBox TextBoxRegScheme;
        private Button ButtonNotifications;
        private TabPage TabInvoiceSend;
        private TabPage TabInvoiceReceive;
        private RichTextBox RichTextBoxResult;
    }
}