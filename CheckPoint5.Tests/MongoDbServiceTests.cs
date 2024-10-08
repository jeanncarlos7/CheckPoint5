using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CheckPoint5.Services;
using CheckPoint5.Models;
using CheckPoint5.Settings;

namespace CheckPoint5.Tests
{
    public class MongoDbServiceTests
    {
        private readonly Mock<IMongoCollection<ClienteModel>> _mockCollection;
        private readonly Mock<IMongoDatabase> _mockDatabase;
        private readonly Mock<IMongoClient> _mockClient;
        private readonly MongoDbService _service;

        public MongoDbServiceTests()
        {
            _mockCollection = new Mock<IMongoCollection<ClienteModel>>();
            _mockDatabase = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();

            var settings = new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "testdb",
                CollectionName = "clientes"
            };
            var mockOptions = Options.Create(settings);

            _mockClient.Setup(c => c.GetDatabase(It.IsAny<string>(), null))
                       .Returns(_mockDatabase.Object);

            _mockDatabase.Setup(d => d.GetCollection<ClienteModel>(It.IsAny<string>(), null))
                         .Returns(_mockCollection.Object);

            _service = new MongoDbService(mockOptions);
        }

        [Fact]
        public async Task GetAsync_ReturnsListOfClientes()
        {
            // Arrange
            var mockCursor = new Mock<IAsyncCursor<ClienteModel>>();
            mockCursor.Setup(_ => _.Current).Returns(new List<ClienteModel> { new ClienteModel() });
            mockCursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);

            _mockCollection.Setup(x => x.FindAsync(It.IsAny<FilterDefinition<ClienteModel>>(),
                It.IsAny<FindOptions<ClienteModel, ClienteModel>>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(mockCursor.Object);

            // Act
            var result = await _service.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsCliente_WhenFound()
        {
            // Arrange
            var id = "66e5df3ff574bb92853c830e";
            var cliente = new ClienteModel { Id = id };
            var mockCursor = new Mock<IAsyncCursor<ClienteModel>>();
            mockCursor.Setup(_ => _.Current).Returns(new List<ClienteModel> { cliente });
            mockCursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);

            _mockCollection.Setup(x => x.FindAsync(It.IsAny<FilterDefinition<ClienteModel>>(),
                It.IsAny<FindOptions<ClienteModel, ClienteModel>>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(mockCursor.Object);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task CreateAsync_InsertsNewEntity()
        {
            // Arrange
            var newEntity = new ClienteModel { Id = "66e5df3ff574bb92853c830e", Nome = "Teste" };

            // Simule a operação de inserção, não conecte ao MongoDB real
            _mockCollection.Setup(x => x.InsertOneAsync(newEntity, null, default))
                           .Returns(Task.CompletedTask); // Simulação de retorno vazio (sem erros)

            // Act
            await _service.CreateAsync(newEntity);

            // Assert
            _mockCollection.Verify(x => x.InsertOneAsync(newEntity, null, default), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ReplacesEntity()
        {
            // Arrange
            var id = "66e5df3ff574bb92853c830e";
            var updatedEntity = new ClienteModel { Id = id, Nome = "Updated Teste" };

            // Act
            await _service.UpdateAsync(id, updatedEntity);

            // Assert
            _mockCollection.Verify(x => x.ReplaceOneAsync(
                It.IsAny<FilterDefinition<ClienteModel>>(), // Filtro
                updatedEntity,                              // Entidade atualizada
                It.IsAny<ReplaceOptions>(),                 // Opções de substituição (null por padrão)
                It.IsAny<CancellationToken>()               // Token de cancelamento
            ), Times.Once);
        }

        [Fact]

        public async Task RemoveAsync_DeletesEntity()
        {
            // Arrange
            var id = "66e5df3ff574bb92853c830e";

            // Act
            await _service.RemoveAsync(id);

            // Assert
            _mockCollection.Verify(x => x.DeleteOneAsync(It.IsAny<FilterDefinition<ClienteModel>>(), default), Times.Once);
        }
    }
}
