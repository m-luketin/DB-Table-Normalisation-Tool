using Microsoft.EntityFrameworkCore.Migrations;

namespace Normalization.Data.Migrations
{
    public partial class fixing_functional_dependecies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FunctionalDependencies_DependencyElements_DependencyElementPrimaryId",
                table: "FunctionalDependencies");

            migrationBuilder.DropIndex(
                name: "IX_FunctionalDependencies_DependencyElementPrimaryId",
                table: "FunctionalDependencies");

            migrationBuilder.DropColumn(
                name: "DependencyElementPrimaryId",
                table: "FunctionalDependencies");

            migrationBuilder.AddColumn<int>(
                name: "FunctionalDependenciesPrimaryId",
                table: "DependencyElements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DependencyElements_FunctionalDependenciesPrimaryId",
                table: "DependencyElements",
                column: "FunctionalDependenciesPrimaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DependencyElements_FunctionalDependencies_FunctionalDependenciesPrimaryId",
                table: "DependencyElements",
                column: "FunctionalDependenciesPrimaryId",
                principalTable: "FunctionalDependencies",
                principalColumn: "PrimaryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DependencyElements_FunctionalDependencies_FunctionalDependenciesPrimaryId",
                table: "DependencyElements");

            migrationBuilder.DropIndex(
                name: "IX_DependencyElements_FunctionalDependenciesPrimaryId",
                table: "DependencyElements");

            migrationBuilder.DropColumn(
                name: "FunctionalDependenciesPrimaryId",
                table: "DependencyElements");

            migrationBuilder.AddColumn<int>(
                name: "DependencyElementPrimaryId",
                table: "FunctionalDependencies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FunctionalDependencies_DependencyElementPrimaryId",
                table: "FunctionalDependencies",
                column: "DependencyElementPrimaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FunctionalDependencies_DependencyElements_DependencyElementPrimaryId",
                table: "FunctionalDependencies",
                column: "DependencyElementPrimaryId",
                principalTable: "DependencyElements",
                principalColumn: "PrimaryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
