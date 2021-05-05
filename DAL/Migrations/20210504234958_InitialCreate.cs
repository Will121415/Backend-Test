using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Indentification = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(130)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Indentification);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Nit = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Nit);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    IdInvoice = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalIva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDate = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    ClientIndentification = table.Column<string>(type: "nvarchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.IdInvoice);
                    table.ForeignKey(
                        name: "FK_Invoices_Clients_ClientIndentification",
                        column: x => x.ClientIndentification,
                        principalTable: "Clients",
                        principalColumn: "Indentification",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitMeasure = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    QuantityStock = table.Column<float>(type: "real", nullable: false),
                    Iva = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierNit = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierNit",
                        column: x => x.SupplierNit,
                        principalTable: "Suppliers",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    IdDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityProduct = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    TolalDetail = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductIdProduct = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    InvoiceIdInvoice = table.Column<string>(type: "nvarchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.IdDetail);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceIdInvoice",
                        column: x => x.InvoiceIdInvoice,
                        principalTable: "Invoices",
                        principalColumn: "IdInvoice",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Products_ProductIdProduct",
                        column: x => x.ProductIdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceIdInvoice",
                table: "InvoiceDetails",
                column: "InvoiceIdInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductIdProduct",
                table: "InvoiceDetails",
                column: "ProductIdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientIndentification",
                table: "Invoices",
                column: "ClientIndentification");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierNit",
                table: "Products",
                column: "SupplierNit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
