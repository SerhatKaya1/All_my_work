--JOIN İLE YAPAMAYACAĞIMIZ BİR ÖRNEKDEN BAHSEDELİM .
--EN ÇOK HANGİ AY SATILDI...
SET STATISTICS IO ON 
SELECT ITM.ITEMCODE AS URUNKODU,
ITM.ITEMNAME AS URUNADI,
(SELECT MIN(UNITPRICE) FROM ORDERDETAILS WHERE ITEMID=ITM.ID) AS ENDUSUKFIYAT,
(SELECT MAX(UNITPRICE) FROM ORDERDETAILS WHERE ITEMID=ITM.ID) AS ENYUSEKFIYAT,
(SELECT AVG(UNITPRICE) FROM ORDERDETAILS WHERE ITEMID=ITM.ID) AS ORTALAMA_FIYAT,
(SELECT SUM(AMOUNT) FROM ORDERDETAILS WHERE ITEMID=ITM.ID) AS TOPLAM_ADET,
(
SELECT TOP 1 DATEPART(MONTH,O.DATE_) AS AY FROM ORDERDETAILS OD
INNER JOIN ORDERS O ON OD.ORDERID=O.ID
WHERE OD.ITEMID=ITM.ID --1 yerine ITM.ID Değerini gönderdik.
GROUP BY DATEPART(MONTH,O.DATE_)
ORDER BY SUM(AMOUNT) DESC --satış adedine göre tersden sıraladık.
) AS ENCOKSATILANAY
FROM
ITEMS ITM
--WHERE (SELECT MIN(UNITPRICE FROM ORDERDETAILS WHERE ITEMID=ITM.ID) IS NULL  --Burada od den gelen boş kolonlaru bu şekilde çektik 
WHERE ITM.ID NOT IN --(item tablosunda id değeri alttaki sorguda olmayanları getir demiş oluyoruz)
(SELECT ITEMID FROM ORDERDETAILS) --ORDERDETAILS TABLOSUNDA DEĞİLSE BANA GETİR DEMİŞ OLUYORUZ.
--subquery i bir dataset olarak değerlendirdik
/*
En yukarıda kolon olarak değerlendirme yapıyorduk ve aggregate fonksiyon ile çekiyorduk . Oysa en alttaki yaptığımızda ise
(SELECT ITEMID FROM ORDERDETAILS) burada ise bir dataset olarak değrlendirme yaptım ve ona filtre olarak gönderdim.
Not In dediğimde hiç sipariş olmayan satırları getirdim. In dediğimde ise iiner join in farklı bir yöntemini uygulamış olduk.
Yerine göre subquery yerine göre join kullanmak gerekir . Eğer join ile yapma imkanımız varsa bunu subquery ile yapmak 
anlamsız olacaktır. Hem performans açısından hemde kodumuzun okunaklılığı açısından daha önemlidir. 
En çok ay ı bulduğumuz örneklerde gibi örneklerde ise subquery kullanmak çok daha iyidir.
*/


--KULLANICININ SON ADRESİNİ BULALIM.
SELECT TOP 1 U.*,A.ADDRESSTEXT,A.ID FROM
USERS U
INNER JOIN ADDRESS A ON U.ID=A.USERID

WHERE U.ID=1
ORDER BY A.ID DESC
--(yukarıdaki sorguda son adresi getirmek için subquery kullanmak dışında başka şansımız yok.)


SELECT U.*, --kullanıcıya ait tüm bilgileri getiriyoruz.
(SELECT TOP 1 ADDRESSTEXT FROM ADDRESS WHERE USERID=U.ID ORDER BY ID DESC) SONADRESS,
(SELECT TOP 1 ADDRESSTEXT FROM ADDRESS WHERE USERID=U.ID ORDER BY ID) ILKADRESS,
(SELECT COUNT(ADDRESSTEXT) FROM ADDRESS WHERE USERID=U.ID) ADRESSSAYISI
FROM USERS U

WHERE U.ID=1

