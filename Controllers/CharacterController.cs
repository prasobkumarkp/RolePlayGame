using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RolePlayGame.Dtos.Character;
using RolePlayGame.Services.CharacterServices;

namespace RolePlayGame.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            this._service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllCharacters());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingle(int Id)
        {
            return Ok(await _service.GetCharacterById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto character)
        {
            return Ok(await _service.AddCharacter(character));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto character)
        {
            var response = await _service.UpdateCharacter(character);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _service.DeleteCharacter(Id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }
    }
}