CREATE TABLE [dbo].[Orders] (
    [id]         INT      IDENTITY (1, 1) NOT NULL,
    [customerId] INT      NOT NULL,
    [productId]  INT      NOT NULL,
    [dateTime]   DATETIME NOT NULL,
    [quantity]   INT      NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Customer_Orders] FOREIGN KEY ([customerId]) REFERENCES [dbo].[Customer] ([id]),
    CONSTRAINT [FK_Products_Orders] FOREIGN KEY ([productId]) REFERENCES [dbo].[Products] ([id])
);

