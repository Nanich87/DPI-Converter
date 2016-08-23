namespace DpiConverter.Files.Importable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Linq;
    using DpiConverter.Data;
    using DpiConverter.Files.Importable.Contracts;
    using DpiConverter.Helpers;

    internal class LandXmlFile : IImportableFile
    {
        public const string ShemaLocation = "LandXML-1.0.xsd";

        public void Open(string file, ICollection<Station> stationsList)
        {
            XDocument document = Utilities.CreateXmlDocument(file, LandXmlFile.ShemaLocation, Properties.Settings.Default.ValidateInputFile);

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

                BindingList<Observation> observations = LandXmlHelper.GetObservations(station);

                stationsList.Add(new Station(stationIndex, stationPointCode, stationName, instrumentHeight, observations));
                stationsList.Last().CalculateVerticalAngleError();
            }
        }
    }
}