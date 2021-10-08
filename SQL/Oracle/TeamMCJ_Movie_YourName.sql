COMMIT;
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

--Crew--
insert into Crew(ContactNum, FirstName, LastName)values(null,'Makoto', 'Shinkai');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Ryûnosuke', 'Kamiki');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Clark', 'Cheng');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Mone', 'Kamishiraishi');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Ryô', 'Narita');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Aoi', 'Yûki');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Nobunaga', 'Shimazaki');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Kaito', 'Ishikawa');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Kanon', 'Tani');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Maskai', 'Terasoma');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Sayaka', 'Ôhara');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Kazuhiko', 'Inoue');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Chafûrin', null);
insert into Crew(ContactNum, FirstName, LastName)values(null,'Kana', 'Hanazawa');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Shin''ya', 'Hamazoe');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Yoshihiro', 'Furusawa');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Tatsuro', 'Hatanaka');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Minami', 'Ichikawa');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Shin''ichirô', 'Inoue');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Kôichirô', 'Itô');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Noritaka', 'Kawaguchi');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Genki', 'Kawamura');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Yukari', 'Kiso');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Kenji', 'Ohta');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Yuuichi', 'Sakai');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Katsuhiro', 'Takei');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Masanori', 'Yumiya');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Junji', 'Zenki');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Masami', 'Nagasawa');
insert into Crew(ContactNum, FirstName, LastName)values(null,'Etsuko', 'Ichihara');

--Stars--
insert into Stars values (1, 1);
insert into Stars values (2, 1);
insert into Stars values (3, 1);
insert into Stars values (4, 1);
insert into Stars values (5, 1);
insert into Stars values (6, 1);
insert into Stars values (7, 1);
insert into Stars values (8, 1);
insert into Stars values (9, 1);
insert into Stars values (10, 1);
insert into Stars values (11, 1);
insert into Stars values (12, 1);
insert into Stars values (13, 1);
insert into Stars values (14, 1);
insert into Stars values (15, 1);
insert into Stars values (16, 1);
insert into Stars values (17, 1);
insert into Stars values (18, 1);
insert into Stars values (19, 1);
insert into Stars values (20, 1);
insert into Stars values (21, 1);
insert into Stars values (22, 1);
insert into Stars values (23, 1);
insert into Stars values (24, 1);
insert into Stars values (25, 1);
insert into Stars values (26, 1);
insert into Stars values (27, 1);
insert into Stars values (28, 1);
insert into Stars values (29, 1);
insert into Stars values (30, 1);

--Screen Writer--
insert into ScreenWriter values (1);
insert into ScreenWriter values (3);

--Producer--
insert into Producer values (1);
insert into Producer values (16);
insert into Producer values (17);
insert into Producer values (18);
insert into Producer values (19);
insert into Producer values (20);
insert into Producer values (21);
insert into Producer values (22);
insert into Producer values (23);
insert into Producer values (24);
insert into Producer values (25);
insert into Producer values (26);
insert into Producer values (27);
insert into Producer values (28);

--Type of Producer--
insert into TypeOfProd(Crew_Id, Pname) values (1, 'Director');
insert into TypeOfProd(Crew_Id, Pname) values (16, 'Executive Producer');
insert into TypeOfProd(Crew_Id, Pname) values (17, 'Co-Producer');
insert into TypeOfProd(Crew_Id, Pname) values (18, 'Chief Executive Prod');
insert into TypeOfProd(Crew_Id, Pname) values (19, 'Co-Producer');
insert into TypeOfProd(Crew_Id, Pname) values (20, 'Producer');
insert into TypeOfProd(Crew_Id, Pname) values (21, 'Chief Executive Prod');
insert into TypeOfProd(Crew_Id, Pname) values (21, 'Producer');
insert into TypeOfProd(Crew_Id, Pname) values (22, 'Producer');
insert into TypeOfProd(Crew_Id, Pname) values (23, 'Line Producer');
insert into TypeOfProd(Crew_Id, Pname) values (24, 'Chief Executive Prod');
insert into TypeOfProd(Crew_Id, Pname) values (25, 'Line Producer');
insert into TypeOfProd(Crew_Id, Pname) values (26, 'Producer');
insert into TypeOfProd(Crew_Id, Pname) values (27, 'Co-Producer');
insert into TypeOfProd(Crew_Id, Pname) values (28, 'Co-Producer');


