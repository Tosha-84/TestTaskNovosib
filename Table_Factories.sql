CREATE TABLE [dbo].[Factories] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Type] NVARCHAR (50) NULL,
    [City] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([City]) REFERENCES [dbo].[Cities] ([City])
);
