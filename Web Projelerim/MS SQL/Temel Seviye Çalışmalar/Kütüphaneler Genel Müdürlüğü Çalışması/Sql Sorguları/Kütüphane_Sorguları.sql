--a.İsmi “Kar” ile başlayan kitalalpları listeleyiniz.
select bookName
from Books
where bookName like 'Kar%'

--b.Tüm kitapları Kategori bazında (Roman, Hikaye, Tarih v.s.) kitap sayılarını listeleyiniz.
select categoryName,count(*) as Kitap_Sayisi
from Books b inner join Categories c on c.ID= b.categoryId 
group by c.categoryName

--c.Tüm Kütüphanlerin listesi. (Kütüphane Adı, il, İlçe)
select *
from Libraries lb 
inner join Lib_Adress la on lb.ID= la.ID
inner join Countries c on c.Id=la.countryID
inner join Cities ct on ct.ID = la.cityID
left join Towns t on t.ID= la.townID

--d.Kütüphanelerde bulunan kitaplarin stok sayılarını listeleyiniz. (Kütüphane, Kitap, Stok Sayısı)

select l.name kütüphaneAdı, b.bookName kitapAdı,stockQuantity
from Libraries l 
left join Books b on l.bookID= b.ID

--e.Kütüphaneden bağımsız olarak en çok kitap alan 10 öğrenci kimdir?
select top 10 st.name,st.surname
from Libraries lr 
inner join Books  bs on lr.bookID=bs.ID
inner join RentalTables rt on rt.bookID= bs.ID
inner join Students st on st.ID=rt.studentID

--f.Kitap getirmesi 15 günden fazla geciken öğrencileri listeler misiniz?
select st.name,st.surname,DATEDIFF(DAY,CONVERT(DATE,rentalDate),CONVERT(DATE,returnDate)) gecikmeSüresi
from RentalTables rt
join Students st on rt.studentID = st.ID 
where DATEDIFF(DAY,CONVERT(DATE,rentalDate),CONVERT(DATE,returnDate)) > 15

