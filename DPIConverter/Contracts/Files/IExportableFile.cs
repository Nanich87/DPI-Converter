namespace DpiConverter.Contracts.Files
{
    using System;
    using System.Linq;

    internal interface IExportableFile
    {
        string Export();
    }
}