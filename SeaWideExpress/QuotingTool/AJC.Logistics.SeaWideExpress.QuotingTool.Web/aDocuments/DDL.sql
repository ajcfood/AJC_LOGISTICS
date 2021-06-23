USE [master]
GO
/****** Object:  Database [QuotingTool]    Script Date: 7/6/2021 8:56:03 p. m. ******/
CREATE DATABASE [QuotingTool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuotingTool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\QuotingTool.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuotingTool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\QuotingTool_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuotingTool] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuotingTool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuotingTool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuotingTool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuotingTool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuotingTool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuotingTool] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuotingTool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuotingTool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuotingTool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuotingTool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuotingTool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuotingTool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuotingTool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuotingTool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuotingTool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuotingTool] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuotingTool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuotingTool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuotingTool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuotingTool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuotingTool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuotingTool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuotingTool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuotingTool] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuotingTool] SET  MULTI_USER 
GO
ALTER DATABASE [QuotingTool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuotingTool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuotingTool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuotingTool] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuotingTool]
GO

/****** Object:  Table [dbo].[Test]    Script Date: 7/6/2021 8:56:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechadesde] [datetime] NULL,
	[fechahasta] [datetime] NULL,
	[zona] [int] NULL,
	[zonaDescripcion] [varchar](50) NULL,
	[precio] [decimal](18, 3) NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Test] ON 
GO
INSERT [dbo].[Test] ([id], [fechadesde], [fechahasta], [zona], [zonaDescripcion], [precio]) VALUES (1, CAST(N'2021-10-10T12:00:00.000' AS DateTime), CAST(N'2021-10-10T12:00:00.000' AS DateTime), 1, N'1', CAST(12.010 AS Decimal(18, 3)))
GO
INSERT [dbo].[Test] ([id], [fechadesde], [fechahasta], [zona], [zonaDescripcion], [precio]) VALUES (2, CAST(N'2021-10-10T12:00:00.000' AS DateTime), CAST(N'2021-10-10T12:00:00.000' AS DateTime), 1, N'1', CAST(15.000 AS Decimal(18, 3)))
GO
INSERT [dbo].[Test] ([id], [fechadesde], [fechahasta], [zona], [zonaDescripcion], [precio]) VALUES (3, CAST(N'2021-10-10T12:00:00.000' AS DateTime), CAST(N'2021-10-10T12:00:00.000' AS DateTime), 1, N'5', CAST(20.000 AS Decimal(18, 3)))
GO
INSERT [dbo].[Test] ([id], [fechadesde], [fechahasta], [zona], [zonaDescripcion], [precio]) VALUES (4, CAST(N'2021-10-10T12:00:00.000' AS DateTime), CAST(N'2021-10-10T12:00:00.000' AS DateTime), 4, N'7', CAST(55.000 AS Decimal(18, 3)))
GO
INSERT [dbo].[Test] ([id], [fechadesde], [fechahasta], [zona], [zonaDescripcion], [precio]) VALUES (5, CAST(N'2021-10-10T12:00:00.000' AS DateTime), CAST(N'2021-10-10T12:00:00.000' AS DateTime), 7, N'4', CAST(66.000 AS Decimal(18, 3)))
GO
INSERT [dbo].[Test] ([id], [fechadesde], [fechahasta], [zona], [zonaDescripcion], [precio]) VALUES (6, CAST(N'2021-10-10T12:00:00.000' AS DateTime), CAST(N'2021-10-10T12:00:00.000' AS DateTime), 8, N'4', CAST(77.000 AS Decimal(18, 3)))
GO
INSERT [dbo].[Test] ([id], [fechadesde], [fechahasta], [zona], [zonaDescripcion], [precio]) VALUES (7, CAST(N'2021-10-10T12:00:00.000' AS DateTime), CAST(N'2021-10-10T12:00:00.000' AS DateTime), 4, N'2', CAST(90.000 AS Decimal(18, 3)))
GO
INSERT [dbo].[Test] ([id], [fechadesde], [fechahasta], [zona], [zonaDescripcion], [precio]) VALUES (8, CAST(N'2021-10-10T12:00:00.000' AS DateTime), CAST(N'2021-10-10T12:00:00.000' AS DateTime), 75, N'4', CAST(150.000 AS Decimal(18, 3)))
GO
INSERT [dbo].[Test] ([id], [fechadesde], [fechahasta], [zona], [zonaDescripcion], [precio]) VALUES (9, CAST(N'2021-10-10T12:00:00.000' AS DateTime), CAST(N'2021-10-10T12:00:00.000' AS DateTime), 44, N'4', CAST(250.000 AS Decimal(18, 3)))
GO
INSERT [dbo].[Test] ([id], [fechadesde], [fechahasta], [zona], [zonaDescripcion], [precio]) VALUES (10, CAST(N'2021-10-10T12:00:00.000' AS DateTime), CAST(N'2021-10-10T12:00:00.000' AS DateTime), 55, N'4', CAST(350.000 AS Decimal(18, 3)))
GO
SET IDENTITY_INSERT [dbo].[Test] OFF
GO
USE [master]
GO
ALTER DATABASE [QuotingTool] SET  READ_WRITE 
GO
