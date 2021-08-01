using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ExpensesApp.Server.Data.Migrations
{
    public partial class OperrationTypeAndOwnerAccountingPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id_operation",
                table: "operations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "id_operation_owner",
                table: "operations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_operation_type",
                table: "operations",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "AspNetUserClaims",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "AspNetRoleClaims",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "accounting_periods",
                columns: table => new
                {
                    id_accounting_period = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    creation_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    start_date_inclusive = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date_exclusive = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounting_periods", x => x.id_accounting_period);
                });

            migrationBuilder.CreateTable(
                name: "operation_owners",
                columns: table => new
                {
                    id_operation_owner = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    owner = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_operation_owners", x => x.id_operation_owner);
                });

            migrationBuilder.CreateTable(
                name: "operation_types",
                columns: table => new
                {
                    id_operation_type = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    type = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_operation_types", x => x.id_operation_type);
                });

            migrationBuilder.CreateIndex(
                name: "ix_operations_id_operation_owner",
                table: "operations",
                column: "id_operation_owner");

            migrationBuilder.CreateIndex(
                name: "ix_operations_id_operation_type",
                table: "operations",
                column: "id_operation_type");

            migrationBuilder.AddForeignKey(
                name: "fk_operations_operation_owners_id_operation_owner",
                table: "operations",
                column: "id_operation_owner",
                principalTable: "operation_owners",
                principalColumn: "id_operation_owner",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_operations_operation_types_id_operation_type",
                table: "operations",
                column: "id_operation_type",
                principalTable: "operation_types",
                principalColumn: "id_operation_type",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_operations_operation_owners_id_operation_owner",
                table: "operations");

            migrationBuilder.DropForeignKey(
                name: "fk_operations_operation_types_id_operation_type",
                table: "operations");

            migrationBuilder.DropTable(
                name: "accounting_periods");

            migrationBuilder.DropTable(
                name: "operation_owners");

            migrationBuilder.DropTable(
                name: "operation_types");

            migrationBuilder.DropIndex(
                name: "ix_operations_id_operation_owner",
                table: "operations");

            migrationBuilder.DropIndex(
                name: "ix_operations_id_operation_type",
                table: "operations");

            migrationBuilder.DropColumn(
                name: "id_operation_owner",
                table: "operations");

            migrationBuilder.DropColumn(
                name: "id_operation_type",
                table: "operations");

            migrationBuilder.AlterColumn<int>(
                name: "id_operation",
                table: "operations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "AspNetUserClaims",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "AspNetRoleClaims",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);
        }
    }
}
