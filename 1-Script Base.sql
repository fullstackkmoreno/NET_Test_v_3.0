/*
	drop table poliza
	drop table TipoIdentificacion
*/


CREATE TABLE Estados(
    IdEstado int identity(1,1) NOT NULL,
	Nombre varchar(250) NOT NULL,
	Descripcion varchar(250) NOT NULL,
	CONSTRAINT PK_IdEstado PRIMARY KEY (IdEstado)
	
);

INSERT INTO Estados (Nombre, Descripcion) SELECT 'No Publicada', 'No Publicada';
INSERT INTO Estados (Nombre, Descripcion) SELECT 'Aprobación Pendiente', 'Aprobación Pendiente';
INSERT INTO Estados (Nombre, Descripcion) SELECT 'Aprobada', 'Aprobada';
INSERT INTO Estados (Nombre, Descripcion) SELECT 'Rechazada', 'Rechazada';
INSERT INTO Estados (Nombre, Descripcion) SELECT 'Desbloqueada', 'Desbloqueada';
truncate table Estados
GO

CREATE TABLE Publicaciones(
    IdPublicacion int identity(1,1) NOT NULL,
	Titulo varchar(250) NOT NULL,
	Texto varchar(250) NOT NULL,
	Fecha datetime NOT NULL,
	Autor varchar(250) NOT NULL,
	[EstadoIdEstado] int NOT NULL,
	[Activo] [bit] NOT NULL,
	CONSTRAINT PK_IdPublicacion PRIMARY KEY (IdPublicacion),
	CONSTRAINT FK_PublicacionEstado FOREIGN KEY ([EstadoIdEstado]) REFERENCES Estados(IdEstado)
	
);
truncate table Publicaciones
GO
select * from Publicaciones
INSERT INTO Publicaciones (Titulo, Texto, Fecha, Autor, EstadoIdEstado, Activo) SELECT 'Titulo 1', 'Texto 1', convert(datetime,'18-06-12 10:34:09 PM',5), 'Autor 1', 1, 1;
INSERT INTO Publicaciones (Titulo, Texto, Fecha, Autor, EstadoIdEstado, Activo) SELECT 'Titulo 2', 'Texto 2', convert(datetime,'18-06-12 10:34:09 PM',5), 'Autor ', 2, 1;
INSERT INTO Publicaciones (Titulo, Texto, Fecha, Autor, EstadoIdEstado, Activo) SELECT 'Titulo 3', 'Texto 3', convert(datetime,'18-06-12 10:34:09 PM',5), 'Autor 1', 3, 1;
GO

CREATE TABLE Comentarios(
	[IdComentario] [int] IDENTITY(1,1) NOT NULL,
	[PublicacionIdPublicacion] [int] NOT NULL,
	[Texto] [nvarchar](max) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Autor] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
	CONSTRAINT PK_IdComentario PRIMARY KEY (IdComentario),
	CONSTRAINT FK_PublicacionComentario FOREIGN KEY ([PublicacionIdPublicacion]) REFERENCES Publicaciones(IdPublicacion)
);
truncate table Comentarios
GO

INSERT INTO Comentarios ([PublicacionIdPublicacion], Texto, Fecha, Autor, Activo) SELECT 1, 'Texto 1', convert(datetime,'18-06-12 10:34:09 PM',5), 'Autor 1', 1;
INSERT INTO Comentarios ([PublicacionIdPublicacion], Texto, Fecha, Autor, Activo) SELECT 1, 'Texto 2', convert(datetime,'18-06-12 10:34:09 PM',5), 'Autor 2', 1;


