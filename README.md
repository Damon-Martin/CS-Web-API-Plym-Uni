# TrailAPI: Web API Command Specification
### Module: Information Management & Retrieval
### University: University of Plymouth
### Student ID: 10729705
This is a CRUD Restful API Made in C# following the Model View Controller Architectual Pattern. This manipulates my TrailService SQL Server Data Base using controllers that manipulate the DbContext that holds all the models.

### Programming Language used C#
<img src ="https://user-images.githubusercontent.com/91668778/211181144-3f18c307-9de5-4ed3-83d9-29934dea440d.svg" alt="C#_Logo" width=50>
(seeklogo, C# Logo 2022)

### How to Run
    1. Create a MS SQL Server Database
    2. Run Scripts Found in "SqlServerScripts"
    3. Adjust Connection String found in https://github.com/Damon-Martin/CS-Web-API-Plym-Uni/blob/main/TrailAPI/appsettings.json
    3. (Note Original DB is different due to University Ownership and is for assesment)
    4. Open project using the sln file using Visual Studio 2022
    5. Run Project (Can use the API as intended or use Swagger/OpenAPI)

## MS SQL Database Design
<img src="https://user-images.githubusercontent.com/91668778/217995066-d335dd69-2676-4f48-bc8a-3f2f0a1d9e8b.png" alt="ERD and Normalisation" width="700">



## API Usage Description
## Authors Table
    HTTP GET
    URI: http://secam_or_localhost.com/API/Authors
    
    HTTP GET BY ID
    URI: http://secam_or_localhost.com/API/Authors/{trailID}
    
    HTTP Put
    URI: http://secam_or_localhost.com/API/Authors/{trailID}
    HTTP Body Schema:
    {
        "trailID": 0,
        "author": "string"
    }
    
    HTTP Post
    URI: http://secam_or_localhost.com/API/Authors
    HTTP Body Schema:
    {
        "author": "string"
    }
    
    HTTP Delete: Integer Key trailID
    URI: http://secam_or_localhost.com/API/Authors/{trailID}
## Description Table
    HTTP GET
    URI: http://secam_or_localhost.com/API/Description
    
    HTTP GET BY ID
    URI: http://secam_or_localhost.com/API/Description/{geohash}
    
    HTTP Put
    URI: http://secam_or_localhost.com/API/Description
    HTTP Body Schema:
    {
        "geohash": "string",
        "info": "string",
        "difficulty": "string",
        "distance": 0,
        "duration": 0,
        "pointAgeohash": "string",
        "pointBgeohash": "string",
        "pointCgeohash": "string",
        "pointDgeohash": "string"
    }
    
    HTTP Post
    URI: http://secam_or_localhost.com/API/Description
    HTTP Body Schema:
    {
        "geohash": "string",
        "info": "string",
        "difficulty": "string",
        "distance": 0,
        "duration": 0,
        "pointAgeohash": "string",
        "pointBgeohash": "string",
        "pointCgeohash": "string",
        "pointDgeohash": "string"
    }
    
    HTTP Delete: String Key geohash
    URI: http://secam_or_localhost.com/API/Users/{geohash}
## TrailUsers Table
    HTTP GET
    URI: http://secam_or_localhost.com/API/TrailUsers
    
    HTTP GET BY ID
    URI: http://secam_or_localhost.com/API/TrailUsers/{trailID}/{userID}
    
    HTTP Put
    HTTP Body Schema:
    URI: http://secam_or_localhost.com/API/TrailUsers
    {
        "trailId": 0,
        "userId": 0,
        "geohash": "string"
    }
    
    HTTP Post
    URI: http://secam_or_localhost.com/API/TrailUsers
    HTTP Body Schema:
    {
        "trailId": 0,
        "userId": 0,
        "geohash": "string"
    }
    
    HTTP Delete: Integer Compound Key, Integer trailID & Integer userID
    URI: http://secam_or_localhost.com/API/TrailUsers/{trailID}/{userID}

## User Table
    HTTP GET
    URI: http://secam_or_localhost.com/API/User
    
    HTTP GET BY ID
    URI: http://secam_or_localhost.com/API/User/{userID}
    
    HTTP Put
    URI: http://secam_or_localhost.com/API/User/{userID}
    HTTP Body Schema:
    {
        "userId": 0,
        "firstName": "string",
        "lastName": "string",
        "email": "string"
    }
    
    HTTP Post
    URI: http://secam_or_localhost.com/API/User
    HTTP Body Schema:
    {
        "firstName": "string",
        "lastName": "string",
        "email": "string"
    }
    
    HTTP Delete: Integer Key userID
    URI: http://secam_or_localhost.com/API/Users/{userID}
## References
seeklogo (2022) C# Logo, seeklogo. seeklogo. Available at: https://seeklogo.com/vector-logo/363285/c-sharp-c (Accessed: January 8, 2023). 
