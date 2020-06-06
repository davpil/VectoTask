using Microsoft.EntityFrameworkCore.Migrations;

namespace VectoTask.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Toures_TourId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TourId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toures",
                table: "Toures");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Toures",
                newName: "Tours");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tours",
                table: "Tours",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TourCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    TourId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourCategories_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourCategories_CategoryId",
                table: "TourCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TourCategories_TourId",
                table: "TourCategories",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tours",
                table: "Tours");

            migrationBuilder.RenameTable(
                name: "Tours",
                newName: "Toures");

            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toures",
                table: "Toures",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TourId",
                table: "Categories",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Toures_TourId",
                table: "Categories",
                column: "TourId",
                principalTable: "Toures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
