using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Normalization.Data.Migrations
{
    public partial class InitalCreateSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeCollections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeCollections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColumnName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FunctionalDependencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalDependencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeyGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeCollectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyGroups_AttributeCollections_AttributeCollectionId",
                        column: x => x.AttributeCollectionId,
                        principalTable: "AttributeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DependencyElements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeCollectionId = table.Column<int>(nullable: false),
                    FunctionalDependencyId = table.Column<int>(nullable: false),
                    IsLeft = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependencyElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependencyElements_AttributeCollections_AttributeCollectionId",
                        column: x => x.AttributeCollectionId,
                        principalTable: "AttributeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DependencyElements_FunctionalDependencies_FunctionalDependencyId",
                        column: x => x.FunctionalDependencyId,
                        principalTable: "FunctionalDependencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TableId = table.Column<int>(nullable: false),
                    AttributeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableAttributes_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableAttributeCollections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeCollectionId = table.Column<int>(nullable: false),
                    TableAttributeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAttributeCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableAttributeCollections_AttributeCollections_AttributeCollectionId",
                        column: x => x.AttributeCollectionId,
                        principalTable: "AttributeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableAttributeCollections_TableAttributes_TableAttributeId",
                        column: x => x.TableAttributeId,
                        principalTable: "TableAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DependencyElements_AttributeCollectionId",
                table: "DependencyElements",
                column: "AttributeCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DependencyElements_FunctionalDependencyId",
                table: "DependencyElements",
                column: "FunctionalDependencyId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyGroups_AttributeCollectionId",
                table: "KeyGroups",
                column: "AttributeCollectionId");

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
                name: "DependencyElements");

            migrationBuilder.DropTable(
                name: "KeyGroups");

            migrationBuilder.DropTable(
                name: "TableAttributeCollections");

            migrationBuilder.DropTable(
                name: "FunctionalDependencies");

            migrationBuilder.DropTable(
                name: "AttributeCollections");

            migrationBuilder.DropTable(
                name: "TableAttributes");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
