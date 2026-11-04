-- Changing data: INSERT, UPDATE, DELETE

INSERT INTO customers (CustomerID, FirstName, LastName, Email, City, Country, SignupDate)
VALUES (9, 'Vikram', 'Rao', 'vikram.rao@example.com', 'Hyderabad', 'India', '2026-11-01');

INSERT INTO orders (OrderID, CustomerID, OrderDate, Status)
VALUES (5013, 9, '2026-11-02', 'Pending');

UPDATE products
SET Stock = Stock - 2
WHERE ProductID = 201 AND Stock >= 2;

DELETE FROM orderitems
WHERE OrderItemID = 920;

Delete From products Where ProductID = 201;  -- fails: FK restriction