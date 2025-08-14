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
            TabCheckVat = new TabPage();
            LabelVatResponseContent = new Label();
            ButtonVatLookUp = new Button();
            TextBoxVatNumber = new TextBox();
            TabCheckPeppol = new TabPage();
            LabelPeppolResponseContent = new Label();
            ButtonLookUpPeppolID = new Button();
            TextBoxPeppolID = new TextBox();
            TabControlVariousTools.SuspendLayout();
            TabCheckVat.SuspendLayout();
            TabCheckPeppol.SuspendLayout();
            SuspendLayout();
            // 
            // TabControlVariousTools
            // 
            TabControlVariousTools.Controls.Add(TabCheckVat);
            TabControlVariousTools.Controls.Add(TabCheckPeppol);
            TabControlVariousTools.Dock = DockStyle.Fill;
            TabControlVariousTools.Location = new Point(0, 0);
            TabControlVariousTools.Name = "TabControlVariousTools";
            TabControlVariousTools.SelectedIndex = 0;
            TabControlVariousTools.Size = new Size(576, 450);
            TabControlVariousTools.TabIndex = 0;
            // 
            // TabCheckVat
            // 
            TabCheckVat.Controls.Add(LabelVatResponseContent);
            TabCheckVat.Controls.Add(ButtonVatLookUp);
            TabCheckVat.Controls.Add(TextBoxVatNumber);
            TabCheckVat.Location = new Point(4, 24);
            TabCheckVat.Name = "TabCheckVat";
            TabCheckVat.Padding = new Padding(3);
            TabCheckVat.Size = new Size(568, 422);
            TabCheckVat.TabIndex = 0;
            TabCheckVat.Text = "Controle BTW Nummer";
            TabCheckVat.UseVisualStyleBackColor = true;
            // 
            // LabelVatResponseContent
            // 
            LabelVatResponseContent.BorderStyle = BorderStyle.FixedSingle;
            LabelVatResponseContent.Dock = DockStyle.Bottom;
            LabelVatResponseContent.Location = new Point(3, 34);
            LabelVatResponseContent.Name = "LabelVatResponseContent";
            LabelVatResponseContent.Size = new Size(562, 385);
            LabelVatResponseContent.TabIndex = 3;
            // 
            // ButtonVatLookUp
            // 
            ButtonVatLookUp.Location = new Point(142, 6);
            ButtonVatLookUp.Name = "ButtonVatLookUp";
            ButtonVatLookUp.Size = new Size(79, 23);
            ButtonVatLookUp.TabIndex = 1;
            ButtonVatLookUp.Text = "Opzoeken";
            ButtonVatLookUp.UseVisualStyleBackColor = true;
            ButtonVatLookUp.Click += ButtonVatLookUp_Click;
            // 
            // TextBoxVatNumber
            // 
            TextBoxVatNumber.Location = new Point(8, 6);
            TextBoxVatNumber.Name = "TextBoxVatNumber";
            TextBoxVatNumber.Size = new Size(128, 23);
            TextBoxVatNumber.TabIndex = 0;
            TextBoxVatNumber.Text = "BE0440058217";
            // 
            // TabCheckPeppol
            // 
            TabCheckPeppol.Controls.Add(LabelPeppolResponseContent);
            TabCheckPeppol.Controls.Add(ButtonLookUpPeppolID);
            TabCheckPeppol.Controls.Add(TextBoxPeppolID);
            TabCheckPeppol.Location = new Point(4, 24);
            TabCheckPeppol.Name = "TabCheckPeppol";
            TabCheckPeppol.Size = new Size(568, 422);
            TabCheckPeppol.TabIndex = 1;
            TabCheckPeppol.Text = "Controle Peppol ID";
            TabCheckPeppol.UseVisualStyleBackColor = true;
            // 
            // LabelPeppolResponseContent
            // 
            LabelPeppolResponseContent.BorderStyle = BorderStyle.FixedSingle;
            LabelPeppolResponseContent.Dock = DockStyle.Bottom;
            LabelPeppolResponseContent.Location = new Point(0, 29);
            LabelPeppolResponseContent.Name = "LabelPeppolResponseContent";
            LabelPeppolResponseContent.Size = new Size(568, 393);
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
            // FormLookUpTools
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 450);
            Controls.Add(TabControlVariousTools);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormLookUpTools";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Opzoekingen";
            TabControlVariousTools.ResumeLayout(false);
            TabCheckVat.ResumeLayout(false);
            TabCheckVat.PerformLayout();
            TabCheckPeppol.ResumeLayout(false);
            TabCheckPeppol.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControlVariousTools;
        private TabPage TabCheckVat;
        private Label LabelVatResponseContent;        
        private Button ButtonVatLookUp;
        private TextBox TextBoxVatNumber;
        private TabPage TabCheckPeppol;
        private Label LabelPeppolResponseContent;
        private Button ButtonLookUpPeppolID;
        private TextBox TextBoxPeppolID;
    }
}