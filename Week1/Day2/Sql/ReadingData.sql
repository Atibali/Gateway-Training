-- Reading data: SELECT, WHERE, ORDER BY, DISTINCT, TOP/LIMIT, LIKE, IN, BETWEEN Query

SELECT CustomerID, FirstName, LastName, City, SignupDate
FROM customers
WHERE Country = 'India'
ORDER BY SignupDate DESC;

SELECT Distinct Country FROM customers ORDER BY Country;

Select ProductName, UnitPrice
From products
ORDER BY UnitPrice DESC
LIMIT 4;

SELECT ProductName, Category, UnitPrice
FROM products
WHERE Category IN ('Accessories', 'Audio')
  AND UnitPrice BETWEEN 1000 AND 5000
ORDER BY UnitPrice;

Select FirstName, LastName
From customers
WHERE LastName Like 'S%'
   OR LastName Like '%ha%';

SELECT ProductName As Product,
       UnitPrice  As Price,
       UnitPrice * 1.18 As PriceWithGST
FROM products
ORDER BY Price DESC;

SELECT
    UPPER(Country) AS CountryCode,
    YEAR(SignupDate) AS SignupYear,
    MONTHNAME(SignupDate) AS SignupMonth
FROM customers
ORDER BY SignupDate;

Select FirstName, City, Country
From customers
Where (City in ('Mumbai', 'Delhi') or Country = 'India')
  AND NOT Country = 'USA';

-- Emails ending in example.com
SELECT FirstName, Email FROM customers WHERE Email LIKE '%@example.com';

-- Last name exactly 4 characters long
SELECT FirstName, LastName FROM customers WHERE LastName LIKE '____';

-- Second letter of first name is 'a'
SELECT FirstName FROM customers WHERE FirstName LIKE '_a%';

-- In With Subquery:
select ProductName, Category, UnitPrice
from products
where ProductID INTERSECT (select DISTINCT ProductID from orderitems)
ORDER BY UnitPrice DESC;

SELECT ProductName, UnitPrice
FROM products
WHERE UnitPrice BETWEEN 500 AND 3000;

SELECT ProductName, Stock FROM products WHERE Stock IS NULL;

-- Every unique (City, Country) pair
SELECT DISTINCT City, Country FROM customers ORDER BY Country, City;

-- How many distinct countries?
SELECT COUNT(DISTINCT Country) AS Countries FROM customers;

SELECT ProductName, UnitPrice
FROM products
ORDER BY UnitPrice DESC
LIMIT 3 OFFSET 3;

SELECT ProductName, Stock
FROM products
ORDER BY Stock DESC, ProductName ASC;

SELECT ProductName,UnitPrice,
    CASE
        WHEN UnitPrice >= 8000 THEN 'Premium'
        WHEN UnitPrice >= 2000 THEN 'Mid'
        ELSE 'Budget'
    END AS PriceTier
FROM products
ORDER BY UnitPrice DESC;

Select CustomerID,
       FirstName,
       COALESCE(Email, 'no-email@unknown') As ContactEmail
From customers
Order By CustomerID;