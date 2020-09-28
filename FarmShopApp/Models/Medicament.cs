using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FarmShopApp.Models
{
    public class Medicament
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string WordName { get; set; }
        public string Type { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdCategory { get; set; }
    }
}