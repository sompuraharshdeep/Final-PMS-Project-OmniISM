USE [master]
GO
/****** Object:  Database [Project Management System]    Script Date: 24-09-2019 14:25:05 ******/
CREATE DATABASE [Project Management System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Project Management System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Project Management System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Project Management System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Project Management System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Project Management System] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Project Management System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Project Management System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Project Management System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Project Management System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Project Management System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Project Management System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Project Management System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Project Management System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Project Management System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Project Management System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Project Management System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Project Management System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Project Management System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Project Management System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Project Management System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Project Management System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Project Management System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Project Management System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Project Management System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Project Management System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Project Management System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Project Management System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Project Management System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Project Management System] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Project Management System] SET  MULTI_USER 
GO
ALTER DATABASE [Project Management System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Project Management System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Project Management System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Project Management System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Project Management System] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Project Management System] SET QUERY_STORE = OFF
GO
USE [Project Management System]
GO
/****** Object:  Table [dbo].[tbl_Designation]    Script Date: 24-09-2019 14:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Designation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[departmentname] [varchar](50) NULL,
	[designation] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ManageProjects]    Script Date: 24-09-2019 14:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ManageProjects](
	[projectid] [int] IDENTITY(1,1) NOT NULL,
	[projectname] [varchar](100) NULL,
	[description] [varchar](max) NULL,
	[startdate] [date] NULL,
	[enddate] [date] NULL,
	[documentupload] [varchar](max) NULL,
	[estimatedhours] [int] NULL,
	[actualhours] [int] NULL,
	[projectstatus] [varchar](50) NULL,
	[activitystatus] [bit] NULL,
	[createdby] [varchar](50) NULL,
	[createddate] [date] NULL,
	[modifiedby] [varchar](50) NULL,
	[modifieddate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[projectid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ManageTask]    Script Date: 24-09-2019 14:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ManageTask](
	[taskid] [int] IDENTITY(1,1) NOT NULL,
	[taskname] [varchar](100) NULL,
	[description] [varchar](max) NULL,
	[startdate] [date] NULL,
	[enddate] [date] NULL,
	[estimatedhours] [int] NULL,
	[taskstatus] [varchar](50) NULL,
	[createdby] [varchar](50) NULL,
	[createddate] [date] NULL,
	[modifiedby] [varchar](50) NULL,
	[modifieddate] [date] NULL,
	[FKuserid] [int] NULL,
	[FKprojectid] [int] NULL,
	[FKdesignationid] [int] NULL,
	[TaskCount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[taskid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ManageUsers]    Script Date: 24-09-2019 14:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ManageUsers](
	[userid] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](20) NULL,
	[role] [varchar](20) NULL,
	[designation] [varchar](50) NULL,
	[emailid] [varchar](50) NULL,
	[activitystatus] [varchar](20) NULL,
	[createdby] [varchar](50) NULL,
	[createddate] [date] NULL,
	[modifiedby] [varchar](50) NULL,
	[modifieddate] [date] NULL,
	[FKdesignationid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SuperAdminLogin]    Script Date: 24-09-2019 14:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SuperAdminLogin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[useremail] [varchar](50) NULL,
	[password] [varchar](20) NULL,
	[ResetPassword] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TaskSummary]    Script Date: 24-09-2019 14:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TaskSummary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKtimesheetid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TimeSheet]    Script Date: 24-09-2019 14:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TimeSheet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKprojectid] [int] NULL,
	[FKtaskid] [int] NULL,
	[FKuserid] [int] NULL,
	[startdate] [date] NULL,
	[enddate] [date] NULL,
	[actualhours] [int] NULL,
	[comments] [varchar](max) NULL,
	[createdby] [varchar](50) NULL,
	[createddate] [date] NULL,
	[modifiedby] [varchar](50) NULL,
	[modifieddate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Designation] ON 

INSERT [dbo].[tbl_Designation] ([id], [departmentname], [designation]) VALUES (1, N'IT', N'Developer')
SET IDENTITY_INSERT [dbo].[tbl_Designation] OFF
SET IDENTITY_INSERT [dbo].[tbl_ManageProjects] ON 

INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (2, N'abc', N'abcdefghi', CAST(N'2019-01-01' AS Date), CAST(N'2019-01-02' AS Date), N'System.Web.HttpPostedFileWrapper', 2, 1, N'complete', 1, N'abc', CAST(N'2019-01-01' AS Date), N'abc', CAST(N'2019-01-01' AS Date))
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (3, N'PMS', N'It is used for Company.', CAST(N'2019-01-01' AS Date), CAST(N'2019-03-01' AS Date), N'System.Web.HttpPostedFileWrapper', 5, 4, N'In Progress', 0, N'Harsh', CAST(N'2019-01-01' AS Date), N'Harsh', CAST(N'2019-01-01' AS Date))
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (7, NULL, NULL, NULL, NULL, N'System.Web.HttpPostedFileWrapper', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (8, N'managment', N'hotel managment', CAST(N'2017-12-08' AS Date), CAST(N'2018-09-09' AS Date), N'System.Web.HttpPostedFileWrapper', 78, 88, N'1', 1, N'yash', CAST(N'2018-09-09' AS Date), N'9/9/18', CAST(N'2018-09-09' AS Date))
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (9, N'managment', N'hospital managment', CAST(N'2017-12-08' AS Date), CAST(N'2017-12-08' AS Date), N'System.Web.HttpPostedFileWrapper', 78, 88, N'Completed', 1, N'8/12/17', CAST(N'2017-12-08' AS Date), N'8/12/17', CAST(N'2017-12-08' AS Date))
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (10, N'medical', N'hospital', CAST(N'2019-12-09' AS Date), CAST(N'2019-12-09' AS Date), N'System.Web.HttpPostedFileWrapper', 99, 90, N'In Progess', NULL, N'yash', CAST(N'2019-12-09' AS Date), N'yyash', CAST(N'2019-12-09' AS Date))
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (11, NULL, NULL, NULL, NULL, N'download (2).jpg', NULL, NULL, N'Not Started', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (12, NULL, NULL, NULL, NULL, N'images.jpg,Profileimg.jpg,Story.xlsx', NULL, NULL, N'Not Started', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (13, N'Medical Store', N'Used for Doctor,admin.', CAST(N'2019-05-23' AS Date), CAST(N'2019-09-23' AS Date), N'Class Room Exercise-2.docx,download (1).jpg,flowers.jpg,Ganesh.jpg,images (1).jpg', 10, 15, N'Completed', 1, N'Harsh', CAST(N'2019-05-23' AS Date), N'yash', CAST(N'2019-06-10' AS Date))
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (14, N'Job Portal', N'Used for job Seeker', CAST(N'2019-05-25' AS Date), CAST(N'2019-12-28' AS Date), N'image.jpg', 23, 33, N'inProgress', 1, N'Arthy', CAST(N'2019-05-23' AS Date), N'Harsh', CAST(N'2019-06-10' AS Date))
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (15, NULL, NULL, CAST(N'2019-09-05' AS Date), NULL, N'download.jpg', NULL, NULL, N'Not Started', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (16, NULL, NULL, CAST(N'2019-09-04' AS Date), CAST(N'2019-09-11' AS Date), N'flowers.jpg', NULL, NULL, N'Not Started', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (17, N'Transport Company', N'used for Transportation', CAST(N'2019-06-05' AS Date), CAST(N'2019-07-10' AS Date), N'Bike.jpg', 5, 10, N'In Progess', 1, N'', CAST(N'2019-09-23' AS Date), NULL, NULL)
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (18, N'fvdf', N'vxcvx', CAST(N'2019-09-05' AS Date), CAST(N'2019-09-05' AS Date), N'flowers.jpg', 545, 33, N'Completed', 0, N'', CAST(N'2019-09-23' AS Date), NULL, NULL)
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (19, NULL, NULL, CAST(N'2019-09-06' AS Date), CAST(N'2019-09-27' AS Date), N'ball1.jpg', NULL, NULL, N'In Progess', 0, NULL, NULL, N'admin@gmail.com', CAST(N'2019-09-23' AS Date))
INSERT [dbo].[tbl_ManageProjects] ([projectid], [projectname], [description], [startdate], [enddate], [documentupload], [estimatedhours], [actualhours], [projectstatus], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (20, N'Safari ', N'It is making for Searching service or browser.', CAST(N'2019-09-03' AS Date), CAST(N'2019-09-27' AS Date), N'images (1).png', 10, 9, N'In Progess', 1, N'', CAST(N'2019-09-24' AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_ManageProjects] OFF
SET IDENTITY_INSERT [dbo].[tbl_ManageTask] ON 

INSERT [dbo].[tbl_ManageTask] ([taskid], [taskname], [description], [startdate], [enddate], [estimatedhours], [taskstatus], [createdby], [createddate], [modifiedby], [modifieddate], [FKuserid], [FKprojectid], [FKdesignationid], [TaskCount]) VALUES (1, N'Generate Report', N'Madical Report', CAST(N'2019-09-01' AS Date), CAST(N'2019-09-05' AS Date), 10, N'complate', N'yash', CAST(N'2019-09-01' AS Date), N'harsh', CAST(N'2019-09-03' AS Date), 2, 13, 1, 20)
INSERT [dbo].[tbl_ManageTask] ([taskid], [taskname], [description], [startdate], [enddate], [estimatedhours], [taskstatus], [createdby], [createddate], [modifiedby], [modifieddate], [FKuserid], [FKprojectid], [FKdesignationid], [TaskCount]) VALUES (2, N'ApplyJobs', N'Job Forms', CAST(N'2019-09-01' AS Date), CAST(N'2019-09-01' AS Date), 33, N'completed', N'Arthy', CAST(N'2019-09-01' AS Date), N'Yash', CAST(N'2019-09-01' AS Date), 2, 14, 1, 25)
INSERT [dbo].[tbl_ManageTask] ([taskid], [taskname], [description], [startdate], [enddate], [estimatedhours], [taskstatus], [createdby], [createddate], [modifiedby], [modifieddate], [FKuserid], [FKprojectid], [FKdesignationid], [TaskCount]) VALUES (3, N'Login Page', N'Make a User Login Page.', CAST(N'2019-09-25' AS Date), CAST(N'2019-09-27' AS Date), 2, N'Not Started', NULL, CAST(N'2019-09-23' AS Date), NULL, NULL, NULL, 13, 1, 1)
SET IDENTITY_INSERT [dbo].[tbl_ManageTask] OFF
SET IDENTITY_INSERT [dbo].[tbl_ManageUsers] ON 

INSERT [dbo].[tbl_ManageUsers] ([userid], [username], [password], [role], [designation], [emailid], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate], [FKdesignationid]) VALUES (2, N'admin@gmail.com', N'123', N'user', NULL, N'admin@gmail.com', N'In Progress', N'', CAST(N'2019-09-23' AS Date), N'harsh', CAST(N'2019-09-05' AS Date), 1)
INSERT [dbo].[tbl_ManageUsers] ([userid], [username], [password], [role], [designation], [emailid], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate], [FKdesignationid]) VALUES (3, N'harsh@gmail.com', N'555', N'user', NULL, N'harsh@gmail.com', N'In Progress', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tbl_ManageUsers] ([userid], [username], [password], [role], [designation], [emailid], [activitystatus], [createdby], [createddate], [modifiedby], [modifieddate], [FKdesignationid]) VALUES (4, N'yash', N'123', N'user', NULL, N'yash@gmail.com', N'Active', N'', CAST(N'2019-09-24' AS Date), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[tbl_ManageUsers] OFF
SET IDENTITY_INSERT [dbo].[tbl_SuperAdminLogin] ON 

INSERT [dbo].[tbl_SuperAdminLogin] ([id], [useremail], [password], [ResetPassword]) VALUES (1, N'admin@gmail.com', N'123', NULL)
SET IDENTITY_INSERT [dbo].[tbl_SuperAdminLogin] OFF
SET IDENTITY_INSERT [dbo].[tbl_TimeSheet] ON 

INSERT [dbo].[tbl_TimeSheet] ([id], [FKprojectid], [FKtaskid], [FKuserid], [startdate], [enddate], [actualhours], [comments], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (1, 13, 1, 1, CAST(N'2019-09-01' AS Date), CAST(N'2019-09-05' AS Date), 5, N'complete', N'harsh', CAST(N'2019-09-01' AS Date), N'yash', CAST(N'2019-09-04' AS Date))
INSERT [dbo].[tbl_TimeSheet] ([id], [FKprojectid], [FKtaskid], [FKuserid], [startdate], [enddate], [actualhours], [comments], [createdby], [createddate], [modifiedby], [modifieddate]) VALUES (2, 14, 2, 1, CAST(N'2019-09-01' AS Date), CAST(N'2019-09-01' AS Date), 33, N'done', N'harsh', CAST(N'2019-09-01' AS Date), N'arthy', CAST(N'2019-09-01' AS Date))
SET IDENTITY_INSERT [dbo].[tbl_TimeSheet] OFF
ALTER TABLE [dbo].[tbl_ManageTask]  WITH CHECK ADD FOREIGN KEY([FKdesignationid])
REFERENCES [dbo].[tbl_Designation] ([id])
GO
ALTER TABLE [dbo].[tbl_ManageTask]  WITH CHECK ADD FOREIGN KEY([FKprojectid])
REFERENCES [dbo].[tbl_ManageProjects] ([projectid])
GO
ALTER TABLE [dbo].[tbl_ManageTask]  WITH NOCHECK ADD FOREIGN KEY([FKuserid])
REFERENCES [dbo].[tbl_ManageUsers] ([userid])
GO
ALTER TABLE [dbo].[tbl_ManageUsers]  WITH CHECK ADD FOREIGN KEY([FKdesignationid])
REFERENCES [dbo].[tbl_Designation] ([id])
GO
ALTER TABLE [dbo].[tbl_TaskSummary]  WITH CHECK ADD FOREIGN KEY([FKtimesheetid])
REFERENCES [dbo].[tbl_TimeSheet] ([id])
GO
ALTER TABLE [dbo].[tbl_TimeSheet]  WITH CHECK ADD FOREIGN KEY([FKprojectid])
REFERENCES [dbo].[tbl_ManageProjects] ([projectid])
GO
ALTER TABLE [dbo].[tbl_TimeSheet]  WITH CHECK ADD FOREIGN KEY([FKtaskid])
REFERENCES [dbo].[tbl_ManageTask] ([taskid])
GO
USE [master]
GO
ALTER DATABASE [Project Management System] SET  READ_WRITE 
GO
