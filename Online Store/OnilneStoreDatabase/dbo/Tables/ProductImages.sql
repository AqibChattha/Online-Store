CREATE TABLE [dbo].[ProductImages] (
    [id]            INT             IDENTITY (1, 1) NOT NULL,
    [productId]     INT             NOT NULL,
    [image]         VARBINARY (MAX) NOT NULL,
    [previewImage1] VARBINARY (MAX) NULL,
    [previewImage2] VARBINARY (MAX) NULL,
    [previewImage3] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_ProductImages_Products] FOREIGN KEY ([productId]) REFERENCES [dbo].[Products] ([id])
);

