using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolePlayGame.Dtos.Fight;
using RolePlayGame.Services.FightService;

namespace RolePlayGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;
        public FightController(IFightService fightService)
        {
            this._fightService = fightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHighScore()
        {
            return Ok(await _fightService.GetHighScore());
        }

        [HttpPost]
        public async Task<IActionResult> Fight(FightRequestDto request)
        {
            return Ok(await _fightService.Fight(request));
        }

        [HttpPost("Weapon")]
        public async Task<IActionResult> WeaponAttack(WeaponAttackDto request)
        {
            return Ok(await _fightService.WeaponAttack(request));
        }

        [HttpPost("Skill")]
        public async Task<IActionResult> SkillAttack(SkillAttackDto request)
        {
            return Ok(await _fightService.SkillAttack(request));
        }

    }
}