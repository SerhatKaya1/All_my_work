USE SampleDb

CREATE TABLE Calisanlar(
	id INT NOT NULL IDENTITY(1,1),
	tcNo CHAR(11) NOT NULL,
	adSoyad NVARCHAR(50) NOT NULL,
	cinsiyet BIT NOT NULL,
	bolumId INT NOT NULL,
	PRIMARY KEY(id),
	FOREIGN KEY(bolumId) REFERENCES Bolumler(id)
)

--DROP TABLE Calisanlar