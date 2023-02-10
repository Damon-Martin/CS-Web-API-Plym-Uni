/*
    Task: Excercise 3 SQL
    StudentID: 10729705
*/

/************ INSERT INTO VALUES ***********/

/*We will be using 5 Rows of Data to simulate the same database at a larger scale with many more records of data*/
INSERT INTO [CW2].[Author](author) 
VALUES 
    ('Jonnathon Frost'),
    ('Ben Jones'),
    ('John Smith'),
    ('Alexis Smith'),
    ('Daniel Craig');

INSERT INTO [CW2].[Users](firstName, lastName, email)
VALUES 
('Jayden', 'Bailey', 'jayden.bailey@email.com'),
('Lewis', 'Johnson', 'lewis.johnson@email.com'),
('Jonathan', 'Paul', 'johnathan.paul@email.com'),
('Percy', 'Jackson', 'percy.jackson@email.com'),
('Henry', 'Jones', 'henry.jones@email.com');

INSERT INTO [CW2].[Description](
    geohash, info, difficulty, distance, duration, pointAGeohash, pointBGeohash, pointCGeohash, pointDGeohash
)
VALUES 
(
    --Geohashes contain both latitude and longitude.
    --Geohash Presicion scales from 1 VARCHAR to 11 VARCHAR any more will be negligible and is redundant data. 5+ chars is ideal.
    'gbvn9dx6m1e', --Plymouth Geohash
    'The Ocean Trail is the ultimate challenge for advanced the most advanced', --Description
    'Hard', --Difficulty
    35000, --Metres
    540, --Walking Duration in Minutes. 540mins = 9hrs.
    'gbvn9dx6m1d', --pointAGeohash
    'gbvn9keb', --pointBGeoHash
    'gbvn9jeb', --pointCGeoHash
    'gbvn9jkp' --pointDGeoHash
),
(
    'gcn87f5', --Sandbanks, Poole & Bournemouth Geohash
    'Sandbanks, located in Poole a part of the Jarrassic Coast has some of the most beautiful views and easy routes..',
    'Easy',
    4000, --4,000km = 4km
    48, --Walking Duration in Minutes
    'gcn87g',
    'gcn8kh',
    'gcn8kj',
    'gcn8kq'
),
(
    'gcpvn1', --london Geohash
    'London, One of the longest trails due to being a massive city. Not for the lighthearted due to dangourous roads.',
    'Hard',
    50000, --50,000m = 50km
    760, --Walking Duration in Minutes. 760mins = 12.67hrs.
    'gcpvn2',
    'gcpvn6',
    'gcpvne',
    'gcpvnu'
),
(
    'gcn8xs0',
    'Christchurch, located next to Bournemouth this historical town is a moderate challenge with spectacular views.',
    'Medium',
    15000, --1500m = 15km
    70, --Walking Duration in Minutes
    'gcn8xs3',
    'gcn8xsd',
    'gcn8xs7',
    'gcn8xss'
),
(
    'gcncmzsbr',
    'New Forest National Park, Easily Accessible located in the country-side in the south of the UK.
    This trail has stunning views and horses with little',
    'Easy',
    4500, --4,000km = 4km
    50, --Walking Duration in Minutes
    'gcncw0',
    'gcncw2',
    'gcncw9',
    'gcncwf'
);

--Authors may upload multiple locations
--Occassionally we a trail may have 2 or more authors as perhaps they might be co-owners of the trail or trail company.
--This is a minority but the system should allow for such use cases.
--Users may choose different tracks
INSERT INTO [CW2].[TrailUsers] (trailID, userID, geohash)
VALUES
(1, 5, 'gbvn9dx6m1e'),
(2, 1, 'gcpvn1'),
(2, 4, 'gcpvn1'),
(3, 3, 'gcn87f5'),
(4, 3, 'gcn8xs0'),
(4, 2, 'gcncmzsbr'), --[4]Alexis Smith & [5]Daniel Craig both own New Forest. TrailUsers allows many Users to go to their track.
(5, 2, 'gcncmzsbr'); 

