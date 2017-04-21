namespace DpiConverter.Files.Importable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Contracts.Files;
    using Data;
    using Helpers;

    internal class SdrFile : IImportableFile
    {
        private readonly bool validateFile = false;

        public SdrFile()
            : this(false)
        {
        }

        public SdrFile(bool validateFile)
        {
            this.validateFile = validateFile;
        }

        public void Open(string file, ICollection<Station> stationsList)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                int rowNumber = 1;

                int stationIndex = 1;
                double targetHeight = -1.000;

                while (reader.EndOfStream == false)
                {
                    try
                    {
                        string line = reader.ReadLine();
                        string[] data = Regex.Replace(line, @"\s\s+", " ").Trim().Split(' ');
                        if (data.Length == 0)
                        {
                            continue;
                        }

                        string code = line.Substring(0, 4);

                        switch (code)
                        {
                            case "02TP":
                            case "02IC":
                                string stationPoint = line.Substring(4, 16).Trim();
                                string stationCode = line.Substring(84, 16).Trim();
                                double stationHeight = double.Parse(line.Substring(68, 16).Trim());

                                BindingList<Observation> observations = new BindingList<Observation>();

                                Station station = new Station(
                                    stationIndex.ToString(),
                                    stationCode,
                                    stationPoint,
                                    stationHeight,
                                    observations);

                                stationsList.Add(station);

                                stationIndex++;

                                break;
                            case "03NM":
                            case "03IC":
                                targetHeight = double.Parse(line.Substring(4, 16).Trim());

                                break;
                            case "09F1":
                            case "09F2":
                                string targetPoint = line.Substring(20, 16).Trim();
                                double horizontalAngle = double.Parse(line.Substring(68, 16).Trim());

                                double slopeDistance;
                                bool slopeDistanceResult = double.TryParse(line.Substring(36, 16).Trim(), out slopeDistance);
                                if (!slopeDistanceResult)
                                {
                                    slopeDistance = -1.000;
                                }

                                double zenithAngle = double.Parse(line.Substring(52, 16).Trim());
                                string pointDescription = line.Substring(84, 16).Trim();
                                string pointCode = Observation.PredefinedCodes.Contains(pointDescription.ToLower()) ? pointDescription : string.Empty;

                                Observation observation = new Observation(
                                    pointCode,
                                    targetPoint,
                                    targetHeight,
                                    horizontalAngle,
                                    slopeDistance,
                                    zenithAngle,
                                    pointDescription);

                                stationsList.FirstOrDefault(s => s.StationIndex == stationIndex.ToString()).Observations.Add(observation);

                                break;
                        }

                        rowNumber++;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        LogHelper.Log(string.Format("Невалиден формат на данните на ред: {0}", rowNumber));
                    }
                }
            }
        }
    }
}