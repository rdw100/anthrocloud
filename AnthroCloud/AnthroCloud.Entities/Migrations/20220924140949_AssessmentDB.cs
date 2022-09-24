using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnthroCloud.Entities.Migrations
{
    public partial class AssessmentDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<byte>(type: "tinyint", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    LengthHeight = table.Column<double>(type: "float", nullable: false),
                    DateOfVisit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "DateOfBirth", "FirstName", "LastName", "Sex" },
                values: new object[] { 1, new DateTime(2021, 9, 24, 0, 0, 0, 0, DateTimeKind.Local), "John", "Smith", (byte)0 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "DateOfBirth", "FirstName", "LastName", "Sex" },
                values: new object[] { 2, new DateTime(2020, 9, 24, 0, 0, 0, 0, DateTimeKind.Local), "Olivia", "Diaz", (byte)1 });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "VisitId", "DateOfVisit", "LengthHeight", "PatientId", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), 18.0, 1, 16.0 },
                    { 2, new DateTime(2022, 6, 24, 0, 0, 0, 0, DateTimeKind.Local), 23.0, 1, 20.0 },
                    { 3, new DateTime(2021, 9, 24, 0, 0, 0, 0, DateTimeKind.Local), 25.0, 2, 26.0 },
                    { 4, new DateTime(2021, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 28.0, 2, 32.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
