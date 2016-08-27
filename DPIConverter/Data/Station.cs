namespace DpiConverter.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using DpiConverter.Helpers;

    internal class Station
    {
        private string stationIndex;
        private string stationName;
        private double instrumentHeight;
        private BindingList<Observation> observations;
        private bool useStation = true;
        private string featureCode = string.Empty;

        public Station(string stationIndex, string featureCode, string stationName, double instrumentHeight, BindingList<Observation> observations)
        {
            this.stationIndex = stationIndex;
            this.featureCode = featureCode;
            this.stationName = stationName;
            this.instrumentHeight = instrumentHeight;
            this.observations = observations;
        }

        public string FeatureCode
        {
            get
            {
                return this.featureCode;
            }

            set
            {
                this.featureCode = value;
            }
        }

        public string FullName
        {
            get
            {
                string prefix = this.UseStation ? string.Empty : "-";
                return string.Format("{0}{1}{2}", prefix, this.FeatureCode, this.StationName);
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Невалидно име на станция!");
                }

                string featureCode = StationHelper.ParseCode(value);
                string pointNumber = StationHelper.ParseNumber(value);

                this.featureCode = featureCode;
                this.stationName = pointNumber;
            }
        }

        public bool UseStation
        {
            get
            {
                return this.useStation;
            }

            set
            {
                this.useStation = value;
            }
        }

        public BindingList<Observation> Observations
        {
            get
            {
                return this.observations;
            }

            set
            {
                this.observations = value;
            }
        }

        public string StationIndex
        {
            get
            {
                return this.stationIndex;
            }

            set
            {
                this.stationIndex = value;
            }
        }

        public string StationName
        {
            get
            {
                return this.stationName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Невалидно име на станция!");
                }

                this.stationName = value;
            }
        }

        public double InstrumentHeight
        {
            get
            {
                return this.instrumentHeight;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Невалидна стойност за височина на инструмента!");
                }

                if (99 < value || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Височината на инструмента не може да бъде по-малка от 0.000 или по-голяма от 99 метра!");
                }

                this.instrumentHeight = value;
            }
        }

        public void ResetVerticalAngleMisclosure()
        {
            this.observations
                .ToList()
                .ForEach(o => o.VerticalAngleMisclosure = null);
        }

        public void CalculateVerticalAngleMisclosure()
        {
            Dictionary<string, List<double>> pointObservations = new Dictionary<string, List<double>>();

            foreach (var observation in this.observations.Where(o => o.FeatureCode != string.Empty))
            {
                if (pointObservations.ContainsKey(observation.FullName.ToLower()))
                {
                    pointObservations[observation.FullName.ToLower()].Add(observation.ZenithAngle);
                }
                else
                {
                    pointObservations.Add(observation.FullName.ToLower(), new List<double>() { observation.ZenithAngle });
                }
            }

            foreach (var zenithAngleCollection in pointObservations)
            {
                var firstFaceZenithAngles = zenithAngleCollection.Value.Where(angle => angle <= 200).ToList();
                var secondFaceZenithAngles = zenithAngleCollection.Value.Where(angle => angle > 200).ToList();

                double averageFirstFaceZenithAngle = firstFaceZenithAngles.Sum() / firstFaceZenithAngles.Count;
                double averageSecondFaceZenithAngle = secondFaceZenithAngles.Sum() / secondFaceZenithAngles.Count;
                double zenithAngleMisclosure = (400 - (averageFirstFaceZenithAngle + averageSecondFaceZenithAngle)) * 10000;

                if (firstFaceZenithAngles.Count > 0 && secondFaceZenithAngles.Count > 0)
                {
                    this.observations
                        .Where(o => o.FullName.ToLower() == zenithAngleCollection.Key)
                        .First()
                        .VerticalAngleMisclosure = zenithAngleMisclosure;
                }
            }
        }
    }
}