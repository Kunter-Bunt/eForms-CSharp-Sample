using eForms_CSharp_Sample_App.models;
using eForms_CSharp_Sample_App.Schemas;
using System;
using System.Text;

namespace eForms_CSharp_Sample_App.services
{
    public class CreateNoticeService
    {
        private const string Eng = "ENG";
        private const string EFormsVersion = "eforms-sdk-1.6";
        private const string UblVersion = "2.3";

        public ContractNoticeType CreateNotice(NoticeModel model)
        {
            var notice = new ContractNoticeType();
            notice.ContractFolderID = new ContractFolderIDType { Value = model.ProcessId.ToString() };
            notice.ID = CreateConformingGuid();
            notice.UBLExtensions = BuildUBLExtensions(model);
            notice.UBLVersionID = new UBLVersionIDType { Value = UblVersion };
            notice.CustomizationID = new CustomizationIDType { Value = EFormsVersion };
            return notice;
        }

        private UBLExtensionType[] BuildUBLExtensions(NoticeModel model)
        {
            var ublExtension = new UBLExtensionType();
            ublExtension.ExtensionContent = new ExtensionContentType();
            var item = ublExtension.ExtensionContent.Item = new EformsExtension();
            item.NoticeSubType = new NoticeSubTypeType
            {
                SubTypeCode = new SubTypeCodeType
                {
                    listName = "notice-subtype",
                    Value = $"{(int)model.NoticeType}"
                }
            };
            item.Organizations = new OrganizationsType
            {
                Organization = new OrganizationType[] { BuildOrg(model) }
            };
            return new UBLExtensionType[] { ublExtension };
        }

        private IDType CreateConformingGuid()
        {
            var builder = new StringBuilder(Guid.NewGuid().ToString());
            builder[14] = '4';
            builder[19] = '8';
            var id = new IDType
            {
                schemeName = "notice-id",
                Value = builder.ToString()
            };
            return id;
        }

        private OrganizationType BuildOrg(NoticeModel model)
        {
            var org = new OrganizationType();
            var company = org.Company = new CompanyType();
            var partyName = new PartyNameType
            {
                Name = new NameType1
                {
                    languageID = Eng,
                    Value = model.CompanyName
                }
            };
            company.PartyName = new PartyNameType[] { partyName };
            return org;
        }
    }
}
