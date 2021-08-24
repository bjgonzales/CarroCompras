CREATE PROCEDURE Pr_Insertar_Cliente(@nombre VARCHAR(255), @apellido VARCHAR(255), @correo VARCHAR(255), @fechanacimiento VARCHAR(20), @sueldo DECIMAL(10, 4), @edad INT)
AS
BEGIN
	INSERT INTO Clientes(Nombre, Apellido, Correo, FechaNacimiento, Sueldo, Edad)
	VALUES(@nombre, @apellido, @correo, @fechanacimiento, @sueldo, @edad)
END
GO

CREATE PROCEDURE Pr_Eliminar_Cliente(@id INT)
AS
BEGIN
	DELETE FROM Clientes
	WHERE Id = @id
END
GO

CREATE PROCEDURE Pr_Actualizar_Cliente(@id INT, @nombre VARCHAR(255), @apellido VARCHAR(255), @correo VARCHAR(255), @fechanacimiento VARCHAR(20), @sueldo DECIMAL(10, 4), @edad INT)
AS
BEGIN
	UPDATE Clientes
	SET Nombre = @nombre,
		Apellido = @apellido,
		Correo = @correo,
		FechaNacimiento = @fechanacimiento,
		Sueldo = @sueldo,
		Edad = @edad
	WHERE Id = @id
END
GO

CREATE PROCEDURE Pr_Listar_Cliente
AS
BEGIN
	SELECT Id, Nombre, Apellido, Correo, FechaNacimiento, Sueldo, Edad FROM Clientes
END
GO

CREATE PROCEDURE Pr_Obtener_Cliente(@id INT)
AS
BEGIN
	SELECT Nombre, Apellido, Correo, FechaNacimiento, Sueldo, Edad
	FROM Clientes
	WHERE Id = @id
END
GO