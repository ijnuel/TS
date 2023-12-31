USE [master]
GO
/****** Object:  Database [PatientManagement]    Script Date: 12/06/2023 5:11:31 AM ******/
CREATE DATABASE [PatientManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PatientManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PatientManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PatientManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PatientManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PatientManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PatientManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PatientManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PatientManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PatientManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PatientManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PatientManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [PatientManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PatientManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PatientManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PatientManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PatientManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PatientManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PatientManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PatientManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PatientManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PatientManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PatientManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PatientManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PatientManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PatientManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PatientManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PatientManagement] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PatientManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PatientManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PatientManagement] SET  MULTI_USER 
GO
ALTER DATABASE [PatientManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PatientManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PatientManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PatientManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PatientManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PatientManagement] SET QUERY_STORE = OFF
GO
USE [PatientManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/06/2023 5:11:32 AM ******/
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
/****** Object:  Table [dbo].[Patients]    Script Date: 12/06/2023 5:11:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [uniqueidentifier] NOT NULL,
	[PatientId] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/06/2023 5:11:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [uniqueidentifier] NOT NULL,
	[Amount] [float] NOT NULL,
	[PaymentDate] [datetime2](7) NOT NULL,
	[PatientId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230611114513_FirstMigration', N'7.0.5')
GO
INSERT [dbo].[Patients] ([Id], [PatientId], [FirstName], [LastName]) VALUES (N'c36baf70-634c-4af5-8d9c-31faa83bcb94', N'102', N'NewMan', N'Clients')
INSERT [dbo].[Patients] ([Id], [PatientId], [FirstName], [LastName]) VALUES (N'29336e70-1c65-444e-ae89-5831039cc9ad', N'104', N'New', N'Patient')
INSERT [dbo].[Patients] ([Id], [PatientId], [FirstName], [LastName]) VALUES (N'ecc48869-d763-4f29-9e67-967e5a373208', N'101', N'Patient', N'SomeNames')
GO
INSERT [dbo].[Payments] ([Id], [Amount], [PaymentDate], [PatientId]) VALUES (N'aa2a12bd-8a60-43bf-a9f5-2333a096be9c', 100.07, CAST(N'2023-06-13T12:00:00.0000000' AS DateTime2), N'ecc48869-d763-4f29-9e67-967e5a373208')
GO
/****** Object:  Index [IX_Payments_PatientId]    Script Date: 12/06/2023 5:11:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_PatientId] ON [dbo].[Payments]
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Patients_PatientId]
GO
USE [master]
GO
ALTER DATABASE [PatientManagement] SET  READ_WRITE 
GO
