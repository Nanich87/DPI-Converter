namespace DpiConverter.Databases
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DpiConverter.Data;

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
    }
}