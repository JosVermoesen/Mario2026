using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Mario2026
{
    public static class PeppolClient
    {        
        public static async Task<string> CheckConnection(HttpClient client)
        {
            string ademicoUrl = Properties.Settings.Default.AdemicoUrl;
            string accessToken = Properties.Settings.Default.AdemicoAccessToken;
            string username = Properties.Settings.Default.AdemicoUsername;
            string password = Properties.Settings.Default.AdemicoPassword;

            // Compose the full endpoint with query parameter
            string requestUri = $"{ademicoUrl.TrimEnd('/')}/api/peppol/v1/tools/connectivity" +
                                $"?accessToken={Uri.EscapeDataString(accessToken)}";

            // Prepare Basic Auth header
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            // Request JSON
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUri);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return "Access granted ✅";
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return "Unauthorized ❌ — check your username/password/accesstoken.";
                }
                else
                {
                    return $"Unexpected status: {(int)response.StatusCode} {response.ReasonPhrase}";
                }

                // content = await response.Content.ReadAsStringAsync();
                // Console.WriteLine("Response body:");
                // Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}

