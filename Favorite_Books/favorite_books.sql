SELECT * FROM favorite_books.Romance;

INSERT INTO favorite_books.Romance( Title, Author,  Pages, Ratings, Comments)
VALUES( 'Reminders of him', 'Colleen Hoover', 335, 8, ' page turner!');

DELETE FROM favorite_books.Romance WHERE idRomance = 2;

SELECT * FROM favorite_books.Mystery;

INSERT INTO favorite_books.Mystery( Title, Author, Pages, Ratings, Comments)
VALUES( "Don't Let her stay", 'Nicola Sanders', 284, 10, 'A complete plot twister!');

SELECT * FROM favorite_books.Fiction;

INSERT INTO favorite_books.Fiction( Title, Author, Pages, Ratings, Comments)
VALUES( 'Diary of a Wimpy Kid', 'Jeff Kinney', 228, 9, 'Such a CLASSIC!');

SELECT * FROM favorite_books.Comics;

INSERT INTO favorite_books.Comics( Title, Author, Pages, Ratings, Comments)
VALUES( 'Misplaced Vol. 1', 'Josh Blaylock', 100, 6, 'It was good, but I needed more.') ;

SELECT * FROM favorite_books.Biography;

INSERT INTO favorite_books.Biography( Title, Author, Pages, Ratings, Comments)
VALUES( "It's not about You", 'Tom Rath', 38, 10, 'Thought provoking.') 