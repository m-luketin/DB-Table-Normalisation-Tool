using Microsoft.EntityFrameworkCore.Migrations;

namespace Normalization.Data.Migrations
{
    public partial class functional_typo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DependencyElements_FunctionalDependencies_FunctionalDependenciesPrimaryId",
                table: "DependencyElements");

            migrationBuilder.RenameColumn(
                name: "FunctionalDependenciesPrimaryId",
                table: "DependencyElements",
                newName: "FunctionalDependencyPrimaryId");

            migrationBuilder.RenameIndex(
                name: "IX_DependencyElements_FunctionalDependenciesPrimaryId",
                table: "DependencyElements",
                newName: "IX_DependencyElements_FunctionalDependencyPrimaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DependencyElements_FunctionalDependencies_FunctionalDependencyPrimaryId",
                table: "DependencyElements",
                column: "FunctionalDependencyPrimaryId",
                principalTable: "FunctionalDependencies",
                principalColumn: "PrimaryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DependencyElements_FunctionalDependencies_FunctionalDependencyPrimaryId",
                table: "DependencyElements");

            migrationBuilder.RenameColumn(
                name: "FunctionalDependencyPrimaryId",
                table: "DependencyElements",
                newName: "FunctionalDependenciesPrimaryId");

            migrationBuilder.RenameIndex(
                name: "IX_DependencyElements_FunctionalDependencyPrimaryId",
                table: "DependencyElements",
                newName: "IX_DependencyElements_FunctionalDependenciesPrimaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DependencyElements_FunctionalDependencies_FunctionalDependenciesPrimaryId",
                table: "DependencyElements",
                column: "FunctionalDependenciesPrimaryId",
                principalTable: "FunctionalDependencies",
                principalColumn: "PrimaryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
