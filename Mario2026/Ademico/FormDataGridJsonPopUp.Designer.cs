namespace Mario2026.Ademico
{
    partial class FormDataGridJsonPopUp
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
            TabControl = new TabControl();
            TabGridView = new TabPage();
            DataGridView = new DataGridView();
            TabJsonView = new TabPage();
            RichTextBox = new RichTextBox();
            TabControl.SuspendLayout();
            TabGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            TabJsonView.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Controls.Add(TabGridView);
            TabControl.Controls.Add(TabJsonView);
            TabControl.Dock = DockStyle.Fill;
            TabControl.Location = new Point(0, 0);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(1196, 450);
            TabControl.TabIndex = 1;
            // 
            // TabGridView
            // 
            TabGridView.Controls.Add(DataGridView);
            TabGridView.Location = new Point(4, 24);
            TabGridView.Name = "TabGridView";
            TabGridView.Padding = new Padding(3);
            TabGridView.Size = new Size(1188, 422);
            TabGridView.TabIndex = 0;
            TabGridView.Text = "Tabel";
            TabGridView.UseVisualStyleBackColor = true;
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Dock = DockStyle.Fill;
            DataGridView.Location = new Point(3, 3);
            DataGridView.Name = "DataGridView";
            DataGridView.ReadOnly = true;
            DataGridView.Size = new Size(1182, 416);
            DataGridView.TabIndex = 2;
            // 
            // TabJsonView
            // 
            TabJsonView.Controls.Add(RichTextBox);
            TabJsonView.Location = new Point(4, 24);
            TabJsonView.Name = "TabJsonView";
            TabJsonView.Padding = new Padding(3);
            TabJsonView.Size = new Size(1188, 422);
            TabJsonView.TabIndex = 1;
            TabJsonView.Text = "Json";
            TabJsonView.UseVisualStyleBackColor = true;
            // 
            // RichTextBox
            // 
            RichTextBox.Dock = DockStyle.Fill;
            RichTextBox.Location = new Point(3, 3);
            RichTextBox.Name = "RichTextBox";
            RichTextBox.ReadOnly = true;
            RichTextBox.Size = new Size(1182, 416);
            RichTextBox.TabIndex = 0;
            RichTextBox.Text = "";
            // 
            // FormDataGridJsonPopUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 450);
            Controls.Add(TabControl);
            Name = "FormDataGridJsonPopUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormJsonTableTesting";
            TabControl.ResumeLayout(false);
            TabGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            TabJsonView.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControl;
        private TabPage TabGridView;
        private DataGridView DataGridView;
        private TabPage TabJsonView;
        private RichTextBox RichTextBox;
    }
}