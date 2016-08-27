namespace DpiConverter.Files.Importable
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Contracts.Files;
    using Data;

    internal class SdrFile : IImportableFile
    {
        private readonly bool validation = false;

        public SdrFile() : this(false)
        {
        }

        public SdrFile(bool validation)
        {
            this.validation = validation;
        }

        public void Open(string file, ICollection<Station> stationsList)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                int stationIndex = 1;
                double targetHeight = -1;

                while (reader.EndOfStream == false)
                {
                    string currentLine = reader.ReadLine();
                    string[] lineData = Regex.Replace(currentLine, @"\s\s+", " ").Trim().Split(' ');

                    string code = this.validation ? lineData[0] : currentLine.Substring(0, 4);

                    switch (code)
                    {
                        case "02TP":
                            if (stationsList.Count > 0)
                            {
                                stationsList.Last().CalculateVerticalAngleMisclosure();
                            }

                            string stationName = this.validation ? lineData[1] : currentLine.Substring(4, 16).Trim();
                            string stationCode = this.validation ? lineData[6] : currentLine.Substring(84, 16).Trim();
                            double stationHeight = this.validation ? double.Parse(lineData[5]) : double.Parse(currentLine.Substring(68, 16).Trim());
                            BindingList<Observation> observations = new BindingList<Observation>();

                            Station station = new Station(
                                stationIndex.ToString(),
                                stationCode,
                                stationName,
                                stationHeight,
                                observations);

                            stationsList.Add(station);

                            stationIndex++;
                            break;
                        case "03NM":
                            targetHeight = this.validation ? double.Parse(lineData[1]) : double.Parse(currentLine.Substring(4, 16).Trim());
                            break;
                        case "09F1":
                        case "09F2":
                            string targetPoint = this.validation ? lineData[2] : currentLine.Substring(20, 16).Trim();
                            double horizontalAngle = this.validation ? double.Parse(lineData[5]) : double.Parse(currentLine.Substring(68, 16).Trim());
                            double slopeDistance = this.validation ? double.Parse(lineData[3]) : double.Parse(currentLine.Substring(36, 16).Trim());
                            double zenithAngle = this.validation ? double.Parse(lineData[4]) : double.Parse(currentLine.Substring(52, 16).Trim());
                            string pointDescription = this.validation ? lineData[6] : currentLine.Substring(84, 16).Trim();
                            string pointCode = Observation.PredefinedCodes.Contains(pointDescription.ToLower()) ? pointDescription : string.Empty;

                            Observation observation = new Observation(
                                pointCode,
                                targetPoint,
                                targetHeight,
                                horizontalAngle,
                                slopeDistance,
                                zenithAngle,
                                pointDescription);

                            stationsList.Last().Observations.Add(observation);
                            break;
                    }
                }
            }
        }
    }
}