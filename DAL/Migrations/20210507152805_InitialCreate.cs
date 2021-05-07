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
                    IdClient = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(130)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
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
                    IdClient = table.Column<string>(type: "nvarchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.IdInvoice);
                    table.ForeignKey(
                        name: "FK_Invoices_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", nullable: true),
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
                    IdProduct = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IdInvoice = table.Column<string>(type: "nvarchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.IdDetail);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_IdInvoice",
                        column: x => x.IdInvoice,
                        principalTable: "Invoices",
                        principalColumn: "IdInvoice",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_IdInvoice",
                table: "InvoiceDetails",
                column: "IdInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_IdProduct",
                table: "InvoiceDetails",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_IdClient",
                table: "Invoices",
                column: "IdClient");

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
