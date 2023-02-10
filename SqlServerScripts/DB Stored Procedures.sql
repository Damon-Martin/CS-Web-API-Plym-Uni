/*
    Task: Excercise 5 Stored Procedures
    StudentID: 10729705
*/

/************ CREATE SECTION ***********/

--Add Entry: Description
--No trigger needed
CREATE PROCEDURE [CW2].[CreateEntryDescription] @geohash VARCHAR(11), @infoInput VARCHAR(255),
@difficultyInput VARCHAR(255), @distanceInput VARCHAR(30), @durationInput INT, @pointAGeohash VARCHAR(11), 
@pointBGeohash VARCHAR(11), @pointCGeohash VARCHAR(11), @pointDGeohash VARCHAR(11)
AS
    INSERT INTO [CW2].[Description] ([geohash], [info],
    [difficulty], [distance], [duration], [pointAGeohash], [pointBGeohash], 
    [pointCGeohash], [pointDGeohash]
    )
    VALUES (
        @geohash, @infoInput, @difficultyInput,
        @distanceInput, @durationInput,
        @pointAGeohash, @pointBGeohash,
        @pointCGeohash, @pointDGeohash
    );
GO

--Add Entry: Users
--No trigger needed
--Must assign userID, firstName, lastName
CREATE PROCEDURE [CW2].[CreateEntryUser] @firstNameInput VARCHAR(11), @lastNameInput VARCHAR(255), @email VARCHAR(255)
AS
    INSERT INTO [CW2].[Users] ([firstName], [lastName], [email])
    VALUES (@firstNameInput, @lastNameInput, @email);
GO

--Add Entry: Authors
--No trigger needed
--Must assign trailID, author
CREATE PROCEDURE [CW2].[CreateEntryAuthor] @authorName VARCHAR(30)
AS
    INSERT INTO [CW2].[Author] ([author])
    VALUES (@authorName);
GO

--Add Entry: TrailUsers
--Set trigger to make Default entry in info if geohash not in Description
CREATE PROCEDURE [CW2].[CreateEntryTrailUsers] @trailIdInput INT, @UserIdInput INT, @geohashInput VARCHAR(11)
AS
    INSERT INTO [CW2].[TrailUsers] ([trailID], [userID], [geohash])
    VALUES (@trailIdInput, @UserIdInput, @geohashInput);
GO

/************ UPDATE SECTION ***********/

-- Update a Trails Description
-- Geohash is the Primary Key to be UPDATED
CREATE PROCEDURE [CW2].[UpdateEntryDescription] @geohash VARCHAR(11), @info VARCHAR(255),
@difficulty VARCHAR(255), @distance VARCHAR(30), @duration INT, @pointAGeohash VARCHAR(11),
@pointBGeohash VARCHAR(11), @pointCGeohash VARCHAR(11), @pointDGeohash VARCHAR(11)
AS
    UPDATE [CW2].[Description]
        SET [info] = @info, [difficulty] = @difficulty, [distance] = @distance, [duration] = @duration,
        [pointAGeohash] = @pointAGeohash, [pointBGeohash] = @pointBGeohash, [pointCGeohash] = @pointCGeohash,
        [pointDGeohash] = @pointDGeohash
    WHERE [geohash] = @geohash;
GO

-- Update Author Name
-- trailID is the Primary Key to be UPDATED
CREATE PROCEDURE [CW2].[UpdateEntryAuthor] @trailID INT, @authorInput VARCHAR(255)
AS
    UPDATE [CW2].[Author]
    SET [author] = @authorInput
    WHERE [trailID] = @trailID;
GO


-- Update Users
-- trailID is the Primary Key to be UPDATED
CREATE PROCEDURE [CW2].[UpdateEntryUser] @userID INT, @firstName VARCHAR(255), @lastName VARCHAR(255), @email VARCHAR(255)
AS
    UPDATE [CW2].[Users]
    SET [firstName] = @firstName, [lastName] = @lastName, [email] = @email
    WHERE [userID] = @userID;
GO

-- Update TrailUsers
-- I'm assuiming the author put in the wrong location so this allows them to update it
-- Use trigger Here if new geohash not in geohash table
-- Only thing makes sense to update is geohash(location) .
-- Due to if a match of user and author and if they wanted to change that they'd DELETE. 
-- However, some authors have different locations so geohash makes sense
CREATE PROCEDURE [CW2].[UpdateEntryTrailUser] @trailID INT, @userID INT, @newGeohash VARCHAR(11)
AS
    UPDATE [CW2].[TrailUsers]
    SET [geohash] = @newGeohash
    WHERE [trailID] = @trailID AND [userID] = @userID;
GO

/************ DELETE SECTION ***********/

--Delete TrailEntryUsers
CREATE PROCEDURE [CW2].[DeleteEntryTrailUser] @trailID INT, @userID INT
AS
    DELETE FROM [CW2].[TrailUsers]
    WHERE [trailID] = @trailID AND [userID] = @userID;
GO

-- Delete EntryUser
-- Deletes from TrailUsers and Users Table
CREATE PROCEDURE [CW2].[DeleteEntryUser] @userID INT
AS
    DELETE FROM [CW2].[Users]
    WHERE [userID] = @userID;
GO

