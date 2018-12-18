using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ASTCapi.Models
{
    public class SearchResult
    {
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string ProductName { get; set; }

        [BsonElement("brand")]
        public string ProductBrand { get; set; }

        [BsonElement("shops")]
        public List<Seller> ProductSellers { get; set; }
    }
}
