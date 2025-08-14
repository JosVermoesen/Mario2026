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
            ButtonCheckConnectivity = new Button();
            LabelResultConnectivityCheck = new Label();
            SuspendLayout();
            // 
            // ButtonCheckConnectivity
            // 
            ButtonCheckConnectivity.Location = new Point(12, 16);
            ButtonCheckConnectivity.Name = "ButtonCheckConnectivity";
            ButtonCheckConnectivity.Size = new Size(122, 23);
            ButtonCheckConnectivity.TabIndex = 0;
            ButtonCheckConnectivity.Text = "Test Connectivity";
            ButtonCheckConnectivity.UseVisualStyleBackColor = true;
            ButtonCheckConnectivity.Click += ButtonCheckConnectivity_Click;
            // 
            // LabelResultConnectivityCheck
            // 
            LabelResultConnectivityCheck.Location = new Point(140, 16);
            LabelResultConnectivityCheck.Name = "LabelResultConnectivityCheck";
            LabelResultConnectivityCheck.Size = new Size(297, 52);
            LabelResultConnectivityCheck.TabIndex = 1;
            LabelResultConnectivityCheck.Text = "Result";
            // 
            // FormAdemicoTesting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 232);
            Controls.Add(LabelResultConnectivityCheck);
            Controls.Add(ButtonCheckConnectivity);
            Name = "FormAdemicoTesting";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAdemicoTesting";
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonCheckConnectivity;
        private Label LabelResultConnectivityCheck;
    }
}