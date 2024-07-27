using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core.Migrations
{
    /// <inheritdoc />
    public partial class SelfReferenSturct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_OrgUnits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OrgUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_OrgUnits_T_OrgUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "T_OrgUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    ApproverId = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Leaves_T_Users_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "T_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Leaves_T_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "T_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_T_Leaves_ApproverId",
                table: "T_Leaves",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Leaves_RequesterId",
                table: "T_Leaves",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_T_OrgUnits_ParentId",
                table: "T_OrgUnits",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Leaves");

            migrationBuilder.DropTable(
                name: "T_OrgUnits");

            migrationBuilder.DropTable(
                name: "T_Users");
        }
    }
}
