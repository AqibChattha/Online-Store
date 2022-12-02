CREATE TABLE [dbo].[Products] (
    [id]            INT             IDENTITY (1, 1) NOT NULL,
    [description]   NVARCHAR (500)  NULL,
    [model/brand]   NVARCHAR (50)   NULL,
    [stockQuantity] INT             NULL,
    [soldQuantity]  INT             NULL,
    [price]         DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([id] ASC)
);

