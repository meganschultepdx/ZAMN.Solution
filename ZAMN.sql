-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 23, 2019 at 07:02 AM
-- Server version: 5.7.25
-- PHP Version: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `ZAMN`
--

-- --------------------------------------------------------

--
-- Table structure for table `capekiwanda`
--

DROP TABLE IF EXISTS `capekiwanda`;
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

--
-- Indexes for dumped tables
--

--
-- Indexes for table `capekiwanda`
--
ALTER TABLE `capekiwanda`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `capekiwanda`
--
ALTER TABLE `capekiwanda`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
