using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASTCapi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ASTCapi.Services
{
    public class SearchService
    {
        private readonly IMongoCollection<Product> _products;

        public SearchService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("mongodb"));
            var database = client.GetDatabase("astc");
            _products = database.GetCollection<Product>("Products");
        }

        public List<Product> SearchProducts(string query)
        {
            List<Product> results = new List<Product>();

            //Filter taken from https://stackoverflow.com/questions/8382307/mongodb-c-sharp-query-for-like-on-string
            var filter = new BsonDocument { { "name", new BsonDocument { { "$regex", query }, { "$options", "i" } } } };

            return _products.Find(filter).ToList();

            //-----------------------------------------------------
            //This commented out section would enable the search to find categories as well, but we had disabled it because it introduces new issues
            //Example: user searches "ice" while looking for ice cream
            //         results include results for products with the category "spice" because it contains "ice"
            //         but the user doesn't see the item categories, so the search results would cause confusion

            //var list = _products.Find(filter).ToList();

            //foreach (var item in list)
            //{
            //    results.Add(item);
            //}

            //filter = new BsonDocument { { "category", new BsonDocument { { "$regex", query }, { "$options", "i" } } } };

            //list = _products.Find(filter).ToList();

            //foreach (var item in list)
            //{
            //    results.Add(item);
            //}

            //return results;
            //-----------------------------------------------------
        }


    }
}
