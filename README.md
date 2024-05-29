# Digital Library

## main feature: Book Lending and Returning

* Create a database schema that includes tables for Users, Books, and Loans.
* The Users table will store information about library members.
* The Books table will store information about all the books available in the library.
* The Loans table will store information about which books are currently loaned out to which users, and when they are due back.
* The API should allow for creating new users, adding new books, loaning books to users, returning books, and checking the current status of a book (available, loaned out, overdue).

## extended feature: Book Reservations

* This feature will require a schema migration to add a new table, Reservations.
* The Reservations table will store information about which books are reserved by which users, and in what order.
* Additionally, users should be able to see their position in the reservation queue for a particular book.

### initial database schema
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

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [ssn] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Loans] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [LoanDate] datetime2 NOT NULL,
    [DueDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Loans] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Loans_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Author] nvarchar(max) NOT NULL,
    [Genre] nvarchar(max) NOT NULL,
    [Year] int NOT NULL,
    [LoansId] int NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Books_Loans_LoansId] FOREIGN KEY ([LoansId]) REFERENCES [Loans] ([Id])
);
GO

CREATE INDEX [IX_Books_LoansId] ON [Books] ([LoansId]);
GO

CREATE INDEX [IX_Loans_UserId] ON [Loans] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240526094444_initial', N'8.0.5');
GO

COMMIT;
GO

### extended database schema