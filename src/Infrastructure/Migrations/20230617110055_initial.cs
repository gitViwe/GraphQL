using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OverwatchDeployments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CombatMapId = table.Column<int>(type: "integer", nullable: false),
                    GameModeId = table.Column<int>(type: "integer", nullable: false),
                    SuperHeroId = table.Column<int>(type: "integer", nullable: false),
                    DeployedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeployedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchDeployments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OverwatchMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Screenshot = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchMaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OverwatchMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OverwatchSuperHeroHitpoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Health = table.Column<int>(type: "integer", nullable: false),
                    Armor = table.Column<int>(type: "integer", nullable: false),
                    Shields = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchSuperHeroHitpoint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OverwatchSuperHeroLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mp4 = table.Column<string>(type: "text", nullable: false),
                    Webm = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchSuperHeroLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OverwatchSuperHeroRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchSuperHeroRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OverwatchMode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Screenshot = table.Column<string>(type: "text", nullable: false),
                    OverwatchCombatMapId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchMode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverwatchMode_OverwatchMaps_OverwatchCombatMapId",
                        column: x => x.OverwatchCombatMapId,
                        principalTable: "OverwatchMaps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OverwatchSuperHeroStory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    MediaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchSuperHeroStory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverwatchSuperHeroStory_OverwatchMedia_MediaId",
                        column: x => x.MediaId,
                        principalTable: "OverwatchMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OverwatchSuperHeroVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Thumbnail = table.Column<string>(type: "text", nullable: false),
                    LinkId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchSuperHeroVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverwatchSuperHeroVideo_OverwatchSuperHeroLink_LinkId",
                        column: x => x.LinkId,
                        principalTable: "OverwatchSuperHeroLink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OverwatchSuperHeroChapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: false),
                    OverwatchSuperHeroStoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchSuperHeroChapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverwatchSuperHeroChapter_OverwatchSuperHeroStory_Overwatch~",
                        column: x => x.OverwatchSuperHeroStoryId,
                        principalTable: "OverwatchSuperHeroStory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OverwatchSuperHeroDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Portrait = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    HitpointsId = table.Column<int>(type: "integer", nullable: false),
                    StoryId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchSuperHeroDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverwatchSuperHeroDetail_OverwatchSuperHeroHitpoint_Hitpoin~",
                        column: x => x.HitpointsId,
                        principalTable: "OverwatchSuperHeroHitpoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OverwatchSuperHeroDetail_OverwatchSuperHeroRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OverwatchSuperHeroRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OverwatchSuperHeroDetail_OverwatchSuperHeroStory_StoryId",
                        column: x => x.StoryId,
                        principalTable: "OverwatchSuperHeroStory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OverwatchSuperHeroAbility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    VideoId = table.Column<int>(type: "integer", nullable: false),
                    OverwatchSuperHeroDetailId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchSuperHeroAbility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverwatchSuperHeroAbility_OverwatchSuperHeroDetail_Overwatc~",
                        column: x => x.OverwatchSuperHeroDetailId,
                        principalTable: "OverwatchSuperHeroDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OverwatchSuperHeroAbility_OverwatchSuperHeroVideo_VideoId",
                        column: x => x.VideoId,
                        principalTable: "OverwatchSuperHeroVideo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OverwatchSuperHeroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Portrait = table.Column<string>(type: "text", nullable: false),
                    DetailId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverwatchSuperHeroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverwatchSuperHeroes_OverwatchSuperHeroDetail_DetailId",
                        column: x => x.DetailId,
                        principalTable: "OverwatchSuperHeroDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OverwatchMode_OverwatchCombatMapId",
                table: "OverwatchMode",
                column: "OverwatchCombatMapId");

            migrationBuilder.CreateIndex(
                name: "IX_OverwatchSuperHeroAbility_OverwatchSuperHeroDetailId",
                table: "OverwatchSuperHeroAbility",
                column: "OverwatchSuperHeroDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OverwatchSuperHeroAbility_VideoId",
                table: "OverwatchSuperHeroAbility",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_OverwatchSuperHeroChapter_OverwatchSuperHeroStoryId",
                table: "OverwatchSuperHeroChapter",
                column: "OverwatchSuperHeroStoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OverwatchSuperHeroDetail_HitpointsId",
                table: "OverwatchSuperHeroDetail",
                column: "HitpointsId");

            migrationBuilder.CreateIndex(
                name: "IX_OverwatchSuperHeroDetail_RoleId",
                table: "OverwatchSuperHeroDetail",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OverwatchSuperHeroDetail_StoryId",
                table: "OverwatchSuperHeroDetail",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OverwatchSuperHeroes_DetailId",
                table: "OverwatchSuperHeroes",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OverwatchSuperHeroStory_MediaId",
                table: "OverwatchSuperHeroStory",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_OverwatchSuperHeroVideo_LinkId",
                table: "OverwatchSuperHeroVideo",
                column: "LinkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OverwatchDeployments");

            migrationBuilder.DropTable(
                name: "OverwatchMode");

            migrationBuilder.DropTable(
                name: "OverwatchSuperHeroAbility");

            migrationBuilder.DropTable(
                name: "OverwatchSuperHeroChapter");

            migrationBuilder.DropTable(
                name: "OverwatchSuperHeroes");

            migrationBuilder.DropTable(
                name: "OverwatchMaps");

            migrationBuilder.DropTable(
                name: "OverwatchSuperHeroVideo");

            migrationBuilder.DropTable(
                name: "OverwatchSuperHeroDetail");

            migrationBuilder.DropTable(
                name: "OverwatchSuperHeroLink");

            migrationBuilder.DropTable(
                name: "OverwatchSuperHeroHitpoint");

            migrationBuilder.DropTable(
                name: "OverwatchSuperHeroRole");

            migrationBuilder.DropTable(
                name: "OverwatchSuperHeroStory");

            migrationBuilder.DropTable(
                name: "OverwatchMedia");
        }
    }
}
