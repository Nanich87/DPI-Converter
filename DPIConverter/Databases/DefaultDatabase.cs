namespace DpiConverter.Databases
{
    using System.Collections.Generic;
    using Data;

    internal class DefaultDatabase
    {
        private static readonly DefaultDatabase Instance = new DefaultDatabase();
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
            return DefaultDatabase.Instance;
        }

        public int ChangePointCode(string oldCode, string newCode)
        {
            int affectedCodesCount = 0;

            foreach (var station in this.stations)
            {
                if (station.PointCode.ToLower() == oldCode.ToLower())
                {
                    station.PointCode = newCode;

                    affectedCodesCount++;
                }

                foreach (var observation in station.Observations)
                {
                    if (observation.PointCode.ToLower() == oldCode.ToLower())
                    {
                        observation.PointCode = newCode;

                        affectedCodesCount++;
                    }
                }
            }

            return affectedCodesCount;
        }
    }
}