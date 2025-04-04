CREATE DATABASE Productos;

USE Productos;

CREATE TABLE TiposProducto (
    TipoProductoID INT IDENTITY(1,1) PRIMARY KEY,
    NombreTipo VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE FormasPago (
    FormaPagoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) UNIQUE NOT NULL,
    Factor DECIMAL(5, 4)
);

CREATE TABLE Productos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) UNIQUE NOT NULL,
    Descripcion TEXT,
    TipoProductoID INT,
    FormaPagoID INT,  -- Relación directa con FormasPago
    PrimaAnual DECIMAL(18, 2) CHECK (PrimaAnual <= 300.00),
    SumaAsegurada DECIMAL(18, 2),
    CHECK (PrimaAnual < SumaAsegurada),
    FOREIGN KEY (TipoProductoID) REFERENCES TiposProducto(TipoProductoID),
    FOREIGN KEY (FormaPagoID) REFERENCES FormasPago(FormaPagoID)  -- Relación con FormasPago
);


-- Insertar datos en la tabla TiposProducto
INSERT INTO TiposProducto (NombreTipo) VALUES
('Auto'),
('Salud'),
('Accidentes Personales'),
('Vida'),
('Residencial'),
('Fianzas');

-- Insertar datos en la tabla FormasPago con sus factores generales
INSERT INTO FormasPago (Nombre, Factor) VALUES
('Anual', 1.0000),        -- Pago único anual
('Mensual', 1.0000 / 12), -- Pago dividido en 12 meses
('Trimestral', 1.0000 / 4),-- Pago dividido en 4 trimestres
('Semestral', 1.0000 / 2); -- Pago dividido en 2 semestres

-- Verificar los datos insertados (opcional)
SELECT * FROM TiposProducto;
SELECT * FROM FormasPago;