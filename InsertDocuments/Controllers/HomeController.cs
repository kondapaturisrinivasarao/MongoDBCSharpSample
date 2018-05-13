using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsertDocuments.Models;
using MongoDB.Bson;
using InsertDocuments.Services;
namespace InsertDocuments.Controllers
{
    public class HomeController : Controller
    {
        public void Insert()
        {
            var document = new BsonDocument
            {
                { "item", "canvas" },
                { "qty", 100 },
                { "tags", new BsonArray { "cotton" } },
                { "size", new BsonDocument { { "h", 28 }, { "w", 35.5 }, { "uom", "cm" } } }
            };

            MongoDBService mongoDBService = new MongoDBService();
            mongoDBService.InsertDocument(document);
        }

        public void InsertMany()
        {
            var documents = new BsonDocument[]
            {
                new BsonDocument
                {
                    { "item", "journal" },
                    { "qty", 25 },
                    { "tags", new BsonArray { "blank", "red" } },
                    { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, {  "uom", "cm"} } }
                },
                new BsonDocument
                {
                    { "item", "mat" },
                    { "qty", 85 },
                    { "tags", new BsonArray { "gray" } },
                    { "size", new BsonDocument { { "h", 27.9 }, { "w", 35.5 }, {  "uom", "cm"} } }
                },
                new BsonDocument
                {
                    { "item", "mousepad" },
                    { "qty", 25 },
                    { "tags", new BsonArray { "gel", "blue" } },
                    { "size", new BsonDocument { { "h", 19 }, { "w", 22.85 }, {  "uom", "cm"} } }
                },
                new BsonDocument
                {
                    { "item", "journal" },
                    { "qty", 25 },
                    { "tags", new BsonArray { "blank", "red" } },
                    { "dim_cm", new BsonArray { 14, 21 } }
                },
                new BsonDocument
                {
                    { "item", "notebook" },
                    { "qty", 50 },
                    { "tags", new BsonArray { "red", "blank" } },
                    { "dim_cm", new BsonArray { 14, 21 } }
                },
                new BsonDocument
                {
                    { "item", "paper" },
                    { "qty", 100 },
                    { "tags", new BsonArray { "red", "blank", "plain" } },
                    { "dim_cm", new BsonArray { 14, 21 } }
                },
                new BsonDocument
                {
                    { "item", "planner" },
                    { "qty", 75 },
                    { "tags", new BsonArray { "blank", "red" } },
                    { "dim_cm", new BsonArray { 22.85, 30 } }
                },
                new BsonDocument
                {
                    { "item", "postcard" },
                    { "qty", 45 },
                    { "tags", new BsonArray { "blue" } },
                    { "dim_cm", new BsonArray { 10, 15.25 } }
                }
            ,
                new BsonDocument
                {
                    { "item", "journal" },
                    { "qty", 25 },
                    { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } } },
                    { "status", "A" }
                },
                new BsonDocument
                {
                    { "item", "notebook" },
                    { "qty", 50 },
                    { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
                    { "status", "A" }
                },
                new BsonDocument
                {
                    { "item", "paper" },
                    { "qty", 100 },
                    { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
                    { "status", "D" }
                },
                new BsonDocument
                {
                    { "item", "planner" },
                    { "qty", 75 },
                    { "size", new BsonDocument { { "h", 22.85 }, { "w", 30 }, { "uom", "cm" } } },
                    { "status", "D" }
                },
                new BsonDocument
                {
                    { "item", "postcard" },
                    { "qty", 45 },
                    { "size", new BsonDocument { { "h", 10 }, { "w", 15.25 }, { "uom", "cm" } } },
                    { "status", "A" } },
                new BsonDocument
                {
                    { "item", "journal" },
                    { "qty", 25 },
                    { "tags", new BsonArray { "blank", "red" } },
                    { "dim_cm", new BsonArray { 14, 21 } }
                },
                new BsonDocument
                {
                    { "item", "notebook" },
                    { "qty", 50 },
                    { "tags", new BsonArray { "red", "blank" } },
                    { "dim_cm", new BsonArray { 14, 21 } }
                },
                new BsonDocument
                {
                    { "item", "paper" },
                    { "qty", 100 },
                    { "tags", new BsonArray { "red", "blank", "plain" } },
                    { "dim_cm", new BsonArray { 14, 21 } }
                },
                new BsonDocument
                {
                    { "item", "planner" },
                    { "qty", 75 },
                    { "tags", new BsonArray { "blank", "red" } },
                    { "dim_cm", new BsonArray { 22.85, 30 } }
                },
                new BsonDocument
                {
                    { "item", "postcard" },
                    { "qty", 45 },
                    { "tags", new BsonArray { "blue" } },
                    { "dim_cm", new BsonArray { 10, 15.25 } }
                },
                new BsonDocument
                {
                    { "item", "journal" },
                    { "instock", new BsonArray
                        {
                            new BsonDocument { { "warehouse", "A" }, { "qty", 5 } },
                            new BsonDocument { { "warehouse", "C" }, { "qty", 15 } } }
                        }
                },
                new BsonDocument
                {
                    { "item", "notebook" },
                    { "instock", new BsonArray
                        {
                            new BsonDocument { { "warehouse", "C" }, { "qty", 5 } } }
                        }
                },
                new BsonDocument
                {
                    { "item", "paper" },
                    { "instock", new BsonArray
                        {
                            new BsonDocument { { "warehouse", "A" }, { "qty", 60 } },
                            new BsonDocument { { "warehouse", "B" }, { "qty", 15 } } }
                        }
                },
                new BsonDocument
                {
                    { "item", "planner" },
                    { "instock", new BsonArray
                        {
                            new BsonDocument { { "warehouse", "A" }, { "qty", 40 } },
                            new BsonDocument { { "warehouse", "B" }, { "qty", 5 } } }
                        }
                },
                new BsonDocument
                {
                    { "item", "postcard" },
                    { "instock", new BsonArray
                        {
                            new BsonDocument { { "warehouse", "B" }, { "qty", 15 } },
                            new BsonDocument { { "warehouse", "C" }, { "qty", 35 } } }
                        }
                },new BsonDocument
                {
                    { "item", "journal" },
                    { "status", "A" },
                    { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } } },
                    { "instock", new BsonArray
                        {
                            new BsonDocument { { "warehouse", "A" }, { "qty", 5 } } }
                        }
                },
                new BsonDocument
                {
                    { "item", "notebook" },
                    { "status", "A" },
                    { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
                    { "instock", new BsonArray
                        {
                            new BsonDocument { { "warehouse", "C" }, { "qty", 5 } } }
                        }
                },
                new BsonDocument
                {
                    { "item", "paper" },
                    { "status", "D" },
                    { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
                    { "instock", new BsonArray
                        {
                            new BsonDocument { { "warehouse", "A" }, { "qty", 60 } } }
                        }
                },
                new BsonDocument
                {
                    { "item", "planner" },
                    { "status", "D" },
                    { "size", new BsonDocument { { "h", 22.85 }, { "w", 30 }, { "uom", "cm" } } },
                    { "instock", new BsonArray
                        {
                            new BsonDocument { { "warehouse", "A" }, { "qty", 40 } } }
                        }
                },
                new BsonDocument
                {
                    { "item", "postcard" },
                    { "status", "A" },
                    { "size", new BsonDocument { { "h", 10 }, { "w", 15.25 }, { "uom", "cm" } } },
                    { "instock", new BsonArray
                        {
                            new BsonDocument { { "warehouse", "B" }, { "qty", 15 } },
                            new BsonDocument { { "warehouse", "C" }, { "qty", 35 } } }
                        }
                },
                new BsonDocument { { "_id", 1 }, { "item", BsonNull.Value } },
                new BsonDocument { { "_id", 2 } }
            };
            MongoDBService mongoDBService = new MongoDBService();
            mongoDBService.InsertManyDocument(documents);
        }

        public void Update()
        {
            MongoDBService mongoDBService = new MongoDBService();
            mongoDBService.Update();
        }
        public IActionResult Index()
        {
            MongoDBService mongoDBService = new MongoDBService();
            var result = mongoDBService.Get();
            ViewBag.result = result.ToJson();
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        /*
        db.collection.insertOne()	Inserts a single document into a collection.
        db.collection.insertMany()	db.collection.insertMany() inserts multiple documents into a collection.
        db.collection.insert()	db.collection.insert() inserts a single document or multiple documents into a collection.

        db.collection.update() when used with the upsert: true option.
        db.collection.updateOne() when used with the upsert: true option.
        db.collection.updateMany() when used with the upsert: true option.
        db.collection.findAndModify() when used with the upsert: true option.
        db.collection.findOneAndUpdate() when used with the upsert: true option.
        db.collection.findOneAndReplace() when used with the upsert: true option.
        db.collection.save().
        db.collection.bulkWrite()
         */
    }
}
