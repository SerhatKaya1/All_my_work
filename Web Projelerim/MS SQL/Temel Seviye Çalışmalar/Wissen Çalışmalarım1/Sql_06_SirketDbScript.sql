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
	('Sat��'),
	('�K'),
	('Y�netim')

/*
	���i, Muhasebe Uzman�, Sat����, �K Uzman�, �K Stajyeri, Y�netici,
	Y�netici Yard�mc�s�
*/

USE SirketDb2
CREATE TABLE Unvanlar(
	id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ad NVARCHAR(50) NOT NULL
)

INSERT INTO Unvanlar(ad) VALUES 
	('���i'),
	('Muhasebe Uzman�'),
	('Sat����'),
	('�K Uzman�'),
	('�K Stajyeri'),
	('Y�netici'),
	('Y�netici Yard�mc�s�')

USE SirketDb2
CREATE TABLE Iller(
	id CHAR(2) NOT NULL PRIMARY KEY,
	ad NVARCHAR(30) NOT NULL
)

INSERT INTO Iller(id, ad) VALUES
	('34', '�stanbul'), 
	('06', 'Ankara'),
	('35', '�zmir'),
	('58', 'Sivas'),
	('41', '�zmit')

USE SirketDb2
CREATE TABLE Ilceler(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ad NVARCHAR(30) NOT NULL,
	ilId CHAR(2) NOT NULL,
	FOREIGN KEY(ilId) REFERENCES Iller(id)
)

INSERT INTO Ilceler (ad, ilId) VALUES
	('Kad�k�y', '34'),
	('Be�ikta�', '34'),
	('Avc�lar', '34'),
	('Konak', '35'),
	('Yenimahalle', '06'),
	('�ankaya','06'),
	('Su�ehri', '58')

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
		('Sude','Can�z',1,'1999-05-15',2,'2021-11-10', 2, 5, 22500),
		('Ya�ar','Tel',0,'1999-05-15',3,'2021-11-10', 3, 6, 32500),
		('Kemal','Faraba',0,'1999-05-15',4,'2021-11-10', 4, 7, 12800),
		('Zeliha','G�leny�z',1,'1999-05-15',5,'2021-11-10', 5, 7, 12000),
		('Armanc','Ek�isurat',1,'1999-05-15',6,'2021-11-10', 1, 6, 17500),
		('Kadriye','�p�eken',1,'1999-05-15',7,'2021-11-10', 2, 5, 15000),
		('Fatih','Elebakan',0,'1999-05-15',1,'2021-11-10', 3, 4, 18500),
		('Kaya','Kurtlutepe',0,'1999-05-15',2,'2021-11-10', 4, 3, 19500),
		('Sel�uk','Tepe',0,'1999-05-15',3,'2021-11-10', 5, 2, 16500),
		('Arda','G�ler',0,'1999-05-15',4,'2021-11-10', 1, 1, 33500)

USE SirketDb2
CREATE TABLE Projeler(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ad NVARCHAR(50) NOT NULL,
	baslamaTarihi DATE NOT NULL,
	planlananBitisTarihi DATE NOT NULL
)

INSERT INTO Projeler(ad, baslamaTarihi, planlananBitisTarihi) VALUES
	('Mutlu �ocuklar', '2022-5-5', '2022-8-5'),
	('Temiz �sk�dar', '2022-5-5', '2022-8-5'),
	('Kirli Kad�k�y', '2022-5-5', '2022-8-5'),
	('Haydi Gen�ler Elele', '2022-5-5', '2022-8-5')



	USE SirketDb2
	INSERT INTO Departmanlar(ad) VALUES ('Yeni departman')