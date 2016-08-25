namespace DpiConverter.Helpers
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Linq;
    using Data;

    internal class TrimbleJobXmlHelper
    {
        public static ICollection<TargetRecord> FindTargetRecords(XDocument document)
        {
            ICollection<TargetRecord> targetRecordsList = new List<TargetRecord>();

            var targetRecords = from target in document.Root
                                                       .Elements()
                                                       .Where(x => x.Name.LocalName == "FieldBook")
                                                       .Elements()
                                                       .Where(x => x.Name.LocalName == "TargetRecord")
                                select target;

            foreach (var targetRecord in targetRecords)
            {
                if (targetRecord.Element("TargetHeight").Value != string.Empty)
                {
                    string targetIndex = targetRecord.Attribute("ID").Value;
                    double targetHeight = double.Parse(targetRecord.Element("TargetHeight").Value);

                    TargetRecord currentTargetRecord = new TargetRecord(targetIndex, targetHeight);

                    targetRecordsList.Add(currentTargetRecord);
                }
            }

            return targetRecordsList;
        }

        public static ICollection<Station> FindStations(XDocument document)
        {
            ICollection<Station> stationsList = new List<Station>();

            var stations = from station in document.Root
                                                   .Elements()
                                                   .Where(x => x.Name.LocalName == "FieldBook")
                                                   .Elements()
                                                   .Where(x => x.Name.LocalName == "StationRecord")
                           select station;

            foreach (var station in stations)
            {
                string stationIndex = station.Attribute("ID").Value;

                string stationName = station.Element("StationName").Value;
                double instrumentHeight = double.Parse(station.Element("TheodoliteHeight").Value);

                string stationPointCode = string.Empty;

                BindingList<Observation> stationObservations = new BindingList<Observation>();

                stationsList.Add(new Station(stationIndex, stationPointCode, stationName, instrumentHeight, stationObservations));
            }

            return stationsList;
        }
    }
}