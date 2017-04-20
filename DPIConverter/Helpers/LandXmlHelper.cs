namespace DpiConverter.Helpers
{
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Linq;
    using Data;

    internal class LandXmlHelper
    {
        public static ObservationPurpose GetObservationPurpose(string purpose)
        {
            switch (purpose)
            {
                case "backsight":
                    return ObservationPurpose.Backsight;
                case "traverse":
                    return ObservationPurpose.Traverse;
                case "sideshot":
                    return ObservationPurpose.Sideshot;
                default:
                    return ObservationPurpose.Sideshot;
            }
        }

        public static BindingList<Observation> ParseObservations(XElement station)
        {
            BindingList<Observation> observationsList = new BindingList<Observation>();

            var rawObservations = station.Elements().Where(x => x.Name.LocalName == "RawObservation");

            var previousPointName = string.Empty;

            foreach (var observation in rawObservations)
            {
                var observationPointFeature = observation.Elements().FirstOrDefault(x => x.Name.LocalName == "Feature");

                string observationPointCode = string.Empty;
                string observationPointName = string.Empty;
                string observationPointDescription = string.Empty;

                if (observationPointFeature != null)
                {
                    if (Properties.Settings.Default.UsePredefinedPointCodes)
                    {
                        string code = observationPointFeature.Attribute("code") != null ? observationPointFeature.Attribute("code").Value : string.Empty;

                        if (Observation.PredefinedCodes.Contains(code))
                        {
                            observationPointCode = code;
                        }
                        else
                        {
                            observationPointDescription = code;
                        }
                    }
                    else
                    {
                        observationPointCode = observationPointFeature.Attribute("code") != null ? observationPointFeature.Attribute("code").Value : string.Empty;
                    }
                }

                var observationTargetPoint = observation.Elements().FirstOrDefault(x => x.Name.LocalName == "TargetPoint");

                if (observationTargetPoint != null)
                {
                    observationPointName = observationTargetPoint.Attribute("name") != null ? observationTargetPoint.Attribute("name").Value : string.Empty;

                    if (previousPointName == string.Empty)
                    {
                        previousPointName = observationPointName;
                    }

                    if (observationTargetPoint.Attribute("desc") != null)
                    {
                        observationPointDescription = observationTargetPoint.Attribute("desc").Value;
                    }
                }

                double targetHeight = observation.Attribute("targetHeight") != null ? double.Parse(observation.Attribute("targetHeight").Value) : -1;
                double horizAngle = observation.Attribute("horizAngle") != null ? double.Parse(observation.Attribute("horizAngle").Value) : -1;
                double slopeDistance = observation.Attribute("slopeDistance") != null ? double.Parse(observation.Attribute("slopeDistance").Value) : -1;
                double zenithAngle = observation.Attribute("zenithAngle") != null ? double.Parse(observation.Attribute("zenithAngle").Value) : -1;

                if (observationsList.Count > 0 && observation.Attribute("slopeDistance") == null && observationPointName == previousPointName)
                {
                    slopeDistance = observationsList.Last().SlopeDistance * System.Math.Sin(observationsList.Last().ZenithAngle * System.Math.PI / 200) / System.Math.Sin(zenithAngle*System.Math.PI / 200);
                }

                Observation currentObservation = new Observation(observationPointCode, observationPointName, targetHeight, horizAngle, slopeDistance, zenithAngle, observationPointDescription);

                currentObservation.Purpose = LandXmlHelper.GetObservationPurpose(observation.Attribute("purpose").Value);

                if (currentObservation.Purpose == ObservationPurpose.Sideshot &&
                    Properties.Settings.Default.AddOffsetToSideshotPoints &&
                    currentObservation.FeatureCode == string.Empty)
                {
                    int pointNumber;

                    if (int.TryParse(currentObservation.TargetPoint, out pointNumber))
                    {
                        currentObservation.TargetPoint = (Properties.Settings.Default.SideshotPointNumberOffset + pointNumber).ToString();
                    }
                }

                observationsList.Add(currentObservation);

                previousPointName = observationPointName;
            }

            return observationsList;
        }
    }
}