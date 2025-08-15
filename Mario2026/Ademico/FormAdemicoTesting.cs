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
            string country = "BE"; // Example country code
            string peppolRegistrationScheme = ""; // Example scheme code, e.g., "0208"
            string peppolRegistrationIdentifier = ""; // Example identifier, e.g., "0440058217"
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

        async private void ButtonEntityNew_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel.Text = "Bezig...";
            //try
            //{
            //    var response = await PeppolClient.CreateLegalEntityAsync(new HttpClient(), "BE", "0208", "0440058217", "PEPPOL_BIS_BILLING_UBL_INVOICE_V3");
            //    if (response.StatusCode == System.Net.HttpStatusCode.Created)
            //    {
            //        ToolStripStatusLabel.Text = "Entity created successfully (201).";
            //    }
            //    else
            //    {
            //        ToolStripStatusLabel.Text = $"Failed to create entity: {(int)response.StatusCode} {response.StatusCode}";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ToolStripStatusLabel.Text = $"Error creating entity: {ex.Message}";
            //}


            // Build the request using your Postman example values
            var req = new CreateLegalEntityRequest
            {
                LegalEntityDetails = new LegalEntityDetails
                {
                    PublishInPeppolDirectory = true,
                    Name = "Erika Callebaut",
                    CountryCode = "BE",
                    GeographicalInformation = "Schroverstraat 102, 9310 Aalst",
                    WebsiteURL = "",
                    Contacts =
                    {
                        new Contact
                        {
                            ContactType = "public",
                            Name = "Callebaut Erika",
                            PhoneNumber = "+32 53225925",
                            Email = "erika@telenet.be"
                        }
                    },
                    AdditionalInformation = "Wij zijn gespecialiseerd in huishoudhulp"
                },

                PeppolRegistrations =
                {
                    new PeppolRegistrationX
                    {
                        PeppolIdentifier = new PeppolIdentifier
                        {
                            Scheme = "0208",
                            Identifier = "0885799743"
                        },
                    SupportedDocuments =
                    {
                            "PEPPOL_BIS_BILLING_UBL_INVOICE_V3",
                            "PEPPOL_BIS_BILLING_UBL_CREDIT_NOTE_V3",
                            "PEPPOL_MESSAGE_LEVEL_RESPONSE_TRANSACTION_3_0",
                            "PEPPOL_INVOICE_RESPONSE_TRANSACTION_3_0"
                     },
                    PeppolRegistration = true
                }
            }
            };

            var result = await PeppolClient.CreateOrRegisterLegalEntityAsync(request: req);

            ToolStripStatusLabel.Text = $"Status: {(int)result.StatusCode} {result.StatusCode}";
            MessageBox.Show($"Response: {result.ResponseBody}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
