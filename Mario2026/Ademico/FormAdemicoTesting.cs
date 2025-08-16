using Newtonsoft.Json;
using System.Globalization;

namespace Mario2026
{
    public partial class FormAdemicoTesting : Form
    {
        private readonly HttpClient httpCheck;
        public FormAdemicoTesting()
        {
            InitializeComponent();
            httpCheck = new HttpClient(); // Initialize HttpClient instance                        
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
                    ToolStripStatusLabel.Text = "Registration(s) found (200).";
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
                    Name = TextBoxCompanyName.Text,
                    CountryCode = "BE",
                    GeographicalInformation = TextBoxGeographicalInformation.Text,
                    WebsiteURL = "",
                    Contacts =
                    {
                        new Contact
                        {
                            ContactType = "public",
                            Name = "Vsoft Support",
                            PhoneNumber = "",
                            Email = "support@vsoft.be"
                        }
                    },
                    AdditionalInformation = ""
                },

                PeppolRegistrations =
                {
                    new PeppolRegistrationX
                    {
                        PeppolIdentifier = new PeppolIdentifier
                        {
                            Scheme = "0208",
                            Identifier = TextBoxIdentifier.Text
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
            ButtonEntityNew.Enabled = false; // Disable the button after creating the entity
            TextBoxCompanyName .Clear();
            TextBoxGeographicalInformation.Clear();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        async private void ButtonLookUp_Click(object sender, EventArgs e)
        {
            if (TextBoxIdentifier.Text.Length == 12)
            {
                ToolStripStatusLabel.Text = "Bezig...";

                string vatNumber = TextBoxIdentifier.Text;
                string countryCode = vatNumber[..2];
                string vat = vatNumber[2..];

                string url = "https://ec.europa.eu/taxation_customs/vies/rest-api/ms/" + countryCode + "/vat/" + vat;

                try
                {
                    HttpResponseMessage response = await httpCheck.GetAsync(url); // Use the HttpClient instance
                    response.EnsureSuccessStatusCode(); // Throws if not successful
                    string responseContent = await response.Content.ReadAsStringAsync();
                    LabelResult.Text = responseContent;

                    // Deserialize into VatResponse object
                    VatResponse? data = JsonConvert.DeserializeObject<VatResponse>(responseContent);

                    // Access fields
                    if (data != null)
                    {
                        string? address = data.Address;

                        if (data?.IsValid == true)
                        {                            
                            TextBoxCompanyName.Text = ToTitleCase(data.Name ?? string.Empty);
                            TextBoxGeographicalInformation.Text = address?.Replace("\n", " - ");

                            ToolStripStatusLabel.Text = "VAT number is valid.";
                            ButtonEntityNew.Enabled = true; // Enable the button if data is found
                        }
                        else
                        {
                            TextBoxCompanyName.Clear();
                            TextBoxGeographicalInformation.Clear();

                            ToolStripStatusLabel.Text = "VAT number is not valid.";
                            ButtonEntityNew.Enabled = false; // Disable the button if no data is found
                        }
                        //LabelResult.Text = $"Name: {data.Name}\nAddress: {address}\nRequest Date: {data.RequestDate}\nRequest Identifier: {data.RequestIdentifier}\nOriginal VAT Number: {data.OriginalVatNumber}\nVAT Number: {data.VatNumber}";
                        //if (data.ViesApproximate != null)
                        //{
                        //    LabelResult.Text += $"\nApproximate Match:\nName: {data.ViesApproximate.Name}\nStreet: {data.ViesApproximate.Street}\nPostal Code: {data.ViesApproximate.PostalCode}\nCity: {data.ViesApproximate.City}\nCompany Type: {data.ViesApproximate.CompanyType}";
                        //}                    
                    }
                }
                catch (HttpRequestException ex)
                {
                    ToolStripStatusLabel.Text = "Error: " + ex.Message;
                }
            }
        }

        public static string ToTitleCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // step 1: bring everything to lowercase
            var lower = input.ToLower(CultureInfo.CurrentCulture);

            // step 2: capitalize the first letter of each word
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(lower);
        }        
    }
}
