using eForms_CSharp_Sample_App.clients.ValidationApi;
using eForms_CSharp_Sample_App.models;
using System.Xml.Serialization;

namespace eForms_CSharp_Sample_App.extensions
{
    public static class FileResponseExtensions
    {
        public static schematronoutput? DeserializeAsShematron(this FileResponse response)
        {
            var serx = new XmlSerializer(typeof(schematronoutput));
            return serx.Deserialize(response.Stream) as schematronoutput;
        }
    }
}
