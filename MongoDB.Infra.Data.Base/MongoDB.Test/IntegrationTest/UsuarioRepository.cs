using MongoDB.Infra.Data.Base.Interface;
using MongoDB.Infra.Data.Base.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Test.IntegrationTest
{
    public class UsuarioRepository : TypedRepository<Usuario>
    {
        public UsuarioRepository(string collectionName, IDataContext dataContext) : base(collectionName, dataContext)
        {

        }

        public override async Task<Usuario> Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
