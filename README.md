# *Tienda_Informatica_OldSolutions*
*Aplicación piloto con Xamarin - mysql - node*

*Autor* : ***Adán José Gómez Hernández***

*Contacto* : ***AdanJoGoHe@gmail.com***

<img src="https://i.imgur.com/6NkcWsi.png" alt="Imagen Pila Tecnologica"/> 

*El objetivo del proyecto será la creación de un sistema de gestión reparaciones para una tienda física de informática. La aplicación tendrá numerosas funcionalidades relacionadas con reparar productos.*

<p> El cliente y la idea son ficticias, existen con el fin de dar un propósito a la aplicación, también estoy utilizando este proyecto para afianzarme con GIT y GITHub. Se esperan fallos con el fin de aprender.</p>

# Tabla de contenidos


1. [Descripción de la idea](#Descripción-de-la-idea)
2. [Descripción de la base de datos](#Descripción-de-la-base-de-datos)
3. [Mockups y vistas](#MockUps-y-Vistas.) 
4. [Descripción de la aplicación](#Descripción-de-la-aplicación)
5. [Herramientas Utilizadas](#Herramientas-Utilizadas)


# Descripción de la idea

El cliente me ha solicitado la creación de un programa para la gestión de reparaciones que realizan en la tienda creando una aplicación que sean capaz de manejar a través del móvil. 

Las reparaciones se realizaran sobre equipos informáticos como ordenadores o servidores.

Cuando un cliente solicite una reparación y haya sido tramitada se le dará un ticket con un numero, este numero a través de la web podrá ver el estado del producto, las reparaciones tendrán varios estados que serán explicados a continuación.

## Historias de usuario 

Las reparaciones se podrán crear, donde se le dará un tiempo estimado para la reparación el cual sera genérico de 2 días.

Las reparaciones se podrán posponer, donde se podrá alargar el plazo del tiempo estimado para la reparación en caso de que se complique la reparación.

Las reparaciones se podrán suspender, donde se suspenderá la reparación en caso de que haya sido reparado y nadie lo haya recogido a las 2 semanas.

Las reparaciones se podrán terminar, este caso ocurrirá cuando el producto a reparar haya sido reparado y este listo para entregar, se guardara la fecha de reparación.

Las reparaciones se podrán entregar, el producto ha sido reparado y entregado al cliente se guardara la fecha de entrega.

Las reparaciones se podrán eliminar, el producto ha sido devuelto sin reparar por circunstancias varias.

También, se debe poder gestionar los operadores, clientes y productos desde la propia aplicación.

# Descripción de la base de datos 

-- --------------------------------------------------------
-- Versión del servidor:         5.7.24 - MySQL Community Server (GPL)

-- SO del servidor:              Linux

-- HeidiSQL Versión:             9.5.0.5196
-- --------------------------------------------------------

Creacion de la base de datos y las tablas : <https://pastebin.com/NwU5tVp0>

* 2.1 [Diagrama entidad relacion](#Diagrama-entidad-relación) 
* 2.2 [Tablas](#Tablas) 

## Diagrama entidad relación
<a href="https://i.imgur.com/OvCVqxE.png"><img src="https://i.imgur.com/OvCVqxE.png" alt="hola" style="width: 700px; height: 460px; "/> </a>

[Otra posible solución](https://i.imgur.com/wg27Re6.png).


## Tablas
![](https://i.imgur.com/kGDHbvk.png)

### Tabla Cliente

![](https://i.imgur.com/3WhjEww.png)

El ***cliente*** *compra* ***reparacion***. El cliente contendrá un **nombre**, también tendremos un **telefono_contacto** donde almacenaremos el teléfono , una contraseña y un **id_cliente**.

### Tabla Operador

![](https://i.imgur.com/4zsiufB.png)

El ***operador*** *realiza* ***reparación***. El operador tendrá un, **nombre** un **apellido**, un **dni**, una **contraseña** y un **id_operador**.

### Tabla Producto

![](https://i.imgur.com/ZLDUNb6.png)

El ***producto*** es *utilizado* en ***reparacion***, almacenaremos el **nombre** del producto, una **descripcion** del mismo y una **id_producto**.

### Tabla Reparación

![](https://i.imgur.com/Q2zV4Zq.png)

De la ***REPARACION*** guardaremos :
- **id_reparacion** Integer auto-incrementado.

- **id_cliente**  id del cliente que la haya solicitado.

- **id_operador** id del operador que tome la reparación.

- **fecha_entrega** Fecha en la que el cliente entregada el objeto a reparar a la tienda.

- **fecha_estimada** Por defecto dos días después de recoger el pedido aunque puede ser aplazada manualmente por un operador.

- **fecha_reparacion** La fecha en la que se ha reparado el producto. 

- **fecha_recogida** La fecha en la que el objeto es devuelto al propietario.

- **estado** de la reparación que estará limitado a 5 estados que serán "En proceso","Reparado","Entregado", "Entregado sin reparar" y "Detenida",.

- **descripcion** que puede ser la idea aproximada del problema.

- **precio_total** Precio de los productos utilizados en la reparación y tarifa.



# MockUps y Vistas.

## MockUp interactivo 

<https://app.moqups.com/adanjogohe@gmail.com/R6m1FFlfTT/view>

## Vistas



# Descripción del servidor

#### Tecnología : NodeJS

#### Sistema Operativo : Windows 10(Posible cambio a debian)

#### Manual de Instalación y uso :WIP

#### Dependencias utilizadas :
- [Body-parser](https://www.npmjs.com/package/body-parser).
- [Express](https://www.npmjs.com/package/body-parser).
- [Mysql](https://www.w3schools.com/nodejs/nodejs_mysql.asp).

## Ejemplo :

Caso | Descripción
:---: | :---
**Titulo** | ip+puerto/operador
**Método** |GET
**Parametros de la URL** | No tiene
**Parametros de datos** | No tiene
**Respuesta con exito** | Contenido de ejemplo : <br> {"id_operador":14,"dni":"74859117X","nombre":"Adreso","apellidos":"Plisu","password":null},{"id_operador":15,"dni":"45346569E","nombre":"Adan","apellidos":"Leonhardt","password":"dd94709528bb1c83d08f3088d4043f4742891f4f"}] 
 
 [POSTMAN](https://web.postman.co/collections/5460163-f470ee48-1eaf-49c9-9fd6-b5385e683b55?workspace=2a137706-3147-4342-8d03-44cdbc9e2b11#b586a1da-3daa-42ff-9466-86d54164e675)
# Descripción de la aplicación

* 4.1 [Linting](#Linting) 
* 4.2 [Funcionalidades](#Tablas)  
* 4.3 [Diagrama de clases](#Diagrama-de-clases) 
* 4.4 [Casos de uso](#Casos-de-uso)
* 4.5 [Manual de usuario](#Manual-de-usuario)
* 4.6 [Comparacion de tecnologias](#Comparacion-de-tecnologias)
* 4.7 [Tests](#Tests)
-----------------
-- Tecnología : Xamarin

-- Sistema Operativo : Windows 10

-- Manual de Instalación y uso :WIP

-- Dependencias utilizadas :
- [Newtonsoft.json (12.0.1)](https://www.npmjs.com/package/body-parser).
- [System.Net.Http (4.3.4)](https://www.npmjs.com/package/body-parser).
- [SonarAnalyzer.CSharp](https://www.nuget.org/packages/SonarAnalyzer.CSharp/).
- [Sql-pcl-net(SQLite)]()

-----------------
## Linting 

El software que utilice para mejorar el código es **SonarAnalyzer** que se instala como complemento en el proyecto.
 
![](https://i.imgur.com/10oLape.png)

## Funcionalidades 
La aplicación contara con un CRUD desde la aplicación a el servicio web.

Se deberá poder gestionar :
- Clientes
- Productos
- Operadores
- Reparaciones

Sobre reparaciones : 

El estado **Crear reparación** constara de un create que creara una tupla en la base de datos con los respectivos datos introducidos en la aplicación.

Al crear la reparación el campo estado se pondrá en el **estado** "en proceso" sin ninguna acción por parte del operario.

El estado **posponer reparación** constara de un put que modificara el campo "fecha estimada" que aumentara el plazo de la reparación del producto, el producto se pondrá en el **estado** "en proceso" si no lo estaba ya.

El estado **terminar reparación** constara de un put que modificara el campo "fecha de reparación" con la fecha dada por el operador, el estado pasara a "Terminado".

El estado **suspender reparación** constara de un put que modificara el **estado** por "Suspendido".

El estado **reparación terminada** constara de un put del campo "fecha de entrega" por la fecha dada por el operador y el campo **estado** se pondrá en "terminado".


## Diagrama de clases
<a href="https://i.imgur.com/Lu5S7Iy.png"><img src="https://i.imgur.com/Lu5S7Iy.png" alt="hola" style="width: 700px; height: 460px; "/></a>

## Casos de uso

![](https://i.imgur.com/jSr9ojp.png)
## Manual de usuario

Acción | Uso | GIF
 :---: | :---: | :---:
Añadir (Generico a todas las clases) | Una vez dentro de la vista se seleccionara sobre el boton "Add" posicionado en la parte superior derecha, una vez dentro de la nueva vista se añadiran los datos pertinentes y seleccionaremos el boton Add posicionado en la parte inferior. |<a href="https://i.imgur.com/ZRobkKw.gif"><img src="https://i.imgur.com/ZRobkKw.gif" width="100%" height="100%"  ></a>
Modificar(Generico a todas las clases) | Una vez dentro de la vista se seleccionara el item que quieras modificar, dentro se cambiara el dato que quisieras cambiar y pulsar sobre "modificar" | <a href="https://i.imgur.com/Nb9t0nI.gif"><img src="https://i.imgur.com/Nb9t0nI.gif" width="100%" height="100%"  ></a>
Eliminar(Generico a todas las clases) | Una vez dentro de la vista se seleccionara el item que quieras eliminar, dentro se pulsara sobre "eliminar" | <a href="https://i.imgur.com/gYgEwZK.gif"><img src="https://i.imgur.com/gYgEwZK.gif" width="100%" height="100%"  ></a>

## Comparación con tecnologías
Tecnología | Ventajas | Inconvenientes
 :---: | :--- | :---
 XAMARIN | -Compatibilidad Multiplataforma(iOS,Android,Windows)<br>-Soporte de microsoft<br> | -Ligado al IDE Visual studio<br>-Como presento en la documentación, las interfaces se hacen a codigo XML y no tiene un diseñador<br>-Herramienta no tan conocida
Ionic(framwork) | -Compatibilidad en iOS y Android<br>Información abundante | -Dado que es un herramienta en desarrollo, hay que adaptarse a los cambios
Android(studio) | -Gran cantidad de informacion y documentación<br>-Alta demanda | -Solo desplegable en Dispositivos Android 

## Tests
![clipboard](https://i.imgur.com/VRrIVGh.png)


# Herramientas Utilizadas

Una descripción de las herramientas y tecnologías utilizadas en este proyecto.

## Tecnologías utilizadas : 
Tecnología | Descripción
 :---: | :---
<a href="https://visualstudio.microsoft.com/es/xamarin/"><img src="https://i.imgur.com/O4ilwXe.png" width="200px" height="125px"  ></a> | Xamarin o para ser mas especifico xamarin.forms es la tecnología principal de este proyecto, su premisa consiste en el desarrollo de una aplicación móvil que programando una base de código(codebase), se despliegue para todas las plataformas móviles(Android,IOS,Windows). he utilizado el paquete Newtonsoft.Json 
<a href="https://www.mysql.com/" margin="10px"><img src="https://i.imgur.com/y8unasD.png" height="175" width="175"  ></a> | MySQL es un gestor de base de datos relacionales muy popular en el mercado actual, este se encargara de el almacenamiento.
<a href="https://nodejs.org/en/"><img src="https://i.imgur.com/kIwlxRv.png" width="200px" height="125px"  ></a> | NodeJS Se encargara de la parte de el apartado del servidor redirigiendo las conexiones a la base de datos.


## Software : 

Herramienta | Descripción
 :---: | :---
<a href="https://visualstudio.microsoft.com/es/"><img src="https://i.imgur.com/9KvwFxG.jpg" width="200px" height="125px" align="left" ></a> | Visual studio 2017 es la herramienta necesaria para poder programar en xamarin, es una herramienta muy customizable desarrollada por microsoft.
<a href="https://www.heidisql.com/"><img src="https://i.imgur.com/UXPh7Tb.png" width="150px" height="125px" align="center" ></a> | HeidiSql es un conector de bases de datos que funciona tanto con Mysql como con postgreSQL, es Open source y completamente gratis.
<a href="https://visualstudio.microsoft.com/es"><img src="https://i.imgur.com/AzHbL6i.png" width="200px" height="125px" align="left" ></a> | Visual Studio Code es un editor de codigo desarrollado por Microsoft el cual integra sistemas como Git.






