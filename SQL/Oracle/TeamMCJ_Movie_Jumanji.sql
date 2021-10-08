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
insert into Crew(FirstName, LastName)values('Joe','Johnston');
insert into Crew(FirstName, LastName)values('Jonathan','Hensleigh');
insert into Crew(FirstName, LastName)values('Greg','Taylor');
insert into Crew(FirstName, LastName)values('Jim','Strain');
insert into Crew(FirstName, LastName)values('Chris Van','Allsburg');
insert into Crew(FirstName, LastName)values('Robin','Williams');
insert into Crew(FirstName, LastName)values('Jonathan','Hyde');
insert into Crew(FirstName, LastName)values('Kirsten','Dunst');
insert into Crew(FirstName, LastName)values('Bradley','Piece');
insert into Crew(FirstName, LastName)values('Bonnie','Hunt');
insert into Crew(FirstName, LastName)values('Bebe','Neuwirth');
insert into Crew(FirstName, LastName)values('David Alan','Grier');
insert into Crew(FirstName, LastName)values('Patricia','Clarkson');
insert into Crew(FirstName, LastName)values('Adam','Hann-Byrd');
insert into Crew(FirstName, LastName)values('Laura Bell','Bundy');
insert into Crew(FirstName, LastName)values('James','Handly');
insert into Crew(FirstName, LastName)values('Gillian','Barber');
insert into Crew(FirstName, LastName)values('Brandon','Obray');
insert into Crew(FirstName, LastName)values('Cyrus','Thiedeke');
insert into Crew(FirstName, LastName)values('Gary Joeshph','Thorup');
insert into Crew(FirstName, LastName)values('Leonard','Zola');
insert into Crew(FirstName, LastName)values('Lloyd','Berry');
insert into Crew(FirstName, LastName)values('Malcolm','Stewart');
insert into Crew(FirstName, LastName)values('Annabel','Kershaw');
insert into Crew(FirstName, LastName)values('Darryl','Henriques');
insert into Crew(FirstName, LastName)values('Robyn','Driscoll');
insert into Crew(FirstName, LastName)values('Peter','Bryant');
insert into Crew(FirstName, LastName)values('Sarah','Gilson');
insert into Crew(FirstName, LastName)values('Florica','Vlad');
insert into Crew(FirstName, LastName)values('June','Lion');
insert into Crew(FirstName, LastName)values('Brenda','Lockmuller');
insert into Crew(FirstName, LastName)values('Frederick','Richardson');
insert into Crew(FirstName, LastName)values('Frank','Welker');
insert into Crew(FirstName, LastName)values('Robert','W. Cort');
insert into Crew(FirstName, LastName)values('Ted','Field');
insert into Crew(FirstName, LastName)values('Larry','Franco');
insert into Crew(FirstName, LastName)values('Scott','Kroopf');
insert into Crew(FirstName, LastName)values('William','Teitler');

--Stars--
insert into Stars values(88,3);
insert into Stars values(89,3);
insert into Stars values(90,3);
insert into Stars values(91,3);
insert into Stars values(92,3);
insert into Stars values(93,3);
insert into Stars values(94,3);
insert into Stars values(95,3);
insert into Stars values(96,3);
insert into Stars values(97,3);
insert into Stars values(98,3);
insert into Stars values(99,3);
insert into Stars values(100,3);
insert into Stars values(101,3);
insert into Stars values(102,3);
insert into Stars values(103,3);
insert into Stars values(104,3);
insert into Stars values(105,3);
insert into Stars values(106,3);
insert into Stars values(107,3);
insert into Stars values(108,3);
insert into Stars values(109,3);
insert into Stars values(110,3);
insert into Stars values(111,3);
insert into Stars values(112,3);
insert into Stars values(113,3);
insert into Stars values(114,3);
insert into Stars values(115,3);
insert into Stars values(116,3);
insert into Stars values(117,3);
insert into Stars values(118,3);
insert into Stars values(119,3);
insert into Stars values(120,3);
insert into Stars values(121,3);
insert into Stars values(122,3);
insert into Stars values(123,3);
insert into Stars values(124,3);
insert into Stars values(125,3);

--Screen Writer--
insert into ScreenWriter values(89);
insert into ScreenWriter values(90);
insert into ScreenWriter values(91);
insert into ScreenWriter values(92);

--Producer--
insert into Producer values(88);
insert into Producer values(121);
insert into Producer values(122);
insert into Producer values(123);
insert into Producer values(124);
insert into Producer values(125);

--Type of Producer--
insert into TypeOfProd(Crew_Id, Pname) values(88, 'Director');
insert into TypeOfProd(Crew_Id, Pname) values(121, 'Executive Producer');
insert into TypeOfProd(Crew_Id, Pname) values(122, 'Executive Producer');
insert into TypeOfProd(Crew_Id, Pname) values(123, 'Executive Producer');
insert into TypeOfProd(Crew_Id, Pname) values(124, 'Producer');
insert into TypeOfProd(Crew_Id, Pname) values(125, 'Producer');

--Actor--
insert into Actor values(93);
insert into Actor values(94);
insert into Actor values(95);
insert into Actor values(96);
insert into Actor values(97);
insert into Actor values(98);
insert into Actor values(99);
insert into Actor values(100);
insert into Actor values(101);
insert into Actor values(102);
insert into Actor values(103);
insert into Actor values(104);
insert into Actor values(105);
insert into Actor values(106);
insert into Actor values(107);
insert into Actor values(108);
insert into Actor values(109);
insert into Actor values(110);
insert into Actor values(111);
insert into Actor values(112);
insert into Actor values(113);
insert into Actor values(114);
insert into Actor values(115);
insert into Actor values(116);
insert into Actor values(117);
insert into Actor values(118);
insert into Actor values(119);
insert into Actor values(120);

--MovCharacter--
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Alan Parrish', 'Alan Parrish is the main character of the 1995 film, played by Robin Williams as his adult self and by Adam Hann-Byrd as his younger self.', 93);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Van Pelt/Sam Parrish', 'Van Pelt is the main antagonist of the 1995 live action fantasy film Jumanji.', 94);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Judy Shepherd', 'Judy Shepherd is one of the two tritagonists of the 1995 fantasy film, Jumanji, the other being her brother, Peter Shepherd.', 95);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Peter Shepherd', 'Peter Shepherd is one of the two tritagonists of the 1981 fantasy novel, Jumanji, and the 1995 film of the same name, the other being his sister, Judy.', 96);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Sarah Whittle', '', 97);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Nora Shepherd', '', 98);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Bentley', '', 99);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Coral Parrish', '', 100);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Young Alan', '', 101);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Young Sarah', '', 102);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Exterminator', '', 103);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Mrs. Thomas', '', 104);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Benjamin', '', 105);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Caleb', '', 106);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Billy Jessup', '', 107);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Cop', '', 108);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Bum', '', 109);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Jim Shepherd', '', 110);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Martha Shepherd', '', 111);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Gun Salesman', '', 112);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Paramedic', '', 113);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Paramedic', '', 114);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Girl', '', 115);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Girl', '', 116);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Baker', '', 117);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Pianist', '', 118);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Barber', '', 119);
insert into MovCharacter (Char_Name, Char_Desc, Crew_Id) values('Special VocalEffects', '', 120);