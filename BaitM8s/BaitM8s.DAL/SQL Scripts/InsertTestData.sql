USE BaitM8s

-- ZIPCODE
INSERT INTO Zipcode (zipcode, city) VALUES
(8000, 'Aarhus C'),
(8200, 'Aarhus N'),
(8300, 'Odder'),
(5000, 'Odense C'),
(9000, 'Aalborg');

-- POND OWNERS
INSERT INTO PondOwner 
(FirstName, LastName, Address, Email, PhoneNumber, UserName, PasswordHash, FK_ZipcodeId)
VALUES
('Lars', 'Jensen', 'Fiskevej 12', 'lars@pond.dk', '12345678', 'larsj', 'hash1', 1),
('Mette', 'Poulsen', 'Søvej 44', 'mette@pond.dk', '87654321', 'mettep', 'hash2', 2),
('Ole', 'Hansen', 'Kildebakken 3', 'ole@pond.dk', '22223333', 'oleh', 'hash3', 3),
('Tina', 'Mortensen', 'Bakkevej 88', 'tina@pond.dk', '99998888', 'tinam', 'hash4', 4),
('Jonas', 'Kristensen', 'Skovvej 7', 'jonas@pond.dk', '11112222', 'jonask', 'hash5', 5);

-- FISH SPECIES
INSERT INTO FishSpecies (Species) VALUES
('Rainbow Trout'),
('Brown Trout'),
('Pike'),
('Perch'),
('Carp');

-- FISHING SPOTS ✅ FIXED (IsAwaitingApproval added)
INSERT INTO FishingSpot 
(Name, Address, FK_zipcodeId, Longitude, Latitude, StartAvailableHours, EndAvailableHours, Capacity, HandicapFriendly, IsAwaitingApproval, FK_PondOwnerId)
VALUES
('Sølykke Fiskesø', 'Søvej 1', 1, 10.123, 56.123, 8, 16, 50, 1, 0, 1),
('Nordlys Put & Take', 'Skovvej 22', 2, 10.456, 56.234, 10, 15, 30, 0, 0, 2),
('Odder Fiskepark', 'Engvej 77', 3, 10.789, 56.345, 7, 15, 40, 1, 0, 3),
('Fyns Fiskesø', 'Parkvej 9', 4, 10.321, 55.401, 5, 13, 20, 0, 0, 4),
('Aalborg Fiskevand', 'Havnegade 3', 5, 9.921, 57.012, 10, 18, 60, 1, 0, 5);

-- FISH SPECIES / FISHING SPOT LINKS
INSERT INTO FishSpecies_FishingSpot (FK_FishSpeciesId, FK_FishingSpotId) VALUES
(1, 1),
(2, 1),
(3, 2),
(4, 3),
(5, 4);

-- ANGLERS
INSERT INTO Angler 
(FirstName, LastName, Address, Email, PhoneNumber, UserName, Password, FK_ZipCodeId)
VALUES
('Henrik', 'Kringel', 'Vej 1', 'henrik@mail.com', '44445555', 'henrik01', 'pw1', 1),
('Maria', 'Lund', 'Vej 2', 'maria@mail.com', '55556666', 'marial', 'pw2', 2),
('Thomas', 'Nielsen', 'Vej 3', 'thomas@mail.com', '22221111', 'thomasn', 'pw3', 3),
('Sara', 'Berg', 'Vej 4', 'sara@mail.com', '99990000', 'sarab', 'pw4', 4),
('Peter', 'Bro', 'Vej 5', 'peter@mail.com', '88889999', 'peterb', 'pw5', 5);

-- BOOKINGS
INSERT INTO Booking 
(Day, Month, Year, WeekNumber, NumberOfPeople, StartTime, EndTime, FK_AnglerId, FK_FishingSpotId)
VALUES
(12, 5, 2025, 20, 16, 17, 19, 1, 1),
(18, 5, 2025, 20, 10, 11, 14, 2, 2),
(23, 6, 2025, 25, 8, 9, 12, 3, 3),
(2, 7, 2025, 27, 13, 14, 17, 4, 4),
(15, 7, 2025, 29, 12, 12, 15, 5, 5);
GO