COMMIT;

CREATE TABLE AppUser (

Email VARCHAR(50) PRIMARY KEY,
CONSTRAINT chk_email
    CHECK (Email like '%@%.%'),
UserPass VARCHAR(25) NOT NULL

);

CREATE TABLE Movie (

Movie_Id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
Title VARCHAR(150) NOT NULL,
Summary VARCHAR(400),
ReleaseYear DATE NOT NULL,
MovieDuration INT,
MovieImg VARCHAR(300)

);

CREATE TABLE Genre (

Gname VARCHAR(20) PRIMARY KEY,
Genre_Desc VARCHAR(300)

);

CREATE TABLE Crew (

Crew_Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
ContactNum INT,
FirstName VARCHAR(20),
LastName VARCHAR(20)

);

CREATE TABLE MovCharacter (

Char_Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
Char_Name VARCHAR(20),
Char_Desc VARCHAR(300),
Crew_Id INT,
CONSTRAINT FK_CrewId
    FOREIGN KEY(Crew_Id) REFERENCES Crew(Crew_Id)

);

CREATE TABLE ProducerType (

Pname VARCHAR(20) PRIMARY KEY,
Prod_Desc VARCHAR(300)

);

CREATE TABLE Review (

Email VARCHAR(50),
CONSTRAINT chk_rev_email
    CHECK (Email like '%@%.%'),
Movie_Id INT NOT NULL,
RComment VARCHAR(500),
Rating INT,
CONSTRAINT chk_rating
    CHECK ((Rating >= 0) AND (Rating <= 10)),
CONSTRAINT PK_Review
    PRIMARY KEY(Email, Movie_Id),
CONSTRAINT FK_email
    FOREIGN KEY(Email)
    REFERENCES AppUser(Email),
CONSTRAINT FK_movieId
    FOREIGN KEY(Movie_Id)
    REFERENCES Movie(Movie_Id)

);

CREATE TABLE TypeOfMovie (

Gname VARCHAR(20) NOT NULL,
Movie_Id INT NOT NULL,
CONSTRAINT PK_TypeOfMovie
    PRIMARY KEY(Gname, Movie_Id),
CONSTRAINT FK_gname
    FOREIGN KEY(Gname)
    REFERENCES Genre(Gname),
CONSTRAINT FK_ToM_movieId
    FOREIGN KEY(Movie_Id)
    REFERENCES Movie(Movie_Id)

);

CREATE TABLE Stars (

Crew_Id INT NOT NULL,
Movie_Id INT NOT NULL,
CONSTRAINT PK_Stars
    PRIMARY KEY(Crew_Id, Movie_Id),
CONSTRAINT FK_Stars_crewId
    FOREIGN KEY(Crew_Id)
    REFERENCES Crew(Crew_Id),
CONSTRAINT FK_Stars_movieId
    FOREIGN KEY(Movie_Id)
    REFERENCES Movie(Movie_Id)

);

CREATE TABLE TypeOfProd (

Crew_Id INT NOT NULL,
Pname VARCHAR(20) NOT NULL,
CONSTRAINT PK_TypeOfProd
    PRIMARY KEY(Crew_Id, Pname),
CONSTRAINT FK_ToP_crewId
    FOREIGN KEY(Crew_Id)
    REFERENCES Crew(Crew_Id),
CONSTRAINT FK_ToP_pname
    FOREIGN KEY(Pname)
    REFERENCES ProducerType(Pname)

);

CREATE TABLE Actor (

Crew_Id INT PRIMARY KEY,
CONSTRAINT FK_Actor_crewId
    FOREIGN KEY(Crew_Id)
    REFERENCES Crew(Crew_Id)

);

CREATE TABLE Producer (

Crew_Id INT PRIMARY KEY,
CONSTRAINT FK_Producer_crewId
    FOREIGN KEY(Crew_Id)
    REFERENCES Crew(Crew_Id)

);

CREATE TABLE ScreenWriter (

Crew_Id INT PRIMARY KEY,
CONSTRAINT FK_ScreenWriter_crewId
    FOREIGN KEY(Crew_Id)
    REFERENCES Crew(Crew_Id)

);

Select * FROM AppUser;
Select * FROM Movie;
Select * FROM Genre;
Select * FROM Crew;
Select * FROM MovCharacter;
Select * FROM ProducerType;
Select * FROM Review;
Select * FROM TypeOfMovie;
Select * FROM Stars;
Select * FROM TypeOfProd;
Select * FROM Actor;
Select * FROM Producer;
Select * FROM ScreenWriter;

DROP TABLE ScreenWriter;
DROP TABLE Producer;
DROP TABLE Actor;
DROP TABLE TypeOfProd;
DROP TABLE Stars;
DROP TABLE TypeOfMovie;
DROP TABLE Review;
DROP TABLE ProducerType;
DROP TABLE MovCharacter;
DROP TABLE Crew;
DROP TABLE Genre;
DROP TABLE Movie;
DROP TABLE AppUser;