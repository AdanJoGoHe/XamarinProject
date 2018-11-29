/* CREACION DE LA BASE DE DATOS
CREATE DATABASE OLDSOLUTIONS
*/

/*
DROP TABLE REPARACION;
DROP TABLE CLIENTE;
DROP TABLE OPERADOR;
DROP TABLE PRODUCTO;
*/

/* Cada vez que un cliente solicite una reparacion, se creara un nuevo registro de CLIENTE aunque si se considera que es el mismo cliente se podra reutilizar */ 
CREATE TABLE CLIENTE
(
id_cliente INTEGER NOT NULL AUTO_INCREMENT,
telefono_contacto VARCHAR(15) NULL,
nombre VARCHAR(20) NULL,

CONSTRAINT pk_cliente PRIMARY KEY (id_cliente)
);

/* Los operadores seran registrados y seran fijos */
CREATE TABLE OPERADOR
(
id_operador INTEGER NOT NULL AUTO_INCREMENT,
dni VARCHAR(9) NOT NULL,
nombre VARCHAR(25) NOT NULL,
apellidos VARCHAR(25) NOT NULL,

CONSTRAINT pk_operador PRIMARY KEY (id_operador)
);

CREATE TABLE PRODUCTO
(
id_producto INTEGER NOT NULL AUTO_INCREMENT,
nombre VARCHAR(50) NOT NULL,
descripcion VARCHAR(150) NULL,

CONSTRAINT pk_producto PRIMARY KEY (id_producto)
);

CREATE TABLE REPARACION
(
	id_reparacion INTEGER NOT NULL AUTO_INCREMENT,
	id_cliente INTEGER NOT NULL,
	id_operador INTEGER NULL,
	fecha_entrega DATE NULL,
	fecha_estimada DATE NULL,
	fecha_reparacion DATE NULL,
	fecha_recogida DATE NULL,
	estado VARCHAR(20) NOT NULL,
	descripcion VARCHAR(255) NULL,

	CONSTRAINT pk_reparacion PRIMARY KEY (id_reparacion),
	CONSTRAINT fk_reparacion_y_cliente FOREIGN KEY (id_cliente)	REFERENCES CLIENTE(id_cliente),
	CONSTRAINT fk_reparacion_y_operador FOREIGN KEY (id_operador) REFERENCES OPERADOR(id_operador)
);

CREATE TABLE REPARACION_PRODUCTO
(
	id_reparacion INTEGER NOT NULL,
	id_producto INTEGER NOT NULL,

	CONSTRAINT pk_reparacion_producto PRIMARY KEY (id_reparacion,id_producto),
	CONSTRAINT fk_reparacion_producto1 FOREIGN KEY (id_reparacion)	REFERENCES REPARACIOn(id_reparacion),
	CONSTRAINT fk_reparacion_producto2 FOREIGN KEY (id_producto) REFERENCES PRODUCTO(id_producto)
);