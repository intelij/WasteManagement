USE [master]
GO
/****** Object:  Database [Nasscom]    Script Date: 07-04-2018 21:28:46 ******/
CREATE DATABASE [Nasscom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nasscom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Nasscom.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Nasscom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Nasscom_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nasscom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nasscom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nasscom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nasscom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nasscom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nasscom] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nasscom] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Nasscom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nasscom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nasscom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nasscom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nasscom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nasscom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nasscom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nasscom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nasscom] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Nasscom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nasscom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nasscom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nasscom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nasscom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nasscom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nasscom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nasscom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Nasscom] SET  MULTI_USER 
GO
ALTER DATABASE [Nasscom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nasscom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nasscom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nasscom] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Nasscom]
GO
/****** Object:  Table [dbo].[Compactor]    Script Date: 07-04-2018 21:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compactor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompactorNumber] [varchar](50) NULL,
	[Size] [varchar](50) NULL,
	[Make] [varchar](50) NULL,
	[LocationId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Complains]    Script Date: 07-04-2018 21:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complains](
	[ComplainID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[ContactNumber] [nvarchar](500) NULL,
	[Location] [nvarchar](500) NULL,
	[Compactor] [nvarchar](500) NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ComplainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeploymentSheet]    Script Date: 07-04-2018 21:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeploymentSheet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteNumber] [varchar](50) NULL,
	[DeploymentDate] [datetime] NULL,
	[VehicleNo] [varchar](50) NULL,
	[Substitute] [int] NULL,
	[StaffId] [int] NULL,
	[StaffType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 07-04-2018 21:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 07-04-2018 21:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteNumber] [varchar](50) NULL,
	[VehicleNo] [varchar](50) NULL,
	[DriverID] [int] NULL,
	[CrewID] [int] NULL,
	[WorkerID] [int] NULL,
	[locationId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 07-04-2018 21:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
	[Phone] [varchar](10) NULL,
	[StaffType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffType]    Script Date: 07-04-2018 21:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeDescription] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 07-04-2018 21:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[VehicleNo] [varchar](50) NOT NULL,
	[RegistrationDate] [datetime] NULL,
	[Make] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Compactor] ON 
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (1, N'C-123', N'Large', N'Ashok Leyland', 1)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (2, N'C-123', N'Large', N'Ashok Leyland', 1)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (3, N'C-113', N'Medium', N'Ashok Leyland', 2)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (4, N'C-928', N'Small', N'Ashok Leyland', 3)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (5, N'C-139', N'Large', N'Ashok Leyland', 4)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (6, N'C-188', N'Medium', N'Ashok Leyland', 5)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (7, N'C-103', N'Small', N'Ashok Leyland', 6)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (8, N'C-223', N'Large', N'Ashok Leyland', 7)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (9, N'C-143', N'Medium', N'Ashok Leyland', 8)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (10, N'C-423', N'Small', N'Ashok Leyland', 9)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (11, N'C-983', N'Medium', N'Ashok Leyland', 10)
GO
INSERT [dbo].[Compactor] ([Id], [CompactorNumber], [Size], [Make], [LocationId]) VALUES (12, N'C-124', N'Large', N'jlajdl', 1)
GO
SET IDENTITY_INSERT [dbo].[Compactor] OFF
GO
SET IDENTITY_INSERT [dbo].[Complains] ON 
GO
INSERT [dbo].[Complains] ([ComplainID], [Name], [Email], [ContactNumber], [Location], [Compactor], [Description]) VALUES (1, N'', N'harshadmehta001@gmail.com', N'79237299832', N'xyz', N'jaljldla', NULL)
GO
INSERT [dbo].[Complains] ([ComplainID], [Name], [Email], [ContactNumber], [Location], [Compactor], [Description]) VALUES (2, N'', N'fawf', N'7979', N'ualkjdfljl', N'809809A', NULL)
GO
INSERT [dbo].[Complains] ([ComplainID], [Name], [Email], [ContactNumber], [Location], [Compactor], [Description]) VALUES (3, N'', N'Test@gmail.com', N'808308230', N'jlajljal;jal;', N'jaljfdlajl;', NULL)
GO
SET IDENTITY_INSERT [dbo].[Complains] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (1, N'Noida sector 1 Block A', N'Noida sector 1 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (2, N'Noida sector 1 Block B', N'Noida sector 1 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (3, N'Noida sector 1 Block C', N'Noida sector 1 Block C')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (4, N'Noida sector 2 Block A', N'Noida sector 2 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (5, N'Noida sector 2 Block B', N'Noida sector 2 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (6, N'Noida sector 2 Block C', N'Noida sector 2 Block C')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (7, N'Noida sector 3 Block A', N'Noida sector 3 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (8, N'Noida sector 3 Block B', N'Noida sector 3 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (9, N'Noida sector 3 Block C', N'Noida sector 3 Block C')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (10, N'Noida sector 4 Block A', N'Noida sector 4 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (11, N'Noida sector 4 Block B', N'Noida sector 4 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (12, N'Noida sector 4 Block C', N'Noida sector 4 Block C')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (13, N'Noida sector 5 Block A', N'Noida sector 5 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (14, N'Noida sector 5 Block B', N'Noida sector 5 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (15, N'Noida sector 5 Block C', N'Noida sector 5 Block C')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (16, N'Noida sector 6 Block A', N'Noida sector 6 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (17, N'Noida sector 6 Block B', N'Noida sector 6 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (18, N'Noida sector 6 Block C', N'Noida sector 6 Block C')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (19, N'Noida sector 7 Block A', N'Noida sector 7 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (20, N'Noida sector 7 Block B', N'Noida sector 7 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (21, N'Noida sector 7 Block C', N'Noida sector 7 Block C')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (22, N'Noida sector 8 Block A', N'Noida sector 8 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (23, N'Noida sector 8 Block B', N'Noida sector 8 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (24, N'Noida sector 8 Block C', N'Noida sector 8 Block C')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (25, N'Noida sector 9 Block A', N'Noida sector 9 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (26, N'Noida sector 9 Block B', N'Noida sector 9 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (27, N'Noida sector 9 Block C', N'Noida sector 9 Block C')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (28, N'Noida sector 10 Block A', N'Noida sector 10 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (29, N'Noida sector 10 Block B', N'Noida sector 10 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (30, N'Noida sector 10 Block C', N'Noida sector 10 Block C')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (31, N'Noida sector 11 Block A', N'Noida sector 11 Block A')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (32, N'Noida sector 11 Block B', N'Noida sector 11 Block B')
GO
INSERT [dbo].[Location] ([Id], [Name], [Description]) VALUES (33, N'Noida sector 11 Block C', N'Noida sector 11 Block C')
GO
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Route] ON 
GO
INSERT [dbo].[Route] ([Id], [RouteNumber], [VehicleNo], [DriverID], [CrewID], [WorkerID], [locationId]) VALUES (1, N'RT101', N'DL-1B-A-5067', 1, 13, 7, NULL)
GO
INSERT [dbo].[Route] ([Id], [RouteNumber], [VehicleNo], [DriverID], [CrewID], [WorkerID], [locationId]) VALUES (3, N'RT102', N'DL-1B-A-5067', 2, 14, 8, NULL)
GO
SET IDENTITY_INSERT [dbo].[Route] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (1, N'Ram', NULL, N'123456789', 1)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (2, N'Ashok', NULL, N'9912890793', 1)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (3, N'Sundar', NULL, N'1289456973', 1)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (4, N'Anurag', NULL, N'9988686793', 1)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (5, N'Akash', NULL, N'9988686793', 1)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (6, N'Kishor', NULL, N'9988804793', 3)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (7, N'Mohit', NULL, N'9267888912', 3)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (8, N'Jatin', NULL, N'9985323793', 3)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (9, N'Abhishek', NULL, N'9981116793', 3)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (10, N'Roushan', NULL, N'9989999793', 3)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (11, N'Prakash', NULL, N'9986504793', 2)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (12, N'Ashish', NULL, N'9956880912', 2)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (13, N'Kishan', NULL, N'9268850912', 2)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (14, N'Rajat', NULL, N'9268850912', 2)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (15, N'Abhinav', NULL, N'9268909127', 2)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (22, N'Harshad Mehta', N'harshadmehta001@gmail.com', N'7404209751', 1)
GO
INSERT [dbo].[Staff] ([Id], [Name], [Email], [Phone], [StaffType]) VALUES (23, N'', N'', N'', 1)
GO
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[StaffType] ON 
GO
INSERT [dbo].[StaffType] ([Id], [TypeDescription]) VALUES (1, N'Driver')
GO
INSERT [dbo].[StaffType] ([Id], [TypeDescription]) VALUES (2, N'Crew')
GO
INSERT [dbo].[StaffType] ([Id], [TypeDescription]) VALUES (3, N'Worker')
GO
SET IDENTITY_INSERT [dbo].[StaffType] OFF
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'adas', CAST(N'2018-04-06T17:51:51.060' AS DateTime), N'165')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'DL-1B-A-506', CAST(N'2018-04-06T19:05:37.580' AS DateTime), N'jlajld')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'DL-1B-A-5060	', CAST(N'2018-04-07T20:56:21.227' AS DateTime), N'Truck')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'DL-1B-A-5067', CAST(N'2018-04-06T17:53:02.573' AS DateTime), N'Compactor')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'DL-1B-A-6899', CAST(N'2013-01-07T00:00:00.000' AS DateTime), N'Swaraj')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'DL-1B-A-9089', CAST(N'2001-05-09T00:00:00.000' AS DateTime), N'Swaraj')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'DL-1C-A-3980', CAST(N'2017-07-06T00:00:00.000' AS DateTime), N'Eicher')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'DL-1C-P-5655', CAST(N'2011-07-03T00:00:00.000' AS DateTime), N'Volvo')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'DL-1D-A-2112', CAST(N'2011-07-04T00:00:00.000' AS DateTime), N'Tata Motors')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'DL-1D-A-2900', CAST(N'2016-09-08T00:00:00.000' AS DateTime), N'Tata Motors')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'HR-1C-A-1640', CAST(N'2001-08-03T00:00:00.000' AS DateTime), N'Eicher')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'HR-1C-A-3468', CAST(N'2011-01-03T00:00:00.000' AS DateTime), N'Eicher')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'HR-1C-L-2618', CAST(N'2011-01-02T00:00:00.000' AS DateTime), N'Hindustan Motors')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'UK01', CAST(N'2018-04-06T17:30:54.177' AS DateTime), N'dsd')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'UP-1C-A-1298', CAST(N'2014-01-07T00:00:00.000' AS DateTime), N'Tata Motors')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'UP-1C-A-8888', CAST(N'2012-01-09T00:00:00.000' AS DateTime), N'Ashok Leyland')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'UP-1C-P-1118', CAST(N'2006-08-09T00:00:00.000' AS DateTime), N'Volvo')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'UP-1C-P-2344', CAST(N'2008-06-03T00:00:00.000' AS DateTime), N'Volvo')
GO
INSERT [dbo].[Vehicle] ([VehicleNo], [RegistrationDate], [Make]) VALUES (N'UP-5K-C-3457', CAST(N'2015-02-05T00:00:00.000' AS DateTime), N'Mahindra')
GO
/****** Object:  StoredProcedure [dbo].[usp_FetchDeploymentSheetByDate]    Script Date: 07-04-2018 21:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_FetchDeploymentSheetByDate]
@DeploymentDate DateTime
AS
SELECT DS.Id,RouteNumber=RT.RouteNumber,VehicleNo=RT.VehicleNo,StaffName=ST.Name,Email=ST.Email,Phone=ST.Phone,
		 Substitute=DS.Substitute,ST.StaffType,Designation=SFT.TypeDescription,DS.StaffId	
		 FROM [Route] RT
		 LEFT JOIN DeploymentSheet DS ON DS.RouteNumber=RT.RouteNumber AND DS.StaffType=1 AND CONVERT(DATE,DS.DeploymentDate)=CONVERT(DATE,@DeploymentDate)
		 LEFT JOIN Staff ST ON ST.Id=RT.DriverID 
		 LEFT JOIN StaffType SFT ON SFT.Id=ST.StaffType 
		 
UNION ALL
SELECT DS.Id,RouteNumber=RT.RouteNumber,VehicleNo=RT.VehicleNo,StaffName=ST.Name,Email=ST.Email,Phone=ST.Phone,
		 Substitute=DS.Substitute,ST.StaffType,Designation=SFT.TypeDescription,DS.StaffId		
		 FROM [Route] RT
		 LEFT JOIN DeploymentSheet DS ON DS.RouteNumber=RT.RouteNumber AND DS.StaffType=2 AND CONVERT(DATE,DS.DeploymentDate)=CONVERT(DATE,@DeploymentDate)
		 LEFT JOIN Staff ST ON ST.Id=RT.CrewID 
		 LEFT JOIN StaffType SFT ON SFT.Id=ST.StaffType 
UNION ALL
SELECT DS.Id,RouteNumber=RT.RouteNumber,VehicleNo=RT.VehicleNo,StaffName=ST.Name,Email=ST.Email,Phone=ST.Phone,
		 Substitute=DS.Substitute,ST.StaffType,Designation=SFT.TypeDescription,DS.StaffId		
		 FROM [Route] RT
		 LEFT JOIN DeploymentSheet DS ON DS.RouteNumber=RT.RouteNumber AND DS.StaffType=3 AND CONVERT(DATE,DS.DeploymentDate)=CONVERT(DATE,@DeploymentDate)
		 LEFT JOIN Staff ST ON ST.Id=RT.WorkerID 
		 LEFT JOIN StaffType SFT ON SFT.Id=ST.StaffType 
									


GO
/****** Object:  StoredProcedure [dbo].[usp_FetchStaffByRouteNo]    Script Date: 07-04-2018 21:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_FetchStaffByRouteNo]
@RouteNo VARCHAR(50),
@StaffType INT
AS
Select Value=ST.Id,[Text]=Name FROM Staff ST
JOIN [Route] R ON R.RouteNumber=@RouteNo 
AND ST.Id= CASE WHEN @StaffType=1 THEN R.DriverID 
				WHEN @StaffType=2 THEN R.CrewID 
				WHEN @StaffType=3 THEN R.WorkerID
				END 

GO
USE [master]
GO
ALTER DATABASE [Nasscom] SET  READ_WRITE 
GO
