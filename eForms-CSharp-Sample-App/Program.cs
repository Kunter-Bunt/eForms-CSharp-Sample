using eForms_CSharp_Sample_App.clients;
using eForms_CSharp_Sample_App.clients.PublicationApi;
using eForms_CSharp_Sample_App.clients.ValidationApi;
using eForms_CSharp_Sample_App.extensions;
using eForms_CSharp_Sample_App.models;
using eForms_CSharp_Sample_App.services;
using Microsoft.Extensions.Configuration;
using System.Text;

Console.WriteLine("Starting");
var createNoticeService = new CreateNoticeService();
var serializeNoticeService = new SerializeNoticeService();
var noticeModel = new NoticeModel();

Console.WriteLine("Creating a notice");
var mappedNotice = createNoticeService.CreateNotice(noticeModel);

Console.WriteLine("Serializing a notice");
var serializedNotice = serializeNoticeService.SerializeNotice(mappedNotice, Encoding.UTF8);

var filename = "./out.xml";
Console.WriteLine($"Saving notice to {filename}");
File.WriteAllBytes(filename, serializedNotice);

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Console.WriteLine("Please enter Api Key:");
var apiKey = Console.ReadLine() ?? throw new InvalidOperationException("Please enter Api Key!");
var factory = new ClientFactory(config, apiKey);
var validationClient = factory.GetValidationClient();

var request = new InputNoticeValidation
{
    EFormsSdkVersion = mappedNotice.CustomizationID.Value,
    Language = "en",
    ValidationMode = InputNoticeValidationValidationMode.Static,
    Notice = serializedNotice
};
Console.WriteLine("Validating a notice");
var validationResponse = await validationClient.V1NoticesValidationAsync(factory.ApiKey, request);
var schematronoutput = validationResponse.DeserializeAsShematron();

if (schematronoutput?.HasErrors() == true)
{
    Console.WriteLine("Validation Errrors:");
    Console.WriteLine(schematronoutput.BuildErrorString());
}
else
    Console.WriteLine("No Validation Errors!");

Console.WriteLine($"Do you also want to try to publish the notice to {factory.PublicationApiUrl}? [Y/N]");
var answer = Console.ReadLine() ?? throw new InvalidOperationException("Please enter Api Key!");
if (answer.StartsWith("y", StringComparison.OrdinalIgnoreCase))
{
    var publicationClient = factory.GetPublicationClient();
    var metadata = new Metadata
    {
        NoticeAuthorEmail = config.GetSection("Settings")["PublicationMail"],
        NoticeAuthorLocale = "en",
    };
    var notice = new FileParameter(new MemoryStream(serializedNotice), $"{mappedNotice.ID.Value}.xml", "text/xml");
    Console.WriteLine("Publishing a notice");
    var publicationResponse = await publicationClient.SubmitNoticeAsync(notice, metadata);
    Console.WriteLine($"Publication Result: {publicationResponse.Success}");
    Console.WriteLine($"Validation Report: {publicationResponse.ValidationReportUrl}");
}

Console.WriteLine("Done");
Console.ReadLine();

