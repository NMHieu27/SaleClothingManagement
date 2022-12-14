USE [ClothingShop]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 13/09/2022 11:42:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[CustumerID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Created_date] [date] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Bill_1] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 13/09/2022 11:42:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[BillID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Total] [float] NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_BillDetail] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 13/09/2022 11:42:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[DiscountID] [int] NULL,
	[Description] [nvarchar](50) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 13/09/2022 11:42:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NULL,
	[Phone] [nvarchar](11) NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Dob] [date] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 13/09/2022 11:42:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[DiscountID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Value] [float] NOT NULL,
	[Created_date] [date] NULL,
	[From_date] [date] NULL,
	[To_date] [date] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 13/09/2022 11:42:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Dob] [date] NULL,
	[HireDate] [date] NULL,
	[Avatar] [nvarchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 13/09/2022 11:42:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [decimal](9, 3) NULL,
	[Remaining] [int] NULL,
	[CategoryID] [int] NOT NULL,
	[SupplierID] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 13/09/2022 11:42:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](11) NULL,
	[Country] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (14, 1, 3, CAST(N'2022-09-12' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (18, 2, 4, CAST(N'2022-09-11' AS Date), 0)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (19, 3, 3, CAST(N'2022-09-12' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (20, 1, 4, CAST(N'2022-09-12' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (21, 3, 5, CAST(N'2022-10-15' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (22, 2, 6, CAST(N'2022-10-18' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (23, 2, 9, CAST(N'2022-10-26' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (24, 1, 8, CAST(N'2022-08-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (25, 3, 3, CAST(N'2022-07-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (26, 3, 5, CAST(N'2022-06-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (27, 1, 6, CAST(N'2022-05-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (28, 2, 8, CAST(N'2022-11-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (29, 3, 9, CAST(N'2022-01-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (30, 1, 7, CAST(N'2022-01-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (31, 1, 1, CAST(N'2022-02-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (32, 3, 3, CAST(N'2022-03-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (33, 2, 6, CAST(N'2022-04-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (34, 3, 9, CAST(N'2022-04-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (35, 2, 5, CAST(N'2022-09-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (36, 3, 7, CAST(N'2022-12-16' AS Date), 1)
INSERT [dbo].[Bill] ([BillID], [CustumerID], [EmployeeID], [Created_date], [Active]) VALUES (37, 2, 7, NULL, 1)
SET IDENTITY_INSERT [dbo].[Bill] OFF
INSERT [dbo].[BillDetail] ([BillID], [ProductID], [Total], [Amount]) VALUES (14, 1, 100000, 1)
INSERT [dbo].[BillDetail] ([BillID], [ProductID], [Total], [Amount]) VALUES (18, 3, 150000, 2)
INSERT [dbo].[BillDetail] ([BillID], [ProductID], [Total], [Amount]) VALUES (19, 1, 1000000, 10)
INSERT [dbo].[BillDetail] ([BillID], [ProductID], [Total], [Amount]) VALUES (19, 4, 560000, 4)
INSERT [dbo].[BillDetail] ([BillID], [ProductID], [Total], [Amount]) VALUES (26, 4, 560000, 4)
INSERT [dbo].[BillDetail] ([BillID], [ProductID], [Total], [Amount]) VALUES (31, 2, 480000, 3)
INSERT [dbo].[BillDetail] ([BillID], [ProductID], [Total], [Amount]) VALUES (32, 3, 560000, 4)
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [Name], [DiscountID], [Description], [Active]) VALUES (1, N'Áo', 1, NULL, 1)
INSERT [dbo].[Category] ([CategoryID], [Name], [DiscountID], [Description], [Active]) VALUES (2, N'Quần', 1, N'', 1)
INSERT [dbo].[Category] ([CategoryID], [Name], [DiscountID], [Description], [Active]) VALUES (3, N'Váy', 3, NULL, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [Fullname], [Phone], [Address], [Email], [Dob], [Active]) VALUES (1, N'Lươn Hoàng Nam', N'0788869781', N'Q11', N'Namluong16@gmail.com', CAST(N'2022-11-01' AS Date), 1)
INSERT [dbo].[Customer] ([CustomerID], [Fullname], [Phone], [Address], [Email], [Dob], [Active]) VALUES (2, N'Nguyễn Hoàng Nam', N'0866924254', N'TP HCM', N'Nguyenhoangn023@gmail.com', CAST(N'2022-09-19' AS Date), 1)
INSERT [dbo].[Customer] ([CustomerID], [Fullname], [Phone], [Address], [Email], [Dob], [Active]) VALUES (3, N'Nguyễn Minh Hiếu', N'0368697700', N'Củ HCM', N'Minhhieu@gmail.com', CAST(N'2022-09-19' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Discount] ON 

INSERT [dbo].[Discount] ([DiscountID], [Name], [Value], [Created_date], [From_date], [To_date], [Active]) VALUES (1, N'Giảm 50%', 0.5, NULL, NULL, NULL, 1)
INSERT [dbo].[Discount] ([DiscountID], [Name], [Value], [Created_date], [From_date], [To_date], [Active]) VALUES (3, N'Giảm 15%', 0.15, NULL, NULL, NULL, 1)
INSERT [dbo].[Discount] ([DiscountID], [Name], [Value], [Created_date], [From_date], [To_date], [Active]) VALUES (4, N'Giảm 30%', 0.3, NULL, NULL, NULL, 1)
INSERT [dbo].[Discount] ([DiscountID], [Name], [Value], [Created_date], [From_date], [To_date], [Active]) VALUES (6, N'string', 0, CAST(N'2022-09-13' AS Date), CAST(N'2022-09-13' AS Date), CAST(N'2022-09-13' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Discount] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Dob], [HireDate], [Avatar], [Active]) VALUES (1, N'Linh', N'Bùi Mạnh', CAST(N'2001-03-08' AS Date), CAST(N'2001-03-08' AS Date), NULL, 0)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Dob], [HireDate], [Avatar], [Active]) VALUES (3, N'Hiếu', N'Nguyễn', CAST(N'2022-09-11' AS Date), CAST(N'2022-09-11' AS Date), N'string', 1)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Dob], [HireDate], [Avatar], [Active]) VALUES (4, N'Long', N'Nguyễn', CAST(N'2022-09-12' AS Date), CAST(N'2022-09-12' AS Date), N'string', 1)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Dob], [HireDate], [Avatar], [Active]) VALUES (5, N'My', N'Trần', CAST(N'2022-09-11' AS Date), CAST(N'2022-09-11' AS Date), N'string', 1)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Dob], [HireDate], [Avatar], [Active]) VALUES (6, N'Hạnh', N'Phạm', CAST(N'2022-09-11' AS Date), CAST(N'2022-09-11' AS Date), N'string', 1)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Dob], [HireDate], [Avatar], [Active]) VALUES (7, N'Cúc', N'Trịnh', CAST(N'2022-09-11' AS Date), CAST(N'2022-09-11' AS Date), N'string', 1)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Dob], [HireDate], [Avatar], [Active]) VALUES (8, N'Hoa', N'Nguyễn', CAST(N'2022-09-12' AS Date), CAST(N'2022-09-12' AS Date), N'string', 1)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Dob], [HireDate], [Avatar], [Active]) VALUES (9, N'Hoa', N'Trinh', CAST(N'2022-09-12' AS Date), CAST(N'2022-09-12' AS Date), N'string', 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [Name], [Price], [Remaining], [CategoryID], [SupplierID]) VALUES (1, N'Quần Jean', CAST(200000.000 AS Decimal(9, 3)), 15, 2, 1)
INSERT [dbo].[Product] ([ProductID], [Name], [Price], [Remaining], [CategoryID], [SupplierID]) VALUES (2, N'Váy màu tía tô họa tiết eo sà', CAST(250000.000 AS Decimal(9, 3)), 21, 3, 1)
INSERT [dbo].[Product] ([ProductID], [Name], [Price], [Remaining], [CategoryID], [SupplierID]) VALUES (3, N'Áo thun', CAST(150000.000 AS Decimal(9, 3)), 30, 1, 1)
INSERT [dbo].[Product] ([ProductID], [Name], [Price], [Remaining], [CategoryID], [SupplierID]) VALUES (4, N'Áo ba lỗ', CAST(280000.000 AS Decimal(9, 3)), 80, 1, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([SupplierID], [Name], [Phone], [Country], [Description]) VALUES (1, N'Supprime', N'0123456789', N'Việt Nam', NULL)
INSERT [dbo].[Supplier] ([SupplierID], [Name], [Phone], [Country], [Description]) VALUES (3, N'Hasfo', N'123456798', N'Việt Nam', NULL)
INSERT [dbo].[Supplier] ([SupplierID], [Name], [Phone], [Country], [Description]) VALUES (4, N'Dior', N'23456790', N'Nước ngoài', NULL)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
ALTER TABLE [dbo].[Bill] ADD  CONSTRAINT [DF_Bill_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Discount] ADD  CONSTRAINT [DF_Discount_Discount]  DEFAULT ((0)) FOR [Value]
GO
ALTER TABLE [dbo].[Discount] ADD  CONSTRAINT [DF_Discount_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Remaining]  DEFAULT ((0)) FOR [Remaining]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Customer] FOREIGN KEY([CustumerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Customer]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Employee]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_Bill] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([BillID])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_Bill]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_Product]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Discount] FOREIGN KEY([DiscountID])
REFERENCES [dbo].[Discount] ([DiscountID])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Discount]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([SupplierID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Supplier]
GO
