using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSehirTeknolojileri_Data.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Brand = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Stock = table.Column<short>(type: "smallint", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(1012), "Sıfır Telefonlar", false, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(1009), "Telefon" },
                    { 2, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(1014), "Beyaz Eşya", false, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(1013), "Beyaz Eşya" },
                    { 3, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(1016), "Laptoplar", false, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(1015), "Bilgisayar" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "CreatedDate", "Description", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Fetih Mah. Aşık Nigari Sok. NO:2AB", "Konya", new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(1993), null, "ramazankucukkoc43@gmail.com", "Ramazan", false, "Küçükkoç", new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(1995), "5436251369" },
                    { 2, "Sincan Mah. Aşık Nigari Sok. NO:2AB", "Ankara", new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(1998), null, "alistfn06@gmail.com", "Aliş", false, "Tufan", new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(1999), "5427123456" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedDate", "Description", "IsDeleted", "ModifiedDate", "Name", "Stock", "UnitPrice" },
                values: new object[] { 1, "Samsung", 1, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(3599), "Samsung Ürünü Güzel", false, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(3595), "Galaxy M-20", (short)22, 22m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedDate", "Description", "IsDeleted", "ModifiedDate", "Name", "Stock", "UnitPrice" },
                values: new object[] { 2, "Arçelik", 2, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(3606), "Arçelik Ürün Şahane", false, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(3604), "Buzdolabı", (short)12, 20m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedDate", "Description", "IsDeleted", "ModifiedDate", "Name", "Stock", "UnitPrice" },
                values: new object[] { 3, "Huawei", 3, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(3608), "Huawei Ürün artıları fazla", false, new DateTime(2022, 12, 14, 12, 5, 11, 300, DateTimeKind.Local).AddTicks(3607), "Huawei Matebook m20", (short)13, 12m });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
