using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnthroCloud.Entities.Migrations
{
    public partial class AssessmentDB_Visit_New_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                columns: new[] { "HeadCircumference", "MUAC", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { 38.899999999999999, 11.199999999999999, 4.5999999999999996, 5.5 });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                columns: new[] { "HeadCircumference", "MUAC", "Oedema", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { 40.299999999999997, 11.4, (byte)0, 4.4000000000000004, 5.2000000000000002 });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                columns: new[] { "HeadCircumference", "MUAC", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { 41.600000000000001, 11.5, 4.0999999999999996, 4.7999999999999998 });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 4,
                columns: new[] { "HeadCircumference", "MUAC", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { 42.700000000000003, 11.6, 3.8999999999999999, 4.5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                columns: new[] { "HeadCircumference", "MUAC", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { 45.0, 15.0, 7.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                columns: new[] { "HeadCircumference", "MUAC", "Oedema", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { 45.0, 15.0, (byte)1, 7.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                columns: new[] { "HeadCircumference", "MUAC", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { 45.0, 15.0, 7.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 4,
                columns: new[] { "HeadCircumference", "MUAC", "SubscapularSkinFold", "TricepsSkinFold" },
                values: new object[] { 45.0, 15.0, 7.0, 8.0 });
        }
    }
}
