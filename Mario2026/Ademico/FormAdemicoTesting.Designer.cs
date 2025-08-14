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
            TabResponse = new TabPage();
            LabelResult = new Label();
            StatusStrip = new StatusStrip();
            ToolStripStatusLabel = new ToolStripStatusLabel();
            TabControlVariousTools.SuspendLayout();
            TabActions.SuspendLayout();
            TabResponse.SuspendLayout();
            StatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // TabControlVariousTools
            // 
            TabControlVariousTools.Controls.Add(TabActions);
            TabControlVariousTools.Controls.Add(TabResponse);
            TabControlVariousTools.Dock = DockStyle.Fill;
            TabControlVariousTools.Location = new Point(0, 0);
            TabControlVariousTools.Name = "TabControlVariousTools";
            TabControlVariousTools.SelectedIndex = 0;
            TabControlVariousTools.Size = new Size(556, 362);
            TabControlVariousTools.TabIndex = 3;
            // 
            // TabActions
            // 
            TabActions.Controls.Add(ButtonGetPeppolRegistrations);
            TabActions.Controls.Add(ButtonCheckConnectivity);
            TabActions.Location = new Point(4, 24);
            TabActions.Name = "TabActions";
            TabActions.Padding = new Padding(3);
            TabActions.Size = new Size(548, 334);
            TabActions.TabIndex = 0;
            TabActions.Text = "Actions";
            TabActions.UseVisualStyleBackColor = true;
            // 
            // ButtonGetPeppolRegistrations
            // 
            ButtonGetPeppolRegistrations.Location = new Point(136, 6);
            ButtonGetPeppolRegistrations.Name = "ButtonGetPeppolRegistrations";
            ButtonGetPeppolRegistrations.Size = new Size(176, 23);
            ButtonGetPeppolRegistrations.TabIndex = 3;
            ButtonGetPeppolRegistrations.Text = "Get Peppol Registration(s)";
            ButtonGetPeppolRegistrations.UseVisualStyleBackColor = true;
            ButtonGetPeppolRegistrations.Click += ButtonGetPeppolRegistrations_Click;
            // 
            // ButtonCheckConnectivity
            // 
            ButtonCheckConnectivity.Location = new Point(8, 6);
            ButtonCheckConnectivity.Name = "ButtonCheckConnectivity";
            ButtonCheckConnectivity.Size = new Size(122, 23);
            ButtonCheckConnectivity.TabIndex = 1;
            ButtonCheckConnectivity.Text = "Test Connectivity";
            ButtonCheckConnectivity.UseVisualStyleBackColor = true;
            ButtonCheckConnectivity.Click += ButtonCheckConnectivity_Click;
            // 
            // TabResponse
            // 
            TabResponse.Controls.Add(LabelResult);
            TabResponse.Location = new Point(4, 24);
            TabResponse.Name = "TabResponse";
            TabResponse.Size = new Size(548, 334);
            TabResponse.TabIndex = 1;
            TabResponse.Text = "Resultaat";
            TabResponse.UseVisualStyleBackColor = true;
            // 
            // LabelResult
            // 
            LabelResult.Dock = DockStyle.Fill;
            LabelResult.Location = new Point(0, 0);
            LabelResult.Name = "LabelResult";
            LabelResult.Size = new Size(548, 334);
            LabelResult.TabIndex = 7;
            LabelResult.Text = "Result";
            // 
            // StatusStrip
            // 
            StatusStrip.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel });
            StatusStrip.Location = new Point(0, 340);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(556, 22);
            StatusStrip.TabIndex = 4;
            // 
            // ToolStripStatusLabel
            // 
            ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            ToolStripStatusLabel.Size = new Size(39, 17);
            ToolStripStatusLabel.Text = "Ready";
            // 
            // FormAdemicoTesting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 362);
            Controls.Add(StatusStrip);
            Controls.Add(TabControlVariousTools);
            Name = "FormAdemicoTesting";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAdemicoTesting";
            TabControlVariousTools.ResumeLayout(false);
            TabActions.ResumeLayout(false);
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
    }
}