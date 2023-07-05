﻿--Mağazaların satış rakamlarına göre satış rakamlarını getirme.
SELECT * FROM SALES

--SELECT DATEPART(MONTH,'2019-08-02') --BANA KAÇINCI AY OLDUĞUNU VERİR.
--DATEPART: Verilen tarih-saat parametresini parçalarına ayırıp istenilen parçayı almaya yarar.
UPDATE SALES SET MONTHNAME_='01.OCAK' WHERE DATEPART(MONTH,DATE2)=1 
--ŞARTIMDA WHERE DATEPART(MONTH,DATE2)=1 OCAK AYINA DENK GELENLER İÇİN 01.OCAK YAZ DEMİŞ OLDUK.
--Eğer 01. yazmazsak aralık ocakdan önce geldiği için Alfabetik sıralamalarda ve ay sırasında karışıklık olacak.01 koyarsam her zaman 01 önce gelir.
UPDATE SALES SET MONTHNAME_='02.ŞUBAT' WHERE DATEPART(MONTH,DATE2)=2
UPDATE SALES SET MONTHNAME_='03.MART' WHERE DATEPART(MONTH,DATE2)=3
UPDATE SALES SET MONTHNAME_='04.NİSAN' WHERE DATEPART(MONTH,DATE2)=4
UPDATE SALES SET MONTHNAME_='05.MAYIS' WHERE DATEPART(MONTH,DATE2)=5
UPDATE SALES SET MONTHNAME_='06.HAZİRAN' WHERE DATEPART(MONTH,DATE2)=6
UPDATE SALES SET MONTHNAME_='07.TEMMUZ' WHERE DATEPART(MONTH,DATE2)=7
UPDATE SALES SET MONTHNAME_='08.AĞUSTOS' WHERE DATEPART(MONTH,DATE2)=8
UPDATE SALES SET MONTHNAME_='09.EYLÜL' WHERE DATEPART(MONTH,DATE2)=9
UPDATE SALES SET MONTHNAME_='10.EKİM' WHERE DATEPART(MONTH,DATE2)=10
UPDATE SALES SET MONTHNAME_='11.KASIM' WHERE DATEPART(MONTH,DATE2)=11
UPDATE SALES SET MONTHNAME_='12.ARALIK' WHERE DATEPART(MONTH,DATE2)=12

--AYLARA GÖRE SATIŞLARI GETİRELİM
SELECT MONTHNAME_,SUM(TOTALPRICE) AS TOTALPRICE 
FROM SALES
GROUP BY MONTHNAME_
ORDER BY MONTHNAME_
--ŞEHİRLERİN AYLARA GÖRE DAĞILIMI GÖRMEK İSTERSEK?
SELECT CITY,MONTHNAME_,SUM(TOTALPRICE) AS TOTALPRICE 
FROM SALES
GROUP BY CITY,MONTHNAME_
ORDER BY CITY,MONTHNAME_

--AYLARA GÖRE İLLERİN SATIŞLARI
SELECT DISTRICT,MONTHNAME_,SUM(TOTALPRICE) AS TOTALPRICE
FROM SALES
GROUP BY DISTRICT,MONTHNAME_
ORDER BY DISTRICT,MONTHNAME_


