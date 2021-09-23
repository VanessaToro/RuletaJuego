USE Autenticacion
GO

----------------------------------------------------------------------
--CREAR TABLA ROLES
----------------------------------------------------------------------
CREATE TABLE Roles
(
  Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
  Nombre VARCHAR (50) not null
)
GO
 

---------------------------------------------------------------------
--CREAR TABLA PERMISOS
----------------------------------------------------------------------
CREATE TABLE Permisos
(
  Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
  Nombre VARCHAR (50) not null,
  Descripcion NVARCHAR(200)
)
GO


----------------------------------------------------------------------
--CREAR TABLA PERMISOS_ROLES
----------------------------------------------------------------------
CREATE TABLE PermisosRoles
(
  Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
  Rolid UNIQUEIDENTIFIER not null,
  PermisoId UNIQUEIDENTIFIER not null

  CONSTRAINT fk_Rol FOREIGN KEY (Rolid) REFERENCES Roles (Id),
  CONSTRAINT fk_Permiso FOREIGN KEY (PermisoId) REFERENCES Permisos (Id),
)
GO

---------------------------------------------------------------------
--CREAR TABLA USUARIOS
----------------------------------------------------------------------
CREATE TABLE Usuarios
(
  Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
  NumeroIdentificacion VARCHAR(50) not null,
  Nombres VARCHAR (50) not null,
  Apellidos VARCHAR (80) not null,
  NombreCompleto VARCHAR (200) not null,
  Direccion NVARCHAR(200) not null,
  NumeroContacto VARCHAR(20) not null,
  FechaNacimiento Date not null,
  Usuario NVARCHAR(15) not null,
  Clave NVARCHAR(100) not null,
  RolId UNIQUEIDENTIFIER not null,
  FechaCracionRegistro DateTime not null,
  FechaUltimaActualziacion DateTime null,
  UsuarioModifico NVARCHAR(15) NULL,
  Estado BIT

  CONSTRAINT fk_RolUsuario FOREIGN KEY (Rolid) REFERENCES Roles (Id),
)
GO



---------------------------------------------------------------------
--INSERTAR DATOS INICIALES
----------------------------------------------------------------------
Declare @rolVisitante varchar(50) = 'Visitante'
Declare @rolAsistente varchar(50) = 'Asistente'
Declare @rolEditor varchar(50) = 'Editor'
Declare @rolAdministrador varchar(50) = 'Administrador'
Declare @permisoVer varchar(50) = 'Ver'
Declare @permisoFiltrar varchar(50) = 'Filtrar'
Declare @permisoEditar varchar(50) = 'Editar'
Declare @permisoCrear varchar(50) = 'Crear'
Declare @permisoEliminar varchar(50) = 'permisoEliminar'

------------------------Roles---------------------------------
INSERT INTO Roles VALUES (default, @rolVisitante)
INSERT INTO Roles VALUES (default,@rolAsistente)
INSERT INTO Roles VALUES (default, @rolEditor)
INSERT INTO Roles VALUES (default,@rolAdministrador)
-------------------------------------------------------------

----------------------Permisos--------------------------------
 
INSERT INTO Permisos VALUES (default, @permisoVer, 'Visualizar mensajes y contenido')
INSERT INTO Permisos VALUES (default, @permisoFiltrar, 'Consultar la información usando filtros')
INSERT INTO Permisos VALUES (default, @permisoEditar, 'Actualizar datos personales usuario')
INSERT INTO Permisos VALUES (default, @permisoCrear, 'Crear registro usuario nuevos')
INSERT INTO Permisos VALUES (default, @permisoEliminar, 'Eliminar registro usuario')
------------------------------------------------------------------------------------------------

-------------------------Permisos por Rol-----------------------------------------------------------------------------
INSERT INTO PermisosRoles 
VALUES (default,(Select Id from Roles where Nombre = @rolVisitante), (Select Id from Permisos where Nombre = @permisoVer))
INSERT INTO PermisosRoles 
VALUES (default,(Select Id from Roles where Nombre = @rolAsistente), (Select Id from Permisos where Nombre = @permisoFiltrar))
INSERT INTO PermisosRoles 
VALUES (default,(Select Id from Roles where Nombre = @rolEditor), (Select Id from Permisos where Nombre = @permisoEditar))
INSERT INTO PermisosRoles 
VALUES (default,(Select Id from Roles where Nombre = @rolAdministrador), (Select Id from Permisos where Nombre = @permisoCrear))
INSERT INTO PermisosRoles 
VALUES (default,(Select Id from Roles where Nombre = @rolAdministrador), (Select Id from Permisos where Nombre = @permisoEliminar))