namespace DpiConverter.Tests
{
    using System;
    using Data;
    using NUnit.Framework;

    public class ObservationTests
    {
        Observation observation;

        [SetUp]
        public void BeforeTest()
        {
            observation = new Observation("PT", "1", 1.47, 100.0000, 50.000, 100.0000, "PT1");
        }

        [TestCase("", "")]
        public void FullName_ShouldThrowArgumentException_WhenInvalidStationNameSet(string featureCode, string stationNumber)
        {
            Assert.Throws<ArgumentException>(() => observation.FullName = string.Format("{0}{1}", featureCode, stationNumber));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("   ")]
        public void StationName_ShouldThrowArgumentException_WhenInvalidStationNameSet(string targetPoint)
        {
            Assert.Throws<ArgumentException>(() => observation.TargetPoint = targetPoint);
        }

        [TestCase(-1.0000)]
        [TestCase(400.0000)]
        public void HorizontalAngle_ShouldThrowArgumentOutOfRangeException_WhenInvalidHorizontalAngleSet(double angle)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => observation.HorizontalAngle = angle);
        }

        [TestCase(-1.0000)]
        [TestCase(400.0000)]
        public void ZenithAngle_ShouldThrowArgumentOutOfRangeException_WhenInvalidZenithAngleSet(double angle)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => observation.ZenithAngle = angle);
        }
    }
}