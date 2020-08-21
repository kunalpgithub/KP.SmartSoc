using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.SmartSoc.Migrations
{
    public partial class ExtendingentityTenanttoSocietyUsertoSocietyMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Building",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNo",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParkingId",
                table: "AbpUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankDetail",
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
                    Name = table.Column<string>(nullable: true),
                    IFSCCode = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    UpiId = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDetail_AbpTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
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
                    ParkingNo = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parking_AbpTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parking_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDetail_TenantId",
                table: "BankDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_TenantId",
                table: "Parking",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_UserId",
                table: "Parking",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDetail");

            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropColumn(
                name: "Building",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "HouseNo",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ParkingId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "AbpTenants");
        }
    }
}
