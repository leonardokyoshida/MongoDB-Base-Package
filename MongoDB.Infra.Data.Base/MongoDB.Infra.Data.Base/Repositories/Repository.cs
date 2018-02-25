using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Infra.Data.Base.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Infra.Data.Base.Repositories
{
    public abstract class TypedRepository<T> : Repository 
    {
        public IMongoCollection<T> MongoCollection { get; }
        public FilterDefinitionBuilder<T> Filter { get; }

        public TypedRepository(string collectionName, IDataContext dataContext) : base(dataContext)
        {
            MongoCollection = _db.GetCollection<T>(collectionName);
            Filter = new FilterDefinitionBuilder<T>();
        }

        protected async Task<T> Save(T entity)
        {

            if (entity.Id == null)
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
                await MongoCollection.InsertOneAsync(entity);
                return entity;
            }
            else
            {
                return await MongoCollection.FindOneAndReplaceAsync<T>(Filter.Eq(x => x.Id, entity.Id), entity);
            }

        }

        protected async Task<bool> Remove(T entity)
        {

            //var retorn = await MongoCollection.FindOneAndDeleteAsync(Filter.Eq(x => x.Id, entity.Id));

            return true;
        }


        protected async Task<IEnumerable<T>> GetAll()
        {
            var t = await MongoCollection.FindAsync(Filter.Empty);
            return t.ToListAsync().Result;
        }
    }

    public abstract class Repository
    {
        protected readonly IMongoDatabase _db;

        protected Repository(IDataContext context)
        {
            _db = context.Connect();
        }

    }
}
