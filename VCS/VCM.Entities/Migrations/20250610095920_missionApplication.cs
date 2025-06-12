using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VCS.Entities.Migrations
{
    /// <inheritdoc />
    public partial class missionApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MissionAvailability",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "MissionDocuments",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "MissionOrganisationDetail",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "MissionOrganisationName",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "MissionType",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "MissionVideoUrl",
                table: "Missions");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "MissionSkill",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MissionSkill",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "skill_name",
                table: "MissionSkill",
                newName: "SkillName");

            migrationBuilder.CreateTable(
                name: "MissionApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MissionId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Seats = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissionApplication_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionApplication_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionApplication_MissionId",
                table: "MissionApplication",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionApplication_UserId",
                table: "MissionApplication",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionApplication");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "MissionSkill",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MissionSkill",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SkillName",
                table: "MissionSkill",
                newName: "skill_name");

            migrationBuilder.AddColumn<string>(
                name: "MissionAvailability",
                table: "Missions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MissionDocuments",
                table: "Missions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MissionOrganisationDetail",
                table: "Missions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MissionOrganisationName",
                table: "Missions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MissionType",
                table: "Missions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MissionVideoUrl",
                table: "Missions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
