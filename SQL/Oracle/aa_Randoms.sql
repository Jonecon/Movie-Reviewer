Select * FROM AppUser;
Select Count(*) FROM AppUser;
Select * FROM AppUser WHERE email = '';

Select * FROM Movie WHERE movie_id > 199979;
Select MOVIE_ID, TITLE, MOVIEIMG  FROM Movie WHERE movieimg is Null; 
Select Count(*) FROM Movie;
Select * FROM Movie WHERE movie_id = 31005;
Select * FROM Movie WHERE title = 'Nickelodeon';
SET DEFINE OFF

Select * FROM Genre;

SELECT Title, movieimg  FROM Movie;
SELECT Title, movieimg FROM Movie FETCH NEXT 30 ROWS ONLY;

DELETE FROM movie WHERE title = 'Your Name';
DELETE FROM movie WHERE title = 'Spirited Away';

insert into Movie (title, summary, releaseyear, movieduration) values ('Running', 'Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero.', DATE '1961-08-30', 114);
insert into Movie (title, summary, releaseyear, movieduration) values ('Somers Town', 'Nullam varius. Nulla facilisi.', DATE '1961-05-10', 82);
insert into Movie (title, summary, releaseyear, movieduration) values ('Devil and Daniel Johnston, The', 'Mauris lacinia sapien quis libero.', DATE '1801-04-17', 141);
insert into Movie (title, summary, releaseyear, movieduration) values ('Dark Angel: Ascent, The', 'Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis. Fusce posuere felis sed lacus.', DATE '1933-03-21', 83);
insert into Movie (title, summary, releaseyear, movieduration) values ('Atrocious', 'Praesent blandit lacinia erat.', DATE '1926-09-05', 54);
insert into Movie (title, summary, releaseyear, movieduration) values ('Friends of God: A Road Trip with Alexandra Pelosi', 'Aenean auctor gravida sem. Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo.', DATE '1882-03-02', 69);
insert into Movie (title, summary, releaseyear, movieduration) values ('Red Army', 'Nam nulla.', DATE '1960-06-25', 149);
insert into Movie (title, summary, releaseyear, movieduration) values ('One Missed Call (Chakushin ari)', 'Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis.', DATE '1894-12-21', 87);
insert into Movie (title, summary, releaseyear, movieduration) values ('Marseillaise, La', 'Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.', DATE '1834-01-18', 93);
insert into Movie (title, summary, releaseyear, movieduration) values ('Inside (À l''intérieur)', 'Nulla justo. Aliquam quis turpis eget elit sodales scelerisque.', DATE '1920-02-14', 90);

UPDATE Movie SET movieimg = 'Imgs\\AsheLOL.jpg' WHERE movie_id = 11;
UPDATE Movie SET movieimg = 'Imgs\\Ciri.jpg' WHERE movie_id = 12;
UPDATE Movie SET movieimg = 'Imgs\\SylvanasWOW.jpg' WHERE movie_id = 13;
UPDATE Movie SET movieimg = 'Imgs\\DravenLOL.jpg' WHERE movie_id = 14;
UPDATE Movie SET movieimg = 'Imgs\\CiriAndGeralt.jpg' WHERE movie_id = 15;
UPDATE Movie SET movieimg = 'Imgs\\TyrandeWOW.jpg' WHERE movie_id = 16;
UPDATE Movie SET movieimg = 'Imgs\\MissFortuneLOL.jpg' WHERE movie_id = 17;
UPDATE Movie SET movieimg = 'Imgs\\CiriSit.jpg' WHERE movie_id = 18;
UPDATE Movie SET movieimg = 'Imgs\\UzumakiFamily.jpg' WHERE movie_id = 19;
UPDATE Movie SET movieimg = 'Imgs\\XayahLOL.jpg' WHERE movie_id = 20;

COMMIT;