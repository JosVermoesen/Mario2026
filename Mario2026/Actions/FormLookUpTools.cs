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
            string peppolId = TextBoxPeppolID.Text;
            LabelPeppolResponseContent.Text = "Bezig...";
            string url = "https://directory.peppol.eu/search/1.0/xml?q=" + peppolId;

            HttpResponseMessage response = await httpCheck.GetAsync(url); // Use the HttpClient instance
            string responseContent = await response.Content.ReadAsStringAsync();

            var doc = XDocument.Parse(responseContent);

            // Convert the XDocument to a string representation
            LabelPeppolResponseContent.Text = doc.ToString();
        }

        private void ButtonReadinvoice_Click(object sender, EventArgs e)
        {
            using OpenFileDialog SPPathFileDialog = new();
            SPPathFileDialog.InitialDirectory = @"c:\";
            SPPathFileDialog.Filter = "xml files (*.xml)|*.xml";
            SPPathFileDialog.Multiselect = false;
            SPPathFileDialog.FilterIndex = 1;
            SPPathFileDialog.RestoreDirectory = true;

            if (SPPathFileDialog.ShowDialog() == DialogResult.OK)
            {
                // string fileContent = string.Empty;
                string firstFullPath; // = string.Empty;

                //Get the path of specified file
                firstFullPath = SPPathFileDialog.FileName;
                // var arrayFileNames = SPPathFileDialog.FileNames;


                FileInfo fi = new(firstFullPath);
                if (!fi.Exists)
                {
                    MessageBox.Show("File \"" + firstFullPath + "\" not found.");
                    return;
                }

                XmlDocument doc = new();
                doc.Load(firstFullPath);

                XmlNamespaceManager ns = new(doc.NameTable);
                ns.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                ns.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");

                string? invoiceId = doc.SelectSingleNode("//cbc:ID", ns)?.InnerText;
                string? issueDate = doc.SelectSingleNode("//cbc:IssueDate", ns)?.InnerText;

                XmlNodeList? invoiceLines = doc.SelectNodes("//cac:InvoiceLine", ns);
                if (invoiceLines != null)
                {
                    foreach (XmlNode line in invoiceLines)
                    {
                        string? description = line.SelectSingleNode(".//cbc:Description", ns)?.InnerText;
                        string? quantity = line.SelectSingleNode(".//cbc:InvoicedQuantity", ns)?.InnerText;
                        string? price = line.SelectSingleNode(".//cbc:PriceAmount", ns)?.InnerText;

                        Console.WriteLine($"Item: {description}, Quantity: {quantity}, Price: {price}");
                    }
                }
            }
        }        
    }
}
