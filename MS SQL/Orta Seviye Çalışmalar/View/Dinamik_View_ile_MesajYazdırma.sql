--D�NAM�K V�EW �LE �OK DAHA RAHAT BU ��LEMLER� YAPAB�L�R�M.
CREATE VIEW VW_BUGUNDOGANLAR AS
SELECT 
NAMESURNAME AD_SOYAD,
'Sn' +'. '+ NAMESURNAME+' ' + GenderXp+'; ' +CONVERT(varchar,AGE) +'. ya��n�z� kutlar ailenile birlikte nice mutlu y�llarge�irmenizi dilerim.' Message_
FROM 
(
SELECT 
NAMESURNAME,GENDER,DATEDIFF(YEAR,BIRTHDATE,GETDATE()) AGE,BIRTHDATE,
IIF(GENDER='K','Han�m','Bey') GenderXp
FROM USERS
WHERE DATEPART(MONTH,BIRTHDATE)=DATEPART(MONTH,GETDATE()) AND
DATEPART(DAY,BIRTHDATE)=DATEPART(DAY,GETDATE())
) T