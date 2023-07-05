USE Northwind

--SELECT DISTINCT CategoryId FROM Products

--1) Bugüne kadar hangi ülkelere kargo göndermişiz?

--SELECT DISTINCT ShipCountry FROM Orders
--ORDER BY ShipCountry

--2) Hangi ülkeye ne kadar satış yapmışız?
--SELECT O.ShipCountry, SUM(OD.Quantity * OD.UnitPrice) AS 'Toplam Tutar' FROM Orders O INNER JOIN [Order Details] OD
--ON O.OrderID = OD.OrderID
--GROUP BY O.ShipCountry
--ORDER BY 'Toplam Tutar' DESC

--3) En çok satış yapılan üç ülke
--SELECT TOP(3) O.ShipCountry, SUM(OD.Quantity * OD.UnitPrice) AS 'Toplam Tutar' FROM Orders O INNER JOIN [Order Details] OD
--ON O.OrderID = OD.OrderID
--GROUP BY O.ShipCountry
--ORDER BY 'Toplam Tutar' DESC

--4) Elimizde en çok stoğu bulunan ilk üç ürün
--SELECT TOP(3) P.ProductName, P.UnitsInStock FROM Products P
--ORDER BY P.UnitsInStock DESC

--5) Hangi kategoride kaç adet ürünümüz var?
--SELECT C.CategoryName, COUNT(*) As Adet FROM Categories C INNER JOIN Products P
--ON C.CategoryID = P.CategoryID
--GROUP BY C.CategoryName
--HAVING COUNT(*)>10
--ORDER BY Adet DESC

--6) Hangi üründen kaç tane satılmıştır?
--7) En çok kazandıran ilk üç ürün?
--8) Hangi kargo şirketine ne kadar ödeme yapılmıştır?(Freight)
--9) En az ödeme yapılmış kargo şirketi?



--6)
--SELECT P.ProductName, COUNT(*) AS 'Adet' FROM Products P INNER JOIN [Order Details] OD
--ON P.ProductID = OD.ProductID
--GROUP BY P.ProductName
--ORDER BY Adet DESC

--7)
--SELECT TOP(3) P.ProductName, SUM(OD.Quantity * OD.UnitPrice) AS 'Total' FROM Products P INNER JOIN [Order Details] OD
--ON P.ProductID = OD.ProductID
--GROUP BY P.ProductName
--ORDER BY Total DESC

--8) 
--SELECT S.CompanyName, SUM(O.Freight) AS Total  FROM Shippers S INNER JOIN Orders O
--ON S.ShipperID=O.ShipVia
--GROUP BY S.CompanyName
--ORDER BY Total DESC

--9)
--SELECT TOP(1) S.CompanyName, SUM(O.Freight) AS Total  FROM Shippers S INNER JOIN Orders O
--ON S.ShipperID=O.ShipVia
--GROUP BY S.CompanyName
--ORDER BY Total

--10) Hangi müşteriye ne kadar tutarında satış yapılmış?
--SELECT C.CompanyName, SUM(OD.Quantity*OD.UnitPrice) AS TOTAL
--FROM Customers C
--INNER JOIN Orders O ON C.CustomerId=O.CustomerID
--INNER JOIN [Order Details] OD
--ON O.OrderID=OD.OrderID
--GROUP BY C.CompanyName
--ORDER BY TOTAL DESC

--11) Bölgelere göre satış tutarları

--SELECT R.RegionDescription, SUM(OD.Quantity * OD.UnitPrice) Total  FROM Employees E 
--INNER JOIN EmployeeTerritories ET ON E.EmployeeID=ET.EmployeeID
--INNER JOIN Territories T ON ET.TerritoryID=T.TerritoryID
--INNER JOIN Region R ON T.RegionID=R.RegionID
--INNER JOIN Orders O ON E.EmployeeID=O.EmployeeID
--INNER JOIN [Order Details] OD ON O.OrderID=OD.OrderID
--GROUP BY R.RegionDescription
--ORDER BY Total DESC

--12) Hangi bölgede, hangi üründen kaç paralık satış yapılmıştır?
SELECT R.RegionDescription, P.ProductName, SUM(OD.Quantity * OD.UnitPrice) Total  FROM Employees E 
INNER JOIN EmployeeTerritories ET ON E.EmployeeID=ET.EmployeeID
INNER JOIN Territories T ON ET.TerritoryID=T.TerritoryID
INNER JOIN Region R ON T.RegionID=R.RegionID
INNER JOIN Orders O ON E.EmployeeID=O.EmployeeID
INNER JOIN [Order Details] OD ON O.OrderID=OD.OrderID
INNER JOIN Products P ON OD.ProductID=P.ProductID
GROUP BY R.RegionDescription, P.ProductName
ORDER BY R.RegionDescription, P.ProductName, Total DESC