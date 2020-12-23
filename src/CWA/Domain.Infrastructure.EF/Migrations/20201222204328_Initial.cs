using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Domain.Infrastructure.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    ProductRegisterDate = table.Column<DateTime>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsTags",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsTags", x => new { x.TagId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductsTags_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsTags_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "ProductRegisterDate", "UnitPrice" },
                values: new object[] { new Guid("355ccaab-f3e5-40b1-af1a-d32abec73b72"), "IPhone X", new DateTime(2020, 12, 22, 20, 43, 27, 839, DateTimeKind.Utc).AddTicks(4688), 1000m });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6100adba-7698-4507-95d3-00b14a598d7b"), "Mobile phone" });

            migrationBuilder.InsertData(
                table: "ProductsTags",
                columns: new[] { "TagId", "ProductId" },
                values: new object[] { new Guid("6100adba-7698-4507-95d3-00b14a598d7b"), new Guid("355ccaab-f3e5-40b1-af1a-d32abec73b72") });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTags_ProductId",
                table: "ProductsTags",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Name",
                table: "Tag",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsTags");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
