using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procuts_Categories_CategoryId",
                table: "Procuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procuts",
                table: "Procuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Procuts",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Procuts_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Product",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Product",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Category",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Procuts");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Procuts",
                newName: "IX_Procuts_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Procuts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Procuts",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Procuts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Procuts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procuts",
                table: "Procuts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Procuts_Categories_CategoryId",
                table: "Procuts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
