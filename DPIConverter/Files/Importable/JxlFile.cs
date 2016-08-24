namespace DpiConverter.Files.Importable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using DpiConverter.Data;
    using DpiConverter.Files.Importable.Contracts;
    using DpiConverter.Helpers;

    internal class JxlFile : IImportableFile
    {
        public const string ShemaLocation = "JobXMLSchema-5.64.xsd";

        public void Open(string file, ICollection<Station> stationsList)
        {
            XDocument document = Utilities.CreateXmlDocument(file, JxlFile.ShemaLocation, Properties.Settings.Default.ValidateInputFile);

            ((List<Station>)stationsList).AddRange(TrimbleJobXmlHelper.FindStations(document));

            ICollection<TargetRecord> targetRecords = new List<TargetRecord>(TrimbleJobXmlHelper.FindTargetRecords(document));

            var observations = from observation in document.Root
                                                           .Elements()
                                                           .Where(x => x.Name.LocalName == "FieldBook")
                                                           .Elements()
                                                           .Where(x => x.Name.LocalName == "PointRecord")
                               select observation;

            foreach (var observation in observations)
            {
                string method = observation.Element("Method").Value;

                switch (method)
                {
                    case "DirectReading":
                        string targetPointName = observation.Element("Name").Value;
                        string targetPointCode = string.Empty;

                        string targetPointDescription = observation.Element("Code").Value;
                        double horizontalCircle = double.Parse(observation.Element("Circle").Element("HorizontalCircle").Value) * 200 / 180;
                        double verticalCircle = double.Parse(observation.Element("Circle").Element("VerticalCircle").Value) * 200 / 180;
                        double distance = double.Parse(observation.Element("Circle").Element("EDMDistance").Value);
                        string stationIndex = observation.Element("StationID").Value;
                        string targetIndex = observation.Element("TargetID").Value;
                        double targetHeight = targetRecords.Where(th => th.TargetIndex == targetIndex).Last().TargetHeight;

                        Observation currentObservation = new Observation(targetPointCode, targetPointName, targetHeight, horizontalCircle, distance, verticalCircle, targetPointDescription);

                        stationsList.FirstOrDefault(s => s.StationIndex == stationIndex).Observations.Add(currentObservation);
                        break;
                }
            }
        }
    }
}