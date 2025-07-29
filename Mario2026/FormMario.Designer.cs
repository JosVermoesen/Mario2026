namespace Mario2026
{
    partial class FormMario
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
            MarioMenuStrip = new MenuStrip();
            ActionsToolStripMenuItem = new ToolStripMenuItem();
            LookUpsToolStripMenuItem = new ToolStripMenuItem();
            CheckUBLDocumentToolStripMenuItem = new ToolStripMenuItem();
            CloseAppToolStripMenuItem = new ToolStripMenuItem();
            VpeToolStripMenuItem = new ToolStripMenuItem();
            AutoPageBreakTestToolStripMenuItem = new ToolStripMenuItem();
            InfoToolStripMenuItem = new ToolStripMenuItem();
            PleskToolStripMenuItem = new ToolStripMenuItem();
            HostingToolStripMenuItem = new ToolStripMenuItem();
            WebmailToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            CommandPromptToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            UBLValidatorToolStripMenuItem = new ToolStripMenuItem();
            UBLDocsBillingToolStripMenuItem = new ToolStripMenuItem();
            MarioMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MarioMenuStrip
            // 
            MarioMenuStrip.Items.AddRange(new ToolStripItem[] { ActionsToolStripMenuItem, VpeToolStripMenuItem, InfoToolStripMenuItem });
            MarioMenuStrip.Location = new Point(0, 0);
            MarioMenuStrip.Name = "MarioMenuStrip";
            MarioMenuStrip.Size = new Size(800, 24);
            MarioMenuStrip.TabIndex = 1;
            MarioMenuStrip.Text = "menuStrip1";
            // 
            // ActionsToolStripMenuItem
            // 
            ActionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { LookUpsToolStripMenuItem, CheckUBLDocumentToolStripMenuItem, CloseAppToolStripMenuItem });
            ActionsToolStripMenuItem.Name = "ActionsToolStripMenuItem";
            ActionsToolStripMenuItem.Size = new Size(51, 20);
            ActionsToolStripMenuItem.Text = "Acties";
            // 
            // LookUpsToolStripMenuItem
            // 
            LookUpsToolStripMenuItem.Name = "LookUpsToolStripMenuItem";
            LookUpsToolStripMenuItem.Size = new Size(203, 22);
            LookUpsToolStripMenuItem.Text = "Opzoekingen";
            LookUpsToolStripMenuItem.Click += LookUpsToolStripMenuItem_Click;
            // 
            // CheckUBLDocumentToolStripMenuItem
            // 
            CheckUBLDocumentToolStripMenuItem.Name = "CheckUBLDocumentToolStripMenuItem";
            CheckUBLDocumentToolStripMenuItem.Size = new Size(203, 22);
            CheckUBLDocumentToolStripMenuItem.Text = "Controle UBL Document";
            CheckUBLDocumentToolStripMenuItem.Click += CheckUBLDocumentToolStripMenuItem_Click;
            // 
            // CloseAppToolStripMenuItem
            // 
            CloseAppToolStripMenuItem.Name = "CloseAppToolStripMenuItem";
            CloseAppToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            CloseAppToolStripMenuItem.Size = new Size(203, 22);
            CloseAppToolStripMenuItem.Text = "Afsluiten";
            CloseAppToolStripMenuItem.Click += CloseAppToolStripMenuItem_Click;
            // 
            // VpeToolStripMenuItem
            // 
            VpeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AutoPageBreakTestToolStripMenuItem });
            VpeToolStripMenuItem.Name = "VpeToolStripMenuItem";
            VpeToolStripMenuItem.Size = new Size(39, 20);
            VpeToolStripMenuItem.Text = "VPE";
            // 
            // AutoPageBreakTestToolStripMenuItem
            // 
            AutoPageBreakTestToolStripMenuItem.Name = "AutoPageBreakTestToolStripMenuItem";
            AutoPageBreakTestToolStripMenuItem.Size = new Size(179, 22);
            AutoPageBreakTestToolStripMenuItem.Text = "AutoPageBreak Test";
            AutoPageBreakTestToolStripMenuItem.Click += AutoPageBreakTestToolStripMenuItem_Click;
            // 
            // InfoToolStripMenuItem
            // 
            InfoToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            InfoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { PleskToolStripMenuItem, toolStripSeparator1, CommandPromptToolStripMenuItem, toolStripSeparator2, UBLValidatorToolStripMenuItem, UBLDocsBillingToolStripMenuItem });
            InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            InfoToolStripMenuItem.Size = new Size(24, 20);
            InfoToolStripMenuItem.Text = "?";
            // 
            // PleskToolStripMenuItem
            // 
            PleskToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { HostingToolStripMenuItem, WebmailToolStripMenuItem });
            PleskToolStripMenuItem.Name = "PleskToolStripMenuItem";
            PleskToolStripMenuItem.Size = new Size(174, 22);
            PleskToolStripMenuItem.Text = "Plesk Hosting";
            // 
            // HostingToolStripMenuItem
            // 
            HostingToolStripMenuItem.Name = "HostingToolStripMenuItem";
            HostingToolStripMenuItem.Size = new Size(166, 22);
            HostingToolStripMenuItem.Text = "Obsidian v18.0.65";
            // 
            // WebmailToolStripMenuItem
            // 
            WebmailToolStripMenuItem.Name = "WebmailToolStripMenuItem";
            WebmailToolStripMenuItem.Size = new Size(166, 22);
            WebmailToolStripMenuItem.Text = "Webmail rv.be";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(171, 6);
            // 
            // CommandPromptToolStripMenuItem
            // 
            CommandPromptToolStripMenuItem.Name = "CommandPromptToolStripMenuItem";
            CommandPromptToolStripMenuItem.Size = new Size(174, 22);
            CommandPromptToolStripMenuItem.Text = "Command Prompt";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(171, 6);
            // 
            // UBLValidatorToolStripMenuItem
            // 
            UBLValidatorToolStripMenuItem.Name = "UBLValidatorToolStripMenuItem";
            UBLValidatorToolStripMenuItem.Size = new Size(174, 22);
            UBLValidatorToolStripMenuItem.Text = "UBL Validator";
            // 
            // UBLDocsBillingToolStripMenuItem
            // 
            UBLDocsBillingToolStripMenuItem.Name = "UBLDocsBillingToolStripMenuItem";
            UBLDocsBillingToolStripMenuItem.Size = new Size(174, 22);
            UBLDocsBillingToolStripMenuItem.Text = "Docs Billing 3.0";
            // 
            // FormMario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MarioMenuStrip);
            IsMdiContainer = true;
            MainMenuStrip = MarioMenuStrip;
            Name = "FormMario";
            FormClosing += FormMario_FormClosing;
            Load += FormMario_Load;
            MarioMenuStrip.ResumeLayout(false);
            MarioMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MarioMenuStrip;
        private ToolStripMenuItem ActionsToolStripMenuItem;
        private ToolStripMenuItem LookUpsToolStripMenuItem;
        private ToolStripMenuItem CheckUBLDocumentToolStripMenuItem;
        private ToolStripMenuItem CloseAppToolStripMenuItem;
        private ToolStripMenuItem VpeToolStripMenuItem;
        private ToolStripMenuItem AutoPageBreakTestToolStripMenuItem;
        private ToolStripMenuItem InfoToolStripMenuItem;
        private ToolStripMenuItem PleskToolStripMenuItem;
        private ToolStripMenuItem HostingToolStripMenuItem;
        private ToolStripMenuItem WebmailToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem CommandPromptToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem UBLValidatorToolStripMenuItem;
        private ToolStripMenuItem UBLDocsBillingToolStripMenuItem;
    }
}