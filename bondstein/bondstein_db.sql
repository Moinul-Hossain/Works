-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 11, 2021 at 08:59 AM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.0.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bondstein_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `people`
--

CREATE TABLE `people` (
  `id` int(11) NOT NULL,
  `name` varchar(80) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `city` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `people`
--

INSERT INTO `people` (`id`, `name`, `dob`, `city`) VALUES
(1, 'Scott Parel', '1986-05-23', 'New York'),
(2, 'Brett Quigley', '1978-10-02', 'Chicago'),
(3, 'Bernhard Langer', '1978-10-02', 'San Antonio'),
(4, 'Brett Quigley', '1967-08-19', 'Dallas'),
(5, 'Ernie Els', '1991-03-08', 'Austin'),
(6, 'Jim Furyk', '1985-11-22', 'San Diego'),
(7, 'Jerry Kelly', '1991-03-12', 'Denver'),
(8, 'Shane Bertsch', '1967-08-19', 'Washington'),
(9, 'Ernie Els', '1991-03-08', 'Oklahoma City'),
(10, 'Phil Mickelson', '1987-10-22', 'New York'),
(11, 'Jerry Kelly', '1993-06-19', 'San Antonio'),
(12, 'Shane Bertsch', '1974-08-19', 'Dallas'),
(13, 'Ernie Els', '1990-05-18', 'San Diego');

-- --------------------------------------------------------

--
-- Table structure for table `person`
--

CREATE TABLE `person` (
  `person_id` int(11) NOT NULL,
  `person_name` varchar(80) DEFAULT NULL,
  `person_dob` date DEFAULT NULL,
  `salary_per_annum` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `person`
--

INSERT INTO `person` (`person_id`, `person_name`, `person_dob`, `salary_per_annum`) VALUES
(1, 'Scott Parel', '1986-05-23', 20000),
(2, 'Brett Quigley', '1978-10-02', 65000),
(3, 'Bernhard Langer', '1978-10-02', 20000),
(4, 'Brett Quigley', '1967-08-19', 25000),
(5, 'Ernie Els', '1991-03-08', 20000),
(6, 'Jim Furyk', '1985-11-22', 25000),
(7, 'Jerry Kelly', '1991-03-12', 60000),
(8, 'Shane Bertsch', '1967-08-19', 50000),
(9, 'Ernie Els', '1991-03-08', 10000),
(10, 'Phil Mickelson', '1987-10-22', 50000),
(11, 'Jerry Kelly', '1993-06-19', 10000),
(12, 'Shane Bertsch', '1974-08-19', 50000),
(13, 'Ernie Els', '1990-05-18', 10000);

-- --------------------------------------------------------

--
-- Table structure for table `person_address`
--

CREATE TABLE `person_address` (
  `address_id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `address_line` varchar(255) NOT NULL,
  `city` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `person_address`
--

INSERT INTO `person_address` (`address_id`, `person_id`, `address_line`, `city`) VALUES
(1, 1, '', 'New York'),
(2, 2, '', 'Manhattan'),
(3, 3, '', 'San Antonio'),
(4, 4, '', 'Dallas'),
(5, 5, '', 'Manhattan'),
(6, 6, '', 'San Diego'),
(7, 7, '', 'Denver'),
(8, 8, '', 'Manhattan'),
(9, 9, '', 'Oklahoma City'),
(10, 10, '', 'New York'),
(11, 11, '', 'Manhattan'),
(12, 12, '', 'Dallas'),
(13, 13, '', 'San Diego');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `login_id` varchar(10) NOT NULL,
  `password` varchar(80) NOT NULL DEFAULT '',
  `user_category` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `login_id`, `password`, `user_category`) VALUES
(1, 'customer', 'd41d8cd98f00b204e9800998ecf8427e', 'Customer'),
(2, 'admin', 'e10adc3949ba59abbe56e057f20f883e', 'Admin'),
(3, 'Bondstein', 'e10adc3949ba59abbe56e057f20f883e', 'Admin'),
(4, 'Moinul', 'e10adc3949ba59abbe56e057f20f883e', 'Customer'),
(5, 'dba', 'e10adc3949ba59abbe56e057f20f883e', 'Admin');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `people`
--
ALTER TABLE `people`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`person_id`);

--
-- Indexes for table `person_address`
--
ALTER TABLE `person_address`
  ADD PRIMARY KEY (`address_id`),
  ADD KEY `person_id` (`person_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `people`
--
ALTER TABLE `people`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `person`
--
ALTER TABLE `person`
  MODIFY `person_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `person_address`
--
ALTER TABLE `person_address`
  MODIFY `address_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `person_address`
--
ALTER TABLE `person_address`
  ADD CONSTRAINT `fk_person_address` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  ADD CONSTRAINT `person_address_ibfk_1` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
