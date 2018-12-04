using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ASTCapi.Models;

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
