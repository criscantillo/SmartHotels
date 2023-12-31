USE [master]
GO
/****** Object:  Database [SmartHotel]    Script Date: 8/12/2023 1:33:05 a. m. ******/
CREATE DATABASE [SmartHotel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SmartHotel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SmartHotel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SmartHotel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SmartHotel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SmartHotel] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SmartHotel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SmartHotel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SmartHotel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SmartHotel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SmartHotel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SmartHotel] SET ARITHABORT OFF 
GO
ALTER DATABASE [SmartHotel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SmartHotel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SmartHotel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SmartHotel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SmartHotel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SmartHotel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SmartHotel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SmartHotel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SmartHotel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SmartHotel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SmartHotel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SmartHotel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SmartHotel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SmartHotel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SmartHotel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SmartHotel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SmartHotel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SmartHotel] SET RECOVERY FULL 
GO
ALTER DATABASE [SmartHotel] SET  MULTI_USER 
GO
ALTER DATABASE [SmartHotel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SmartHotel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SmartHotel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SmartHotel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SmartHotel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SmartHotel] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SmartHotel', N'ON'
GO
ALTER DATABASE [SmartHotel] SET QUERY_STORE = ON
GO
ALTER DATABASE [SmartHotel] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SmartHotel]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/12/2023 1:33:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[guest]    Script Date: 8/12/2023 1:33:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[guest](
	[guest_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [nvarchar](30) NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NULL,
	[birthdate] [date] NULL,
	[gender] [nvarchar](20) NULL,
	[document_type] [nvarchar](3) NULL,
	[document_number] [nvarchar](20) NULL,
	[email] [nvarchar](70) NULL,
	[contact_phone] [nvarchar](15) NULL,
 CONSTRAINT [PK_guest] PRIMARY KEY CLUSTERED 
(
	[guest_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hotel]    Script Date: 8/12/2023 1:33:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hotel](
	[hotel_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[city] [nvarchar](80) NULL,
	[address] [nvarchar](200) NULL,
	[stars] [int] NULL,
	[user_id] [nvarchar](30) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_hotel] PRIMARY KEY CLUSTERED 
(
	[hotel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reservation]    Script Date: 8/12/2023 1:33:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservation](
	[reserve_id] [int] IDENTITY(1,1) NOT NULL,
	[hotel_id] [int] NOT NULL,
	[room_id] [int] NOT NULL,
	[from_date] [date] NOT NULL,
	[to_date] [date] NOT NULL,
	[reserve_at] [date] NOT NULL,
	[emergency_contact_name] [nvarchar](100) NULL,
	[emergency_contact_phone] [nvarchar](20) NULL,
	[user_id] [nvarchar](30) NOT NULL,
	[guest_ids] [nvarchar](200) NOT NULL,
	[total_price] [float] NOT NULL,
 CONSTRAINT [PK_reservation] PRIMARY KEY CLUSTERED 
(
	[reserve_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[room]    Script Date: 8/12/2023 1:33:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[room](
	[room_id] [int] IDENTITY(1,1) NOT NULL,
	[hotel_id] [int] NOT NULL,
	[location] [nvarchar](20) NOT NULL,
	[type] [smallint] NOT NULL,
	[capacity] [smallint] NOT NULL,
	[base_price] [float] NOT NULL,
	[taxes] [float] NOT NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_room] PRIMARY KEY CLUSTERED 
(
	[room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_app]    Script Date: 8/12/2023 1:33:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_app](
	[user_id] [nvarchar](30) NOT NULL,
	[user_name] [nvarchar](60) NOT NULL,
	[user_email] [nvarchar](50) NOT NULL,
	[user_type] [smallint] NOT NULL,
	[user_active] [bit] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[room]  WITH CHECK ADD  CONSTRAINT [FK_room_hotel] FOREIGN KEY([hotel_id])
REFERENCES [dbo].[hotel] ([hotel_id])
GO
ALTER TABLE [dbo].[room] CHECK CONSTRAINT [FK_room_hotel]
GO
USE [master]
GO
ALTER DATABASE [SmartHotel] SET  READ_WRITE 
GO
