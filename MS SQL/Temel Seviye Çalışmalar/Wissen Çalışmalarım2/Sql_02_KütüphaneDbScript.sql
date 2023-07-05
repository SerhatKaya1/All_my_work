/*
1) KutuphaneDb ad�nda bir veri taban� olu�turunuz.
2) Veritan�nda a�a��daki tablolar bulunsun:
	Turler
	Yazarlar
	Yayinevleri
	Uyeler
	Kitaplar
	OduncIslemleri
3) Yeteri kadar �rnek veri giri�i de yap�n�z.

*/

USE master
GO

DROP DATABASE IF EXISTS KutuphaneDb
GO

CREATE DATABASE KutuphaneDb
GO

USE KutuphaneDb
CREATE TABLE Turler
	(
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		turAd VARCHAR(30) UNIQUE
	)
GO


INSERT INTO Turler VALUES
	('Genel'),('Ba�vuru'),('Bilgisayar'),('Edebiyat'),('Ders Kitab�')
GO

CREATE TABLE Yazarlar
	(
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		adSoyad VARCHAR(30),
		cinsiyet VARCHAR(1),
		dogumTarihi DATE,
		tel VARCHAR(11),
		mail VARCHAR(40)
	)
GO
INSERT INTO Yazarlar VALUES
('Orhan Pamuk','E','1950-1-1','55555','opamuk1@gmail.com'),
('Orhan Yamuk','E','1970-1-1','44444','opamuk3@gmail.com'),
('Osman Pamuk','K','1960-1-1','22222','opamuk4@gmail.com'),
('Orhan Tanuk','E','1970-1-1','99999','opamuk2@gmail.com')

CREATE TABLE Yayinevleri
	(
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		ad VARCHAR(50) UNIQUE,
		adres VARCHAR(50),
		tel VARCHAR(11)
	)
GO

INSERT INTO Yayinevleri VALUES
('K�rm�z� �nek Yay�nevi','Beyo�lu','55555'),
('Mavi Portakal Bas�m Da��t�m','Bak�rk�y','11111'),
('Turuncu G�ky�z� Yay�nlar�','Kad�k�y','898989')

CREATE TABLE Uyeler
	(
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		adSoyad VARCHAR(30),
		cinsiyet VARCHAR(1),
		dogumTarihi DATE,
		tel VARCHAR(11),
		mail VARCHAR(40),
		uyelikTarihi DATE,
		uyelikTipi INT,
		tcNo VARCHAR(11),
		meslek VARCHAR(30),
		egitimDurumu INT,
		cezaDurumu BIT
	)
GO

INSERT INTO Uyeler (AdSoyad, Cinsiyet, UyelikTipi, EgitimDurumu, CezaDurumu)
VALUES
--�yelik Tipi: 1 ya da 2
--E�itim Durumu: 1-5 aras�nda
--Ceza Durumu: 0 ya da 1
('Ferhat Ald�verdi','E',1,3,0),
('Canan G�na�maz','K',2,1,0),
('Ferdi Tayfur','E',2,4,0),
('Sezen Aksu','K',1,2,0),
('Tarkan Teveto�lu','E',2,4,0)
GO

CREATE TABLE Kitaplar
	(
		ISBN VARCHAR(13) NOT NULL PRIMARY KEY,
		ad VARCHAR(100),
		sayfaSayisi INT,
		stok INT,
		turId INT DEFAULT 1 FOREIGN KEY REFERENCES Turler(id) ON DELETE SET DEFAULT,
		yazarId INT FOREIGN KEY REFERENCES Yazarlar(id) ON DELETE SET NULL,
		yayinEviId INT FOREIGN KEY REFERENCES Yayinevleri(id) ON DELETE CASCADE
	)
GO

INSERT INTO Kitaplar (ISBN, Ad, TurId, YazarId, yayinEviId)
--TurId: 1-4
--YazarId: 1-4
--YayinEviId: 1-3
VALUES
('44444','C# Programlamaya Giri�',2,3,2),
('55555','Kara Kitap',3,1,1),
('88888','Vegan Olma Rehberi',4,2,1),
('99999','G��e Bakal�m',3,2,3),
('77777','E-Ticaretin Kap�lar�',2,4,1)
GO

CREATE TABLE Odunc
	(
		id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
		uyeId INT FOREIGN KEY REFERENCES Uyeler(id) ON DELETE CASCADE, 
		kitapISBN VARCHAR(13) FOREIGN KEY REFERENCES Kitaplar(ISBN) ON DELETE CASCADE,
		verilisTarihi DATE,
		teslimTarihi DATE,
		iptal BIT DEFAULT 0
	)
GO

INSERT INTO Odunc (uyeId, kitapISBN, verilisTarihi) VALUES
	(1,'44444','2022-11-7'),
	(2,'88888','2022-10-7'),
	(3,'77777','2022-9-7')
