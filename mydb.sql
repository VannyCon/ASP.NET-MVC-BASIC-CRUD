-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 27, 2024 at 07:33 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mydb`
--

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

CREATE TABLE `departments` (
  `Department_Id` int(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Manager` varchar(255) NOT NULL,
  `Location` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `departments`
--

INSERT INTO `departments` (`Department_Id`, `Name`, `Manager`, `Location`) VALUES
(1, 'Finance', 'John Doe', 'New York'),
(2, 'Marketing', 'Jane Smith', 'Los Angeles'),
(3, 'Human Resources', 'Mike Johnson', 'Chicago');

-- --------------------------------------------------------

--
-- Table structure for table `designation`
--

CREATE TABLE `designation` (
  `Designation_Id` int(255) NOT NULL,
  `Designated` varchar(255) NOT NULL,
  `First` varchar(255) NOT NULL,
  `Last` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `designation`
--

INSERT INTO `designation` (`Designation_Id`, `Designated`, `First`, `Last`) VALUES
(1, 'Manager', 'John', 'Doep'),
(2, 'Supervisor', 'Jane', 'Smith'),
(3, 'Team Lea', 'Mike', 'Johnson'),
(4, 'UI/UX Designer', 'Sarah', 'Williams');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `Employee_Id` int(255) NOT NULL,
  `First` varchar(255) NOT NULL,
  `Last` varchar(255) NOT NULL,
  `Birthday` varchar(255) NOT NULL,
  `Gender` varchar(255) NOT NULL,
  `Position` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`Employee_Id`, `First`, `Last`, `Birthday`, `Gender`, `Position`) VALUES
(1, 'John Dope', 'Doe', '1985-05-15', 'Male', 'Manager'),
(2, 'Jane', 'Smith', '1988-10-22', 'Female', 'Supervisor');

-- --------------------------------------------------------

--
-- Table structure for table `useraccount`
--

CREATE TABLE `useraccount` (
  `UserAccount_Id` int(255) NOT NULL,
  `First_Name` varchar(255) NOT NULL,
  `Last_Name` varchar(255) NOT NULL,
  `Mobile` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Email_Account` varchar(255) NOT NULL,
  `Account` varchar(255) NOT NULL,
  `Gender` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `useraccount`
--

INSERT INTO `useraccount` (`UserAccount_Id`, `First_Name`, `Last_Name`, `Mobile`, `Password`, `Email_Account`, `Account`, `Gender`) VALUES
(1, 'John', 'Doe', '1234567890', '123', 'john.doe@example.com', 'john_doe', 'Male'),
(2, 'Jane', 'Smith', '2147483647', '123', 'jane.smith@example.com', 'jane_smith', 'Female'),
(3, 'Mike', 'Johnson', '2147483647', '123', 'mike.johnson@example.com', 'mike_johnson', 'Male'),
(4, 'Suwri', 'Williams', '2147483647', '123', 'sarah.williams@example.com', 'sarah_williams', 'Female');

-- --------------------------------------------------------

--
-- Table structure for table `userinfo`
--

CREATE TABLE `userinfo` (
  `Id` int(100) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Mobile` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `userinfo`
--

INSERT INTO `userinfo` (`Id`, `Name`, `Email`, `Password`, `Mobile`) VALUES
(1, 'Ivan', 'ivan.contrevida4@gmail.com', 'asdsadas', '912321321321'),
(2, 'Vanny', 'sadfasdfasd@sda.con', 'sadsadsa', '091234'),
(3, 'Vanny', 'van@y.com', 'van', '09053805560'),
(4, 'test', 'test@gmail.com', 'test', '090233805560'),
(5, 'Cindy Quinlat', 'Cindyquinlat@yahoo.com', 'ivanrc123', '09506351266'),
(6, 'CashCon', 'Cashy@yahoo.com', 'cash', '0912373123'),
(7, 'micheal', 'micheal@yahoo.com', 'micheal', '019239217328738273213'),
(8, 'ervin', 'ervin@gmail.com', 'test', '0912302312'),
(9, 'Justin Smith', 'justin_smith@yahoo.com', 'test', '09506351266'),
(10, 'Test', 'tessdasdt@gmail.com', 'testserer', '90233805560');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`Department_Id`);

--
-- Indexes for table `designation`
--
ALTER TABLE `designation`
  ADD PRIMARY KEY (`Designation_Id`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`Employee_Id`);

--
-- Indexes for table `useraccount`
--
ALTER TABLE `useraccount`
  ADD PRIMARY KEY (`UserAccount_Id`);

--
-- Indexes for table `userinfo`
--
ALTER TABLE `userinfo`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `departments`
--
ALTER TABLE `departments`
  MODIFY `Department_Id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `designation`
--
ALTER TABLE `designation`
  MODIFY `Designation_Id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `Employee_Id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `useraccount`
--
ALTER TABLE `useraccount`
  MODIFY `UserAccount_Id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `userinfo`
--
ALTER TABLE `userinfo`
  MODIFY `Id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
