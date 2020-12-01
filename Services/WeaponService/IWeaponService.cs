using System.Threading.Tasks;
using RolePlayGame.Dtos.Character;
using RolePlayGame.Dtos.Weapon;
using RolePlayGame.Models;

namespace RolePlayGame.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto weapon);
    }
}