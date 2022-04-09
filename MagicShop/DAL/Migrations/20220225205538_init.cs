using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveEffect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessoriesType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<long>(type: "bigint", nullable: false),
                    Agility = table.Column<long>(type: "bigint", nullable: false),
                    Endurance = table.Column<long>(type: "bigint", nullable: false),
                    Intelligence = table.Column<long>(type: "bigint", nullable: false),
                    CriticalDamage = table.Column<long>(type: "bigint", nullable: false),
                    Speed = table.Column<long>(type: "bigint", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Armor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmorMaterialType = table.Column<int>(type: "int", nullable: false),
                    ArmorType = table.Column<int>(type: "int", nullable: false),
                    Protection = table.Column<int>(type: "int", nullable: false),
                    PhysicalRezist = table.Column<int>(type: "int", nullable: false),
                    MagicRezist = table.Column<int>(type: "int", nullable: false),
                    FireRezist = table.Column<int>(type: "int", nullable: false),
                    IceRezist = table.Column<int>(type: "int", nullable: false),
                    PoisonRezist = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<long>(type: "bigint", nullable: false),
                    Agility = table.Column<long>(type: "bigint", nullable: false),
                    Endurance = table.Column<long>(type: "bigint", nullable: false),
                    Intelligence = table.Column<long>(type: "bigint", nullable: false),
                    CriticalDamage = table.Column<long>(type: "bigint", nullable: false),
                    Speed = table.Column<long>(type: "bigint", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MagicWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MagicWeaponType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<long>(type: "bigint", nullable: false),
                    Agility = table.Column<long>(type: "bigint", nullable: false),
                    Endurance = table.Column<long>(type: "bigint", nullable: false),
                    Intelligence = table.Column<long>(type: "bigint", nullable: false),
                    CriticalDamage = table.Column<long>(type: "bigint", nullable: false),
                    Speed = table.Column<long>(type: "bigint", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    DamageType = table.Column<int>(type: "int", nullable: false),
                    HandWeaponType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicWeapon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeleeWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeleeWeaponType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<long>(type: "bigint", nullable: false),
                    Agility = table.Column<long>(type: "bigint", nullable: false),
                    Endurance = table.Column<long>(type: "bigint", nullable: false),
                    Intelligence = table.Column<long>(type: "bigint", nullable: false),
                    CriticalDamage = table.Column<long>(type: "bigint", nullable: false),
                    Speed = table.Column<long>(type: "bigint", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    DamageType = table.Column<int>(type: "int", nullable: false),
                    HandWeaponType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeleeWeapon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangeWeaponType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<long>(type: "bigint", nullable: false),
                    Agility = table.Column<long>(type: "bigint", nullable: false),
                    Endurance = table.Column<long>(type: "bigint", nullable: false),
                    Intelligence = table.Column<long>(type: "bigint", nullable: false),
                    CriticalDamage = table.Column<long>(type: "bigint", nullable: false),
                    Speed = table.Column<long>(type: "bigint", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    DamageType = table.Column<int>(type: "int", nullable: false),
                    HandWeaponType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeWeapon", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Armor");

            migrationBuilder.DropTable(
                name: "MagicWeapon");

            migrationBuilder.DropTable(
                name: "MeleeWeapon");

            migrationBuilder.DropTable(
                name: "RangeWeapon");
        }
    }
}
