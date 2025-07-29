using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mario2026
{
    public partial class FormUblDocCheckUp : Form
    {
        public FormUblDocCheckUp()
        {
            InitializeComponent();

            // Ensure events are hooked up if you didn't use the Designer
            this.DragEnter += FormUblDocCheckUp_DragEnter;
            this.DragDrop += FormUblDocCheckUp_DragDrop;
        }

        private void FormUblDocCheckUp_DragEnter(object? sender, DragEventArgs e)
        {
            // Only allow file drops
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void FormUblDocCheckUp_DragDrop(object? sender, DragEventArgs e)
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
        private bool HandleUblDocument(string filePath)
        {
            FileInfo fi = new(filePath);
            if (!fi.Exists)
            {
                MessageBox.Show("File \"" + filePath + "\" not found.");
                return false;
            }

            XmlDocument xmlDoc = new();
            xmlDoc.Load(filePath);

            XmlNamespaceManager ns = new(xmlDoc.NameTable);
            ns.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            ns.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");

            string? invoiceId = xmlDoc.SelectSingleNode("//cbc:ID", ns)?.InnerText;
            LabelInvoiceId.Text = invoiceId ?? "No Invoice ID found";

            string? issueDate = xmlDoc.SelectSingleNode("//cbc:IssueDate", ns)?.InnerText;
            LabelIssueDate.Text = issueDate ?? "No Issue Date found";

            XmlNodeList? invoiceLines = xmlDoc.SelectNodes("//cac:InvoiceLine", ns);
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
            return true;
        }

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
                    foreach (XmlNode subElem in subtotals)
                    {
                        msgTax.AppendLine();
                        msgTax.AppendLine("SubDetail");
                        msgTax.AppendLine("TaxableAmount: " + NodeText(subElem, "cbc:TaxableAmount", ns));
                        msgTax.AppendLine("TaxAmount: " + NodeText(subElem, "cbc:TaxAmount", ns));
                        msgTax.AppendLine("Percent: " + NodeText(subElem, "cac:TaxCategory/cbc:Percent", ns) + "%");
                        msgTax.AppendLine();
                    }
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

        private void ButtonCheckUBL_Click(object sender, EventArgs e)
        {
            string filePath = LabelFile.Text.Trim();
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            if (extension != ".xml" && extension != ".ubl")
            {
                // Show a message box if the file is not a valid UBL XML file
                // MessageBox.Show("This is not a valid UBL XML file");
                MessageBox.Show("Dit is geen geldig UBL XML bestand");
            }
            else
            {
                // HandleUblDocument(filePath);
                ReadUBLInvoice(filePath);
            }
        }

        private void LabelFile_TextChanged(object sender, EventArgs e)
        {
            ButtonCheckUBL.Enabled = !string.IsNullOrWhiteSpace(LabelFile.Text) && File.Exists(LabelFile.Text);
        }
    }
}
