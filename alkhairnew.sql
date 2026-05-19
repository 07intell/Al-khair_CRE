-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 19, 2026 at 04:19 AM
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
-- Database: `alkhairnew`
--

-- --------------------------------------------------------

--
-- Table structure for table `accountashead`
--

CREATE TABLE `accountashead` (
  `id` bigint(15) NOT NULL,
  `head_name` varchar(50) DEFAULT NULL,
  `opdre_status` int(1) DEFAULT 0,
  `opcre_status` int(1) DEFAULT 0,
  `libility_status` int(1) DEFAULT 0,
  `assests_status` int(1) DEFAULT 0,
  `ge_status` int(1) DEFAULT 0,
  `head_status` int(1) DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `balance_sheet_entry`
--

CREATE TABLE `balance_sheet_entry` (
  `id` bigint(15) NOT NULL,
  `field_name` varchar(30) NOT NULL DEFAULT '',
  `field_value` decimal(10,2) NOT NULL DEFAULT 0.00,
  `status` varchar(10) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `bank`
--

CREATE TABLE `bank` (
  `id` bigint(15) NOT NULL,
  `bank` varchar(50) NOT NULL DEFAULT '',
  `incStatus` int(11) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `calector`
--

CREATE TABLE `calector` (
  `id` bigint(15) NOT NULL,
  `emp_id` bigint(15) DEFAULT NULL,
  `ename` varchar(100) DEFAULT NULL,
  `sex` int(1) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `designation` bigint(15) DEFAULT NULL,
  `domicile` bigint(15) DEFAULT NULL,
  `fname` varchar(100) DEFAULT NULL,
  `falive` int(1) DEFAULT NULL,
  `mname` varchar(100) DEFAULT NULL,
  `malive` int(1) DEFAULT NULL,
  `sname` varchar(100) DEFAULT NULL,
  `salive` int(1) DEFAULT NULL,
  `pspouse` varchar(100) DEFAULT NULL,
  `nochild` int(2) DEFAULT NULL,
  `child_desc` text DEFAULT NULL,
  `cphone` varchar(50) DEFAULT NULL,
  `cmobile` varchar(50) DEFAULT NULL,
  `cfaxno` varchar(100) DEFAULT NULL,
  `cemail` varchar(50) DEFAULT NULL,
  `postal_add` text DEFAULT NULL,
  `per_add` text DEFAULT NULL,
  `asondate` date DEFAULT NULL,
  `palive` varchar(20) DEFAULT NULL,
  `staff_type` int(2) DEFAULT NULL,
  `branch_code` int(2) DEFAULT NULL,
  `pay_scale` decimal(10,2) DEFAULT NULL,
  `salary_due` decimal(10,2) DEFAULT NULL,
  `date_of_joing` date DEFAULT NULL,
  `contri_welfer` varchar(20) DEFAULT '0',
  `incr_date` date NOT NULL DEFAULT '0000-00-00',
  `incr_amount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `incr_state` int(2) NOT NULL DEFAULT 0,
  `accountno` varchar(30) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `daybook`
--

CREATE TABLE `daybook` (
  `id` bigint(15) NOT NULL,
  `vou_id` bigint(15) DEFAULT NULL,
  `drparticular` bigint(15) NOT NULL DEFAULT 0,
  `crparticular` bigint(15) NOT NULL DEFAULT 0,
  `drcramount` decimal(10,2) DEFAULT NULL,
  `cramount` decimal(10,2) DEFAULT 0.00,
  `date_id` bigint(15) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `day_clese`
--

CREATE TABLE `day_clese` (
  `id` bigint(15) NOT NULL,
  `cur_date` date NOT NULL DEFAULT '0000-00-00',
  `status` int(1) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `designation`
--

CREATE TABLE `designation` (
  `id` bigint(15) NOT NULL,
  `designation` varchar(50) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `general_voucher`
--

CREATE TABLE `general_voucher` (
  `id` bigint(15) NOT NULL,
  `vou_id` bigint(15) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `address` text DEFAULT NULL,
  `asondate` date DEFAULT NULL,
  `exp_subhead` bigint(15) DEFAULT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `empid` int(10) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `genrate_total_id`
--

CREATE TABLE `genrate_total_id` (
  `id` bigint(15) NOT NULL,
  `genrated_id` bigint(15) DEFAULT NULL,
  `id_by_name` varchar(200) DEFAULT NULL,
  `type_of_user` varchar(10) DEFAULT NULL,
  `fix_status` int(1) DEFAULT 0,
  `pl_Bal_status` varchar(10) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `loan_details`
--

CREATE TABLE `loan_details` (
  `id` bigint(15) NOT NULL,
  `vou_id` bigint(15) NOT NULL DEFAULT 0,
  `growth_id` bigint(15) NOT NULL DEFAULT 0,
  `loan_type` int(1) NOT NULL DEFAULT 0,
  `loan_amt` decimal(10,2) NOT NULL DEFAULT 0.00,
  `s_charge` decimal(10,2) NOT NULL DEFAULT 0.00,
  `mar_monery` decimal(10,2) NOT NULL DEFAULT 0.00,
  `mar_monery_per` int(2) NOT NULL DEFAULT 0,
  `total_loan_amt` decimal(10,2) NOT NULL DEFAULT 0.00,
  `inst_amt` decimal(10,2) NOT NULL DEFAULT 0.00,
  `noof_inst_tot` bigint(15) NOT NULL DEFAULT 0,
  `ret_inst` bigint(15) NOT NULL DEFAULT 0,
  `type_colle` int(1) NOT NULL DEFAULT 0,
  `loan_adv_id` bigint(15) NOT NULL DEFAULT 0,
  `loan_dateid` bigint(15) DEFAULT NULL,
  `loan_confirm_status` int(1) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id` bigint(15) NOT NULL,
  `user_type` int(1) NOT NULL DEFAULT 0,
  `user_name` varchar(20) NOT NULL DEFAULT '',
  `password` varchar(20) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id`, `user_type`, `user_name`, `password`) VALUES
(13, 9, 'sanjay', 'billorani'),
(14, 1, 'mdr', '123456'),
(15, 0, 'user', '123456'),
(16, 7, 'user1', '123456'),
(17, 9, 'Aman', 'master1$*'),
(18, 7, 'Afaque', '123456');

-- --------------------------------------------------------

--
-- Table structure for table `membership`
--

CREATE TABLE `membership` (
  `applicant_name` varchar(50) NOT NULL DEFAULT '',
  `f_name` varchar(50) NOT NULL DEFAULT '',
  `age` varchar(50) NOT NULL DEFAULT '0',
  `sex` char(2) NOT NULL DEFAULT '',
  `caste` char(2) NOT NULL DEFAULT '',
  `permanent_add` varchar(200) NOT NULL DEFAULT '',
  `pin_code` varchar(50) NOT NULL DEFAULT '',
  `state` varchar(50) NOT NULL DEFAULT '',
  `nationality` varchar(50) NOT NULL DEFAULT '',
  `postal_address` varchar(200) NOT NULL DEFAULT '',
  `pin_code_postal` varchar(200) NOT NULL DEFAULT '',
  `state_present_address` varchar(50) NOT NULL DEFAULT '',
  `profession` varchar(50) NOT NULL DEFAULT '',
  `phone_no` varchar(50) NOT NULL DEFAULT '',
  `n_nominee` varchar(50) NOT NULL DEFAULT '',
  `relationship` varchar(10) NOT NULL DEFAULT '',
  `age_n` varchar(10) NOT NULL DEFAULT '',
  `Add_n` varchar(200) NOT NULL DEFAULT '',
  `mr_no` varchar(100) NOT NULL DEFAULT '',
  `membership_no` bigint(15) NOT NULL DEFAULT 0,
  `first_share` varchar(10) NOT NULL DEFAULT '',
  `additional_shares` varchar(10) NOT NULL DEFAULT '',
  `date_additional_shares` varchar(10) NOT NULL DEFAULT '',
  `total_share_amount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `admission_fee` decimal(10,2) NOT NULL DEFAULT 0.00,
  `donation` decimal(10,2) NOT NULL DEFAULT 0.00,
  `additional_donation` varchar(50) NOT NULL DEFAULT '',
  `date_additional_donations` varchar(50) NOT NULL DEFAULT '',
  `total` decimal(10,2) NOT NULL DEFAULT 0.00,
  `defaulter` varchar(50) NOT NULL DEFAULT '',
  `id` bigint(15) NOT NULL,
  `growth_id` bigint(15) DEFAULT NULL,
  `branch_code` varchar(5) DEFAULT 'BR04',
  `mobileno` varchar(10) DEFAULT NULL,
  `panno` varchar(10) DEFAULT NULL,
  `images` varchar(100) DEFAULT NULL,
  `gen_mem_id` bigint(15) DEFAULT NULL,
  `gen_gf_id` bigint(15) NOT NULL DEFAULT 0,
  `signature` varchar(200) DEFAULT NULL,
  `gfcoll_status` int(1) DEFAULT 0,
  `gfcoll_id` varchar(10) NOT NULL DEFAULT '',
  `cudate` date DEFAULT NULL,
  `albank_membership_table_id` bigint(20) NOT NULL DEFAULT 0,
  `old_membership` int(4) NOT NULL DEFAULT 0,
  `fullmemshipid` varchar(20) NOT NULL DEFAULT '',
  `branch_codeid` int(10) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `relationship`
--

CREATE TABLE `relationship` (
  `id` bigint(15) NOT NULL,
  `relation_name` varchar(30) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `return_laon_adv`
--

CREATE TABLE `return_laon_adv` (
  `id` bigint(15) NOT NULL,
  `vou_id` bigint(15) NOT NULL DEFAULT 0,
  `loan_id` bigint(15) NOT NULL DEFAULT 0,
  `ret_inst` bigint(15) DEFAULT NULL,
  `ret_amt` decimal(10,2) NOT NULL DEFAULT 0.00,
  `retloan_dateid` bigint(15) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `state`
--

CREATE TABLE `state` (
  `id` bigint(15) NOT NULL DEFAULT 0,
  `state` varchar(100) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `voucher_entry`
--

CREATE TABLE `voucher_entry` (
  `id` bigint(15) NOT NULL,
  `branch_code` bigint(15) NOT NULL DEFAULT 0,
  `vou_type` int(1) NOT NULL DEFAULT 0,
  `vou_sub_type` int(1) NOT NULL DEFAULT 0,
  `vou_no` int(20) NOT NULL DEFAULT 0,
  `vou_year` int(4) NOT NULL DEFAULT 0,
  `vou_dateid` bigint(15) NOT NULL DEFAULT 0,
  `verify_status` int(1) NOT NULL DEFAULT 0,
  `decription` text DEFAULT NULL,
  `cash_status` int(1) DEFAULT 1,
  `cheque_no` varchar(25) DEFAULT NULL,
  `cheque_date` date DEFAULT NULL,
  `bank_name` bigint(15) DEFAULT NULL,
  `fund_id` bigint(15) NOT NULL DEFAULT 0,
  `submit_userid` bigint(15) DEFAULT NULL,
  `confirm_userid` bigint(15) DEFAULT NULL,
  `cheque_confirm_status` bigint(15) NOT NULL DEFAULT 0,
  `che_clea_status` int(1) DEFAULT 0,
  `conf_dateid` bigint(15) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accountashead`
--
ALTER TABLE `accountashead`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `balance_sheet_entry`
--
ALTER TABLE `balance_sheet_entry`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `bank`
--
ALTER TABLE `bank`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `calector`
--
ALTER TABLE `calector`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `daybook`
--
ALTER TABLE `daybook`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `day_clese`
--
ALTER TABLE `day_clese`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `designation`
--
ALTER TABLE `designation`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `general_voucher`
--
ALTER TABLE `general_voucher`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `genrate_total_id`
--
ALTER TABLE `genrate_total_id`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `loan_details`
--
ALTER TABLE `loan_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `membership`
--
ALTER TABLE `membership`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `relationship`
--
ALTER TABLE `relationship`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `return_laon_adv`
--
ALTER TABLE `return_laon_adv`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `voucher_entry`
--
ALTER TABLE `voucher_entry`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accountashead`
--
ALTER TABLE `accountashead`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `balance_sheet_entry`
--
ALTER TABLE `balance_sheet_entry`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `bank`
--
ALTER TABLE `bank`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `calector`
--
ALTER TABLE `calector`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `daybook`
--
ALTER TABLE `daybook`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `day_clese`
--
ALTER TABLE `day_clese`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `designation`
--
ALTER TABLE `designation`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `general_voucher`
--
ALTER TABLE `general_voucher`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `genrate_total_id`
--
ALTER TABLE `genrate_total_id`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `loan_details`
--
ALTER TABLE `loan_details`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `membership`
--
ALTER TABLE `membership`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `relationship`
--
ALTER TABLE `relationship`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `return_laon_adv`
--
ALTER TABLE `return_laon_adv`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `voucher_entry`
--
ALTER TABLE `voucher_entry`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
