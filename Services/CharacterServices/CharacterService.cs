using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public CharacterService(IMapper mapper, DataContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            await _context.AddAsync(_mapper.Map<Character>(character));
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters(int userId)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.Where(c => c.User.Id == userId).ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacters = await _context.Characters.FirstOrDefaultAsync(c => c.Id == Id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacters);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updateCharacterDto.Id);
                character.Name = updateCharacterDto.Name;
                character.Type = updateCharacterDto.Type;
                character.Defence = updateCharacterDto.Defence;
                character.HitPoints = updateCharacterDto.HitPoints;
                character.Intelligence = updateCharacterDto.Intelligence;
                character.Strength = updateCharacterDto.Strength;
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                _context.Characters.Update(character);
                await _context.SaveChangesAsync();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                var character = await _context.Characters.FirstAsync(c => c.Id == Id);
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
    }
}