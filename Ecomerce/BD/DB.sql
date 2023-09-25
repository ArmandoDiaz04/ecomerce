Use master;
go
DROP DATABASE Ecommerce5
go
CREATE DATABASE Ecommerce5
GO
USE Ecommerce5;
GO

-- Crear tabla 'carrito'
CREATE TABLE carrito (
  id_carrito INT IDENTITY(1,1) PRIMARY KEY,
  id_usuario INT NOT NULL,
  id_producto INT NOT NULL,
  cantidad INT NOT NULL,
  fecha_agregado DATETIME NOT NULL DEFAULT GETDATE()
);

-- Crear tabla 'categoria'
CREATE TABLE categoria (
  id_categoria INT IDENTITY(1,1) PRIMARY KEY,
  descripcion VARCHAR(50) NOT NULL,
  estado INT NOT NULL
);

-- Crear tabla 'detalle_pedido'
CREATE TABLE detalle_pedido (
  id_detalle INT IDENTITY(1,1) PRIMARY KEY,
  id_producto INT NOT NULL,
  id_pedido INT NOT NULL,
  cantidad INT
);

-- Crear tabla 'estado_pedido'
CREATE TABLE estado_pedido (
  id_estado_pedido INT IDENTITY(1,1) PRIMARY KEY,
  Estado VARCHAR(50) NOT NULL
);

-- Crear tabla 'pedidos'
CREATE TABLE pedidos (
  id_pedido INT IDENTITY(1,1) PRIMARY KEY,
  total_pagar FLOAT NOT NULL,
  fecha_pedido DATE NOT NULL,
  id_estado_pedido INT NOT NULL,
  id_usuario INT NOT NULL,
  ubicacion VARCHAR(150) NOT NULL
);

-- Crear tabla 'producto'
CREATE TABLE producto (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    nombre varchar(50) not null,
    precio decimal(8,2) not null,
    precio_subasta decimal(8,2) null,
    imagen_url varchar(255) not null,
    descripcion varchar(255) not null,
    id_categoria int not null,
    estado int not null,
    fecha_inicio datetime not null,
    fecha_final datetime not null,
    tipo_producto varchar(10) not null,
    id_usuario int NOT NULL
);

-- Crear tabla 'usuarios'
CREATE TABLE usuarios (
  id_usuario INT IDENTITY(1,1) PRIMARY KEY,
  nombre_usuario VARCHAR(50) NOT NULL,
  apellido_usuario VARCHAR(50) NOT NULL,
  correo VARCHAR(50) NOT NULL,
  telefono VARCHAR(11) NOT NULL,
  direccion VARCHAR(150) NOT NULL,
  password VARCHAR(60) NOT NULL
);
ALTER TABLE producto
ADD id_usuario_ultima_puja INT NULL; -- Puede ser NULL si aún no hay una puja.


-- Agregar restricciones de clave externa
ALTER TABLE detalle_pedido
  ADD CONSTRAINT FK_detalle_pedido_pedido FOREIGN KEY (id_pedido) REFERENCES pedidos(id_pedido) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE detalle_pedido
  ADD CONSTRAINT FK_detalle_pedido_producto FOREIGN KEY (id_producto) REFERENCES producto(id_producto) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE pedidos
  ADD CONSTRAINT FK_pedidos_estado_pedido FOREIGN KEY (id_estado_pedido) REFERENCES estado_pedido(id_estado_pedido) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE pedidos
  ADD CONSTRAINT FK_pedidos_usuario FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE producto
  ADD CONSTRAINT FK_producto_categoria FOREIGN KEY (id_categoria) REFERENCES categoria(id_categoria) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE carrito
  ADD CONSTRAINT FK_carrito_usuario FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE producto
  ADD CONSTRAINT FK_producto_usuario FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario);



UPDATE producto
SET imagen_url = 'assets/img/descarga.jpeg';


