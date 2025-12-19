USE EquipmentAccounting;
GO

INSERT INTO EquipmentTypes (Name) VALUES 
('Ноутбук'), ('Монитор'), ('Клавиатура'), ('Мышь'), ('Принтер');

INSERT INTO Departments (Name) VALUES 
('IT-отдел'), ('Бухгалтерия'), ('HR'), ('Продажи');

INSERT INTO Employees (Name, DepartmentId, Position) VALUES 
('Иванов И.И.', 1, 'Разработчик'),
('Петров П.П.', 1, 'Системный администратор'),
('Сидорова А.А.', 2, 'Бухгалтер');

INSERT INTO Equipment (InventoryNumber, TypeId, EmployeeId, SerialNumber) VALUES 
('INV-001', 1, 1, 'SN12345'),
('INV-002', 2, 1, 'SN12346'),
('INV-003', 3, 2, 'SN12347');
GO
