/*
    Task: Excercise 4 Views
    StudentID: 10729705
*/

/************ VIEWS ***********/
-- VIEW AuthorTrailsDifficulty: Displays [author], [geohash(location)] and [difficulty]
-- Shows Which owners has rights to a trail. Occassionally a trail might have 2 authors.
CREATE VIEW [CW2].[AuthorTrailsDifficulty]
AS
    SELECT
        [CW2].[Author].[author],
        [CW2].[Description].[geohash],
        [CW2].[Description].[difficulty]
    FROM [CW2].[Author]
    JOIN [CW2].[TrailUsers]
        ON [CW2].[Author].[trailID] = [CW2].[TrailUsers].[trailID]
    JOIN [CW2].[Description]
        ON [CW2].[Description].[geohash] = [CW2].[TrailUsers].[geohash];
GO

-- VIEW UserOwnedTrails: Displays Users and What Trails they Own
-- Useful for this micro-service to share with other micro-services and info for users
CREATE VIEW [CW2].[UserOwnedTrails] 
AS
    SELECT DISTINCT [firstName],[lastName],[TrailUsers].[userID], [geohash]
    FROM [CW2].[TrailUsers]
    JOIN [CW2].[Users]
        ON [Users].[userID] = [TrailUsers].[userID];
GO


CREATE VIEW [CW2].[CheckPoints] 
AS
    SELECT [geohash] AS 'initGeohash', [pointAGeohash] AS 'Point A', [pointBGeohash] AS 'Point B', 
        [pointCGeohash] AS 'Point C', [pointDGeohash] AS 'Point D'
    FROM [CW2].[Description];
GO


-- VIEW TrackDuration: Displays The Trail and its duration
-- Useful for advice for users
CREATE VIEW [CW2].[TrackDuration]
AS
    SELECT [geohash], [duration] AS 'duration (mins)' FROM [CW2].[Description];
GO

-- VIEW AuthorFrequency: Displays how many times an author is used
-- Useful for Analytics and advertising a trail
CREATE VIEW [CW2].[AuthorFrequency] 
AS
    SELECT [trailID], COUNT(trailID) AS 'frequency'
    FROM [CW2].[TrailUsers]
    GROUP BY [trailID]
GO



/*
--Test - Checking if AuthorTrailsDifficulty works == True
SELECT * FROM [CW2].[TrailUsers];
SELECT * FROM [CW2].[Author];
SELECT * FROM [CW2].[AuthorTrailsDifficulty];
*/

/*
--Test - Checking if User Owned Trails Works == True
SELECT * FROM [CW2].[UserOwnedTrails];
SELECT * FROM [CW2].[TrailUsers];
SELECT * FROM [CW2].[Users];
*/

/*
--Test - Checking if Author Frequency Works == True
SELECT * FROM [CW2].[TrailUsers];
SELECT * FROM [CW2].[AuthorFrequency];
*/

/*
--Test - Checking Duration is working == True
SELECT * FROM [CW2].[TrackDuration];
SELECT * FROM [CW2].[Description];
*/

/*
--Testing CheckPoints == True
SELECT * FROM [CW2].[CheckPoints];
SELECT * FROM [CW2].[Description];
*/