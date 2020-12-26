using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Infrastructure.EF.Migrations
{
    public partial class many2manyconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "ProductRegisterDate", "UnitPrice" },
                values: new object[] { new Guid("0fdaed30-cd1e-4935-81d3-a5f941d9cd5d"), "IPhone X", new DateTime(2020, 12, 26, 23, 6, 17, 78, DateTimeKind.Utc).AddTicks(2205), 1000m });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f025ad17-e714-4ede-8b9c-c6053471e106"), "Mobile phone" });

            migrationBuilder.InsertData(
                table: "ProductsTags",
                columns: new[] { "Id", "ProductId", "TagId" },
                values: new object[] { new Guid("ded8718f-a05b-4ac9-92b7-828551469831"), new Guid("0fdaed30-cd1e-4935-81d3-a5f941d9cd5d"), new Guid("f025ad17-e714-4ede-8b9c-c6053471e106") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumn: "Id",
                keyValue: new Guid("ded8718f-a05b-4ac9-92b7-828551469831"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("0fdaed30-cd1e-4935-81d3-a5f941d9cd5d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("f025ad17-e714-4ede-8b9c-c6053471e106"));
        }
    }
}
