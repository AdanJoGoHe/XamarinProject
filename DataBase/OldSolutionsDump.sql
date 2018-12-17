-- --------------------------------------------------------
-- Host:                         192.168.1.93
-- Versión del servidor:         5.7.24 - MySQL Community Server (GPL)
-- SO del servidor:              Linux
-- HeidiSQL Versión:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para oldsolutions
CREATE DATABASE IF NOT EXISTS `oldsolutions` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `oldsolutions`;

-- Volcando estructura para tabla oldsolutions.CLIENTE
CREATE TABLE IF NOT EXISTS `CLIENTE` (
  `id_cliente` int(11) NOT NULL AUTO_INCREMENT,
  `telefono_contacto` varchar(15) DEFAULT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `password` varchar(40) NOT NULL,
  PRIMARY KEY (`id_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1 COMMENT='Tabla para almacenar a los clientes.\r\nID Autoincrementado.';

-- La exportación de datos fue deseleccionada.
-- Volcando estructura para tabla oldsolutions.OPERADOR
CREATE TABLE IF NOT EXISTS `OPERADOR` (
  `id_operador` int(11) NOT NULL AUTO_INCREMENT,
  `dni` varchar(9) NOT NULL,
  `nombre` varchar(25) NOT NULL,
  `apellidos` varchar(25) NOT NULL,
  `password` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id_operador`),
  UNIQUE KEY `uk_operador` (`dni`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1 COMMENT='Tabla para almacenar a los operadores\r\nID Autoincrementado.\r\nDNI Unique key.';

-- La exportación de datos fue deseleccionada.
-- Volcando estructura para tabla oldsolutions.PRODUCTO
CREATE TABLE IF NOT EXISTS `PRODUCTO` (
  `id_producto` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(150) DEFAULT NULL,
  `precio_publico` decimal(9,2) DEFAULT NULL,
  `url_imagen` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1 COMMENT='Tabla para almacenar a los productos y su precio.\r\nID Autogeneado.\r\n';

-- La exportación de datos fue deseleccionada.
-- Volcando estructura para tabla oldsolutions.REPARACION
CREATE TABLE IF NOT EXISTS `REPARACION` (
  `id_reparacion` int(11) NOT NULL AUTO_INCREMENT,
  `id_cliente` int(11) NOT NULL,
  `id_operador` int(11) DEFAULT NULL,
  `fecha_entrega` date DEFAULT NULL,
  `fecha_estimada` date DEFAULT NULL,
  `fecha_reparacion` date DEFAULT NULL,
  `fecha_recogida` date DEFAULT NULL,
  `estado` varchar(20) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `precio_total` decimal(9,2) DEFAULT NULL,
  PRIMARY KEY (`id_reparacion`),
  KEY `fk_reparacion_y_cliente` (`id_cliente`),
  KEY `fk_reparacion_y_operador` (`id_operador`),
  CONSTRAINT `fk_reparacion_y_cliente` FOREIGN KEY (`id_cliente`) REFERENCES `CLIENTE` (`id_cliente`),
  CONSTRAINT `fk_reparacion_y_operador` FOREIGN KEY (`id_operador`) REFERENCES `OPERADOR` (`id_operador`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Tabla para almacenar las reparaciones, de ella podremos extrar al cliente que la pidio y el operador que la realizo.\r\nid_reparacion Autoincrementado\r\nid_cliente foreign key de cliente.\r\nid_operador foreign key de operador.';

-- La exportación de datos fue deseleccionada.
-- Volcando estructura para tabla oldsolutions.REPARACION_PRODUCTO
CREATE TABLE IF NOT EXISTS `REPARACION_PRODUCTO` (
  `id_reparacion` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  PRIMARY KEY (`id_reparacion`,`id_producto`),
  KEY `fk_reparacion_producto2` (`id_producto`),
  CONSTRAINT `fk_reparacion_producto1` FOREIGN KEY (`id_reparacion`) REFERENCES `REPARACION` (`id_reparacion`),
  CONSTRAINT `fk_reparacion_producto2` FOREIGN KEY (`id_producto`) REFERENCES `PRODUCTO` (`id_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Tabla creada por la relación muchos a muchos entre producto y relación.\r\n';

-- La exportación de datos fue deseleccionada.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
