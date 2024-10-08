USE [master]
GO

CREATE DATABASE [manilab_uab]
GO

USE [manilab_uab]
GO

CREATE TABLE [dbo].[usuario](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[FechaNacimiento] [date] NULL,
	[Sexo] [bit] NULL,
)
GO

CREATE TABLE [dbo].[todoApp](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Visible] [bit] NULL,
	[Estado] [bit] NULL,
	[FechaCreacion] [date] NULL,
	[FechaActualizacion] [date] NULL,
	[IdUsuario] [int] NULL,
	FOREIGN KEY (IdUsuario) REFERENCES usuario(Id)
)
GO

INSERT [dbo].[usuario] ([Nombre], [Apellido], [FechaNacimiento], [Sexo]) VALUES (N'Tommy', N'BLACK', CAST(N'2024-09-12' AS Date), 1)
INSERT [dbo].[usuario] ([Nombre], [Apellido], [FechaNacimiento], [Sexo]) VALUES (N'Chipi', N'BLACK & WHITE', CAST(N'2024-09-10' AS Date), 0)
INSERT [dbo].[usuario] ([Nombre], [Apellido], [FechaNacimiento], [Sexo]) VALUES (N'Jack', N'BLACK & WHITE', CAST(N'2020-09-01' AS Date), 1)
GO

DECLARE @UserId INT
SET @UserId = SELECT TOP(1) id FROM usuario

INSERT [dbo].[todoApp] ([Descripcion], [Visible], [Estado], [FechaCreacion], [FechaActualizacion], [IdUsuario]) VALUES (N'Mi primera tarea', 1, 1, CAST(N'2020-12-08' AS Date), CAST(N'2024-12-08' AS Date), @UserId)
INSERT [dbo].[todoApp] ([Descripcion], [Visible], [Estado], [FechaCreacion], [FechaActualizacion], [IdUsuario]) VALUES (N'test 21082024', 1, 1, CAST(N'2024-08-21' AS Date), CAST(N'2024-08-21' AS Date), @UserId)
INSERT [dbo].[todoApp] ([Descripcion], [Visible], [Estado], [FechaCreacion], [FechaActualizacion], [IdUsuario]) VALUES (N'test fom net Core 21082024', 1, 1, CAST(N'2024-08-22' AS Date), CAST(N'2024-08-22' AS Date), @UserId)
INSERT [dbo].[todoApp] ([Descripcion], [Visible], [Estado], [FechaCreacion], [FechaActualizacion], [IdUsuario]) VALUES (N'test fom net Core 21082024', 0, 1, CAST(N'2000-03-04' AS Date), CAST(N'2024-08-22' AS Date), @UserId)
INSERT [dbo].[todoApp] ([Descripcion], [Visible], [Estado], [FechaCreacion], [FechaActualizacion], [IdUsuario]) VALUES (N'guardando el id 1008', 1, 0, CAST(N'2024-08-22' AS Date), CAST(N'2024-08-22' AS Date), @UserId)
INSERT [dbo].[todoApp] ([Descripcion], [Visible], [Estado], [FechaCreacion], [FechaActualizacion], [IdUsuario]) VALUES (N'guardando nuevo dato', 1, 1, CAST(N'2024-08-26' AS Date), CAST(N'2024-08-26' AS Date), @UserId)
INSERT [dbo].[todoApp] ([Descripcion], [Visible], [Estado], [FechaCreacion], [FechaActualizacion], [IdUsuario]) VALUES (N'Hola mundo desde postman', 0, 1, CAST(N'2000-01-01' AS Date), CAST(N'0001-01-01' AS Date), @UserId)
INSERT [dbo].[todoApp] ([Descripcion], [Visible], [Estado], [FechaCreacion], [FechaActualizacion], [IdUsuario]) VALUES (N'Tarea de clase 002', 1, 0, CAST(N'2024-09-02' AS Date), CAST(N'2024-09-02' AS Date), @UserId)
GO