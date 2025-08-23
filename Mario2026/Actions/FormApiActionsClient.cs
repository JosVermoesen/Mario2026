using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario2026.Ademico
{
    public partial class FormApiActionsClient : Form
    {
        public FormApiActionsClient()
        {
            InitializeComponent();
        }

        async private void ButtonCheckConnectivity_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel.Text = "Bezig...";
            var response = await AdemicoClient.CheckConnection(new HttpClient());
            if (response != null)
            {
                ToolStripStatusLabel.Text = response;
            }
            else
            {
                MessageBox.Show(response, "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }        
    }
}
