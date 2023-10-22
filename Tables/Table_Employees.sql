CREATE TABLE [dbo].[Employees] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Surname]     NVARCHAR (50) NOT NULL,
    [FathersName] NVARCHAR (50) NOT NULL,
    [FactoryId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FactoryId]) REFERENCES [dbo].[Factories] ([Id])
);