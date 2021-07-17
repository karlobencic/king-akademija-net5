CREATE TABLE [dbo].[File] (
    [Id]		INT				IDENTITY (1, 1) NOT NULL,
    [Name]		NVARCHAR (100)	NOT NULL,
    [FolderId]	INT	            NOT NULL,
    CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_File_FolderId] FOREIGN KEY ([FolderId]) REFERENCES [dbo].[Folder] ([Id]),
);
