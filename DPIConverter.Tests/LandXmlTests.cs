namespace DpiConverter.Tests
{
    using Data;
    using Helpers;
    using NUnit.Framework;

    public class LandXmlTests
    {
        [TestCase("backsight", ObservationPurpose.Backsight)]
        [TestCase("traverse", ObservationPurpose.Traverse)]
        [TestCase("sideshot", ObservationPurpose.Sideshot)]
        [TestCase("unknown", ObservationPurpose.Sideshot)]
        public void GetObservationPurpose_ShouldReturnCorrectResult(string purpose, ObservationPurpose observationPurpose)
        {
            Assert.AreEqual(observationPurpose, LandXmlHelper.GetObservationPurpose(purpose));
        }
    }
}