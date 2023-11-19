using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migration_Core.Migrations
{
    /// <inheritdoc />
    public partial class changeTypeDecimal_to_string : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // поменять тип колонки
           // создаем новую колонку
            migrationBuilder.AddColumn<string>(
                name: "PriceString",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true);
            // заполняем ее с изменением типа
            migrationBuilder.Sql("update Dishes set PriceString = cast(Price as nvarchar(max));");
            // меняем тип исходной колонки 
            migrationBuilder.AlterColumn<string>(
               name: "Price",
               table: "Dishes",
               type: "nvarchar(max)",
               nullable: false,
               oldClrType: typeof(decimal),
               oldType: "decimal(18,2)");
            // переписываем данные в обновленную колонку
            migrationBuilder.Sql("update Dishes set Price = PriceString;");
            // удаляем временную колонку
            migrationBuilder.DropColumn("PriceString", "Dishes");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // поменять тип колонки
            // создаем новую колонку
            migrationBuilder.AddColumn< decimal> (
                name: "PriceDecimal",
                table: "Dishes",
                type: "decimal(18,2)",
                nullable: true);
            // заполняем ее с изменением типа
            migrationBuilder.Sql("update Dishes set PriceDecimal = cast(Price as decimal(18,2));");
            // меняем тип исходной колонки
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
            // переписываем данные в обновленную колонку
            migrationBuilder.Sql("update Dishes set Price = PriceDecimal;");
            // удаляем временную колонку
            migrationBuilder.DropColumn("PriceDecimal", "Dishes");
        }
    }
}
