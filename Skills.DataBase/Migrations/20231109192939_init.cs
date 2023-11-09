using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skills.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "skill_set",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    edit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill_set", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "caharacter",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    build_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    starting_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    story = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    photo_id = table.Column<Guid>(type: "uuid", nullable: true),
                    photo_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    SkillSetId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_caharacter_skill_set_SkillSetId",
                        column: x => x.SkillSetId,
                        principalSchema: "public",
                        principalTable: "skill_set",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    default_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    SkillSetId = table.Column<Guid>(type: "uuid", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    edit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.id);
                    table.ForeignKey(
                        name: "FK_skill_skill_set_SkillSetId",
                        column: x => x.SkillSetId,
                        principalSchema: "public",
                        principalTable: "skill_set",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character_skill",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    skill_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    is_main = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    edit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_skill", x => x.id);
                    table.ForeignKey(
                        name: "FK_character_skill_caharacter_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "public",
                        principalTable: "caharacter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_skill_skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "public",
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skill_levels_data",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    source = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    edit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill_levels_data", x => x.id);
                    table.ForeignKey(
                        name: "FK_skill_levels_data_skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "public",
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_caharacter_photo_id1",
                schema: "public",
                table: "caharacter",
                column: "photo_id1");

            migrationBuilder.CreateIndex(
                name: "IX_caharacter_SkillSetId",
                schema: "public",
                table: "caharacter",
                column: "SkillSetId");

            migrationBuilder.CreateIndex(
                name: "IX_character_skill_CharacterId",
                schema: "public",
                table: "character_skill",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_character_skill_SkillId",
                schema: "public",
                table: "character_skill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_skill_SkillSetId",
                schema: "public",
                table: "skill",
                column: "SkillSetId");

            migrationBuilder.CreateIndex(
                name: "IX_skill_levels_data_SkillId",
                schema: "public",
                table: "skill_levels_data",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "character_skill",
                schema: "public");

            migrationBuilder.DropTable(
                name: "skill_levels_data",
                schema: "public");

            migrationBuilder.DropTable(
                name: "caharacter",
                schema: "public");

            migrationBuilder.DropTable(
                name: "skill",
                schema: "public");

            migrationBuilder.DropTable(
                name: "file_entity",
                schema: "public");

            migrationBuilder.DropTable(
                name: "skill_set",
                schema: "public");
        }
    }
}
