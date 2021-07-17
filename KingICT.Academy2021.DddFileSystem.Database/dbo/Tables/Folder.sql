CREATE TABLE [dbo].[Folder] (
    [Id]		INT				IDENTITY (1, 1) NOT NULL,
    [Name]		NVARCHAR (100)	NOT NULL,
    [ParentId]	INT	            NULL,
    CONSTRAINT [PK_Folder] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Folder_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Folder] ([Id]),
);
