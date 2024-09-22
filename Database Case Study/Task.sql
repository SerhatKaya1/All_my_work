SELECT 
    p.ProductName, 
    YEAR(s.SaleDate) AS Year, 
    SUM(s.Quantity) AS TotalQuantitySold, 
    SUM(s.Quantity * p.Price) AS TotalSalesAmount
FROM Sales s
JOIN Products p ON s.ProductID = p.ProductID
GROUP BY p.ProductName, YEAR(s.SaleDate);



SELECT TOP 1
    p.ProductName, 
    SUM(s.Quantity * p.Price) AS TotalSalesAmount
FROM Sales s
JOIN Products p ON s.ProductID = p.ProductID
GROUP BY p.ProductName
ORDER BY TotalSalesAmount DESC;
