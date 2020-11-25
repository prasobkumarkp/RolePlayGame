using RolePlayGame.Models;

namespace RolePlayGame.Dtos.Character
{
    public class AddCharacterDto
    {

        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 10;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public CharacterType Type { get; set; } = CharacterType.Knight;
    }
}