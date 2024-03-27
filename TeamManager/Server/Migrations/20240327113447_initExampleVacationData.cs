using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamManager.Server.Migrations
{
    public partial class initExampleVacationData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VacationBalances",
                columns: new[] { "VacationBalanceId", "RemainingBalance", "TotalBalance", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, 7, 20, 1, 2024 },
                    { 2, 15, 25, 2, 2024 },
                    { 3, 35, 35, 3, 2024 }
                });

            migrationBuilder.InsertData(
                table: "VacationRequests",
                columns: new[] { "VacationRequestId", "EndDate", "Reason", "StartDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacation trip", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", 1 },
                    { 2, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family vacation", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VacationBalances",
                keyColumn: "VacationBalanceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VacationBalances",
                keyColumn: "VacationBalanceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VacationBalances",
                keyColumn: "VacationBalanceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2);
        }
    }
}
