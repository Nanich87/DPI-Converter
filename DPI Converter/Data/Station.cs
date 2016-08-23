namespace DpiConverter.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;

    internal class Station
    {
        private string stationIndex;
        private string stationName;
        private double instrumentHeight;
        private BindingList<Observation> observations;
        private bool useStation = true;
        private string pointCode = string.Empty;

        public Station(string stationIndex, string pointCode, string stationName, double instrumentHeight, BindingList<Observation> observations)
        {
            this.stationIndex = stationIndex;
            this.pointCode = pointCode;
            this.stationName = stationName;
            this.instrumentHeight = instrumentHeight;
            this.observations = observations;
        }

        public string PointCode
        {
            get
            {
                return this.pointCode;
            }

            set
            {
                this.pointCode = value;
            }
        }

        public string FullName
        {
            get
            {
                string prefix = this.UseStation ? string.Empty : "-";
                return string.Format("{0}{1}{2}", prefix, this.PointCode, this.StationName);
            }

            set
            {
                StringBuilder code = new StringBuilder();

                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsLetter(value[i]))
                    {
                        code.Append(value[i]);
                    }
                    else
                    {
                        break;
                    }
                }

                string pointCode = code.ToString();

                StringBuilder number = new StringBuilder();

                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        number.Append(value[i]);
                    }
                }

                string pointNumber = number.ToString();

                this.pointCode = pointCode;
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
                this.instrumentHeight = value;
            }
        }

        public void ResetVerticalAngleError()
        {
            this.observations.ToList().ForEach(o => o.VerticalAngleError = null);
        }

        public void CalculateVerticalAngleError()
        {
            Dictionary<string, List<double>> zenithAngles = new Dictionary<string, List<double>>();

            foreach (var observation in this.observations.Where(o => o.PointCode != string.Empty))
            {
                if (zenithAngles.ContainsKey(observation.FullName.ToLower()))
                {
                    zenithAngles[observation.FullName.ToLower()].Add(observation.ZenithAngle);
                }
                else
                {
                    zenithAngles.Add(observation.FullName.ToLower(), new List<double>() { observation.ZenithAngle });
                }
            }

            foreach (var zenithAngleList in zenithAngles)
            {
                var firstFaceZenithAnglesList = zenithAngleList.Value.Where(angle => angle <= 200).ToList();
                var secondFaceZenithAnglesList = zenithAngleList.Value.Where(angle => angle > 200).ToList();

                double averageFirstFaceZenithAngle = firstFaceZenithAnglesList.Sum() / firstFaceZenithAnglesList.Count;
                double averageSecondFaceZenithAngle = secondFaceZenithAnglesList.Sum() / secondFaceZenithAnglesList.Count;
                double indexError = (400 - (averageFirstFaceZenithAngle + averageSecondFaceZenithAngle)) * 10000;

                if (firstFaceZenithAnglesList.Count > 0 && secondFaceZenithAnglesList.Count > 0)
                {
                    this.observations.Where(o => o.FullName.ToLower() == zenithAngleList.Key).First().VerticalAngleError = indexError;
                }
            }
        }
    }
}