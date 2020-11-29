using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolePlayGame.Data;
using RolePlayGame.Dtos.User;
using RolePlayGame.Models;

namespace RolePlayGame.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            this._authRepo = authRepo;
        }

        [HttpPost()]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(new User { Username = request.Username }, request.Password);
            if (!response.IsSuccess)
                return BadRequest(response.Message);
            return Ok(response);
        }

        [HttpPost()]
        public async Task<IActionResult> Login(UserloginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);
            if (!response.IsSuccess)
                return BadRequest(response.Message);
            return Ok(response);
        }
    }
}