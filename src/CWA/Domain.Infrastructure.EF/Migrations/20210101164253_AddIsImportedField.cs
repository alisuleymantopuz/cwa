using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Infrastructure.EF.Migrations
{
    public partial class AddIsImportedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsImported",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "ProductRegisterDate", "UnitPrice" },
                values: new object[] { new Guid("f457923e-6b73-4711-887a-093dc0a1e34e"), "IPhone X", new DateTime(2021, 1, 1, 16, 42, 50, 936, DateTimeKind.Utc).AddTicks(7106), 1000m });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c609571b-086d-4343-838b-6d4147920afe"), "Mobile phone" });

            migrationBuilder.InsertData(
                table: "ProductsTags",
                columns: new[] { "Id", "ProductId", "TagId" },
                values: new object[] { new Guid("87447a4a-a125-4913-9670-d0e8963a9af6"), new Guid("f457923e-6b73-4711-887a-093dc0a1e34e"), new Guid("c609571b-086d-4343-838b-6d4147920afe") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumn: "Id",
                keyValue: new Guid("87447a4a-a125-4913-9670-d0e8963a9af6"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f457923e-6b73-4711-887a-093dc0a1e34e"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("c609571b-086d-4343-838b-6d4147920afe"));

            migrationBuilder.DropColumn(
                name: "IsImported",
                table: "Product");

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
    }
}
