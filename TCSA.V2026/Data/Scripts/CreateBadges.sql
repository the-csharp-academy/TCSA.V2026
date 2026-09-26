-- Run against the application's SQL Server database before deploying the badge feature.
-- Existing tables/columns are left unchanged; this script can be run again.
SET XACT_ABORT ON;

BEGIN TRANSACTION;

IF OBJECT_ID(N'[dbo].[Badges]', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Badges]
    (
        [BadgeId] int NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        [DateAwarded] datetimeoffset(7) NOT NULL,
        [IsPendingNotification] bit NOT NULL,
        CONSTRAINT [PK_Badges] PRIMARY KEY ([BadgeId], [UserId]),
        CONSTRAINT [FK_Badges_AspNetUsers_UserId]
            FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
            ON DELETE CASCADE
    );
END;

IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE [object_id] = OBJECT_ID(N'[dbo].[Badges]')
      AND [name] = N'IX_Badges_UserId'
)
BEGIN
    CREATE INDEX [IX_Badges_UserId] ON [dbo].[Badges] ([UserId]);
END;

-- Existing users must remain eligible for the application's badge backfill.
IF COL_LENGTH(N'dbo.AspNetUsers', N'HasBackfilledBadges') IS NULL
BEGIN
    ALTER TABLE [dbo].[AspNetUsers]
        ADD [HasBackfilledBadges] bit NOT NULL
            CONSTRAINT [DF_AspNetUsers_HasBackfilledBadges] DEFAULT (0) WITH VALUES;
END;

COMMIT TRANSACTION;
