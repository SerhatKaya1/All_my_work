SELECT 
U.USERNAME_ AS KULLANICIADI,U.NAMESURNAME AS ADSOYAD,
CT.CITY AS IL,T.TOWN AS ILCE,D.DISTRICT AS SEMT,A.ADDRESSTEXT AS ACIKADRES,
O.ID AS SIPARISID,O.DATE_ AS TARIH,O.TOTALPRICE AS TOPLAMTUTAR ,
P.DATE_ AS ODEMETARIHI,P.APPROVECODE AS BANKAONAYKODU,
I.DATE_ AS FATURATARIHI,I.CARGOFICHENO AS KARGOFISHNO,
OD.*,
ITM.*
FROM ORDERS O --REFERANS ORDERS TABLOMDUR.Çünkü 
INNER JOIN USERS U ON U.ID=O.USERID
INNER JOIN ADDRESS A ON A.ID=O.ADDRESSID
INNER JOIN CITIES CT ON CT.ID=A.CITYID
INNER JOIN TOWNS T ON T.ID=A.TOWNID
INNER JOIN DISTRICTS D ON D.ID= A.DISTRICTID
INNER JOIN PAYMENTS P ON P.ORDERID=O.ID
INNER JOIN INVOICES I ON I.ORDERID=O.ID
INNER JOIN ORDERDETAILS OD ON OD.ORDERID=O.ID
INNER JOIN ITEMS ITM ON ITM.ID= OD.ID
--WHERE U.USERNAME_ = 'F_DENIZALP'
WHERE O.ID=3515
/*
FROM ORDERS O
INNER JOIN USERS U ON U.ID=O.USERID

Bu, "ORDERS" tablosunu "USERS" tablosuyla "ID" ve "USERID" sütunlarında birleştiren bir SQL sorgusudur. 
Sonuç tablosu, "USERS" tablosundaki "ID" sütunundaki değerlerin, "ORDERS" tablosundaki "USERID" sütunundaki değerlerle eşleştiği 
tüm satırları içerecektir.

Başka bir deyişle, sorgu, ortak kullanıcı ID sütunu temelinde her iki tablodan gelen verileri birleştirecektir. 
Bu, sipariş geçmişi verilerini demografik veya iletişim bilgileri gibi kullanıcı verileriyle birlikte analiz etmek için faydalı olabilir.
*/
--Burada önemli nokta şu ki id ler üzerinden bir ortak nokta belirlemesi yapıyoruz ve buna göre bir kesişim yapıyoruz . Yanii kolon isimleri
--bir ortaklık aramıyoruz . id ler eşitse osatırlar kesişime yazılıyor.


