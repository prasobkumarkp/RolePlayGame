using System.Linq;
using AutoMapper;
using RolePlayGame.Dtos.Character;
using RolePlayGame.Dtos.Skill;
using RolePlayGame.Dtos.Weapon;
using RolePlayGame.Models;

namespace RolePlayGame
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>()
            .ForMember(dtos => dtos.Skills, c => c.MapFrom(c => c.CharacterSkills.Select(cs => cs.Skill)));
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
        }
    }
}