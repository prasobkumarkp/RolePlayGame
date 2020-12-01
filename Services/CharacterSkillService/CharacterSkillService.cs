using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RolePlayGame.Data;
using RolePlayGame.Dtos.Character;
using RolePlayGame.Dtos.CharacterSkill;
using RolePlayGame.Models;

namespace RolePlayGame.Services.CharacterSkillService
{
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterSkillService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._mapper = mapper;
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto characterSkill)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters
                .Include(c => c.Weapon)
                .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                .FirstOrDefaultAsync(c => c.Id == characterSkill.CharacterId &&
                c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

                if (character == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Character not found";
                    return serviceResponse;
                }

                var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == characterSkill.SkillId);
                if (skill == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Skill not found";
                }

                var newCharacterSkill = new CharacterSkill
                {
                    Character = character,
                    Skill = skill
                };
                await _context.CharacterSkills.AddAsync(newCharacterSkill);
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