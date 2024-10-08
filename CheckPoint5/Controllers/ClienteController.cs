using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using CheckPoint5.Models;
using CheckPoint5.Services;


namespace CheckPoint5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        private readonly MongoDbService _mongoDbService;

        public ClienteController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        /// <summary>
        /// Lista os clientes.
        /// </summary>
        /// <returns>Uma Lista de Clientes</returns>
        /// <response code="200">Retorna os Clientes cadastrados.</response>
        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(List<ClienteModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var list = await _mongoDbService.GetAsync();
            return Ok(list);
        }
            

        /// <summary>
        /// Obtem um cliente.
        /// </summary>
        /// <returns>O cliente encontrado pelo Id.</returns>
        /// <response code="200">Retorna o cliente por Id cadastrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id)
        {
            var entity = await _mongoDbService.GetByIdAsync(id);

            if (entity is null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        /// <summary>
        /// Cria o cliente.
        /// </summary>
        /// <returns>Os itens de cliente criado.</returns>
        /// <response code="201">Retorna os itens criados de cliente cadastrado.</response>
        [HttpPost]
        [ProducesResponseType( StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(ClienteInsertModel clienteInsert)
        {
            var cliente = new ClienteModel { 
                Id = ObjectId.GenerateNewId().ToString(),  // Gera um novo ObjectId
                Nome = clienteInsert.Nome,
                Email = clienteInsert.Email            
            };

            await _mongoDbService.CreateAsync(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        /// <summary>
        /// Atualiza os itens de cliente por Id.
        /// </summary>
        /// <returns>Os itens de cliente atualizado por Id.</returns>
        /// <response code="204">Retorna os itens de cliente atualizado por Id.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(string id, ClienteInsertModel updatedEntity)
        {
            var entity = await _mongoDbService.GetByIdAsync(id);

            if (entity is null)
            {
                return NotFound();
            }

            var cliente = new ClienteModel { 
                Id = id,
                Nome = updatedEntity.Nome,
                Email = updatedEntity.Email
            };

            cliente.Id = entity.Id;
            await _mongoDbService.UpdateAsync(id, cliente);

            return NoContent();
        }

        /// <summary>
        /// Deleta os itens de cliente por Id.
        /// </summary>
        /// <returns>Os itens de cliente deletado por Id.</returns>
        /// <response code="204">Retorna 204 indicando que o cliente foi excluído.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await _mongoDbService.GetByIdAsync(id);

            if (entity is null)
            {
                return NotFound();
            }

            await _mongoDbService.RemoveAsync(id);
            return NoContent();
        }
    }
}
