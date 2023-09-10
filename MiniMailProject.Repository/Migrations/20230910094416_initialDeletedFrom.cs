using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniMailProject.Repository.Migrations
{
    public partial class initialDeletedFrom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendMail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendMail", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SendMail",
                columns: new[] { "Id", "Body", "CreatedDate", "Subject", "To", "UpdatedDate" },
                values: new object[] { 1, "Seed özelliği denemek için oluşturduğum örnek verinin açıklaması", new DateTime(2023, 9, 10, 12, 44, 16, 436, DateTimeKind.Local).AddTicks(8904), "Seed Özelliği", "sametdikmendev@gmail.com", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendMail");
        }
    }
}
