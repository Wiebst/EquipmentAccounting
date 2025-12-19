CREATE DATABASE EquipmentAccounting;
GO

USE EquipmentAccounting;
GO

CREATE TABLE EquipmentTypes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    DepartmentId INT,
    Position NVARCHAR(50),
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

CREATE TABLE Equipment (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    InventoryNumber NVARCHAR(50) UNIQUE NOT NULL,
    TypeId INT,
    EmployeeId INT NULL,
    SerialNumber NVARCHAR(50),
    FOREIGN KEY (TypeId) REFERENCES EquipmentTypes(Id),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

CREATE INDEX IX_Equipment_InventoryNumber ON Equipment(InventoryNumber);
GO
