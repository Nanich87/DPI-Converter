namespace DpiConverter.Data
{
    using System;
    using System.Collections.Generic;
    using DpiConverter.Helpers;

    internal class Observation
    {
        private string featureCode = string.Empty;
        private string targetPoint;
        private double targetHeight;
        private double horizontalAngle;
        private double slopeDistance;
        private double zenithAngle;
        private string pointDescription = string.Empty;
        private double? verticalAngleMisclosure = null;
        private double? horizontalAngleMisclosure = null;
        private ObservationPurpose purpose = ObservationPurpose.Sideshot;

        public Observation(string featureCode, string targetPoint, double targetHeight, double horizontalAngle, double slopeDistance, double zenithAngle, string pointDescription)
        {
            this.featureCode = featureCode;
            this.targetPoint = targetPoint;
            this.targetHeight = targetHeight;
            this.horizontalAngle = horizontalAngle;
            this.slopeDistance = slopeDistance;
            this.zenithAngle = zenithAngle;
            this.pointDescription = pointDescription;
        }

        public static ICollection<string> PredefinedCodes
        {
            get
            {
                return new List<string>() { "tt", "pt", "ot", "lt", "nr" };
            }
        }

        public double? HorizontalAngleMisclosure
        {
            get
            {
                return this.horizontalAngleMisclosure;
            }

            set
            {
                this.horizontalAngleMisclosure = value;
            }
        }

        public ObservationPurpose Purpose
        {
            get
            {
                return this.purpose;
            }

            set
            {
                this.purpose = value;
            }
        }

        public double? VerticalAngleMisclosure
        {
            get
            {
                return this.verticalAngleMisclosure;
            }

            set
            {
                this.verticalAngleMisclosure = value;
            }
        }

        public string PointDescription
        {
            get
            {
                return this.pointDescription;
            }

            set
            {
                this.pointDescription = value;
            }
        }

        public string FullName
        {
            get
            {
                return string.Format("{0}{1}", this.featureCode, this.targetPoint);
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Невалиден номер на точка!");
                }

                string featureCode = StationHelper.ParseCode(value);
                string pointNumber = StationHelper.ParseNumber(value);

                this.FeatureCode = featureCode;
                this.TargetPoint = pointNumber;
            }
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

        public string TargetPoint
        {
            get
            {
                return this.targetPoint;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Невалиден номер на наблюдавана точка!");
                }

                this.targetPoint = value;
            }
        }

        public double TargetHeight
        {
            get
            {
                return this.targetHeight;
            }

            set
            {
                this.targetHeight = value;
            }
        }

        public double HorizontalAngle
        {
            get
            {
                return this.horizontalAngle;
            }

            set
            {
                this.horizontalAngle = value;
            }
        }

        public double SlopeDistance
        {
            get
            {
                return this.slopeDistance;
            }

            set
            {
                this.slopeDistance = value;
            }
        }

        public double ZenithAngle
        {
            get
            {
                return this.zenithAngle;
            }

            set
            {
                this.zenithAngle = value;
            }
        }
    }
}