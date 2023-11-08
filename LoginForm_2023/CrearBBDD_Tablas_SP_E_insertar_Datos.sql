--Crear BBDD
CREATE DATABASE MULTISYSTEM;
GO

USE MULTISYSTEM;
GO


CREATE TABLE UsuariosMS (
    ID_user INT IDENTITY(1, 1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password_Hash NVARCHAR(128) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Fecha_Reg DATETIME NOT NULL,
    Estado INT NOT NULL, -- 1 para habilitado, 0 para bloqueado
    Intentos_Fallidos INT NOT NULL
);

GO

CREATE TABLE Configuracion (
    Nombre_Empresa NVARCHAR(100)
	,ruta_logo  NVARCHAR(200)
	,estado_Empresa int
);
GO





-- Crear un procedimiento almacenado para insertar un nuevo usuario 
CREATE PROCEDURE sp_Insertar_Nuevo_Usuario
    @Username NVARCHAR(50),
    @Password_Hash NVARCHAR(128),
    @Email NVARCHAR(100)
AS
BEGIN
    -- Insertar el nuevo usuario con la clave aplicada al hash
    INSERT INTO UsuariosMS (Username, Password_Hash, Email, Fecha_Reg, Estado, Intentos_Fallidos)
    VALUES (@Username, @Password_Hash, @Email, GETDATE(), 1, 0);
END;


INSERT INTO Configuracion (Nombre_Empresa,ruta_logo,estado_Empresa)
VALUES ('NINCAT Services','C:\APPAIEP\Login\LoginForm\LoginForm\nincat.png',1);
GO

INSERT INTO Configuracion (Nombre_Empresa,ruta_logo,estado_Empresa)
VALUES ('LALA Tester','C:\APPAIEP\Login\LoginForm\LoginForm\lalatester.png',0);
GO


-- Ejecutar el procedimiento almacenado para insertar un nuevo usuario
EXEC sp_Insertar_Nuevo_Usuario 'nproboste', '902ed675b8e7f73db48be3d6e22cc793243ccbe4559afb52dd132433e307257c', 'nproboste@gmail.com';
EXEC sp_Insertar_Nuevo_Usuario 'lalbornoz', 'ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f', 'lalbornoz@gmail.com';
EXEC sp_Insertar_Nuevo_Usuario 'mespinosa', '459548b889a12787c59976a3948a26f86a5372338f5e31fad58871d9a1e46f61', 'mespinosa@gmail.com';


/* Listado de Password
Para usuario nproboste: clave: passlala hash: 902ed675b8e7f73db48be3d6e22cc793243ccbe4559afb52dd132433e307257c
Para usuario lalbornoz: clave: password123 hash: ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f
Para usuario mespinosa: clave: Mea589 hash:   459548b889a12787c59976a3948a26f86a5372338f5e31fad58871d9a1e46f61
*/



SELECT * FROM UsuariosMS;
SELECT * FROM Configuracion;
------Habilitar la empresa que desee
update Configuracion 
Set estado_Empresa=1 where Nombre_Empresa='NINCAT Services'

------deshabilitar la empresa que desee
update Configuracion 
Set estado_Empresa=0 where Nombre_Empresa='LALA Tester'



SELECT top 1 Nombre_Empresa, ruta_logo FROM Configuracion WHERE estado_Empresa = 1