using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AltaTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Point = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, true, "Nguyễn Minh Ý" },
                    { 2, true, "Nguyễn Quốc Đạt" },
                    { 3, false, "Lê Huyền Linh" },
                    { 4, false, "Cao Thanh Tú" },
                    { 5, true, "Lê Bá Dũng" },
                    { 6, false, "Dương Ngọc Vân" },
                    { 7, true, "Trần Trung Hải" },
                    { 8, false, "Đỗ Nguyễn Huyền Trân" },
                    { 9, false, "Lý Thị Xuân" },
                    { 10, true, "Trịnh Công Bình" }
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "DateTime", "PlayerId", "Point" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 600 },
                    { 2, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 500 },
                    { 3, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 200 },
                    { 4, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 200 },
                    { 5, new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 600 },
                    { 6, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 70 },
                    { 7, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 600 },
                    { 8, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 350 },
                    { 9, new DateTime(2024, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 100 },
                    { 10, new DateTime(2024, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 600 },
                    { 11, new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 400 },
                    { 12, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 400 },
                    { 13, new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 300 },
                    { 14, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 400 },
                    { 15, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 100 },
                    { 16, new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 120 },
                    { 17, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 330 },
                    { 18, new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 125 },
                    { 19, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 160 },
                    { 20, new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 500 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Points_PlayerId",
                table: "Points",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
