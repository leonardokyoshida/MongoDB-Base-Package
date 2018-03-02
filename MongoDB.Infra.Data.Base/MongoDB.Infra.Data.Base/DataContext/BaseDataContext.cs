using MongoDB.Driver;
using MongoDB.Infra.Data.Base.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Infra.Data.Base.DataContext
{
    public abstract class BaseDataContext : IDataContext
    {
        public string ConnectionString { get; }
        public string DataBaseName { get; }

        protected BaseDataContext(string dataBaseName, string connectionString = "mongodb://localhost:27017")
        {
            DataBaseName = dataBaseName;
            ConnectionString = connectionString;
        }

        public IMongoDatabase Connect()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(this.ConnectionString));


            var client = new MongoClient(settings);
            
            
            var database = client.GetDatabase(this.DataBaseName);

            //Chamar mapeamentos aqui

            return database;

        }
    }
}
