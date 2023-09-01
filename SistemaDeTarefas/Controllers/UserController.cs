using Domain.Dto;
using Domain.Interface.ServicesRepository;
using Domain.services.serviceUser.InterfaceUsersServices;
using Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserId _userId;

        public UserController(IUserId userId)
        {
            _userId = userId;
        }

        [HttpGet(Name = "Buscar todos os Usuarios")]
        public async Task<IActionResult> Get([FromServices] IAllUsers userService)
        {          

            var users = await userService.SearchAllUsersAsync();
            return this.StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet("{id}", Name = "Buscar usuário pelo ID")]
        public async Task<IActionResult> Get([FromServices] IUserId userService, int id)
        {
            var user = await userService.SearchUserIdAsync(id);
            return this.StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpGet("Buscar/{email}", Name = "Buscar usuário pelo email")]
        public async Task<IActionResult> GetEmail([FromServices] ISearchEamil userService, string email)
        {   

            var user = await userService.SearchEamil(email);

            if (user != null)
            {

                return this.StatusCode(StatusCodes.Status201Created, user);

            }
            else
            {
                throw new Exception("teste");
            }
        }

        [HttpPost(Name = "Adcionar Usuário")]
        public async Task<IActionResult> Post([FromServices] IPostUser userService, ModelUserDto model)
        {
            var user = await userService.AddUserAsync(model);
            return this.StatusCode(StatusCodes.Status201Created, user);
        }

        [HttpPut("{id}", Name = "Atulizar usuário")]
        public async Task<IActionResult> Put([FromServices] IUserUp userService, ModelUserDto modelUser)
        {
            var updatedUser = await userService.UpUserAsync(modelUser);

            if (updatedUser != null && updatedUser.Id == modelUser.Id) // Verifique se o usuário foi atualizado e o ID corresponde
            {
                return this.StatusCode(StatusCodes.Status201Created, updatedUser);
            }
            else
            {
                throw new Exception("Erro ao Atualizar usuário");
            }
        }

        [HttpDelete("{id}", Name = "Deletar usuário pelo ID")]
        public async Task<IActionResult> Delete([FromServices] IDeleteUser userService, int id)
        {
            var user = await _userId.SearchUserIdAsync(id);
            await userService.DeleteAsync(user);

            return this.StatusCode(StatusCodes.Status202Accepted, user);
        }
    }
}
