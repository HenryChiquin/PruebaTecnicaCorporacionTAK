USE [PruebaTecnicaTakDB]
GO
/****** Object:  Table [dbo].[COLABORADOR]    Script Date: 9/05/2023 21:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COLABORADOR](
	[IdColaborador] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[EstadoCivil] [varchar](20) NOT NULL,
	[GradoAcademico] [varchar](200) NOT NULL,
	[Direccion] [varchar](max) NULL,
 CONSTRAINT [PK_COLABORADOR] PRIMARY KEY CLUSTERED 
(
	[IdColaborador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[COLABORADOR] ON 

INSERT [dbo].[COLABORADOR] ([IdColaborador], [Nombres], [Apellidos], [FechaNacimiento], [EstadoCivil], [GradoAcademico], [Direccion]) VALUES (4, N'Karla Marleny', N'Nuevo apodo', CAST(N'2023-05-14T00:00:00.000' AS DateTime), N'Viudo', N'Universitario', N'Ciudad de Guatemala')
SET IDENTITY_INSERT [dbo].[COLABORADOR] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_COLABORADOR]    Script Date: 9/05/2023 21:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---UPDATE
CREATE PROC [dbo].[SP_ACTUALIZAR_COLABORADOR]
@idColaborador int,
@nombres varchar (100),
@apellidos varchar (100),
@fechaNacimiento datetime,
@estadoCivil varchar (20),
@gradoAcademico varchar (200),
@direccion varchar (MAX)
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE COLABORADOR
	SET Nombres = @nombres, Apellidos = @apellidos, FechaNacimiento = @fechaNacimiento, EstadoCivil = @estadoCivil, GradoAcademico = @gradoAcademico, Direccion = @direccion
	WHERE IdColaborador = @idColaborador
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_COLABORADOR]    Script Date: 9/05/2023 21:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---DELETE
CREATE PROC [dbo].[SP_ELIMINAR_COLABORADOR]
@idColaborador int
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE FROM COLABORADOR WHERE IdColaborador=@idColaborador
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_COLABORADOR]    Script Date: 9/05/2023 21:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---INSERT
CREATE PROC [dbo].[SP_INSERTAR_COLABORADOR]
@nombres varchar (100),
@apellidos varchar (100),
@fechaNacimiento datetime,
@estadoCivil varchar (20),
@gradoAcademico varchar (200),
@direccion varchar (MAX)
AS
BEGIN
	SET NOCOUNT ON;
	
	Insert into COLABORADOR(Nombres, Apellidos, FechaNacimiento, EstadoCivil, GradoAcademico, Direccion)
	Values (@nombres,@apellidos,@fechaNacimiento, @estadoCivil, @gradoAcademico, @direccion)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_COLABORADOR]    Script Date: 9/05/2023 21:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LISTA_COLABORADOR]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM COLABORADOR
END
GO
