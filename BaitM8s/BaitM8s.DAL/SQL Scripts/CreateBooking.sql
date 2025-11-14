﻿-- Opret tabel
CREATE TABLE Booking (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BookingNumber NVARCHAR(50) NOT NULL,
    Pond NVARCHAR(100) NOT NULL,
    TimeSlots NVARCHAR(50),
    Date DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    NumberOfPeople INT NOT NULL
);