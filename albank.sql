-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 19, 2026 at 04:18 AM
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
-- Database: `albank`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounthead`
--

CREATE TABLE `accounthead` (
  `id` int(11) NOT NULL,
  `suspen_acc_type` int(4) NOT NULL DEFAULT 0,
  `account_head` varchar(50) NOT NULL DEFAULT '',
  `amount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `status` int(1) NOT NULL DEFAULT 0
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
-- Table structure for table `branch_detils`
--

CREATE TABLE `branch_detils` (
  `id` int(11) NOT NULL,
  `branch_name` varchar(50) NOT NULL DEFAULT '',
  `branch_code` varchar(50) NOT NULL DEFAULT '',
  `user_name` varchar(30) NOT NULL DEFAULT '',
  `password` varchar(30) NOT NULL DEFAULT '',
  `status` int(1) NOT NULL DEFAULT 0,
  `stateCode` char(2) NOT NULL DEFAULT '',
  `branch_code1` char(2) NOT NULL DEFAULT '',
  `branch_code_id` int(11) NOT NULL,
  `full_user_name` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `branch_heading`
--

CREATE TABLE `branch_heading` (
  `id` int(11) NOT NULL,
  `society_name` varchar(300) NOT NULL,
  `branch_name` varchar(300) DEFAULT NULL,
  `branch_code_id` int(2) NOT NULL,
  `op_bal_loss` decimal(10,2) DEFAULT NULL,
  `op_bal_profit` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `branch_user`
--

CREATE TABLE `branch_user` (
  `id` int(11) NOT NULL,
  `branch_name` varchar(50) DEFAULT NULL,
  `user_name` varchar(50) DEFAULT NULL,
  `pass` varchar(50) DEFAULT NULL,
  `user_type` int(1) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `collection_file`
--

CREATE TABLE `collection_file` (
  `id` int(11) NOT NULL,
  `file_name` varchar(200) DEFAULT NULL,
  `file_status` int(2) DEFAULT 0,
  `cur_date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `coll_depo_amount`
--

CREATE TABLE `coll_depo_amount` (
  `id` int(11) NOT NULL,
  `branch_code` int(10) DEFAULT NULL,
  `colle_id` int(10) DEFAULT NULL,
  `depo_date` int(11) NOT NULL DEFAULT 0,
  `accountid` varchar(10) DEFAULT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `voucher_no` int(10) DEFAULT NULL,
  `receiptno` varchar(5) DEFAULT NULL,
  `collectionTYpe` int(1) NOT NULL DEFAULT 0,
  `chequeno` varchar(10) NOT NULL DEFAULT '0',
  `chequedate` date NOT NULL DEFAULT '0000-00-00',
  `bankname` int(10) NOT NULL DEFAULT 0,
  `narration` text NOT NULL,
  `returnType` int(11) NOT NULL DEFAULT 0,
  `confstatus` int(11) NOT NULL DEFAULT 0,
  `rectDateid` int(11) NOT NULL DEFAULT 0,
  `sms_mobile_no` varchar(15) NOT NULL,
  `send_msg_details` varchar(200) NOT NULL,
  `user_login_id` int(10) NOT NULL,
  `user_login_date_time` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `coll_voucher_entry`
--

CREATE TABLE `coll_voucher_entry` (
  `id` int(11) NOT NULL,
  `collid` int(10) DEFAULT NULL,
  `collection_type` int(2) DEFAULT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `voucherid` int(10) DEFAULT NULL,
  `branch_code` int(5) DEFAULT NULL,
  `verify_status` int(1) NOT NULL DEFAULT 0,
  `acstatus` int(1) NOT NULL DEFAULT 0,
  `narration` text DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `daily_collection`
--

CREATE TABLE `daily_collection` (
  `id` bigint(20) NOT NULL,
  `branchid` int(10) NOT NULL,
  `collector_id` int(10) NOT NULL,
  `localid` int(10) NOT NULL,
  `ac_type` int(10) NOT NULL,
  `ac_no` int(10) NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  `file_name` varchar(300) NOT NULL,
  `imp_status` int(2) NOT NULL DEFAULT 0,
  `cur_date` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `daybook`
--

CREATE TABLE `daybook` (
  `id` bigint(15) NOT NULL,
  `vou_id` bigint(15) DEFAULT NULL,
  `drparticular` bigint(15) NOT NULL DEFAULT 0,
  `crparticular` bigint(15) NOT NULL DEFAULT 0,
  `drcramount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `cramount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `date_id` bigint(15) DEFAULT NULL,
  `branch_code` int(10) DEFAULT NULL,
  `narration` text DEFAULT NULL,
  `groups` varchar(20) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `demand_loan`
--

CREATE TABLE `demand_loan` (
  `loan_app_id` int(11) NOT NULL,
  `branch_code` int(10) DEFAULT NULL,
  `loan_sgmno` varchar(10) DEFAULT NULL,
  `loan_amount` decimal(10,2) DEFAULT NULL,
  `loan_ser_charge` decimal(10,2) DEFAULT NULL,
  `loan_no_of_inst` int(3) DEFAULT NULL,
  `loan_inst_amt` decimal(10,2) DEFAULT NULL,
  `loan_narration` text DEFAULT NULL,
  `gua_sgmno` varchar(10) DEFAULT NULL,
  `gua_signature2` varchar(100) DEFAULT NULL,
  `gua_mem_name2` varchar(100) DEFAULT NULL,
  `gua_relation2` varchar(10) DEFAULT NULL,
  `shop_proof` varchar(200) DEFAULT NULL,
  `residence_proof` text DEFAULT NULL,
  `loan_request_date` int(10) DEFAULT NULL,
  `comment` text DEFAULT NULL,
  `l_commtee_status` int(1) DEFAULT 0,
  `loan_return_mode` varchar(20) DEFAULT NULL,
  `loan_payment_mode` varchar(20) DEFAULT NULL,
  `loanid` bigint(20) DEFAULT NULL,
  `voucherid` varchar(20) DEFAULT NULL,
  `cheque_draft_no` varchar(30) DEFAULT NULL,
  `bank_name` int(10) DEFAULT NULL,
  `cheque_draft_date` varchar(10) DEFAULT NULL,
  `reject_status` int(1) DEFAULT 0,
  `reject_comment` text DEFAULT NULL,
  `cheque_conf_status` int(1) DEFAULT NULL,
  `status` int(1) NOT NULL DEFAULT 0,
  `oldLoanId` int(11) NOT NULL DEFAULT 0,
  `traccountno` varchar(20) NOT NULL DEFAULT '',
  `security_details` text NOT NULL,
  `recorvery_type` int(4) NOT NULL DEFAULT 0,
  `collector_id` int(5) NOT NULL DEFAULT 0,
  `loanamount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `loan_period` int(5) NOT NULL DEFAULT 0,
  `pan_no` varchar(100) NOT NULL DEFAULT '0',
  `adhar_no` varchar(100) NOT NULL DEFAULT '0',
  `mobile_no` varchar(50) NOT NULL DEFAULT '0',
  `loan_clear_month` int(2) NOT NULL DEFAULT 0,
  `loan_clear_year` int(4) NOT NULL DEFAULT 0,
  `g_mem_no2` varchar(50) NOT NULL DEFAULT '0',
  `g_mem_name2` varchar(250) NOT NULL DEFAULT '0',
  `g_mobile_no2` varchar(50) NOT NULL DEFAULT '0',
  `g_address2` text NOT NULL,
  `gst_no` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `general_voucher`
--

CREATE TABLE `general_voucher` (
  `id` int(11) NOT NULL,
  `vou_id` int(10) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `address` text DEFAULT NULL,
  `asondate` date DEFAULT NULL,
  `exp_subhead` int(10) DEFAULT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `branch_code` int(10) DEFAULT NULL,
  `vou_dateid` int(1) DEFAULT NULL,
  `decription` text DEFAULT NULL,
  `cash_status` int(1) DEFAULT NULL,
  `cheque_no` varchar(20) DEFAULT NULL,
  `cheque_date` date DEFAULT NULL,
  `bank_name` int(10) DEFAULT NULL,
  `fund_id` int(10) DEFAULT NULL,
  `submit_userid` int(10) DEFAULT NULL,
  `cheque_conf_status` int(1) DEFAULT NULL,
  `empid` int(10) DEFAULT NULL,
  `transferid` varchar(10) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `genrate_total_id`
--

CREATE TABLE `genrate_total_id` (
  `id` bigint(15) NOT NULL,
  `genrated_id` bigint(15) DEFAULT NULL,
  `id_by_name` varchar(200) DEFAULT NULL,
  `groups` varchar(10) DEFAULT NULL,
  `fix_status` int(1) DEFAULT 0,
  `pl_Bal_status` varchar(10) DEFAULT NULL,
  `type_of_user` varchar(10) NOT NULL DEFAULT '',
  `tableid` bigint(20) NOT NULL DEFAULT 0,
  `transferstatus` int(11) NOT NULL DEFAULT 0,
  `headType` varchar(10) NOT NULL DEFAULT '',
  `LGHeadStatus` varchar(5) NOT NULL DEFAULT '',
  `branch_codeid` int(2) NOT NULL DEFAULT 0,
  `indraHeadStatus` int(11) NOT NULL DEFAULT 0,
  `group_define` varchar(50) NOT NULL,
  `display_order` int(1) DEFAULT NULL,
  `balance` decimal(10,0) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE `groups` (
  `id` int(11) NOT NULL,
  `groups_name` varchar(150) NOT NULL,
  `short_name` varchar(20) NOT NULL,
  `display_order` int(3) NOT NULL,
  `status` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `gst_branch`
--

CREATE TABLE `gst_branch` (
  `id` int(10) NOT NULL,
  `b_code_short_name` varchar(2) NOT NULL,
  `invoice_t` varchar(10) NOT NULL,
  `b_code_no` varchar(5) NOT NULL,
  `bank_name` varchar(200) NOT NULL,
  `bank_ac_no` varchar(50) NOT NULL,
  `ifs_code` int(11) NOT NULL,
  `state` varchar(11) NOT NULL,
  `state_code` varchar(11) NOT NULL,
  `b_gst_no` varchar(20) NOT NULL,
  `b_telephoneno` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `gst_invoice`
--

CREATE TABLE `gst_invoice` (
  `id` int(11) NOT NULL,
  `b_code_short_name` varchar(10) NOT NULL,
  `b_code_no` varchar(10) NOT NULL,
  `inv_type` varchar(10) NOT NULL,
  `loan_type` varchar(10) NOT NULL,
  `inv_year` varchar(10) NOT NULL,
  `inv_no` int(10) NOT NULL,
  `inv_date` int(11) DEFAULT 0,
  `tax_amt` decimal(10,2) NOT NULL,
  `sgst_amt` decimal(10,2) NOT NULL,
  `cgst_amt` decimal(10,2) NOT NULL,
  `t_inv_amt` decimal(10,2) NOT NULL,
  `aft_tax_amt` decimal(10,2) NOT NULL,
  `loan_id` int(10) NOT NULL,
  `month_of_inv` varchar(2) NOT NULL,
  `year_of_inv` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `item_code`
--

CREATE TABLE `item_code` (
  `id` bigint(15) NOT NULL,
  `propery_type` bigint(15) NOT NULL DEFAULT 0,
  `item_name` varchar(50) NOT NULL DEFAULT '',
  `item_code` varchar(20) NOT NULL DEFAULT '',
  `gen_itemcode` bigint(15) DEFAULT NULL,
  `branch_code` bigint(15) DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `laon_return`
--

CREATE TABLE `laon_return` (
  `id` int(11) NOT NULL,
  `return_inst` varchar(5) NOT NULL DEFAULT '',
  `total_amt` varchar(10) NOT NULL DEFAULT '',
  `cash_type` int(3) NOT NULL DEFAULT 0,
  `cheqe_no` varchar(25) NOT NULL DEFAULT '',
  `cheq_date` date NOT NULL DEFAULT '0000-00-00',
  `bank_name` varchar(5) NOT NULL DEFAULT '',
  `narration` text NOT NULL,
  `cur_date` varchar(10) NOT NULL DEFAULT '',
  `status` int(1) NOT NULL DEFAULT 0,
  `loanid` varchar(10) DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `loan_gst`
--

CREATE TABLE `loan_gst` (
  `id` int(11) NOT NULL,
  `loanid` int(10) NOT NULL,
  `loan_type` varchar(20) NOT NULL,
  `gst_amt` decimal(10,2) NOT NULL,
  `gst_per` decimal(5,0) NOT NULL,
  `loant_per` decimal(5,0) NOT NULL,
  `profit_per` decimal(5,0) NOT NULL,
  `profit_inst` decimal(10,2) NOT NULL,
  `profit_bal` decimal(10,2) NOT NULL,
  `gst_ded_from` int(10) NOT NULL,
  `profit_dues` decimal(10,2) NOT NULL,
  `dues_of_month` varchar(20) NOT NULL,
  `gst_ded_of_month` varchar(20) NOT NULL,
  `gst_ded_amt` decimal(10,2) NOT NULL,
  `bwc_ded_amt` decimal(10,2) NOT NULL,
  `loan_tab_id` int(10) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `loan_id`
--

CREATE TABLE `loan_id` (
  `id` int(11) NOT NULL,
  `loan_id` int(10) DEFAULT NULL,
  `branch_code` int(4) DEFAULT NULL,
  `loan_dateid` int(10) DEFAULT NULL,
  `gen_loan_id` varchar(10) NOT NULL DEFAULT '',
  `loan_type` varchar(4) DEFAULT NULL,
  `colector_id` int(10) NOT NULL DEFAULT 0,
  `oldAcNo` int(11) NOT NULL DEFAULT 0,
  `loan_comp_status` int(11) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `user_type` int(5) NOT NULL DEFAULT 0,
  `user_name` varchar(25) NOT NULL DEFAULT '',
  `password` varchar(200) NOT NULL DEFAULT '',
  `branchid` int(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id`, `user_type`, `user_name`, `password`, `branchid`) VALUES
(13, 2, 'Dilshad', '7e16036a55664f22e6511e460ee09d4f', 7),
(12, 2, 'sohail', '12e086066892a311b752673a28583d3f', 7),
(11, 2, 'santosh', '9407c826d8e3c07ad37cb2d13d1cb641', 7),
(10, 1, 'administrator', '634eff92404f9221b049c106bb5950bf', 7);

-- --------------------------------------------------------

--
-- Table structure for table `membership`
--

CREATE TABLE `membership` (
  `id` bigint(20) NOT NULL,
  `mem_ship_table_id` int(10) NOT NULL DEFAULT 0,
  `branch_id` int(10) DEFAULT NULL,
  `account_type` char(2) DEFAULT NULL,
  `gen_for_accountid` bigint(10) DEFAULT NULL,
  `account_number` varchar(10) DEFAULT NULL,
  `join_date` date DEFAULT NULL,
  `colector_collection_id` int(10) NOT NULL DEFAULT 0,
  `oldAccountNo` varchar(10) NOT NULL DEFAULT '',
  `account_close_status` int(11) NOT NULL,
  `account_close_date` date NOT NULL,
  `stop_payment` int(1) NOT NULL DEFAULT 0,
  `stop_payment_reason` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `membership_details`
--

CREATE TABLE `membership_details` (
  `id` bigint(20) NOT NULL,
  `membership_tableid` bigint(15) NOT NULL DEFAULT 0,
  `opening_date` date NOT NULL DEFAULT '0000-00-00',
  `app_name_one` varchar(40) NOT NULL DEFAULT '',
  `app_name_two` varchar(40) NOT NULL DEFAULT '',
  `app_name_three` varchar(40) NOT NULL DEFAULT '',
  `app_name_four` varchar(40) NOT NULL DEFAULT '',
  `app_name_first` varchar(40) NOT NULL DEFAULT '',
  `father_husban_name` varchar(40) NOT NULL DEFAULT '',
  `permant_address` text NOT NULL,
  `pin_code` varchar(12) NOT NULL DEFAULT '',
  `state` char(3) NOT NULL DEFAULT '',
  `national` char(3) NOT NULL DEFAULT '',
  `phone` varchar(15) NOT NULL DEFAULT '',
  `wit_membership_no` varchar(15) NOT NULL DEFAULT '',
  `wit_name` varchar(30) NOT NULL DEFAULT '',
  `wit_address` text NOT NULL,
  `wit_pin_code` varchar(12) NOT NULL DEFAULT '',
  `wit_state` char(3) NOT NULL DEFAULT '',
  `wit_national` char(3) NOT NULL DEFAULT '',
  `nom_name` varchar(35) NOT NULL DEFAULT '',
  `nom_relation` char(3) NOT NULL DEFAULT '',
  `nom_datebirth` int(2) NOT NULL DEFAULT 0,
  `nom_address` text NOT NULL,
  `nom_pine_code` varchar(12) NOT NULL DEFAULT '',
  `nom_state` char(3) NOT NULL DEFAULT '',
  `nom_national` char(3) NOT NULL DEFAULT '',
  `app_photo_one` varchar(500) NOT NULL DEFAULT '',
  `app_photo_two` varchar(500) NOT NULL DEFAULT '',
  `app_photo_three` varchar(30) NOT NULL DEFAULT '',
  `app_photo_four` varchar(30) NOT NULL DEFAULT '',
  `app_signat_one` varchar(500) NOT NULL DEFAULT '',
  `app_signat_two` varchar(500) NOT NULL DEFAULT '',
  `app_signat_three` varchar(30) NOT NULL DEFAULT '',
  `app_signat_four` varchar(30) NOT NULL DEFAULT '',
  `adminst_charge` varchar(5) NOT NULL DEFAULT '',
  `donation_charge` varchar(5) NOT NULL DEFAULT '',
  `collector_id` int(10) DEFAULT NULL,
  `nomine_minnor` varchar(30) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `morabiya_loan`
--

CREATE TABLE `morabiya_loan` (
  `loan_app_id` int(11) NOT NULL,
  `branch_code` int(10) DEFAULT NULL,
  `loan_sgmno` varchar(10) DEFAULT NULL,
  `loan_amount` decimal(10,2) DEFAULT NULL,
  `loan_profit` decimal(10,2) DEFAULT NULL,
  `loan_margin_mon` decimal(10,2) DEFAULT NULL,
  `loan_no_of_inst` int(3) DEFAULT NULL,
  `loan_inst_amt` decimal(10,2) DEFAULT NULL,
  `loan_narration` text DEFAULT NULL,
  `gua_sgmno` varchar(10) DEFAULT NULL,
  `gua_signature2` varchar(100) DEFAULT NULL,
  `gua_mem_name2` varchar(100) DEFAULT NULL,
  `gua_relation2` varchar(10) DEFAULT NULL,
  `shop_proof` varchar(200) DEFAULT NULL,
  `residence_proof` text DEFAULT NULL,
  `loan_request_date` int(10) DEFAULT NULL,
  `comment` text DEFAULT NULL,
  `l_commtee_status` int(1) DEFAULT 0,
  `loan_payment_mode` varchar(20) DEFAULT NULL,
  `loanid` varchar(20) DEFAULT NULL,
  `voucherid` varchar(20) DEFAULT NULL,
  `cheque_draft_no` varchar(30) DEFAULT NULL,
  `bank_name` int(10) DEFAULT NULL,
  `cheque_draft_date` varchar(10) DEFAULT NULL,
  `reject_status` int(1) DEFAULT 0,
  `reject_comment` text DEFAULT NULL,
  `cheque_conf_status` int(1) DEFAULT NULL,
  `stockid` int(10) NOT NULL DEFAULT 0,
  `quantity` int(10) NOT NULL DEFAULT 0,
  `status` int(11) NOT NULL DEFAULT 0,
  `oldLoanId` int(11) NOT NULL DEFAULT 0,
  `traccountno` varchar(20) NOT NULL DEFAULT '',
  `security_details` text NOT NULL,
  `recorvery_type` int(4) NOT NULL DEFAULT 0,
  `collector_id` int(5) NOT NULL DEFAULT 0,
  `loanamount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `loan_period` int(5) NOT NULL DEFAULT 0,
  `pan_no` varchar(100) NOT NULL DEFAULT '0',
  `adhar_no` varchar(100) NOT NULL DEFAULT '0',
  `mobile_no` varchar(50) NOT NULL DEFAULT '0',
  `loan_clear_month` int(2) NOT NULL DEFAULT 0,
  `loan_clear_year` int(4) NOT NULL DEFAULT 0,
  `g_mem_no2` varchar(50) NOT NULL DEFAULT '0',
  `g_mem_name2` varchar(250) NOT NULL DEFAULT '0',
  `g_mobile_no2` varchar(50) NOT NULL DEFAULT '0',
  `g_address2` text NOT NULL,
  `gst_no` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `mtbl_loan`
--

CREATE TABLE `mtbl_loan` (
  `loan_app_id` int(11) NOT NULL,
  `branch_code` int(10) DEFAULT NULL,
  `loan_sgmno` varchar(10) DEFAULT NULL,
  `loan_amount` decimal(10,2) DEFAULT NULL,
  `loan_profit` decimal(10,2) DEFAULT NULL,
  `loan_depo_status` varchar(10) DEFAULT NULL,
  `loan_narration` text DEFAULT NULL,
  `gua_sgmno` varchar(10) DEFAULT NULL,
  `gua_signature2` varchar(100) DEFAULT NULL,
  `gua_mem_name2` varchar(100) DEFAULT NULL,
  `gua_relation2` varchar(10) DEFAULT NULL,
  `shop_proof` varchar(200) DEFAULT NULL,
  `residence_proof` text DEFAULT NULL,
  `loan_request_date` int(10) DEFAULT NULL,
  `comment` text DEFAULT NULL,
  `l_commtee_status` int(1) DEFAULT 0,
  `loan_payment_mode` varchar(20) DEFAULT NULL,
  `loanid` varchar(20) DEFAULT NULL,
  `voucherid` varchar(20) DEFAULT NULL,
  `cheque_draft_no` varchar(30) DEFAULT NULL,
  `bank_name` int(10) DEFAULT NULL,
  `cheque_draft_date` varchar(10) DEFAULT NULL,
  `reject_status` int(1) DEFAULT 0,
  `reject_comment` text DEFAULT NULL,
  `cheque_conf_status` int(1) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT 0,
  `oldLoanId` int(11) NOT NULL DEFAULT 0,
  `traccountno` varchar(10) NOT NULL DEFAULT '0',
  `loan_no_of_inst` int(11) NOT NULL,
  `loan_inst_amt` decimal(10,2) NOT NULL,
  `security_details` text NOT NULL,
  `recorvery_type` int(4) NOT NULL DEFAULT 0,
  `collector_id` int(5) NOT NULL DEFAULT 0,
  `loanamount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `loan_period` int(5) NOT NULL DEFAULT 0,
  `pan_no` varchar(100) NOT NULL DEFAULT '0',
  `adhar_no` varchar(100) NOT NULL DEFAULT '0',
  `mobile_no` varchar(50) NOT NULL DEFAULT '0',
  `loan_clear_month` int(2) NOT NULL DEFAULT 0,
  `loan_clear_year` int(4) NOT NULL DEFAULT 0,
  `g_mem_no2` varchar(50) NOT NULL DEFAULT '0',
  `g_mem_name2` varchar(250) NOT NULL DEFAULT '0',
  `g_mobile_no2` varchar(50) NOT NULL DEFAULT '0',
  `g_address2` text NOT NULL,
  `gst_no` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `outstanding`
--

CREATE TABLE `outstanding` (
  `id` int(11) NOT NULL,
  `vou_id` int(10) NOT NULL DEFAULT 0,
  `name` varchar(50) DEFAULT NULL,
  `address` text DEFAULT NULL,
  `asondate` date DEFAULT NULL,
  `exp_subhead` int(10) NOT NULL DEFAULT 0,
  `amount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `branch_code` int(10) NOT NULL DEFAULT 0,
  `vou_dateid` int(1) NOT NULL DEFAULT 0,
  `decription` text DEFAULT NULL,
  `cash_status` int(1) NOT NULL DEFAULT 0,
  `cheque_no` varchar(20) DEFAULT NULL,
  `cheque_date` date DEFAULT NULL,
  `bank_name` int(10) NOT NULL DEFAULT 0,
  `fund_id` int(10) NOT NULL DEFAULT 0,
  `submit_userid` int(10) NOT NULL DEFAULT 0,
  `staff_id` int(10) NOT NULL DEFAULT 0,
  `designation` int(10) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `receipt_voucher`
--

CREATE TABLE `receipt_voucher` (
  `id` int(11) NOT NULL,
  `voucherId` int(10) NOT NULL DEFAULT 0,
  `recHead` int(3) NOT NULL DEFAULT 0,
  `recName` varchar(50) NOT NULL DEFAULT '',
  `recAddress` text NOT NULL,
  `recdate` date NOT NULL DEFAULT '0000-00-00',
  `recAmount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `cashType` int(1) NOT NULL DEFAULT 0,
  `chequeNo` varchar(20) NOT NULL DEFAULT '',
  `chequeDate` date NOT NULL DEFAULT '0000-00-00',
  `bankName` int(3) NOT NULL DEFAULT 0,
  `narration` text NOT NULL,
  `recptdateId` int(10) NOT NULL DEFAULT 0,
  `verifyStatus` int(2) NOT NULL DEFAULT 0,
  `branch_code` int(3) DEFAULT NULL,
  `cheque_conf_status` int(1) DEFAULT NULL,
  `registerId` varchar(10) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `recipt`
--

CREATE TABLE `recipt` (
  `id` int(11) NOT NULL,
  `recipt_type` int(3) NOT NULL DEFAULT 0,
  `book_no` varchar(15) NOT NULL DEFAULT '',
  `recipt_from` varchar(8) NOT NULL DEFAULT '',
  `recipt_to` varchar(8) NOT NULL DEFAULT '',
  `total_recipt` varchar(10) NOT NULL DEFAULT '',
  `date` date NOT NULL DEFAULT '0000-00-00',
  `branch_name` varchar(8) DEFAULT NULL,
  `status` int(1) DEFAULT 0,
  `collector_name` varchar(5) DEFAULT NULL,
  `collector_status` int(1) DEFAULT 0,
  `branch_date` date DEFAULT NULL,
  `collector_date` date DEFAULT NULL
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
-- Table structure for table `returnadvance`
--

CREATE TABLE `returnadvance` (
  `id` int(11) NOT NULL,
  `investment_id` int(1) NOT NULL DEFAULT 0,
  `branchCode` int(5) NOT NULL DEFAULT 0,
  `voucherId` bigint(15) NOT NULL DEFAULT 0,
  `cashStatus` varchar(10) NOT NULL DEFAULT '',
  `cheque_no` varchar(20) NOT NULL DEFAULT '',
  `cheque_date` varchar(20) NOT NULL DEFAULT '',
  `bankName` int(10) NOT NULL DEFAULT 0,
  `returmAmonnt` decimal(10,2) NOT NULL DEFAULT 0.00,
  `returnDateid` bigint(15) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `returninvestment`
--

CREATE TABLE `returninvestment` (
  `id` int(11) NOT NULL,
  `investment_id` int(1) NOT NULL DEFAULT 0,
  `branchCode` int(5) NOT NULL DEFAULT 0,
  `voucherId` bigint(15) NOT NULL DEFAULT 0,
  `cashStatus` varchar(10) NOT NULL DEFAULT '',
  `cheque_no` varchar(20) NOT NULL DEFAULT '',
  `cheque_date` varchar(20) NOT NULL DEFAULT '',
  `bankName` int(10) NOT NULL DEFAULT 0,
  `returmAmonnt` decimal(10,2) NOT NULL DEFAULT 0.00,
  `returnDateid` bigint(15) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `state`
--

CREATE TABLE `state` (
  `id` int(11) NOT NULL,
  `state` varchar(40) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `stbllaon_return`
--

CREATE TABLE `stbllaon_return` (
  `id` int(11) NOT NULL,
  `amount` varchar(20) NOT NULL DEFAULT '',
  `cash_type` int(3) NOT NULL DEFAULT 0,
  `cheqeno` varchar(20) NOT NULL DEFAULT '',
  `cheqe_date` date NOT NULL DEFAULT '0000-00-00',
  `bank_name` int(3) NOT NULL DEFAULT 0,
  `narrtion` text NOT NULL,
  `loanid` varchar(20) NOT NULL DEFAULT '',
  `status` int(1) NOT NULL DEFAULT 0,
  `cur_loandate` int(10) DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `stbl_loan`
--

CREATE TABLE `stbl_loan` (
  `loan_app_id` int(11) NOT NULL,
  `branch_code` int(10) DEFAULT NULL,
  `loan_sgmno` varchar(10) DEFAULT NULL,
  `loan_amount` decimal(10,2) DEFAULT NULL,
  `loan_profit` decimal(10,2) DEFAULT NULL,
  `loan_depo_status` varchar(10) DEFAULT NULL,
  `loan_narration` text DEFAULT NULL,
  `gua_sgmno` varchar(10) DEFAULT NULL,
  `gua_signature2` varchar(100) DEFAULT NULL,
  `gua_mem_name2` varchar(100) DEFAULT NULL,
  `gua_relation2` varchar(10) DEFAULT NULL,
  `shop_proof` varchar(200) DEFAULT NULL,
  `residence_proof` text DEFAULT NULL,
  `loan_request_date` int(10) DEFAULT NULL,
  `comment` text DEFAULT NULL,
  `l_commtee_status` int(1) DEFAULT 0,
  `loan_payment_mode` varchar(20) DEFAULT NULL,
  `loanid` varchar(20) DEFAULT NULL,
  `voucherid` varchar(20) DEFAULT NULL,
  `cheque_draft_no` varchar(30) DEFAULT NULL,
  `bank_name` int(10) DEFAULT NULL,
  `cheque_draft_date` varchar(10) DEFAULT NULL,
  `reject_status` int(1) DEFAULT 0,
  `reject_comment` text DEFAULT NULL,
  `cheque_conf_status` int(1) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT 0,
  `oldLoanId` int(11) NOT NULL DEFAULT 0,
  `traccountno` varchar(20) NOT NULL DEFAULT '',
  `loan_no_of_inst` int(10) NOT NULL,
  `loan_inst_amt` decimal(10,2) NOT NULL,
  `security_details` text NOT NULL,
  `recorvery_type` int(4) NOT NULL DEFAULT 0,
  `collector_id` int(5) NOT NULL DEFAULT 0,
  `loanamount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `loan_period` int(5) NOT NULL DEFAULT 0,
  `pan_no` varchar(100) NOT NULL DEFAULT '0',
  `adhar_no` varchar(100) NOT NULL DEFAULT '0',
  `mobile_no` varchar(50) NOT NULL DEFAULT '0',
  `loan_clear_month` int(2) NOT NULL DEFAULT 0,
  `loan_clear_year` int(4) NOT NULL DEFAULT 0,
  `g_mem_no2` varchar(50) NOT NULL DEFAULT '0',
  `g_mem_name2` varchar(250) NOT NULL DEFAULT '0',
  `g_mobile_no2` varchar(50) NOT NULL DEFAULT '0',
  `g_address2` text NOT NULL,
  `gst_no` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `supsen_account`
--

CREATE TABLE `supsen_account` (
  `id` int(11) NOT NULL,
  `susepetype` varchar(30) NOT NULL DEFAULT '',
  `status` int(1) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `voucher_no`
--

CREATE TABLE `voucher_no` (
  `id` int(11) NOT NULL,
  `voucher_no` int(10) DEFAULT NULL,
  `voucher_year` varbinary(10) DEFAULT NULL,
  `branch_code` int(10) DEFAULT NULL,
  `verify_status` int(1) DEFAULT 0,
  `voucher_date_id` int(10) DEFAULT NULL,
  `user_login_id` int(10) NOT NULL,
  `user_login_date_time` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `withdrw`
--

CREATE TABLE `withdrw` (
  `id` int(11) NOT NULL,
  `branch_code` int(10) NOT NULL DEFAULT 0,
  `depo_date` int(10) NOT NULL DEFAULT 0,
  `accountid` varchar(10) NOT NULL DEFAULT '',
  `amount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `narration` text NOT NULL,
  `voucher_no` int(10) NOT NULL DEFAULT 0,
  `cash_type` int(3) DEFAULT 0,
  `cheque_no` varchar(20) DEFAULT '0',
  `che_date` date DEFAULT NULL,
  `bank` varchar(5) DEFAULT '0',
  `cheque_conf_status` int(1) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounthead`
--
ALTER TABLE `accounthead`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `balance_sheet_entry`
--
ALTER TABLE `balance_sheet_entry`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `branch_detils`
--
ALTER TABLE `branch_detils`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `branch_heading`
--
ALTER TABLE `branch_heading`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `branch_user`
--
ALTER TABLE `branch_user`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `collection_file`
--
ALTER TABLE `collection_file`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `coll_depo_amount`
--
ALTER TABLE `coll_depo_amount`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `coll_voucher_entry`
--
ALTER TABLE `coll_voucher_entry`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `daily_collection`
--
ALTER TABLE `daily_collection`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `daybook`
--
ALTER TABLE `daybook`
  ADD PRIMARY KEY (`id`),
  ADD KEY `daybokcramount` (`drparticular`,`crparticular`,`groups`),
  ADD KEY `daybokcramount1` (`crparticular`,`groups`),
  ADD KEY `daybokcramount2` (`drparticular`,`groups`);

--
-- Indexes for table `demand_loan`
--
ALTER TABLE `demand_loan`
  ADD PRIMARY KEY (`loan_app_id`);

--
-- Indexes for table `general_voucher`
--
ALTER TABLE `general_voucher`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `genrate_total_id`
--
ALTER TABLE `genrate_total_id`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fetch_rows` (`tableid`,`type_of_user`),
  ADD KEY `fetch_rows1` (`type_of_user`);

--
-- Indexes for table `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `gst_branch`
--
ALTER TABLE `gst_branch`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `gst_invoice`
--
ALTER TABLE `gst_invoice`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `item_code`
--
ALTER TABLE `item_code`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `laon_return`
--
ALTER TABLE `laon_return`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `loan_gst`
--
ALTER TABLE `loan_gst`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `loan_id`
--
ALTER TABLE `loan_id`
  ADD PRIMARY KEY (`id`),
  ADD KEY `loan` (`loan_id`,`loan_type`);

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
-- Indexes for table `membership_details`
--
ALTER TABLE `membership_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `morabiya_loan`
--
ALTER TABLE `morabiya_loan`
  ADD PRIMARY KEY (`loan_app_id`);

--
-- Indexes for table `mtbl_loan`
--
ALTER TABLE `mtbl_loan`
  ADD PRIMARY KEY (`loan_app_id`);

--
-- Indexes for table `outstanding`
--
ALTER TABLE `outstanding`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `receipt_voucher`
--
ALTER TABLE `receipt_voucher`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `recipt`
--
ALTER TABLE `recipt`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `relationship`
--
ALTER TABLE `relationship`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `returnadvance`
--
ALTER TABLE `returnadvance`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `returninvestment`
--
ALTER TABLE `returninvestment`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `state`
--
ALTER TABLE `state`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stbllaon_return`
--
ALTER TABLE `stbllaon_return`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stbl_loan`
--
ALTER TABLE `stbl_loan`
  ADD PRIMARY KEY (`loan_app_id`);

--
-- Indexes for table `supsen_account`
--
ALTER TABLE `supsen_account`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `voucher_no`
--
ALTER TABLE `voucher_no`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `withdrw`
--
ALTER TABLE `withdrw`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accounthead`
--
ALTER TABLE `accounthead`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `balance_sheet_entry`
--
ALTER TABLE `balance_sheet_entry`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `branch_detils`
--
ALTER TABLE `branch_detils`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `branch_heading`
--
ALTER TABLE `branch_heading`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `branch_user`
--
ALTER TABLE `branch_user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `collection_file`
--
ALTER TABLE `collection_file`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `coll_depo_amount`
--
ALTER TABLE `coll_depo_amount`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `coll_voucher_entry`
--
ALTER TABLE `coll_voucher_entry`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `daily_collection`
--
ALTER TABLE `daily_collection`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `daybook`
--
ALTER TABLE `daybook`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `demand_loan`
--
ALTER TABLE `demand_loan`
  MODIFY `loan_app_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `general_voucher`
--
ALTER TABLE `general_voucher`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `genrate_total_id`
--
ALTER TABLE `genrate_total_id`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `groups`
--
ALTER TABLE `groups`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `gst_branch`
--
ALTER TABLE `gst_branch`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `gst_invoice`
--
ALTER TABLE `gst_invoice`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `item_code`
--
ALTER TABLE `item_code`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `laon_return`
--
ALTER TABLE `laon_return`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `loan_gst`
--
ALTER TABLE `loan_gst`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `loan_id`
--
ALTER TABLE `loan_id`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `membership`
--
ALTER TABLE `membership`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `membership_details`
--
ALTER TABLE `membership_details`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `morabiya_loan`
--
ALTER TABLE `morabiya_loan`
  MODIFY `loan_app_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mtbl_loan`
--
ALTER TABLE `mtbl_loan`
  MODIFY `loan_app_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `outstanding`
--
ALTER TABLE `outstanding`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `receipt_voucher`
--
ALTER TABLE `receipt_voucher`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `recipt`
--
ALTER TABLE `recipt`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `relationship`
--
ALTER TABLE `relationship`
  MODIFY `id` bigint(15) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `returnadvance`
--
ALTER TABLE `returnadvance`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `returninvestment`
--
ALTER TABLE `returninvestment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `state`
--
ALTER TABLE `state`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stbllaon_return`
--
ALTER TABLE `stbllaon_return`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stbl_loan`
--
ALTER TABLE `stbl_loan`
  MODIFY `loan_app_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supsen_account`
--
ALTER TABLE `supsen_account`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `voucher_no`
--
ALTER TABLE `voucher_no`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `withdrw`
--
ALTER TABLE `withdrw`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
