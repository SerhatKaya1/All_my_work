﻿--ÖDEME TÜRLERİNE GÖRE DAĞILIM 
--SELECT * FROM PAYMENTS

--SELECT DISTINCT PAYMENTTYPE FROM PAYMENTS --KAÇ TANE ÖDEME TÜRÜ OLDUĞUNU GÖSTERİR
--KREDİ KARTI VE BANKA HAVALESİ OLMAK ÜZERE 2 ÇEŞİT.
--1-KREDİ KARTI 
--2-BANKA HAVALAESİ

SELECT 
DATEPART(MONTH,DATE_) AS AY,
DATEPART(YEAR,DATE_) AS YIL,
CASE 
    WHEN PAYMENTTYPE=1 THEN 'KREDİ KARTI'
    WHEN PAYMENTTYPE=2 THEN 'BANKA HAVALESİ'
	END AS  ODEMETURU_ACIKLAMA,
SUM(PAYMENTTOTAL) AS TOPLAMTUTAR
FROM PAYMENTS
GROUP BY DATEPART(MONTH,DATE_),PAYMENTTYPE ,DATEPART(YEAR,DATE_)
ORDER BY DATEPART(YEAR,DATE_),DATEPART(MONTH,DATE_)
--NOT PAYMENTYPE ZATEN GROUP BYDA OLDUĞU İÇİN TEKRARDAN YAZMADIK CASE DE KOLON GETİRİRKEN