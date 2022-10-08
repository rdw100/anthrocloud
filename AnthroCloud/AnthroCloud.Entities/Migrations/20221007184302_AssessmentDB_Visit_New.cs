using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnthroCloud.Entities.Migrations
{
    public partial class AssessmentDB_Visit_New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HeadCircumference",
                table: "Visits",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MUAC",
                table: "Visits",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Measured",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Oedema",
                table: "Visits",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<double>(
                name: "SubscapularSkinFold",
                table: "Visits",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TricepsSkinFold",
                table: "Visits",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2021, 10, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "FirstName" },
                values: new object[] { new DateTime(2020, 10, 7, 0, 0, 0, 0, DateTimeKind.Local), "Juana" });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                columns: new[] { "DateOfVisit", "HeadCircumference", "MUAC", "Measured", "Oedema", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), 45.0, 15.0, 1, (byte)1, 7.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                columns: new[] { "DateOfVisit", "HeadCircumference", "MUAC", "Measured", "Oedema", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), 45.0, 15.0, 1, (byte)1, 7.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                columns: new[] { "DateOfVisit", "HeadCircumference", "MUAC", "Measured", "Oedema", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { new DateTime(2021, 10, 7, 0, 0, 0, 0, DateTimeKind.Local), 45.0, 15.0, 1, (byte)1, 7.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 4,
                columns: new[] { "DateOfVisit", "HeadCircumference", "MUAC", "Measured", "Oedema", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { new DateTime(2021, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), 45.0, 15.0, 1, (byte)1, 7.0, 8.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadCircumference",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "MUAC",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Measured",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Oedema",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "SubscapularSkinFold",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "TricepsSkinFold",
                table: "Visits");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2021, 9, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "FirstName" },
                values: new object[] { new DateTime(2020, 9, 24, 0, 0, 0, 0, DateTimeKind.Local), "Olivia" });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "DateOfVisit",
                value: new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "DateOfVisit",
                value: new DateTime(2022, 6, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "DateOfVisit",
                value: new DateTime(2021, 9, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 4,
                column: "DateOfVisit",
                value: new DateTime(2021, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
