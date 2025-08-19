using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mario2026
{
    public static class AdemicoClient
    {
        public static class PeppolInvoiceSender
        {
            public sealed record ApiResult(HttpStatusCode StatusCode, string? ResponseBody);
            /// <summary>
            /// Sends a UBL invoice/credit note file to the Buyer via the Peppol API.
            /// Matches the Postman definition: multipart/form-data with Basic authentication.
            /// </summary>
            public static async Task<ApiResult> SendUblInvoiceAsync(
                string filePath,
                bool xC5Reporting = false,
                CancellationToken cancellationToken = default)
            {
                string ademicoUrl = Properties.Settings.Default.AdemicoUrl;
                string accessToken = Properties.Settings.Default.AdemicoAccessToken;
                string username = Properties.Settings.Default.AdemicoUsername;
                string password = Properties.Settings.Default.AdemicoPassword;
                                
                // Prepare target URL with query parameter
                string requestUri = $"{ademicoUrl.TrimEnd('/')}/api/peppol/v1/invoices/ubl-submissions" +
                                    $"?accessToken={Uri.EscapeDataString(accessToken)}";

                using var http = new HttpClient();

                // Basic Auth header
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                // Accept JSON
                http.DefaultRequestHeaders.Accept.Clear();
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // X-C5-REPORTING header
                http.DefaultRequestHeaders.Add("X-C5-REPORTING", xC5Reporting.ToString().ToLowerInvariant());

                // Prepare multipart content with the UBL XML file
                using var form = new MultipartFormDataContent();
                using var fileStream = File.OpenRead(filePath);
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
                form.Add(fileContent, "file", Path.GetFileName(filePath));

                using var response = await http.PostAsync(requestUri, form, cancellationToken).ConfigureAwait(false);
                string? body = response.Content is null
                    ? null
                    : await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

                return new ApiResult(response.StatusCode, body);
            }
        }

        public static async Task<string> GetNotificationsAsync(
            string transmissionId, string documentId, string eventType, string peppolDocumentType, string sender,
            string receiver, string startDateTime, string endDateTime, string page, string pageSize,
            CancellationToken cancellationToken = default)
        {
            string ademicoUrl = Properties.Settings.Default.AdemicoUrl;
            string accessToken = Properties.Settings.Default.AdemicoAccessToken;
            string username = Properties.Settings.Default.AdemicoUsername;
            string password = Properties.Settings.Default.AdemicoPassword;
                        
            // Helper to URL-encode query parameters safely
            static string Encode(string val) => Uri.EscapeDataString(val ?? string.Empty);

            // Build query parameters dynamically (skip null/empty)
            var queryParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(transmissionId)) queryParams.Add($"transmissionId={Encode(transmissionId)}");
            if (!string.IsNullOrWhiteSpace(documentId)) queryParams.Add($"documentId={Encode(documentId)}");
            if (!string.IsNullOrWhiteSpace(eventType)) queryParams.Add($"eventType={Encode(eventType)}");
            if (!string.IsNullOrWhiteSpace(peppolDocumentType)) queryParams.Add($"peppolDocumentType={Encode(peppolDocumentType)}");
            if (!string.IsNullOrWhiteSpace(sender)) queryParams.Add($"sender={Encode(sender)}");
            if (!string.IsNullOrWhiteSpace(receiver)) queryParams.Add($"receiver={Encode(receiver)}");
            if (!string.IsNullOrWhiteSpace(startDateTime)) queryParams.Add($"startDateTime={Encode(startDateTime)}");
            if (!string.IsNullOrWhiteSpace(endDateTime)) queryParams.Add($"endDateTime={Encode(endDateTime)}");
            if (!string.IsNullOrWhiteSpace(page)) queryParams.Add($"page={Encode(page)}");
            if (!string.IsNullOrWhiteSpace(pageSize)) queryParams.Add($"pageSize={Encode(pageSize)}");
            if (!string.IsNullOrWhiteSpace(accessToken)) queryParams.Add($"accessToken={Encode(accessToken)}");

            var fullUrl = $"{ademicoUrl.TrimEnd('/')}/api/peppol/v1/notifications";
            if (queryParams.Count > 0)
                fullUrl += "?" + string.Join("&", queryParams);

            // Build HttpClient & request
            using var httpClient = new HttpClient();

            var authValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            using var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authValue);

            // Send and read response
            using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }

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
        /// <param name="legalEntityId">Unique legal entity ID (optional)</param>
        /// <param name="accessToken">Access token (query parameter)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>HTTP status code and raw response body</returns>
        /// 
        
        public static async Task<LegalEntityResult> GetPeppolRegistrationAsync(
                string? country, string? peppolRegistrationScheme, string? peppolRegistrationIdentifier,
                string? peppolSupportedDocument, string? legalEntityId,
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
                ["legalEntityId"] = legalEntityId ?? throw new ArgumentNullException(nameof(legalEntityId)),
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
        /// 
        
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

            JsonSerializerOptions jsonSerializerOptions = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = false
            };
            var jsonOptions = jsonSerializerOptions;

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

