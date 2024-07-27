using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core.Migrations
{
    /// <inheritdoc />
    public partial class NoneRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_OrgUnits_T_OrgUnits_ParentId",
                table: "T_OrgUnits");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "T_OrgUnits",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_T_OrgUnits_T_OrgUnits_ParentId",
                table: "T_OrgUnits",
                column: "ParentId",
                principalTable: "T_OrgUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_OrgUnits_T_OrgUnits_ParentId",
                table: "T_OrgUnits");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "T_OrgUnits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_T_OrgUnits_T_OrgUnits_ParentId",
                table: "T_OrgUnits",
                column: "ParentId",
                principalTable: "T_OrgUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
