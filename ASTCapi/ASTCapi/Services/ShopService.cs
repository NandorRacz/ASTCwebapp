using ASTCapi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ASTCapi.Services
{
    public class ShopService
    {
        private readonly IMongoCollection<Shop> _shops;

        public ShopService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("mongodb"));
            var database = client.GetDatabase("astc");
            _shops = database.GetCollection<Shop>("Shops");
        }

        public List<Shop> Get()
        {
            return _shops.Find(shop => true).ToList();
        }

        public Shop Get(string id)
        {
            var shopId = new ObjectId(id);

            return _shops.Find<Shop>(shop => shop.Id == shopId).FirstOrDefault();
        }

        public Shop GetByName(string name)
        {
            return _shops.Find<Shop>(shop => shop.ShopName == name).FirstOrDefault();
        }

        public Shop Create(Shop shop)
        {
            _shops.InsertOne(shop);
            return shop;
        }

        public void Update(string id, Shop shopIn)
        {
            var docId = new ObjectId(id);

            _shops.ReplaceOne(shop => shop.Id == docId, shopIn);
        }

        public void Remove(Shop shopIn)
        {
            _shops.DeleteOne(shop => shop.Id == shopIn.Id);
        }

        public void Remove(ObjectId id)
        {
            _shops.DeleteOne(shop => shop.Id == id);
        }
    }
}
