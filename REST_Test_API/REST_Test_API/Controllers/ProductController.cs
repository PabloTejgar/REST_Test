using Microsoft.AspNetCore.Mvc;
using REST_Test.Model.Models;
using REST_Test.Model.Repositories;

namespace REST_Test.API.Controllers
{
    public class ProductController : Controller
    {
        private IGenericRepository<Product> repository;
        private ILogger<ProductController> logger;

        public ProductController(IGenericRepository<Product> genericRepository, ILogger<ProductController> productLogger)
        {
            repository = genericRepository;
            logger = productLogger;
        }


        public async Task<Product> Get(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        public async Task Add(Product product)
        {
            await repository.CreateAsync(product);
        }


        public async Task Update(Product product)
        {
            await repository.UpdateAsync(product);
        }

        public async Task Delete(Product product)
        {
            await repository.RemoveAsync(product);
        }
    }
}
