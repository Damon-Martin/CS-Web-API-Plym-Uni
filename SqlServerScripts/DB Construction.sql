/*
    Task: Excercise 3 SQL
    StudentID: 10729705
*/
/************ CREATE TABLES ***********/

CREATE SCHEMA CW2;

CREATE TABLE [CW2].[Author] (
    trailID INT IDENTITY(1,1), 
    author VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY (trailID)
);

CREATE TABLE [CW2].[Users] (
    [userID] INT IDENTITY(1,1) NOT NULL,
    [firstName] VARCHAR(255) NOT NULL,
    [lastName] VARCHAR(255) NOT NULL,
    [email] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY (userID)
);

CREATE Table [CW2].[Description] (
    [geohash] VARCHAR(11),
    [info] VARCHAR(255) NOT NULL,
    [difficulty] VARCHAR(255) NOT NULL,
    [distance] FLOAT NOT NULL, --Metres
    [duration] INT NOT NULL, --Duration in Minutes
    [pointAGeohash] VARCHAR(11),
    [pointBGeohash] VARCHAR(11),
    [pointCGeohash] VARCHAR(11),
    [pointDGeohash] VARCHAR(11),
    CONSTRAINT [PK_Description] PRIMARY KEY (geohash)
);

CREATE TABLE [CW2].[TrailUsers] (
    [trailID] INT,
    [userID] INT,
    [geohash] VARCHAR(11) NOT NULL,
    FOREIGN KEY (trailID) REFERENCES [CW2].[Author](trailID),
    FOREIGN KEY (userID) REFERENCES [CW2].[Users](userID),
    FOREIGN KEY (geohash) REFERENCES [CW2].[Description](geohash),
    CONSTRAINT [PK_TrailUsers] PRIMARY KEY (trailID, userID)
);

