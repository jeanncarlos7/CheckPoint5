using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.RegularExpressions;

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

        // Método para validar e-mail usando expressão regular
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
