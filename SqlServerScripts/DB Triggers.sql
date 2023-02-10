/*
    Task: Excercise 6 Triggers
    StudentID: 10729705
*/
--Checks if the entry for difficulty is 
CREATE TRIGGER [CW2].[checkDifficultyValid]
ON [CW2].[Description]
FOR INSERT, UPDATE
AS
BEGIN
--We Just need a case and we are good
    UPDATE [CW2].[Description]
    SET [difficulty] = CASE
        --Only Acceptable values will be taken in for difficulty
        WHEN [difficulty] = 'Hard' THEN 'Hard'
        WHEN [difficulty] = 'hard' THEN 'Hard'
        WHEN [difficulty] = 'Medium' THEN 'Medium'
        WHEN [difficulty] = 'medium' THEN 'Medium'
        WHEN [difficulty] = 'Easy' THEN 'Easy'
        WHEN [difficulty] = 'easy' THEN 'Easy'
        ELSE 'Medium'
    END;
END
GO


--Test Selecting ALL triggers
SELECT
    name,
    type
FROM
   sys.triggers


--This test requires 3 test cases for 1 wrong input, then Easy, Medium and Hard
SELECT * FROM [CW2].[Description];
EXEC [CW2].[UpdateEntryDescription] 
    @geohash = 'gcncmzsbr', 
    @info = 'New Forest, is one of our easiest trails filled with horses and wilderness',
    @difficulty = 'dafasfasd', --This will Auto correct into Medium
    @distance = 4515,
    @duration = 55,
    @pointAGeohash = 'gcncw0',
    @pointBGeohash = 'gcncw2',
    @pointCGeohash = 'gcncw8',
    @pointDGeohash = 'gcncwf'
GO
SELECT * FROM [CW2].[Description];



--Test 2
SELECT * FROM [CW2].[Description];
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
SELECT * FROM [CW2].[Description];



--Test 3
SELECT * FROM [CW2].[Description];
EXEC [CW2].[UpdateEntryDescription] 
    @geohash = 'gcncmzsbr', 
    @info = 'New Forest, is one of our easiest trails filled with horses and wilderness',
    @difficulty = 'Medium', 
    @distance = 4515,
    @duration = 55,
    @pointAGeohash = 'gcncw0',
    @pointBGeohash = 'gcncw2',
    @pointCGeohash = 'gcncw8',
    @pointDGeohash = 'gcncwf'
GO
SELECT * FROM [CW2].[Description];



--Test 4
SELECT * FROM [CW2].[Description];
EXEC [CW2].[UpdateEntryDescription] 
    @geohash = 'gcncmzsbr', 
    @info = 'New Forest, is one of our easiest trails filled with horses and wilderness',
    @difficulty = 'Hard', 
    @distance = 4515,
    @duration = 55,
    @pointAGeohash = 'gcncw0',
    @pointBGeohash = 'gcncw2',
    @pointCGeohash = 'gcncw8',
    @pointDGeohash = 'gcncwf'
GO
SELECT * FROM [CW2].[Description];



SELECT * FROM [CW2].[Description];
EXEC [CW2].[CreateEntryDescription] 
    @geohash = 'd7285m1ytpj', 
    @infoInput = 'Cambridge, an easy tail for our users',
    @difficultyInput = 'idsndnfaonfadsonsdakjnfasdkjnas', --This will Auto correct into Medium
    @distanceInput = 5,
    @durationInput = 10,
    @pointAGeohash = 'd7285n',
    @pointBGeohash = 'd7285j',
    @pointCGeohash = 'd7285k',
    @pointDGeohash = 'd7285m'
GO
SELECT * FROM [CW2].[Description];


