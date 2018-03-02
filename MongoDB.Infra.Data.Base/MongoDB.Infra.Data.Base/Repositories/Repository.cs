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
            Filter = Builders<T>.Filter;
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await MongoCollection.InsertOneAsync(entity);
            return entity;
        }

        public abstract Task<T> UpdateAsync(T entity);

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            var result = await MongoCollection.DeleteOneAsync(x => x.Equals(entity));
            return result.IsAcknowledged;
        }


        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var t = await MongoCollection.FindAsync(Filter.Empty);
            return await t.ToListAsync();
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
