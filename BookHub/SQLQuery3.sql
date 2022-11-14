﻿CREATE TABLE [dbo].[ContactUs]
(
	[ContactID] INT IDENTITY(1,1) PRIMARY KEY,
	[UserName] VARCHAR(50) NOT NULL,
	[UserEmail] VARCHAR(50) NOT NULL,
	[Subject] VARCHAR(100) NOT NULL,
	[Message] VARCHAR(MAX)
)