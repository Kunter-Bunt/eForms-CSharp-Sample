using System.Text;
using System.Xml.Serialization;

namespace eForms_CSharp_Sample_App.services
{
    public class SerializeNoticeService
    {
        public byte[] SerializeNotice(object eform, Encoding encoding)
        {
            var serx = new XmlSerializer(eform.GetType());
            var ns = new XmlSerializerNamespaces();
            ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            ns.Add("efac", "http://data.europa.eu/p27/eforms-ubl-extension-aggregate-components/1");
            ns.Add("efbc", "http://data.europa.eu/p27/eforms-ubl-extension-basic-components/1");
            ns.Add("efext", "http://data.europa.eu/p27/eforms-ubl-extensions/1");
            ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            var stream = new MemoryStream();
            var stringWriter = new StreamWriter(stream, encoding);
            serx.Serialize(stringWriter, eform, ns);
            return stream.ToArray();
        }
    }
}
