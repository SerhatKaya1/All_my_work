CREATE DATABASE SirketDb2
GO

USE SirketDb2

CREATE TABLE Departmanlar(
	id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ad NVARCHAR(MAX) NOT NULL
)

INSERT INTO Departmanlar(ad) VALUES 
	('Muhasebe'),
	('Teknik'),
	('Satýþ'),
	('ÝK'),
	('Yönetim')

/*
	Ýþçi, Muhasebe Uzmaný, Satýþçý, ÝK Uzmaný, ÝK Stajyeri, Yönetici,
	Yönetici Yardýmcýsý
*/

USE SirketDb2
CREATE TABLE Unvanlar(
	id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ad NVARCHAR(50) NOT NULL
)

INSERT INTO Unvanlar(ad) VALUES 
	('Ýþçi'),
	('Muhasebe Uzmaný'),
	('Satýþçý'),
	('ÝK Uzmaný'),
	('ÝK Stajyeri'),
	('Yönetici'),
	('Yönetici Yardýmcýsý')

USE SirketDb2
CREATE TABLE Iller(
	id CHAR(2) NOT NULL PRIMARY KEY,
	ad NVARCHAR(30) NOT NULL
)

INSERT INTO Iller(id, ad) VALUES
	('34', 'Ýstanbul'), 
	('06', 'Ankara'),
	('35', 'Ýzmir'),
	('58', 'Sivas'),
	('41', 'Ýzmit')

USE SirketDb2
CREATE TABLE Ilceler(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ad NVARCHAR(30) NOT NULL,
	ilId CHAR(2) NOT NULL,
	FOREIGN KEY(ilId) REFERENCES Iller(id)
)

INSERT INTO Ilceler (ad, ilId) VALUES
	('Kadýköy', '34'),
	('Beþiktaþ', '34'),
	('Avcýlar', '34'),
	('Konak', '35'),
	('Yenimahalle', '06'),
	('Çankaya','06'),
	('Suþehri', '58')

USE SirketDb2
CREATE TABLE Personeller(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ad NVARCHAR(25) NOT NULL,
	soyad NVARCHAR(25) NOT NULL,
	cinsiyet BIT NOT NULL,
	dogumTarihi DATE NOT NULL,
	ikametgahIlceId INT NOT NULL,
	iseBaslamaTarihi DATE NOT NULL,
	departmanId INT NOT NULL,
	unvanId INT NOT NULL,
	maas MONEY NOT NULL,
	FOREIGN KEY(ikametgahIlceId) REFERENCES Ilceler(id),
	FOREIGN KEY(departmanId) REFERENCES Departmanlar(id),
	FOREIGN KEY(unvanId) REFERENCES Unvanlar(id)
)

INSERT INTO Personeller 
	(ad, soyad, cinsiyet, dogumTarihi, ikametgahIlceId, iseBaslamaTarihi,
		departmanId, UnvanId, Maas) VALUES 
		('Alican','Kabak',0,'1999-05-15',1,'2021-11-10', 1, 4, 12500),
		('Sude','Canöz',1,'1999-05-15',2,'2021-11-10', 2, 5, 22500),
		('Yaþar','Tel',0,'1999-05-15',3,'2021-11-10', 3, 6, 32500),
		('Kemal','Faraba',0,'1999-05-15',4,'2021-11-10', 4, 7, 12800),
		('Zeliha','Gülenyüz',1,'1999-05-15',5,'2021-11-10', 5, 7, 12000),
		('Armanc','Ekþisurat',1,'1999-05-15',6,'2021-11-10', 1, 6, 17500),
		('Kadriye','Ýpçeken',1,'1999-05-15',7,'2021-11-10', 2, 5, 15000),
		('Fatih','Elebakan',0,'1999-05-15',1,'2021-11-10', 3, 4, 18500),
		('Kaya','Kurtlutepe',0,'1999-05-15',2,'2021-11-10', 4, 3, 19500),
		('Selçuk','Tepe',0,'1999-05-15',3,'2021-11-10', 5, 2, 16500),
		('Arda','Güler',0,'1999-05-15',4,'2021-11-10', 1, 1, 33500)

USE SirketDb2
CREATE TABLE Projeler(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ad NVARCHAR(50) NOT NULL,
	baslamaTarihi DATE NOT NULL,
	planlananBitisTarihi DATE NOT NULL
)

INSERT INTO Projeler(ad, baslamaTarihi, planlananBitisTarihi) VALUES
	('Mutlu Çocuklar', '2022-5-5', '2022-8-5'),
	('Temiz Üsküdar', '2022-5-5', '2022-8-5'),
	('Kirli Kadýköy', '2022-5-5', '2022-8-5'),
	('Haydi Gençler Elele', '2022-5-5', '2022-8-5')



	USE SirketDb2
	INSERT INTO Departmanlar(ad) VALUES ('Yeni departman')