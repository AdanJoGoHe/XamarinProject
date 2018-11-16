/* CREACION DE LA BASE DE DATOS
CREATE DATABASE OLDSOLUTIONS
*/

/* DROP TABLES
DROP TABLE REPARACION;
DROP TABLE CLIENTE;
DROP TABLE OPERADOR;
DROP TABLE CPU_FAN;
DROP TABLE GPU;
DROP TABLE CPU;
DROP TABLE RAM;
DROP TABLE PSU;
DROP TABLE PLACA_BASE;
DROP TABLE OTRO;
DROP TABLE PRODUCTO;
*/

/* Cada vez que un cliente solicite una reparacion, se creara un nuevo registro de CLIENTE */ 

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
dni INTEGER NOT NULL,
nombre VARCHAR(25) NOT NULL,
apellidos VARCHAR(25) NOT NULL,
fecha_nacimiento DATE NULL,

CONSTRAINT pk_operador PRIMARY KEY (id_operador)
);

CREATE TABLE PRODUCTO
(
id_producto INTEGER NOT NULL AUTO_INCREMENT,
nombre VARCHAR(50) NOT NULL,
descripcion VARCHAR(150) NULL,

CONSTRAINT pk_producto PRIMARY KEY (id_producto)
);

CREATE TABLE CPU_FAN
(
id_producto INTEGER NOT NULL,
tipo_socket VARCHAR(30) NOT NULL,
tipo_refrigracion VARCHAR(20) NOT NULL,

CONSTRAINT pk_cpu_fan PRIMARY KEY (id_producto),
CONSTRAINT fk_cpu_fan FOREIGN KEY (id_producto) 
	REFERENCES PRODUCTO(id_producto)

);

CREATE TABLE GPU
(
id_producto INTEGER NOT NULL,
memoria VARCHAR(20) NOT NULL,
fec_reloj VARCHAR(15) NOT NULL,

CONSTRAINT pk_gpu PRIMARY KEY (id_producto),
CONSTRAINT fk_gpu FOREIGN KEY (id_producto) 
	REFERENCES PRODUCTO(id_producto)
);

CREATE TABLE CPU
(
id_producto INTEGER NOT NULL,
tipo_socket VARCHAR(20) NOT NULL,
fec_reloj VARCHAR(15) NOT NULL,

CONSTRAINT pk_cpu PRIMARY KEY (id_producto),
CONSTRAINT fk_cpu FOREIGN KEY (id_producto) 
	REFERENCES PRODUCTO(id_producto)
);

CREATE TABLE RAM
(
id_producto INTEGER NOT NULL,
capacidad_memoria VARCHAR(20) NOT NULL,
velocidad_memoria VARCHAR(15) NOT NULL,
tipo_memoria VARCHAR(15) NOT NULL,

CONSTRAINT pk_ram PRIMARY KEY (id_producto),
CONSTRAINT fk_ram FOREIGN KEY (id_producto) 
	REFERENCES PRODUCTO(id_producto)
);

CREATE TABLE PSU
(
id_producto INTEGER NOT NULL,
energia VARCHAR(20) NOT NULL,

CONSTRAINT pk_psu PRIMARY KEY (id_producto),
CONSTRAINT fk_psu FOREIGN KEY (id_producto) 
	REFERENCES PRODUCTO(id_producto)
);

CREATE TABLE PLACA_BASE
(
id_producto INTEGER NOT NULL,
tipo_socket VARCHAR(20) NOT NULL,
chipset VARCHAR(20) NOT NULL,

CONSTRAINT pk_placa_base PRIMARY KEY (id_producto),
CONSTRAINT fk_placa_base FOREIGN KEY (id_producto) 
	REFERENCES PRODUCTO(id_producto)
);

CREATE TABLE OTRO
(
id_producto INTEGER NOT NULL,
tipo_producto VARCHAR(20) NOT NULL,

CONSTRAINT pk_otro PRIMARY KEY (id_producto),
CONSTRAINT fk_otro FOREIGN KEY (id_producto) 
	REFERENCES PRODUCTO(id_producto)
);

CREATE TABLE REPARACION
(
id_reparacion INTEGER NOT NULL AUTO_INCREMENT,
id_cliente INTEGER NOT NULL,
id_operador INTEGER NOT NULL,
fecha_entrega DATETIME NULL,
fecha_estimada DATETIME NULL,
fecha_reparacion DATETIME NULL,
estado VARCHAR(20) NOT NULL,
descripcion VARCHAR(150) NULL,

CONSTRAINT pk_reparacion PRIMARY KEY (id_reparacion,id_cliente,id_operador),

CONSTRAINT fk_reparacion_y_cliente FOREIGN KEY (id_cliente)	REFERENCES CLIENTE(id_cliente),
CONSTRAINT fk_reparacion_y_operador FOREIGN KEY (id_operador) REFERENCES OPERADOR(id_operador)
);