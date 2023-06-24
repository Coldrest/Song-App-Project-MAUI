using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veri.Migrations
{
    public partial class sarki_eklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sarkı",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SarkıAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sarkıcı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sure = table.Column<double>(type: "float", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sarkı", x => x.Id);
                });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sarkı");
        }
    }
}
