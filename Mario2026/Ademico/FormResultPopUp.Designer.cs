namespace Mario2026.Ademico
{
    partial class FormResultPopUp
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
            ButtonClose = new Button();
            RichTextBoxResultPopUp = new RichTextBox();
            SuspendLayout();
            // 
            // ButtonClose
            // 
            ButtonClose.Location = new Point(153, 137);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(75, 23);
            ButtonClose.TabIndex = 0;
            ButtonClose.Text = "Close";
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // RichTextBoxResultPopUp
            // 
            RichTextBoxResultPopUp.Dock = DockStyle.Fill;
            RichTextBoxResultPopUp.Location = new Point(0, 0);
            RichTextBoxResultPopUp.Name = "RichTextBoxResultPopUp";
            RichTextBoxResultPopUp.ReadOnly = true;
            RichTextBoxResultPopUp.Size = new Size(377, 301);
            RichTextBoxResultPopUp.TabIndex = 1;
            RichTextBoxResultPopUp.Text = "";            
            // 
            // FormResultPopUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 301);
            Controls.Add(ButtonClose);
            Controls.Add(RichTextBoxResultPopUp);
            Name = "FormResultPopUp";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormResultPopUp";
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonClose;
        private RichTextBox RichTextBoxResultPopUp;
    }
}