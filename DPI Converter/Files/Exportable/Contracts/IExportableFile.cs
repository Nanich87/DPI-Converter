namespace DpiConverter.Files.Exportable.Contracts
{
    using System;
    using System.Linq;

    internal interface IExportableFile
    {
        string Export();
    }
}