--sayfa sayýsý 300'den büyük eþit olan kitaplarý listeleyin
--USE KutuphaneDb
--SELECT * FROM Kitaplar WHERE sayfaSayisi>=300

--stok adedi 90-113 arasýndakileri listeleyelim
--USE KutuphaneDb
----SELECT * FROM Kitaplar WHERE stok>=90 AND stok<=113
--SELECT * FROM Kitaplar WHERE stok BETWEEN 90 AND 113

--sayfa sayýsý en çok olandan en az olana doðru sýralayalým
--USE KutuphaneDb
--SELECT * FROM Kitaplar ORDER BY sayfaSayisi DESC

--Türe göre küçükten büyüðe sýralayalým
--USE KutuphaneDb
--SELECT * FROM Kitaplar ORDER BY turId, sayfaSayisi DESC