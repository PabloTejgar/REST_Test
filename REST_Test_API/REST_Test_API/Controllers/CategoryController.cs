using Microsoft.AspNetCore.Mvc;
using REST_Test.Business.DTO;
using REST_Test.Business.Services.Interface;
using REST_Test.Model.Models;

namespace REST_Test.API.Controllers
{
    public class CategoryController : Controller
    {
        private IGenericServiceAsync<Category, CategoryDTO> writeService;
        private IReadServiceAsync<Category, CategoryDTO> readService;
        private ILogger<CategoryController> logger;

        public CategoryController(
            IGenericServiceAsync<Category, CategoryDTO> writeService,
            IReadServiceAsync<Category, CategoryDTO> readService, 
            ILogger<CategoryController> categoryLogger)
        {
            this.writeService = writeService;
            this.readService = readService;
            logger = categoryLogger;
        }


        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            return Ok(await readService.GetAsync(id));
        }

        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            return Ok(await readService.GetAllAsync());
        }

        public async Task Create(CategoryDTO category)
        {
            await writeService.AddAsync(category);
        }


        public async Task Update(CategoryDTO category)
        {
            await writeService.UpdateAsync(category);
        }

        public async Task Delete(int id)
        {
            await writeService.DeleteAsync(id);
        }
    }
}
