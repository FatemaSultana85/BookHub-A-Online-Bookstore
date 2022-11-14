CREATE TABLE [dbo].[Users]
(
	[UserID] INT IDENTITY(1,1) PRIMARY KEY,
	[UserFirstName] NVARCHAR(50) NOT NULL,
	[UserLastName] NVARCHAR(50) NOT NULL,
	[UserEmail] NVARCHAR(50) NOT NULL,
	[UserPassword] NVARCHAR(50) NOT NULL,
	[UserAddress] NVARCHAR(MAX),
	[UserPhoneNo] NVARCHAR(25),
)

CREATE TABLE [dbo].[Feedbacks]
(
	[FeedbackID] INT IDENTITY(1,1) PRIMARY KEY,
	[UserID] INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
	[FeedbackMessage] NVARCHAR(MAX)
)

CREATE TABLE [dbo].[Authors]
(
	[AuthorID] INT IDENTITY(1,1) PRIMARY KEY,
	[AuthorFirstName] NVARCHAR(50) NOT NULL,
	[AuthorLastName] NVARCHAR(50) NOT NULL,
	[AuthorCountry] NVARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Books]
(
	[BookID] INT IDENTITY(1,1) PRIMARY KEY,
	[BookName] NVARCHAR(50),
	[AuthorID] INT NOT NULL FOREIGN KEY REFERENCES Authors(AuthorID),
	[BookCategory] NVARCHAR(50) NOT NULL,
	[BookPrice] INT NOT NULL,
	[BookImage] VARBINARY(MAX)
)

CREATE TABLE [dbo].[Administrators]
(
	[AdminID] INT IDENTITY(1,1) PRIMARY KEY,
	[AdminFirstName] NVARCHAR(50) NOT NULL,
	[AdminLastName] NVARCHAR(50) NOT NULL,
	[AdminAddress] NVARCHAR(50) NOT NULL,
	[AdminEmail] NVARCHAR(50) NOT NULL,
	[AdminPassword] NVARCHAR(50) NOT NULL,
	[AdminPhoneNo] NVARCHAR(20) NOT NULL
)

CREATE TABLE [dbo].[Payments]
(
	[PaymentID] INT IDENTITY(1,1) PRIMARY KEY,
	[UserID] INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
	[OrderID] INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
	[PaymentTime] datetime NOT NULL,
	[PaymentMethod] NVARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Orders]
(
	[OrderID] INT IDENTITY(1,1) PRIMARY KEY,
	[UserID] INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
	[BookID] INT NOT NULL FOREIGN KEY REFERENCES Books(BookID),
	[OrderDate] datetime NOT NULL,
	[ShipDate] datetime NOT NULL,
)

