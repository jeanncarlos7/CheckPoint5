using Xunit;
using CheckPoint5.Models;

namespace CheckPoint5.Tests
{
    public class ClienteModelTests
    {
        [Fact]
        public void IsValid_ReturnsTrue_WhenAllPropertiesAreValid()
        {
            // Arrange
            var cliente = new ClienteModel
            {
                Id = "507f191e810c19729de860ea", // Exemplo de ObjectId válido
                Nome = "João da Silva",
                Email = "joao.silva@email.com"
            };

            // Act
            var result = cliente.IsValid();

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(null, "João da Silva", "joao.silva@email.com")]
        [InlineData("", "João da Silva", "joao.silva@email.com")]
        [InlineData("507f191e810c19729de860ea", null, "joao.silva@email.com")]
        [InlineData("507f191e810c19729de860ea", "", "joao.silva@email.com")]
        [InlineData("507f191e810c19729de860ea", "João da Silva", null)]
        [InlineData("507f191e810c19729de860ea", "João da Silva", "")]
        public void IsValid_ReturnsFalse_WhenAnyPropertyIsInvalid(string id, string nome, string email)
        {
            // Arrange
            var cliente = new ClienteModel
            {
                Id = id,
                Nome = nome,
                Email = email
            };

            // Act
            var result = cliente.IsValid();

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("joao.silva@email.com", true)]
        [InlineData("joao.silva.email.com", false)] // Falta o @
        [InlineData("joao.silva@", false)] // Falta o domínio
        [InlineData("joao.silva@email", false)] // Falta o sufixo (.com, .org, etc.)
        [InlineData("joao@silva@domain.com", false)] // Dois @
        [InlineData("", false)] // Email vazio
        [InlineData(null, false)] // Email nulo
        public void IsValidEmail_ReturnsExpectedResult(string email, bool expectedResult)
        {
            // Arrange
            var cliente = new ClienteModel();

            // Act
            var result = cliente.IsValidEmail(email);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
