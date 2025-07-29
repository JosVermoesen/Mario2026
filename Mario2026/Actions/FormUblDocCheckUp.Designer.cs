namespace Mario2026
{
    partial class FormUblDocCheckUp
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
            LabelFile = new Label();
            LabelIssueDate = new Label();
            label3 = new Label();
            LabelInvoiceId = new Label();
            label1 = new Label();
            ButtonCheckUBL = new Button();
            SuspendLayout();
            // 
            // LabelFile
            // 
            LabelFile.AutoSize = true;
            LabelFile.Location = new Point(103, 13);
            LabelFile.Name = "LabelFile";
            LabelFile.Size = new Size(230, 15);
            LabelFile.TabIndex = 0;
            LabelFile.Text = "Sleep het UBL xml bestand naar dit venster";
            LabelFile.TextChanged += LabelFile_TextChanged;
            // 
            // LabelIssueDate
            // 
            LabelIssueDate.AutoSize = true;
            LabelIssueDate.Location = new Point(125, 63);
            LabelIssueDate.Name = "LabelIssueDate";
            LabelIssueDate.Size = new Size(0, 15);
            LabelIssueDate.TabIndex = 9;
            // 
            // label3
            // 
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 8;
            label3.Text = "Datum Document:";
            // 
            // LabelInvoiceId
            // 
            LabelInvoiceId.AutoSize = true;
            LabelInvoiceId.Location = new Point(125, 38);
            LabelInvoiceId.Name = "LabelInvoiceId";
            LabelInvoiceId.Size = new Size(0, 15);
            LabelInvoiceId.TabIndex = 7;
            // 
            // label1
            // 
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 6;
            label1.Text = "Factuur Nummer:";
            // 
            // ButtonCheckUBL
            // 
            ButtonCheckUBL.Enabled = false;
            ButtonCheckUBL.Location = new Point(12, 9);
            ButtonCheckUBL.Name = "ButtonCheckUBL";
            ButtonCheckUBL.Size = new Size(75, 23);
            ButtonCheckUBL.TabIndex = 10;
            ButtonCheckUBL.Text = "Start";
            ButtonCheckUBL.UseVisualStyleBackColor = true;
            ButtonCheckUBL.Click += ButtonCheckUBL_Click;
            // 
            // FormUblDocCheckUp
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonCheckUBL);
            Controls.Add(LabelIssueDate);
            Controls.Add(label3);
            Controls.Add(LabelInvoiceId);
            Controls.Add(label1);
            Controls.Add(LabelFile);
            Name = "FormUblDocCheckUp";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            DragDrop += FormUblDocCheckUp_DragDrop;
            DragEnter += FormUblDocCheckUp_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelFile;
        private Label LabelIssueDate;
        private Label label3;
        private Label LabelInvoiceId;
        private Label label1;
        private Button ButtonCheckUBL;
    }
}