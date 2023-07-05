--DISTINCH KOMUTU
/*
Tekrar eden satırları tekilleştirmek amacıyla kullandığımız komuttur . Bir satış tablosunda ben birden fazla ürün alıyorum diyelim aynı
gün içerisinde , 
*/
/*
Formülize ediliş şekli : 
SELECT DISTINCH
KOLON1,KOLON2,KOLON3,...
FORM TABLOADI
WHERE <ŞARTLAR>
*/
--SELECT * FROM Customers
--Türkiyede 81 il var ve bu iller 999 satırda geçiyor. Bunu tekilleştirmek için :
--SELECT DISTINCT CITY FROM Customers --	DISTINCT olmadan sadece city olsaydı o zaman 999 tane şehir gelecekti

--SELECT CITY,DISTRICT FROM Customers

--WHERE CITY='İSTANBUL' --Müşteriler aynı ilçeden ve tekrar ediyor biz bunun olmasını istemeyiz.

SELECT DISTINCT CITY,DISTRICT FROM Customers
WHERE CITY='İSTANBUL'
--Tekarar eden ilçelerin önüne geçmiş olduk. Yukarıda 36 küsür kayır vardır tekrar eden ilçeler ile DISTINCT komutu ile bunları tekil yaptık.

--CİNSİYETE BAKALIM .TOPLAMDA 998 TANE SATIR VAR AMA BEN BİLİYORUM Kİ 2 TANE CİNSİYET VAR.
SELECT DISTINCT GENDER FROM Customers

WHERE CITY='İSTANBUL' --İstanbulda 14 tane erkek müşterim vardı. 22 tane kadın müşterim vardı . 3. bir cinsiyet olmadığı için buraya tekil olarak getirdi arkadaşlar.

--Benim müşterilerim hangi yaşlarda olduğuna bakalım. İstanbuldaki müşteri yaşları
SELECT AGE FROM Customers

WHERE CITY='İSTANBUL'

--ACABA BUNLARIN YAŞLARININ KAÇI FARKLI OLDUĞUN BULALIM.

SELECT DISTINCT AGE FROM Customers

WHERE CITY='İSTANBUL'  --TOPLAM 36 SATIR VARDI ŞİMDİ 27 OLDU . YANİ YAŞLARI FARKLI 27 KİŞİ VAR DEMEK .

--HANGİ YAŞ GURUBUNDAN KAÇ TANE MÜŞTERİM VAR ? BUNUN SORGUSUNU NASIL YAZABİLİRİZ?
--ÖNÜMÜZDEKİ DERSLERDE BUNUN UYGULAMASINI YAPIYOR OLACAĞIZ.
--KISACA BU DERSTE DISTINCT TEKRAR EDEN SATIRLARI TEKİLLEŞTİRME YAPAN BİR KOMUTTUR.