-- Crear base de datos (Opcional, ajusta al nombre de tu BD)
-- CREATE DATABASE EmpresaDB;
-- GO
-- USE EmpresaDB;
-- GO

-- 1. Tabla de Clientes (Catálogo)
CREATE TABLE Cliente (
    ClienteID INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Estado VARCHAR(20) DEFAULT 'Activo'
);

-- 2. Tabla de Ventas (Destino final)
CREATE TABLE Venta (
    VentaID INT PRIMARY KEY,
    ClienteID INT,
    FechaVenta DATE,
    Monto DECIMAL(12,2),
    CONSTRAINT FK_Venta_Cliente FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID)
);

-- 3. Insertar Clientes de prueba (Solo estos IDs serán válidos)
INSERT INTO Cliente (ClienteID, Nombre) VALUES 
(1001, 'Empresa Alfa'),
(1002, 'Corporación Beta'),
(1003, 'Industrias Gamma');