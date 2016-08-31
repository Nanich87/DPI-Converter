namespace DpiConverter.Databases
{
    using System.Collections.Generic;
    using Data;

    internal class DefaultDatabase
    {
        private static readonly DefaultDatabase instance = new DefaultDatabase();
        private readonly ICollection<Station> stations = new List<Station>();

        private DefaultDatabase()
        {
        }

        public ICollection<Station> Stations
        {
            get
            {
                return this.stations;
            }
        }

        public static DefaultDatabase GetInstance()
        {
            return DefaultDatabase.instance;
        }

        public int ChangeFeatureCode(string oldCode, string newCode)
        {
            int changedFeatureCodes = 0;

            foreach (var station in this.stations)
            {
                if (station.FeatureCode.ToLower() == oldCode.ToLower())
                {
                    station.FeatureCode = newCode;

                    changedFeatureCodes++;
                }

                foreach (var observation in station.Observations)
                {
                    if (observation.FeatureCode.ToLower() == oldCode.ToLower())
                    {
                        observation.FeatureCode = newCode;

                        changedFeatureCodes++;
                    }
                }
            }

            return changedFeatureCodes;
        }
    }
}