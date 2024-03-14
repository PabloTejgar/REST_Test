using Microsoft.AspNetCore.Mvc;
using REST_Test.Business.DTO;
using REST_Test.Business.Services.Interface;
using REST_Test.Model.Models;

namespace REST_Test.API.Controllers
{
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

        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            return Ok(await readService.GetAsync(id));
        }

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            return Ok(await readService.GetAllAsync());
        }

        public async Task Add(UserDTO product)
        {
            await writeService.AddAsync(product);
        }


        public async Task Update(UserDTO product)
        {
            await writeService.UpdateAsync(product);
        }

        public async Task Delete(int id)
        {
            await writeService.DeleteAsync(id);
        }
    }
}
