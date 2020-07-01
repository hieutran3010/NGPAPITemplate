using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beke.AdminService.Data.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "pricingplan",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1mc()"),
                    createdon = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "timezone('utc'::text, now())"),
                    createdby = table.Column<string>(type: "citext", nullable: false),
                    modifiedon = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "timezone('utc'::text, now())"),
                    modifiedby = table.Column<string>(type: "citext", nullable: false),
                    name = table.Column<string>(type: "citext", nullable: false),
                    price = table.Column<int>(nullable: false),
                    pricingpackage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pricingplan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenant",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1mc()"),
                    createdon = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "timezone('utc'::text, now())"),
                    createdby = table.Column<string>(type: "citext", nullable: false),
                    modifiedon = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "timezone('utc'::text, now())"),
                    modifiedby = table.Column<string>(type: "citext", nullable: false),
                    brandname = table.Column<string>(type: "citext", nullable: false),
                    registereddate = table.Column<DateTime>(nullable: false),
                    expireddate = table.Column<DateTime>(nullable: true),
                    pricingplanid = table.Column<Guid>(nullable: true),
                    durationmonth = table.Column<int>(nullable: false),
                    paymentstatus = table.Column<int>(nullable: false),
                    owneruserid = table.Column<string>(type: "citext", nullable: false),
                    logo = table.Column<byte[]>(nullable: true),
                    invertlogo = table.Column<byte[]>(nullable: true),
                    islocked = table.Column<bool>(nullable: false),
                    lockreason = table.Column<string>(type: "citext", nullable: true),
                    istrial = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_pricingplan_pricingplanid",
                        column: x => x.pricingplanid,
                        principalTable: "pricingplan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pricingplan_name",
                table: "pricingplan",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_pricingplan_pricingpackage",
                table: "pricingplan",
                column: "pricingpackage",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tenant_brandname",
                table: "tenant",
                column: "brandname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tenant_owneruserid",
                table: "tenant",
                column: "owneruserid");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_pricingplanid",
                table: "tenant",
                column: "pricingplanid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tenant");

            migrationBuilder.DropTable(
                name: "pricingplan");
        }
    }
}
