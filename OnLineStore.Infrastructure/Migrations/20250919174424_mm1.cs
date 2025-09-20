using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnLineStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mm1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_User",
                columns: table => new
                {
                    U_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: true),
                    address = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    phone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___User__5A2040DB134DBC93", x => x.U_ID);
                });

            migrationBuilder.CreateTable(
                name: "catagory",
                columns: table => new
                {
                    C_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    C_name = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__catagory__A9FDEC12AFAD3BAB", x => x.C_ID);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    T_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    U_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cart__83BB1FB2C45EA22C", x => x.T_ID);
                    table.ForeignKey(
                        name: "FK__cart__U_ID__3D5E1FD2",
                        column: x => x.U_ID,
                        principalTable: "_User",
                        principalColumn: "U_ID");
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    P_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    imge_path = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    stock = table.Column<int>(type: "int", nullable: true),
                    C_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product__A3420A777D846025", x => x.P_ID);
                    table.ForeignKey(
                        name: "FK__product__C_ID__403A8C7D",
                        column: x => x.C_ID,
                        principalTable: "catagory",
                        principalColumn: "C_ID");
                });

            migrationBuilder.CreateTable(
                name: "_Order",
                columns: table => new
                {
                    O_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_ID = table.Column<int>(type: "int", nullable: true),
                    Total_Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    paid = table.Column<bool>(type: "bit", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    status = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    T_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___Order__5AAB0C18D36137AC", x => x.O_ID);
                    table.ForeignKey(
                        name: "FK___Order__T_ID__440B1D61",
                        column: x => x.T_ID,
                        principalTable: "cart",
                        principalColumn: "T_ID");
                    table.ForeignKey(
                        name: "FK___Order__U_ID__4316F928",
                        column: x => x.U_ID,
                        principalTable: "_User",
                        principalColumn: "U_ID");
                });

            migrationBuilder.CreateTable(
                name: "cart_item",
                columns: table => new
                {
                    P_ID = table.Column<int>(type: "int", nullable: false),
                    Item_ID = table.Column<int>(type: "int", nullable: true),
                    T_ID = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cart_ite__A3420A77B4AE4BA1", x => x.P_ID);
                    table.ForeignKey(
                        name: "FK__cart_item__P_ID__46E78A0C",
                        column: x => x.P_ID,
                        principalTable: "product",
                        principalColumn: "P_ID");
                    table.ForeignKey(
                        name: "FK__cart_item__T_ID__47DBAE45",
                        column: x => x.T_ID,
                        principalTable: "cart",
                        principalColumn: "T_ID");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    R_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_ID = table.Column<int>(type: "int", nullable: true),
                    P_ID = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    comment = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Review__DE152E899061AB71", x => x.R_ID);
                    table.ForeignKey(
                        name: "FK__Review__P_ID__4BAC3F29",
                        column: x => x.P_ID,
                        principalTable: "product",
                        principalColumn: "P_ID");
                    table.ForeignKey(
                        name: "FK__Review__U_ID__4AB81AF0",
                        column: x => x.U_ID,
                        principalTable: "_User",
                        principalColumn: "U_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX__Order_T_ID",
                table: "_Order",
                column: "T_ID");

            migrationBuilder.CreateIndex(
                name: "IX__Order_U_ID",
                table: "_Order",
                column: "U_ID");

            migrationBuilder.CreateIndex(
                name: "IX_cart_U_ID",
                table: "cart",
                column: "U_ID");

            migrationBuilder.CreateIndex(
                name: "IX_cart_item_T_ID",
                table: "cart_item",
                column: "T_ID");

            migrationBuilder.CreateIndex(
                name: "IX_product_C_ID",
                table: "product",
                column: "C_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_P_ID",
                table: "Review",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_U_ID",
                table: "Review",
                column: "U_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Order");

            migrationBuilder.DropTable(
                name: "cart_item");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "_User");

            migrationBuilder.DropTable(
                name: "catagory");
        }
    }
}
