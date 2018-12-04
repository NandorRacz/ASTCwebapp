using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASTCapi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ASTCapi.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("mongodb"));
            var database = client.GetDatabase("astc");
            _products = database.GetCollection<Product>("Products");
        }

        public List<Product> Get()
        {
            return _products.Find(product => true).ToList();
        }

        public Product Get(string id)
        {
            var shopId = new ObjectId(id);

            return _products.Find<Product>(product => product.Id == shopId).FirstOrDefault();
        }

        public Product GetByName(string name)
        {
            ;
            return _products.Find<Product>(product => product.ProductName == name).FirstOrDefault();
        }

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, Product shopIn)
        {
            var docId = new ObjectId(id);

            _products.ReplaceOne(product => product.Id == docId, shopIn);
        }

        public void Remove(Product shopIn)
        {
            _products.DeleteOne(product => product.Id == shopIn.Id);
        }

        public void Remove(ObjectId id)
        {
            _products.DeleteOne(product => product.Id == id);
        }
    }
}
