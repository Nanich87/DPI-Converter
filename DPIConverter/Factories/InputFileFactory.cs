namespace DpiConverter.Factories
{
    using System;
    using System.Linq;
    using DpiConverter.Contracts.Files;
    using DpiConverter.Files.Importable;

    internal class InputFileFactory
    {
        public static IImportableFile Create(string extension, bool validation = false)
        {
            IImportableFile inputFile;

            switch (extension.ToLower())
            {
                case ".xml":
                    inputFile = new LandXmlFile();

                    return inputFile;
                case ".jxl":
                    inputFile = new JxlFile();

                    return inputFile;
                case ".sdr":
                    inputFile = new SdrFile(validation);

                    return inputFile;
                default:
                    inputFile = new LandXmlFile();

                    return inputFile;
            }
        }
    }
}