namespace Mario2026
{
    public static class SharedGlobals
    {
        static SharedGlobals()
        {
            AdemicoUrl = "https://test-peppol-api1.ademico-software.com/domibus";
            AdemicoAccessToken = "1aade332a55811eca4ff9af89e040201";
            AdemicoUsername = "rv";
            AdemicoPassword = "ay-nFJVqhsGX3rnnVqVkTDxT";

            DbJetProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=";
            MimDataLocation = "";
            MarntMdvLocation= "";
            IsAdmin = false; // default to false
            ClientKbo = ""; // default values
        } // default values        

        public static bool IsAdmin { get; set; } = true; // default to true
        public static string ClientKbo { get; set; }
        public static string AdemicoUrl { get; }
        public static string AdemicoAccessToken { get; }
        public static string AdemicoUsername { get; }
        public static string AdemicoPassword { get; }                
        public static string DbJetProvider { get; }
        public static string MimDataLocation { get; private set; }
        public static void SetMimDataLocation(string newString)
        {
            MimDataLocation = newString;
        }
        public static string MarntMdvLocation { get; private set; }
        public static void SetMarntMdvLocation(string newString)
        {
            MarntMdvLocation = newString;
        }       
    }    
}
