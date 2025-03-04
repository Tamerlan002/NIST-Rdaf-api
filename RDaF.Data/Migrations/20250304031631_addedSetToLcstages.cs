using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RDaF.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedSetToLcstages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasTopics",
                table: "LCStages",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LifeCycleStage",
                table: "LCStages",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LifeCycleStageDefinition",
                table: "LCStages",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkName",
                table: "LCStages",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StatusFlag",
                table: "LCStages",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasTopics",
                table: "LCStages");

            migrationBuilder.DropColumn(
                name: "LifeCycleStage",
                table: "LCStages");

            migrationBuilder.DropColumn(
                name: "LifeCycleStageDefinition",
                table: "LCStages");

            migrationBuilder.DropColumn(
                name: "LinkName",
                table: "LCStages");

            migrationBuilder.DropColumn(
                name: "StatusFlag",
                table: "LCStages");
        }
    }
}
