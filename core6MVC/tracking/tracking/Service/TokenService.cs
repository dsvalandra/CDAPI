using System.Text.Json;
using System.Text;
using tracking.Model;
using tracking.Controllers;
using Microsoft.Extensions.Logging;

namespace tracking.Service
{
    public class TokenService
    {
        private readonly HttpClient _httpClient;
        private string _tokenEndpoint;
        private readonly ILogger<TokenService> _logger;

        public TokenService(string tokenEndpoint)
        {
            _httpClient = new HttpClient();
            _tokenEndpoint = tokenEndpoint;
        }

        public TokenService(ILogger<TokenService> logger)
        {
            _logger = logger;
        }

        public async Task<string> GetBearerTokenAsync(string jsonPayload)
        {

                // Create a request to obtain a new token
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Send the request to the token endpoint
                var response = await _httpClient.PostAsync(_tokenEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    // Read and parse the response JSON
                    string responseJson = await response.Content.ReadAsStringAsync();
                    var authorizationResponse = JsonSerializer.Deserialize<AuthorizationResponse>(responseJson);

                    if (authorizationResponse.Token != null)
                    {
                        // Return the new bearer token
                       // _logger.LogInformation("API call was a successful! Bearer Token: " + authorizationResponse + DateTime.Now);
                        return authorizationResponse.Token;
                    
                    }
                    else
                    {
                        // Handle the error (e.g., log or throw an exception)
                        _logger.LogInformation("API call failed logged response" + authorizationResponse + DateTime.Now);
                        throw new Exception($"Failed to obtain a new token. Status code: " + authorizationResponse + DateTime.Now);
                    }
                }
                else
                {
                    // Handle the error (e.g., log or throw an exception)
                    _logger.LogInformation("API call failed logged response:" + response + DateTime.Now);
                    throw new Exception($"Failed to obtain a new token. Status code:" + response + DateTime.Now);
                }
            }
        }
    }

