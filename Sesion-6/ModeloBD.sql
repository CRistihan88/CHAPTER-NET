-- Crear la base de datos
CREATE DATABASE SistemaVentas;
GO

USE SistemaVentas;
GO

-- 1. Tabla Categorias 
CREATE TABLE Categorias (
    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255)
);

-- 2. Tabla Productos 
CREATE TABLE Productos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    CategoriaID INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Productos_Categorias FOREIGN KEY (CategoriaID) 
        REFERENCES Categorias(CategoriaID)
);

-- 3. Tabla Clientes
CREATE TABLE Clientes (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto NVARCHAR(150) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Telefono NVARCHAR(20)
);

-- 4. Tabla Ordenes
CREATE TABLE Ordenes (
    OrdenID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT NOT NULL,
    FechaOrden DATETIME NOT NULL DEFAULT GETDATE(),
    Total DECIMAL(10, 2) DEFAULT 0.00,
    CONSTRAINT FK_Ordenes_Clientes FOREIGN KEY (ClienteID) 
        REFERENCES Clientes(ClienteID)
);

-- 5. Tabla OrdenDetalle 
CREATE TABLE OrdenDetalle (
    OrdenID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (OrdenID, ProductoID), -- Clave primaria compuesta
    CONSTRAINT FK_Detalle_Ordenes FOREIGN KEY (OrdenID) 
        REFERENCES Ordenes(OrdenID) ON DELETE CASCADE,
    CONSTRAINT FK_Detalle_Productos FOREIGN KEY (ProductoID) 
        REFERENCES Productos(ProductoID)
);
GO