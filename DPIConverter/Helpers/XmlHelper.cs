namespace DpiConverter.Helpers
{
    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;

    internal class XmlHelper
    {
        public static XDocument CreateXmlDocument(string fileName, string shemaLocation, bool validateInputFile = false)
        {
            if (validateInputFile)
            {
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add(null, shemaLocation);

                XmlReaderSettings xrs = new XmlReaderSettings();
                xrs.ValidationType = ValidationType.Schema;
                xrs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                xrs.Schemas = schemaSet;
                xrs.ValidationEventHandler += (o, s) =>
                    {
                        throw new ArgumentException(string.Format("{0}: {1}", s.Severity, s.Message));
                    };

                return XDocument.Load(XmlReader.Create(fileName, xrs));
            }

            return XDocument.Load(fileName);
        }
    }
}