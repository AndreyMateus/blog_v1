IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] VARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Role] (
    [Id] int NOT NULL IDENTITY,
    [Name] VARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Tag] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(40) NOT NULL,
    [Slug] NVARCHAR(40) NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    [Email] VARCHAR(240) NOT NULL,
    [Password] NVARCHAR(60) NOT NULL,
    [Bio] NVARCHAR(255) NOT NULL,
    [ImageUrl] NVARCHAR(240) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [Title] VARCHAR(160) NOT NULL,
    [Summary] VARCHAR(255) NOT NULL,
    [Body] NVARCHAR(255) NOT NULL,
    [Slug] NVARCHAR(450) NOT NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT (GETDATE()),
    [LastUpdateDate] SMALLDATETIME NOT NULL,
    [PostId] int NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CategoryPost_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PostCategory_PostId] FOREIGN KEY ([PostId]) REFERENCES [Category] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserPost_UserId] FOREIGN KEY ([Id]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [RoleUser] (
    [RoleId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_RoleUser] PRIMARY KEY ([RoleId], [UserId]),
    CONSTRAINT [FK_RoleUser_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_UserId] FOREIGN KEY ([UserId]) REFERENCES [Role] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [TagPost] (
    [PostId] int NOT NULL,
    [TagId] int NOT NULL,
    CONSTRAINT [PK_TagPost] PRIMARY KEY ([PostId], [TagId]),
    CONSTRAINT [FK_PostTag_PostId] FOREIGN KEY ([PostId]) REFERENCES [Tag] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TagPost_TagId] FOREIGN KEY ([TagId]) REFERENCES [Post] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Post_CategoryId] ON [Post] ([CategoryId]);
GO

CREATE INDEX [IX_Post_PostId] ON [Post] ([PostId]);
GO

CREATE INDEX [IX_RoleUser_UserId] ON [RoleUser] ([UserId]);
GO

CREATE INDEX [IX_TagPost_TagId] ON [TagPost] ([TagId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230726053104_CriacaoBanco', N'6.0.20');
GO

COMMIT;
GO

