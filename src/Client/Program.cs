using IdentityModel.Client;
using System;
using System.Net.Http;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var identityClient = new HttpClient();
            var discoveryDocument = identityClient.GetDiscoveryDocumentAsync("https://localhost:5001").Result;
            if (discoveryDocument.IsError)
            {
                Console.WriteLine(discoveryDocument.Error);
                return;
            }

            var tokenResponse = identityClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "client_id",
                ClientSecret = "client_secret",
                Scope = "ApiOne"
            }).Result;

            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = apiClient.GetAsync("https://localhost:5003/api/secret").Result;

            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);

            Console.ReadLine();
        }
    }
}
