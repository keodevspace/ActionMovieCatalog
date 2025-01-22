CREATE TABLE Users (
    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE,
    PasswordHash TEXT NOT NULL,
    Role TEXT NOT NULL
);

-- Insert default admin user
INSERT INTO Users (Username, PasswordHash, Role)
VALUES ('admin', 'admin123', 'Admin');

-- Create Movies table
CREATE TABLE Movies (
    MovieId INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    ReleaseYear INTEGER NOT NULL,
    Director TEXT NOT NULL,
    Rating REAL NOT NULL
);

-- Insert 50 action movies
INSERT INTO Movies (Title, ReleaseYear, Director, Rating) VALUES

('Rocky', 1976, 'John G. Avildsen', 8.1),
('Rambo: First Blood', 1982, 'Ted Kotcheff', 7.7),
('Rocky II', 1979, 'Sylvester Stallone', 7.3),
('Rambo: First Blood Part II', 1985, 'George P. Cosmatos', 6.5),
('Rocky III', 1982, 'Sylvester Stallone', 6.8),
('Rambo III', 1988, 'Peter MacDonald', 5.8),
('Rocky IV', 1985, 'Sylvester Stallone', 6.9),
('Cliffhanger', 1993, 'Renny Harlin', 6.4),
('Demolition Man', 1993, 'Marco Brambilla', 6.7),
('The Expendables', 2010, 'Sylvester Stallone', 6.4),
('The Terminator', 1984, 'James Cameron', 8.1),
('Terminator 2: Judgment Day', 1991, 'James Cameron', 8.6),
('Commando', 1985, 'Mark L. Lester', 6.7),
('Predator', 1987, 'John McTiernan', 7.8),
('Total Recall', 1990, 'Paul Verhoeven', 7.5),
('True Lies', 1994, 'James Cameron', 7.3),
('Conan the Barbarian', 1982, 'John Milius', 6.9),
('Conan the Destroyer', 1984, 'Richard Fleischer', 5.9),
('Eraser', 1996, 'Chuck Russell', 6.1),
('The Running Man', 1987, 'Paul Michael Glaser', 6.7),
('Bloodsport', 1988, 'Newt Arnold', 6.8),
('Kickboxer', 1989, 'Mark DiSalle', 6.4),
('Universal Soldier', 1992, 'Roland Emmerich', 6.1),
('Timecop', 1994, 'Peter Hyams', 5.9),
('Hard Target', 1993, 'John Woo', 6.2),
('Lionheart', 1990, 'Sheldon Lettich', 6.2),
('Double Impact', 1991, 'Sheldon Lettich', 5.6),
('Street Fighter', 1994, 'Steven E. de Souza', 4.0),
('Sudden Death', 1995, 'Peter Hyams', 5.8),
('The Quest', 1996, 'Jean-Claude Van Damme', 5.6),
('Die Hard', 1988, 'John McTiernan', 8.2),
('Mad Max: Fury Road', 2015, 'George Miller', 8.1),
('Lethal Weapon', 1987, 'Richard Donner', 7.6),
('The Matrix', 1999, 'The Wachowskis', 8.7),
('Gladiator', 2000, 'Ridley Scott', 8.5),
('The Dark Knight', 2008, 'Christopher Nolan', 9.0),
('John Wick', 2014, 'Chad Stahelski', 7.4),
('Speed', 1994, 'Jan de Bont', 7.3),
('Taken', 2008, 'Pierre Morel', 7.8),
('The Equalizer', 2014, 'Antoine Fuqua', 7.2),
('Mission: Impossible', 1996, 'Brian De Palma', 7.1),
('The Bourne Identity', 2002, 'Doug Liman', 7.9),
('300', 2006, 'Zack Snyder', 7.6),
('Skyfall', 2012, 'Sam Mendes', 7.8),
('Edge of Tomorrow', 2014, 'Doug Liman', 7.9),
('Casino Royale', 2006, 'Martin Campbell', 8.0),
('The Avengers', 2012, 'Joss Whedon', 8.0);
