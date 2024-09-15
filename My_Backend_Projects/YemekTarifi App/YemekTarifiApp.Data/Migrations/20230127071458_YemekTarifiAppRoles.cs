using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YemekTarifiApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class YemekTarifiAppRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Material = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 900, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    AddDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    Point = table.Column<int>(type: "INTEGER", nullable: false, defaultValueSql: "0"),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeMaking = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Owner = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    OwnerMail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    Confirmation = table.Column<bool>(type: "INTEGER", maxLength: 250, nullable: false),
                    Details = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => new { x.FoodId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_FoodCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodCategories_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodRecipes",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecipes", x => new { x.FoodId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_FoodRecipes_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodRecipes_Repices_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Repices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04ca83e0-307b-49c3-ab0b-a51e9d8df001", null, "Admin rolü", "Admin", "ADMIN" },
                    { "c4f284fd-cc41-4064-a23e-5f5ce782b990", null, "User rolü", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2afa6ec0-272c-4e11-996d-ad81ab8fe55c", 0, "Akasya cd. Orkide sk. Gül ap.", "İzmir", "b18d23aa-30e5-4e4b-ab51-ed4a55e022b1", new DateTime(1985, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", true, "Kemal", "Erkek", "User", false, null, "USER@GMAIL.COM", "USER", "AQAAAAIAAYagAAAAEKLskPK78RpKGH1EMB2H/czkmppVYw+CmARA6mAWFT02AopnEIddrSdUbyLDpJSShA==", "4444444444", false, "7dc65732-388f-42b4-9624-5c0c43c4b6c7", false, "user" },
                    { "e1e7cc21-3d85-4427-a9cb-1759e65c4439", 0, "Çek cd. Senet sk. Fatura ap.", "İstanbul", "510031e6-c58f-4cf7-b0b9-8955ca4c66f3", new DateTime(1998, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "Deniz", "Kadın", "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEDBDTyV2BGM4HY71OrxkXM1gQgG/otCNcdCiSV6NZRHnB0vxIwW75LMLkOwuDH3cLg==", "5555555555", false, "24bd5e69-f19f-4369-ab8c-4d83571fc2b3", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Çorbalar bu Categoride bulunmaktadır", "Çorbalar", "Çorbalar" },
                    { 2, "Et Yemekleri bu Categoride bulunmaktadır", "Et Yemekleri", "Et Yemekleri" },
                    { 3, "Tavuk Yemekleri bu Categoride bulunmaktadır", "Tavuk Yemekleri", "Tavuk Yemekleri" },
                    { 4, "Balık Yemekleri bu Categoride bulunmaktadır", "Balık Yemekleri", "Balık Yemekleri" },
                    { 5, "Zeytinyağlılar bu Categoride bulunmaktadır", "Zeytinyağlılar", "Zeytinyağlı Yemekler" },
                    { 6, "Salatalar bu Categoride bulunmaktadır", "Salatalar", "Salata Çesitleri" },
                    { 7, "Tatlılar bu Categoride bulunmaktadır", "Tatlılar", "Tatlı Çesitleri" },
                    { 8, "İçecekler bu Categoride bulunmaktadır", "İçecekler", "İçecekler" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Description", "ImageUrl", "IsApproved", "IsHome", "Material", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Bu çorba ilk kez Kuzeydoğu Çin'de, Rus sınırından yakın mesafede bulunan Harbin şehrinde ortaya çıktı; zaman geçtikçe bu çorba ta Hong Kong'a kadar yayıldı.", "1.Png", true, true, "2 – 3 yemek kaşığı zeytinyağı\r\n1 adet soğan\r\n2 adet patates\r\n½ adet küçük mor lahana\r\n1 adet havuç\r\n1 adet kırmızı kapya biber\r\n1 adet kereviz sapı\r\n1 diş sarımsak\r\n2 yemek kaşığı domates püresi\r\n3 adet pancar\r\n1 adet defne yaprağı\r\n1 yemek kaşığı beyaz sirke\r\nTuz\r\nKarabiber\r\n3 su bardağı et suyu\r\n7 su bardağı su", "Borscht Çorbası", "borscht-corbası" },
                    { 2, "Çeşmi nigar çorbası, Osmanlı mutfağından günümüze uzanmış lezzetlerden. Bir tür mercimek çorbası olan çeşmi nigar çorbasının en önemli özelliği, içine eklenen yumurtalı limonlu terbiye", "2.Png", true, true, "¼ su bardağı zeytinyağı\r\n1 adet soğan\r\n1 yemek kaşığı un\r\n1 su bardağı kırmızı mercimek\r\nTuz\r\nKarabiber\r\n7 su bardağı su\r\nTerbiyesi için Malzemeler\r\n1 yumurta sarısı\r\n½ su bardağı süt\r\n1 adet limonun suyu\r\nSosu için Malzemeler\r\n1 yemek kaşığı tereyağı\r\nKuru nane\r\nToz kırmızı biber\r\nPul biber", "Çeşmi Nigar Çorbası", "cesmi-nigar-corbasi" },
                    { 3, "Ezogelin çorbası, Türk mutfağına has; domates (veya salçası), pirinç ve kırmızı mercimek ile yapılan bir çorba. Adı, Barak Türkmenlerinden Gaziantep'in Oğuzeli ilçesine bağlı Uruş (yeni adıyla Dokuzyol) köyünden Ezo Gelin'in adından gelir.", "3.Png", false, true, "2 yemek kaşığı tereyağı\r\n1 adet orta boy soğan\r\n2 diş sarımsak\r\n1 su bardağı kırmızı mercimek\r\n¼ su bardağı pilavlık bulgur\r\n¼ su bardağı pirinç\r\n2 çay kaşığı tuz\r\n2 çay kaşığı karabiber\r\n7 su bardağı su\r\nMeyanesi için Malzemeler\r\n2 yemek kaşığı tereyağı\r\n1 yemek kaşığı domates salçası\r\n1 yemek kaşığı un\r\nKuru nane\r\nPul biber\r\n2 su bardağı su veya et suyu\r\nKruton için Malzemeler\r\n½ adet ramazan pidesi\r\n2 – 3 yemek kaşığı tereyağı", "Ezogelin Çorbası", "ezogelin-corbasi" },
                    { 4, "Balkabağı çorbası, balkabağı püresinden yapılan genellikle 'bağlı' bir çorbadır. Harmanlanmış balkabağının etinin et suyu veya et suyu ile birleştirilmesiyle yapılır. Sıcak veya soğuk olarak servis edilebilir ve Amerika Birleşik Devletleri'nde yaygın bir Şükran Günü yemeğidir.", "4.Png", false, false, "1 tepeleme yemek kaşığı tereyağı\r\n1 adet büyük boy soğan\r\n1 adet patates\r\n750 gr. balkabağı\r\n¼ adet muskat – rende\r\n1 adet yıldız anason\r\nTuz\r\nKarabiber\r\n5 su bardağı et veya sebze suyu\r\n2 yemek kaşığı krema", "Balkabağı Çorbası", "balkabagı-corbası" },
                    { 5, "Fransız mutfağından alınarak Kanada tarzının eklendiği bezelye çorbası, füme jambon ile yapılıyor.", "5.Png", true, true, "2 yemek kaşığı ayçiçek yağı\r\n1 adet soğan\r\n1 diş sarımsak – ezilmiş\r\n1 adet patates\r\n5 su bardağı tavuk suyu\r\n2 su bardağı bezelye\r\n4 – 5 dal taze nane\r\nTuz\r\nKarabiber\r\n1 adet tavuk göğüs – haşlanmış\r\nSüslemek için Malzemeler\r\nTaze nane yaprağı", "Naneli Bezelye Çorbası", "balkabagı-corbası" },
                    { 6, "İsveç köftesi genellikle kekreyemiş (lingonberry) reçeli, özel et sosu ve haşlanmış veya kızarmış patatesle birlikte servis edilir. Orijinal ismi “köttbullar” olan İsveç köftesi, İsveç mutfağının geleneksel bir yemeğidir", "6.Png", true, true, "500 gr. orta yağlı kıyma\r\n1 su bardağı panko – ekmek kırıntısı\r\n1 adet yumurta\r\n1 adet orta boy soğan – rende\r\n¼ su bardağı süt\r\n1 tatlı kaşığı sarımsak tozu\r\n1 tatlı kaşığı yenibahar\r\nTuz\r\nKarabiber\r\n1 – 2 yemek kaşığı tereyağı\r\nKrema Sosu için Malzemeler\r\n2 yemek kaşığı tereyağı\r\n1 yemek kaşığı un\r\n2 su bardağı et suyu\r\n1 su bardağı krema – 200 ml.\r\n1 çay kaşığı hardal\r\nTuz\r\nKarabiber\r\nÜzeri için Malzemeler\r\n1 adet bayat ekmek\r\nKaşar peyniri – rende\r\nMaydanoz", "İsveç Köftesi", "ısvec-koftesi" },
                    { 7, "Osmanlı saray mutfağında padişah sofralarında ve sarayın önde gelen paşalarına verilen önemli ziyafetlerde yemek menülerinde de öncelikte yer almıştır. Ayni zamanda ahalide Osmanlı ve Türk Mutfağı, Geleneksel Türk Mutfağı, Yöresel Yemekler, Yöresel Mutfaklar da et yemekleri ve tercih edilen tencere yemekleri arasında kendi yerini almıştır. Domatesin tam olarak keşfedilmeden önce eski Türk topluluklarında ve Osmanlıda yemekler koruk suyu, baharatlar ve kuru meyveler ile tatlandırılıyordu.", "7.Png", true, true, "750 gr. kemiksiz kuzu but ya da kol\r\nTuz\r\nKarabiber\r\n2 yemek kaşığı un\r\n2 yemek kaşığı zeytinyağı\r\n2 adet orta boy soğan\r\n3 adet yeşil biber\r\n1 tutam rendelenmiş taze zencefil\r\n3 su bardağı et suyu\r\n1 tutam tel safran ya da aspir\r\n1 su bardağı sıcak su – safran için\r\n1 limonun suyu\r\n1 tatlı kaşığı tane kişniş\r\n1 su bardağı kuru kayısı\r\n1 adet yeşil biber", "Kayısılı Kuzu Eti", "ısvec-koftesi" },
                    { 8, "Taco, (İspanyolca: Taco) geleneksel Meksika yemeği. Birçok şekilde yapılabilmektedir. Yapımında tortilla, et, peynir ve çeşitli sebzeler kullanılır. Ayrıca, yanında bazı garnitürler de tüketilebilir.", "8.Png", true, false, "12\r\nadet\r\nmini lavaş\r\n(ya da taco kabuğu)\r\n3\r\nyemek kaşığı\r\nzeytinyağı\r\n500\r\ngram\r\norta yağlı kıyma\r\n1\r\nadet\r\nküçük boy kuru soğan\r\n(küp küp doğranmış)\r\n1\r\nadet\r\norta boy domates\r\n(püre haline getirilmiş)\r\n1\r\ntatlı kaşığı\r\nacı sos\r\n1\r\ntatlı kaşığı\r\ndomates salçası\r\n1/2\r\nçay kaşığı\r\ntuz\r\n1/4\r\nçay kaşığı\r\nkimyon\r\n4\r\ndal\r\ntaze kişniş\r\n(ya da maydanoz)\r\nServisi için:\r\n1/2\r\ndemet\r\nmaydanoz\r\n(ince kıyılmış)\r\n1/2\r\nadet\r\navokado\r\n1\r\nadet\r\nbüyük boy domates\r\n(küp küp doğranmış)\r\n1\r\nadet\r\norta boy kırmızı soğan\r\n(küp küp doğranmış)\r\n1/2\r\nsu bardağı\r\nrendelenmiş kaşar peyniri\r\n1/2\r\nsu bardağı\r\nrendelenmiş cheddar peyniri", "Meksika Çıtırı: Taco Tarifi", "meksika-citiri-taco" },
                    { 9, " Sonbahar ve kış aylarında Topkapı sarayında yapılan bir yemekti. Osmanlı döneminde ''rummamiye'' denilen bu yemek, yıllar içerisinde unutulmayarak günümüz mutfağında da yer almaktadır. ", "9.Png", false, true, "1 yemek kaşığı tereyağı\r\n1 yemek kaşığı zeytinyağı\r\n1 kilo kuzu eti – iri kuşbaşı\r\n20 – 25 adet arpacık soğan\r\n1 yemek kaşığı domates salçası\r\n1 yemek kaşığı un\r\nTuz\r\nKarabiber\r\n2 – 3 dal taze kekik\r\n1 tutam tane kişniş\r\n1 yemek kaşığı nar ekşisi\r\n4 su bardağı sıcak su\r\n2 adet defne yaprağı\r\nÜzeri için Malzemeler\r\n1 su bardağı nar tanesi\r\n3 dal taze soğanın yeşil kısmı", " Narlı Kuzu Eti", "narlı-kuzu-eti" },
                    { 10, " Fajita, Meksika mutfağına ait bir etli yemek türüdür. Orijinal olarak dana eti ile yapılan yemek günümüzde tavuk ve karides ile yapılmaktadır. Yemek tortilla ekmeği ile birlikte servis edilmektedir. ", "10.Png", true, true, "600 gram julyen doğranmış dana bonfile\r\n1 adet kırmızı Kaliforniya biberi\r\n1 adet sarı Kaliforniya biberi\r\n1 adet yeşil biber\r\n1 baş kırmızı kuru soğan\r\nYarım çay bardağı zeytinyağı\r\n2 yemek kaşığı soya sosu\r\nEt marinasyonu için;\r\n\r\n1 yarım limon suyu\r\n1 çay bardağı zeytinyağı\r\nYarım çay bardağı soya sosu\r\n2 diş sarımsak\r\n1 çay kaşığı karabiber\r\n1 tatlı kaşığı kekik tuz, tatlı toz biber", " Etli Fajita", "etli-fajita" },
                    { 11, "Şnitzel veya şinitzel (Almanca: Wiener Schnitzel), Avusturya mutfağından, gayet ince kesilmiş bir dilim dana, domuz veya tavuk etinin sırasıyla una, yumurta sarısına ve galeta ununa bandırılarak kızgın yağda kızartılmasıyla yapılan bir yemek türüdür.", "11.Png", true, true, "2 adet tavuk göğsü\r\n2 adet yumurta\r\n2 yemek kaşığı un\r\n2 yemek kaşığı zeytinyağı\r\n1 tutam tuz\r\n1 tutam karabiber\r\nPanelemek için Malzemeler\r\n1 su bardağı un\r\n2 adet yumurta\r\n1 su bardağı galeta unu\r\nKızartmak için Malzemeler\r\nAyçiçek yağı", " Tavuk Nugget ", "tavuk-nugget" },
                    { 12, "Antakya Kâğıt Kebabı; dana döş eti, yeşil ve kırmızı biber (acı veya tatlı) maydanoz, sarımsak, tuz ve karabiber karışımından oluşan, disk şekli verilerek yağlı kağıt üzerinde pişirilen, yörede Arapça olarak “lahme la varka” olarak da bilinen bir kebaptır.", "12.Png", true, true, "2 – 3 yemek kaşığı zeytinyağı\r\n1 adet patlıcan\r\n1 adet kabak\r\n1 adet patates\r\n2 adet tavuk göğüs\r\n10 – 15 adet arpacık soğan\r\n1 su bardağı bezelye – haşlanmış ya da dondurulmuş\r\n3 – 4 diş sarımsak\r\n10 adet siyah zeytin\r\nSosu için Malzemeler\r\n3 yemek kaşığı zeytinyağı\r\n2 yemek kaşığı az tuzlu soya sosu\r\n1 tatlı kaşığı domates salçası\r\n1 tatlı kaşığı biber salçası\r\nTuz\r\nKarabiber\r\nKuru kekik\r\n1 avuç ceviz – iri dövülmüş", " Tavuklu Kağıt Kebabı ", "tavuklu-kagit-kebabi" },
                    { 13, "Elmadağ yöresine ait harika ve lezzetli bir yemektir.", "13.Png", false, false, "2 – 3 yemek kaşığı tereyağı\r\n1 adet ramazan pidesi\r\nTavuk için Malzemeler\r\n10 su bardağı su\r\n7 – 8 adet tane karabiber\r\n1 adet soğan\r\n1 dal kereviz sapı\r\n5 – 6 adet tavuk baget\r\nTuz\r\n1 su bardağı nohut – haşlanmış\r\nDomates Sosu için Malzemeler\r\n3 yemek kaşığı zeytinyağı\r\n1 adet soğan\r\n1 yemek kaşığı domates salçası\r\n1 su bardağı tavuk suyu\r\n4 yemek kaşığı domates püresi\r\n1 avuç kuru nane\r\n1 avuç kuru kekik\r\nTuz\r\nKarabiber\r\nYoğurt için Malzemeler\r\n4 – 5 yemek kaşığı süzme yoğurt\r\n1 diş sarımsak\r\nSüslemek için Malzemeler\r\nKuru nane", " Tavuklu Nohutlu Tirit ", "tavuklu-nohutlu-tirit" },
                    { 14, "Ege yöresine ait olup Ege'nin mutfak güzelliklerinden biri olan tavuklu sultan kebabı sofralarımıza lezzet katmaktadır.", "14.Png", true, true, "2 adet yufka\r\n400g tavuk göğsü\r\n400g tavuk pirzola\r\n1 adet kuru soğan\r\n1 yemek kaşığı domates salçası (Birazını ketçap kullanabilirsiniz)\r\n1 su bardağı haşlanmış ya da konserve bezelye\r\n1 adet patlıcan\r\nPul biber\r\nKekik\r\nKarabiber\r\nTuz\r\nBeşamel sos için:\r\n\r\n1,5 yemek kaşığı un\r\n1,5 su bardağı süt\r\n2 yemek kaşığı tereyağı\r\nTuz\r\nÜzeri için:\r\n\r\nKaşar peyniri rendesi", " Tavuklu Sultan Kebabı Tarifi ", "tavuklu-sultan-kebabı" },
                    { 15, "Doğunun incisi Mardinde genelde yapılan nefis bir yemektir..", "15.Png", true, true, "1 adet bütün tavuk\r\n1 tatlı kaşığı un\r\n2-3 defne yaprağı\r\nLimon dilimleri\r\nSosu için:\r\n\r\n1 tatlı kaşığı yoğurt\r\n1 tatlı kaşığı domates salçası\r\n2 yemek kaşığı sıvı yağ\r\n1 çay kaşığı toz kırmızı biber\r\nYarım tatlı kaşığı tuz\r\nPilavı için:\r\n\r\n2 su bardağı pilavlık pirinç\r\n2 yemek kaşığı tereyağı\r\n2 yemek kaşığı sıvı yağ\r\nYarım çay bardağı dolmalık fıstık\r\nYarım çay bardağı kuş üzümü\r\n2 su bardağı sıcak su (400 ml)\r\n1 çay bardağı sıcak su (sonradan ekleniyor)\r\n1 tatlı kaşığı tuz\r\n1 çay kaşığı tarçın\r\n1 çay kaşığı karabiber\r\nGarnitür olarak:\r\n\r\n2 adet patates\r\n2 adet havuç\r\nArpacık soğan", " Fırında İç Pilavlı Tavuk Dolması Tarifi ", "fırında-iç-pilavli-tavuk-dolmasi" },
                    { 16, "Karadeniz denince akla gelen ilk lezzetlerden biridir o. Hamsi kuşu tarifinde kılçıkları tamamen ayıklanıp fileto haline getirilen hamsiler; maydanoz, taze soğan, kuru soğan, mısır unu ve baharatların da yer aldığı karışımla ikişer ikişer kapatılır.", "16.Png", false, true, "40 adet hamsi\r\n3 dal taze soğan\r\n30 yaprak nane\r\n12 dal maydanoz\r\n15 adet karanfilin top kısmı\r\n1 yemek kaşığı susam\r\n1 yemek kaşığı zeytinyağı\r\nTuz\r\nKarabiber\r\nHamsileri kızartmak için Malzemeler\r\n1 su bardağı mısır unu\r\nAyçiçek yağı\r\nSunum için Malzemeler\r\nKırmızı Soğan\r\nLimon\r\nRoka", " Hamsi Kuşu ", "hamsi-kusu" },
                    { 17, "Karadeniz denince akla gelen ilk lezzetlerden biridir o. Hamsi kuşu tarifinde kılçıkları tamamen ayıklanıp fileto haline getirilen hamsiler; maydanoz, taze soğan, kuru soğan, mısır unu ve baharatların da yer aldığı karışımla ikişer ikişer kapatılır.", "17.Png", true, true, "4 dilim somon fileto\r\n4 avuç ekmek kırıntısı – panko\r\n1 tepeleme yemek kaşığı tereyağı\r\n2 – 3 diş sarımsak\r\n2 avuç fesleğen\r\nServis Etmek için Malzemeler\r\nRenkli çeri domates\r\nPesto Sos için Malzemeler\r\n2 bağ fesleğen – 50 yaprak\r\n½ bağ maydanoz\r\n½ su bardağı fındık\r\n½ su bardağı toz parmesan\r\n2 – 3 diş sarımsak\r\nTuz\r\nKarabiber\r\n1 – 1,5 su bardağı zeytinyağı", " Ekmek Kırıntılı Pestolu Somon ", "ekmek-kirintili-pestolu-somon" },
                    { 18, "Karadeniz yöresine ait bir yemek türü olan hamsili pilav, Karadenizlilerin sofralarının vazgeçilmez lezzeti.", "18.Png", true, true, "2 kg. hamsi – ayıklanmış – 120 adet\r\n½ su bardağı zeytinyağı\r\n2 adet soğan – çok ince yemeklik doğranmış\r\n2 su bardağı baldo pirinç\r\nTuz\r\nKarabiber\r\n1 tatlı kaşığı yenibahar\r\n1 tepeleme yemek kaşığı kuru nane\r\n½ su bardağı kuş üzümü – suda beklemiş\r\n1 yemek kaşığı toz şeker\r\n1 adet defne yaprağı\r\n2 su bardağı su\r\n½ bağ dereotu\r\nTereyağı – kabı yağlamak için\r\nÜzeri için Malzemeler\r\n4 dilim limon\r\nTereyağı", " Hamsili Pilav  ", "hamsili-pilav" },
                    { 19, "Gravlax İskandinav mutfağından somon ile hazırlanan fermente edilmiş bir yiyecek dir.", "19.Png", true, true, "1 dilim 120 gramlık somon\r\n1 silme yemek kaşığı toz şeker\r\n1 tutam tuz\r\n1 adet pancarın suyu\r\n1 adet limonun kabuğu\r\n½ adet limon suyu\r\n¼ adet taze rezene\r\nSalata için Malzemeler\r\n1 yemek kaşığı kinoa\r\n2 su bardağı su\r\n¼ adet kırmızı soğan\r\n¼ adet salatalık\r\n1/6 adet sarı dolmalık biber\r\n¼ adet domates – çekirdeği çıkartılmış\r\n1 parmak kereviz sapı\r\n1 dilim mango\r\n4 yaprak taze nane\r\n1 yemek kaşığı lor peyniri\r\nAvokado Katı için Malzemeler\r\n1 adet avokado\r\n1 yemek kaşığı limon suyu\r\nTuz\r\nKarabiber\r\nSosu (Vinaigrette) için Malzemeler\r\n1 yemek kaşığı toz şeker\r\nTuz\r\nKarabiber\r\n½ adet limon suyu\r\n3 yemek kaşığı zeytinyağı\r\nParmesan Tuille için Malzemeler\r\n1 yemek kaşığı parmesan – ince rende", " Somon Grawlax ", "somon-grawlax" },
                    { 20, "Uzakdoğu başta olmak üzere dünyanın pek çok ülkesinde yaygın olarak tüketilen karidesin bilinen 2 bin 500 türü var. Türkiye denizlerinde 61 türü bulunuyor ve bunlardan sadece 7’si ticari olarak değerlendiriliyor. Bu lezzetli deniz kabuklusunun güveci, ızgarası, tavası, söğüşü damakları şenlendiriyor…", "20.Png", true, true, "Orta boy kalın kabuklu karidesler\r\n\r\nKaya Tuzu\r\n\r\nBahçe yeşillikleri", " Tuzda Karides ", "tuzda-karides" },
                    { 21, "Yaprak sarmanın harika bir hali. lezzet bombası, inanılmaz bir ahenk. ricardo moyano' nun yemen türküsü 'nü yorumlaması gibi bir şey.", "21.Png", true, true, "400 gr. asma yaprağı\r\nPilav için Malzemeler\r\n½ su bardağı zeytinyağı\r\n2 yemek kaşığı dolmalık fıstık\r\n2 adet soğan\r\n2 su bardağı pirinç\r\nTuz\r\nKarabiber\r\n½ tatlı kaşığı tarçın\r\n½ tatlı kaşığı yeni bahar\r\n1 tatlı kaşığı kuru nane\r\n1 su bardağı su\r\n1 su bardağı vişne suyu\r\n1 yemek kaşığı kuş üzümü\r\n1 yemek kaşığı nar ekşisi\r\n1 yemek kaşığı toz şeker\r\n400 gr. vişne\r\n1 su bardağı vişne suyu – sarmaları pişirmek için", " Vişneli Yaprak Sarma ", "visneli-yaprak-sarma" },
                    { 22, "Bakla geleneksel İzmir mutfağında sevilerek tüketilen zeytinyağlı yemeklerden biridir.", "22.Png", true, true, "Zeytinyağlı Bakla Malzemeleri\r\n500 gr. taze bakla\r\n½ su bardağı zeytinyağı\r\n1 adet soğan – yemeklik doğranmış\r\nTuz\r\nKarabiber\r\n1 yemek kaşığı toz şeker\r\n1 yemek kaşığı un\r\n½ su bardağı su\r\nÜzeri için Malzemeler\r\nDereotu", " Zeytinyağlı Bakla ", "zeytinyagli-bakla" },
                    { 23, "İzmir'de çoğunlukla Karaburun, Mordoğan, Urla ilçelerinde yetişen enginar, İzmir mutfağında en çok çeşidi yapılan sebzelerden biridir. Zeytinyağlı enginar, kuzu etli enginar, iç baklalı enginar, taze baklalı enginar, enginar kızartması, enginar dolması, enginarlı pilav bunlara örnek olarak verilebilir.", "23.Png", true, true, "4 – 5 yemek kaşığı zeytinyağı\r\n3 adet soğan\r\n150 gr. taze iç bakla\r\n1 diş sarımsak\r\nTuz\r\nBeyaz biber\r\n1 tatlı kaşığı toz şeker\r\n7 adet enginar\r\n1 adet limon suyu\r\n1,5 su bardağı su\r\n½ bağ dereotu – ince kıyım", " İç Baklalı Enginar ", "iç-baklali-enginar" },
                    { 24, "Fava (Favetta) bakla tanelerinin kabuğu soyulduktan sonra yapılan zeytin yağlı yemektir. Eski İstanbul Rumları kuru bakliyattan yapılan bütün ezmelere fava (Φάβα) derdi. Ama bugün Türkiye'de fava denince sadece kuru bakla ezmesinden yapılan meze anlaşılıyor.Girit Türk mutfağında yer alır.", "24.Png", true, true, "½ kg kuru bakla\r\n1 demet dereotu\r\n2 yemek kaşığı şeker\r\n1 orta boy soğan\r\n1 su bardağı zeytinyağı\r\n2 tutam tuz\r\n5 bardak su\r\n \r\nEnginar için Malzemeler\r\n6 adet enginar\r\n1 iri kırmızı soğan\r\n1 portakalın suyu ve parçaları\r\n1 bardak su\r\n1 bardak z.yağı\r\n1 tatlı kaşığı şeker\r\n2 tutam tuz", " Enginarlı Fava ", "enginarli-fava" },
                    { 25, " İmambayıldı, Ege yöresine ait; Patlıcan, soğan, sarımsak, biber, domates, maydanoz ile yapılan bir yemektir.", "25.Png", true, true, "Kızartmak için Malzemeler\r\n4 adet patlıcan – küçük boy\r\nZeytinyağı\r\n \r\nİç harcı için Malzemeler\r\n2 orta boy beyaz kuru soğan\r\n12 diş sarımsak\r\n3 adet sivribiber\r\n3 adet domates\r\n3 tutam tuz\r\n3 tutam karabiber\r\n1 dolu tatlı kaşığı toz şeker\r\n½ demet maydanoz\r\n1 yemek kaşığı zeytinyağı", " İmam Bayıldı ", "imam-bayildi" },
                    { 26, " Doyurucu bir Lübnan lezzeti olan falafel; tadını nohut, taze yeşillikler ve kuru baharatlardan alıyor. İşin sırrı nohutları haşlamadan, bir gece önce suda bekletmekte saklı.", "26.Png", true, true, "Falafelli Salata Malzemeleri\r\n15 – 20 adet renkli çeri domates\r\n2 dolu avuç bebek roka\r\nTuz\r\nKarabiber\r\n2 yemek kaşığı zeytinyağı\r\nFalafel için Malzemeler\r\n1 su bardağı nohut – 1 gece su da bekletilmiş\r\n1 adet orta boy soğan\r\n2 diş sarımsak\r\n1 bağ maydanoz\r\n4 – 5 dal kişniş\r\nTuz\r\nKarabiber\r\n1 tatlı kaşığı kimyon\r\n1 tatlı kaşığı pul biber\r\n2 – 3 yemek kaşığı un\r\nSosu için Malzemeler\r\n1 su bardağı süzme yoğurt\r\n1 yemek kaşığı tahin\r\n½ adet limonun suyu\r\n1 – 2 yemek kaşığı zeytinyağı", " Falafelli Salata ", "falafelli-salata" },
                    { 27, " Semizotu ya da pirpirim, semizotugiller familyasından bir bitki olup yaprakları salata olarak, ya da ıspanak gibi pişirilerek yemeklerde kullanılan bir sebzedir. Kökeni Ortadoğu ve Hindistan olmakla birlikte dünyanın birçok bölgesinde bulunmaktadır.", "27.Png", true, true, "2 bağ semizotu – temizlenmiş\r\n1 adet domates\r\n½ limonun suyu\r\nZeytinyağı\r\n1 avuç ceviz\r\nKabak için Malzemeler\r\n1 adet kabak\r\nTuz\r\nZeytinyağı\r\nTabanı için Malzemeler\r\n6 yemek kaşığı süzme yoğurt\r\n1 yemek kaşığı bal\r\n1 avuç ceviz – kıyılmış", " Semizotu Salatası", "semizotu-salatasi" },
                    { 28, " Baş lahana olarak sınıflandırılan beyaz ve kırmızı lahanalar ülkemizde çoğunlukla Karadeniz Bölgesi'nde yetiştiriliyor.", "28.Png", true, true, "½ adet mor lahana\r\n1 adet havuç – rende\r\n2 adet salatalık – rende\r\n½ adet kırmızı soğan\r\n3 – 4 dal taze kişniş\r\n1 avuç ceviz\r\n1 adet lime kabuğu rendesi\r\n1 avuç sultaniye kuru üzüm\r\nSosu için Malzemeler\r\n1 yemek kaşığı zeytinyağı\r\n½ adet lime suyu\r\n1 yemek kaşığı mayonez\r\n1 yemek kaşığı süzme yoğurt", " Mor Lahana Salatası ", "mor-lahana-salatası" },
                    { 29, "Anayurdu Hindistan olan semizotu, ülkemizde de sıklıkla tüketiliyor. Semizotunun hem yemeği hem de salatası, çok seviliyor.", "29.Png", true, true, "1 bağ semizotu\r\n8-10 adet çeri domates\r\n3-4 adet Çengelköy salatalık\r\n1 adet kırmızı soğan\r\n1 avuç ceviz\r\n1 yemek kaşığı yoğurt\r\n½ adet limon suyu\r\nTuz\r\nZeytinyağı", " Semiz Otlu Yaz Salatası ", "semiz-otlu-yaz-salatasi" },
                    { 30, " İzmirde yetişen bu kök egenin harika salataları arasında yer almıştır.", "30.Png", true, true, "1 kg. ıspanak kökü\r\n½ adet limon suyu\r\n2 diş sarımsak\r\n1 yemek kaşığı süzme yoğurt\r\n2 adet domates\r\nZeytinyağı\r\nPul biber\r\nTuz\r\nKarabiber", " Ispanak Köklü Salata ", "ispanak-koklu-salata" },
                    { 31, "Yaz havaları içinde tercih edilen harika bir tatlı.", "31.Png", true, true, "Tabanı için Malzemeler\r\n1 – 2 yemek kaşığı granül kahve\r\n1 su bardağı sıcak su\r\n2 – 3 damla vanilya özütü\r\n12 – 15 adet kedi dili\r\nArası için Malzemeler\r\n3 adet muz\r\nMuhallebi için Malzemeler\r\n125 gr. tereyağı\r\n1 su bardağı un\r\n1 litre süt\r\n1,5 su bardağı toz şeker\r\n3 – 4 parça dövülmüş damla sakızı\r\nÜzeri için Malzemeler\r\nKakao", " Kedi Dilli Sakızlı Muhallebi ", "kedi-dilli-sakizli-muhallebi" },
                    { 32, "Sakız tadını damağınızda hissedeceğiniz harika bir tatlı..", "32.Png", true, true, "7,5 su bardağı süt – 1,5 litre\r\n½ su bardağı pirinç\r\n1 yemek kaşığı pirinç unu\r\n1 yemek kaşığı buğday nişastası\r\n1 su bardağı toz şeker\r\n1 tutam toz damla sakızı\r\nTarçın – üzeri için", " Damla Sakızlı Sütlaç ", "damla-sakizli-sutlac" },
                    { 33, "Kakaonun doyumsuz lezzeti ile şenlik dolu çikolata tadı", "33.Png", true, true, "4 adet yumurta\r\n1 su bardağı toz şeker\r\n1 su bardağı süt\r\n1 su bardağı ayçiçek yağı\r\n1 su bardağı un\r\n3 yemek kaşığı kakao\r\n1 paket kabartma tozu\r\n1 paket vanilya\r\n1 adet limon kabuğu\r\nSosu için Malzemeler\r\n2 su bardağı süt\r\n½ su bardağı ayçiçek yağı\r\n1 su bardağı toz şeker\r\n2 yemek kaşığı kakao", " Kakaolu Islak Kek ", "kakaolu-islak-kek" },
                    { 34, " Çileğin ekşimsi tadı ile mutlu tatlımsı ve ekşimsi bir tat :))", "34.Png", true, true, "2,5 su bardağı toz şeker\r\n2 su bardağı un\r\n1 su bardağından 1 parmak eksik kakao\r\n1,5 tatlı kaşığı kabartma tozu\r\n1,5 tatlı kaşığı karbonat\r\n1 paket vanilya\r\n1 tutam tuz\r\n2 yumurta\r\n1 + ¼ su bardağı süt\r\n½ su bardağı ayçiçek yağı\r\n1,5 su bardağı sıcak su\r\n1 yemek kaşığı granül kahve\r\nPastacı Kreması için Malzemeler\r\n500 gr. labne\r\n6 tepeleme yemek kaşığı pudra şekeri\r\nArası ve Üzeri için Malzemeler\r\n10 – 12 adet çilek", " Çilekli Porsiyonluk Pasta", "cilekli-posiyonluk-pasta" },
                    { 35, " Ormanın derinliklerinden toplanan ekşimsi meyveler ile harika bir lezzet..", "35.Png", true, true, "2 adet yumurta + 3 adet yumurtanın sarısı\r\n1 su bardağından 1 parmak eksik toz şeker\r\n½ paket vanilya\r\n½ kabartma tozu\r\n¼ su bardağı un\r\n1,5 yemek kaşığı mısır nişastası\r\nLimon kabuğu rendesi\r\n2 adet yumurtanın akı\r\n1 yemek kaşığı toz şeker\r\nRulo Yapmak için Malzemeler\r\nPudra şekeri\r\nDolgusu için Malzemeler\r\n250 gr. labne peyniri\r\n2 yemek kaşığı pudra şekeri\r\nBöğürtlen\r\nÇilek\r\nFrambuaz\r\nYaban mersini\r\nGanaj için Malzemeler\r\n100 gr. krema\r\n1 su bardağı parça bitter çikolata\r\nÜzeri için Malzemeler\r\nToz antep fıstığı", "Orman Meyveli Rulo Pasta ", "orman-meyveli-rulo-pasta" },
                    { 36, "Tüm yemeklerin yanında giden harika lezzet..", "36.Png", true, true, "200 gr. süzme yoğurt\r\n3 su bardağı su\r\n1 küçük parça tereyağı\r\n5 – 6 yaprak taze nane\r\nTuz", "Ayran ", "ayran" },
                    { 37, "Tüm yemeklerin yanında giden harika lezzet..", "37.Png", true, true, "Ev Yapımı Limonata Malzemeleri\r\n6 adet büyük boy limon\r\n1 adet portakal\r\n1 su bardağı toz şeker\r\n1 su bardağı sıcak su\r\n1 litre soğuk su\r\n½ demet taze nane", "Ev Yapımı Limonata ", "ev-yapimi-limonata" },
                    { 38, "Kış aylarının vazgeçilmez ezberi..", "38.Png", true, true, "1 litre süt\r\n1 yemek kaşığı salep\r\n1 yemek kaşığı nişasta\r\n1 paket vanilya\r\n½ su bardağı şeker\r\nTarçın – süslemek için", " Salep ", "salep" },
                    { 39, "Boğazlar mı kötü? Hemen deneyin....", "39.Png", true, true, "½ su bardağı fındık\r\n1 adet muz\r\n5 – 6 adet yulaflı bisküvi\r\n2 – 2,5 su bardağı süt", " Muzlu Süt ", "muzlu-sut" },
                    { 40, "Yaz sıcağını buza çevirin .. ", "40.Png", true, true, "1 litre sıcak su\r\n3 adet poşet siyah çay\r\n2 adet limon\r\n1 su bardağı toz şeker\r\n2 adet karanfil\r\n5 – 6 dal taze nane\r\n½ litre su\r\n1 su bardağından 2 parmak eksik limon suyu – 3-4 adet", " Buzlu Çay ", "buzlu-cay" }
                });

            migrationBuilder.InsertData(
                table: "Repices",
                columns: new[] { "Id", "Owner", "OwnerMail", "RecipeMaking" },
                values: new object[,]
                {
                    { 1, "Ali", "ali@gmail.com", "Büyük boy tencerenizi ocağa alın ve ısıtın.\r\nİçerisine zeytinyağı ve yemeklik doğradığınız soğanı ilave edip sotelemeye başlayın.\r\nKüçük küp doğradığınız patatesi ilave edip karıştırın.\r\nKüçük küp doğradığınız havuç, kırmızı kapya biber ve dilimlediğiniz kereviz sapını ilave edip karıştırın.\r\nİnce doğradığınız sarımsak, domates püresi ve rendelenmiş pancarı ilave edip karıştırın.\r\nDefne yaprağı, beyaz sirke, tuz ve karabiberi ilave edip karıştırın.\r\nEt suyu ve suyu ilave edip karıştırın.\r\nKapağını kapatın ve 40 – 45 dakika pişmeye bırakın.\r\nPişen çorbanızı servis kaselerine alıp üzerine krema ve ince kıyılmış taze soğan serpiştirip servis edin." },
                    { 2, "Ahmet", "ahmet@gmail.com", "Çorba tencerenizi ocağa alın ve zeytinyağını ilave edip ısıtın.\r\nİnce yemeklik doğradığınız soğanı ilave edip yumuşayana kadar kavurun.\r\nUnu ilave edin ve kokusu çıkana kadar kavurun.\r\nYıkayıp suyunu süzdüğünüz mercimek, tuz ve karabiberi ilave edip karıştırın.\r\nSuyunu ilave edip mercimekler iyice yumuşayana kadar 30 dakika pişirin.\r\nMercimekler pişince tuzunu ilave edin ve bir blender yardımıyla çorbanızı pürüzsüz bir kıvam alana kadar çekin.\r\nBir karıştırma kabında yumurta sarısı, süt ve limon suyunu karıştırın.\r\nKarışımın üzerine bir kepçe çorba alın ve karıştırın.\r\nArdından çorba tenceresine ekleyin ve karıştırın.\r\nBir tavanın içerisine tereyağını alın ve eritin.\r\nEriyen yağın içerisine kuru nane, toz kırmızı biber ve pul biberi ilave edip karıştırıp çorbanızın içerisine ekleyin.\r\nSıcak servis edin." },
                    { 3, "Zeynep", "zeynep@gmail.com", "Tereyağını tencereye alıp eritin.\r\nİnce yemeklik doğradığınız soğan ve ezilmiş sarımsakları tencerenize alıp yumuşayana kadar soteleyin.\r\nYıkanmış kırmızı mercimek, bulgur ve pirinci tencerenize ilave edip birkaç tur karıştırın.\r\nTuz, karabiber ve suyunu ilave edip birkaç tur karıştırın.\r\nTencerenizin kapağını kapatın ve pişmeye bırakın.\r\n\r\nKruton için;\r\nRamazan pidenizi küçük küpler olacak şekilde kesin.\r\nTavanızı ocağa alın ve ısıtın.\r\nIsınan tavanızın içerisine tereyağını ilave edip eritin.\r\nEriyen tereyağın içerisine kestiğiniz pideleri alın ve soteleyin.\r\nÇıtırlaşana pideleri kenara alın ve soğutun.\r\n\r\nMeyanesi için;\r\nBir sos tenceresine tereyağını ekleyin ve eritin.\r\nYağınız eriyince domates salçası ve unu ilave edip kavurun.\r\nKuru nane ve pul biberi ilave edip karıştırın.\r\nSuyunu ilave edin ve kıvam alana kadar karıştırın.\r\n\r\nBirleştirmek için;\r\nÇorba tencerenizdeki bakliyatlar pişince meyanesini ilave edip karıştırın.\r\nKapağını kapatın ve 10 – 15 dakika daha pişmeye bırakın.\r\nÇorbanızı kaselere pay edin.\r\nÜzerine krutonlardan serpiştirin ve sıcak servis edin." },
                    { 4, "Tunay", "tunay@gmail.com", "Tencerenizi ocağa alın ve ısıtın.\r\nTereyağını içerisine alın ve eritin.\r\nSoğanı iri küp olacak şekilde doğrayın ve tencereye alıp yumuşayana kadar soteleyin.\r\nİri küp doğradığınız patatesleri ilave edip karıştırın.\r\nKüp doğradığınız balkabaklarını ilave edin ve karıştırın.\r\nMuskat rendesi, yıldız anason, tuz ve karabiberi ilave edip karıştırın.\r\nArdından et veya sebze suyunu ilave edip karıştırın.\r\nKapağını kapatın ve sebzeler pişene kadar su kaynayana kadar yüksek, kaynadıktan sonra kısık ateşte pişirmeye devam edin.\r\nSebzeler piştikten sonra ocağın altını kapatın ve yıldız anasonu tencerenin içinden çıkarın.\r\nBlenderden geçirin ve 2 yemek kaşığı kremayı içerisine ekleyerek karıştırın.\r\nÇorbanızı servis kaselerine alın ve sıcak servis edin." },
                    { 5, "Tuncay", "tuncay@gmail.com", "Çorba tencerenizi ocağa alın ve ayçiçek yağını ilave edip ısıtın.\r\nİnce yemeklik doğradığınız soğanı ilave edip yumuşayana kadar soteleyin.\r\nEzilmiş sarımsak ve küçük küp doğradığınız patatesi ilave edip kavurun.\r\nTavuk suyunu ilave edip 10 dakika kaynatın.\r\nBezelye, taze nane yaprakları, tuz ve karabiberi ilave edip 10 dakika daha kaynatın.\r\nHer şey yumuşayınca bir el blenderi yardımıyla pürüzsüz olana kadar çekin.\r\nHaşlayıp didiklediğiniz tavuğu ilave edin ve 5 dakika daha kaynatın.\r\nHazır olan çorbanızı servis kaselerine pay edin ve taze nane yaprağıyla süsleyerek servis edin." },
                    { 6, "Serhat", "serhat@gmail.com", "Bir karıştırma kabına kıyma, panko, süt, soğan, sarımsak tozu, yenibahar, tuz ve karabiberi alıp iyice yoğurun.\r\nKöftelerinizi 45’er gramlık köfteler alın ve yuvarlayarak köfte şekline getirin.\r\nTavanızı ocağa alın ve ısıtın.\r\nIsınan tavanızın içerisine köfteleri alın ve 7 – 8 dakika kızarana kadar pişirin.\r\nKenarından tereyağı koyun ve bir tur karıştırıp bir tabağa çıkartın.\r\nAynı tavanın içerisine tereyağını ilave edip eritin.\r\nUnu ilave edip kavurun.\r\nKavrulan unun içerisine et suyu ve kremayı ilave edip karıştırın.\r\nArdından hardal, tuz ve karabiberi ilave edip karıştırın.\r\nHazır olan sosun içerisine köfteleri ekleyin ve her taraflarını sosa bulayın.\r\nKöftelerin üzerine dilimlediğiniz bayat ekmekleri dizin.\r\nÜzerine rendelenmiş kaşar peyniri serpiştirin ve 180 derecede önceden ısıtılmış fırında peynirler eriyene kadar pişirin.\r\nFırından çıkardığınız köftelerin üzerine ince kıyılmış maydanoz ekleyin ve sıcak servis edin." },
                    { 7, "Tugay", "tugay@gmail.com", "1 sıcak su dolu bardağa 1 tutam tel safran atın ve safranın renk vermesi için kenara alın.\r\nİri kuşbaşı doğradığınız etleri bir karıştırma kabına alın.\r\nİçerisine un, tuz ve karabiberi ekleyin.\r\nUn, etin her yerine kadar elinizle karıştırın.\r\n\r\nTencerenizi ocağa alın ve zeytinyağı ilave edip ısıtın.\r\nIsınan yağın içerisine etleri ekleyin ve bir tarafı altın rengi alana kadar pişirin.\r\nEtlerinizin bir tarafı pişince diğer tarafını çevirin ve pişirmeye devam edin.\r\nEtler iyice renk alınca piyazlık doğradığınız soğan ve ince verev dilimlediğiniz yeşil biberi ilave edip pişirmeye devam edin.\r\nRendelenmiş zencefil, tuz ve karabiberi ilave edip karıştırın.\r\nSafranlı su ve et suyunu ilave edip yüksek ateşte kaynamaya bırakın.\r\nTenceredeki et suyu kaynayınca altını kısın ve kısık ateşte tencerenin ağzı kapalı olacak şekilde 1 saat pişirin.\r\n\r\n1 saat sonra tencerenin kapağını açın ve bir tur karıştırın.\r\nLimon suyu, havanda dövdüğünüz kişniş, ortadan ikiye kestiğiniz kuru kayısı ve ince verev dilimlediğiniz yeşil biberi ilave edip 15 dakika daha pişirin.\r\nPişen etinizi 10 dakika dinlendirin ve sıcak servis edin." },
                    { 8, "Berkay", "berkay@gmail.com", "Soğanı küp şeklinde doğrayıp kıyma ile birlikte tavaya alın. Üzerine zeytinyağı gezdirip orta ateşte kavrulmaya bırakın.\r\nDomatesleri mutfak robotunda püre haline getirip kavrulmuş kıymaya ekleyin. Salça ve biber sosunu ilave edin.\r\nKısık ateşte suyunu çekinceye kadar pişirin. Biberleri küp şeklinde doğrayıp ayrı bir tavada az zeytinyağı ile soteleyin.\r\nKıymaya ekleyin. Tuz ve baharatlarla tatlandırın. Birkaç dakika pişirip ocaktan alın. Taco kabuklarını fırında ısıtın.\r\nKıyma karışımını içlerine doldurun ve üzerlerine kıyılmış maydanoz serpiştirerek servis yapın. Afiyet olsun." },
                    { 9, "Berkcan", "berkcan@gmail.com", "Düdüklü tencerenizi ocağa alın ve ısıtın.\r\nTereyağı ve zeytinyağı ilave edip tereyağını eritin.\r\nİri kuşbaşı doğradığınız etleri ilave edip birkaç tur karıştırın.\r\nArpacık soğanları ilave edip kavurun.\r\nDomates salçası ve unu ilave edip kokuları çıkana kadar kavurun.\r\nTuz, karabiber, taze kekik, havanda dövülmüş tane kişniş, nar ekşisi, su ve defne yaprağını ilave edip karıştırın.\r\nTencerenizin kapağını kapatın ve 30 – 40 dakika pişirin.\r\nPişen etlerinizi ocaktan alın ve içerisine nar tanelerini ilave edip karıştırın.\r\nServis ederken kalan nar tanesi ve taze soğanın yeşil kısımlarını ince kıyıp süsleyin.\r\nSıcak servis edin." },
                    { 10, "Hasan", "hasan@gmail.com", "Marinasyon sosunun tüm malzemeleri güzelce karıştırıp etleri bu sosla 1 gece önceden ovup 1 gün kadar buz dolabında sosun içinde bekletin.\r\nZamansız yoksa 3-4 saat de yeterli olacaktır.Zeytinyağını tavaya alıp kızdırın.\r\nİçerisine piyazlık doğranmış soğan ile julyen doğranmış biberleri ekleyin ve çok öldürmeden pişirin.\r\nHafif diri kalmaları gerekiyor. Ocaktan almaya yakın soya sosunu ekleyip bir iki kez çevirdikten sonra altını kapatın.(Ben sebzeleri diri seviyorum çok kısa süre ocakta pişirdim. )\r\nAyrı bir tavayı çok iyi ısıtın. Etleri ısınan tavaya alıp mühürleyin ve yüksek ateşte ara ara ters yüz ederek çok kurutmadan pişirin.\r\nEtler pişerken tadını alması için tortilla ekmeklerini üstüne bastırabilirsiniz.\r\nEn son etleri sebzeler ile harmanlayın ve sıcak sıcak servis edin. Deneyecek olanlara şimdidenafiyet olsun" },
                    { 11, "Aygül", "aygul@gmail.com", "Parçalayıcınızın haznesine küp doğradığınız tavuk etini alın ve çekmeye başlayın.\r\nYumurtaları ilave edip çekmeye devam edin.\r\nUnu ilave edip hafif katı bir harç elde edin.\r\nZeytinyağı, tuz ve karabiberi ilave edip iyice çekin.\r\nNOT : Hafif ele yapışan bir harç elde edeceksiniz.\r\nBir kasenin içerisine su ilave edin ve elinizi ıslatarak hazırladığınız harçtan ceviz büyüklüğünde parçalar kopartıp dikdörtgen şekil verin.\r\nGeniş bir tavanın içerisine ayçiçek yağı koyup ısınmaya bırakın.\r\nUn, galeta unu ve yumurtayı ayrı ayrı tabaklara koyun.\r\nHazırladığınız tavukları sırasıyla un, yumurta ve galeta ununa bulayın.\r\nIsınan yağa alın ve arkalı önlü kızartın.\r\nKızaran nuggetleri havlu kağıt serdiğiniz tabağa alın ve fazla yağını bırakmasını sağladıktan sonra servis edin." },
                    { 12, "Nesrin", "nesrin@gmail.com", "Tavanızı ocağa alın ve zeytinyağı ilave edip ısıtın.\r\nIsınan tavanızın içerisine iri küp doğradığınız patlıcan, kabak ve patatesi ilave edip soteleyin.\r\nSotelenen sebzeleri bir tabağa çıkartın.\r\nBir karıştırma kabının içerisine zeytinyağı, soya sos, domates salçası, biber salçası, tuz, karabiber ve kuru kekiği ilave edip bir çırpma teli yardımıyla karıştırın.\r\nİri küp doğradığınız tavukları sosun içerisine alın ve iyice harmanlayın.\r\nTavukları sosuyla beraber sebzeleri sotelediğiniz tavaya alın ve soteleyin.\r\nSotelenen tavukların içerisine arpacık soğan, bezelye, sarımsak ve çekirdekleri çıkartılmış zeytini ilave edip karıştırın.\r\nHazır olan tavuklu karışımı sebzeli karışıma ekleyin ve harmanlayın.\r\nİri dövülmüş cevizi ilave edip karıştırın.\r\nDikdörtgen kestiğiniz fırın kağıdını tezgaha koyun.\r\nFırın kağıdının ortasına hazırladığınız iç harçtan koyun.\r\nİki geniş kenarından katlayın ve kısa kenarlarını altına doğru kıvırarak fırın tepsisine dizin.\r\n180 derecede önceden ısıtılmış fırında 30 dakika pişirin.\r\nHazırladığınız tavuğu 5 – 10 dakika dinlendirin ve sıcak servis edin." },
                    { 13, "Neslihan", "neslihan@gmail.com", "Tavuk için;\r\nTencerenizi ocağa alın.\r\nSu, tane karabiber, dörde bölünmüş soğan, kereviz sapı, tavuk baget ve tuzu ilave edip tavuklar haşlanana kadar pişirin.\r\nPişen tavuklarınızı didikleyin ve bir karıştırma kabının içerisine alın.\r\nİçerisine haşlanmış nohut ve birkaç kaşık tavuk suyundan ekleyip karıştırın.\r\n\r\nTabanı için;\r\nTavanızı ocağa alın ve ısıtın.\r\nTereyağını ilave edip eritin ve küp doğradığınız pideleri ekleyip kavurun.\r\n\r\nDomates sosu için;\r\nBir sos tenceresinin içerisine zeytinyağını ilave edip ısıtın.\r\nİnce yemeklik doğradığınız soğanı ilave edip yumuşayana kadar soteleyin.\r\nSalçayı ilave edip kavurun.\r\nTavuğu haşladığınız sudan ilave edin ve karıştırarak salçayı açın.\r\nRendelediğiniz domatesi ilave edip karıştırın.\r\nKuru nane, kuru kekik, tuz ve karabiberi ilave edip karıştırın\r\n10 dakika kaynamaya bırakın.\r\n\r\nYoğurt için;\r\nBir karıştırma kabının içerisine süzme yoğurt ve ezilmiş sarımsağı alıp karıştırın.\r\n\r\nBirleştirmek için;\r\nPidelerinizi servis tabağınızın tabanına dizin.\r\nÜzerine hazırladığınız domates sosunu gezdirin.\r\nDomates sosunun üzerine hazırladığınız yoğurdu gezdirin.\r\nYoğurdun üzerine didiklediğiniz tavukları koyun.\r\nÜzerine kuru nane serperek servis edin." },
                    { 14, "Fatma", "fatma@gmail.com", "Patlıcanı alacalı soyarak küçük küçük doğrayın ve sıvı yağ ile kızartın.\r\nSüzgece alarak yağının süzmesi bekleyin bu arada tavukları soteleyin.\r\nTavukları kuş başı doğrayın, tencereye alarak arada karıştırarak pişirin.\r\nRengi dönüp suyunu saldığında yemeklik doğranmış soğanı ekleyin.\r\nSoğanlar yumuşadıktan sonra salçayı ve isteğe bağlı kullanacaksanız eğer ketçabı ilave edin.\r\nKapağını kapatarak 4-5 dk. kadar pişmeye bırakın.\r\nSuyunu çektikten sonra bezelye ve patlıcanı ilave edin.\r\nBaharatları da ekleyerek 3-4 dk. daha pişirin.\r\nTavuklar da artık pişmiş olmalılar.\r\nBeşamel sos için, tereyağını eritin ve unu kokusu çıkana kadar kavurun.\r\nÜzerine sütü ilave ederek çırpıcı yardımı ile topak kalmayacak şekilde koyulaşıp göz göz olana kadar karıştırarak pişirin.\r\nSon olarak tuzunu ilave ederek ocaktan alın.\r\nKüçük bir kaseye 4’e böldüğünüz yufkadan serin.\r\nYufkanın kenarlarından parçalar kopartarak çukur olan kısma bir kat daha serin.\r\nKaseye tavuklu harçtan koyarak, kasenin kenarlarından sarkan yufkaları üzerine kapatın.\r\nYağlanmış fırın kabına ters çevirin.\r\nTüm malzemeyi bu şekilde yaptıktan sonra üzerleri beşamel sostan her birine eşit miktarda olacak şekilde dökün.\r\n190 derece fırında yufkalar pembeleşene kadar pişirin.\r\nSonra üzerine kaşar peyniri rendesi serpin ve tekrar fırına sürün.\r\nPeynirler eriyip kızardığında alabilirsiniz.\r\nNot: Sadece tavuk göğsü ile de yapabilirsiniz ama ben göğüs eti kuru olduğu için sote yaparken ya pirzola kullanıyorum ya da bu şekilde karıştırıyorum." },
                    { 15, "Arda", "arda@gmail.com", "Öncelikle iç pilavını hazırlamak için pilavlık pirinçler bir kaba alınır.\r\nÜzerini geçecek kadar ılık su ve tuz eklenerek 20 dakika bekletilir. Daha sonra bol su ile yıkanarak pişirme aşamasına geçilir.\r\nPilavı pişirmek için öncelikle pilav tenceresine tereyağı ve sıvı yağ alınır. Ben tereyağı ve sıvı yağı karışık kullanıyorum, çünkü hem tereyağının lezzetini seviyorum, hem de sıvı yağın parlaklık verdiğini düşünüyorum.\r\nYağlar eriyince suyu süzülen pirinçler eklenerek kavrulur.\r\n2-3 dakika kavrulduktan sonra dolmalık fıstıklar ve kuş üzümleri ilave edilir. Beraber bir iki defa karıştırılarak kavrulur.\r\nÜzerine 2 su bardağı sıcak su ilave edilir. Tuzu ayarlanır. Tencerenin kapağı kapatılarak pişmeye bırakılır.\r\nPilav suyunu çekinceye kadar pişirilir. Bu ölçüdeki pirinç için suyu bilerek az kullanıyoruz, pilavımız biraz diri kalacak.\r\nSon olarak ocaktan alınır ve tarçın ve karabiber eklenerek nazikçe karıştırılır.\r\nDiğer taraftan bütün tavuğumuz yıkanır ve varsa tüyleri ütülenir. Bu tarifte organik tavuk kullandım. Eğer bulabilirseniz köy tavuğu daha geç pişer ama daha sağlıklı ve lezzetli olacaktır, tavsiye ederim.\r\nTavuğun içi fazla bastırmadan pilavla doldurulur. Çok sıkıştırırsanız pilavınız hamur olabilir.\r\nTavuğun ayakları ya derisinden geçirilerek sıkıştırılır veya mutfak ipi ile bağlanır, böylece pişerken açılması önlenmiş olur.\r\nBir kasede sos malzemeleri karıştırılır ve fırça ile tavuğun her yerine gelecek şekilde sürülür.\r\nFırın torbasına un alınır. Poşet çevrilip sallanarak unun her yerine gelmesi sağlanır.\r\nArdından sosladığımız tavuğu poşetin içerisine dikkatli bir şekilde yerleştirelim. Garnitür olarak tavuğun yanına arpacık soğan, patates, havuç, ince kesilmiş limon dilimleri ve birkaç yaprak defne kullandım.\r\nPoşetin ağzını kapattıktan sonra bir kürdanla poşetin üzerine delikler açalım.\r\nTavuğumuzu önceden 190 dereceye ısıttığımız fırında 60 dakika boyunca pişmeye bırakalım.\r\nTencerede kalan pilava sıcak su ilave ederek pişirmeye devam edelim.  Tekrar suyunu çektiğinde üzerine bir havlu kağıt kapatarak  demlenmeye bırakılır.\r\n60 dakikanın sonunda tavuğu fırından alalım. Üzerindeki poşeti açarak fanlı ayarda 10 dakika daha pişirelim. Sürenin sonunda nar gibi kızaran nefis tavuk dolmamız servise hazır.\r\nİç pilavlı tavuk dolması nasıl servis edilir? Ben genişçe bir servis tabağının tabanına demini alan pilavı yayarak tavuk için bir yatak oluşturdum ve fırından çıkan tavuğu pilavın ortasına yerleştirdim. Pişen sebzelerimi de gelişigüzel pilavın üzerine serpiştirdim, tercih sizin, şimdiden afiyet olsun." },
                    { 16, "Eyşan", "eysan@gmail.com", "Taze soğan maydanoz ve taze naneyi bıçak yardımı ile iyice ince ince kıyın. Karanfil ve susamı havanda dövün. Çok kuru olmaması için içerisine 1 yemek kaşığı zeytinyağı ekleyin. İyice kıydığınız taze otları tuz, karabiber ve havanda dövdüğünüz karanfil susam karışımı ile lezzetlendirin.\r\n\r\nTemizlenmiş ve kılçıklarından arındırılmış hamsilerin birinin üzerine bu hazırladığınız harçtan sürüp diğer bir hamsiyi üzerine kapatın.\r\n\r\nTüm hamsileri bu şekilde hazırladıktan sonra mısır ununa bulayıp bir tavada kızdırdığınız sığ yağda kızartın. Dilerseniz hamsilerin içlerini boş bırakıp, sadece tuz karabiber ile tatlandırarak da kızartabilirsiniz.\r\n\r\nKızarttığınız hamsileri havlu peçete olan bir tabağa aktarın ve fazla yağından arındırıp, roka, limon ve soğan ile servis edin." },
                    { 17, "Junior", "junior@gmail.com", "Somon için;\r\nTavanızı ocağa alın ve ekmek kırıntısını içerisine alıp rengi hafif dönene kadar kavurun.\r\nİçerisine tereyağını ilave edip eritin.\r\nArdından ince kıyılmış sarımsak ve fesleğeni ilave edip karıştırın.\r\n\r\nSomonlarınızın kenar kısmında kalan hafif yağlı kısımlarını bıçağınızla kesin.\r\nAma derisi üzerinde kalsın.\r\nBir tavayı ocağa alın ve ısıtın.\r\nİçerisine somonlarınızın derili kısımlarını yerleştirin ve hafif çıtırlaşana kadar pişirin.\r\nArdından etli kısımlarını hazırladığınız ekmek kırıntılı harca batırın.\r\nCam fırın kabınızın içerisine somonlarınızı ve kenarlarına ortadan ikiye böldüğününüz domatesleri yerleştirin.\r\n180 derecede önceden ısıtılmış fırında 20 dakika pişirin.\r\n\r\nPesto sos için;\r\nFesleğen, maydanoz, fındık, sarımsak, tuz ve karabiberi parçalayıcının içerisine alın ve iyice çekin.\r\nArdından parçalayıcının üst haznesinden toz parmesanı ekleyin ve çekin.\r\nZeytinyağını yine üst hazneden yavaş yavaş ekleyin ve her şey birbiriyle iyice karışana kadar çekmeye devam edin.\r\n\r\nBirleştirmek için;\r\nPişen somonunuzu servis edeceğiniz tabağa alın ve yanına pişirdiğiniz domatesleri ilave edin.\r\nSomonunuzun üzerine pesto sos gezdirerek servis edin." },
                    { 18, "Isaac", "isaac@gmail.com", "Ayıklanmış hamsilerin orta kılçıklarını çıkartın.\r\nBol suda iyice yıkayıp süzgece alın ve fazla suyunun süzülmesini sağlayın.\r\n\r\nPilav için;\r\nKuş üzümünü bir kaseye alın ve üzerine sıcak su ilave edip bekletin.\r\nPilav tenceresine zeytinyağını koyun.\r\nİnce yemeklik doğranmış soğanları ilave edip yumuşayana kadar soteleyin.\r\nPirinci ilave edip kavurmaya devam edin.\r\n\r\nTuz, karabiber, kuru nane, yenibahar, suyunu süzdüğünüz kuş üzümü, toz şeker ve defne yaprağını ilave edip bir iki tur karıştırın.\r\nSuyunu ilave edin ve tencerenizin kapağını kapatıp kısık ateşte pişmeye bırakın.\r\nDereotunu ince ince kıyın ve pişen pilava ilave edip bir tur çevirin.\r\nDemlenmeye bırakın.\r\nDefne yaprağını pilavdan çıkartın.\r\n\r\n30 cm. çapında yuvarlak alüminyum kabınızı tereyağı ile yağlayın.\r\nHamsilerin derili kısımları alta gelecek şekilde sırt sırta dizin, hafif birbirlerinin üzerine gelmesine dikkat edin.\r\nKabınızın taban kısmını da hamsiyle iyice kapatın.\r\nTuz ve karabiber serpiştirin.\r\nİçine hazırladığınız pilavdan koyun ve kenarlardan sarkan hamsilerle iyice kapatın.\r\nPilavın üzerini de hamsiyle kapatın.\r\nHamsilerin üzerine tuz, karabiber serpin ve limon dilimlerini dizin.\r\n\r\nÜzerine küçük parçalar halinde tereyağı bırakın ve 180 derecede önceden ısıtılmış fırında 30 – 35 dakika üzeri kızarana kadar pişirin." },
                    { 19, "Kahn", "kahn@gmail.com", "Somon için;\r\n1 adet haşlanmış pancarı rendeleyin.\r\nSuyunu bir tülbent yardımıyla sıkın, posasını atın, suyunu karıştırma kabına ilave edin.\r\nÜzerine toz şeker ve tuzu ilave edin.\r\nLimonun kabuğunu rendeleyin.\r\nLimonun suyunu sıkın.\r\nRezenenin kök kısmını ince ince doğrayın.\r\nSomonunuzu yıkayın ve kurulayın.\r\nSomonunuzu küçük küp olacak şekilde doğrayın.\r\nSebzelerin olduğu karıştırma kasesine somonları ekleyin, karıştırın ve 15 dakika bekletin.\r\n\r\nSalata için;\r\nKinoanınızı bir sos tenceresine ekleyin ve üzerine suyunu ilave edip, kaynatın.\r\nKırmızı soğanı ince doğrayın.\r\nSalatalığın çekirdeklerini çıkartın, küçük küp doğrayın.\r\nBiberi küçük küp doğrayın.\r\nDomateslerin çekirdeklerini çıkartın ve küçük küp doğrayın.\r\nKereviz sapını ince ince doğrayın.\r\nMangonuzdan bir dilim kesin ve kabuklarını soyun.\r\nArdından küçük küp olacak şekilde doğrayın.\r\nNanelerinizi ince ince doğrayın.\r\nHepsini bir karıştırma kabına toplayın.\r\nHaşlanan kinoanızı salataya ekleyin.\r\nArdından lor peynirini de ekleyin ve karıştırın.\r\n\r\nSos için;\r\nBir karıştırma kabına toz şeker ve limon suyunu çırpın.\r\nŞeker hafif eriyince zeytinyağını ekleyerek çırpmaya devam edin.\r\n\r\nAvokado için;\r\nAvokadonuzun kabuğunu soyun.\r\nKüçük küpler halinde doğrayın.\r\nHazırladığınız sostan 2 yemek kaşığı avokadonuzun üzerine gezdirin." },
                    { 20, "Lionel", "lionel@gmail.com", "Karidesleri, ince bir fileto ya da carving bıçağı ile karın kısımlarındaki zarı , içindeki etli bölümü zedelemeden keserek işe başlayın. Kuyruga kadar itina ile zarı kestiginize emin olun Daha sonra işaret parmagınız ile kafasının arkasındaki kabugun kafaya birleşme yerinden , dış kabugu çıtlatın. Parmağınız ile bütün sırtındaki kabuk boyunca , kuyruguna kadar kabugu zedelemeden aşağı kadar inerek kabugu koparmadan etli yuzeyden ayırın. Aynı fileto ya da carving bıçağı ile karidesleri sırt kısmına kafadan başlayıp kuyruga kadar bir derin çizik atın. Karidesin iç organları ve pisligi bu kısımda bulunur ve bu kısmın mutlaka cıkartılması gerekir. Bu kısmı çıkarttıktan sonra kafa kısmındaki diger organlarını da bir çay kaşığı ile temizleyin Bütün karidesi yıkayın ve tekrar kabuğunu etli kısmın üstüne kapatın Bir tavaya kaya tuzunu bir kat olarak serin ve altını harlı ateşte ısıtmaya başlayın. Tuz ısınınca karidesleri (kabukları üzerinde olacak) tuzun üstüne yerleştirin her iki tarafını da cevirerek, 5-6 dakika kadar pişirin İstediğiniz bahçe yeşillikleri üzerinde kabuğu ile servis edin." },
                    { 21, "Staphen", "staphen@gmail.com", "Asma yapraklarını salamura kullanıyorsanız, sadece sıcak suda bekletip tuzunu alın.\r\nTaze asma yaprağı kullanıyorsanız, suda yıkayıp haşlayın.\r\n\r\nPilav için;\r\nPirinci nişastası çıkıncaya kadar yıkayıp süzün.\r\nGeniş bir tencereyi ocağa alın, içerisine zeytinyağını alın ve kızdırın.\r\nDolmalık fıstığı, tencereye ekleyip hafif renk alana kadar kavurun, soğanı ilave ederek kavurmaya devam edin.\r\nSoğanlar yumuşayınca yıkanmış pirinci ekleyin, şeffaflaşana kadar kavurmaya devam edin.\r\nTuz, karabiber, tarçın, yenibahar ve kuru naneyi ekleyip karıştırın.\r\nPirincin üzerine 1 su bardağı vişne suyu, 1 su bardağı su, 1 yemek kaşığı nar ekşisi, 1 yemek kaşığı toz şeker ve kuş üzümünü ekleyin, bir tur karıştırın.\r\n\r\nPilavın suyu kaynadıktan 5 dakika sonra ocaktan alın ve soğumaya bırakın.\r\n\r\nSarmak için;\r\nTencerenin dibine asma yapraklarından bir taban yapın.\r\nAsma yapraklarına uygun miktarda harç ve birer adet vişne koyup, kenarlarını ortaya katlayarak parmak kalınlığında sarın.\r\nHazırladığınız sarmaları, asma yapraklarının üzerine dizin.\r\nKalan vişneleri aralarına serpiştirin.\r\nÜzerine 1 – 1,5 su bardağı su, vişne suyu ve 4 – 5 yemek kaşığı zeytinyağı ekleyin.\r\nÜzerlerine porselen bir tabak koyup tencerenin kapağını kapatın.\r\nÇok kısık ateşte yaklaşık 35 – 40 dakika pişirin.\r\n\r\nKendi tenceresinde oda sıcaklığına gelmesini bekleyin.\r\nIlık ya da soğuk servis edin." },
                    { 22, "Leo", "leo@gmail.com", "Bir karıştırma kabına su ve un ilave edip ayıkladığınız baklaları içerisine alın.\r\nDiğer malzemeler hazırlanana kadar bekletin.\r\nTencerenizi ocağa alın ve ısıtın.\r\nIsınan tencerenin içerisine zeytinyağı ince yemeklik doğradığınız soğanları ilave edip yumuşayana kadar kavurun.\r\nKavrulan soğanın içerisine suda beklettiğiniz baklaları ilave edin.\r\nTuz, karabiber, toz şeker ve un serpip karıştırın.\r\nArdından suyunu ilave edin ve orta ateşte 20 dakika pişirin.\r\nPişen baklanızı ocaktan alın ve tencerede soğumaya bırakın.\r\nSoğuyan baklanızı servis tabağına alın ve üzerine ince doğradığınız dereotu serpin.\r\nYanına yoğurtla servis edin." },
                    { 23, "Jack", "jack@gmail.com", "Soğanlarınızı küçük küpler olacak şekilde doğrayın.\r\nGeniş pilav tencerenizi ocağa alın ve ısıtın.\r\nZeytinyağını ilave edip soğanlar yumuşayana kadar pişirin.\r\nSoğanlarınız hafif yumuşayınca iç baklaları tencereye ilave edin ve hafif soteleyin.\r\nİçerisine sarımsak, tuz, beyaz biber ve toz şekeri ilave edin.\r\nEnginarları soğanlı harcınızın üzerine dizin.\r\nLimon suyu ve suyu ilave edip kısık ateşte pişmeye bırakın.\r\nPişen iç baklalı enginarınızı ocaktan alın ve tencerede hafif soğutun.\r\nHazır olan enginarlarınızı servis edeceğiniz tabağa alın.\r\nDereotlarınızı ince kıyın ve soğanlı ve iç baklalı harcın içerisine alıp karıştırın.\r\nEnginarların iç kısımlarına soğanlı ve iç baklalı harçtan doldurun.\r\nÜzerinden suyunu ve zeytinyağını gezdirin." },
                    { 24, "Mahi", "mahi@gmail.com", "Baklayı 1 gece önceden soğuk suda ıslatın.\r\nSoğanı iri iri doğrayın. Bir tencereye zeytinyağını ekle ve ısınınca soğanları ekleyip biraz kavurun, ardından bakla, şeker, tuz, dereotunun yarısı, üzerini 4 parmak geçecek kadar su koyarak tüm malzemeler iyice yumuşayıncaya ve içerisinde hiç sıvı kalmayıncaya kadar pişirin.\r\nFavanın çok sulu olmaması için suyunu çekmesi gerekir. Tenceredeki malzeme lapa kıvamında olmalıdır. Hazır hale geldiğinde el mikseriyle bütün malzemeyi çekin ve soğuması için kenara alın.\r\n\r\nEnginar için;\r\n\r\nSoğanı yemeklik doğrayın. Tencereye zeytinyağını ilave edin ısınınca soğanları ekleyin ve kavurun.\r\nSoğanlar yumuşayınca enginarları ekleyin. Bir portakalın suyunu ve içindeki parçacıklarını ekleyin. Tuz, şeker ve su ekleyip kapağını kapatın. Enginarlar pişince tencereyi kenara alın.\r\n\r\nEnginarlar soğuyunca içlerine fava doldun. Enginarın içinde piştiği portakallı sostan üzerlerine gezdirin ve dereotu yaprakları serperek servis edin." },
                    { 25, "Sevinç", "sevinc@gmail.com", "Patlıcanlar için;\r\nPatlıcanlarınızın baş ve uç kısımlarını kesin.\r\nOrtadan ikiye bölün ve kızgın zeytinyağında patlıcanları bütün olarak önlü arkalı yumuşayıncaya kadar kızartın.\r\nHepsini kızarttıktan sonra kağıt havlunun üzerine alın.\r\n\r\nİç harcı için;\r\nSoğanları piyazlık doğrayın.\r\nSarımsakları boyundan ikiye bölün.\r\nBiberleri ince doğrayın.\r\nTavanızı ocağa alın, zeytinyağını ekleyip ısıtın.\r\nIsınan yağınızın içerisine soğanınızı ekleyin ve hafif yumuşayana kadar soteleyin.\r\nSotelenen soğanınızın içerisine sarımsak, biber ve sebzelerinizin kolay sotelenmesi için birazcık tuz ekleyip sotelemeye devam edin.\r\nDomateslerinizin kabuklarını soyun.\r\nDomateslerinizin çekirdeklerini çıkartın ve küçük küpler halinde doğrayın.\r\nSoğanlarınıza tuz ve karabiberi ekleyip karıştırın.\r\nDomatesi ekleyin ve sotelemeye devam edin.\r\nToz şekeri içerisine ekleyin ve karıştırın.\r\nMaydanozu ince ince doğrayın ve sotelenen sebzelerinizin içerisine alıp ocaktan alın.\r\n\r\nBirleştirmek için;\r\nPatlıcanları tencereye dizin.\r\nOrtalarını, bıçak yardımıyla çizgi şeklinde açın, kaşıkla genişletin, tabana kadar inmemeye özen gösterin.\r\nİçlerine biraz toz şeker, tuz ve karabiber serpip hazırladığınız harçtan doldurun.\r\nTavada kalan domatesli suyu (domatesin suyu kalmadıysa 2-3 yemek kaşığı suyu) tencerenin üzerine dökün.\r\nÜzerine zeytinyağı ve su gezdirin.\r\nKapağı kapalı olarak 20 – 25 dakika pişirin.\r\n\r\nNot: Eğer kızartma yapmak istemezseniz, her şeyi çiğ olarak, aynı metotla, pişirme süresini 1 saat civarında arttırarak yapabilirsiniz." },
                    { 26, "Mutlu", "mutlu@gmail.com", "Nohudu bir karıştırma kabının içerisine alın ve üzerine su ilave edip 1 gece bekletin.\r\nParçalayıcınızın haznesine beklettiğiniz nohutları alın.\r\nÜzerine kabaca doğradığınız soğan, sarımsak, maydanoz ve kişnişlerin yaprak kısımlarını alın.\r\nTuz, karabiber, kimyon ve pul biberi ilave edip her şeyi biraz pütürlü kalacak şekilde parçalayıcıdan geçirin.\r\nNOT : Tamamen püre olmamasına dikkat edin.\r\nBu karışıma 2 – 3 yemek kaşığı un ekleyin ve yoğurun.\r\nElde ettiğiniz karışımdan ceviz büyüklüğünde toplar yapın.\r\nTavanızı ocağa alın ve ayçiçek yağı ilave edip ısıtın.\r\nIsınan yağın içerisine falafelleri alın ve kızartın.\r\nKızaran falafelleri bir havlu kağıdın üzerine çıkartın ve fazla yağından süzdürün.\r\n\r\nSosu için;\r\nBir karıştırma kabının içerisinde süzme yoğurt, tahin ve limon suyunu karıştırın.\r\nZeytinyağını ilave edip karıştırmaya devam edin.\r\n\r\nServis etmek için;\r\nDomateslerinizi ortadan ikiye bölün ve bir karıştırma kabına alın.\r\nÜzerine bebek roka, tuz, karabiber ve zeytinyağı gezdirip harmanlayın.\r\nHazırladığınız salatayı servis edeceğiniz tabağın tabanına alın.\r\nOrta kısmını hafif boş bırakın ve hazırladığınız yoğurtlu sosu salatanızın ortasına yerleştirin.\r\nYoğurdun üzerine ve kenarlarına kızarttığınız falafelleri yerleştirin." },
                    { 27, "Kadir", "kadir@gmail.com", "Tavanızı ocağa alın ve ısıtın.\r\nIsınan tavanızın içerisine bademlerinizi alın ve renk alana kadar kavurun.\r\nSemizotlarınızı yapraklarını ayırın ve yıkayıp fazla suyundan arındırın.\r\nSemizotlarınızı bir karıştırma kabına alın ve üzerine çok hafif zeytinyağı, tuz ve karabiber ilave edip iyice harmanlayın.\r\nŞeftalinizi elma dilim olacak şekilde kesin.\r\nİzli tavanızı ocağa alın ve ısıtın.\r\nIsınan izli tavanızın içerisine dilimlediğiniz şeftalileri alın ve iz alana kadar pişirin.\r\nSemizotlarınızın içerisine elinizle parçaladığınız keçi büş peynirini ve kavurduğunuz bademleri ilave edip harmanlayın.\r\nServis tabağınızın kenarlarına iz verdirdiğiniz şeftalileri dizin.\r\nSemizotunu şeftalilerin ortasına yerleştirin.\r\nHafif zeytinyağı gezdirerek servis edin." },
                    { 28, "İsa", "isa@gmail.com", "Sultaniye üzümlerini sıcak suda bekletin.\r\nMor lahananızı ortadan ikiye kesin.\r\nKök kısmı altta kalacak şekilde lahananızı tezgaha koyun ve ince ince dilimleyin.\r\nDilimlediğiniz lahanayı bir karıştırma kabına alın ve 1 yemek kaşığı tuzla iyice ovun.\r\nHavucu rendeleyin.\r\nSalatalıkların sadece dış taraflarını rendeleyin, çekirdekli kısımlarını rendelemeyin.\r\nBir tülbent yardımıyla lahana, salatalık ve havucun suyunu sıkın.\r\nKırmızı soğanı ufak ufak doğrayın.\r\nLahana ve salatalığı bir tülbent yardımıyla iyice sıkın.\r\nLime’nin kabuğunu rendeleyin.\r\nKişnişi saplarından ayırın ve ince kıyın.\r\nCevizi iri kıyın.\r\nSultaniye üzümün suyunu süzün.\r\nDoğradığınız her şeyi bir karıştırma kabında karıştırın.\r\n\r\nSosu için;\r\nSos için olan tüm malzemeleri karıştırın ve hazırladığınız salatayla karıştırıp, servis edin." },
                    { 29, "Musa", "musa@gmail.com", "Tüm malzemeleri dilediğiniz gibi doğrayıp bir kâseye alın.\r\n\r\nSos için yoğurt, limon suyu, tuz ve zeytinyağını karıştırın ve salatayla birleştirip servis edin." },
                    { 30, "Murat", "murat@gmail.com", "Ispanak kökünü diri kalacak şekilde tuzlu suda haşlayın ve buzlu suyun içine çıkararak şoklayın.\r\n\r\nBir kâsede ezilmiş sarımsak, süzme yoğurt, limon suyu, tuz, karabiber, pul biber ve zeytinyağını çırpın.\r\n\r\nIspanak köklerini servis kâsesine alın. Üzerine hazırladığınız sostan gezdirin ve küçük doğradığınız domatesleri serpiştirerek servis edin." },
                    { 31, "Cenk", "cenk@gmail.com", "Tabanı için;\r\nBir karıştırma kabının içerisine granül kahve, sıcak su ve vanilya özütünü alıp karıştırın.\r\nKedi dillerinizi hazırladığınız sıvı karışımın içerisine batırıp çıkartın ve servis edeceğiniz kuplara dikine yerleştirin.\r\n\r\nArası için;\r\nMuzlarınızı kabuklarıyla birlikte dikine ortadan ikiye bölün.\r\nİzli tavanızı ocağa alın ve ısıtın.\r\nİkiye böldüğünüz muzları ısınan tavanıza alın ve iyice karamelize olana kadar pişirin.\r\nPişen muzlarınızı tezgaha alın ve doğrayın.\r\nKuplarınızın tabanına doğradığınız muzları ilave edin.\r\n\r\nMuhallebi için;\r\nBir tencerede tereyağını eritin.\r\nTereyağı eriyince unu ilave edip renk alana kadar kavurun.\r\nArdından sütü ilave edip sürekli karıştırarak kaynatın.\r\nSüt kaynayınca şeker ve dövülmüş damla sakızını ilave edin, iyice karıştırın, kaynamaya başlayınca altını kapatın.\r\nHazır olan muhallebinizi kuplarınıza pay edin.\r\nÖnce oda sıcaklığında ardından buzdolabında soğutun.\r\nSoğuttuğunuz muhallebinizin üzerine kakao serperek servis edin." },
                    { 32, "Ceren", "ceren@gmail.com", "Damla sakızını buzlukta soğuttuktan sonra bir dövücü yardımıyla toz haline getirin.\r\nPirinci yıkayın, süzün.\r\nKüçük sos tenceresinin içerisine 2,5 su bardağı süt ve pirinci ilave edin.\r\nKısık ateşte pirinçler yumuşayıncaya kadar haşlayın.\r\nKalan sütü tencereye ilave edin.\r\nNişasta, pirinç unu, toz şeker ve damla sakızını karıştırın.\r\nHaşladığınız pirinçleri bu karışıma ilave edin.\r\nSürekli karıştırarak kıvam alıncaya kadar pişirin.\r\nKıvam alan sütlaçlarınızı güveçlerinize pay edin.\r\nSütlaçlarınızı bir fırın tepsisine alın, tabanına az su koyun ve 180 derecede önceden ısıtılmış fırında üzeri kızarana kadar pişirin." },
                    { 33, "Cemile", "cemile@gmail.com", "Sosu için;\r\nTüm malzemeleri sos tenceresine ilave edip, karıştırın ardından ateşin üzerine alıp kaynayıncaya kadar karıştırarak pişirin.\r\nKenara alıp soğutun.\r\n\r\nKeki için;\r\nToz şeker ve yumurtaları rengi açılıncaya kadar çırpın.\r\nArdından sıvı yağ ve sütü ilave edip, çırpmaya devam edin.\r\nUn, kakao, kabartma tozu, vanilya ve limon kabuğunu ilave edip spatula ile karıştırın.\r\nKek hamurunu yağlanmış kek kalıbına dökün 180 derecede önceden ısıtılmış fırında 30 dakika pişirin.\r\n\r\nNot: Kullandığınız kek kalıbının genişlik ve derinliğine göre pişirme süresine dikkat ediniz. Biraz daha az veya fazla olabilir. Tarifte 30 cm. çaplı kalıp kullanılmıştır.\r\n\r\nKekiniz fırından çıktıktan sonra 5 dakika dinlendirip, dilimleyin.\r\nSoğuyan sosu kekin üzerine dökün ve soğuyuncaya kadar bekleyin.\r\nArdından servis edin." },
                    { 34, "Atatürk", "atatürk@gmail.com", "Kek için;\r\nTezgah üstü mikserinizi tezgahınızın üzerine alın.\r\nHaznesinin içerisine toz şeker, un, kakao, kabartma tozu, kabartma tozu, karbonat ve vanilyayı ekleyip her şeyi düşük devirde karıştırın.\r\nBir karıştırma kabında sıcak su ve granül kahveyi karıştırıp kuru malzemelerinizin içerisine ekleyin.\r\nArdından ayçiçek yağı, süt, yumurta ve tuzu ekleyip yüksek devirde her şey karışana kadar karıştırın.\r\n\r\nDikdörtgen fırın kabınızın tabanına fırın kağıdı serin, kenarlarını yağlayın.\r\nKek hamurunuz hazır olunca fırın kabınızın içerisine dökün ve 180 derecede önceden ısıtılmış fırında 25 dakika pişirin.\r\nKekiniz pişince soğumaya bırakın.\r\n\r\nKreması için;\r\nBir karıştırma kabının içerisine labneyi ekleyin.\r\nÜzerine pudra şekerini ilave edin ve bir spatula yardımıyla çok sulandırmadan karıştırın.\r\nHazırladığınız kremayı ucuna tırtıklı bir uç taktığınız sıkma torbasının içerisine ekleyin.\r\n\r\nBirleştirmek için;\r\nHafif soğuyan kekinizi iyice soğutmak için fırın kabından çıkartın ve ters çevirerek başka bir yağlı kağıdın üzerine alın.\r\nSoğuttuğunuz kekinizden 7 cm’lik bir çember yardımıyla küçük yuvarlaklar çıkartın.\r\nHazır olan keklerinizin tabanı olacak olan keklerinize hazırladığınız kremadan sıkın.\r\nArdından ince dilimlediğiniz çileklerinizi kremanın üzerine dizin.\r\nDiğer kekinizi üzerine yerleştirin.\r\nPastanızın üzerini dilediğiniz şekilde süsleyin." },
                    { 35, "Metehan", "metehan@gmail.com", "Pandispanya için;\r\nYumurta ve yumurta sarılarını toz şekerle birlikte iyice kıvam alıncaya kadar çırpın.\r\nAyrı bir kapta un, vanilya, kabartma tozu ve nişastayı eleyip yumurtalı karışıma spatula yardımı ile içten dışa doğru karıştırarak yedirin.\r\nLimon kabuğunu rendeleyin ve karışıma iyi yedirin\r\nAyrı bir kapta yumurta aklarını 1 yemek kaşığı toz şekerle beze kıvamına gelinceye kadar iyice çırpın ve unlu karışıma, bir spatula yardımı ile hamuru söndürmeden dikkatlice içten dışa doğru karıştırarak yedirin.\r\nFırın tepsinize yağlı kağıt serin, kaymaması için tabanını yağlayabilirsiniz ve pandispanya hamurunu tepsiye döküp, spatula yardımı ile dikdörtgen olacak şekilde yayın.\r\n220 – 230 derecede önceden ısıtılmış fırında 8 – 10 dakika pişirin.\r\nPandispanya fırından çıkmasına yakın tezgahınıza fırın kağıdı serip üzerine elekle pudra şekeri serpin.\r\nPandispanya fırından çıkınca ters çevirerek pudra şekeri serpişmiş kağıdın üzerine yerleştirin. Üstte kalan fırın kağıdını dikkatlice sıyırın ve pandispanyayı rulo yapıp kenara alın.\r\n\r\nLabneli katman için;\r\nDonuk meyve kullanıyorsanız bir eleğe alın ve bir kabın içerisine oturtun.\r\nSuyunu salması için kenara alın.\r\nAyrı bir kapta labne peynirini ve pudra şekeri bir spatula yardımıyla iyice karıştırın.\r\nArdından meyveler suyunu iyice süzünce hafif ezin ve peynirin içerisine alıp karıştırın.\r\nKarışım homojen bir kıvam alınca kenara alın.\r\nPandispanyanın üzerine labneli harcı yayın, rulo yapacağınız uç kısma kalan meyve tanelerini dizin ve rulo yapın.\r\n\r\nGanaj için;\r\nÇikolatayı benmari olacak şekilde eritin.\r\nİçerisine kremayı ekleyin ve ocaktan alıp karıştırın.\r\n\r\nBirleştirmek için;\r\nRulo pastayı bir telin üzerine alın ve üzerine hazırladığınız ganajı gezdirin.\r\nServis edeceğiniz tabağa alın ve üzerlerini vişne ve toz antep fıstığıyla süsleyerek servis edin." },
                    { 36, "Oğulcan", "ogulcan@gmail.com", "Tüm malzemeleri blendere alın, karıştırın ve soğuk servis edin." },
                    { 37, "Berkay", "berkan@gmail.com", "Limon ve portakalların kabuklarını bir kaba rendeleyin.\r\n\r\nÜzerine şeker ilave edin elinizle iyice ovun.\r\n\r\nArdından üzerine sıcak su döküp şeker eriyinceye kadar karıştırın.\r\n\r\nKabuklarını rendelediğiniz portakal ve limonların suyunu sıkıp şekerli karışıma ilave edin.\r\n\r\nLimonata özünü süzgeçten geçirin ve buzdolabında soğuttuktan sonra üzerine su ve nane yaprakları ilave edip servis edin." },
                    { 38, "Kanuni", "kanuni@gmail.com", "Tüm malzemeleri bir tencerenin içerisine alıp sürekli karıştırarak kaynatın ve kıvam aldıktan sonra bardaklara bölüştürüp, üzerine tarçın serperek servis edin." },
                    { 39, "Sherlock", "sherlock@gmail.com", "Fındığınızı çok toz haline gelmeden hafif çekin.\r\nMuzunuzu elinizle bölün ve bir karıştırma kabının içerisine alın.\r\nÜzerine fındıkları ekleyin ve bir parçalayıcı yardımıyla karıştırın.\r\nİçerisine bisküviyi alın ve karıştırmaya devam edin.\r\nHazırladığınız karışımın içerisine sütü ekleyin ve parçalayıcı yardımıyla karıştırmaya devam edin.\r\nHazırladığınız milkshake’inizi buzdolabına koyun ve soğutun.\r\nSoğuyan milkshake’inizi bardaklara pay edip, servis edin." },
                    { 40, "Grimm", "grimm@gmail.com", "Bir sürahiye 1 litre kaynamış su ekleyin.\r\nİçerisine 3 adet poşet siyah çay atın ve demlenmeye bırakın.\r\n2 adet limonun kabuğunu ince uzun parçalar olacak şekilde rendeleyin.\r\nArdından rendelediğiniz limonu ince dilimler olacak şekilde kesin.\r\nÇayınız demlenince poşet çayları içerisinden çıkarın.\r\nÇayınız hazır sıcakken içerisine rendelediğiniz limon kabuklarını ve limon dilimlerini ekleyin. Toz şekeri ve karanfili ilave edin, şeker tamamen eriyene kadar karıştırın.\r\nŞeker eriyince taze naneleri ekleyin.\r\nArdından yarım litre oda sıcaklığında su ve limon suyunu ekleyin.\r\nNot: Limon suyunu en son koymalısınız, yoksa buzlu çayınız biraz acımtırak olacaktır. Soğuması için biraz kenarda bekletin.\r\nArdından buzdolabına koyun ve soğumaya bırakın.\r\n\r\nNot: 2 – 3 gün buzdolabında saklayabilirsiniz!!" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c4f284fd-cc41-4064-a23e-5f5ce782b990", "2afa6ec0-272c-4e11-996d-ad81ab8fe55c" },
                    { "04ca83e0-307b-49c3-ab0b-a51e9d8df001", "e1e7cc21-3d85-4427-a9cb-1759e65c4439" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Confirmation", "Details", "FoodId", "Mail", "Name" },
                values: new object[,]
                {
                    { 1, false, "Bu yemek bir harika.", 1, "serhatkaya2496@gmail.com", "Serhat Kaya" },
                    { 2, false, "Bu yemek bir harika.", 2, "AliOnur25@gmail.com", "ALİ Onur" },
                    { 3, false, "Bu yemek bir harika.", 3, "r.bab96@gmail.com", "Ramazan Babayiğit" },
                    { 4, false, "Bu yemek bir harika.", 3, "seko94@gmail.com", "Serkan Kaya" },
                    { 5, false, "Bu yemek bir harika.", 4, "Aysegul86@gmail.com", "Ayşegül Karakaş" },
                    { 6, false, "", 6, "hziyausakligil@gmail.com", "Halit Ziya Uşaklıgil" },
                    { 7, false, "Bu yemek bir harika.", 10, "#oseyfettin@gmail.com", "Ömer Seyfettin" },
                    { 8, false, "Bu yemek bir harika.", 15, "ppicasso10@gmail.com", "Pablo Picasso" },
                    { 9, false, "Bu yemek bir harika.", 18, "alikoc@gmail.com", "Ali Koç" },
                    { 10, false, "Bu yemek bir harika.", 20, "nesrinylmz@gmail.com", "Nesrin Yılmaz" }
                });

            migrationBuilder.InsertData(
                table: "FoodCategories",
                columns: new[] { "CategoryId", "FoodId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 23 },
                    { 5, 24 },
                    { 5, 25 },
                    { 6, 26 },
                    { 6, 27 },
                    { 6, 28 },
                    { 6, 29 },
                    { 6, 30 },
                    { 7, 31 },
                    { 7, 32 },
                    { 7, 33 },
                    { 7, 34 },
                    { 7, 35 },
                    { 8, 36 },
                    { 8, 37 },
                    { 8, 38 },
                    { 8, 39 },
                    { 8, 40 }
                });

            migrationBuilder.InsertData(
                table: "FoodRecipes",
                columns: new[] { "FoodId", "RecipeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 },
                    { 17, 17 },
                    { 18, 18 },
                    { 19, 19 },
                    { 20, 20 },
                    { 21, 21 },
                    { 22, 22 },
                    { 23, 23 },
                    { 24, 24 },
                    { 25, 25 },
                    { 26, 26 },
                    { 27, 27 },
                    { 28, 28 },
                    { 29, 29 },
                    { 30, 30 },
                    { 31, 31 },
                    { 32, 32 },
                    { 33, 33 },
                    { 34, 34 },
                    { 35, 35 },
                    { 36, 36 },
                    { 37, 37 },
                    { 38, 38 },
                    { 39, 39 },
                    { 40, 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FoodId",
                table: "Comments",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_CategoryId",
                table: "FoodCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipes_RecipeId",
                table: "FoodRecipes",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropTable(
                name: "FoodRecipes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Repices");
        }
    }
}
