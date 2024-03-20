using Microsoft.AspNetCore.Mvc;
using REST_Test.Business.DTO;
using REST_Test.Business.Services.Interface;
using REST_Test.Model.Models;

namespace REST_Test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IGenericServiceAsync<Product, ProductDTO> writeService;
        private IReadServiceAsync<Product, ProductDTO> readService;
        private ILogger<ProductController> logger;

        public ProductController(
            IGenericServiceAsync<Product, ProductDTO> writeService,
            IReadServiceAsync<Product, ProductDTO> readService,
            ILogger<ProductController> productLogger)
        {
            this.writeService = writeService;
            this.readService = readService;
            logger = productLogger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            return Ok(await readService.GetAsync(id));
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            return Ok(await readService.GetAllAsync());
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task Create(ProductDTO product)
        {
            await writeService.AddAsync(product);
        }

        [HttpPut("")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Update(ProductDTO product)
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
