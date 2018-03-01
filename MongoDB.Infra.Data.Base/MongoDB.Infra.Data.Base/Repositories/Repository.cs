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

        public virtual async Task<T> Create (T entity)
        {
            await MongoCollection.InsertOneAsync(entity);
            return entity;
        }

        public abstract Task<T> Update(T entity);

        public virtual async Task<bool> Delete (T entity)
        {
            var retorn = await MongoCollection.DeleteOneAsync(x => x.Equals(entity));
            return true;
        }


        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var t = await MongoCollection.FindAsync(Filter.Empty);
            return t.ToListAsync().Result;
        }
    }

    public abstract class Repository
    {
        public readonly IMongoDatabase _db;

        public Repository(IDataContext context)
        {
            _db = context.Connect();
        }

    }
}
