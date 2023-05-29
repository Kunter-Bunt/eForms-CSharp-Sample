using eForms_CSharp_Sample_App.clients.ValidationApi;
using Microsoft.Extensions.Configuration;

namespace eForms_CSharp_Sample_App.clients
{
    public class ClientFactory
    {
        public ClientFactory(IConfiguration config, string apiKey)
        {
            ValidationHttpClient = new HttpClient();
            Config = config;
            ApiKey = apiKey;

        }

        public IValidationClient GetValidationClient()
        {
            var client = new ValidationClient(ValidationHttpClient);
            client.BaseUrl = Config.GetSection("Settings")["ValidationApiUrl"];
            return client;
        }

        public HttpClient ValidationHttpClient { get; }
        public IConfiguration Config { get; }
        public string ApiKey { get; }

        public void Dispose()
        {
            ValidationHttpClient.Dispose();
        }
    }
}
