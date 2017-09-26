CREATE TABLE [dbo].[Table]
(
	[PageID] INT NOT NULL, 
    [PageName] VARCHAR(70) NULL, 
    [PageURL] VARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([PageID]) 
)
