namespace DpiConverter.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    internal class Observation
    {
        private string pointCode = string.Empty;
        private string targetPoint;
        private double targetHeight;
        private double horizontalAngle;
        private double slopeDistance;
        private double zenithAngle;
        private string pointDescription = string.Empty;
        private double? verticalAngleError = null;
        private double? horizontalAngleError = null;
        private ObservationPurpose purpose = ObservationPurpose.Sideshot;

        public Observation(string pointCode, string targetPoint, double targetHeight, double horizontalAngle, double slopeDistance, double zenithAngle, string pointDescription)
        {
            this.pointCode = pointCode;
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

        public double? HorizontalAngleError
        {
            get
            {
                return this.horizontalAngleError;
            }

            set
            {
                this.horizontalAngleError = value;
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

        public double? VerticalAngleError
        {
            get
            {
                return this.verticalAngleError;
            }

            set
            {
                this.verticalAngleError = value;
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
                return string.Format("{0}{1}", this.pointCode, this.targetPoint);
            }

            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("Невалиден номер на точка!");
                    }

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

                    this.PointCode = pointCode;
                    this.TargetPoint = pointNumber;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        public string TargetPoint
        {
            get
            {
                return this.targetPoint;
            }

            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("Невалиден номер на наблюдавана точка!");
                    }

                    this.targetPoint = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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