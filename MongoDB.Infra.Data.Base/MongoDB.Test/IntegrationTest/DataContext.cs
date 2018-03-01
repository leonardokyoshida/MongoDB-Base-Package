using MongoDB.Infra.Data.Base.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Test.IntegrationTest
{
    public class DataContext : BaseDataContext
    {
        public DataContext(string dataBase, string connectionString = "mongodb://localhost:27017") : base(dataBase, connectionString)
        {


            
        }
    }
}
