using Microsoft.AspNetCore.Mvc;
using REST_Test.Business.DTO;
using REST_Test.Business.Services.Interface;
using REST_Test.Model.Models;

namespace REST_Test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IGenericServiceAsync<User, UserDTO> writeService;
        private IReadServiceAsync<User, UserDTO> readService;
        private ILogger<UserController> logger;

        public UserController(IGenericServiceAsync<User, UserDTO> writeService,
            IReadServiceAsync<User, UserDTO> readService,
            ILogger<UserController> userLogger)

        {
            this.writeService = writeService;
            this.readService = readService;
            logger = userLogger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            return Ok(await readService.GetAsync(id));
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            return Ok(await readService.GetAllAsync());
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task Add(UserDTO product)
        {
            await writeService.AddAsync(product);
        }

        [HttpPut("")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Update(UserDTO product)
        {
            await writeService.UpdateAsync(product);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task Delete(int id)
        {
            await writeService.DeleteAsync(id);
        }
    }
}
