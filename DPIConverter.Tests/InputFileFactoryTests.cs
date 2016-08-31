namespace DpiConverter.Tests
{
    using Contracts.Files;
    using Factories;
    using Files.Importable;
    using NUnit.Framework;

    public class InputFileFactoryTests
    {
       public void Create_ShouldReturnLandXmlFile_WhenXmlFileExtension()
        {
            IImportableFile file = InputFileFactory.Create(".xml");

            Assert.IsInstanceOf(file.GetType(), typeof(LandXmlFile));
        }

        public void Create_ShouldReturnJxlFile_WhenJxlFileExtension()
        {
            IImportableFile file = InputFileFactory.Create(".jxl");

            Assert.IsInstanceOf(file.GetType(), typeof(JxlFile));
        }

        public void Create_ShouldReturnSdrFile_WhenSdrFileExtension()
        {
            IImportableFile file = InputFileFactory.Create(".sdr");

            Assert.IsInstanceOf(file.GetType(), typeof(SdrFile));
        }

        public void Create_ShouldReturnDefaultFile_WhenInvalidExtension()
        {
            IImportableFile file = InputFileFactory.Create(".txt");

            Assert.IsInstanceOf(file.GetType(), typeof(LandXmlFile));
        }
    }
}