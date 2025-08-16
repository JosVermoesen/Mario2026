namespace Mario2026
{
    partial class FormLookUpTools
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
            TabCheckPeppol = new TabPage();
            LabelPeppolResponseContent = new Label();
            ButtonLookUpPeppolID = new Button();
            TextBoxPeppolID = new TextBox();
            ButtonClose = new Button();
            TabControlVariousTools.SuspendLayout();
            TabCheckPeppol.SuspendLayout();
            SuspendLayout();
            // 
            // TabControlVariousTools
            // 
            TabControlVariousTools.Controls.Add(TabCheckPeppol);
            TabControlVariousTools.Dock = DockStyle.Fill;
            TabControlVariousTools.Location = new Point(0, 0);
            TabControlVariousTools.Name = "TabControlVariousTools";
            TabControlVariousTools.SelectedIndex = 0;
            TabControlVariousTools.Size = new Size(421, 386);
            TabControlVariousTools.TabIndex = 0;
            // 
            // TabCheckPeppol
            // 
            TabCheckPeppol.Controls.Add(LabelPeppolResponseContent);
            TabCheckPeppol.Controls.Add(ButtonLookUpPeppolID);
            TabCheckPeppol.Controls.Add(TextBoxPeppolID);
            TabCheckPeppol.Controls.Add(ButtonClose);
            TabCheckPeppol.Location = new Point(4, 24);
            TabCheckPeppol.Name = "TabCheckPeppol";
            TabCheckPeppol.Size = new Size(413, 358);
            TabCheckPeppol.TabIndex = 1;
            TabCheckPeppol.Text = "Controle Peppol ID";
            TabCheckPeppol.UseVisualStyleBackColor = true;
            // 
            // LabelPeppolResponseContent
            // 
            LabelPeppolResponseContent.BorderStyle = BorderStyle.FixedSingle;
            LabelPeppolResponseContent.Dock = DockStyle.Bottom;
            LabelPeppolResponseContent.Location = new Point(0, 32);
            LabelPeppolResponseContent.Name = "LabelPeppolResponseContent";
            LabelPeppolResponseContent.Size = new Size(413, 326);
            LabelPeppolResponseContent.TabIndex = 6;
            // 
            // ButtonLookUpPeppolID
            // 
            ButtonLookUpPeppolID.Location = new Point(142, 3);
            ButtonLookUpPeppolID.Name = "ButtonLookUpPeppolID";
            ButtonLookUpPeppolID.Size = new Size(79, 23);
            ButtonLookUpPeppolID.TabIndex = 5;
            ButtonLookUpPeppolID.Text = "Opzoeken";
            ButtonLookUpPeppolID.UseVisualStyleBackColor = true;
            ButtonLookUpPeppolID.Click += ButtonLookUpPeppolID_Click;
            // 
            // TextBoxPeppolID
            // 
            TextBoxPeppolID.Location = new Point(8, 3);
            TextBoxPeppolID.Name = "TextBoxPeppolID";
            TextBoxPeppolID.Size = new Size(128, 23);
            TextBoxPeppolID.TabIndex = 4;
            TextBoxPeppolID.Text = "0208:0423100736";
            // 
            // ButtonClose
            // 
            ButtonClose.Location = new Point(456, 287);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(75, 23);
            ButtonClose.TabIndex = 1;
            ButtonClose.Text = "Close";
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // FormLookUpTools
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = ButtonClose;
            ClientSize = new Size(421, 386);
            Controls.Add(TabControlVariousTools);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormLookUpTools";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Opzoekingen";
            TabControlVariousTools.ResumeLayout(false);
            TabCheckPeppol.ResumeLayout(false);
            TabCheckPeppol.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControlVariousTools;
        private TabPage TabCheckPeppol;
        private Label LabelPeppolResponseContent;
        private Button ButtonLookUpPeppolID;
        private TextBox TextBoxPeppolID;
        private Button ButtonClose;
    }
}