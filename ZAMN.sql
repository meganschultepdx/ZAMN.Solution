-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 23, 2019 at 03:23 PM
-- Server version: 5.7.25
-- PHP Version: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

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
  `time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `capekiwanda`
--

INSERT INTO `capekiwanda` (`id`, `userName`, `comment`, `time`) VALUES
(1, 'Kurt', 'Did anyone find a blue 5\' X 3/16 leash laying around. Thanks!', '0001-01-01 00:00:00');

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
  `time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `indianbeach`
--

INSERT INTO `indianbeach` (`id`, `userName`, `comment`, `time`) VALUES
(1, 'Cory', 'Test test test ', '0001-01-01 00:00:00');

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
  `time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shortsands`
--

INSERT INTO `shortsands` (`id`, `userName`, `comment`, `time`) VALUES
(106, 'Sam', 'A group of us are meeting at Pioneer Square at 3:30 AM to caravan for dawn patrol tomorrow! ', '2019-05-22 23:29:35'),
(107, 'Baldwin', '6-10 ft at shorties right now, charging!!', '2019-05-22 23:33:13');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `hikes`
--
ALTER TABLE `hikes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `indianbeach`
--
ALTER TABLE `indianbeach`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `restaurants`
--
ALTER TABLE `restaurants`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `shortsands`
--
ALTER TABLE `shortsands`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=109;
