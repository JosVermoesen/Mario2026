using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            ToolStripStatusLabel.Text = "Bezig...";
            var response = await PeppolClient.CheckConnection(new HttpClient());
            if (response != null)
            {
                ToolStripStatusLabel.Text = response;
            }
            else
            {
                MessageBox.Show(response, "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        async private void ButtonGetPeppolRegistrations_Click(object sender, EventArgs e)
        {
            // Example usage in a WinForms/WPF/Console app
            ToolStripStatusLabel.Text = "Bezig...";
            string country = ""; // Example country code
            string peppolRegistrationScheme = ""; // Example scheme code, e.g., "0208"
            string peppolRegistrationIdentifier = "0440058217"; // Example identifier, e.g., "0440058217"
            string peppolSupportedDocument = ""; // Example supported document, e.g., "PEPPOL_BIS_BILLING_UBL_INVOICE_V3"

            try
            {
                var respons = await PeppolClient.GetPeppolRegistrationAsync(
                    country,
                    peppolRegistrationScheme,
                    peppolRegistrationIdentifier,
                    peppolSupportedDocument);

                if (respons.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ToolStripStatusLabel.Text = "Registration found (200).";
                }
                else if (respons.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    ToolStripStatusLabel.Text = "Unauthorized (401) — check credentials.";
                }
                else if (respons.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ToolStripStatusLabel.Text = "Not found (404) — no matching registration.";
                }
                else
                {
                    ToolStripStatusLabel.Text = $"Status: {(int)respons.StatusCode} {respons.StatusCode}";
                }

                LabelResult.Text = "Response body:\n" + respons.ResponseBody;
            }
            catch (Exception ex)
            {
                ToolStripStatusLabel.Text = $"Request failed: {ex.Message}";
            }
        }


    }
}
