using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.Linq;
using System.Collections.Generic;

namespace FarmShopApp.Models.MongoContext
{
    public class DBMongoManager : IDBManager
    {
        readonly IMongoDatabaseSettings _settings;
        const string connectionString = "mongodb://localhost:27017/farm";
        IGridFSBucket gridFS;

        public DBMongoManager(IMongoDatabaseSettings settings)
        {
            _settings = settings;
        }

        public (IMongoDatabase DataBase, IGridFSBucket GridFS) CreateConnection()
        {
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            gridFS = new GridFSBucket(database);

            return (database, gridFS);
        }

        public IEnumerable<Medicament> GetMedicamentList()
        {
            (var DataBase, var GridFS) = CreateConnection();

            var collection = DataBase.GetCollection<Medicament>(nameof(MongoCollections.medicaments));
            
            return collection.AsQueryable();
        }

        public IEnumerable<Category> GetCategoryList()
        {
            (var DataBase, var GridFS) = CreateConnection();

            var collection = DataBase.GetCollection<Category>(nameof(MongoCollections.categories));
            
            return collection.AsQueryable();
        }
    }
}