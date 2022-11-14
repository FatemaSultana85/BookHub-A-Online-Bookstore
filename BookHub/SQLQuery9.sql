CREATE TABLE [dbo].[BookDetails]
(
	[BookID] INT IDENTITY(1,1) PRIMARY KEY,
	[BookName] NVARCHAR(50),
	[AuthorName] NVARCHAR(50),
	[BookCategory] NVARCHAR(50) NOT NULL,
	[BookPrice] INT NOT NULL,
	[BookImage] VARCHAR(MAX)
)