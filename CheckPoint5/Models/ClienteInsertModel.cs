using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheckPoint5.Models
{
    public class ClienteInsertModel
    {
        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
    }
}
