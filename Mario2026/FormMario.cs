using IDEALSoftware.VpeCommunity;
using System.Diagnostics;

namespace Mario2026
{
    public partial class FormMario : Form
    {
        public VpeControl Vpe = new();
        public FormMario()
        {
            InitializeComponent();
            Text = "Mario2026";
        }
        private void FormMario_Load(object sender, EventArgs e)
        {
            // Upgrade settings from previous version if needed
            if (!Properties.Settings.Default.IsUpgraded)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.IsUpgraded = true;
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.MarioMainFormTop <= 0)
            {
                this.Width = 816;
                this.Height = 489;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.Top = Properties.Settings.Default.MarioMainFormTop;
                this.Left = Properties.Settings.Default.MarioMainFormLeft;
                this.Width = Properties.Settings.Default.MarioMainFormWidth;
                this.Height = Properties.Settings.Default.MarioMainFormHeight;
            }
        }
        private void FormMario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MarioMainFormTop = this.Top;
            Properties.Settings.Default.MarioMainFormLeft = this.Left;
            Properties.Settings.Default.MarioMainFormWidth = this.Width;
            Properties.Settings.Default.MarioMainFormHeight = this.Height;
            Properties.Settings.Default.Save();
        }
        private void CloseAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LookUpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form lookUpTools = new FormLookUpTools
            {
                Owner = this
            };
            lookUpTools.ShowDialog();
        }
        private void CheckUBLDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form checkUBLDocument = new FormUblDocCheckUp
            {
                Owner = this
            };
            checkUBLDocument.ShowDialog();
        }
        private void AutoPageBreakTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // =====================================================================
            //                             Auto Page Break
            // =====================================================================
            using OpenFileDialog SPPathFileDialog = new();
            SPPathFileDialog.InitialDirectory = @"c:\";
            SPPathFileDialog.Filter = "c# txt files (*.cs)|*.cs|All files (*.txt)|*.txt";
            SPPathFileDialog.Multiselect = true;
            SPPathFileDialog.FilterIndex = 1;
            SPPathFileDialog.RestoreDirectory = true;

            if (SPPathFileDialog.ShowDialog() == DialogResult.OK)
            {
                // string fileContent = string.Empty;
                string firstFullPath; // = string.Empty;

                //Get the path of specified file
                firstFullPath = SPPathFileDialog.FileName;
                // var arrayFileNames = SPPathFileDialog.FileNames;

                string sLine, block = "";
                StreamReader stream;

                FileInfo fi = new(firstFullPath);
                if (!fi.Exists)
                {
                    MessageBox.Show("File \"" + firstFullPath + "\" not found.");
                    return;
                }

                stream = new StreamReader(firstFullPath);
                while (stream.Peek() > -1)    // not EOF
                {
                    sLine = stream.ReadLine()!;

                    // Replace all TAB characters with blanks, since the plain text object created with
                    // VPE.Print[Box]() or VPE.Write[Box]() does not handle TAB's
                    // NOTE: The RTF (Rich Text Format) object of the VPE Professional Edition DOES handle
                    //       tabs and also hanging indents, but this demo is intended for the
                    //       VPE Standard Edition.
                    sLine = sLine.Replace("\t", "   ");
                    block = block + "\n" + sLine;
                }
                stream.Close();

                MessageBox.Show("We loaded the file\n \"" + firstFullPath + "\"\n\n" +
                    "into memory using the slow \"ReadLine\" method.\n" +
                    "We also replaced all tab-characters with blanks.\n" +
                    "NOW we call VPE and create a document from the data.\n" +
                    "VPE will create the page breaks itself. This will work very fast!");

                Vpe = new VpeControl
                {
                    PageFormat = PageFormat.A4,
                    PageOrientation = PageOrientation.Portrait
                };

                Vpe.OpenDoc();
                Vpe.SelectFont("Courier New", 8);

                // Set the bottom margin, so the report will fit
                // onto A4 as well as onto US-Letter paper:
                // =============================================
                Vpe.SetOutRect(2, 2, 19, 26.5);

                // Header will be placed outside default output rectangle:
                Vpe.NoPen();
                Vpe.TextUnderline = true;
                Vpe.DefineHeader(1, 1, -7, -0.5, "Auto Text Break Demo - Page @PAGE");

                // On every intial page:
                // VLEFT   = VLEFTMARGIN
                // VTOP    = VTOPMARGIN
                // VRIGHT  = VRIGHTMARGIN
                // VBOTTOM = VTOPMARGIN !!!!!!!!!!
                Vpe.TextUnderline = false;
                Vpe.SetPen(0.03, PenStyle.Solid, Color.Black);
                Vpe.WriteBox(Vpe.nLeft, Vpe.nBottom, Vpe.nRight, Vpe.nFree, "[N TO BC LtGray CE S 12 B]Start of Listing");
                Vpe.WriteBox(Vpe.nLeft, Vpe.nBottom, Vpe.nRight, Vpe.nFree, block);
                Vpe.WriteBox(Vpe.nLeft, Vpe.nBottom, Vpe.nRight, Vpe.nFree, "[N TO BC LtGray CE S 12 B]End of Listing");

                Vpe.Preview();

                // ExportDocument("Auto Break.pdf", vpe);                
            }
        }

        private void VsoftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.vsoft.be") { UseShellExecute = true });
        }
        private void HostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://web24.foxxl.com:8443") { UseShellExecute = true });
        }
        private void WebmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://webmail.rv.be") { UseShellExecute = true });
        }
        private void CommandPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string myDocumentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Process myDocProcess = new();
            myDocProcess.StartInfo.FileName = "cmd.exe";
            myDocProcess.StartInfo.WorkingDirectory = myDocumentsFolderPath;
            myDocProcess.StartInfo.UseShellExecute = true;
            myDocProcess.StartInfo.CreateNoWindow = true;
            myDocProcess.Start();

            // Process myApp = new();
            // myApp.StartInfo.FileName = "cmd.exe";
            // myApp.StartInfo.WorkingDirectory = Application.LocalUserAppDataPath; // Use LocalUserAppDataPath for application data
            // myApp.StartInfo.UseShellExecute = true;
            // myApp.StartInfo.CreateNoWindow = true;
            // myApp.Start();
        }
        private void UBLValidatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.ubl.be/validator") { UseShellExecute = true });
        }
        private void UBLDocsBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://docs.peppol.eu/poacc/billing/3.0/") { UseShellExecute = true });
        }

        private void TestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ademicoTesting = new FormAdemicoTesting
            {
                Owner = this
            };
            ademicoTesting.ShowDialog();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form settingsForm = new FormAdemicoSettings 
            {
                Owner = this
            };
            settingsForm.ShowDialog();
        }
    }
}
