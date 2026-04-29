CREATE DATABASE IF NOT EXISTS ITEMCONTROL;
USE ITEMCONTROL;
CREATE TABLE Usuarios (
    id_Usuario INT AUTO_INCREMENT NOT NULL, 
    nombre_De_Usuario VARCHAR(15) UNIQUE,
    contrasena VARCHAR(10) NOT NULL,
    fecha_De_Alta DATE NOT NULL,
    rol VARCHAR(15) NOT NULL,
    CONSTRAINT pk_id_User PRIMARY KEY (id_Usuario)
);
CREATE TABLE Promociones (
    id_Promocion DECIMAL(5,0) NOT NULL, 
    porcentaje_De_Descuento DECIMAL(3,0) NOT NULL,
    fecha_De_Inicio DATE NOT NULL,
    fecha_De_Fin DATE NOT NULL,
    estado VARCHAR(15) NOT NULL,
    CONSTRAINT pk_id_Promo PRIMARY KEY (id_Promocion)
);
CREATE TABLE Productos (
    lote_Producto DECIMAL(15,0) NOT NULL, 
    nombre_De_Producto VARCHAR(20) NOT NULL,
    fecha_De_Caducidad DATE NOT NULL,
    proveedor VARCHAR(20) NOT NULL,
    precio_De_Venta DECIMAL(5,0) NOT NULL,
    cantidad_En_Stock DECIMAL(3,0) NOT NULL,
    departamento VARCHAR(20) NOT NULL,
    marca_Del_Producto VARCHAR(20) NOT NULL,
    fecha_De_Ingreso DATE NOT NULL,
    estado VARCHAR(15) NOT NULL,
    CONSTRAINT pk_loteProd PRIMARY KEY(lote_Producto)
);
INSERT INTO Usuarios (nombre_De_Usuario, contrasena, fecha_De_Alta, rol) 
VALUES ('Prueba1', 'Prueba1', CURDATE(), 'Abarrotero');