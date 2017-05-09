namespace DpiConverter.Files.Importable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
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

        public void Open(string path, ICollection<Station> stationsList)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int rowNumber = 1;
                string line = string.Empty;

                double targetHeight = -1.000;

                while (reader.EndOfStream == false)
                {
                    try
                    {
                        line = reader.ReadLine();
                        if (line.Trim().Length < 4)
                        {
                            continue;
                        }

                        string code = line.Substring(0, 4);

                        switch (code)
                        {
                            case "02TP":
                            case "02IC":
                                string stationIndex = Station.GenerateUniqueIndex().ToString();
                                string stationPoint = line.Substring(4, 16).Trim();
                                string stationCode = line.Substring(84, 16).Trim();
                                double stationHeight = double.Parse(line.Substring(68, 16).Trim());

                                BindingList<Observation> observations = new BindingList<Observation>();

                                Station station = new Station(
                                    stationIndex,
                                    stationCode,
                                    stationPoint,
                                    stationHeight,
                                    observations);

                                stationsList.Add(station);

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
                        LogHelper.Log(string.Format("Невалиден формат на данните на ред: {0} Записът се пропуска: {1}", rowNumber, line));
                    }
                }
            }
        }
    }
}