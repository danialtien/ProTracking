USE [ProTracking]
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 10/28/2023 8:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[Index] [int] NOT NULL,
 CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChildTasks]    Script Date: 10/28/2023 8:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChildTasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TodoId] [int] NOT NULL,
	[CreatedBy] [int] NULL,
	[Title] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[Priority] [int] NULL,
 CONSTRAINT [PK_ChildTasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 10/28/2023 8:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TodoId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ReplyToId] [int] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/28/2023 8:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Birthday] [datetime2](7) NULL,
	[Avatar] [nvarchar](max) NULL,
	[RegisteredAt] [datetime2](7) NOT NULL,
	[LastLoginAt] [datetime2](7) NULL,
	[Status] [nvarchar](max) NULL,
	[Role] [int] NULL,
	[GoogleId] [nvarchar](max) NULL,
	[GoogleEmail] [nvarchar](max) NULL,
	[AccountTypeId] [int] NOT NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Labels]    Script Date: 10/28/2023 8:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_Labels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/28/2023 8:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[QRCode] [nvarchar](max) NULL,
	[AccessKey] [nvarchar](max) NULL,
	[PrivateKey] [nvarchar](max) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectParticipants]    Script Date: 10/28/2023 8:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectParticipants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[IsLeader] [bit] NOT NULL,
 CONSTRAINT [PK_ProjectParticipants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 10/28/2023 8:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[SubTitle] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Todos]    Script Date: 10/28/2023 8:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Todos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[LabelId] [int] NULL,
	[Title] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[ReportTo] [int] NOT NULL,
	[Assignee] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[IconPriority] [nvarchar](max) NULL,
 CONSTRAINT [PK_Todos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 10/28/2023 8:38:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AccountTypeId] [int] NOT NULL,
	[PaymentId] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[PaymentDate] [datetime2](7) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountTypes] ON 
