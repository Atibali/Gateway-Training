-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 04, 2026 at 08:13 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sqlpractice`
--

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `CustomerID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `Country` varchar(50) DEFAULT 'India',
  `SignupDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`CustomerID`, `FirstName`, `LastName`, `Email`, `City`, `Country`, `SignupDate`) VALUES
(1, 'Aarav', 'Sharma', 'aarav.sharma@example.com', 'Mumbai', 'India', '2025-11-12'),
(2, 'Priya', 'Patel', 'priya.patel@example.com', 'Ahmedabad', 'India', '2025-12-03'),
(3, 'John', 'Smith', 'john.smith@example.com', 'New York', 'USA', '2026-01-15'),
(4, 'Emily', 'Johnson', 'emily.j@example.com', 'London', 'UK', '2026-02-20'),
(5, 'Rohan', 'Verma', 'rohan.verma@example.com', 'Delhi', 'India', '2026-03-08'),
(6, 'Sara', 'Khan', 'sara.khan@example.com', 'Mumbai', 'India', '2026-04-22'),
(7, 'Michael', 'Brown', 'michael.b@example.com', 'Chicago', 'USA', '2026-05-30'),
(8, 'Ananya', 'Iyer', 'ananya.iyer@example.com', 'Bangalore', 'India', '2026-07-14');

-- --------------------------------------------------------

--
-- Table structure for table `orderitems`
--

CREATE TABLE `orderitems` (
  `OrderItemID` int(11) NOT NULL,
  `OrderID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL CHECK (`Quantity` > 0),
  `LineTotal` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `orderitems`
--

INSERT INTO `orderitems` (`OrderItemID`, `OrderID`, `ProductID`, `Quantity`, `LineTotal`) VALUES
(901, 5001, 201, 2, '1598.00'),
(902, 5001, 202, 3, '897.00'),
(903, 5002, 203, 1, '2499.00'),
(904, 5003, 205, 1, '15999.00'),
(905, 5003, 206, 2, '2598.00'),
(906, 5004, 204, 1, '4599.00'),
(907, 5004, 201, 1, '799.00'),
(908, 5005, 208, 2, '11998.00'),
(909, 5005, 207, 1, '1899.00'),
(910, 5006, 209, 1, '8499.00'),
(911, 5007, 203, 1, '2499.00'),
(912, 5007, 202, 4, '1196.00'),
(913, 5008, 206, 1, '1299.00'),
(914, 5009, 205, 1, '15999.00'),
(915, 5009, 209, 1, '8499.00'),
(916, 5009, 207, 2, '3798.00'),
(917, 5010, 208, 1, '5999.00'),
(918, 5011, 201, 1, '799.00'),
(919, 5012, 204, 1, '4599.00'),
(920, 5012, 202, 2, '598.00');

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `OrderID` int(11) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `OrderDate` date NOT NULL,
  `Status` varchar(20) DEFAULT 'Pending'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`OrderID`, `CustomerID`, `OrderDate`, `Status`) VALUES
(5001, 1, '2026-01-05', 'Delivered'),
(5002, 1, '2026-02-10', 'Delivered'),
(5003, 2, '2026-02-15', 'Delivered'),
(5004, 3, '2026-03-01', 'Shipped'),
(5005, 4, '2026-03-20', 'Delivered'),
(5006, 3, '2026-04-05', 'Cancelled'),
(5007, 5, '2026-04-18', 'Delivered'),
(5008, 6, '2026-05-02', 'Pending'),
(5009, 5, '2026-05-25', 'Delivered'),
(5010, 7, '2026-06-10', 'Shipped'),
(5011, 1, '2026-07-01', 'Pending'),
(5012, 4, '2026-08-15', 'Delivered');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ProductID` int(11) NOT NULL,
  `ProductName` varchar(100) NOT NULL,
  `Category` varchar(50) DEFAULT NULL,
  `UnitPrice` decimal(10,2) DEFAULT NULL CHECK (`UnitPrice` >= 0),
  `Stock` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ProductID`, `ProductName`, `Category`, `UnitPrice`, `Stock`) VALUES
(201, 'Wireless Mouse', 'Accessories', '799.00', 50),
(202, 'USB-C Cable', 'Accessories', '299.00', 200),
(203, 'Bluetooth Headphones', 'Audio', '2499.00', 35),
(204, 'Mechanical Keyboard', 'Accessories', '4599.00', 20),
(205, '27-inch Monitor', 'Displays', '15999.00', 15),
(206, 'Laptop Stand', 'Accessories', '1299.00', 60),
(207, 'Webcam HD', 'Accessories', '1899.00', 40),
(208, 'Noise Cancelling Earbuds', 'Audio', '5999.00', 25),
(209, 'Portable SSD 1TB', 'Storage', '8499.00', 30),
(210, 'Desk Lamp', 'Accessories', '899.00', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`CustomerID`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indexes for table `orderitems`
--
ALTER TABLE `orderitems`
  ADD PRIMARY KEY (`OrderItemID`),
  ADD KEY `OrderID` (`OrderID`),
  ADD KEY `ProductID` (`ProductID`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`OrderID`),
  ADD KEY `CustomerID` (`CustomerID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `orderitems`
--
ALTER TABLE `orderitems`
  ADD CONSTRAINT `orderitems_ibfk_1` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`OrderID`),
  ADD CONSTRAINT `orderitems_ibfk_2` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`);

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`CustomerID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
