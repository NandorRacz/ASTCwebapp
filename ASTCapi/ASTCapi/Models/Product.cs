using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ASTCapi.Models
{
    public class Product
    {
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string ProductName { get; set; }

        [BsonElement("brand")]
        public string ProductBrand { get; set; }

        [BsonElement("category")]
        public List<string> ProductCategories { get; set; }

        [BsonElement("shops")]
        public List<Seller> ProductSellers { get; set; }
    }
}
