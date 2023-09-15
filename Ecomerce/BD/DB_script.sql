Use master;
go
create database Ecommerce;
go
use Ecommerce;
go
CREATE TABLE CATEGORIAS(
id_categorias int identity(1,1) primary key,
descripcion varchar(20) not null,
estado int not null
);
go
CREATE TABLE PRODUCTOS(
id_producto int identity(1,1) primary key,
nombre varchar(50) not null,
precio decimal(8,2) not null,
imagen_url varchar(255) not null,
descripcion varchar(255) not null,
id_categoria int not null,
eestado int not null
);
go
CREATE TABLE USUARIOS(
id_usuario int identity(1,1) primary key,
nombre varchar(50) not null,
apellido varchar(50) not null,
correo varchar(50) not null,
telefono varchar(11) not null,
domicilio varchar(200) not null,
contrasenia varchar(100) not null
);
go
Create table CARRITO(
id_carrrito int identity(1,1) primary key,
id_usuario int,
total_pagar decimal(10,2),
);
go
CREATE TABLE SUBASTAS(
id_subasta int identity(1,1) primary key,
id_producto int,
descripcion varchar(255),
tiempo_inicia date,
tiempo_finaliza date,
monto_inicial decimal(10,2),
id_usuario_publica int
);
go
CREATE TABLE DETALLE_SUBASTAS(
id_detalle int identity(1,1) primary key,
id_subasta int,
id_usuario int,
monto_total decimal(10,2),
id_estado int
);
go
CREATE TABLE ESTADO_SUBASTAS(
id_estado int primary key,
estado varchar(20)
);
go
CREATE TABLE VENTAS(
id_venta int identity(1,1) primary key,
id_producto int not null,
descripcion varchar(255),
id_usuario_publica int
);
go
create table DETALLE_VENTA(
id_detalle_venta int identity(1,1) primary key,
id_venta int not null,
cantidad int not null,
id_usuario_compra int,
fecha_compra date
);
go
ALTER TABLE CARRITO ADD constraint fk_carrito_usuario foreign key (id_usuario) references USUARIOS(id_usuario) ON DELETE CASCADE ON UPDATE CASCADE;
go
ALTER TABLE PRODUCTOS ADD constraint fk_product_categoria foreign key (id_categoria) references CATEGORIAS(id_categorias) ON DELETE CASCADE ON UPDATE CASCADE;;
go
ALTER TABLE SUBASTAS ADD CONSTRAINT fk_subasta_producto foreign key (id_producto) references PRODUCTOS(id_producto) ON DELETE CASCADE ON UPDATE CASCADE;;
go
ALTER TABLE SUBASTAS ADD CONSTRAINT fk_subasta_usuario foreign key (id_usuario_publica) references USUARIOS(id_usuario) ON DELETE CASCADE ON UPDATE CASCADE;;
go
ALTER TABLE DETALLE_SUBASTAS ADD CONSTRAINT fk_detalle_usuarios foreign key (id_usuario) references USUARIOS(id_usuario) ON DELETE CASCADE ON UPDATE CASCADE;;
go
ALTER TABLE DETALLE_SUBASTAS ADD CONSTRAINT fk_detalle_subasta foreign key (id_subasta) references SUBASTAS(id_subasta);
go
ALTER TABLE DETALLE_SUBASTAS ADD CONSTRAINT fk_detalle_estado foreign key (id_estado) references ESTADO_SUBASTAS(id_estado) ON DELETE CASCADE ON UPDATE CASCADE;
go
ALTER TABLE VENTAS ADD CONSTRAINT fk_venta_productos foreign key (id_producto) references PRODUCTOS(id_producto) ON DELETE CASCADE ON UPDATE CASCADE;
go
ALTER TABLE VENTAS ADD CONSTRAINT fk_venta_usuario foreign key (id_usuario_publica) references USUARIOS(id_usuario)ON DELETE CASCADE ON UPDATE CASCADE;
go
ALTER TABLE DETALLE_VENTA ADD CONSTRAINT fk_detalleventa_usuario foreign key (id_usuario_compra) references USUARIOS(id_usuario)ON DELETE CASCADE ON UPDATE CASCADE;
go
ALTER TABLE DETALLE_VENTA ADD CONSTRAINT fk_detalleventa_ventas foreign key (id_venta) references ventas(id_venta);
/*
USE MASTER;
GO
DROP DATABASE Ecommerce;*/