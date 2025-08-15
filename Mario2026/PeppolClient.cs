using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mario2026
{
    public static class PeppolClient
    {
        public sealed record LegalEntityResult(HttpStatusCode StatusCode, string? ResponseBody);
        /// <summary>
        /// Calls GET {{ademicoUrl}}/api/peppol/v1/legal-entities with Basic authentication and query params.
        /// </summary>
        /// <param name="ademicoUrl">Base URL, e.g. https://your-ademico-host</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        /// <param name="country">Legal entity country (e.g., "BE")</param>
        /// <param name="peppolRegistrationScheme">Peppol identifier scheme (e.g., "0208")</param>
        /// <param name="peppolRegistrationIdentifier">Peppol identifier (e.g., "0440058217")</param>
        /// <param name="peppolSupportedDocument">Supported document (e.g., "PEPPOL_BIS_BILLING_UBL_INVOICE_V3")</param>
        /// <param name="accessToken">Access token (query parameter)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>HTTP status code and raw response body</returns>
        public static async Task<LegalEntityResult> GetPeppolRegistrationAsync(
                string? country,
                string? peppolRegistrationScheme,
                string? peppolRegistrationIdentifier,
                string? peppolSupportedDocument,
            CancellationToken cancellationToken = default)
        {
            string ademicoUrl = Properties.Settings.Default.AdemicoUrl;
            string accessToken = Properties.Settings.Default.AdemicoAccessToken;
            string username = Properties.Settings.Default.AdemicoUsername;
            string password = Properties.Settings.Default.AdemicoPassword;

            var baseUrl = ademicoUrl.EndsWith('/') ? ademicoUrl : ademicoUrl + "/";

            // Build encoded query string
            var query = new Dictionary<string, string>
            {
                ["country"] = country ?? throw new ArgumentNullException(nameof(country)),
                ["peppolRegistrationScheme"] = peppolRegistrationScheme ?? throw new ArgumentNullException(nameof(peppolRegistrationScheme)),
                ["peppolRegistrationIdentifier"] = peppolRegistrationIdentifier ?? throw new ArgumentNullException(nameof(peppolRegistrationIdentifier)),
                ["peppolSupportedDocument"] = peppolSupportedDocument ?? throw new ArgumentNullException(nameof(peppolSupportedDocument)),
                ["accessToken"] = accessToken
            };
            string queryString = await new FormUrlEncodedContent(query).ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            var client = new HttpClient { BaseAddress = new Uri(baseUrl, UriKind.Absolute) };

            // Basic auth
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            // Accept JSON
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestUri = $"api/peppol/v1/legal-entities?{queryString}";
            using var response = await client.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            string? body = response.Content is null
                ? null
                : await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            return new LegalEntityResult(response.StatusCode, body);
        }

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

        public sealed record ApiResult(HttpStatusCode StatusCode, string? ResponseBody);
        /// <summary>
        /// POST {{ademicoUrl}}/api/peppol/v1/legal-entities?accessToken={{ademicoAccessToken}}
        /// Creates/registers a legal entity in the Peppol network using Basic authentication.
        /// </summary>
        public static async Task<ApiResult> CreateOrRegisterLegalEntityAsync(
            CreateLegalEntityRequest request,
            CancellationToken cancellationToken = default)
        {
            // if (request is null) throw new ArgumentNullException(nameof(request));

            string ademicoUrl = Properties.Settings.Default.AdemicoUrl;
            string accessToken = Properties.Settings.Default.AdemicoAccessToken;
            string username = Properties.Settings.Default.AdemicoUsername;
            string password = Properties.Settings.Default.AdemicoPassword;

            var baseUrl = ademicoUrl.TrimEnd('/');
            var requestUri = $"{baseUrl}/api/peppol/v1/legal-entities?accessToken={Uri.EscapeDataString(accessToken)}";

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = false
            };

            using var http = new HttpClient();

            // Basic auth
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            // Accept JSON
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonSerializer.Serialize(request, jsonOptions);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await http.PostAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            var body = response.Content is null
                ? null
                : await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            return new ApiResult(response.StatusCode, body);
        }

    }
}

