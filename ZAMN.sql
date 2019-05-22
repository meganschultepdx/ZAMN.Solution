-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 22, 2019 at 11:00 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ZAMN`
--
CREATE DATABASE IF NOT EXISTS `ZAMN` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ZAMN`;

-- --------------------------------------------------------

--
-- Table structure for table `capekiwanda`
--

CREATE TABLE `capekiwanda` (
  `id` int(11) NOT NULL,
  `userName` varchar(255) NOT NULL,
  `comment` text NOT NULL,
  `time` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `hikes`
--

CREATE TABLE `hikes` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `indianbeach`
--

CREATE TABLE `indianbeach` (
  `id` int(11) NOT NULL,
  `userName` varchar(255) NOT NULL,
  `comment` text NOT NULL,
  `time` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `restaurants`
--

CREATE TABLE `restaurants` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `restaurants`
--

INSERT INTO `restaurants` (`id`, `name`, `address`, `type`, `description`) VALUES
(1, 'food place', 'indian beach', 'food food', 'i ate food');

-- --------------------------------------------------------

--
-- Table structure for table `shortsands`
--

CREATE TABLE `shortsands` (
  `id` int(11) NOT NULL,
  `userName` varchar(255) NOT NULL,
  `comment` text NOT NULL,
  `time` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shortsands`
--

INSERT INTO `shortsands` (`id`, `userName`, `comment`, `time`) VALUES
(1, 'megan', 'i\'m hear and the waves are badass!', '0000-00-00'),
(2, 'megan', 'i\'m hear and the waves are badass!', '0000-00-00'),
(3, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(42, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(43, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(44, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(45, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(46, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(47, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(48, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(49, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(50, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(51, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(52, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(53, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(54, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(55, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(56, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(57, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(58, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(59, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(60, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(61, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(62, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(63, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(64, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(65, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(66, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(67, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(68, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(69, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(70, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(71, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(72, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(73, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(74, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(75, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(76, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(77, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(78, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(79, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(80, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(81, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(82, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(83, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(84, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(85, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(86, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(87, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(88, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(89, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(90, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(91, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(92, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(93, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(94, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(95, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(96, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(97, 'megan', 'it raining i go eet\r\n', '0000-00-00'),
(98, 'megan', 'The passage experienced a surge in popularity during the 1960s when Letraset used it on their dry-transfer sheets, and again during the 90s as desktop publishers bundled the text with their software. Today it\'s seen all around the web; on templates, websites, and stock designs. Use our generator to get your own, or read on for the authoritative history of lorem ipsum.', '0000-00-00'),
(99, 'megan', 'The passage experienced a surge in popularity during the 1960s when Letraset used it on their dry-transfer sheets, and again during the 90s as desktop publishers bundled the text with their software. Today it\'s seen all around the web; on templates, websites, and stock designs. Use our generator to get your own, or read on for the authoritative history of lorem ipsum.', '0000-00-00'),
(100, 'megan', 'hey', '0001-01-01');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `capekiwanda`
--
ALTER TABLE `capekiwanda`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `hikes`
--
ALTER TABLE `hikes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `indianbeach`
--
ALTER TABLE `indianbeach`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `restaurants`
--
ALTER TABLE `restaurants`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `shortsands`
--
ALTER TABLE `shortsands`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `capekiwanda`
--
ALTER TABLE `capekiwanda`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `hikes`
--
ALTER TABLE `hikes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `indianbeach`
--
ALTER TABLE `indianbeach`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurants`
--
ALTER TABLE `restaurants`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `shortsands`
--
ALTER TABLE `shortsands`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
