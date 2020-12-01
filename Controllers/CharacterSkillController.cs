using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RolePlayGame.Dtos.CharacterSkill;
using RolePlayGame.Services.CharacterSkillService;

namespace RolePlayGame.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterSkillController : ControllerBase
    {
        private readonly ICharacterSkillService _skillService;
        public CharacterSkillController(ICharacterSkillService skillService)
        {
            this._skillService = skillService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacterSkill(AddCharacterSkillDto characterSkill)
        {
            return Ok(await _skillService.AddCharacterSkill(characterSkill));
        }
    }
}