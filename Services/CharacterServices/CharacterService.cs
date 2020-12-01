using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RolePlayGame.Data;
using RolePlayGame.Dtos.Character;
using RolePlayGame.Models;

namespace RolePlayGame.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._mapper = mapper;
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var newCharacter = _mapper.Map<Character>(character);
            newCharacter.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            await _context.AddAsync(newCharacter);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Characters.Where(c => c.Id == GetUserId()).Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.Where(c => c.User.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacters = await _context.Characters
            .Include(c => c.Weapon)
            .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
            .FirstOrDefaultAsync(c => c.Id == Id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacters);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == updateCharacterDto.Id);
                if (character.User.Id == GetUserId())
                {
                    character.Name = updateCharacterDto.Name;
                    character.Type = updateCharacterDto.Type;
                    character.Defence = updateCharacterDto.Defence;
                    character.HitPoints = updateCharacterDto.HitPoints;
                    character.Intelligence = updateCharacterDto.Intelligence;
                    character.Strength = updateCharacterDto.Strength;
                    serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                    _context.Characters.Update(character);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Character not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == Id && c.User.Id == GetUserId());
                if (character != null)
                {
                    _context.Characters.Remove(character);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.Characters.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Character not found";
                }

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