using System.Data.OleDb;
using System.Data;

namespace Mario2026.Actions
{
    public partial class FormUserSettings : Form
    {
        public FormUserSettings()
        {
            InitializeComponent();
            LabelMimDataLocation.Text = SharedGlobals.MimDataLocation;
            if (LabelMimDataLocation.Text.Length > 0)
            {
                FillCompanyList();
            }
        }

        private void FillCompanyList()
        {
            ListBoxCompanies.Items.Clear();

            string MyPath = LabelMimDataLocation.Text;
            ResultExploringMimFileSystem(MyPath);
        }
        private bool ResultExploringMimFileSystem(string path)
        {
            if (path == "" || path == null)
            {
                return false;
            }

            if (Directory.Exists(path))
            {
                ProcessMimDirectory(path);
                return true;
            }
            else
            {
                MessageBox.Show(path + " is not a valid directory");
                return false;
            }
        }
        private void ProcessMimDirectory(string targetDirectory)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                int subDirLength = subdirectory.Length;
                string subDirMap = subdirectory.ToString()[(subDirLength - 3)..];
                ProcessMarntTxtFile(subdirectory, subDirMap);
            }
        }
        private void ProcessMarntTxtFile(string companyPath, string mapName)
        {
            string marntTxtPath = companyPath + @"\marnt.txt";
            if (File.Exists(marntTxtPath))
            {
                AddToMimList(marntTxtPath, mapName);
            }
            else
            {
                MessageBox.Show(marntTxtPath + " is not a valid file");
            }
        }
        private void AddToMimList(string marntTxtPath, string mapName)
        {
            // TODO add content to list view
            try
            {
                var stream = new StreamReader(marntTxtPath);
                if (stream.Peek() > -1)    // not EOF
                {
                    string line = stream.ReadLine()!;
                    ListBoxCompanies.Items.Add(mapName + " - " + line);
                }
                stream.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(marntTxtPath + " could not be read");
                MessageBox.Show(e.Message);
            }
        }

        private void ListBoxCompanies_Click(object sender, EventArgs e)
        {
            if (ListBoxCompanies.SelectedItem != null)
            {
                string selectedItem = ListBoxCompanies.SelectedItem.ToString()!;
                int separatorPos = selectedItem.IndexOf(" - ");
                if (separatorPos > 0)
                {
                    string selectedKbo = selectedItem[..separatorPos];
                    SharedGlobals.ClientKbo = selectedKbo;

                    // Use the provided method to set the value instead of direct assignment
                    SharedGlobals.SetMarntMdvLocation("\\" + selectedKbo + "\\marnt.mdv");
                    MessageBox.Show (SharedGlobals.MarntMdvLocation);
                    string jrFile = GetCounterTable(SharedGlobals.MarntMdvLocation, "jr");
                    MessageBox.Show(jrFile);
                }
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static string GetCounterTable(string location, string filter)
        {
            // Change provider depending on Access version:
            // For .mdb (Jet)
            string connStr = SharedGlobals.DbJetProvider + SharedGlobals.MimDataLocation + location;

            using OleDbConnection conn = new(connStr);
            conn.Open();

            // Retrieve schema for tables only
            DataTable tables = conn.GetSchema("Tables");

            foreach (DataRow row in tables.Rows)
            {
                // Use null-coalescing operator to handle potential null values
                string tableName = row["TABLE_NAME"]?.ToString() ?? string.Empty;
                string tableType = row["TABLE_TYPE"]?.ToString() ?? string.Empty;

                // Filter out system/internal tables if needed
                if (tableType == "TABLE")
                {
                    if (tableName.StartsWith(filter, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(tableName);
                        return tableName; // Return the first matching table name
                    }
                }
            }
            return string.Empty; // Return empty string if no matching table is found
        }
    }
}
