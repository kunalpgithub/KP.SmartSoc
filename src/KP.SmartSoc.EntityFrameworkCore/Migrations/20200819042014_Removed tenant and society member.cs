using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.SmartSoc.Migrations
{
    public partial class Removedtenantandsocietymember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocietyMember");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Society");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Society",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SocietyMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietyMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocietyMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocietyMember_Society_SocietyMemberId",
                        column: x => x.SocietyMemberId,
                        principalTable: "Society",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocietyMember_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocietyMember_SocietyMemberId",
                table: "SocietyMember",
                column: "SocietyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SocietyMember_UserId",
                table: "SocietyMember",
                column: "UserId");
        }
    }
}
