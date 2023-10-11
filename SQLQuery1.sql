CREATE DATABASE AppointDB
GO

USE AppointDB
GO

CREATE TABLE Patients 
(
	PatientId INT PRIMARY KEY IDENTITY,
	PatientName VARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	MaritalStatus BIT,
	AppointmentDate DATE NOT NULL,
	Picture VARCHAR(MAX)
);
GO

CREATE TABLE Department
(
	DepartmentId INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(50) NOT NULL,
	DoctorName VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Appointments 
(
	AppointmentId INT PRIMARY KEY IDENTITY,
	PatientId INT REFERENCES Patients(PatientId),
	DepartmentId INT REFERENCES Department(DepartmentId)
);
GO