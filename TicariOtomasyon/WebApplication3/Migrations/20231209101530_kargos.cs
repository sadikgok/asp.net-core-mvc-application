using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    public partial class kargos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "KargoDetays",
                columns: table => new
                {
                    KargoDetayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TakipKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alici = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KargoDetays", x => x.KargoDetayId);
                });

            migrationBuilder.CreateTable(
                name: "kargoTakips",
                columns: table => new
                {
                    KargoTakipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakipKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarihZaman = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kargoTakips", x => x.KargoTakipId);
                });


            migrationBuilder.DropTable(
                name: "KargoDetays");

            migrationBuilder.DropTable(
                name: "kargoTakips");

        }
    }
}
