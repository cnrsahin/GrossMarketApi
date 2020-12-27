using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrossMarketApp.Data.Migrations
{
    public partial class Kurulum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    EmployeeAge = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    EmployeeSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EmployeePhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmployeeJob = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsHired = table.Column<bool>(type: "bit", nullable: false),
                    IsFired = table.Column<bool>(type: "bit", nullable: false),
                    IsContinuesToWork = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberCustomerName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MemberCustomerAge = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    MemberCustomerPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    SupplierPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SupplierEmailAddress = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarcodeNumber = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "ModifiedDate", "Note" },
                values: new object[,]
                {
                    { 1, "Yağ Ürünleri", new DateTime(2020, 12, 27, 19, 37, 43, 473, DateTimeKind.Local).AddTicks(2237), new DateTime(2020, 12, 27, 19, 37, 43, 473, DateTimeKind.Local).AddTicks(3297), "Sıvı ve Katı Yağ Kategorisi" },
                    { 2, "Kasap Ürünleri", new DateTime(2020, 12, 27, 19, 37, 43, 473, DateTimeKind.Local).AddTicks(4358), new DateTime(2020, 12, 27, 19, 37, 43, 473, DateTimeKind.Local).AddTicks(4361), "Kırmızı ve Beyaz Et Kategorisi" },
                    { 3, "Manav Ürünleri", new DateTime(2020, 12, 27, 19, 37, 43, 473, DateTimeKind.Local).AddTicks(4370), new DateTime(2020, 12, 27, 19, 37, 43, 473, DateTimeKind.Local).AddTicks(4372), "Meyve ve Sebze Ürünleri" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeAddress", "EmployeeAge", "EmployeeJob", "EmployeeName", "EmployeePhoneNumber", "EmployeeSalary", "IsContinuesToWork", "IsFired", "IsHired" },
                values: new object[,]
                {
                    { 1, "Ramiz Mahallesi No:609 Sındırgı, Balıkesir", 24, "Kasiyer", "İsmail Çakır", "+908512730226", 2600m, true, false, true },
                    { 2, "Dolgun Caddesi No:394 Ağaçören, Aksaray", 41, "Manav", "Ezgi Bulut", "+908511660275", 2300m, true, false, true },
                    { 3, "Buse Mahallesi No:129 Türkeli, Sinop", 34, "Kasap", "Hasan Köse", "+908512897057", 3100m, true, false, true }
                });

            migrationBuilder.InsertData(
                table: "MemberCustomers",
                columns: new[] { "Id", "CreatedDate", "MemberCustomerAge", "MemberCustomerName", "MemberCustomerPhoneNumber", "ModifiedDate", "Note" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 27, 19, 37, 43, 479, DateTimeKind.Local).AddTicks(8520), 22, "Çiğdem Erdoğan", "+908516342272", new DateTime(2020, 12, 27, 19, 37, 43, 479, DateTimeKind.Local).AddTicks(8531), "Yeni müşteri, üyelik kartı satın aldı." },
                    { 2, new DateTime(2020, 12, 27, 19, 37, 43, 479, DateTimeKind.Local).AddTicks(8541), 32, "Nurcan Arslan", "+908513277329", new DateTime(2020, 12, 27, 19, 37, 43, 479, DateTimeKind.Local).AddTicks(8543), "Yeni müşteri, üyelik kartı satın aldı." },
                    { 3, new DateTime(2020, 12, 27, 19, 37, 43, 479, DateTimeKind.Local).AddTicks(8551), 48, "Bayram Köse", "+908514856593", new DateTime(2020, 12, 27, 19, 37, 43, 479, DateTimeKind.Local).AddTicks(8553), "Yeni müşteri, üyelik kartı satın aldı." }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Note", "SupplierAddress", "SupplierEmailAddress", "SupplierName", "SupplierPhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 27, 19, 37, 43, 478, DateTimeKind.Local).AddTicks(8344), new DateTime(2020, 12, 27, 19, 37, 43, 478, DateTimeKind.Local).AddTicks(8355), "Yiyecek ve içecek tedarikçisi", "Ayfer Caddesi No:656 Kurşunlu, Çankırı", "info@mail.com", "Destek Gıda", "+908515083726" },
                    { 2, new DateTime(2020, 12, 27, 19, 37, 43, 478, DateTimeKind.Local).AddTicks(8377), new DateTime(2020, 12, 27, 19, 37, 43, 478, DateTimeKind.Local).AddTicks(8379), "Yiyecek ve içecek tedarikçisi", "Adnan Menderes Bulvarı No:136 Görele, Giresun", "info@mail.com", "Besa Gıda", "+908512279812" },
                    { 3, new DateTime(2020, 12, 27, 19, 37, 43, 478, DateTimeKind.Local).AddTicks(8388), new DateTime(2020, 12, 27, 19, 37, 43, 478, DateTimeKind.Local).AddTicks(8390), "Yiyecek ve içecek tedarikçisi", "Kaçkar Bulvarı No:800 Palu, Elazığ", "info@mail.com", "Öz Trakya Gıda", "+908516990496" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BarcodeNumber", "CategoryId", "CreatedDate", "ExpiryDate", "ModifiedDate", "Note", "Price", "ProductName", "ProductionDate", "Stock", "SupplierId" },
                values: new object[] { 1, new Guid("6ed794db-5a77-4076-afb8-9e796c170b34"), 1, new DateTime(2020, 12, 27, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(5811), new DateTime(2021, 12, 27, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(4825), new DateTime(2020, 12, 27, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(5848), "Süzme zeytin yağı 1 litrelik şişe", 60m, "Zeytin Yağı 1lt", new DateTime(2020, 10, 28, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(3774), 28, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BarcodeNumber", "CategoryId", "CreatedDate", "ExpiryDate", "ModifiedDate", "Note", "Price", "ProductName", "ProductionDate", "Stock", "SupplierId" },
                values: new object[] { 2, new Guid("502840ef-abfd-46b4-baff-f9192879eb64"), 2, new DateTime(2020, 12, 27, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(5890), new DateTime(2021, 12, 27, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(5887), new DateTime(2020, 12, 27, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(5892), "1Kg dana eti", 55m, "Dana Eti", new DateTime(2020, 10, 28, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(5882), 78, 2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BarcodeNumber", "CategoryId", "CreatedDate", "ExpiryDate", "ModifiedDate", "Note", "Price", "ProductName", "ProductionDate", "Stock", "SupplierId" },
                values: new object[] { 3, new Guid("0ca7c4f2-77bc-4da5-ac66-9d5d074e7f26"), 3, new DateTime(2020, 12, 27, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(5907), new DateTime(2021, 12, 27, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(5905), new DateTime(2020, 12, 27, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(5909), "1Kg salkım ihraç domates", 11m, "Salkım Domates", new DateTime(2020, 10, 28, 19, 37, 43, 477, DateTimeKind.Local).AddTicks(5902), 120, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "MemberCustomers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
