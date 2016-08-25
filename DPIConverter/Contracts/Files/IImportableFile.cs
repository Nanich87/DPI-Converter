namespace DpiConverter.Contracts.Files
{
    using System.Collections.Generic;
    using Data;

    internal interface IImportableFile
    {
        void Open(string file, ICollection<Station> stations);
    }
}