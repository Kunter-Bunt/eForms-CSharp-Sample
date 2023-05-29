using eForms_CSharp_Sample_App.clients.PublicationApi;
using eForms_CSharp_Sample_App.clients.ValidationApi;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace eForms_CSharp_Sample_App.clients
{
    public class ClientFactory
    {
        public ClientFactory(IConfiguration config, string apiKey)
        {
            ValidationHttpClient = new HttpClient();
            PublicationHttpClient = new HttpClient();
            Config = config;
            ApiKey = apiKey;
            ValidationApiUrl = Config.GetSection("Settings")["ValidationApiUrl"];
            PublicationApiUrl = Config.GetSection("Settings")["PublicationApiUrl"];
        }

        public IValidationClient GetValidationClient()
        {
            var client = new ValidationClient(ValidationHttpClient);
            client.BaseUrl = ValidationApiUrl;
            return client;
        }

        public IPublicationClient GetPublicationClient()
        {
            PublicationHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

            var client = new PublicationClient(PublicationHttpClient);
            client.BaseUrl = PublicationApiUrl;
            return client;
        }

        public HttpClient ValidationHttpClient { get; }
        public HttpClient PublicationHttpClient { get; }
        public IConfiguration Config { get; }
        public string ApiKey { get; }
        public string? ValidationApiUrl { get; }
        public string? PublicationApiUrl { get; }

        public void Dispose()
        {
            ValidationHttpClient.Dispose();
            PublicationHttpClient.Dispose();
        }
    }
}
