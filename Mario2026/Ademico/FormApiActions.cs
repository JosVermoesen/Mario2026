using Mario2026.Ademico;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Xml;

namespace Mario2026
{
    public partial class FormApiActions : Form
    {
        private readonly HttpClient httpCheck;
        public Form FormResultPopUp { get; set; }
        public Form FormDataGridJsonPopUp { get; set; }
        
        public FormApiActions()
        {
            InitializeComponent();
            httpCheck = new HttpClient(); // Initialize HttpClient instance

            FormResultPopUp = new FormResultPopUp { };
            FormDataGridJsonPopUp = new FormDataGridJsonPopUp { };
            
            // Ensure events are hooked up if you didn't use the Designer
            this.DragEnter += TabInvoiceSend_DragEnter;
            this.DragDrop += TabInvoiceSend_DragDrop;
            this.RadioButtonGetReceived.Checked = true;
        }

        // Connection check
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

        // Document Sending Tab
        private void TabInvoiceSend_DragEnter(object? sender, DragEventArgs e)
        {
            // Only allow file drops
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void TabInvoiceSend_DragDrop(object? sender, DragEventArgs e)
        {
            // Use pattern matching to simplify the type check and cast
            if (e.Data is DataObject dataObject && dataObject.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                // Example 1: Open each file with its default program
                // foreach (var file in files)
                //     Process.Start(new ProcessStartInfo(file) { UseShellExecute = true });

                // Example 2: Load the first file’s text into a TextBox
                if (File.Exists(files[0]))
                {
                    // Assuming you have a TextBox named LabelFile and LabelInvoiceId, LabelIssueDate
                    LabelFile.Text = files[0];
                }
            }
        }
        private void LabelFile_TextChanged(object sender, EventArgs e)
        {
            ButtonCheckFile.Enabled = !string.IsNullOrWhiteSpace(LabelFile.Text) && File.Exists(LabelFile.Text);
        }
        private void ButtonCheckFile_Click(object sender, EventArgs e)
        {
            string filePath = LabelFile.Text.Trim();
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            if (extension != ".xml") // && extension != ".ubl")
            {
                // Show a message box if the file is not a valid UBL XML file
                MessageBox.Show("Dit is geen geldig UBL XML bestand");
                ButtonSendUblDocument.Enabled = false; // Disable the button if the file is not valid
                return;
            }
            else
            {
                // HandleUblDocument(filePath);
                ReadUBLInvoice(filePath);


                // If the file is valid, enable the button
                ButtonSendUblDocument.Enabled = true;
                ToolStripStatusLabel.Text = "Bestand is een geldig UBL XML bestand.";
            }
        }
        async private void ButtonSendUblDocument_Click(object sender, EventArgs e)
        {
            string filePath = LabelFile.Text.Trim();

            try
            {
                var result = await AdemicoClient.PeppolInvoiceSender.SendUblInvoiceAsync(
                    filePath: filePath,
                    xC5Reporting: false // or true if needed for Singapore reporting
                );

                ToolStripStatusLabel.Text = $"Status: {(int)result.StatusCode} {result.StatusCode}";

                if (!string.IsNullOrEmpty(result.ResponseBody)) // Ensure ResponseBody is not null or empty
                {
                    var deserializedString = JsonConvert.DeserializeObject(value: result.ResponseBody);
                    RichTextBoxResult.Text = JsonConvert.SerializeObject(deserializedString, Newtonsoft.Json.Formatting.Indented);
                    DoPopUpResult(RichTextBoxResult.Text); // Show the result in a popup
                }
                else
                {
                    ToolStripStatusLabel.Text = "No response body.";
                }
            }
            catch (Exception ex)
            {
                ToolStripStatusLabel.Text = $"Error: {ex.Message}";
            }
        }

        // Document Retrieval Tab


        // Notifications Tab
        private void RadioButtonGetReceived_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonGetReceived.Checked)
            {
                // Enable the fields for received documents                
                TextBoxReceiver.Enabled = true;
                TextBoxReceiver.Text = "0208:0440058217"; // Default receiver for received documents
                TextBoxSender.Enabled = false;
                TextBoxSender.Text = "";
            }
            else
            {
                // Disable the fields for received documents
                TextBoxSender.Enabled = true;
                TextBoxSender.Text = "9925:BE0440058217"; // Default sender for sent documents
                TextBoxReceiver.Enabled = false;
                TextBoxReceiver.Text = "";
            }

        }
        async private void ButtonNotifications_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel.Text = "Bezig...";
            
