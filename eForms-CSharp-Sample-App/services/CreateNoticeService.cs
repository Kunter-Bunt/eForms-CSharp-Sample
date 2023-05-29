using eForms_CSharp_Sample_App.models;
using eForms_CSharp_Sample_App.Schemas;
using System;
using System.Reflection.Emit;
using System.Text;

namespace eForms_CSharp_Sample_App.services
{
    public class CreateNoticeService
    {
        private const string Eng = "ENG";
        private const string Eur = "EUR";
        private const string EFormsVersion = "eforms-sdk-1.6";
        private const string UblVersion = "2.3";
        private const string ContractingOrgId = "ORG-0001";

        public ContractNoticeType CreateNotice(NoticeModel model)
        {
            var notice = new ContractNoticeType();
            notice.NoticeLanguageCode = new NoticeLanguageCodeType { Value = Eng };
            notice.AdditionalNoticeLanguage = BuildLanguages();
            notice.ContractFolderID = new ContractFolderIDType { Value = model.ProcessId.ToString() };
            notice.ID = CreateConformingGuid();
            notice.UBLExtensions = BuildUBLExtensions(model);
            notice.UBLVersionID = new UBLVersionIDType { Value = UblVersion };
            notice.CustomizationID = new CustomizationIDType { Value = EFormsVersion };
            notice.ContractingParty = new ContractingPartyType[] { BuildContractingParty() };
            notice.ProcurementProject = BuildProcurementProject(model);
            return notice;
        }

        private static LanguageType[] BuildLanguages()
        {
            return new LanguageType[]
                {
                    new LanguageType 
                    { 
                        ID = new IDType 
                        {  
                            Value = Eng 
                        } 
                    }
                };
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
                },
            };
            company.PartyName = new PartyNameType[] { partyName };
            company.WebsiteURI = new WebsiteURIType { Value = model.Website };
            company.EndpointID = new EndpointIDType { Value = model.Website };
            company.PartyIdentification = new PartyIdentificationType
            {
                ID = new IDType
                {
                    schemeName = "organisation",
                    Value = ContractingOrgId
                }
            };
            return org;
        }

        private ProcurementProjectType BuildProcurementProject(NoticeModel model)
        {
            return new ProcurementProjectType
            {
                ID = new IDType
                {
                    schemeName = "InternalID",
                    Value = model.ProcessId.ToString()
                },
                Name = new NameType1[]
                    {
                        new NameType1
                        {
                            languageID = Eng,
                            Value = model.ProcessId.ToString()
                        }
                    },
                Description = new DescriptionType[]
                    {
                        new DescriptionType
                        {
                            languageID = Eng,
                            Value = model.ProcessId.ToString()
                        }
                    },
                ProcurementTypeCode = new ProcurementTypeCodeType
                {
                    listName = "contract-nature",
                    Value = "services"
                },
                RequestedTenderTotal = new RequestedTenderTotalType
                {
                    EstimatedOverallContractAmount = new EstimatedOverallContractAmountType
                    {
                        currencyID = Eur,
                        Value = 0
                    }
                },
                MainCommodityClassification = new CommodityClassificationType[]
                {
                    new CommodityClassificationType
                    {
                        ItemClassificationCode = new ItemClassificationCodeType
                        {
                            listName = "cpv",
                            Value = "03111200-4"
                        }
                    }
                }
            };
        }


        private ContractingPartyType BuildContractingParty()
        {
            return new ContractingPartyType
            {
                ContractingPartyType1 = new ContractingPartyTypeType[]
                {
                    new ContractingPartyTypeType
                    {
                        PartyTypeCode = new PartyTypeCodeType
                        {
                            listName = "buyer-legal-type",
                            Value = "body-pl-cga"
                        }
                    },
                    new ContractingPartyTypeType
                    {
                        PartyTypeCode = new PartyTypeCodeType
                        {
                            listName = "buyer-contracting-type",
                            Value = "cont-ent"
                        }
                    }
                },
                ContractingActivity = new ContractingActivityType[]
                {
                    new ContractingActivityType
                    {
                        ActivityTypeCode = new ActivityTypeCodeType
                        {
                            listName = "authority-activity",
                            Value = "soc-pro"
                        }
                    }
                },
                Party = new PartyType
                {
                    PartyIdentification = new PartyIdentificationType[]
                    {
                        new PartyIdentificationType
                        {
                            ID = new IDType
                            {
                                schemeName = "organisation",
                                Value = ContractingOrgId
                            }
                        }
                    }
                }
            };
        }
    }
}
