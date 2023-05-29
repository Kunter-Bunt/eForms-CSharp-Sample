using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eForms_CSharp_Sample_App.models
{
    public class NoticeModel
    {
        public NoticeModel()
        {
            ProcessId = Guid.NewGuid();
            CompanyName = "MyTestCompany";
            CompanyName = "https://MyTestCompany.com";
            UID = "ATU12345";
            NoticeType = NoticeTypeEnum.ConcessionNotice;
        }
        public Guid ProcessId { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string UID { get; set; }
        public NoticeTypeEnum NoticeType { get; set; }
    }

    public enum NoticeTypeEnum
    {
        ContractNoticeGeneral = 16,
        ContractNoticeSectoral = 17,
        ContractNoticeDefence = 18,
        ConcessionNotice = 19,
    }
}
