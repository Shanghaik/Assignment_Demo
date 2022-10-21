using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Giohang",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IDKhach = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giohang", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Giatien = table.Column<decimal>(type: "decimal", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiohangChitiet",
                columns: table => new
                {
                    IDSanpham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDGiohang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Soluong = table.Column<decimal>(type: "Decimal", nullable: false),
                    Giatien = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiohangChitiet", x => new { x.IDGiohang, x.IDSanpham });
                    table.ForeignKey(
                        name: "FK_Giohang",
                        column: x => x.IDGiohang,
                        principalTable: "Giohang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sanpham",
                        column: x => x.IDSanpham,
                        principalTable: "Sanpham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiohangChitiet_IDSanpham",
                table: "GiohangChitiet",
                column: "IDSanpham");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiohangChitiet");

            migrationBuilder.DropTable(
                name: "Giohang");

            migrationBuilder.DropTable(
                name: "Sanpham");
        }
    }
}
