namespace DpiConverter.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using DpiConverter.Data;

    internal class Utilities
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

        public static int ChangePointCode(string oldCode, string newCode, ICollection<Station> stationsList)
        {
            int affectedCodesCount = 0;

            foreach (var station in stationsList)
            {
                if (station.PointCode.ToLower() == oldCode.ToLower())
                {
                    station.PointCode = newCode;

                    affectedCodesCount++;
                }

                foreach (var observation in station.Observations)
                {
                    if (observation.PointCode.ToLower() == oldCode.ToLower())
                    {
                        observation.PointCode = newCode;

                        affectedCodesCount++;
                    }
                }
            }

            return affectedCodesCount;
        }
    }
}