GO
INSERT [dbo].[AccountTypes] ([Id], [Title], [Description], [Price], [Index]) VALUES (1, N'Free', N'Free account', 0, 0)
GO
INSERT [dbo].[AccountTypes] ([Id], [Title], [Description], [Price], [Index]) VALUES (2, N'Standard', N'Standard account', 20, 1)
GO
INSERT [dbo].[AccountTypes] ([Id], [Title], [Description], [Price], [Index]) VALUES (3, N'Premium', N'Premium account', 30, 2)
GO
INSERT [dbo].[AccountTypes] ([Id], [Title], [Description], [Price], [Index]) VALUES (4, N'Enterprise', N'Enterprise account', 40, 3)
GO
SET IDENTITY_INSERT [dbo].[AccountTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([Id], [Username], [FirstName], [LastName], [Email], [Password], [Phone], [Birthday], [Avatar], [RegisteredAt], [LastLoginAt], [Status], [Role], [GoogleId], [GoogleEmail], [AccountTypeId], [StartDate], [EndDate]) VALUES (1, N'khoa', N'Hoang', N'Khoa', N'khoa@gmail.com', N'1234', N'08888888', CAST(N'2023-10-28T08:31:32.9901460' AS DateTime2), NULL, CAST(N'2023-10-28T00:00:00.0000000' AS DateTime2), NULL, N'Active', 1, NULL, N'khoa@gmail.com', 1, NULL, NULL)
GO
INSERT [dbo].[Customers] ([Id], [Username], [FirstName], [LastName], [Email], [Password], [Phone], [Birthday], [Avatar], [RegisteredAt], [LastLoginAt], [Status], [Role], [GoogleId], [GoogleEmail], [AccountTypeId], [StartDate], [EndDate]) VALUES (2, N'khoa', N'Hoang', N'Hai', N'hai@gmail.com', N'1234', N'08888888', CAST(N'2023-10-28T08:31:32.9901475' AS DateTime2), NULL, CAST(N'2023-10-28T00:00:00.0000000' AS DateTime2), NULL, N'Active', 1, NULL, N'hai@gmail.com', 1, NULL, NULL)
GO
INSERT [dbo].[Customers] ([Id], [Username], [FirstName], [LastName], [Email], [Password], [Phone], [Birthday], [Avatar], [RegisteredAt], [LastLoginAt], [Status], [Role], [GoogleId], [GoogleEmail], [AccountTypeId], [StartDate], [EndDate]) VALUES (3, N'customer', NULL, NULL, N'customer@gmail.com', N'P@ssw0rd', N'1234', NULL, NULL, CAST(N'2023-10-28T08:35:55.2129745' AS DateTime2), NULL, N'Active', 0, NULL, NULL, 1, CAST(N'2023-10-28T08:35:55.2129765' AS DateTime2), CAST(N'2024-01-28T08:35:55.2129766' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Labels] ON 
GO
INSERT [dbo].[Labels] ([Id], [ProjectId], [Title]) VALUES (1, 1, N'Frontend')
GO
INSERT [dbo].[Labels] ([Id], [ProjectId], [Title]) VALUES (2, 1, N'Backend')
GO
INSERT [dbo].[Labels] ([Id], [ProjectId], [Title]) VALUES (3, 1, N'AI')
GO
INSERT [dbo].[Labels] ([Id], [ProjectId], [Title]) VALUES (4, 1, N'Marketing')
GO
SET IDENTITY_INSERT [dbo].[Labels] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 
GO
INSERT [dbo].[Payments] ([Id], [Title], [QRCode], [AccessKey], [PrivateKey]) VALUES (1, N'Free', N'Free', N'Free', N'Free')
GO
INSERT [dbo].[Payments] ([Id], [Title], [QRCode], [AccessKey], [PrivateKey]) VALUES (2, N'ZaloPay', N'dfsdalfdfa', N'AceessKey', N'Privatekey')
GO
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectParticipants] ON 
GO
INSERT [dbo].[ProjectParticipants] ([Id], [ProjectId], [CustomerId], [IsLeader]) VALUES (1, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[ProjectParticipants] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 
GO
INSERT [dbo].[Projects] ([Id], [Title], [SubTitle], [Description], [Status], [CreatedBy]) VALUES (1, N'ProTracking EXE201', N'ProTracking make your work easier', N'A startup project helping user to manage projects', N'Active', 1)
GO
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[Todos] ON 
GO
INSERT [dbo].[Todos] ([Id], [ProjectId], [LabelId], [Title], [Status], [StartDate], [EndDate], [ReportTo], [Assignee], [CreatedBy], [Priority], [IconPriority]) VALUES (1, 1, 1, N'Design UI/UX for application', N'In Progress', CAST(N'2023-10-28T08:31:32.9901524' AS DateTime2), CAST(N'2023-11-04T08:31:32.9901524' AS DateTime2), 0, 1, 1, 5, N'')
GO
INSERT [dbo].[Todos] ([Id], [ProjectId], [LabelId], [Title], [Status], [StartDate], [EndDate], [ReportTo], [Assignee], [CreatedBy], [Priority], [IconPriority]) VALUES (2, 1, 2, N'Builtd API for application', N'Todo', CAST(N'2023-10-28T08:31:32.9901529' AS DateTime2), CAST(N'2023-11-04T08:31:32.9901530' AS DateTime2), 0, 1, 1, 5, N'')
GO
INSERT [dbo].[Todos] ([Id], [ProjectId], [LabelId], [Title], [Status], [StartDate], [EndDate], [ReportTo], [Assignee], [CreatedBy], [Priority], [IconPriority]) VALUES (3, 1, 3, N'Integrated Chatbox to application', N'In Progress', CAST(N'2023-10-28T08:31:32.9901531' AS DateTime2), CAST(N'2023-11-04T08:31:32.9901531' AS DateTime2), 0, 1, 1, 5, N'')
GO
SET IDENTITY_INSERT [dbo].[Todos] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionHistory] ON 
GO
INSERT [dbo].[TransactionHistory] ([Id], [CustomerId], [AccountTypeId], [PaymentId], [Content], [PaymentDate], [StartDate], [EndDate], [IsActive], [Amount]) VALUES (1, 1, 1, 1, NULL, CAST(N'2023-10-28T08:31:32.9904864' AS DateTime2), CAST(N'2023-10-28T08:31:32.9904867' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 0)
GO
SET IDENTITY_INSERT [dbo].[TransactionHistory] OFF
GO
ALTER TABLE [dbo].[ChildTasks]  WITH CHECK ADD  CONSTRAINT [FK_ChildTasks_Todos_TodoId] FOREIGN KEY([TodoId])
REFERENCES [dbo].[Todos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChildTasks] CHECK CONSTRAINT [FK_ChildTasks_Todos_TodoId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Comments_ReplyToId] FOREIGN KEY([ReplyToId])
REFERENCES [dbo].[Comments] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Comments_ReplyToId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Todos_TodoId] FOREIGN KEY([TodoId])
REFERENCES [dbo].[Todos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Todos_TodoId]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_AccountTypes_AccountTypeId] FOREIGN KEY([AccountTypeId])
REFERENCES [dbo].[AccountTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_AccountTypes_AccountTypeId]
GO
ALTER TABLE [dbo].[Labels]  WITH CHECK ADD  CONSTRAINT [FK_Labels_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Labels] CHECK CONSTRAINT [FK_Labels_Projects_ProjectId]
GO
ALTER TABLE [dbo].[ProjectParticipants]  WITH CHECK ADD  CONSTRAINT [FK_ProjectParticipants_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectParticipants] CHECK CONSTRAINT [FK_ProjectParticipants_Customers_CustomerId]
GO
ALTER TABLE [dbo].[ProjectParticipants]  WITH CHECK ADD  CONSTRAINT [FK_ProjectParticipants_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectParticipants] CHECK CONSTRAINT [FK_ProjectParticipants_Projects_ProjectId]
GO
ALTER TABLE [dbo].[Todos]  WITH CHECK ADD  CONSTRAINT [FK_Todos_Customers_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Todos] CHECK CONSTRAINT [FK_Todos_Customers_CreatedBy]
GO
ALTER TABLE [dbo].[Todos]  WITH CHECK ADD  CONSTRAINT [FK_Todos_Labels_LabelId] FOREIGN KEY([LabelId])
REFERENCES [dbo].[Labels] ([Id])
GO
ALTER TABLE [dbo].[Todos] CHECK CONSTRAINT [FK_Todos_Labels_LabelId]
GO
ALTER TABLE [dbo].[Todos]  WITH CHECK ADD  CONSTRAINT [FK_Todos_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Todos] CHECK CONSTRAINT [FK_Todos_Projects_ProjectId]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistory_AccountTypes_AccountTypeId] FOREIGN KEY([AccountTypeId])
REFERENCES [dbo].[AccountTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK_TransactionHistory_AccountTypes_AccountTypeId]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistory_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK_TransactionHistory_Customers_CustomerId]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistory_Payments_PaymentId] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK_TransactionHistory_Payments_PaymentId]
GO
