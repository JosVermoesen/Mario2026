namespace Mario2026
{
    public partial class FormAdemicoSettings : Form
    {
        public FormAdemicoSettings()
        {
            InitializeComponent();
        }

        private void FormAdemicoSettings_Load(object sender, EventArgs e)
        {
            // Load settings or initialize components here if needed
            TextBoxUrl.Text = Properties.Settings.Default.AdemicoUrl;
            TextBoxAccessToken.Text = Properties.Settings.Default.AdemicoAccessToken;
            TextBoxUsername.Text = Properties.Settings.Default.AdemicoUsername;
            TextBoxPassword.Text = Properties.Settings.Default.AdemicoPassword;
        }

        private void ButtonSaveSettings_Click(object sender, EventArgs e)
        {
            // Save settings when the button is clicked
            Properties.Settings.Default.AdemicoUrl = TextBoxUrl.Text;
            Properties.Settings.Default.AdemicoAccessToken = TextBoxAccessToken.Text;
            Properties.Settings.Default.AdemicoUsername = TextBoxUsername.Text;
            Properties.Settings.Default.AdemicoPassword = TextBoxPassword.Text;

            Properties.Settings.Default.Save(); // Save the settings to the config file
            MessageBox.Show("Settings saved with data provided!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close(); // Close the settings form after saving
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close(); // Close the settings form without saving
        }
    }
}