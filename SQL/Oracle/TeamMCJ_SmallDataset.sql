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

--Query--
COMMIT;
Select * FROM AppUser;
Select * FROM Movie;
Select * FROM Genre;
Select * FROM TypeOfMovie;

--Application Users--
insert into AppUser values ('meecah.mec@gmail.com', 'imPreti');
insert into AppUser values ('Connor.gauthern@gmail.com', 'imNerd');
insert into AppUser values ('tammy.cahayon@yahoo.com', 'imCutie');
insert into AppUser values ('LeighMetz@xtra.co.nz', 'imPogi');
insert into AppUser values ('Sasuke.Uchiha@naruto.com', 'imZeBest');
insert into AppUser values ('Kirito.soloPlayer@sao.co.nz', 'imSoloPlayer');
insert into AppUser values ('Tanjiro.Kamado@yahoo.com', 'imDemonSlayer');
insert into AppUser values ('Grey.Fullbuster@fairytail.com', 'imIceMage');
insert into AppUser values ('Goku@dragonballz.com', 'imSaiyan');
insert into AppUser values ('Mitsuha.Miyamizu@yourname.com', 'iCry');

--Movie--
insert into Movie(title, summary, releaseyear, movieduration, movieimg) values ('Your Name', 'Two teenagers share a profound, magical connection upon discovering they are swapping bodies. But things become even more complicated when the boy and girl decide to meet in person.', DATE '2016-12-16', 112, 'Imgs\\YourName.jpg');
insert into Movie(title, summary, releaseyear, movieduration, movieimg) values ('Spirited Away', NULL, DATE '2001-07-20', 125, 'Imgs\\SpiritedAway.jpg');
insert into Movie(title, summary, releaseyear, movieduration, movieimg) values ('Jumanji', 'Two children come across a magical board game. While playing it, they meet Alan, a man who was trapped in the game, and attempt to free him while facing different kinds of danger.', DATE '1995-12-15', 104, 'Imgs\\Jumanji1995.jpg');
insert into Movie(title, summary, releaseyear, movieduration, movieimg) values ('The Last: Naruto the Movie', 'Hinata Hyuga''s younger sister has been kidnapped, so Naruto must do what he can to save her.', DATE '2014-01-15', 112, 'Imgs\\TheLastNaruto.jpg');
insert into Movie(title, summary, releaseyear, movieduration, movieimg) values ('Wolf Children', 'Hana marries a wolf man and raises their two children alone after he dies. They move to the countryside and the children have adventures in the woods and at school.', DATE '2012-06-25', 117, 'Imgs\\WolfChildren.jpg');
insert into Movie(title, summary, releaseyear, movieduration, movieimg) values ('Avengers: Infinity War', 'The Avengers must stop Thanos, an intergalactic warlord, from getting his hands on all the infinity stones. However, Thanos is prepared to go to any lengths to carry out his insane plan.', DATE '2018-04-25', 160, 'Imgs\\InfinityWars.jpg');
insert into Movie(title, summary, releaseyear, movieduration, movieimg) values ('Bridge to Terabithia', 'A rich city girl, Leslie, and a poor country boy, Jess, create Terabithia, a land of magical beings, and become its rulers. This helps Jess to escape and cope with a tragedy.', DATE '2007-06-07', 96, 'Imgs\\BridgetoTerabithia.jpg');
insert into Movie(title, summary, releaseyear, movieduration, movieimg) values ('Weathering with you', 'A boy runs away to Tokyo and befriends a girl who appears to be able to manipulate the weather.', DATE '2019-08-22', 111, 'Imgs\\Weatheringwithyou.jpg');
insert into Movie(title, summary, releaseyear, movieduration, movieimg) values ('The Lion King', 'As a cub, Simba is forced to leave the Pride Lands after his father Mufasa is murdered by his wicked uncle, Scar. Years later, he returns as a young lion to reclaim his throne.', DATE '1994-08-25', 79, 'Imgs\\TheLionKing1994.jpg');
insert into Movie(title, summary, releaseyear, movieduration, movieimg) values ('Jungle Book', 'Mowgli is a young boy who has been raised by wolves. When a man-eating tiger threatens his life, his animal family tries to convince him to leave the jungle and live in the human village.', DATE '1967-10-18', 89, 'Imgs\\ThejungleBook1967.jpg');

--Genre--
insert into Genre values ('Horror', 'Story that creates feelings of fear, dread, repulsion, and terror');
insert into Genre values ('Action', 'Exactly what it sounds like');
insert into Genre values ('Comedy', 'Story that makes you laugh');
insert into Genre values ('Romance', 'Story about two people who are inlove with each other');
insert into Genre values ('Documentary', 'A non-fiction movie that documents or captures reality in some way');
insert into Genre values ('Drama', 'A white girl movie');
insert into Genre values ('Science Fiction', 'Speculative fiction that typically deals with imaginative and futuristic concepts');
insert into Genre values ('Family', 'Family friendly movies');
insert into Genre values ('Fantasy', 'A speculative fiction set in a fictional universe, often inspired by real world myth and folklore.');
insert into Genre values ('Thriller', 'Story that creates feelings of suspense, excitement, surprise, anticipation and anxiety.');

--TypeOfMovie--
insert into TypeOfMovie values ('Animation', 1);
insert into TypeOfMovie values ('Drama', 1);
insert into TypeOfMovie values ('Romance', 1);
insert into TypeOfMovie values ('Fantasy', 1);
--
insert into TypeOfMovie values ('Animation', 2);
insert into TypeOfMovie values ('Fantasy', 2);
insert into TypeOfMovie values ('Adventure', 2);
insert into TypeOfMovie values ('Family', 2);
--
insert into TypeOfMovie values ('Family', 3);
insert into TypeOfMovie values ('Adventure', 3);
insert into TypeOfMovie values ('Comedy', 3);
--
insert into TypeOfMovie values ('Animation', 4);
insert into TypeOfMovie values ('Adventure', 4);
insert into TypeOfMovie values ('Action', 4);
insert into TypeOfMovie values ('Romance', 4);
--
insert into TypeOfMovie values ('Animation', 5);
insert into TypeOfMovie values ('Family', 5);
insert into TypeOfMovie values ('Drama', 5);
--
insert into TypeOfMovie values ('Science Fiction', 6);
insert into TypeOfMovie values ('Action', 6);
insert into TypeOfMovie values ('Adventure', 6);
--
insert into TypeOfMovie values ('Family', 7);
insert into TypeOfMovie values ('Fantasy', 7);
insert into TypeOfMovie values ('Drama', 7);
--
insert into TypeOfMovie values ('Animation', 8);
insert into TypeOfMovie values ('Fantasy', 8);
insert into TypeOfMovie values ('Drama', 8);
insert into TypeOfMovie values ('Family', 8);
--
insert into TypeOfMovie values ('Animation', 9);
insert into TypeOfMovie values ('Family', 9);
insert into TypeOfMovie values ('Adventure', 9);
insert into TypeOfMovie values ('Drama', 9);
--
insert into TypeOfMovie values ('Animation', 10);
insert into TypeOfMovie values ('Family', 10);
insert into TypeOfMovie values ('Adventure', 10);
