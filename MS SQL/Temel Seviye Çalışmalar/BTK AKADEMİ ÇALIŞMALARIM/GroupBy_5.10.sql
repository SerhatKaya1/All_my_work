--Mağazaların müşteri sayılarını getirme.
/*
Bir müşteri birden fazla ürün alabilir ve bu ürünlerin tek bir fişde toplanması ve 1 müşteri olarak almak gerekir . Hadi bunu yapalım!
*/
SELECT * FROM SALES
WHERE MONTHNAME_='02.ŞUBAT'
AND CITY='ADANA' --316 tane sonuç geldi.328 nolu fişden 2 işlem geldi.Fishno ya group yaparsam ,  261 satıra inme olacak .Aşağıdaki örnekl 
--bunu açıklıyor.

SELECT FICHENO,COUNT(*) --SATIR SAYIM GURUP YAPTIKTAN SONRA 261 E DÜŞTÜ.Mağaza bazlı benim gerçek sayım 261 dir.
FROM SALES
WHERE MONTHNAME_='02.ŞUBAT'
AND CITY='ADANA'
GROUP BY FICHENO --gerçekte 261 tane fiş kestik yani her bir ürün için ayrı fish kesmedik . Bunları tekilleştirme yapınca satır sayısı azaldı.
--Burada gerçek müşteri sayım 261'dir.

SELECT CITY,FICHENO,COUNT(*) --Burada Adanada şehre ve fiş numarasına göre guruplama yap diyoruz.kesilen fiş sayısını da count(*) ile buluyoruz.
FROM SALES
WHERE MONTHNAME_='02.ŞUBAT'
GROUP BY CITY,FICHENO
ORDER BY CITY
--ADANADA KESİLEN FİŞ SAYISINI TEK SATIR OLARAK GÖRMEK İSTİYORUM DİYELİM.
SELECT CITY,COUNT(*) --ADANADA 316 YAZIYOR
FROM SALES
WHERE MONTHNAME_='02.ŞUBAT'
GROUP BY CITY
ORDER BY CITY

SELECT --tekrar eden satırları//verileri tekilleştirmeye yarayan komut DISTINCT komutudur.
CITY,COUNT(DISTINCT FICHENO),COUNT(*) 
FROM SALES
WHERE MONTHNAME_='02.ŞUBAT'
GROUP BY CITY
ORDER BY CITY
--2.Kolon mağazadan geçen müşteri sayısı sayısı 3.kolon ise orada okutulan barkot sayısı(tekrar eden fiş nolar ile birlikte).

--** Bir mağazanın tekil müşteri sayısınıda hesap etmek isteyelim.Bir mağaza içinde 1 ay içinde 10 kere alışveriş yapalım . 2.kolonda 
--10 kez yazılmış oluyor ama 1 kişiye tekabül ettiğini göstermemiz gerekir.
SELECT 
CITY,COUNT(DISTINCT CUSTOMERNAME) AS UNIQUECUSTOMER,
COUNT(DISTINCT FICHENO) CUSTOMERCOUNT,
COUNT(*) ITEMCOUNT
FROM SALES
WHERE MONTHNAME_='02.ŞUBAT'
GROUP BY CITY
ORDER BY CITY
--1.KOLON : 1 KİŞİNİN ADANA 2 KERE ALIŞVERİŞ YAPTIĞINI GÖRÜYORUZ.
--2.KOLON : MÜŞTERİ SAYISI
--3.KOLON : OKUTULAN BARKOT SAYISI
--ADANADA HER MÜŞTERİ 1 KERE GELMİŞ
--ANKARADA 786 ADET MÜŞTERİ VAR . 789 ADET YAPILAN ALIŞVERİŞ VAR . 961 ADET OKUTULAN BARKOT VAR .
--GURUPLADIĞIMIZ DATAYI KENDİ İÇERİSİNDE TEKİLLEŞTİREREK TEK SATIR İÇERİSİNDE YAZDIRMA İMKANIMIZ OLUYOR...