-- Delete Author
CREATE PROCEDURE [CW2].[DeleteEntryAuthor] @trailID INT
AS
    DELETE FROM [CW2].[Author]
    WHERE [trailID] = @trailID;
GO

--Delete Description
CREATE PROCEDURE [CW2].[DeleteEntryDescription] @geohash VARCHAR(11)
AS
    DELETE FROM [CW2].[Description]
    WHERE [geohash] = @geohash;
GO

/************ Testing SECTION ***********/
/******* TESTING CREATE SECTION *********/
/*
--Testing Create Author Entry
--Before
SELECT * FROM [CW2].[Author];
-- Creation
EXEC [CW2].[CreateEntryAuthor] @authorName = 'Alex Martin'
--After
SELECT * FROM [CW2].[Author];
*/

/*
--Testing Create Description Entry
--Before
SELECT * FROM [CW2].[Description];
-- Creation
EXEC [CW2].[CreateEntryDescription] @geohash = 'gfhyzze8kc7', 
    @infoInput = 'Inverness, is a moderate challenge of Scottish Trails',
    @difficultyInput = 'Medium',
    @distanceInput = 14000,
    @durationInput = 65,
    @pointAGeohash = 'gfhyzzu',
    @pointBGeohash = 'gfhzpbj',
    @pointCGeohash = 'gfhzpbj',
    @pointDGeohash = 'gfhzpbq';
GO
--After
SELECT * FROM [CW2].[Description];
*/
/*
--Testing User Entry
SELECT * FROM [CW2].[Users];
EXEC [CW2].[CreateEntryUser] @firstNameInput = 'Harry', @lastNameInput = 'Hills', @email = 'harry.hills@email.com';
GO
SELECT * FROM [CW2].[Users];
*/

/*
-- Testing CreateEntryTrailUsers (Requires test createEntryAuthor, createEntryGeohash )
-- Before
SELECT * FROM [CW2].[TrailUsers];
-- Create
EXEC [CW2].[CreateEntryTrailUsers] @trailIdInput = 2, @userIdInput = 3, @geohashInput = 'gcn87f5';
-- After
SELECT * FROM [CW2].[TrailUsers];
*/


/******* TESTING UPDATE SECTION *********/

/*
-- Testing UpdateEntryDescription
-- Before
SELECT * FROM [CW2].[Description];
-- Update
EXEC [CW2].[UpdateEntryDescription] 
    @geohash = 'gcncmzsbr', 
    @info = 'New Forest, is one of our easiest trails filled with horses and wilderness',
    @difficulty = 'Easy',
    @distance = 4515,
    @duration = 55,
    @pointAGeohash = 'gcncw0',
    @pointBGeohash = 'gcncw2',
    @pointCGeohash = 'gcncw8',
    @pointDGeohash = 'gcncwf'
GO
-- Change
SELECT * FROM [CW2].[Description];
*/

/*
-- Testing UpdateEntryUser
-- Before
SELECT * FROM [CW2].[Users];
-- Update
EXEC [CW2].[UpdateEntryUser] @userID = 1, @firstName = 'Thomas', @lastName = 'Keeth', @email = 'thomas.keeth@fastmail.com'
-- After
SELECT * FROM [CW2].[Users];
*/

/*
--Testing UpdateEntryAuthor
--Before
SELECT * FROM [CW2].[Author];
--Update (Changing userID = 2, Ben Jones to Jack Kennedy)
EXEC [CW2].[UpdateEntryAuthor] @trailID = 2, @authorInput = 'Jack Kennedy'
--After
SELECT * FROM [CW2].[Author];
*/

/*
-- Updating TrailUser (Not testing Trigger Yet)
--Before
SELECT * FROM [CW2].[TrailUsers];
-- I'm assuiming the author put in the wrong location so this allows them to update it
--Changing trailID = 2's geohash gcpvn1 (current) to gbvn9dx6m1e (after)
-- Making trailID = 2 a multi publisher of the trails
-- Update
EXEC [CW2].[UpdateEntryTrailUser] @trailID = 2, @userID = 4, @newGeohash = 'gbvn9dx6m1e'
--After
SELECT * FROM [CW2].[TrailUsers];
*/

/************ DELETE TESTING SECTION ****************/
/*
-- Testing Delete TrailUser
--Before
SELECT * FROM [CW2].[TrailUsers];
-- Delete
EXEC [CW2].[DeleteEntryTrailUser] @trailID = 4, @userID = 3;
-- After
SELECT * FROM [CW2].[TrailUsers];
*/

/*
-- Testing Delete User
--Before
SELECT * FROM [CW2].[Users];
-- Delete
EXEC [CW2].[DeleteEntryUser] @userID = 6
-- After
SELECT * FROM [CW2].[Users];
*/

/*
--Testing DeleteEntryAuthor
-- Can only delete items non referenced. Delete Trail Users First then this.
-- It's a planned micro-service and I assume the logic of the system will handle this in a higher level
--Before
SELECT * FROM [CW2].[Author];
-- Delete
EXEC [CW2].[DeleteEntryAuthor] @trailID = 6;
-- After
SELECT * FROM [CW2].[Author];
*/


--Testing DeleteEntryDescription
-- Before
SELECT * FROM [CW2].[Description];
-- Delete
EXEC [CW2].[DeleteEntryDescription] @geohash = gfhyzze8kc7
-- After
SELECT * FROM [CW2].[Description];
