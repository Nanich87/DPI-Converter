namespace DpiConverter.Factories
{
    using System;
    using System.Linq;
    using DpiConverter.Files.Importable;
    using DpiConverter.Files.Importable.Contracts;

    internal class InputFileFactory
    {
        public static IImportableFile Create(string ext, bool validation = false)
        {
            IImportableFile inputFile;

            switch (ext.ToLower())
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