            string eventType = RadioButtonGetReceived.Checked ? "DOCUMENT_RECEIVED" : "DOCUMENT_SENT";
            var jsonResponse = await AdemicoClient.GetNotificationsAsync(
                transmissionId: "", // "f8a591c77b2211f0b1ed0af13d778bd4"
                documentId: "",
                eventType: eventType, // "DOCUMENT_RECEIVED" or "DOCUMENT_SENT"
                peppolDocumentType: "", // "INVOICE"
                sender: TextBoxSender.Text, // "9925:BE0440058217",
                receiver: TextBoxReceiver.Text, // "0208:0440058217",
                startDateTime: "", // "2023-07-25T11:03:26.688Z"
                endDateTime: "", // "2023-07-29T11:03:26.688Z"
                page: "",
                pageSize: ""
            );

            if (jsonResponse != null)
            {
                ToolStripStatusLabel.Text = "Notifications retrieved successfully.";
                var deserializedString = JsonConvert.DeserializeObject(jsonResponse);
                RichTextBoxResult.Text = JsonConvert.SerializeObject(deserializedString, Newtonsoft.Json.Formatting.Indented);              
                DoPopUpNotificationData(RichTextBoxResult.Text); // Show the result in a popup with JSON table view
            }
            else
            {
                ToolStripStatusLabel.Text = "Failed to retrieve notifications.";
                RichTextBoxResult.Text = "";
            }
        }
                
        // Entities Tab
        async private void ButtonLookUp_Click(object sender, EventArgs e)
        {
            if (TextBoxIdentifier.Text.Length != 12) // Check if the VAT number is exactly 12 characters long
            {
                ToolStripStatusLabel.Text = "Voer een geldig BTW-nummer in (12 tekens).";
                return;
            }


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

                var deserializedString = JsonConvert.DeserializeObject(responseContent);
                RichTextBoxResult.Text = JsonConvert.SerializeObject(deserializedString, Newtonsoft.Json.Formatting.Indented);


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
                }
            }
            catch (HttpRequestException ex)
            {
                ToolStripStatusLabel.Text = "Error: " + ex.Message;
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
                    RichTextBoxResult.Text = JsonConvert.SerializeObject(deserializedString, Newtonsoft.Json.Formatting.Indented);
                    // DoPopUpResult(RichTextBoxResult.Text); // Show the result in a popup
                    DoPopUpEntitiesData(RichTextBoxResult.Text); // Show the result in a popup with JSON table view
                }
                else
                {
                    ToolStripStatusLabel.Text = "No response body.";
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

        // Close application
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Utility method to convert a string to title case
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

        // Read and parse UBL Invoice XML file
        private static void ReadUBLInvoice(string filePath)
        {
            var xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ns = new XmlNamespaceManager(xmlDoc.NameTable);
            ns.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            ns.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");

            var sb = new StringBuilder();

            // UBL Version
            var ublVersionNode = xmlDoc.SelectSingleNode("//cbc:UBLVersionID", ns);
            sb.AppendLine("UBL VersionID: " + (ublVersionNode?.InnerText ?? "not found"));

            // Document ID
            var invoiceIdNode = xmlDoc.SelectSingleNode("//cbc:ID", ns);
            sb.AppendLine("Document ID: " + (invoiceIdNode?.InnerText ?? "not found"));

            // IssueDate
            var issueDateNode = xmlDoc.SelectSingleNode("//cbc:IssueDate", ns);
            sb.AppendLine("IssueDate: " + (issueDateNode?.InnerText ?? "not found"));

            // DueDate
            var dueDateNode = xmlDoc.SelectSingleNode("//cbc:DueDate", ns);
            sb.AppendLine("DueDate: " + (dueDateNode?.InnerText ?? "not found"));

            // InvoiceTypeCode
            var invTypeNode = xmlDoc.SelectSingleNode("//cbc:InvoiceTypeCode", ns);
            if (invTypeNode != null)
            {
                var invoiceTypeCode = invTypeNode.InnerText;
                var listID = invTypeNode.Attributes?["listID"]?.Value ?? "";
                sb.AppendLine("invoiceTypeCode: " + invoiceTypeCode);
                sb.AppendLine("invoice listID: " + listID);
            }
            else
            {
                MessageBox.Show("InvoiceTypeCode element not found.");
            }

            // OrderReference
            var orderList = xmlDoc.SelectNodes("//cac:OrderReference", ns);
            if (orderList != null)
            {
                foreach (XmlNode ordNode in orderList)
                {
                    var orderId = ordNode.SelectSingleNode("cbc:ID", ns)?.InnerText ?? "Order ID: not available";
                    sb.AppendLine("Order ID: " + orderId);
                }
            }
            MessageBox.Show(sb.ToString(), "Testing UBL DATA versie 0.01", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Supplier info
            var supplierNode = xmlDoc.SelectSingleNode("//cac:AccountingSupplierParty/cac:Party", ns);
            if (supplierNode != null)
            {
                var msg = new StringBuilder();
                msg.AppendLine("Supplier info");
                msg.AppendLine("-------------");
                msg.AppendLine("endpointOndernemingsnummer " + NodeText(supplierNode, "cbc:EndpointID", ns));
                msg.AppendLine("supplierID: " + NodeText(supplierNode, "cac:PartyIdentification/cbc:ID", ns));
                msg.AppendLine("tradingName: " + NodeText(supplierNode, "cac:PartyName/cbc:Name", ns));
                msg.AppendLine("street: " + NodeText(supplierNode, "cac:PostalAddress/cbc:StreetName", ns));
                msg.AppendLine("city: " + NodeText(supplierNode, "cac:PostalAddress/cbc:CityName", ns));
                msg.AppendLine("postalZone: " + NodeText(supplierNode, "cac:PostalAddress/cbc:PostalZone", ns));
                msg.AppendLine("countryCode: " + NodeText(supplierNode, "cac:PostalAddress/cac:Country/cbc:IdentificationCode", ns));
                msg.AppendLine("vatNumber: " + NodeText(supplierNode, "cac:PartyTaxScheme/cbc:CompanyID", ns));
                MessageBox.Show(msg.ToString(), "Testing UBL DATA versie 0.01", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No AccountingSupplierParty element found.");
            }

            // Customer info
            var custNode = xmlDoc.SelectSingleNode("//cac:AccountingCustomerParty", ns);
            if (custNode != null)
            {
                var msg = new StringBuilder();
                msg.AppendLine("Customer info");
                msg.AppendLine("-------------");
                msg.AppendLine("custAssignedAccountID: " + NodeText(custNode, "cbc:CustomerAssignedAccountID", ns));
                msg.AppendLine("custEndpointID: " + NodeText(custNode, "cac:Party/cbc:EndpointID", ns));
                msg.AppendLine("custName: " + NodeText(custNode, "cac:Party/cac:PartyName/cbc:Name", ns));
                msg.AppendLine("custStreet: " + NodeText(custNode, "cac:Party/cac:PostalAddress/cbc:StreetName", ns));
                msg.AppendLine("custCity: " + NodeText(custNode, "cac:Party/cac:PostalAddress/cbc:CityName", ns));
                msg.AppendLine("custPostalZone: " + NodeText(custNode, "cac:Party/cac:PostalAddress/cbc:PostalZone", ns));
                msg.AppendLine("custCountryCode: " + NodeText(custNode, "cac:Party/cac:PostalAddress/cac:Country/cbc:IdentificationCode", ns));
                msg.AppendLine("custTaxID: " + NodeText(custNode, "cac:Party/cac:PartyTaxScheme/cbc:CompanyID", ns));
                msg.AppendLine("custTaxScheme: " + NodeText(custNode, "cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:ID", ns));
                MessageBox.Show(msg.ToString(), "Testing UBL DATA versie 0.01", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No AccountingCustomerParty element found.");
            }

            // PaymentMeans
            var pmNodes = xmlDoc.SelectNodes("//cac:PaymentMeans", ns);
            if (pmNodes != null && pmNodes.Count > 0)
            {
                var msg = new StringBuilder();
                msg.AppendLine("PaymentMeans");
                msg.AppendLine("------------");
                foreach (XmlNode pmNode in pmNodes)
                {
                    msg.AppendLine("PaymentMeansCode: " + NodeText(pmNode, "cbc:PaymentMeansCode", ns));
                    msg.AppendLine("PaymentID: " + NodeText(pmNode, "cbc:PaymentID", ns));
                    msg.AppendLine("Payee IBAN: " + NodeText(pmNode, "cac:PayeeFinancialAccount/cbc:ID", ns));
                    msg.AppendLine("Account Name: " + NodeText(pmNode, "cac:PayeeFinancialAccount/cbc:Name", ns));
                    msg.AppendLine("BIC/Branch ID: " + NodeText(pmNode, "cac:PayeeFinancialAccount/cac:FinancialInstitutionBranch/cbc:ID", ns));
                    msg.AppendLine();
                    msg.AppendLine("Card account (if present)");
                    msg.AppendLine("Card Account ID: " + NodeText(pmNode, "cac:CardAccount/cbc:ID", ns));
                    msg.AppendLine("Card Account Name: " + NodeText(pmNode, "cac:CardAccount/cbc:Name", ns));
                    msg.AppendLine();
                    msg.AppendLine("Direct debit mandate (if present)");
                    msg.AppendLine("Mandate ID: " + NodeText(pmNode, "cac:PaymentMandate/cbc:ID", ns));
                    msg.AppendLine("Mandate Date: " + NodeText(pmNode, "cac:PaymentMandate/cbc:PaymentMandateDate", ns));
                }
                MessageBox.Show(msg.ToString(), "Testing UBL DATA versie 0.01", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No PaymentMeans element found.");
            }

            // TaxTotal
            var msgTax = new StringBuilder();
            msgTax.AppendLine("TaxTotal");
            msgTax.AppendLine("--------");
            var taxAmountEl = xmlDoc.SelectSingleNode("//cac:TaxTotal/cbc:TaxAmount", ns);
            var currencyID = taxAmountEl?.Attributes?["currencyID"]?.Value ?? "";
            if (taxAmountEl != null && string.IsNullOrEmpty(currencyID))
            {
                MessageBox.Show("Attribute currencyID is missing on <cbc:TaxAmount>");
            }

            var taxTotals = xmlDoc.SelectNodes("//cac:TaxTotal", ns);
            if (taxTotals != null)
            {
                foreach (XmlNode taxTotalElem in taxTotals)
                {
                    var ttAmount = taxTotalElem.SelectSingleNode("cbc:TaxAmount", ns)?.InnerText ?? "";
                    msgTax.AppendLine($"TaxTotal: {ttAmount} {currencyID}");

                    var subtotals = taxTotalElem.SelectNodes("cac:TaxSubtotal", ns);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    foreach (XmlNode subElem in subtotals)
                    {
                        msgTax.AppendLine();
                        msgTax.AppendLine("SubDetail");
                        msgTax.AppendLine("TaxableAmount: " + NodeText(subElem, "cbc:TaxableAmount", ns));
                        msgTax.AppendLine("TaxAmount: " + NodeText(subElem, "cbc:TaxAmount", ns));
                        msgTax.AppendLine("Percent: " + NodeText(subElem, "cac:TaxCategory/cbc:Percent", ns) + "%");
                        msgTax.AppendLine();
                    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
                MessageBox.Show(msgTax.ToString(), "Testing UBL DATA versie 0.01", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // LegalMonetaryTotal
            var msgMoney = new StringBuilder();
            msgMoney.AppendLine("LegalMonetaryTotal");
            msgMoney.AppendLine("------------------");
            var moneyTotalEl = xmlDoc.SelectSingleNode("//cac:LegalMonetaryTotal", ns);
            if (moneyTotalEl != null)
            {
                msgMoney.AppendLine("LineExtensionAmount: " + NodeText(moneyTotalEl, "cbc:LineExtensionAmount", ns));
                msgMoney.AppendLine("TaxExclusiveAmount: " + NodeText(moneyTotalEl, "cbc:TaxExclusiveAmount", ns));
                msgMoney.AppendLine("TaxInclusiveAmount: " + NodeText(moneyTotalEl, "cbc:TaxInclusiveAmount", ns));
                msgMoney.AppendLine("PayableAmount: " + NodeText(moneyTotalEl, "cbc:PayableAmount", ns) + $" ({currencyID})");
                MessageBox.Show(msgMoney.ToString(), "Testing UBL DATA versie 0.01", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // InvoiceLines
            var msgLines = new StringBuilder();
            var invoiceLines = xmlDoc.SelectNodes("//cac:InvoiceLine", ns);
            if (invoiceLines != null)
            {
                foreach (XmlNode lineNode in invoiceLines)
                {
                    var desc = NodeText(lineNode, ".//cbc:Description", ns);
                    var qty = NodeText(lineNode, ".//cbc:InvoicedQuantity", ns);
                    var price = NodeText(lineNode, ".//cbc:PriceAmount", ns);
                    msgLines.AppendLine($"Item: {desc}, Quantity: {qty}, Price: {price}");
                }
                MessageBox.Show(msgLines.ToString(), "Testing UBL DATA versie 0.01", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Helper for safe node text extraction
        private static string NodeText(XmlNode parentNode, string xpath, XmlNamespaceManager ns)
        {
            var node = parentNode.SelectSingleNode(xpath, ns);
            return node?.InnerText.Trim() ?? "";
        }

        private void TextBoxLegalEntityId_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxLegalEntityId.Text.Length > 0)
            {
                // If a Legal Entity ID is choosen, set specific values for Belgium
                TextBoxCountryCode.Text = "";
                TextBoxRegScheme.Text = "";
                TextBoxRegIdentifier.Text = "";
                TextBoxSupportedDocument.Text = "";
                TextBoxLegalEntityId.Enabled = true;
                TextBoxRegIdentifier.Enabled = false;
                TextBoxCountryCode.Enabled = false;
                TextBoxRegScheme.Enabled = false;
                TextBoxSupportedDocument.Enabled = false;
            }
            else
            {
                // If no Legal Entity ID is provided, set default values for Belgium
                TextBoxCountryCode.Text = "BE"; // Default to Belgium if no Legal Entity ID is provided                                
                TextBoxRegScheme.Text = "0208"; // Default to 0208 scheme for Belgium  
                TextBoxRegIdentifier.Text = "0440058217"; // Default to a common identifier for Belgium
                TextBoxSupportedDocument.Text = "PEPPOL_BIS_BILLING_UBL_INVOICE_V3"; // Default to UBL Invoice for Belgium            
                TextBoxLegalEntityId.Text = ""; // Default Legal Entity ID for Belgium

                TextBoxRegIdentifier.Enabled = true; // Enable the registration identifier field
                TextBoxCountryCode.Enabled = true; // Enable the country code field 
                TextBoxRegScheme.Enabled = true; // Enable the registration scheme field
                TextBoxSupportedDocument.Enabled = true; // Enable the supported document field
            }
        }

        private void DoPopUpResult(string message)
        {
            FormResultPopUp.Controls.Clear(); // Clear previous controls in the popup form
            RichTextBox richTextBox = new()
            {
                Dock = DockStyle.Fill, // Fill the popup form with the RichTextBox
                BackColor = Color.White, // Set background color to white for better readability
                ForeColor = Color.Black, // Set text color to black for better contrast
                ReadOnly = true,
                Text = message, // Set the text from the main form's RichTextBox
                Font = new Font("Consolas", 10) // Set a monospaced font for better readability
            };
            FormResultPopUp.Controls.Add(richTextBox); // Add the RichTextBox to the popup form
            FormResultPopUp.ShowDialog(this); // Show the popup form as a dialog, centered on the main form
        }

        private void DoPopUpNotificationData(string messageAsJson)
        {
            FormDataGridJsonPopUp.Controls.Clear();
            FormDataGridJsonPopUp formJsonTable = new()
            {
                jsonData = messageAsJson, // Pass the JSON data to the popup form
                Dock = DockStyle.Fill // Fill the popup form with the JSON table view                
            };
            formJsonTable.LoadNotificationJsonData();            
            formJsonTable.ShowDialog(this); // Show the popup form as a dialog, centered on the main form
        }

        private void DoPopUpEntitiesData(string messageAsJson)
        {
            FormDataGridJsonPopUp.Controls.Clear();
            FormDataGridJsonPopUp formJsonTable = new()
            {
                jsonData = messageAsJson, // Pass the JSON data to the popup form
                Dock = DockStyle.Fill // Fill the popup form with the JSON table view                
            };
            formJsonTable.LoadRegistrationJsonData();
            formJsonTable.ShowDialog(this); // Show the popup form as a dialog, centered on the main form
        }
    }
}







//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;
//using Newtonsoft.Json;

//namespace JsonToTableWinForms
//{
//    public partial class MainForm : Form
//    {
//        private Root rootData;
//        private int currentPage;

//        public MainForm()
//        {
//            InitializeComponent();
//            SetupUI();
//            LoadJsonData();
//            ShowPage(0);
//        }

//        private void SetupUI()
//        {
//            // DataGridView
//            dataGridView1.Dock = DockStyle.Top;
//            dataGridView1.Height = 300;

//            // Buttons & Label
//            var panel = new FlowLayoutPanel
//            {
//                Dock = DockStyle.Bottom,
//                Height = 40,
//                FlowDirection = FlowDirection.LeftToRight
//            };

//            var btnPrev = new Button { Text = "Previous" };
//            var btnNext = new Button { Text = "Next" };
//            lblPageInfo = new Label { AutoSize = true, Padding = new Padding(10, 10, 0, 0) };

//            btnPrev.Click += (s, e) => ShowPage(currentPage - 1);
//            btnNext.Click += (s, e) => ShowPage(currentPage + 1);

//            panel.Controls.Add(btnPrev);
//            panel.Controls.Add(btnNext);
//            panel.Controls.Add(lblPageInfo);

//            Controls.Add(panel);
//            Controls.Add(dataGridView1);
//        }

//        private Label lblPageInfo;
//        private DataGridView dataGridView1 = new DataGridView();

//        private void LoadJsonData()
//        {
//            string json = System.IO.File.ReadAllText("data.json");
//            rootData = JsonConvert.DeserializeObject<Root>(json);
//        }

//        private void ShowPage(int pageIndex)
//        {
//            int pageSize = rootData.Pagination.PageSize;
//            int totalCount = rootData.Pagination.Count;

//            if (pageIndex < 0 || pageIndex > (totalCount - 1) / pageSize)
//                return;

//            currentPage = pageIndex;
//            rootData.Pagination.Page = pageIndex;

//            var pageData = rootData.Notifications
//                                   .GetRange(pageIndex * pageSize,
//                                             Math.Min(pageSize, totalCount - pageIndex * pageSize));

//            dataGridView1.DataSource = null;
//            dataGridView1.DataSource = pageData;

//            lblPageInfo.Text = $"Page {pageIndex + 1} of {Math.Ceiling((double)totalCount / pageSize)}";
//        }
//    }

//    public class Root
//    {
//        [JsonProperty("pagination")]
//        public Pagination Pagination { get; set; }

//        [JsonProperty("notifications")]
//        public List<Notification> Notifications { get; set; }
//    }

//    public class Pagination
//    {
//        public int Count { get; set; }
//        public int Page { get; set; }
//        public int PageSize { get; set; }
//    }

//    public class Notification
//    {
//        public string EventType { get; set; }
//        public int NotificationId { get; set; }
//        public string TransmissionId { get; set; }
//        public string SbdhTransmissionId { get; set; }
//        public DateTime NotificationDate { get; set; }
//        public string DocumentId { get; set; }
//        public string PeppolDocumentType { get; set; }
//        public string DocumentStatus { get; set; }
//        public string Sender { get; set; }
//        public string Receiver { get; set; }
//        public List<object> Details { get; set; }
//    }
//}
