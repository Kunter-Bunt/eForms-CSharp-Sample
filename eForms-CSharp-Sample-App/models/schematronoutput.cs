namespace eForms_CSharp_Sample_App.models
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.oclc.org/dsdl/svrl")]
    [System.Xml.Serialization.XmlRootAttribute("schematron-output", Namespace = "http://purl.oclc.org/dsdl/svrl", IsNullable = false)]
    public partial class schematronoutput
    {

        private object[] itemsField;

        private string titleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("active-pattern", typeof(schematronoutputActivepattern))]
        [System.Xml.Serialization.XmlElementAttribute("failed-assert", typeof(schematronoutputFailedassert))]
        [System.Xml.Serialization.XmlElementAttribute("fired-rule", typeof(schematronoutputFiredrule))]
        [System.Xml.Serialization.XmlElementAttribute("ns-prefix-in-attribute-values", typeof(schematronoutputNsprefixinattributevalues))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.oclc.org/dsdl/svrl")]
    public partial class schematronoutputActivepattern
    {

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.oclc.org/dsdl/svrl")]
    public partial class schematronoutputFailedassert
    {

        private string textField;

        private schematronoutputFailedassertDiagnosticreference diagnosticreferenceField;

        private string idField;

        private string locationField;

        private string testField;

        private string roleField;

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("diagnostic-reference")]
        public schematronoutputFailedassertDiagnosticreference diagnosticreference
        {
            get
            {
                return this.diagnosticreferenceField;
            }
            set
            {
                this.diagnosticreferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string test
        {
            get
            {
                return this.testField;
            }
            set
            {
                this.testField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.oclc.org/dsdl/svrl")]
    public partial class schematronoutputFailedassertDiagnosticreference
    {

        private string textField;

        private string diagnosticField;

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string diagnostic
        {
            get
            {
                return this.diagnosticField;
            }
            set
            {
                this.diagnosticField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.oclc.org/dsdl/svrl")]
    public partial class schematronoutputFiredrule
    {

        private string contextField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string context
        {
            get
            {
                return this.contextField;
            }
            set
            {
                this.contextField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.oclc.org/dsdl/svrl")]
    public partial class schematronoutputNsprefixinattributevalues
    {

        private string prefixField;

        private string uriField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string prefix
        {
            get
            {
                return this.prefixField;
            }
            set
            {
                this.prefixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string uri
        {
            get
            {
                return this.uriField;
            }
            set
            {
                this.uriField = value;
            }
        }
    }
}
