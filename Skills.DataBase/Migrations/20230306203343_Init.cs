using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skills.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "file_entity",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    edit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file_entity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "caharacter",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    build_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    starting_date = table.Column<DateOnly>(type: "date", nullable: false),
                    story = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    photo_id = table.Column<Guid>(type: "uuid", nullable: true),
                    photo_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    edit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caharacter", x => x.id);
                    table.ForeignKey(
                        name: "FK_caharacter_file_entity_photo_id1",
                        column: x => x.photo_id1,
                        principalSchema: "public",
                        principalTable: "file_entity",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "skill",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    skill_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    CahracterId = table.Column<Guid>(type: "uuid", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: true),
                    image_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    is_main = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    edit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.id);
                    table.ForeignKey(
                        name: "FK_skill_caharacter_CahracterId",
                        column: x => x.CahracterId,
                        principalSchema: "public",
                        principalTable: "caharacter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skill_file_entity_image_id1",
                        column: x => x.image_id1,
                        principalSchema: "public",
                        principalTable: "file_entity",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_caharacter_photo_id1",
                schema: "public",
                table: "caharacter",
                column: "photo_id1");

            migrationBuilder.CreateIndex(
                name: "IX_skill_CahracterId",
                schema: "public",
                table: "skill",
                column: "CahracterId");

            migrationBuilder.CreateIndex(
                name: "IX_skill_image_id1",
                schema: "public",
                table: "skill",
                column: "image_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "skill",
                schema: "public");

            migrationBuilder.DropTable(
                name: "caharacter",
                schema: "public");

            migrationBuilder.DropTable(
                name: "file_entity",
                schema: "public");
        }
    }
}
