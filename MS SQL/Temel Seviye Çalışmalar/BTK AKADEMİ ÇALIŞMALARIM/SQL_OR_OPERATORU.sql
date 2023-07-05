SELECT * FROM Customers

--WHERE --CITY IN ('İSTANBUL', 'İZMİR' , 'BURSA') AŞAĞIDAKİ İLE AYNI ANLAMA GELİYOR GİBİ DÜŞÜNEBİLİRİZ.

--CITY='İSTANBUL' OR CITY='İZMİR' OR CITY='BURSA'

--a=a 36 b=b 25 burada bana kesişim değil birleşimi getirecek.

--WHERE BIRTHDAY >='19900101' AND BIRTHDAY<='19981231'

--WHERE BIRTHDAY >='19900101' OR BIRTHDAY<='19981231'
--1990 dan büyük olanlar ve 1998 den küçük olanları getir. Bu ikisinin birleşimini al diyoruz.

WHERE NOT BIRTHDAY BETWEEN '19900101' AND '19981231' --1990 ve 1998 arasında doğmayanların listesini bana getir demiş oluyoruz.
--üstteki ve alttaki formül aynı anlama gelmektedir.
-- WHERE BIRTHDAY <='19900101' OR BIRTHDAY>='19981231' --(1990 dahil ve önceki yılları veya  1998 dan büyük olan yılları getirecek)

/*
not : Kısaca or dediğimizde aklımıza birleşim gelecek ve and dediğimizde ise kesişim gelecek . And varsa tüm şartların sağlanmış olması gerekmektedir
Or da ise şartların 1 tanesinin sağlanması yeterli olacaktır.
*/
