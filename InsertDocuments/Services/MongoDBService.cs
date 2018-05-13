using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsertDocuments.Services
{
    public class MongoDBService
    {
        private const string ConnectionString = "mongodb://localhost";

        public MongoDBService()
        {
            var clinet = new MongoClient(ConnectionString);
            var database = clinet.GetDatabase("MVCCURD");
            collection = database.GetCollection<BsonDocument>("Students");
        }

        public MongoDBService(IMongoCollection<BsonDocument> collection)
        {
            collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        public IMongoCollection<BsonDocument> collection { get; }

        public void InsertDocument(BsonDocument document)
        {
            collection.InsertOne(document);
        }

        public void InsertManyDocument(BsonDocument[] documents)
        {
            collection.InsertMany(documents);
        }

        public List<BsonDocument> Get()
        {
            var builder = Builders<BsonDocument>.Filter;
            //var filter = Builders<BsonDocument>.Filter.Eq("item", "canvas");
            //var filter = Builders<BsonDocument>.Filter.Eq("status", "D");
            //var filter = Builders<BsonDocument>.Filter.In("status", new[] { "A", "D" });

            // AND
            //var filter = builder.And(builder.Eq("status", "A"), builder.Lt("qty", 30));

            // OR
            //var filter = builder.Or(builder.Eq("status", "A"), builder.Lt("qty", 30)); 

            // AND & OR
            //var filter = builder.And(
            //    builder.Eq("status", "A"),
            //    builder.Or(builder.Lt("qty", 30), builder.Regex("item", new BsonRegularExpression("^p"))));

            //var filter = Builders<BsonDocument>.Filter.Eq("size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } });

            //var filter = Builders<BsonDocument>.Filter.Eq("size.uom", "in");

            //var filter = Builders<BsonDocument>.Filter.Lt("size.h", 15);

            /*
            
            var filter = builder.And(builder.Lt("size.h", 15), builder.Eq("size.uom", "in"), builder.Eq("status", "D"));
            */

            //var filter = Builders<BsonDocument>.Filter.Eq("tags", new[] { "red", "blank" });

            // var filter = Builders<BsonDocument>.Filter.All("tags", new[] { "red", "blank" });

            //var filter = Builders<BsonDocument>.Filter.Eq("tags", new[] { "red", "blank" });
            //var filter = Builders<BsonDocument>.Filter.All("tags", new[] { "red", "blank" });
            //var filter = Builders<BsonDocument>.Filter.Eq("tags", "red");

            //var filter = Builders<BsonDocument>.Filter.Gt("dim_cm", 25);
            //var filter = builder.And(builder.Gt("dim_cm", 15), builder.Lt("dim_cm", 20));
            //var filter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>("dim_cm", new BsonDocument { { "$gt", 22 }, { "$lt", 30 } });

            //var filter = Builders<BsonDocument>.Filter.Gt("dim_cm.1", 25);
            //var filter = Builders<BsonDocument>.Filter.Size("tags", 3);
            //var filter = Builders<BsonDocument>.Filter.AnyEq("instock", new BsonDocument { { "warehouse", "A" }, { "qty", 5 } });
            //var filter = Builders<BsonDocument>.Filter.AnyEq("instock", new BsonDocument { { "qty", 5 }, { "warehouse", "A" } });
            //var filter = Builders<BsonDocument>.Filter.Lte("instock.qty", 20);
            //var filter = Builders<BsonDocument>.Filter.Lte("instock.0.qty", 20);
            //var filter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>("instock", new BsonDocument { { "qty", 5 }, { "warehouse", "A" } });
            // var filter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>("instock", new BsonDocument { { "qty", new BsonDocument { { "$gt", 10 }, { "$lte", 20 } } } });
            // var filter = builder.And(builder.Gt("instock.qty", 10), builder.Lte("instock.qty", 20));
            //var filter = builder.And(builder.Eq("instock.qty", 5), builder.Eq("instock.warehouse", "A"));

            //var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            //var projection = Builders<BsonDocument>.Projection.Include("item").Include("status");
            //var projection = Builders<BsonDocument>.Projection.Exclude("status").Exclude("instock");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            //var result = collection.Find(filter).ToList();
            //var result = collection.Find<BsonDocument>(filter).Project(projection).ToList();

            //var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            //var projection = Builders<BsonDocument>.Projection.Include("item").Include("status").Include("size.uom");
            //var result = collection.Find<BsonDocument>(filter).Project(projection).ToList();

            //var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            //var projection = Builders<BsonDocument>.Projection.Exclude("size.uom");
            //var result = collection.Find<BsonDocument>(filter).Project(projection).ToList();

            //var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            //var projection = Builders<BsonDocument>.Projection.Include("item").Include("status").Include("instock.qty");
            //var result = collection.Find<BsonDocument>(filter).Project(projection).ToList();
            //var filter = Builders<BsonDocument>.Filter.Eq("status", "A");
            //var projection = Builders<BsonDocument>.Projection.Include("item").Include("status").Slice("instock", -1);
            //var result = collection.Find<BsonDocument>(filter).Project(projection).ToList();

            //var filter = Builders<BsonDocument>.Filter.Eq("item", BsonNull.Value);
            //var result = collection.Find(filter).ToList();
            //var filter = Builders<BsonDocument>.Filter.Type("item", BsonType.Null);
            //var result = collection.Find(filter).ToList();

            var filter = Builders<BsonDocument>.Filter.Exists("item", false);
            var result = collection.Find(filter).ToList();
            return result;
        }

       public void Update()
        {
            var filter = Builders<BsonDocument>.Filter.Lt("qty", 50);
            var update = Builders<BsonDocument>.Update.Set("size.uom", "in").Set("status", "P").CurrentDate("lastModified");
            var result = collection.UpdateMany(filter, update);
        }
    }
}
