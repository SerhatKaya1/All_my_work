--USE HastaneDb
--SELECT * FROM Bolumler

--USE HastaneDb
--SELECT * FROM Doktorlar

--USE HastaneDb
--SELECT adSoyad as 'AD SOYAD' , adres as ADRES FROM Doktorlar



--F�LTREMELE
--SELECT * FROM Doktorlar WHERE id=5
--SELECT * FROM Doktorlar WHERE adSoyad='Tuna Sefer'
--SELECT * FROM Doktorlar WHERE adSoyad!='Tuna Sefer'
--SELECT * FROM Doktorlar WHERE id=3 OR id=6
--SELECT * FROM Doktorlar WHERE NOT adSoyad='Tuna Sefer'
--SELECT * FROM Doktorlar WHERE bolumId=5 AND adres='�zmir'
--SELECT * FROM Doktorlar WHERE id>=6

--SELECT * FROM Doktorlar WHERE adres IN ('Ankara', '�stanbul')

--SELECT * FROM Doktorlar WHERE adSoyad LIKE 't%'
--SELECT * FROM Doktorlar WHERE adSoyad LIKE 'tut%'
--SELECT * FROM Doktorlar WHERE adSoyad LIKE '%Evgar'
--SELECT * FROM Doktorlar WHERE adSoyad LIKE '%s%'
--SELECT * FROM Doktorlar WHERE adSoyad LIKE '_e%'
--SELECT * FROM Doktorlar WHERE adSoyad LIKE 'D_m%'

--SIRALAMA
--SELECT * FROM Doktorlar ORDER BY adSoyad
--SELECT * FROM Doktorlar ORDER BY adSoyad DESC
--SELECT * FROM Doktorlar ORDER BY bolumId DESC
--SELECT * FROM Doktorlar ORDER BY adres
--SELECT * FROM Doktorlar ORDER BY adres, adSoyad DESC

--HESAPLAMA
--USE KutuphaneDb
--SELECT * FROM Kitaplar
--SELECT MIN(sayfaSayisi) as 'En Az Sayfa Say�s�' FROM Kitaplar
--SELECT MAX(sayfaSayisi) as 'En Y�ksek Sayfa Say�s�' FROM Kitaplar
--SELECT COUNT(*) FROM Kitaplar

--USE HastaneDb
--SELECT COUNT(*) FROM Doktorlar
--SELECT COUNT(bolumId) FROM Doktorlar

--USE KutuphaneDb
--SELECT AVG(sayfaSayisi) FROM Kitaplar
--SELECT SUM(stok) FROM Kitaplar
--SELECT SUM(stok * sayfaSayisi) FROM Kitaplar

--STRING
--USE HastaneDb
--SELECT LEN('Engin Niyazi Erg�l')
--SELECT adSoyad, LEN(adSoyad) as 'Uzunluk' FROM Doktorlar
--SELECT
--	adSoyad, 
--	LEFT(adSoyad,3) as '�lk 3 Karakter',
--	LEN(adSoyad) as 'Uzunluk'
--FROM Doktorlar
--SELECT
--	adSoyad,
--	UPPER(adSoyad) as 'B�Y�K',
--	LOWER(adSoyad) as 'k���k'
--FROM Doktorlar

--SELECT
--	REPLACE('Engin Niyazi Erg�l','n','MERHABA')

--SELECT
--	LOWER(REPLACE('Engin Niyazi Erg�l',' ','')) + '@benimfirmam.com'

--SELECT
--	adSoyad,
--	REPLACE(LOWER(adSoyad),' ','') + '@firma.com' as 'Mail Adresi'
--FROM Doktorlar

--Sercan Furkan ad�nda, Amasya'da ya�ayan, b�l�m� 3 olan doktoru
--kaydedecek sorguyu yaz�n�z.
--USE HastaneDb
--INSERT INTO Doktorlar VALUES
--('Sercan Furkan','Amasya',3)

--USE HastaneDb
--INSERT INTO Doktorlar (adSoyad, adres, bolumId) VALUES
--('Sercan Furkan','Amasya',3)

--G�NCELLEME
--USE HastaneDb
--UPDATE Doktorlar SET adSoyad = 'Sercan Ahmet Furkan'
--WHERE id=12

--USE HastaneDb
--UPDATE Doktorlar SET adSoyad = 'Al sana yeni isim!'

--USE KutuphaneDb
--UPDATE Kitaplar SET sayfaSayisi = sayfaSayisi * 1.2

--S�LME
--USE HastaneDb
--DELETE FROM Doktorlar WHERE id=6

USE HastaneDb
DELETE FROM Doktorlar WHERE bolumId IS NULL

