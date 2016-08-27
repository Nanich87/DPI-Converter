namespace DpiConverter.Files.Importable
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Linq;
    using Contracts.Files;
    using Data;
    using Helpers;

    internal class LandXmlFile : IImportableFile
    {
        public const string ShemaLocation = "LandXML-1.0.xsd";

        private readonly bool validation = false;

        public LandXmlFile() : this(false)
        {
        }

        public LandXmlFile(bool validation)
        {
            this.validation = validation;
        }

        public void Open(string fileName, ICollection<Station> stationsList)
        {
            XDocument document = XmlHelper.CreateXmlDocument(fileName, LandXmlFile.ShemaLocation, this.validation);

            var stations = from station in document.Root
                                                   .Elements()
                                                   .Where(x => x.Name.LocalName == "Survey")
                                                   .Elements()
                                                   .Where(x => x.Name.LocalName == "InstrumentSetup")
                           select station;

            foreach (var station in stations)
            {
                string stationIndex = station.Attribute("id").Value;
                string stationName = station.Attribute("stationName").Value;
                double instrumentHeight = double.Parse(station.Attribute("instrumentHeight").Value);

                var stationPointFeature = station.Elements().FirstOrDefault(x => x.Name.LocalName == "Feature");
                string stationPointCode = string.Empty;

                if (stationPointFeature != null)
                {
                    stationPointCode = stationPointFeature.Attribute("code") != null ? stationPointFeature.Attribute("code").Value : string.Empty;
                }

                BindingList<Observation> observations = LandXmlHelper.ParseObservations(station);

                stationsList.Add(new Station(stationIndex, stationPointCode, stationName, instrumentHeight, observations));
                stationsList.Last().CalculateVerticalAngleMisclosure();
            }
        }
    }
}