using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario2026
{
    public partial class FormAdemicoTesting : Form
    {        

        public FormAdemicoTesting()
        {
            InitializeComponent();            
        }

        async private void ButtonCheckConnectivity_Click(object sender, EventArgs e)
        {
            LabelResultConnectivityCheck.Text = "Bezig...";
            var response = await PeppolClient.CheckConnection(new HttpClient ());            
            if (response != null)
            {
                LabelResultConnectivityCheck.Text = response;                
            }
            else
            {                
                MessageBox.Show (response, "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
