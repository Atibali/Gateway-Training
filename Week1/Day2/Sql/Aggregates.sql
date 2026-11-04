-- Aggregates: COUNT, SUM, AVG, MIN, MAX, GROUP BY, HAVING query

SELECT Country, COUNT(*) AS CustomerCount
FROM customers
GROUP BY Country
ORDER BY CustomerCount DESC;

Select OrderID, SUM(LineTotal) As OrderTotal, COUNT(*) As LineCount FROM orderitems
GROUP BY OrderID
ORDER BY OrderTotal DESC;

SELECT Category,
    Round(AVG(UnitPrice), 2) As AvgPrice,
    Sum(Stock)     As TotalStock,
    Min(UnitPrice) As Cheapest,
    MAX(UnitPrice) As Priciest
FROM products
GROUP By Category
HAVING AVG(UnitPrice) > 2000;

SELECT Status, COUNT(*) AS Orders FROM orders GROUP BY Status;

SELECT Count(*)     AS TotalRows,
       Count(Email) AS RowsWithEmail,     -- ignores NULL
       Count(DISTINCT Country) AS DistinctCountries
FROM customers;

-- Units sold per (category, year)
SELECT p.Category,YEAR(o.OrderDate) AS OrderYear,SUM(oi.Quantity) AS Units
FROM orderitems oi
JOIN products p ON p.ProductID = oi.ProductID
JOIN orders   o ON o.OrderID   = oi.OrderID
GROUP BY p.Category, YEAR(o.OrderDate)
ORDER BY p.Category, OrderYear;

-- Categories with at least 3 products AND average price above 2000
SELECT Category,COUNT(*) AS ProductCount,
       ROUND(AVG(UnitPrice),2) AS AvgPrice
FROM products
GROUP BY Category HAVING COUNT(*) >= 3 AND AVG(UnitPrice) > 2000;

SELECT o.CustomerID,
       COUNT(*)AS DeliveredOrders,
       SUM(oi.LineTotal) AS Revenue
FROM orders o
JOIN orderitems oi ON oi.OrderID = o.OrderID
WHERE o.Status = 'Delivered'            -- row-level filter
GROUP BY o.CustomerID
HAVING SUM(oi.LineTotal) > 5000         -- group-level filter
ORDER BY Revenue DESC;

SELECT ROUND(SUM(LineTotal) / COUNT(DISTINCT OrderID), 2) AS AvgOrderValue FROM orderitems;

-- Any customers sharing a last name?
SELECT LastName, COUNT(*) AS Cnt
FROM customers
GROUP BY LastName
HAVING COUNT(*) > 1;

