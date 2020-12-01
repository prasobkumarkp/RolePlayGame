using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RolePlayGame.Data;
using RolePlayGame.Dtos.Character;
using RolePlayGame.Dtos.Weapon;
using RolePlayGame.Models;

namespace RolePlayGame.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WeaponService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._mapper = mapper;
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto weapon)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == weapon.CharacterId &&
                c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

                if (character == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Character not found";
                }
                var newWeapon = new Weapon
                {
                    Name = weapon.Name,
                    Damaga = weapon.Damage,
                    Character = character
                };

                await _context.Weapons.AddAsync(newWeapon);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}