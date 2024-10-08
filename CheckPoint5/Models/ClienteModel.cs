using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheckPoint5.Models
{
    public class ClienteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Id)) { return false; }

            if (string.IsNullOrWhiteSpace(Nome)) { return false; }

            if (string.IsNullOrWhiteSpace(Email)) { return false; }

            return true;
        }
    }
}
