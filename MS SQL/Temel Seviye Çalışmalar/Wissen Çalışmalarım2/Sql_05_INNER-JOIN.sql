-- Products tablosunu Unit Price kolonuna göre büyükten küçüğe sıralayınız.

--USE Northwind
--SELECT * FROM Products
--ORDER BY UnitPrice DESC

-- UnitPrice'ı 100 ve üzerinde olan ürünleri listele
--USE Northwind
--SELECT * FROM Products
--WHERE  UnitPrice >=100

-- Kategorisi 7 ve 8 olan ürünleri listeleyiniz.
--USE Northwind
--SELECT * FROM Products
--WHERE CategoryID = 7 OR CategoryID = 8

-- Kategorisi 7 ve 8 olanlardan stok miktarı (UnitsInStock) 10 olan ürünleri listeleyiniz.
--USE Northwind
--SELECT * FROM Products
--WHERE (CategoryID = 7 OR CategoryID = 8) AND UnitsInStock <= 10

-- Kategorisi 7 ve 8 olanlardan stok miktarı (UnitsInStock) 10 olan ürünlerin sayısı.
--USE Northwind
--SELECT COUNT(*) FROM Products
--WHERE (CategoryID = 7 OR CategoryID = 8) AND UnitsInStock <= 10
--WHERE (CategoryID = 9 OR CategoryID = 3) AND UnitsInStock <= 50

-----------------------INNER JOIN-------------------
--SELECT Products.ProductName, Categories.CategoryName FROM Products INNER JOIN Categories
--	ON Products.CategoryID = Categories.CategoryID

--SELECT P.ProductName, C.CategoryName 
--FROM Products P INNER JOIN Categories C
--ON P.CategoryID = C.CategoryID
--WHERE CategoryName = 'Beverages' AND P.UnitPrice <= 40
--ORDER BY P.UnitPrice DESC

--Product Name ve Supplier Company Name'i gösteren bir sorgu yazınız.
--SELECT P.ProductName, S.City
--FROM Products P INNER JOIN Suppliers S
--ON P.SupplierID = S.SupplierID

--Germany'den tedarik edilen ürünlerin Product Name listesi
--SELECT P.ProductName
--FROM Products P INNER JOIN Suppliers S
--ON P.SupplierID = S.SupplierID
--WHERE  S.Country = 'Germany'

--Germany'den tedarik edilen ürünlerin toplam tutarı
--SELECT SUM(P.UnitPrice * P.UnitsInStock) as 'Toplam Tutar'
--FROM Products P INNER JOIN Suppliers S
--ON P.SupplierID = S.SupplierID
--WHERE  S.Country = 'Germany'

--Chai satışlarının toplam tutarı
--SELECT SUM(OD.UnitPrice * OD.Quantity)
--FROM Products P INNER JOIN [Order Details] OD
--ON P.ProductID = OD.ProductID
--WHERE P.ProductName = 'Chai'

--Germany'e yapılmış olan Chai satışlarının toplam tutarı
--SELECT SUM(OD.UnitPrice * OD.Quantity)
--FROM ORDERS O INNER JOIN [Order Details] OD
--ON O.OrderID = OD.OrderID INNER JOIN Products P
--ON OD.ProductID = P.ProductID
--WHERE P.ProductName = 'Chai' AND O.ShipCountry = 'Germany'

--Ernst Handel adlı müşterisine yapılan satış tutarının toplamı
SELECT SUM(OD.UnitPrice* OD.Quantity) 
FROM [Order Details] OD INNER JOIN Orders O
ON OD.OrderID = O.OrderID INNER JOIN Customers C
ON O.CustomerID = C.CustomerID
WHERE C.CompanyName = 'Ernst Handel'
