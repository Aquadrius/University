using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    /// <inheritdoc />
    public partial class AddReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    RewiewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewiewName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.RewiewId);
                });

            migrationBuilder.CreateTable(
                name: "LabworkReview",
                columns: table => new
                {
                    LabworkId = table.Column<int>(type: "int", nullable: false),
                    ReviewRewiewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabworkReview", x => new { x.LabworkId, x.ReviewRewiewId });
                    table.ForeignKey(
                        name: "FK_LabworkReview_Labwork_LabworkId",
                        column: x => x.LabworkId,
                        principalTable: "Labwork",
                        principalColumn: "LabworkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabworkReview_Review_ReviewRewiewId",
                        column: x => x.ReviewRewiewId,
                        principalTable: "Review",
                        principalColumn: "RewiewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewStud",
                columns: table => new
                {
                    ReviewRewiewId = table.Column<int>(type: "int", nullable: false),
                    StudId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewStud", x => new { x.ReviewRewiewId, x.StudId });
                    table.ForeignKey(
                        name: "FK_ReviewStud_Review_ReviewRewiewId",
                        column: x => x.ReviewRewiewId,
                        principalTable: "Review",
                        principalColumn: "RewiewId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewStud_Stud_StudId",
                        column: x => x.StudId,
                        principalTable: "Stud",
                        principalColumn: "StudId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabworkReview_ReviewRewiewId",
                table: "LabworkReview",
                column: "ReviewRewiewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewStud_StudId",
                table: "ReviewStud",
                column: "StudId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabworkReview");

            migrationBuilder.DropTable(
                name: "ReviewStud");

            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
