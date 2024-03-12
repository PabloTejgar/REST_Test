using Microsoft.AspNetCore.Mvc;
using REST_Test.Model.Models;
using REST_Test.Model.Repositories;

namespace REST_Test.API.Controllers
{
    public class UserController : Controller
    {
        private IGenericRepository<User> repository;
        private ILogger<UserController> logger;

        public UserController(IGenericRepository<User> genericRepository, ILogger<UserController> userLogger)
        {
            repository = genericRepository;
            logger = userLogger;
        }

        public async Task<User> Get(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        public async Task Add(User user)
        {
            await repository.CreateAsync(user);
        }


        public async Task Update(User user)
        {
            await repository.UpdateAsync(user);
        }

        public async Task Delete(User user)
        {
            await repository.RemoveAsync(user);
        }
    }
}