--Producer Type--
insert into ProducerType values ('Director', 'A person who controls the making of a film and supervises the actors and technical crew.');
insert into ProducerType values ('Co-Director', 'A person who controls the making of a film and supervises the actors and technical crew with another person.');
insert into ProducerType values ('Chief Executive Prod', 'An executive producer is the head producer who oversees the creation of a film, television show, radio broadcast, music album, or theater performance.');
insert into ProducerType values ('Producer', 'A person responsible for the financial and managerial aspects of making a film.');
insert into ProducerType values ('Co-Producer', 'A person responsible for the financial and managerial aspects of making a film with another person.');
insert into ProducerType values ('Executive Producer', 'The role of the Executive Producer is to oversee the work of the producer on behalf of the studio, the financiers or the distributors. They will ensure the film is completed on time, within budget, and to agreed artistic and technical standards.');
insert into ProducerType values ('Line Producer', 'Line Producer manages the budget of a motion picture. Alternatively, or in addition, they may manage the day to day physical aspects of the film production');

--Actor--
insert into Actor values (2);
insert into Actor values (4);
insert into Actor values (5);
insert into Actor values (6);
insert into Actor values (7);
insert into Actor values (8);
insert into Actor values (29);
insert into Actor values (30);
insert into Actor values (9);
insert into Actor values (10);
insert into Actor values (11);
insert into Actor values (14);

--MovCharacter--
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Taki Tachibana', 'A high school boy in Tokyo. He spends his days with his friends and has a part-time job in an Italian restaurant. He is short-tempered but well meaning and kind, and aspires to become an architect.', 2);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Mitsuha Miyamizu', 'A high school girl dissatisfied with her life in Itomori, a rural town. She has a strained relationship with her politically minded father and is embarrassed by often open displays of control, as well as the part as a miko in rituals for the family shrine, with kuchikamizake.', 4);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('KatsuhikoTeshigawara', 'One of Mitsuha''s friends. He is a construction machinery and equipment expert, due to his father''s advice. His nickname is "Tessie".', 5);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Sayaka Natori', 'One of Mitsuha''s friends. She is a nervous girl in the broadcast club in high school who vehemently denies her attraction to Tessie.', 6);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Tsukasa Fujii', 'One of Taki''s friends. He worries about Taki whenever Mitsuha embodies him.', 7);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Shinta Takagi', 'One of Taki''s friends. He is optimistic.', 8);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Miki Okudera', 'A university student and one of Taki''s friends. She has feelings for Taki when Mitsuha is in his body. She is more commonly referred to as Ms. Okudera (Okudera-senpai) by colleagues.', 29);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Hitoha Miyamizu', 'The head of the Miyamizu family shrine in Itomori, and the grandmother of Mitsuha and Yotsuha. Her favorite family tradition is kumihimo (thread weaving).', 30);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Yotsuha Miyamizu', 'Mitsuha''s younger sister. She believes Mitsuha is somewhat crazy, but loves her despite the situation. She participates in creating both kumihimo and kuchikamizake.', 9);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Toshiki Miyamizu', 'The estranged father of Mitsuha and Yotsuha, and Futaba''s husband. He used to be a folklorist who came to town for research. He is very strict and jaded from events that occurred in his life. Toshiki became the town''s mayor after abandoning the shrine.', 10);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Futaba Miyamizu', 'The late mother of Mitsuha and Yotsuha, and the wife of Toshiki.', 11);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values ('Yukari Yukino', 'A literature teacher who says the word, "Kataware-doki" (meaning twilight).', 14);
