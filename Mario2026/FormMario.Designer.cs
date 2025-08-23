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
            PeppolActionsToolStripMenuItem = new ToolStripMenuItem();
            UserSettingsMenuItem = new ToolStripMenuItem();
            CloseAppToolStripMenuItem = new ToolStripMenuItem();
            VpeToolStripMenuItem = new ToolStripMenuItem();
            AutoPageBreakTestToolStripMenuItem = new ToolStripMenuItem();
            InfoToolStripMenuItem = new ToolStripMenuItem();
            VsoftToolStripMenuItem = new ToolStripMenuItem();
            PleskToolStripMenuItem = new ToolStripMenuItem();
            HostingToolStripMenuItem = new ToolStripMenuItem();
            WebmailToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            CommandPromptToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            UBLValidatorToolStripMenuItem = new ToolStripMenuItem();
            UBLDocsBillingToolStripMenuItem = new ToolStripMenuItem();
            PeppolToolStripMenuItem = new ToolStripMenuItem();
            TestingToolStripMenuItem = new ToolStripMenuItem();
            SettingsToolStripMenuItem = new ToolStripMenuItem();
            MarioMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MarioMenuStrip
            // 
            MarioMenuStrip.Items.AddRange(new ToolStripItem[] { ActionsToolStripMenuItem, VpeToolStripMenuItem, PeppolToolStripMenuItem, InfoToolStripMenuItem });
            MarioMenuStrip.Location = new Point(0, 0);
            MarioMenuStrip.Name = "MarioMenuStrip";
            MarioMenuStrip.Size = new Size(352, 24);
            MarioMenuStrip.TabIndex = 1;
            MarioMenuStrip.Text = "menuStrip1";
            // 
            // ActionsToolStripMenuItem
            // 
            ActionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { PeppolActionsToolStripMenuItem, UserSettingsMenuItem, CloseAppToolStripMenuItem });
            ActionsToolStripMenuItem.Name = "ActionsToolStripMenuItem";
            ActionsToolStripMenuItem.Size = new Size(51, 20);
            ActionsToolStripMenuItem.Text = "Acties";
            // 
            // PeppolActionsToolStripMenuItem
            // 
            PeppolActionsToolStripMenuItem.Name = "PeppolActionsToolStripMenuItem";
            PeppolActionsToolStripMenuItem.Size = new Size(189, 22);
            PeppolActionsToolStripMenuItem.Text = "Peppol Acties";
            PeppolActionsToolStripMenuItem.Click += PeppolActionsToolStripMenuItem_Click;
            // 
            // UserSettingsMenuItem
            // 
            UserSettingsMenuItem.Name = "UserSettingsMenuItem";
            UserSettingsMenuItem.Size = new Size(189, 22);
            UserSettingsMenuItem.Text = "Gebruiker Instellingen";
            UserSettingsMenuItem.Click += UserSettingsMenuItem_Click;
            // 
            // CloseAppToolStripMenuItem
            // 
            CloseAppToolStripMenuItem.Name = "CloseAppToolStripMenuItem";
            CloseAppToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            CloseAppToolStripMenuItem.Size = new Size(189, 22);
            CloseAppToolStripMenuItem.Text = "Afsluiten";
            CloseAppToolStripMenuItem.Click += CloseAppToolStripMenuItem_Click;
            // 
            // VpeToolStripMenuItem
            // 
            VpeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AutoPageBreakTestToolStripMenuItem });
            VpeToolStripMenuItem.Name = "VpeToolStripMenuItem";
            VpeToolStripMenuItem.Size = new Size(39, 20);
            VpeToolStripMenuItem.Text = "VPE";
            VpeToolStripMenuItem.Visible = false;
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
            InfoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { VsoftToolStripMenuItem, PleskToolStripMenuItem, toolStripSeparator1, CommandPromptToolStripMenuItem, toolStripSeparator2, UBLValidatorToolStripMenuItem, UBLDocsBillingToolStripMenuItem });
            InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            InfoToolStripMenuItem.Size = new Size(24, 20);
            InfoToolStripMenuItem.Text = "?";
            // 
            // VsoftToolStripMenuItem
            // 
            VsoftToolStripMenuItem.Name = "VsoftToolStripMenuItem";
            VsoftToolStripMenuItem.Size = new Size(174, 22);
            VsoftToolStripMenuItem.Text = "Vsoft";
            VsoftToolStripMenuItem.Click += VsoftToolStripMenuItem_Click;
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
            HostingToolStripMenuItem.Click += HostingToolStripMenuItem_Click;
            // 
            // WebmailToolStripMenuItem
            // 
            WebmailToolStripMenuItem.Name = "WebmailToolStripMenuItem";
            WebmailToolStripMenuItem.Size = new Size(166, 22);
            WebmailToolStripMenuItem.Text = "Webmail rv.be";
            WebmailToolStripMenuItem.Click += WebmailToolStripMenuItem_Click;
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
            CommandPromptToolStripMenuItem.Click += CommandPromptToolStripMenuItem_Click;
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
            UBLValidatorToolStripMenuItem.Click += UBLValidatorToolStripMenuItem_Click;
            // 
            // UBLDocsBillingToolStripMenuItem
            // 
            UBLDocsBillingToolStripMenuItem.Name = "UBLDocsBillingToolStripMenuItem";
            UBLDocsBillingToolStripMenuItem.Size = new Size(174, 22);
            UBLDocsBillingToolStripMenuItem.Text = "Docs Billing 3.0";
            UBLDocsBillingToolStripMenuItem.Click += UBLDocsBillingToolStripMenuItem_Click;
            // 
            // PeppolToolStripMenuItem
            // 
            PeppolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { TestingToolStripMenuItem, SettingsToolStripMenuItem });
            PeppolToolStripMenuItem.Name = "PeppolToolStripMenuItem";
            PeppolToolStripMenuItem.Size = new Size(71, 20);
            PeppolToolStripMenuItem.Text = "Peppol IO";
            PeppolToolStripMenuItem.Visible = false;
            // 
            // TestingToolStripMenuItem
            // 
            TestingToolStripMenuItem.Name = "TestingToolStripMenuItem";
            TestingToolStripMenuItem.Size = new Size(116, 22);
            TestingToolStripMenuItem.Text = "Testing";
            TestingToolStripMenuItem.Click += TestingToolStripMenuItem_Click;
            // 
            // SettingsToolStripMenuItem
            // 
            SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            SettingsToolStripMenuItem.Size = new Size(116, 22);
            SettingsToolStripMenuItem.Text = "Settings";
            SettingsToolStripMenuItem.Visible = false;
            SettingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
            // 
            // FormMario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 190);
            Controls.Add(MarioMenuStrip);
            IsMdiContainer = true;
            MainMenuStrip = MarioMenuStrip;
            Name = "FormMario";
            Text = "Mario";
            FormClosing += FormMario_FormClosing;
            Load += FormMario_Load;
            Shown += FormMario_Shown;
            MarioMenuStrip.ResumeLayout(false);
            MarioMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MarioMenuStrip;
        private ToolStripMenuItem ActionsToolStripMenuItem;
        private ToolStripMenuItem PeppolActionsToolStripMenuItem;
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
        private ToolStripMenuItem VsoftToolStripMenuItem;
        private ToolStripMenuItem PeppolToolStripMenuItem;
        private ToolStripMenuItem TestingToolStripMenuItem;
        private ToolStripMenuItem SettingsToolStripMenuItem;
        private ToolStripMenuItem UserSettingsMenuItem;
    }
}