using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Data.Config
{
	public class FoodConfig : IEntityTypeConfiguration<Food>
	{
		public void Configure(EntityTypeBuilder<Food> builder)
		{
			builder.HasKey(f => f.Id);
			builder.Property(f => f.Id).ValueGeneratedOnAdd();

			builder.Property(f => f.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(f => f.Material)
				.IsRequired()
				.HasMaxLength(1000);

			builder.Property(f => f.Description)
				.IsRequired()
				.HasMaxLength(900);

			builder.Property(f => f.ImageUrl)
			   .IsRequired()
			   .HasMaxLength(250);

			builder.Property(f => f.Url)
				.IsRequired();

			builder.Property(f => f.AddDate)
				.HasDefaultValueSql("date('now')");

			builder.Property(f => f.Point)
				.HasDefaultValueSql("0");

			builder.ToTable("Foods");

			builder.HasData(
				 //5 ADET ÇORBA EKLEYELİM
				 new Food
				 {
					 Id = 1,
					 Name = "Borscht Çorbası",
					 Material = "2 – 3 yemek kaşığı zeytinyağı\r\n1 adet soğan\r\n2 adet patates\r\n½ adet küçük mor lahana\r\n1 adet havuç\r\n1 adet kırmızı kapya biber\r\n1 adet kereviz sapı\r\n1 diş sarımsak\r\n2 yemek kaşığı domates püresi\r\n3 adet pancar\r\n1 adet defne yaprağı\r\n1 yemek kaşığı beyaz sirke\r\nTuz\r\nKarabiber\r\n3 su bardağı et suyu\r\n7 su bardağı su",
					 Description = "Bu çorba ilk kez Kuzeydoğu Çin'de, Rus sınırından yakın mesafede bulunan Harbin şehrinde ortaya çıktı; zaman geçtikçe bu çorba ta Hong Kong'a kadar yayıldı.",
					 ImageUrl = "1.Png",
					 Url = "borscht-corbası",
					 IsHome = true,
					 IsApproved = true
				 },

				 new Food
				 {
					 Id = 2,
					 Name = "Çeşmi Nigar Çorbası",
					 Material = "¼ su bardağı zeytinyağı\r\n1 adet soğan\r\n1 yemek kaşığı un\r\n1 su bardağı kırmızı mercimek\r\nTuz\r\nKarabiber\r\n7 su bardağı su\r\nTerbiyesi için Malzemeler\r\n1 yumurta sarısı\r\n½ su bardağı süt\r\n1 adet limonun suyu\r\nSosu için Malzemeler\r\n1 yemek kaşığı tereyağı\r\nKuru nane\r\nToz kırmızı biber\r\nPul biber",
					 Description = "Çeşmi nigar çorbası, Osmanlı mutfağından günümüze uzanmış lezzetlerden. Bir tür mercimek çorbası olan çeşmi nigar çorbasının en önemli özelliği, içine eklenen yumurtalı limonlu terbiye",
					 ImageUrl = "2.Png",
					 Url = "cesmi-nigar-corbasi",
					 IsHome = true,
					 IsApproved = true
				 },

				 new Food
				 {
					 Id = 3,
					 Name = "Ezogelin Çorbası",
					 Material = "2 yemek kaşığı tereyağı\r\n1 adet orta boy soğan\r\n2 diş sarımsak\r\n1 su bardağı kırmızı mercimek\r\n¼ su bardağı pilavlık bulgur\r\n¼ su bardağı pirinç\r\n2 çay kaşığı tuz\r\n2 çay kaşığı karabiber\r\n7 su bardağı su\r\nMeyanesi için Malzemeler\r\n2 yemek kaşığı tereyağı\r\n1 yemek kaşığı domates salçası\r\n1 yemek kaşığı un\r\nKuru nane\r\nPul biber\r\n2 su bardağı su veya et suyu\r\nKruton için Malzemeler\r\n½ adet ramazan pidesi\r\n2 – 3 yemek kaşığı tereyağı",
					 Description = "Ezogelin çorbası, Türk mutfağına has; domates (veya salçası), pirinç ve kırmızı mercimek ile yapılan bir çorba. Adı, Barak Türkmenlerinden Gaziantep'in Oğuzeli ilçesine bağlı Uruş (yeni adıyla Dokuzyol) köyünden Ezo Gelin'in adından gelir.",
					 ImageUrl = "3.Png",
					 Url = "ezogelin-corbasi",
					 IsHome = true,
					 IsApproved = false
				 },

				  new Food
				  {
					  Id = 4,
					  Name = "Balkabağı Çorbası",
					  Material = "1 tepeleme yemek kaşığı tereyağı\r\n1 adet büyük boy soğan\r\n1 adet patates\r\n750 gr. balkabağı\r\n¼ adet muskat – rende\r\n1 adet yıldız anason\r\nTuz\r\nKarabiber\r\n5 su bardağı et veya sebze suyu\r\n2 yemek kaşığı krema",
					  Description = "Balkabağı çorbası, balkabağı püresinden yapılan genellikle 'bağlı' bir çorbadır. Harmanlanmış balkabağının etinin et suyu veya et suyu ile birleştirilmesiyle yapılır. Sıcak veya soğuk olarak servis edilebilir ve Amerika Birleşik Devletleri'nde yaygın bir Şükran Günü yemeğidir.",
					  ImageUrl = "4.Png",
					  Url = "balkabagı-corbası",
					  IsHome = false,
					  IsApproved = false
				  },

				  new Food
				  {
					  Id = 5,
					  Name = "Naneli Bezelye Çorbası",
					  Material = "2 yemek kaşığı ayçiçek yağı\r\n1 adet soğan\r\n1 diş sarımsak – ezilmiş\r\n1 adet patates\r\n5 su bardağı tavuk suyu\r\n2 su bardağı bezelye\r\n4 – 5 dal taze nane\r\nTuz\r\nKarabiber\r\n1 adet tavuk göğüs – haşlanmış\r\nSüslemek için Malzemeler\r\nTaze nane yaprağı",
					  Description = "Fransız mutfağından alınarak Kanada tarzının eklendiği bezelye çorbası, füme jambon ile yapılıyor.",
					  ImageUrl = "5.Png",
					  Url = "balkabagı-corbası",
					  IsHome = true,
					  IsApproved = true
				  },

				  //5 ADET ETLİ YEMEK YAZALIM

				  new Food
				  {
					  Id = 6,
					  Name = "İsveç Köftesi",
					  Material = "500 gr. orta yağlı kıyma\r\n1 su bardağı panko – ekmek kırıntısı\r\n1 adet yumurta\r\n1 adet orta boy soğan – rende\r\n¼ su bardağı süt\r\n1 tatlı kaşığı sarımsak tozu\r\n1 tatlı kaşığı yenibahar\r\nTuz\r\nKarabiber\r\n1 – 2 yemek kaşığı tereyağı\r\nKrema Sosu için Malzemeler\r\n2 yemek kaşığı tereyağı\r\n1 yemek kaşığı un\r\n2 su bardağı et suyu\r\n1 su bardağı krema – 200 ml.\r\n1 çay kaşığı hardal\r\nTuz\r\nKarabiber\r\nÜzeri için Malzemeler\r\n1 adet bayat ekmek\r\nKaşar peyniri – rende\r\nMaydanoz",
					  Description = "İsveç köftesi genellikle kekreyemiş (lingonberry) reçeli, özel et sosu ve haşlanmış veya kızarmış patatesle birlikte servis edilir. Orijinal ismi “köttbullar” olan İsveç köftesi, İsveç mutfağının geleneksel bir yemeğidir",
					  ImageUrl = "6.Png",
					  Url = "ısvec-koftesi",
					  IsHome = true,
					  IsApproved = true
				  },

				   new Food
				   {
					   Id = 7,
					   Name = "Kayısılı Kuzu Eti",
					   Material = "750 gr. kemiksiz kuzu but ya da kol\r\nTuz\r\nKarabiber\r\n2 yemek kaşığı un\r\n2 yemek kaşığı zeytinyağı\r\n2 adet orta boy soğan\r\n3 adet yeşil biber\r\n1 tutam rendelenmiş taze zencefil\r\n3 su bardağı et suyu\r\n1 tutam tel safran ya da aspir\r\n1 su bardağı sıcak su – safran için\r\n1 limonun suyu\r\n1 tatlı kaşığı tane kişniş\r\n1 su bardağı kuru kayısı\r\n1 adet yeşil biber",
					   Description = "Osmanlı saray mutfağında padişah sofralarında ve sarayın önde gelen paşalarına verilen önemli ziyafetlerde yemek menülerinde de öncelikte yer almıştır. Ayni zamanda ahalide Osmanlı ve Türk Mutfağı, Geleneksel Türk Mutfağı, Yöresel Yemekler, Yöresel Mutfaklar da et yemekleri ve tercih edilen tencere yemekleri arasında kendi yerini almıştır. Domatesin tam olarak keşfedilmeden önce eski Türk topluluklarında ve Osmanlıda yemekler koruk suyu, baharatlar ve kuru meyveler ile tatlandırılıyordu.",
					   ImageUrl = "7.Png",
					   Url = "ısvec-koftesi",
					   IsHome = true,
					   IsApproved = true
				   },

				   new Food
				   {
					   Id = 8,
					   Name = "Meksika Çıtırı: Taco Tarifi",
					   Material = "12\r\nadet\r\nmini lavaş\r\n(ya da taco kabuğu)\r\n3\r\nyemek kaşığı\r\nzeytinyağı\r\n500\r\ngram\r\norta yağlı kıyma\r\n1\r\nadet\r\nküçük boy kuru soğan\r\n(küp küp doğranmış)\r\n1\r\nadet\r\norta boy domates\r\n(püre haline getirilmiş)\r\n1\r\ntatlı kaşığı\r\nacı sos\r\n1\r\ntatlı kaşığı\r\ndomates salçası\r\n1/2\r\nçay kaşığı\r\ntuz\r\n1/4\r\nçay kaşığı\r\nkimyon\r\n4\r\ndal\r\ntaze kişniş\r\n(ya da maydanoz)\r\nServisi için:\r\n1/2\r\ndemet\r\nmaydanoz\r\n(ince kıyılmış)\r\n1/2\r\nadet\r\navokado\r\n1\r\nadet\r\nbüyük boy domates\r\n(küp küp doğranmış)\r\n1\r\nadet\r\norta boy kırmızı soğan\r\n(küp küp doğranmış)\r\n1/2\r\nsu bardağı\r\nrendelenmiş kaşar peyniri\r\n1/2\r\nsu bardağı\r\nrendelenmiş cheddar peyniri",
					   Description = "Taco, (İspanyolca: Taco) geleneksel Meksika yemeği. Birçok şekilde yapılabilmektedir. Yapımında tortilla, et, peynir ve çeşitli sebzeler kullanılır. Ayrıca, yanında bazı garnitürler de tüketilebilir.",
					   ImageUrl = "8.Png",
					   Url = "meksika-citiri-taco",
					   IsHome = false,
					   IsApproved = true
				   },

					  new Food
					  {
						  Id = 9,
						  Name = " Narlı Kuzu Eti",
						  Material = "1 yemek kaşığı tereyağı\r\n1 yemek kaşığı zeytinyağı\r\n1 kilo kuzu eti – iri kuşbaşı\r\n20 – 25 adet arpacık soğan\r\n1 yemek kaşığı domates salçası\r\n1 yemek kaşığı un\r\nTuz\r\nKarabiber\r\n2 – 3 dal taze kekik\r\n1 tutam tane kişniş\r\n1 yemek kaşığı nar ekşisi\r\n4 su bardağı sıcak su\r\n2 adet defne yaprağı\r\nÜzeri için Malzemeler\r\n1 su bardağı nar tanesi\r\n3 dal taze soğanın yeşil kısmı",
						  Description = " Sonbahar ve kış aylarında Topkapı sarayında yapılan bir yemekti. Osmanlı döneminde ''rummamiye'' denilen bu yemek, yıllar içerisinde unutulmayarak günümüz mutfağında da yer almaktadır. ",
						  ImageUrl = "9.Png",
						  Url = "narlı-kuzu-eti",
						  IsHome = true,
						  IsApproved = false
					  },

					  new Food
					  {
						  Id = 10,
						  Name = " Etli Fajita",
						  Material = "600 gram julyen doğranmış dana bonfile\r\n1 adet kırmızı Kaliforniya biberi\r\n1 adet sarı Kaliforniya biberi\r\n1 adet yeşil biber\r\n1 baş kırmızı kuru soğan\r\nYarım çay bardağı zeytinyağı\r\n2 yemek kaşığı soya sosu\r\nEt marinasyonu için;\r\n\r\n1 yarım limon suyu\r\n1 çay bardağı zeytinyağı\r\nYarım çay bardağı soya sosu\r\n2 diş sarımsak\r\n1 çay kaşığı karabiber\r\n1 tatlı kaşığı kekik tuz, tatlı toz biber",
						  Description = " Fajita, Meksika mutfağına ait bir etli yemek türüdür. Orijinal olarak dana eti ile yapılan yemek günümüzde tavuk ve karides ile yapılmaktadır. Yemek tortilla ekmeği ile birlikte servis edilmektedir. ",
						  ImageUrl = "10.Png",
						  Url = "etli-fajita",
						  IsHome = true,
						  IsApproved = true
					  },

					  // 5 adet TAVUK YEMEKLERİ YAZALIM
					  new Food
					  {
						  Id = 11,
						  Name = " Tavuk Nugget ",
						  Material = "2 adet tavuk göğsü\r\n2 adet yumurta\r\n2 yemek kaşığı un\r\n2 yemek kaşığı zeytinyağı\r\n1 tutam tuz\r\n1 tutam karabiber\r\nPanelemek için Malzemeler\r\n1 su bardağı un\r\n2 adet yumurta\r\n1 su bardağı galeta unu\r\nKızartmak için Malzemeler\r\nAyçiçek yağı",
						  Description = "Şnitzel veya şinitzel (Almanca: Wiener Schnitzel), Avusturya mutfağından, gayet ince kesilmiş bir dilim dana, domuz veya tavuk etinin sırasıyla una, yumurta sarısına ve galeta ununa bandırılarak kızgın yağda kızartılmasıyla yapılan bir yemek türüdür.",
						  ImageUrl = "11.Png",
						  Url = "tavuk-nugget",
						  IsHome = true,
						  IsApproved = true
					  },

					  new Food
					  {
						  Id = 12,
						  Name = " Tavuklu Kağıt Kebabı ",
						  Material = "2 – 3 yemek kaşığı zeytinyağı\r\n1 adet patlıcan\r\n1 adet kabak\r\n1 adet patates\r\n2 adet tavuk göğüs\r\n10 – 15 adet arpacık soğan\r\n1 su bardağı bezelye – haşlanmış ya da dondurulmuş\r\n3 – 4 diş sarımsak\r\n10 adet siyah zeytin\r\nSosu için Malzemeler\r\n3 yemek kaşığı zeytinyağı\r\n2 yemek kaşığı az tuzlu soya sosu\r\n1 tatlı kaşığı domates salçası\r\n1 tatlı kaşığı biber salçası\r\nTuz\r\nKarabiber\r\nKuru kekik\r\n1 avuç ceviz – iri dövülmüş",
						  Description = "Antakya Kâğıt Kebabı; dana döş eti, yeşil ve kırmızı biber (acı veya tatlı) maydanoz, sarımsak, tuz ve karabiber karışımından oluşan, disk şekli verilerek yağlı kağıt üzerinde pişirilen, yörede Arapça olarak “lahme la varka” olarak da bilinen bir kebaptır.",
						  ImageUrl = "12.Png",
						  Url = "tavuklu-kagit-kebabi",
						  IsHome = true,
						  IsApproved = true
					  },

					   new Food
					   {
						   Id = 13,
						   Name = " Tavuklu Nohutlu Tirit ",
						   Material = "2 – 3 yemek kaşığı tereyağı\r\n1 adet ramazan pidesi\r\nTavuk için Malzemeler\r\n10 su bardağı su\r\n7 – 8 adet tane karabiber\r\n1 adet soğan\r\n1 dal kereviz sapı\r\n5 – 6 adet tavuk baget\r\nTuz\r\n1 su bardağı nohut – haşlanmış\r\nDomates Sosu için Malzemeler\r\n3 yemek kaşığı zeytinyağı\r\n1 adet soğan\r\n1 yemek kaşığı domates salçası\r\n1 su bardağı tavuk suyu\r\n4 yemek kaşığı domates püresi\r\n1 avuç kuru nane\r\n1 avuç kuru kekik\r\nTuz\r\nKarabiber\r\nYoğurt için Malzemeler\r\n4 – 5 yemek kaşığı süzme yoğurt\r\n1 diş sarımsak\r\nSüslemek için Malzemeler\r\nKuru nane",
						   Description = "Elmadağ yöresine ait harika ve lezzetli bir yemektir.",
						   ImageUrl = "13.Png",
						   Url = "tavuklu-nohutlu-tirit",
						   IsHome = false,
						   IsApproved = false
					   },

					   new Food
					   {
						   Id = 14,
						   Name = " Tavuklu Sultan Kebabı Tarifi ",
						   Material = "2 adet yufka\r\n400g tavuk göğsü\r\n400g tavuk pirzola\r\n1 adet kuru soğan\r\n1 yemek kaşığı domates salçası (Birazını ketçap kullanabilirsiniz)\r\n1 su bardağı haşlanmış ya da konserve bezelye\r\n1 adet patlıcan\r\nPul biber\r\nKekik\r\nKarabiber\r\nTuz\r\nBeşamel sos için:\r\n\r\n1,5 yemek kaşığı un\r\n1,5 su bardağı süt\r\n2 yemek kaşığı tereyağı\r\nTuz\r\nÜzeri için:\r\n\r\nKaşar peyniri rendesi",
						   Description = "Ege yöresine ait olup Ege'nin mutfak güzelliklerinden biri olan tavuklu sultan kebabı sofralarımıza lezzet katmaktadır.",
						   ImageUrl = "14.Png",
						   Url = "tavuklu-sultan-kebabı",
						   IsHome = true,
						   IsApproved = true
					   },

					   new Food
					   {
						   Id = 15,
						   Name = " Fırında İç Pilavlı Tavuk Dolması Tarifi ",
						   Material = "1 adet bütün tavuk\r\n1 tatlı kaşığı un\r\n2-3 defne yaprağı\r\nLimon dilimleri\r\nSosu için:\r\n\r\n1 tatlı kaşığı yoğurt\r\n1 tatlı kaşığı domates salçası\r\n2 yemek kaşığı sıvı yağ\r\n1 çay kaşığı toz kırmızı biber\r\nYarım tatlı kaşığı tuz\r\nPilavı için:\r\n\r\n2 su bardağı pilavlık pirinç\r\n2 yemek kaşığı tereyağı\r\n2 yemek kaşığı sıvı yağ\r\nYarım çay bardağı dolmalık fıstık\r\nYarım çay bardağı kuş üzümü\r\n2 su bardağı sıcak su (400 ml)\r\n1 çay bardağı sıcak su (sonradan ekleniyor)\r\n1 tatlı kaşığı tuz\r\n1 çay kaşığı tarçın\r\n1 çay kaşığı karabiber\r\nGarnitür olarak:\r\n\r\n2 adet patates\r\n2 adet havuç\r\nArpacık soğan",
						   Description = "Doğunun incisi Mardinde genelde yapılan nefis bir yemektir..",
						   ImageUrl = "15.Png",
						   Url = "fırında-iç-pilavli-tavuk-dolmasi",
						   IsHome = true,
						   IsApproved = true
					   },

					   //BU KISIMDA BALIK YEMEKLERİNİ GÖRÜNTÜLEYECEĞİZ.......
					   new Food
					   {
						   Id = 16,
						   Name = " Hamsi Kuşu ",
						   Material = "40 adet hamsi\r\n3 dal taze soğan\r\n30 yaprak nane\r\n12 dal maydanoz\r\n15 adet karanfilin top kısmı\r\n1 yemek kaşığı susam\r\n1 yemek kaşığı zeytinyağı\r\nTuz\r\nKarabiber\r\nHamsileri kızartmak için Malzemeler\r\n1 su bardağı mısır unu\r\nAyçiçek yağı\r\nSunum için Malzemeler\r\nKırmızı Soğan\r\nLimon\r\nRoka",
						   Description = "Karadeniz denince akla gelen ilk lezzetlerden biridir o. Hamsi kuşu tarifinde kılçıkları tamamen ayıklanıp fileto haline getirilen hamsiler; maydanoz, taze soğan, kuru soğan, mısır unu ve baharatların da yer aldığı karışımla ikişer ikişer kapatılır.",
						   ImageUrl = "16.Png",
						   Url = "hamsi-kusu",
						   IsHome = true,
						   IsApproved = false
					   },

					   new Food
					   {
						   Id = 17,
						   Name = " Ekmek Kırıntılı Pestolu Somon ",
						   Material = "4 dilim somon fileto\r\n4 avuç ekmek kırıntısı – panko\r\n1 tepeleme yemek kaşığı tereyağı\r\n2 – 3 diş sarımsak\r\n2 avuç fesleğen\r\nServis Etmek için Malzemeler\r\nRenkli çeri domates\r\nPesto Sos için Malzemeler\r\n2 bağ fesleğen – 50 yaprak\r\n½ bağ maydanoz\r\n½ su bardağı fındık\r\n½ su bardağı toz parmesan\r\n2 – 3 diş sarımsak\r\nTuz\r\nKarabiber\r\n1 – 1,5 su bardağı zeytinyağı",
						   Description = "Karadeniz denince akla gelen ilk lezzetlerden biridir o. Hamsi kuşu tarifinde kılçıkları tamamen ayıklanıp fileto haline getirilen hamsiler; maydanoz, taze soğan, kuru soğan, mısır unu ve baharatların da yer aldığı karışımla ikişer ikişer kapatılır.",
						   ImageUrl = "17.Png",
						   Url = "ekmek-kirintili-pestolu-somon",
						   IsHome = true,
						   IsApproved = true
					   },

						 new Food
						 {
							 Id = 18,
							 Name = " Hamsili Pilav  ",
							 Material = "2 kg. hamsi – ayıklanmış – 120 adet\r\n½ su bardağı zeytinyağı\r\n2 adet soğan – çok ince yemeklik doğranmış\r\n2 su bardağı baldo pirinç\r\nTuz\r\nKarabiber\r\n1 tatlı kaşığı yenibahar\r\n1 tepeleme yemek kaşığı kuru nane\r\n½ su bardağı kuş üzümü – suda beklemiş\r\n1 yemek kaşığı toz şeker\r\n1 adet defne yaprağı\r\n2 su bardağı su\r\n½ bağ dereotu\r\nTereyağı – kabı yağlamak için\r\nÜzeri için Malzemeler\r\n4 dilim limon\r\nTereyağı",
							 Description = "Karadeniz yöresine ait bir yemek türü olan hamsili pilav, Karadenizlilerin sofralarının vazgeçilmez lezzeti.",
							 ImageUrl = "18.Png",
							 Url = "hamsili-pilav",
							 IsHome = true,
							 IsApproved = true
						 },

						  new Food
						  {
							  Id = 19,
							  Name = " Somon Grawlax ",
							  Material = "1 dilim 120 gramlık somon\r\n1 silme yemek kaşığı toz şeker\r\n1 tutam tuz\r\n1 adet pancarın suyu\r\n1 adet limonun kabuğu\r\n½ adet limon suyu\r\n¼ adet taze rezene\r\nSalata için Malzemeler\r\n1 yemek kaşığı kinoa\r\n2 su bardağı su\r\n¼ adet kırmızı soğan\r\n¼ adet salatalık\r\n1/6 adet sarı dolmalık biber\r\n¼ adet domates – çekirdeği çıkartılmış\r\n1 parmak kereviz sapı\r\n1 dilim mango\r\n4 yaprak taze nane\r\n1 yemek kaşığı lor peyniri\r\nAvokado Katı için Malzemeler\r\n1 adet avokado\r\n1 yemek kaşığı limon suyu\r\nTuz\r\nKarabiber\r\nSosu (Vinaigrette) için Malzemeler\r\n1 yemek kaşığı toz şeker\r\nTuz\r\nKarabiber\r\n½ adet limon suyu\r\n3 yemek kaşığı zeytinyağı\r\nParmesan Tuille için Malzemeler\r\n1 yemek kaşığı parmesan – ince rende",
							  Description = "Gravlax İskandinav mutfağından somon ile hazırlanan fermente edilmiş bir yiyecek dir.",
							  ImageUrl = "19.Png",
							  Url = "somon-grawlax",
							  IsHome = true,
							  IsApproved = true
						  },

						   new Food
						   {
							   Id = 20,
							   Name = " Tuzda Karides ",
							   Material = "Orta boy kalın kabuklu karidesler\r\n\r\nKaya Tuzu\r\n\r\nBahçe yeşillikleri",
							   Description = "Uzakdoğu başta olmak üzere dünyanın pek çok ülkesinde yaygın olarak tüketilen karidesin bilinen 2 bin 500 türü var. Türkiye denizlerinde 61 türü bulunuyor ve bunlardan sadece 7’si ticari olarak değerlendiriliyor. Bu lezzetli deniz kabuklusunun güveci, ızgarası, tavası, söğüşü damakları şenlendiriyor…",
							   ImageUrl = "20.Png",
							   Url = "tuzda-karides",
							   IsHome = true,
							   IsApproved = true
						   },

						   //BU ALANDA ZEYTİNYAĞLI YEMEKLERİ GÖRÜNTÜLEYECEĞİZ.

						   new Food
						   {
							   Id = 21,
							   Name = " Vişneli Yaprak Sarma ",
							   Material = "400 gr. asma yaprağı\r\nPilav için Malzemeler\r\n½ su bardağı zeytinyağı\r\n2 yemek kaşığı dolmalık fıstık\r\n2 adet soğan\r\n2 su bardağı pirinç\r\nTuz\r\nKarabiber\r\n½ tatlı kaşığı tarçın\r\n½ tatlı kaşığı yeni bahar\r\n1 tatlı kaşığı kuru nane\r\n1 su bardağı su\r\n1 su bardağı vişne suyu\r\n1 yemek kaşığı kuş üzümü\r\n1 yemek kaşığı nar ekşisi\r\n1 yemek kaşığı toz şeker\r\n400 gr. vişne\r\n1 su bardağı vişne suyu – sarmaları pişirmek için",
							   Description = "Yaprak sarmanın harika bir hali. lezzet bombası, inanılmaz bir ahenk. ricardo moyano' nun yemen türküsü 'nü yorumlaması gibi bir şey.",
							   ImageUrl = "21.Png",
							   Url = "visneli-yaprak-sarma",
							   IsHome = true,
							   IsApproved = true
						   },

							new Food
							{
								Id = 22,
								Name = " Zeytinyağlı Bakla ",
								Material = "Zeytinyağlı Bakla Malzemeleri\r\n500 gr. taze bakla\r\n½ su bardağı zeytinyağı\r\n1 adet soğan – yemeklik doğranmış\r\nTuz\r\nKarabiber\r\n1 yemek kaşığı toz şeker\r\n1 yemek kaşığı un\r\n½ su bardağı su\r\nÜzeri için Malzemeler\r\nDereotu",
								Description = "Bakla geleneksel İzmir mutfağında sevilerek tüketilen zeytinyağlı yemeklerden biridir.",
								ImageUrl = "22.Png",
								Url = "zeytinyagli-bakla",
								IsHome = true,
								IsApproved = true
							},

							new Food
							{
								Id = 23,
								Name = " İç Baklalı Enginar ",
								Material = "4 – 5 yemek kaşığı zeytinyağı\r\n3 adet soğan\r\n150 gr. taze iç bakla\r\n1 diş sarımsak\r\nTuz\r\nBeyaz biber\r\n1 tatlı kaşığı toz şeker\r\n7 adet enginar\r\n1 adet limon suyu\r\n1,5 su bardağı su\r\n½ bağ dereotu – ince kıyım",
								Description = "İzmir'de çoğunlukla Karaburun, Mordoğan, Urla ilçelerinde yetişen enginar, İzmir mutfağında en çok çeşidi yapılan sebzelerden biridir. Zeytinyağlı enginar, kuzu etli enginar, iç baklalı enginar, taze baklalı enginar, enginar kızartması, enginar dolması, enginarlı pilav bunlara örnek olarak verilebilir.",
								ImageUrl = "23.Png",
								Url = "iç-baklali-enginar",
								IsHome = true,
								IsApproved = true
							},

							 new Food
							 {
								 Id = 24,
								 Name = " Enginarlı Fava ",
								 Material = "½ kg kuru bakla\r\n1 demet dereotu\r\n2 yemek kaşığı şeker\r\n1 orta boy soğan\r\n1 su bardağı zeytinyağı\r\n2 tutam tuz\r\n5 bardak su\r\n \r\nEnginar için Malzemeler\r\n6 adet enginar\r\n1 iri kırmızı soğan\r\n1 portakalın suyu ve parçaları\r\n1 bardak su\r\n1 bardak z.yağı\r\n1 tatlı kaşığı şeker\r\n2 tutam tuz",
								 Description = "Fava (Favetta) bakla tanelerinin kabuğu soyulduktan sonra yapılan zeytin yağlı yemektir. Eski İstanbul Rumları kuru bakliyattan yapılan bütün ezmelere fava (Φάβα) derdi. Ama bugün Türkiye'de fava denince sadece kuru bakla ezmesinden yapılan meze anlaşılıyor.Girit Türk mutfağında yer alır.",
								 ImageUrl = "24.Png",
								 Url = "enginarli-fava",
								 IsHome = true,
								 IsApproved = true
							 },

							  new Food
							  {
								  Id = 25,
								  Name = " İmam Bayıldı ",
								  Material = "Kızartmak için Malzemeler\r\n4 adet patlıcan – küçük boy\r\nZeytinyağı\r\n \r\nİç harcı için Malzemeler\r\n2 orta boy beyaz kuru soğan\r\n12 diş sarımsak\r\n3 adet sivribiber\r\n3 adet domates\r\n3 tutam tuz\r\n3 tutam karabiber\r\n1 dolu tatlı kaşığı toz şeker\r\n½ demet maydanoz\r\n1 yemek kaşığı zeytinyağı",
								  Description = " İmambayıldı, Ege yöresine ait; Patlıcan, soğan, sarımsak, biber, domates, maydanoz ile yapılan bir yemektir.",
								  ImageUrl = "25.Png",
								  Url = "imam-bayildi",
								  IsHome = true,
								  IsApproved = true
							  },

							   //BURADA SALATALARI YAZACAĞIZ

							   new Food
							   {
								   Id = 26,
								   Name = " Falafelli Salata ",
								   Material = "Falafelli Salata Malzemeleri\r\n15 – 20 adet renkli çeri domates\r\n2 dolu avuç bebek roka\r\nTuz\r\nKarabiber\r\n2 yemek kaşığı zeytinyağı\r\nFalafel için Malzemeler\r\n1 su bardağı nohut – 1 gece su da bekletilmiş\r\n1 adet orta boy soğan\r\n2 diş sarımsak\r\n1 bağ maydanoz\r\n4 – 5 dal kişniş\r\nTuz\r\nKarabiber\r\n1 tatlı kaşığı kimyon\r\n1 tatlı kaşığı pul biber\r\n2 – 3 yemek kaşığı un\r\nSosu için Malzemeler\r\n1 su bardağı süzme yoğurt\r\n1 yemek kaşığı tahin\r\n½ adet limonun suyu\r\n1 – 2 yemek kaşığı zeytinyağı",
								   Description = " Doyurucu bir Lübnan lezzeti olan falafel; tadını nohut, taze yeşillikler ve kuru baharatlardan alıyor. İşin sırrı nohutları haşlamadan, bir gece önce suda bekletmekte saklı.",
								   ImageUrl = "26.Png",
								   Url = "falafelli-salata",
								   IsHome = true,
								   IsApproved = true
							   },

							   new Food
							   {
								   Id = 27,
								   Name = " Semizotu Salatası",
								   Material = "2 bağ semizotu – temizlenmiş\r\n1 adet domates\r\n½ limonun suyu\r\nZeytinyağı\r\n1 avuç ceviz\r\nKabak için Malzemeler\r\n1 adet kabak\r\nTuz\r\nZeytinyağı\r\nTabanı için Malzemeler\r\n6 yemek kaşığı süzme yoğurt\r\n1 yemek kaşığı bal\r\n1 avuç ceviz – kıyılmış",
								   Description = " Semizotu ya da pirpirim, semizotugiller familyasından bir bitki olup yaprakları salata olarak, ya da ıspanak gibi pişirilerek yemeklerde kullanılan bir sebzedir. Kökeni Ortadoğu ve Hindistan olmakla birlikte dünyanın birçok bölgesinde bulunmaktadır.",
								   ImageUrl = "27.Png",
								   Url = "semizotu-salatasi",
								   IsHome = true,
								   IsApproved = true
							   },

							   new Food
							   {
								   Id = 28,
								   Name = " Mor Lahana Salatası ",
								   Material = "½ adet mor lahana\r\n1 adet havuç – rende\r\n2 adet salatalık – rende\r\n½ adet kırmızı soğan\r\n3 – 4 dal taze kişniş\r\n1 avuç ceviz\r\n1 adet lime kabuğu rendesi\r\n1 avuç sultaniye kuru üzüm\r\nSosu için Malzemeler\r\n1 yemek kaşığı zeytinyağı\r\n½ adet lime suyu\r\n1 yemek kaşığı mayonez\r\n1 yemek kaşığı süzme yoğurt",
								   Description = " Baş lahana olarak sınıflandırılan beyaz ve kırmızı lahanalar ülkemizde çoğunlukla Karadeniz Bölgesi'nde yetiştiriliyor.",
								   ImageUrl = "28.Png",
								   Url = "mor-lahana-salatası",
								   IsHome = true,
								   IsApproved = true
							   },

							   new Food
							   {
								   Id = 29,
								   Name = " Semiz Otlu Yaz Salatası ",
								   Material = "1 bağ semizotu\r\n8-10 adet çeri domates\r\n3-4 adet Çengelköy salatalık\r\n1 adet kırmızı soğan\r\n1 avuç ceviz\r\n1 yemek kaşığı yoğurt\r\n½ adet limon suyu\r\nTuz\r\nZeytinyağı",
								   Description = "Anayurdu Hindistan olan semizotu, ülkemizde de sıklıkla tüketiliyor. Semizotunun hem yemeği hem de salatası, çok seviliyor.",
								   ImageUrl = "29.Png",
								   Url = "semiz-otlu-yaz-salatasi",
								   IsHome = true,
								   IsApproved = true
							   },

								new Food
								{
									Id = 30,
									Name = " Ispanak Köklü Salata ",
									Material = "1 kg. ıspanak kökü\r\n½ adet limon suyu\r\n2 diş sarımsak\r\n1 yemek kaşığı süzme yoğurt\r\n2 adet domates\r\nZeytinyağı\r\nPul biber\r\nTuz\r\nKarabiber",
									Description = " İzmirde yetişen bu kök egenin harika salataları arasında yer almıştır.",
									ImageUrl = "30.Png",
									Url = "ispanak-koklu-salata",
									IsHome = true,
									IsApproved = true
								},

								//BU ALANDA TATLILAR YER ALACAKTIR.
								new Food
								{
									Id = 31,
									Name = " Kedi Dilli Sakızlı Muhallebi ",
									Material = "Tabanı için Malzemeler\r\n1 – 2 yemek kaşığı granül kahve\r\n1 su bardağı sıcak su\r\n2 – 3 damla vanilya özütü\r\n12 – 15 adet kedi dili\r\nArası için Malzemeler\r\n3 adet muz\r\nMuhallebi için Malzemeler\r\n125 gr. tereyağı\r\n1 su bardağı un\r\n1 litre süt\r\n1,5 su bardağı toz şeker\r\n3 – 4 parça dövülmüş damla sakızı\r\nÜzeri için Malzemeler\r\nKakao",
									Description = "Yaz havaları içinde tercih edilen harika bir tatlı.",
									ImageUrl = "31.Png",
									Url = "kedi-dilli-sakizli-muhallebi",
									IsHome = true,
									IsApproved = true
								},

								new Food
								{
									Id = 32,
									Name = " Damla Sakızlı Sütlaç ",
									Material = "7,5 su bardağı süt – 1,5 litre\r\n½ su bardağı pirinç\r\n1 yemek kaşığı pirinç unu\r\n1 yemek kaşığı buğday nişastası\r\n1 su bardağı toz şeker\r\n1 tutam toz damla sakızı\r\nTarçın – üzeri için",
									Description = "Sakız tadını damağınızda hissedeceğiniz harika bir tatlı..",
									ImageUrl = "32.Png",
									Url = "damla-sakizli-sutlac",
									IsHome = true,
									IsApproved = true
								},

								new Food
								{
									Id = 33,
									Name = " Kakaolu Islak Kek ",
									Material = "4 adet yumurta\r\n1 su bardağı toz şeker\r\n1 su bardağı süt\r\n1 su bardağı ayçiçek yağı\r\n1 su bardağı un\r\n3 yemek kaşığı kakao\r\n1 paket kabartma tozu\r\n1 paket vanilya\r\n1 adet limon kabuğu\r\nSosu için Malzemeler\r\n2 su bardağı süt\r\n½ su bardağı ayçiçek yağı\r\n1 su bardağı toz şeker\r\n2 yemek kaşığı kakao",
									Description = "Kakaonun doyumsuz lezzeti ile şenlik dolu çikolata tadı",
									ImageUrl = "33.Png",
									Url = "kakaolu-islak-kek",
									IsHome = true,
									IsApproved = true
								},

								new Food
								{
									Id = 34,
									Name = " Çilekli Porsiyonluk Pasta",
									Material = "2,5 su bardağı toz şeker\r\n2 su bardağı un\r\n1 su bardağından 1 parmak eksik kakao\r\n1,5 tatlı kaşığı kabartma tozu\r\n1,5 tatlı kaşığı karbonat\r\n1 paket vanilya\r\n1 tutam tuz\r\n2 yumurta\r\n1 + ¼ su bardağı süt\r\n½ su bardağı ayçiçek yağı\r\n1,5 su bardağı sıcak su\r\n1 yemek kaşığı granül kahve\r\nPastacı Kreması için Malzemeler\r\n500 gr. labne\r\n6 tepeleme yemek kaşığı pudra şekeri\r\nArası ve Üzeri için Malzemeler\r\n10 – 12 adet çilek",
									Description = " Çileğin ekşimsi tadı ile mutlu tatlımsı ve ekşimsi bir tat :))",
									ImageUrl = "34.Png",
									Url = "cilekli-posiyonluk-pasta",
									IsHome = true,
									IsApproved = true
								},

								new Food
								{
									Id = 35,
									Name = "Orman Meyveli Rulo Pasta ",
									Material = "2 adet yumurta + 3 adet yumurtanın sarısı\r\n1 su bardağından 1 parmak eksik toz şeker\r\n½ paket vanilya\r\n½ kabartma tozu\r\n¼ su bardağı un\r\n1,5 yemek kaşığı mısır nişastası\r\nLimon kabuğu rendesi\r\n2 adet yumurtanın akı\r\n1 yemek kaşığı toz şeker\r\nRulo Yapmak için Malzemeler\r\nPudra şekeri\r\nDolgusu için Malzemeler\r\n250 gr. labne peyniri\r\n2 yemek kaşığı pudra şekeri\r\nBöğürtlen\r\nÇilek\r\nFrambuaz\r\nYaban mersini\r\nGanaj için Malzemeler\r\n100 gr. krema\r\n1 su bardağı parça bitter çikolata\r\nÜzeri için Malzemeler\r\nToz antep fıstığı",
									Description = " Ormanın derinliklerinden toplanan ekşimsi meyveler ile harika bir lezzet..",
									ImageUrl = "35.Png",
									Url = "orman-meyveli-rulo-pasta",
									IsHome = true,
									IsApproved = true
								},

								 // İÇECEKLER LİSTESİNİ YAZALIM.
								 new Food
								 {
									 Id = 36,
									 Name = "Ayran ",
									 Material = "200 gr. süzme yoğurt\r\n3 su bardağı su\r\n1 küçük parça tereyağı\r\n5 – 6 yaprak taze nane\r\nTuz",
									 Description = "Tüm yemeklerin yanında giden harika lezzet..",
									 ImageUrl = "36.Png",
									 Url = "ayran",
									 IsHome = true,
									 IsApproved = true
								 },

								  new Food
								  {
									  Id = 37,
									  Name = "Ev Yapımı Limonata ",
									  Material = "Ev Yapımı Limonata Malzemeleri\r\n6 adet büyük boy limon\r\n1 adet portakal\r\n1 su bardağı toz şeker\r\n1 su bardağı sıcak su\r\n1 litre soğuk su\r\n½ demet taze nane",
									  Description = "Tüm yemeklerin yanında giden harika lezzet..",
									  ImageUrl = "37.Png",
									  Url = "ev-yapimi-limonata",
									  IsHome = true,
									  IsApproved = true
								  },

								   new Food
								   {
									   Id = 38,
									   Name = " Salep ",
									   Material = "1 litre süt\r\n1 yemek kaşığı salep\r\n1 yemek kaşığı nişasta\r\n1 paket vanilya\r\n½ su bardağı şeker\r\nTarçın – süslemek için",
									   Description = "Kış aylarının vazgeçilmez ezberi..",
									   ImageUrl = "38.Png",
									   Url = "salep",
									   IsHome = true,
									   IsApproved = true
								   },

									new Food
									{
										Id = 39,
										Name = " Muzlu Süt ",
										Material = "½ su bardağı fındık\r\n1 adet muz\r\n5 – 6 adet yulaflı bisküvi\r\n2 – 2,5 su bardağı süt",
										Description = "Boğazlar mı kötü? Hemen deneyin....",
										ImageUrl = "39.Png",
										Url = "muzlu-sut",
										IsHome = true,
										IsApproved = true
									},

									 new Food
									 {
										 Id = 40,
										 Name = " Buzlu Çay ",
										 Material = "1 litre sıcak su\r\n3 adet poşet siyah çay\r\n2 adet limon\r\n1 su bardağı toz şeker\r\n2 adet karanfil\r\n5 – 6 dal taze nane\r\n½ litre su\r\n1 su bardağından 2 parmak eksik limon suyu – 3-4 adet",
										 Description = "Yaz sıcağını buza çevirin .. ",
										 ImageUrl = "40.Png",
										 Url = "buzlu-cay",
										 IsHome = true,
										 IsApproved = true
									 }

				 );




		}
	}
}
