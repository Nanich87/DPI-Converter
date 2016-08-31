namespace DpiConverter.Tests
{
    using System;
    using System.ComponentModel;
    using Data;
    using Helpers;
    using NUnit.Framework;

    public class StationTests
    {
        Station station;

        [SetUp]
        public void BeforeTest()
        {
            station = new Station("1", "PT", "100", 1.605, new BindingList<Observation>());
        }

        [TestCase("", "")]
        public void FullName_ShouldThrowArgumentException_WhenInvalidStationNameSet(string featureCode, string stationNumber)
        {
            Assert.Throws<ArgumentException>(() => station.FullName = string.Format("{0}{1}", featureCode, stationNumber));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("   ")]
        public void StationName_ShouldThrowArgumentException_WhenInvalidStationNameSet(string stationName)
        {
            Assert.Throws<ArgumentException>(() => station.StationName = stationName);
        }

        [TestCase(-1)]
        [TestCase(100)]
        public void InstrumentHeight_ShouldThrowArgumentOutOfRangeException_WhenInvalidInstrumentHeightSet(double instrumentHeight)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => station.InstrumentHeight = instrumentHeight);
        }

        [TestCase("PT100", "100")]
        [TestCase("100", "100")]
        [TestCase("100N", "100")]
        public void ParseNumber_ShouldReturnCorrectResult(string stationName, string stationNumber)
        {
            Assert.AreEqual(stationNumber, StationHelper.ParseNumber(stationName));
        }

        [TestCase("PT100", "PT")]
        [TestCase("100", "")]
        public void ParseCode_ShouldReturnCorrectResult(string stationName, string featureCode)
        {
            Assert.AreEqual(featureCode, StationHelper.ParseCode(stationName));
        }
    }
}