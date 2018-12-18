using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ASTCapi.Models
{
    public class Shop
    {
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string ShopName { get; set; }

        [BsonElement("categories")]
        public List<string> ShopCategories { get; set; }

        [BsonElement("openHours")]
        public Hours ShopHours { get; set; }

        [BsonElement("logo")]
        public string ShopLogo { get; set; }

        [BsonElement("email")]
        public string ShopEmail { get; set; }

        [BsonElement("phone")]
        public string ShopPhone { get; set; }

        [BsonElement("web")]
        public string ShopWeb { get; set; }

        [BsonElement("location")]
        public Location ShopLocation { get; set; }
    }
}
