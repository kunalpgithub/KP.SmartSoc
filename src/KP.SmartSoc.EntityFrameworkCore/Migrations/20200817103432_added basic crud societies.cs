using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.SmartSoc.Migrations
{
    public partial class addedbasiccrudsocieties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Society",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Society", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocietyMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    HouseNo = table.Column<string>(nullable: true),
                    SocietyMemberId = table.Column<Guid>(nullable: true),
                    SocietyId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocietyMember");

            migrationBuilder.DropTable(
                name: "Society");
        }
    }
}
