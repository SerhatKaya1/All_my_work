--AND/OR OPERATÖRLERİ
--yaşı 30 den büyük olan ve cinsiyeti erkek olanlar. Şehri istanbul olup ismi serhat ile başlayanları bana listele diyebiliriz.
--Bu şekilde birden fazla şartları kullandığımız yapılara biz or operatörleri diyoruz. ve veya operatörleri diyoruz.
SELECT * FROM Customers
--AND OPERATÖRÜ : BU iki şartıda sağlıyor olması gerekmektedir.
--OR OPERATÖRÜ : Birinci şartı veya 2. şartı karşılasın demek istiyoruz . 2 şart içerisinde en az 1 tanesini karşılaması yeterlidir.

--WHERE CITY='İSTANBUL' AND DISTRICT='Beylikdüzü' AND DISTRICT='Esenler'
--Burada önemli bir husus var . a=a and b=b and c=c şartına bakarsak Şehri istanbul ve ilçesi beylikdüzü olanları bana getir demiş oluyoruz.
--İkinci and de ise şehri istanbul ve ilçesi beylikdüzü ve esenler olanları getir demiş oluyoruz ve öyle bir kayıt olmadığı için bize hata mesajı vermektedir.

--WHERE CITY='İSTANBUL' AND GENDER='ERKEK' AND DISTRICT='ESENLER'

/*
a=a 36 , Şehri istabul olan 36 kayıt var demek 
b=b 472  Cinsiyeti erkek olan bu kadar satır var demek. Bu birinci şart
c=c 1 ilçesi esenler olan 2 veri geliyor.ama erkek olanlardan 1 tane var. Bu 3 şartı da sağlayan şartlara bakmak lazım.
AND OPERATÖRÜ BÜTÜN ŞARTLARIN SAĞLANABİLME DURUMUNDA GEÇERLİDİR.
*/

WHERE CITY='İSTANBUL' AND GENDER='ERKEK'
AND BIRTHDAY BETWEEN '19900101' AND '20000101'