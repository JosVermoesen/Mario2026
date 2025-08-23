namespace Mario2026.Ademico
{
    partial class FormApiActionsClient
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
            TabNotifications = new TabPage();
            ButtonCheckConnectivity = new Button();
            TextBoxSender = new TextBox();
            TextBoxReceiver = new TextBox();
            RadioButtonGetSent = new RadioButton();
            RadioButtonGetReceived = new RadioButton();
            ButtonNotifications = new Button();
            TabInvoiceSend = new TabPage();
            ButtonCheckFile = new Button();
            LabelFile = new Label();
            ButtonSendUblDocument = new Button();
            TabInvoiceReceive = new TabPage();
            LabelTransmissionId = new Label();
            TextBoxTransmissionId = new TextBox();
            ButtonGetUBLDocument = new Button();
            TabResponse = new TabPage();
            RichTextBoxResult = new RichTextBox();
            StatusStrip = new StatusStrip();
            ToolStripStatusLabel = new ToolStripStatusLabel();
            ButtonClose = new Button();
            TabControlVariousTools.SuspendLayout();
            TabNotifications.SuspendLayout();
            TabInvoiceSend.SuspendLayout();
            TabInvoiceReceive.SuspendLayout();
            TabResponse.SuspendLayout();
            StatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // TabControlVariousTools
            // 
            TabControlVariousTools.Controls.Add(TabNotifications);
            TabControlVariousTools.Controls.Add(TabInvoiceSend);
            TabControlVariousTools.Controls.Add(TabInvoiceReceive);
            TabControlVariousTools.Controls.Add(TabResponse);
            TabControlVariousTools.Dock = DockStyle.Fill;
            TabControlVariousTools.Location = new Point(0, 0);
            TabControlVariousTools.Name = "TabControlVariousTools";
            TabControlVariousTools.SelectedIndex = 0;
            TabControlVariousTools.Size = new Size(634, 340);
            TabControlVariousTools.TabIndex = 4;
            // 
            // TabNotifications
            // 
            TabNotifications.Controls.Add(ButtonCheckConnectivity);
            TabNotifications.Controls.Add(TextBoxSender);
            TabNotifications.Controls.Add(TextBoxReceiver);
            TabNotifications.Controls.Add(RadioButtonGetSent);
            TabNotifications.Controls.Add(RadioButtonGetReceived);
            TabNotifications.Controls.Add(ButtonNotifications);
            TabNotifications.Location = new Point(4, 24);
            TabNotifications.Name = "TabNotifications";
            TabNotifications.Size = new Size(626, 312);
            TabNotifications.TabIndex = 5;
            TabNotifications.Text = "Meldingen";
            TabNotifications.UseVisualStyleBackColor = true;
            // 
            // ButtonCheckConnectivity
            // 
            ButtonCheckConnectivity.Location = new Point(12, 18);
            ButtonCheckConnectivity.Name = "ButtonCheckConnectivity";
            ButtonCheckConnectivity.Size = new Size(122, 23);
            ButtonCheckConnectivity.TabIndex = 5;
            ButtonCheckConnectivity.TabStop = false;
            ButtonCheckConnectivity.Text = "&Verbinding Testen";
            ButtonCheckConnectivity.UseVisualStyleBackColor = true;
            ButtonCheckConnectivity.Click += ButtonCheckConnectivity_Click;
            // 
            // TextBoxSender
            // 
            TextBoxSender.Location = new Point(300, 89);
            TextBoxSender.Name = "TextBoxSender";
            TextBoxSender.Size = new Size(237, 23);
            TextBoxSender.TabIndex = 4;
            // 
            // TextBoxReceiver
            // 
            TextBoxReceiver.Location = new Point(300, 60);
            TextBoxReceiver.Name = "TextBoxReceiver";
            TextBoxReceiver.Size = new Size(237, 23);
            TextBoxReceiver.TabIndex = 3;
            // 
            // RadioButtonGetSent
            // 
            RadioButtonGetSent.AutoSize = true;
            RadioButtonGetSent.Location = new Point(210, 89);
            RadioButtonGetSent.Name = "RadioButtonGetSent";
            RadioButtonGetSent.Size = new Size(80, 19);
            RadioButtonGetSent.TabIndex = 2;
            RadioButtonGetSent.TabStop = true;
            RadioButtonGetSent.Text = "Verzonden";
            RadioButtonGetSent.UseVisualStyleBackColor = true;
            // 
            // RadioButtonGetReceived
            // 
            RadioButtonGetReceived.AutoSize = true;
            RadioButtonGetReceived.Location = new Point(210, 61);
            RadioButtonGetReceived.Name = "RadioButtonGetReceived";
            RadioButtonGetReceived.Size = new Size(84, 19);
            RadioButtonGetReceived.TabIndex = 1;
            RadioButtonGetReceived.TabStop = true;
            RadioButtonGetReceived.Text = "Ontvangen";
            RadioButtonGetReceived.UseVisualStyleBackColor = true;
            // 
            // ButtonNotifications
            // 
            ButtonNotifications.Location = new Point(12, 61);
            ButtonNotifications.Name = "ButtonNotifications";
            ButtonNotifications.Size = new Size(100, 51);
            ButtonNotifications.TabIndex = 0;
            ButtonNotifications.Text = "Meldingen Ophalen";
            ButtonNotifications.UseVisualStyleBackColor = true;
            // 
            // TabInvoiceSend
            // 
            TabInvoiceSend.AllowDrop = true;
            TabInvoiceSend.Controls.Add(ButtonCheckFile);
            TabInvoiceSend.Controls.Add(LabelFile);
            TabInvoiceSend.Controls.Add(ButtonSendUblDocument);
            TabInvoiceSend.Location = new Point(4, 24);
            TabInvoiceSend.Name = "TabInvoiceSend";
            TabInvoiceSend.Size = new Size(664, 338);
            TabInvoiceSend.TabIndex = 3;
            TabInvoiceSend.Text = "Facturen Sturen";
            TabInvoiceSend.UseVisualStyleBackColor = true;
            // 
            // ButtonCheckFile
            // 
            ButtonCheckFile.Enabled = false;
            ButtonCheckFile.Location = new Point(8, 294);
            ButtonCheckFile.Name = "ButtonCheckFile";
            ButtonCheckFile.Size = new Size(132, 39);
            ButtonCheckFile.TabIndex = 2;
            ButtonCheckFile.Text = "Controleer Bestand";
            ButtonCheckFile.UseVisualStyleBackColor = true;
            // 
            // LabelFile
            // 
            LabelFile.AutoSize = true;
            LabelFile.Location = new Point(59, 26);
            LabelFile.Name = "LabelFile";
            LabelFile.Size = new Size(545, 15);
            LabelFile.TabIndex = 1;
            LabelFile.Text = "Sleep het UBL xml bestand naar dit venster en druk de knop Controleer Bestand vooraleer te verzenden";
            // 
            // ButtonSendUblDocument
            // 
            ButtonSendUblDocument.Enabled = false;
            ButtonSendUblDocument.Location = new Point(8, 339);
            ButtonSendUblDocument.Name = "ButtonSendUblDocument";
            ButtonSendUblDocument.Size = new Size(132, 50);
            ButtonSendUblDocument.TabIndex = 0;
            ButtonSendUblDocument.Text = "UBL Document Verzenden";
            ButtonSendUblDocument.UseVisualStyleBackColor = true;
            // 
            // TabInvoiceReceive
            // 
            TabInvoiceReceive.Controls.Add(LabelTransmissionId);
            TabInvoiceReceive.Controls.Add(TextBoxTransmissionId);
            TabInvoiceReceive.Controls.Add(ButtonGetUBLDocument);
            TabInvoiceReceive.Location = new Point(4, 24);
            TabInvoiceReceive.Name = "TabInvoiceReceive";
            TabInvoiceReceive.Size = new Size(664, 338);
            TabInvoiceReceive.TabIndex = 4;
            TabInvoiceReceive.Text = "Facturen Ontvangen";
            TabInvoiceReceive.UseVisualStyleBackColor = true;
            // 
            // LabelTransmissionId
            // 
            LabelTransmissionId.AutoSize = true;
            LabelTransmissionId.Location = new Point(8, 17);
            LabelTransmissionId.Name = "LabelTransmissionId";
            LabelTransmissionId.Size = new Size(87, 15);
            LabelTransmissionId.TabIndex = 2;
            LabelTransmissionId.Text = "TransmissionID";
            // 
            // TextBoxTransmissionId
            // 
            TextBoxTransmissionId.Location = new Point(101, 14);
            TextBoxTransmissionId.Name = "TextBoxTransmissionId";
            TextBoxTransmissionId.Size = new Size(232, 23);
            TextBoxTransmissionId.TabIndex = 1;
            TextBoxTransmissionId.Text = "f9ba35d67b2211f0bf1302bb4e4747f9";
            // 
            // ButtonGetUBLDocument
            // 
            ButtonGetUBLDocument.Location = new Point(378, 14);
            ButtonGetUBLDocument.Name = "ButtonGetUBLDocument";
            ButtonGetUBLDocument.Size = new Size(135, 23);
            ButtonGetUBLDocument.TabIndex = 0;
            ButtonGetUBLDocument.Text = "Document Ophalen";
            ButtonGetUBLDocument.UseVisualStyleBackColor = true;
            // 
            // TabResponse
            // 
            TabResponse.Controls.Add(RichTextBoxResult);
            TabResponse.Location = new Point(4, 24);
            TabResponse.Name = "TabResponse";
            TabResponse.Size = new Size(664, 338);
            TabResponse.TabIndex = 1;
            TabResponse.Text = "Antwoorden";
            TabResponse.UseVisualStyleBackColor = true;
            // 
            // RichTextBoxResult
            // 
            RichTextBoxResult.Dock = DockStyle.Fill;
            RichTextBoxResult.Location = new Point(0, 0);
            RichTextBoxResult.Name = "RichTextBoxResult";
            RichTextBoxResult.ReadOnly = true;
            RichTextBoxResult.Size = new Size(664, 338);
            RichTextBoxResult.TabIndex = 8;
            RichTextBoxResult.Text = "";
            // 
            // StatusStrip
            // 
            StatusStrip.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel });
            StatusStrip.Location = new Point(0, 340);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(634, 22);
            StatusStrip.TabIndex = 5;
            // 
            // ToolStripStatusLabel
            // 
            ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            ToolStripStatusLabel.Size = new Size(39, 17);
            ToolStripStatusLabel.Text = "Ready";
            // 
            // ButtonClose
            // 
            ButtonClose.Location = new Point(378, 384);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(75, 23);
            ButtonClose.TabIndex = 7;
            ButtonClose.Text = "Close";
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // FormApiActionsClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = ButtonClose;
            ClientSize = new Size(634, 362);
            Controls.Add(TabControlVariousTools);
            Controls.Add(StatusStrip);
            Controls.Add(ButtonClose);
            Name = "FormApiActionsClient";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormApiActionsClient";
            TabControlVariousTools.ResumeLayout(false);
            TabNotifications.ResumeLayout(false);
            TabNotifications.PerformLayout();
            TabInvoiceSend.ResumeLayout(false);
            TabInvoiceSend.PerformLayout();
            TabInvoiceReceive.ResumeLayout(false);
            TabInvoiceReceive.PerformLayout();
            TabResponse.ResumeLayout(false);
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl TabControlVariousTools;
        private TabPage TabNotifications;
        private TextBox TextBoxSender;
        private TextBox TextBoxReceiver;
        private RadioButton RadioButtonGetSent;
        private RadioButton RadioButtonGetReceived;
        private Button ButtonNotifications;
        private TabPage TabInvoiceSend;
        private Button ButtonCheckFile;
        private Label LabelFile;
        private Button ButtonSendUblDocument;
        private TabPage TabInvoiceReceive;
        private Label LabelTransmissionId;
        private TextBox TextBoxTransmissionId;
        private Button ButtonGetUBLDocument;
        private TabPage TabResponse;
        private RichTextBox RichTextBoxResult;
        private Button ButtonCheckConnectivity;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel ToolStripStatusLabel;
        private Button ButtonClose;
    }
}