-- Joins: INNER, LEFT and RIGHT joins, joining three tables

-- INNER: every order with its customer name
SELECT o.OrderID, o.OrderDate, o.Status,CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName
FROM orders o
INNER JOIN customers c ON c.CustomerID = o.CustomerID
ORDER BY o.OrderDate;

-- LEFT JOIN: all customers, including those with no orders
SELECT c.CustomerID, CONCAT(c.FirstName,' ',c.LastName) AS Customer, COUNT(o.OrderID) AS OrderCount
FROM customers c
LEFT JOIN orders o ON o.CustomerID = c.CustomerID
GROUP BY c.CustomerID, Customer
ORDER BY OrderCount DESC;

-- RIGHT JOIN: all orders, including those with no items
SELECT o.OrderID, o.OrderDate, o.Status, COUNT(oi.OrderItemID) AS ItemCount
FROM orders o
RIGHT JOIN orderitems oi ON oi.OrderID = o.OrderID
GROUP BY o.OrderID, o.OrderDate, o.Status
ORDER BY o.OrderDate;

-- Three tables: product-level sales
SELECT p.ProductName,SUM(oi.Quantity) AS UnitsSold, SUM(oi.LineTotal) AS Revenue
FROM orderitems oi
INNER JOIN products p ON p.ProductID = oi.ProductID
INNER JOIN orders o   ON o.OrderID    = oi.OrderID
WHERE o.Status = 'Delivered'
GROUP BY p.ProductID, p.ProductName
ORDER BY Revenue DESC;


-- Four-table join: customer + order + item + product, Delivered revenue per customer × category
SELECT CONCAT(c.FirstName,' ',c.LastName) AS Customer,
    p.Category,
       SUM(oi.LineTotal) AS Revenue
FROM customers c
JOIN orders     o  ON o.CustomerID = c.CustomerID
JOIN orderitems oi ON oi.OrderID   = o.OrderID
JOIN products   p  ON p.ProductID  = oi.ProductID
WHERE o.Status = 'Delivered'
GROUP BY c.CustomerID, Customer, p.Category
ORDER BY Customer, Revenue DESC;

-- Self-join
SELECT a.FirstName AS PersonA,b.FirstName AS PersonB,a.City
FROM customers a
JOIN customers b
  ON a.City = b.City
 AND a.CustomerID < b.CustomerID
ORDER BY a.City, PersonA;

-- UNION vs JOIN (row-stacking, not column-matching)
SELECT 'Customer' AS Source, FirstName AS Name FROM customers WHERE Country = 'India'
UNION
SELECT 'Customer' AS Source, FirstName AS Name FROM customers WHERE Country = 'USA';

-- CROSS JOIN (cartesian) 
Select p.ProductName, t.Label
From products p
CROSS Join (SELECT 'Available' As Label UNION All Select 'Featured') t
WHERE p.Stock > 0
ORDER BY t.Label, p.ProductName
LIMIT 8;