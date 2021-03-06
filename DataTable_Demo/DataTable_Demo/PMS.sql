USE [master]
GO

/****** Object:  Database [PMS]    Script Date: 09/11/2017 12:14:09 ******/
CREATE DATABASE [PMS] ON  PRIMARY 
( NAME = N'PMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PMS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [PMS] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PMS] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PMS] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PMS] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PMS] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PMS] SET ARITHABORT OFF 
GO

ALTER DATABASE [PMS] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PMS] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [PMS] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PMS] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PMS] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PMS] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PMS] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PMS] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PMS] SET  DISABLE_BROKER 
GO

ALTER DATABASE [PMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PMS] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PMS] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PMS] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PMS] SET  READ_WRITE 
GO

ALTER DATABASE [PMS] SET RECOVERY FULL 
GO

ALTER DATABASE [PMS] SET  MULTI_USER 
GO

ALTER DATABASE [PMS] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PMS] SET DB_CHAINING OFF 
GO


