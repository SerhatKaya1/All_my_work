SELECT * FROM Customers 

--WHERE CITY <> 'İstanbul'
--ikiside aynı anlama gelmektedir. Eşit değildir demek .
--WHERE NOT  CITY = 'İzmir' 

--Cinsiyeti erkek olanlara bakalaım.
--WHERE GENDER = 'E'
--WHERE BIRTHDAY>'1990-01-01'
--WHERE BIRTHDAY BETWEEN '19900101' AND '19981231'      --ikisineden eşit olanlarıda dahil ediyoruz. O tarihte doğanlarda dahil ediliyor.>= ve <= demek oluyor
 --WHERE AGE BETWEEN 22 AND 30 --YUKARIDAKİ VE AŞAĞIDAKİ KOMUT AYNI ŞEYİ İFADE EDİYOR
 --UPDATE Customers SET AGE = DATEDIFF(YEAR,BIRTHDAY,GETDATE()) --ŞİMDİKİ ZAMANLA ARADAKİ FARKI GÜNCELLEDİK.

-- WHERE COSTOMERNAME LIKE '%AL%' --HERHANGİ BİR YERİNDE AL BULUNAN İSİMLERİ BANA GETİRECEK
--NOT: LIKE BİR ALAN İÇERİSİNDE DAHA ÇOK ARAMA YAPMAYA YARAMAKTADIR.
--WHERE COSTOMERNAME NOT LIKE '%ALİ%' --İSMİ ALİ İLE BAŞLAMAYANLARI BANA GETİR DEMİŞ OLUYORUZ.

--IN : BİR VERİ SETİ İÇERİSİNDE BİRDEN FAZLA KARŞILAŞTIRMA YAPMAYA YARAMAKTADIR. aslında CITY = Istanbul demek ile aynı şeydir.
--2 şehirden daha fazla şehir yazarak da getirme işlemi yapabiliriz.

--WHERE CITY IN ('İstanbul','Ankara')

--Cinsiyeti kadın ve erkek olanlarda k ve e yerine ben kadın ve erkek olarak yazdırma işlemi yapmak istiyorum diyelim.
--İlk önce design kısmından varchar 1 i 10 olarak değiştirdikten sonra kayıt yapmak istersek hata alırız. Sistem güvenlik olarak bunu kayıt
--kaymama izin vermez . Bunu kaldırmak için Tool + Options + Designers + Table and Database Designers kısmından 
--prevent saving changes that require table re - cration bu seçeneği kaldırmak gerekmektedir . Bu alan ise şunu ifade etmektedir . 
--tablonun yeniden yapılmasını gerektiren değişikliklerin kaydedilmesini önleme alanı seçili olsun veya olmasın demek için vardır.

UPDATE Customers SET GENDER='KADIN' WHERE GENDER='K' --E OLANLAR artık erkek şekline gelmiştir.update komutunun içerisinde bir where şartı kullandık.

--NOT : İlk erkek için yaptım ve aynı sorguda daha sonra kadınlar için yaptım ve kadın ve erkeklerin bilgileri güncellenmiş oldu.

--ŞİMDİ 18 NUMARALI KAYDI SİLMEYE ÇALIŞALIM . 
DELETE FROM Customers WHERE ID=18