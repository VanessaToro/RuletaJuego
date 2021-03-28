CREATE DATABASE Inventrio
GO

USE [Inventario]
GO

/****** Object:  Table [dbo].[TipoMovimiento]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoMovimiento](
	[Id] [uniqueidentifier] NOT NULL,
	[Codigo] [int] NOT NULL,
	[Descripcion] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TipoMovimiento] ADD  CONSTRAINT [DF_TipoMovimiento_Id]  DEFAULT (newid()) FOR [Id]
GO

/****** Fin  ******/

USE [Inventario]
GO

/****** Object:  Table [dbo].[Empleado] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Empleado](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[Apellidos] [nvarchar](60) NOT NULL,
	[DocumentoIdentificacion] [nvarchar](20) NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaUltimaActualizacion] [datetime] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Empleado] ADD  CONSTRAINT [DF_Empleado_Id]  DEFAULT (newid()) FOR [Id]
GO

/****** FIN ******/

USE [Inventario]
GO

/****** Object:  Table [dbo].[Producto]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Producto](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
	[Sku] [nvarchar](6) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[FechaUltimaActualizacion] [datetime2](7) NOT NULL,
	[PrecioUnitario] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_Id]  DEFAULT (newid()) FOR [Id]
GO

/****** FIN ******/

USE [Inventario]
GO

/****** Object:  Table [dbo].[Bodega]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bodega](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
	[Ubicacion] [nvarchar](80) NOT NULL,
	[CapacidadMaxima] [int] NOT NULL,
	[EmpleadoId] [uniqueidentifier] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[FechaUltimaActualizacion] [datetime2](7) NOT NULL,
	[Activa] [bit] NOT NULL,
 CONSTRAINT [PK_Bodega] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Bodega] ADD  CONSTRAINT [DF_Bodega_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Bodega]  WITH CHECK ADD FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleado] ([Id])
GO

/****** FIN ******/

USE [Inventario]
GO

/****** Object:  Table [dbo].[ProductosBodega]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductosBodega](
	[Id] [uniqueidentifier] NOT NULL,
	[BodegaId] [uniqueidentifier] NULL,
	[ProductoId] [uniqueidentifier] NULL,
	[CantidadDisponible] [int] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaUltimaActualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProductosBodega] ADD  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[ProductosBodega]  WITH CHECK ADD FOREIGN KEY([BodegaId])
REFERENCES [dbo].[Bodega] ([Id])
GO

ALTER TABLE [dbo].[ProductosBodega]  WITH CHECK ADD FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
GO

/****** FIN ******/

USE [Inventario]
GO

/****** Object:  Table [dbo].[Movimientos]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movimientos](
	[Id] [uniqueidentifier] NOT NULL,
	[FechaMovimiento] [datetime2](7) NOT NULL,
	[TipoMovimientoId] [uniqueidentifier] NOT NULL,
	[BodegaId] [uniqueidentifier] NOT NULL,
	[ProductoId] [uniqueidentifier] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[EmpleadoId] [uniqueidentifier] NOT NULL,
	[ValorTotal] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Movimientos] ADD  CONSTRAINT [DF_Movimiento_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD FOREIGN KEY([BodegaId])
REFERENCES [dbo].[Bodega] ([Id])
GO

ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleado] ([Id])
GO

ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
GO

ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD FOREIGN KEY([TipoMovimientoId])
REFERENCES [dbo].[TipoMovimiento] ([Id])
GO

/****** FIN ******/


USE [Inventario]
GO
/****** Crear tipos de movimientos  ******/
INSERT INTO [dbo].[TipoMovimiento]
           ([Codigo]
           ,[Descripcion])
     VALUES
           (1,
		   'Ingreso'),
		   (2,
		   'Salida')
GO

