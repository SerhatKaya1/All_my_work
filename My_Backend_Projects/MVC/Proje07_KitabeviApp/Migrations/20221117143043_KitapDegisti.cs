using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitabeviApp.Migrations
{
    public partial class KitapDegisti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AnaSayfa",
                table: "Kitaplar",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Ozet",
                table: "Kitaplar",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AnaSayfa", "Ozet" },
                values: new object[] { true, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." });

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AnaSayfa", "Ozet" },
                values: new object[] { true, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." });

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AnaSayfa", "Ozet" },
                values: new object[] { true, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." });

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AnaSayfa", "Ozet" },
                values: new object[] { true, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." });

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 5,
                column: "Ozet",
                value: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam.");

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 6,
                column: "Ozet",
                value: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam.");

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 7,
                column: "Ozet",
                value: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam.");

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 8,
                column: "Ozet",
                value: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam.");

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 9,
                column: "Ozet",
                value: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnaSayfa",
                table: "Kitaplar");

            migrationBuilder.DropColumn(
                name: "Ozet",
                table: "Kitaplar");
        }
    }
}
