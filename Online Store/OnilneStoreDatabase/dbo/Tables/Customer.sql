CREATE TABLE [dbo].[Customer] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [firstName]     NVARCHAR (50)  NOT NULL,
    [lastName]      NVARCHAR (50)  NULL,
    [telephone]     NVARCHAR (15)  NOT NULL,
    [address]       NVARCHAR (300) NULL,
    [creditCardNum] NVARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([creditCardNum] ASC),
    UNIQUE NONCLUSTERED ([telephone] ASC)
);

