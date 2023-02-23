using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission08_4_6.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quadrants",
                columns: table => new
                {
                    QuadrantID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuadrantName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadrants", x => x.QuadrantID);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskName = table.Column<string>(nullable: false),
                    DueDate = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    QuadrantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Responses_Quadrants_QuadrantID",
                        column: x => x.QuadrantID,
                        principalTable: "Quadrants",
                        principalColumn: "QuadrantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantID", "QuadrantName" },
                values: new object[] { 1, "Quadrant I: Important / Urgent" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantID", "QuadrantName" },
                values: new object[] { 2, "Quadrant II: Important / Not Urgent" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantID", "QuadrantName" },
                values: new object[] { 3, "Quadrant III: Not Important / Urgent" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantID", "QuadrantName" },
                values: new object[] { 4, "Quadrant IV: Not Important / Not Urgent" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "Category", "Completed", "DueDate", "QuadrantID", "TaskName" },
                values: new object[] { 1, "School", false, "1/1/2023", 1, "Homework" });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuadrantID",
                table: "Responses",
                column: "QuadrantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Quadrants");
        }
    }
}
