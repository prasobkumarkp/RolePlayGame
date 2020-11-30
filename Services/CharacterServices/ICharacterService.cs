using System.Collections.Generic;
using System.Threading.Tasks;
using RolePlayGame.Dtos.Character;
using RolePlayGame.Models;

namespace RolePlayGame.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters(int userId);
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int Id);
    }
}