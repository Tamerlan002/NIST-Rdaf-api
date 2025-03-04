using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using MySql.EntityFrameworkCore.Metadata;
#nullable disable

namespace RDaF.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LCStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LCStages", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Overarches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OverarchingTheme = table.Column<string>(type: "longtext", nullable: true),
                    OTNarrative = table.Column<string>(type: "longtext", nullable: true),
                    StatusFlag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overarches", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PublType = table.Column<string>(type: "longtext", nullable: true),
                    Authors = table.Column<string>(type: "longtext", nullable: true),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    SourceTitle = table.Column<string>(type: "longtext", nullable: true),
                    ISBN = table.Column<string>(type: "longtext", nullable: true),
                    ISSN = table.Column<string>(type: "longtext", nullable: true),
                    DOI = table.Column<string>(type: "longtext", nullable: true),
                    Url = table.Column<string>(type: "longtext", nullable: true),
                    Date = table.Column<string>(type: "longtext", nullable: true),
                    Pages = table.Column<string>(type: "longtext", nullable: true),
                    Issue = table.Column<string>(type: "longtext", nullable: true),
                    JournalAbbr = table.Column<string>(type: "longtext", nullable: true),
                    Publisher = table.Column<string>(type: "longtext", nullable: true),
                    Place = table.Column<string>(type: "longtext", nullable: true),
                    Type = table.Column<string>(type: "longtext", nullable: true),
                    Editor = table.Column<string>(type: "longtext", nullable: true),
                    Edition = table.Column<string>(type: "longtext", nullable: true),
                    ConferenceName = table.Column<string>(type: "longtext", nullable: true),
                    Version = table.Column<string>(type: "longtext", nullable: true),
                    Code = table.Column<string>(type: "longtext", nullable: true),
                    ACSCitation = table.Column<string>(type: "longtext", nullable: true),
                    ChicagoCitation = table.Column<string>(type: "longtext", nullable: true),
                    APACitation = table.Column<string>(type: "longtext", nullable: true),
                    HarvardCitation = table.Column<string>(type: "longtext", nullable: true),
                    StatusFlag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Squib = table.Column<string>(type: "longtext", nullable: true),
                    PublicationTypes = table.Column<int>(type: "int", nullable: false),
                    PublYear = table.Column<string>(type: "longtext", nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    DbKey = table.Column<string>(type: "longtext", nullable: true),
                    Language = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "longtext", nullable: true),
                    StatusFlag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TopicName = table.Column<string>(type: "longtext", nullable: true),
                    Definition = table.Column<string>(type: "longtext", nullable: true),
                    StatusFlag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LCStageId = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_LCStages_LCStageId",
                        column: x => x.LCStageId,
                        principalTable: "LCStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subtopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SubtopicName = table.Column<string>(type: "longtext", nullable: true),
                    SubtopicDefinition = table.Column<string>(type: "longtext", nullable: true),
                    StatusFlag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subtopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OverarchSubtopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OverarchId = table.Column<int>(type: "int", nullable: false),
                    SubtopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverarchSubtopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverarchSubtopics_Overarches_OverarchId",
                        column: x => x.OverarchId,
                        principalTable: "Overarches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OverarchSubtopics_Subtopics_SubtopicId",
                        column: x => x.SubtopicId,
                        principalTable: "Subtopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoleSubtopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    SubtopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleSubtopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleSubtopics_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleSubtopics_Subtopics_SubtopicId",
                        column: x => x.SubtopicId,
                        principalTable: "Subtopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OverarchSubtopics_OverarchId",
                table: "OverarchSubtopics",
                column: "OverarchId");

            migrationBuilder.CreateIndex(
                name: "IX_OverarchSubtopics_SubtopicId",
                table: "OverarchSubtopics",
                column: "SubtopicId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleSubtopics_RoleId",
                table: "RoleSubtopics",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleSubtopics_SubtopicId",
                table: "RoleSubtopics",
                column: "SubtopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtopics_TopicId",
                table: "Subtopics",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_LCStageId",
                table: "Topics",
                column: "LCStageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OverarchSubtopics");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "RoleSubtopics");

            migrationBuilder.DropTable(
                name: "Overarches");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Subtopics");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "LCStages");
        }
    }
}
