CREATE DATABASE manilab_academico

GO
USE manilab_academico

GO
CREATE TABLE Usuario (
	Id INT PRIMARY KEY IDENTITY(1,1),
	NombreCompleto NVARCHAR(100) NULL,
	Codigo NVARCHAR(255) NULL
)
CREATE TABLE Materia (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(100) NULL,
	Descripcion NVARCHAR(255) NULL
)
CREATE TABLE Asignatura (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Total MONEY NOT NULL,
	Descripcion NVARCHAR(255) NULL,
	MateriaId INT NOT NULL,
	UsuarioId INT NOT NULL,
	FOREIGN KEY (MateriaId) REFERENCES Materia(Id),
	FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id),
)