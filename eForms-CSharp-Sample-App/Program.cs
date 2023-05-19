using eForms_CSharp_Sample_App.models;
using eForms_CSharp_Sample_App.services;
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

Console.WriteLine("Done");
Console.ReadLine();