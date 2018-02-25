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
        public string DataBase { get; }

        protected BaseDataContext(string dataBase, string connectionString = "mongodb://localhost:27017")
        {
            DataBase = dataBase;
            ConnectionString = connectionString;
        }

        public IMongoDatabase Connect()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(this.ConnectionString));
            var client = new MongoClient(settings);

            var database = client.GetDatabase(this.DataBase);

            //Chamar mapeamentos aqui

            return database;

        }
    }
}
