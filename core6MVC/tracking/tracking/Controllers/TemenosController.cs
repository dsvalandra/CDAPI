using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http.Headers;
using System.Globalization;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using tracking.Service;
using Microsoft.Extensions.Logging;
using tracking.Model;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace tracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemenosController : ControllerBase
    {
   
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<TemenosController> _logger;

        public TemenosController(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<TemenosController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;
        }

        //public TemenosController(ILogger<TemenosController> logger) => _logger = logger;
        [HttpPost("userdata")]
        public async Task<IActionResult> ReceiveUserDataAsync([FromBody] YourDTO data)
        {
            try
            {
            
            var apiBaseUrl = _configuration["AppSettings:ApiBaseUrl"];
            var apiKey = _configuration["AppSettings:ApiKey"];
            var Identifier = _configuration["AppSettings:ApplicationIdentifier"];
            var tememosApi = _configuration["AppSettings:TemenosApi"];
            _logger.LogInformation("API started at:" + DateTime.Now);
            var tokenService = new TokenService(apiBaseUrl);

            string newBearerToken = await tokenService.GetBearerTokenAsync(apiKey);
            
            using var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = tememosApi;
            httpClient.BaseAddress = new Uri(apiUrl);
             
            // Set the headers
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "" + newBearerToken);

                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string postResponse = await response.Content.ReadAsStringAsync();
                    return Ok(postResponse);
                }
                else
                {
                    // return StatusCode((int)response.StatusCode, "API call failed.");
                    _logger.LogInformation("API call failed and did not throw exception:" + response + DateTime.Now);
                    return StatusCode((int)response.StatusCode, $"Failed to make the request. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }
    


        [HttpGet("{GetApplications}")]
        public async Task<IActionResult> GetApplications()
        {   
            try
            {
                // Geting app settings temenos constants apiBaseUrl, apiKey and app identifier   
                var apiBaseUrl = _configuration["AppSettings:ApiBaseUrl"];
                var apiKey = _configuration["AppSettings:ApiKey"];
                var Identifier = _configuration["AppSettings:ApplicationIdentifier"];
                var tememosApi = _configuration["AppSettings:TemenosApi"];

                _logger.LogInformation("API started at:" + DateTime.Now);

                // Set token base url into constuctor
                var tokenService = new TokenService(apiBaseUrl);
                
                // Set Api Key and Api Secret Key 
                string newBearerToken = await tokenService.GetBearerTokenAsync(apiKey);
                
                // Creating http client
                using var httpClient = _httpClientFactory.CreateClient();

                // Set the request URL
                string apiUrl = tememosApi + Identifier;
                httpClient.BaseAddress = new Uri(apiUrl);

                // Set the headers
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "" + newBearerToken);
                Console.WriteLine(httpClient.BaseAddress.ToString() +" "+ httpClient.DefaultRequestHeaders.Accept.ToString() +" "+ httpClient.DefaultRequestHeaders.Authorization.ToString());
                // Send the GET request
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                else
                {
                    // return StatusCode((int)response.StatusCode, "API call failed.");
                    _logger.LogInformation("API call failed and did not throw exception:" + response + DateTime.Now);
                    return StatusCode((int)response.StatusCode, $"Failed to make the request. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

    }

    //[HttpGet("{BearerToken}")]
    //public async Task<IActionResult> BearerToken()
    //{
    //    try
    //    {
    //        using var httpClient = _httpClientFactory.CreateClient();

    //        // Set the request headers
    //        httpClient.DefaultRequestHeaders.Add("accept", "application/json");

    //        // Create the request payload as a JSON string
    //        var jsonPayload = "{\"ApiKey\":\"0jzKas+nfRiTVgJdeox9QEP1az+Gcji/j2nJ9s3nctQH3zpMHUnDN4ahqmwdFM60KuZ+d7qef3x/1h94ZN3KpWOXqv0D8CRW+/278GhwoXyFT3ixo4bAqsIvrTLcXjpJZM4SDO16ATgvvKsVhewIwgEZ3hwkaZ4hT21imQr8Nw8=\",\"SecretKey\":\"AsimPle1!\"}";

    //        // Create a StringContent from the JSON payload
    //        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

    //        // Make the POST request
    //        HttpResponseMessage response = await httpClient.PostAsync("https://opentest.metrofcu.org/publicapi/api/v1/login", content);


    //        if (response.IsSuccessStatusCode)
    //        {

    //            string responseBody = await response.Content.ReadAsStringAsync();
    //            Globals gl = new();
    //            gl.Token = responseBody;
    //            Vars bs = new();
    //            bs.MyMethod(gl);

    //            return Ok(responseBody);

    //        }
    //        else
    //        {
    //            return StatusCode((int)response.StatusCode, $"Failed to make the request. Status code: {response.StatusCode}");
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, $"An error occurred: {ex.Message}");
    //    }
    //}


}

