using Microsoft.AspNetCore.Mvc;
using REST_Test.Model.Models;
using REST_Test.Model.Repositories;

namespace REST_Test.API.Controllers
{
    public class CategoryController : Controller
    {
        private IGenericRepository<Category> repository;
        private ILogger<CategoryController> logger;

        public CategoryController(IGenericRepository<Category> genericRepository, ILogger<CategoryController> categoryLogger)
        {
            repository = genericRepository;
            logger = categoryLogger;
        }


        public async Task<Category> Get(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        public async Task Add(Category category)
        {
            await repository.CreateAsync(category);
        }


        public async Task Update(Category category)
        {
            await repository.UpdateAsync(category);
        }

        public async Task Delete(Category category)
        {
            await repository.RemoveAsync(category);
        }
    }
}
