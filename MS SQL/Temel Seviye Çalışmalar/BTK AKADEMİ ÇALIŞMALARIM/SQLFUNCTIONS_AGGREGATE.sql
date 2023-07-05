--SELECT * FROM SALES
--SELECT COUNT(*) FROM SALES --TOPLAM SATIR SAYISINI BU ŞEKİLDE DE BULABİLİRİZ. COUNT SAYMAK ANLAMINA GELMEKTEDİR.

SELECT * FROM SALES ORDER BY AMOUNT --En az alan 1 adet almış.En çok alan 10 adet almıştır. Bunu sıralama yaparak rahatça gördük.
--Bunu fonsiyon ile yazmak istersem ;
SELECT MIN(AMOUNT) FROM SALES --Adet olarak en düşük sayı 1 
SELECT MAX(AMOUNT) FROM SALES --Adet olarak en yüksek miktar 10 dur.
--yan yana da yazabilirizi + Satır sayısı
SELECT MIN(AMOUNT),MAX(AMOUNT),COUNT(FICHENO),SUM(AMOUNT),AVG(AMOUNT) FROM SALES  --count içinde * yada herhangi bir alan ıd yazsakta olur.
--SUM TOPLAM SATILAN ÜRÜN ADETLERİ TOPLAMINI VERMEKTEDİR.
--AVG ise ortalama satış adedini bize verir . Toplam satır sayısı/toplam adet miktarı=ortalama satış miktarı
--her müşteri benden ürün aldığında ortalama 5.5 adet ürün satmış oluyoruz.
SELECT * FROM SALES  ORDER BY TOTALPRICE 

SELECT MIN(TOTALPRICE),MAX(TOTALPRICE),COUNT(FICHENO),SUM(TOTALPRICE),AVG(TOTALPRICE) FROM SALES WHERE CITY='ADANA'
--ortalama bir satırın ciro değeri ve toplam ciro değerlerini bize vermektedir.
SELECT MIN(TOTALPRICE),MAX(TOTALPRICE),COUNT(FICHENO),SUM(TOTALPRICE),AVG(TOTALPRICE) FROM SALES WHERE CITY='ANKARA'
--ANKARA İLİ NİN TOPLAM CİROSU VE ORTALAMA SATIŞ MİKTARI GELDİ

SELECT MIN(TOTALPRICE),MAX(TOTALPRICE),COUNT(FICHENO),SUM(TOTALPRICE),AVG(TOTALPRICE) FROM SALES WHERE CITY='istanbul'
--İSTANBUL ŞEHRİ NİN TOPLAM CİROSU VE ORTALAMA SATIŞ MİKTARI GELDİ

--GROUP BY ile aylara göre , şehirlere göre ciro ayarlamasını yapabiliriz burada yukarıda ise tek satırda toplam ciro hesapları yapmış olduk.

SELECT * 
FROM SALES WHERE CITY='ANKARA'
AND DATE2='2019-01-01' --DATE_ ALANINA  BU ŞARTI VERSEYDİK GELMEZDİ.BÖYLE BİR KAYIT YOK.
ORDER BY DATE_


--BİR ŞEHRİN GÜNLERE GÖRE SATIŞLARININ LİSTELENMESİNİ BULUYORUZ
SELECT CITY,DATE2,SUM(TOTALPRICE) AS TOTALPRICE 
FROM SALES WHERE CITY='ANKARA'
GROUP BY CITY,DATE2
ORDER BY CITY,DATE2 --GÜNLERE GÖRE CİROLARINI BULMUŞ OLDUK.

/*
NOT : Bunu asla unutma bir aggregate fonksiyonu geçen bir alan varsa burada diğer yazılan kolonlar vb .de aggregate içinde veya group by 
içerisinde yazılması gerekmektedir aksi halde hata mesajı alırız.
ankara için 365 günlük bir işlem sözkonusu ve ankaradaki satışları bize getiriyor ve burada sıralı bir şekilde gelmiyor.
*/