namespace DpiConverter.Files.Exportable
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts.Files;
    using Data;

    internal class DpiFile : IExportableFile
    {
        private readonly ICollection<Station> stations;

        public DpiFile(ICollection<Station> stations)
        {
            this.stations = new List<Station>();
            ((List<Station>)this.stations).AddRange(stations);
        }

        public string Export()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Обект:");
            output.AppendLine(" Parm Klasp 8 Mr 30.0 a 5.0 b 5.0 c 0.0 tci 5.0 tcs 5.0");
            output.AppendLine(" Parm Klasv 6 Mz 50.0 tvi 5.0 tvs 5.0");

            foreach (var station in this.stations)
            {
                if (station.UseStation == false)
                {
                    continue;
                }

                output.AppendFormat("Stn {0,10} Vi {1:0.000}", station.FullName, station.InstrumentHeight);
                output.AppendLine();

                foreach (var observation in station.Observations)
                {
                    switch (observation.Purpose)
                    {
                        case ObservationPurpose.Backsight:
                            if (Properties.Settings.Default.ExportBacksightObservations == false)
                            {
                                continue;
                            }

                            break;
                        case ObservationPurpose.Traverse:
                            if (Properties.Settings.Default.ExportTraverseObservations == false)
                            {
                                continue;
                            }

                            break;
                        case ObservationPurpose.Sideshot:
                            if (Properties.Settings.Default.ExportSideshotObservations == false)
                            {
                                continue;
                            }

                            break;
                    }

                    string pointDescription = observation.PointDescription != string.Empty ? string.Format("kod       {0}", observation.PointDescription) : string.Empty;
                    
                    output.AppendFormat(
                        " Nt {0,10} R {1,10:0.0000} S {2,10:0.000} Z {3,10:0.0000} Vs {4,10:0.000} {5,10}",
                        observation.FullName,
                        observation.HorizontalAngle,
                        observation.SlopeDistance,
                        observation.ZenithAngle,
                        observation.TargetHeight,
                        pointDescription);
                    output.AppendLine();
                }
            }

            return output.ToString();
        }
    }
}