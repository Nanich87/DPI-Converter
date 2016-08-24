namespace DpiConverter.Files.Importable.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DpiConverter.Data;

    internal interface IImportableFile
    {
        void Open(string file, ICollection<Station> stations);
    }
}