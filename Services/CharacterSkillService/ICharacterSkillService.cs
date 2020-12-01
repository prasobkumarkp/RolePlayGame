using System.Threading.Tasks;
using RolePlayGame.Dtos.Character;
using RolePlayGame.Dtos.CharacterSkill;
using RolePlayGame.Models;

namespace RolePlayGame.Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto characterSkill);
    }
}