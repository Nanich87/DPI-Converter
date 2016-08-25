namespace DpiConverter.Factories
{
    using Contracts.Files;
    using Files.Importable;

    internal class InputFileFactory
    {
        public static IImportableFile Create(string extension, bool validation = false)
        {
            IImportableFile inputFile;

            switch (extension.ToLower())
            {
                case ".xml":
                    inputFile = new LandXmlFile(validation);

                    return inputFile;
                case ".jxl":
                    inputFile = new JxlFile(validation);

                    return inputFile;
                case ".sdr":
                    inputFile = new SdrFile(validation);

                    return inputFile;
                default:
                    inputFile = new LandXmlFile(validation);

                    return inputFile;
            }
        }
    }
}