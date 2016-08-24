namespace DpiConverter.Tests
{
    using System;
    using DpiConverter.Contracts.Files;
    using DpiConverter.Factories;
    using DpiConverter.Files.Importable;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InputFileFactoryTests
    {
        [TestMethod]
        public void Create_ShouldReturnLandXmlFile_WhenXmlFileExtension()
        {
            IImportableFile file = InputFileFactory.Create(".xml");

            Assert.IsInstanceOfType(file, typeof(LandXmlFile));
        }

        [TestMethod]
        public void Create_ShouldReturnJxlFile_WhenJxlFileExtension()
        {
            IImportableFile file = InputFileFactory.Create(".jxl");

            Assert.IsInstanceOfType(file, typeof(JxlFile));
        }

        [TestMethod]
        public void Create_ShouldReturnSdrFile_WhenSdrFileExtension()
        {
            IImportableFile file = InputFileFactory.Create(".sdr");

            Assert.IsInstanceOfType(file, typeof(SdrFile));
        }

        [TestMethod]
        public void Create_ShouldReturnDefaultFile_WhenInvalidExtension()
        {
            IImportableFile file = InputFileFactory.Create(".txt");

            Assert.IsInstanceOfType(file, typeof(LandXmlFile));
        }
    }
}