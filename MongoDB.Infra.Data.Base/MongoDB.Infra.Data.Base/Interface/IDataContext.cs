using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Infra.Data.Base.Interface
{
    public interface IDataContext
    {
        string ConnectionString { get; }
        string DataBaseName{ get; }

        IMongoDatabase Connect();
    }
}
