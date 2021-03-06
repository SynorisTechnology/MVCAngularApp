USE [Apitest]
GO
/****** Object:  FullTextCatalog [testcat]    Script Date: 31-Oct-15 9:36:33 PM ******/
CREATE FULLTEXT CATALOG [testcat]WITH ACCENT_SENSITIVITY = ON

GO
/****** Object:  FullTextCatalog [testcat2]    Script Date: 31-Oct-15 9:36:33 PM ******/
CREATE FULLTEXT CATALOG [testcat2]WITH ACCENT_SENSITIVITY = ON

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 31-Oct-15 9:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Address] [nvarchar](256) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MyOrder]    Script Date: 31-Oct-15 9:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyOrder](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [nvarchar](50) NULL,
	[OrderDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[CustomerID] [int] NULL,
	[PaymentInfo] [nvarchar](50) NULL,
	[PaymentMethod] [nvarchar](50) NULL,
	[TaxAmount] [money] NULL,
	[DeliveryMethod] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[EmailID] [nvarchar](50) NULL,
	[DeliveryAddress] [nvarchar](256) NULL,
	[DeliveryAddress2] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[TotalAmount] [money] NULL,
 CONSTRAINT [PK_MyOrders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orderitem]    Script Date: 31-Oct-15 9:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orderitem](
	[OrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ItemName] [nvarchar](50) NULL,
	[ItemCode] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[Price] [money] NULL,
	[Discount] [money] NULL,
	[CouponCode] [money] NULL,
	[TaxAmount] [money] NULL,
 CONSTRAINT [PK_Orderitem] PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MyOrder]  WITH CHECK ADD  CONSTRAINT [FK_MyOrder_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[MyOrder] CHECK CONSTRAINT [FK_MyOrder_Customer]
GO
ALTER TABLE [dbo].[Orderitem]  WITH CHECK ADD  CONSTRAINT [FK_Orderitem_MyOrder] FOREIGN KEY([OrderID])
REFERENCES [dbo].[MyOrder] ([OrderID])
GO
ALTER TABLE [dbo].[Orderitem] CHECK CONSTRAINT [FK_Orderitem_MyOrder]
GO
/****** Object:  StoredProcedure [dbo].[SpSearchCustomer]    Script Date: 31-Oct-15 9:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpSearchCustomer]
(
  @CustomerName nvarchar(256),
  @Address nvarchar(256)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
  select c.Address,c.Country,c.CustomerID,c.Email,c.FullName,c.Mobile,c.State,c.ZipCode,o.ContactNo,o.DeliveryAddress,o.DeliveryAddress2,o.DeliveryMethod,o.EmailID,o.OrderDate,o.InvoiceNo,o.OrderID,o.PaymentInfo,o.PaymentMethod,o.State as State2,o.Status,o.TaxAmount,o.ZipCode zipcode2,o.TotalAmount from Customer c inner join MyOrder o on c.CustomerID = o.CustomerID where  freetext(c.FullName, @CustomerName) or freetext(c.Address, @Address)

END

GO
