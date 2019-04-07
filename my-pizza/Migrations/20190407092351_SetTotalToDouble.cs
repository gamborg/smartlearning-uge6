using Microsoft.EntityFrameworkCore.Migrations;

namespace my_pizza.Migrations
{
    public partial class SetTotalToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
