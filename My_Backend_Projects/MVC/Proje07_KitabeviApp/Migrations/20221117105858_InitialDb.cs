using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitabeviApp.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    DogumYili = table.Column<int>(type: "INTEGER", nullable: false),
                    Cinsiyet = table.Column<char>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    BasimYili = table.Column<int>(type: "INTEGER", nullable: false),
                    SayfaSayisi = table.Column<int>(type: "INTEGER", nullable: false),
                    KategoriId = table.Column<int>(type: "INTEGER", nullable: false),
                    YazarId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Yazarlar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Aciklama", "Ad" },
                values: new object[] { 1, "Çocuk Kitapları", "Çocuk" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Aciklama", "Ad" },
                values: new object[] { 2, "Roman, Hikaye, Şiir Kitapları", "Edebiyat" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Aciklama", "Ad" },
                values: new object[] { 3, "Bilgisayar Kitapları", "Bilgisayar" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Aciklama", "Ad" },
                values: new object[] { 4, "Akademik Kitaplar", "Akademik" });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 1, "Matt Heig", 'E', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 2, "Feyyaz Yiğit", 'E', 1990 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 3, "Gizem Doğan", 'K', 1960 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 4, "Jack London", 'E', 1930 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 5, "Margaret Atwood", 'K', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 6, "Cem Akaş", 'E', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 7, "Zafer Demirkol", 'E', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 8, "İlber Ortaylı", 'E', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 9, "Seda Yiğit", 'K', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 10, "George Orwell", 'E', 1980 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Ad", "BasimYili", "KategoriId", "SayfaSayisi", "YazarId" },
                values: new object[] { 1, "İnsanlar", 2021, 2, 330, 1 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Ad", "BasimYili", "KategoriId", "SayfaSayisi", "YazarId" },
                values: new object[] { 2, "Zamanı Durdurmanın Yolları", 2021, 1, 370, 1 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Ad", "BasimYili", "KategoriId", "SayfaSayisi", "YazarId" },
                values: new object[] { 3, "Demir Ökçe", 2017, 2, 400, 4 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Ad", "BasimYili", "KategoriId", "SayfaSayisi", "YazarId" },
                values: new object[] { 4, "Huzursuzluk", 2018, 2, 330, 9 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Ad", "BasimYili", "KategoriId", "SayfaSayisi", "YazarId" },
                values: new object[] { 5, "Serenad", 2020, 2, 300, 9 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Ad", "BasimYili", "KategoriId", "SayfaSayisi", "YazarId" },
                values: new object[] { 6, "19", 2016, 2, 380, 6 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Ad", "BasimYili", "KategoriId", "SayfaSayisi", "YazarId" },
                values: new object[] { 7, "C# Programlama Dili", 2011, 3, 730, 7 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Ad", "BasimYili", "KategoriId", "SayfaSayisi", "YazarId" },
                values: new object[] { 8, "React Uygulama Geliştirme", 2021, 3, 530, 3 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Ad", "BasimYili", "KategoriId", "SayfaSayisi", "YazarId" },
                values: new object[] { 9, "İnsan Ömrünü Neyle Geçirmeli?", 2021, 2, 330, 8 });

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_KategoriId",
                table: "Kitaplar",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YazarId",
                table: "Kitaplar",
                column: "YazarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
