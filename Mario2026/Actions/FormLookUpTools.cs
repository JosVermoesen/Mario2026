using System.Xml;
using System.Xml.Linq;

namespace Mario2026
{
    public partial class FormLookUpTools : Form
    {
        private readonly HttpClient httpCheck;
        public FormLookUpTools()
        {
            InitializeComponent();
            httpCheck = new HttpClient(); // Initialize HttpClient instance                        
        }
        async private void ButtonVatLookUp_Click(object sender, EventArgs e)
        {
            string vatNumber = TextBoxVatNumber.Text;
            string countryCode = vatNumber[..2];
            string vat = vatNumber[2..];

            LabelVatResponseContent.Text = "Bezig...";

            string url = "https://ec.europa.eu/taxation_customs/vies/rest-api/ms/" + countryCode + "/vat/" + vat;

            HttpResponseMessage response = await httpCheck.GetAsync(url); // Use the HttpClient instance
            string responseContent = await response.Content.ReadAsStringAsync();

            LabelVatResponseContent.Text = responseContent;
        }
        async private void ButtonLookUpPeppolID_Click(object sender, EventArgs e)
        {
            try
            {
                string peppolId = TextBoxPeppolID.Text;
                LabelPeppolResponseContent.Text = "Bezig...";
                string url = "https://directory.peppol.eu/search/1.0/xml?q=" + peppolId;

                HttpResponseMessage response = await httpCheck.GetAsync(url); // Use the HttpClient instance
                string responseContent = await response.Content.ReadAsStringAsync();


                // Attempt to parse the response content as XML
                var doc = XDocument.Parse(responseContent);

                // Convert the XDocument to a string representation
                LabelPeppolResponseContent.Text = doc.ToString();
            }
            catch (XmlException)
            {
                // If parsing fails, show an error message
                LabelPeppolResponseContent.Text = "Ongeldige XML-structuur ontvangen.";
                return;
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that may occur
                LabelPeppolResponseContent.Text = "Fout bij het verwerken van de response: " + ex.Message;
                return;
            }

            // Check in batch of till 25 VAT numbers at once
            // https://app.peppolchecker.eu/



        }
    }
}
