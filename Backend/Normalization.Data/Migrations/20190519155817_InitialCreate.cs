using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Normalization.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeCollections",
                columns: table => new
                {
                    PrimaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeCollections", x => x.PrimaryId);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    PrimaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColumnName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.PrimaryId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    PrimaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.PrimaryId);
                });

            migrationBuilder.CreateTable(
                name: "DependencyElements",
                columns: table => new
                {
                    PrimaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeCollectionPrimaryId = table.Column<int>(nullable: true),
                    IsLeft = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependencyElements", x => x.PrimaryId);
                    table.ForeignKey(
                        name: "FK_DependencyElements_AttributeCollections_AttributeCollectionPrimaryId",
                        column: x => x.AttributeCollectionPrimaryId,
                        principalTable: "AttributeCollections",
                        principalColumn: "PrimaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeyGroups",
                columns: table => new
                {
                    PrimaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeCollectionPrimaryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyGroups", x => x.PrimaryId);
                    table.ForeignKey(
                        name: "FK_KeyGroups_AttributeCollections_AttributeCollectionPrimaryId",
                        column: x => x.AttributeCollectionPrimaryId,
                        principalTable: "AttributeCollections",
                        principalColumn: "PrimaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TableAttributes",
                columns: table => new
                {
                    PrimaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TableId = table.Column<int>(nullable: false),
                    AttributeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAttributes", x => x.PrimaryId);
                    table.ForeignKey(
                        name: "FK_TableAttributes_Tables_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Tables",
                        principalColumn: "PrimaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableAttributes_Attributes_TableId",
                        column: x => x.TableId,
                        principalTable: "Attributes",
                        principalColumn: "PrimaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunctionalDependencies",
                columns: table => new
                {
                    PrimaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DependencyElementPrimaryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalDependencies", x => x.PrimaryId);
                    table.ForeignKey(
                        name: "FK_FunctionalDependencies_DependencyElements_DependencyElementPrimaryId",
                        column: x => x.DependencyElementPrimaryId,
                        principalTable: "DependencyElements",
                        principalColumn: "PrimaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TableAttributeCollections",
                columns: table => new
                {
                    PrimaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeCollectionId = table.Column<int>(nullable: false),
                    TableAttributeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAttributeCollections", x => x.PrimaryId);
                    table.ForeignKey(
                        name: "FK_TableAttributeCollections_AttributeCollections_AttributeCollectionId",
                        column: x => x.AttributeCollectionId,
                        principalTable: "AttributeCollections",
                        principalColumn: "PrimaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableAttributeCollections_TableAttributes_TableAttributeId",
                        column: x => x.TableAttributeId,
                        principalTable: "TableAttributes",
                        principalColumn: "PrimaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DependencyElements_AttributeCollectionPrimaryId",
                table: "DependencyElements",
                column: "AttributeCollectionPrimaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionalDependencies_DependencyElementPrimaryId",
                table: "FunctionalDependencies",
                column: "DependencyElementPrimaryId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyGroups_AttributeCollectionPrimaryId",
                table: "KeyGroups",
                column: "AttributeCollectionPrimaryId");

            migrationBuilder.CreateIndex(
                name: "IX_TableAttributeCollections_AttributeCollectionId",
                table: "TableAttributeCollections",
                column: "AttributeCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TableAttributeCollections_TableAttributeId",
                table: "TableAttributeCollections",
                column: "TableAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_TableAttributes_AttributeId",
                table: "TableAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_TableAttributes_TableId",
                table: "TableAttributes",
                column: "TableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FunctionalDependencies");

            migrationBuilder.DropTable(
                name: "KeyGroups");

            migrationBuilder.DropTable(
                name: "TableAttributeCollections");

            migrationBuilder.DropTable(
                name: "DependencyElements");

            migrationBuilder.DropTable(
                name: "TableAttributes");

            migrationBuilder.DropTable(
                name: "AttributeCollections");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Attributes");
        }
    }
}
