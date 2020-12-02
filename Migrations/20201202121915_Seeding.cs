using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RolePlayGame.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[,]
                {
                    { 1, 30, "Fireball" },
                    { 2, 20, "Frenzy" },
                    { 3, 50, "Blizzard" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[,]
                {
                    { 1, new byte[] { 212, 16, 234, 217, 52, 111, 101, 221, 74, 114, 228, 30, 100, 214, 247, 193, 198, 0, 48, 216, 10, 247, 48, 127, 80, 88, 85, 126, 118, 236, 69, 245, 153, 142, 193, 206, 210, 47, 137, 58, 21, 117, 105, 72, 10, 247, 22, 138, 3, 223, 252, 93, 44, 166, 198, 196, 97, 94, 139, 106, 146, 126, 251, 148 }, new byte[] { 110, 30, 123, 128, 36, 2, 233, 6, 4, 144, 233, 199, 123, 188, 136, 66, 218, 206, 188, 25, 179, 159, 166, 40, 89, 198, 204, 17, 190, 126, 43, 245, 105, 246, 220, 145, 115, 205, 182, 238, 13, 83, 58, 158, 177, 175, 22, 66, 105, 167, 171, 64, 198, 187, 47, 156, 11, 23, 40, 161, 126, 221, 136, 178, 88, 91, 167, 54, 245, 70, 229, 82, 212, 192, 164, 64, 63, 94, 26, 211, 134, 35, 104, 11, 6, 65, 148, 137, 91, 121, 236, 185, 128, 185, 178, 156, 43, 54, 36, 171, 14, 172, 165, 118, 18, 109, 153, 110, 188, 187, 130, 195, 243, 23, 39, 59, 132, 44, 1, 157, 128, 157, 85, 44, 119, 122, 138, 246 }, "Flora" },
                    { 2, new byte[] { 212, 16, 234, 217, 52, 111, 101, 221, 74, 114, 228, 30, 100, 214, 247, 193, 198, 0, 48, 216, 10, 247, 48, 127, 80, 88, 85, 126, 118, 236, 69, 245, 153, 142, 193, 206, 210, 47, 137, 58, 21, 117, 105, 72, 10, 247, 22, 138, 3, 223, 252, 93, 44, 166, 198, 196, 97, 94, 139, 106, 146, 126, 251, 148 }, new byte[] { 110, 30, 123, 128, 36, 2, 233, 6, 4, 144, 233, 199, 123, 188, 136, 66, 218, 206, 188, 25, 179, 159, 166, 40, 89, 198, 204, 17, 190, 126, 43, 245, 105, 246, 220, 145, 115, 205, 182, 238, 13, 83, 58, 158, 177, 175, 22, 66, 105, 167, 171, 64, 198, 187, 47, 156, 11, 23, 40, 161, 126, 221, 136, 178, 88, 91, 167, 54, 245, 70, 229, 82, 212, 192, 164, 64, 63, 94, 26, 211, 134, 35, 104, 11, 6, 65, 148, 137, 91, 121, 236, 185, 128, 185, 178, 156, 43, 54, 36, 171, 14, 172, 165, 118, 18, 109, 153, 110, 188, 187, 130, 195, 243, 23, 39, 59, 132, 44, 1, 157, 128, 157, 85, 44, 119, 122, 138, 246 }, "Clara" }
                });

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
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 2, 1, 20, "The Master Sword" });

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
