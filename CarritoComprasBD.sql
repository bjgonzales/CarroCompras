CREATE DATABASE CarroComprasBD
GO

USE CarroComprasBD
GO

CREATE TABLE Clientes
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Nombre VARCHAR(255),
	Apellido VARCHAR(255),
	Correo VARCHAR(255),
	FechaNacimiento DATETIME,
	Sueldo DECIMAL(10, 4),
	Edad INT
)
GO

INSERT INTO Clientes(Nombre, Apellido, Correo, FechaNacimiento, Sueldo, Edad)
VALUES('Billy', 'Gonzales', 'bjgonzalesm@gmail.com', 28/05/1987, 3500, 34)