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


        async private void ButtonGetPeppolRegistrations_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel.Text = "Bezig...";
            string country = TextBoxCountryCode.Text; // Example country code
            string peppolRegistrationScheme = TextBoxRegScheme.Text; // Example scheme code, e.g., "0208"
            string peppolRegistrationIdentifier = TextBoxRegIdentifier.Text; // Example identifier, e.g., "0529835180"
            string peppolSupportedDocument = TextBoxSupportedDocument.Text; // Example supported document, e.g., "PEPPOL_BIS_BILLING_UBL_INVOICE_V3"
            string legalEntityId = TextBoxLegalEntityId.Text; // Example legal entity ID, if needed

            try
            {
                var respons = await AdemicoClient.GetPeppolRegistrationAsync(
                    country,
                    peppolRegistrationScheme,
                    peppolRegistrationIdentifier,
                    peppolSupportedDocument,
                    legalEntityId);

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

                if (!string.IsNullOrEmpty(respons.ResponseBody))
                {
                    var deserializedString = JsonConvert.DeserializeObject(respons.ResponseBody);
                    RichTextBoxResult.Text = JsonConvert.SerializeObject(deserializedString, Formatting.Indented);
                }
                else
                {
                    RichTextBoxResult.Text = "No response body.";
                }
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

            var result = await AdemicoClient.CreateOrRegisterLegalEntityAsync(request: req);

            ToolStripStatusLabel.Text = $"Status: {(int)result.StatusCode} {result.StatusCode}";
            MessageBox.Show($"Response: {result.ResponseBody}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ButtonEntityNew.Enabled = false; // Disable the button after creating the entity
            TextBoxCompanyName.Clear();
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
                    // LabelResult.Text = responseContent;
                    var deserializedString = JsonConvert.DeserializeObject(responseContent);
                    RichTextBoxResult.Text = JsonConvert.SerializeObject(deserializedString, Formatting.Indented);


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

        async private void ButtonNotifications_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel.Text = "Bezig...";
            var jsonResponse = await AdemicoClient.GetNotificationsAsync(
                transmissionId: "", // "f8a591c77b2211f0b1ed0af13d778bd4"
                documentId: "test-31",
                eventType: "", // "INVOICE_RESPONSE_RECEIVED"
                peppolDocumentType: "", // "INVOICE"
                sender: "9925:BE0440058217",
                receiver: "0208:0440058217",
                startDateTime: "", // "2023-07-25T11:03:26.688Z"
                endDateTime: "", // "2023-07-29T11:03:26.688Z"
                page: "",
                pageSize: ""
            );
                        
            if (jsonResponse != null)
            {
                ToolStripStatusLabel.Text = "Notifications retrieved successfully.";
                var deserializedString = JsonConvert.DeserializeObject(jsonResponse);
                RichTextBoxResult.Text = JsonConvert.SerializeObject(deserializedString, Formatting.Indented);                
            }
            else
            {
                ToolStripStatusLabel.Text = "Failed to retrieve notifications.";
                RichTextBoxResult.Text = "";
            }
        }
    }
}
