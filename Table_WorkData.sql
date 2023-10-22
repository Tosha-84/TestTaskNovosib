CREATE TABLE [dbo].[WorkDatas] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [City]         NVARCHAR (50) NOT NULL,
    [FactoryId]    INT           NOT NULL,
    [EmployeeId]   INT           NOT NULL,
    [Brigade]      BIT           NOT NULL,
    [WorkingShift] TINYINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([City]) REFERENCES [dbo].[Cities] ([City]),
    FOREIGN KEY ([FactoryId]) REFERENCES [dbo].[Factories] ([Id]),
    FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id])
);