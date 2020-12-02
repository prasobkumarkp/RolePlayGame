using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RolePlayGame.Migrations
{
    public partial class AddedSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Player")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    HitPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Defence = table.Column<int>(type: "INTEGER", nullable: false),
                    Intelligence = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fights = table.Column<int>(type: "INTEGER", nullable: false),
                    Victories = table.Column<int>(type: "INTEGER", nullable: false),
                    Defeats = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => new { x.CharacterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 1, 30, "Fireball" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 2, 20, "Frenzy" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 3, 50, "Blizzard" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 9, 22, 245, 207, 31, 231, 146, 46, 226, 97, 167, 61, 243, 12, 169, 134, 71, 189, 165, 92, 196, 243, 41, 251, 229, 127, 25, 26, 206, 82, 72, 151, 66, 90, 127, 97, 169, 77, 64, 68, 93, 16, 145, 210, 132, 211, 30, 122, 128, 166, 69, 228, 30, 65, 74, 190, 76, 17, 47, 10, 226, 85, 228, 199 }, new byte[] { 139, 154, 62, 46, 166, 147, 229, 131, 60, 5, 160, 176, 180, 43, 233, 57, 200, 104, 119, 133, 214, 246, 98, 168, 185, 165, 39, 196, 106, 193, 162, 201, 203, 198, 227, 152, 26, 92, 164, 204, 222, 245, 114, 25, 222, 123, 100, 29, 184, 148, 102, 251, 123, 118, 24, 155, 232, 71, 111, 103, 100, 102, 176, 34, 92, 229, 40, 210, 243, 70, 171, 110, 145, 122, 113, 170, 173, 7, 185, 148, 25, 146, 140, 36, 90, 121, 145, 194, 143, 144, 92, 209, 229, 58, 4, 69, 14, 248, 129, 114, 99, 120, 45, 115, 175, 128, 194, 218, 62, 62, 53, 145, 104, 204, 237, 246, 43, 26, 91, 146, 0, 191, 63, 12, 76, 106, 230, 93 }, "Flora" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 2, new byte[] { 9, 22, 245, 207, 31, 231, 146, 46, 226, 97, 167, 61, 243, 12, 169, 134, 71, 189, 165, 92, 196, 243, 41, 251, 229, 127, 25, 26, 206, 82, 72, 151, 66, 90, 127, 97, 169, 77, 64, 68, 93, 16, 145, 210, 132, 211, 30, 122, 128, 166, 69, 228, 30, 65, 74, 190, 76, 17, 47, 10, 226, 85, 228, 199 }, new byte[] { 139, 154, 62, 46, 166, 147, 229, 131, 60, 5, 160, 176, 180, 43, 233, 57, 200, 104, 119, 133, 214, 246, 98, 168, 185, 165, 39, 196, 106, 193, 162, 201, 203, 198, 227, 152, 26, 92, 164, 204, 222, 245, 114, 25, 222, 123, 100, 29, 184, 148, 102, 251, 123, 118, 24, 155, 232, 71, 111, 103, 100, 102, 176, 34, 92, 229, 40, 210, 243, 70, 171, 110, 145, 122, 113, 170, 173, 7, 185, 148, 25, 146, 140, 36, 90, 121, 145, 194, 143, 144, 92, 209, 229, 58, 4, 69, 14, 248, 129, 114, 99, 120, 45, 115, 175, 128, 194, 218, 62, 62, 53, 145, 104, 204, 237, 246, 43, 26, 91, 146, 0, 191, 63, 12, 76, 106, 230, 93 }, "Clara" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Defeats", "Defence", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "Type", "UserId", "Victories" },
                values: new object[] { 1, 0, 10, 0, 100, 10, "Frodo", 15, 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Defeats", "Defence", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "Type", "UserId", "Victories" },
                values: new object[] { 2, 0, 5, 0, 100, 20, "Raistlin", 5, 2, 2, 0 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 2, 1, 20, "The Master Sword" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillId",
                table: "CharacterSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
