//Librerias o dependencias
const mysql = require('mysql');
const express = require('express');
var app = express();
const bodyparser = require('body-parser');
app.use(bodyparser.json());

//Conexion a la base de datos
var mysqlConnection = mysql.createConnection({
    host: '192.168.1.93', //Ip de la base de datos(sin puerto)
    user: 'remote', //Usuario con el que se logueara a la base de datos
    password: 'adminadmin', //Contraseña del usuario logueado
    database: 'oldsolutions', //EL nombre de la base de datos
    multipleStatements: true
});

//Mesanjes de conexion a la base de datos(solo para el desarrollador)
mysqlConnection.connect((err) => 
{
    if (!err)
        console.log('DB connection succeded.');
    else
        console.log('DB connection failed \n Error : ' + JSON.stringify(err, undefined, 2));
});

//Puerto de el servicio web
app.listen(3000, () => console.log('Express server is runnig at port no : 3000'));

// Comienzo de las llamadas sql
// **********************ZONA CLIENTES********************
//Get Todos los clientes
app.get('/cliente', (req, res) =>
{
    var sql = 'SELECT * FROM CLIENTE';
    mysqlConnection.query(sql, (err, rows, fields) => 
    {
        if (!err)
            res.send(rows);
        else
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
    })
});


//Get cliente por telefono
app.get('/cliente/getbyphone/:id', (req, res) => 
{
    var sql = 'SELECT * FROM CLIENTE WHERE telefono_contacto = ?';
    mysqlConnection.query(sql, [req.params.id], (err, rows, fields) =>
     {
        if (!err)
            res.send(rows);
        else
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
    })
});

//Insert un cliente
app.post('/cliente', (req, res) => 
{
    var _telefono = req.body.telefono_contacto; 
    var _nombre = req.body.nombre;
    var _pass = req.body.password;
    var sql = 'insert into CLIENTE(telefono_contacto,nombre,password) values (?,?,?);';
    mysqlConnection.query(sql,[_telefono,_nombre,_pass], (err, rows, fields) => 
    {
        if (!err)  
        {         
            res.send('Cliente insertado correctamente.');
        }
        else
        {
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
        }       
    })
});

//Put de cliente
app.put('/cliente', (req, res) => 
{    
    var _id = req.body.id_cliente;
    var _nombre = req.body.nombre;
    var _telefono_contacto = req.body.telefono_contacto;    
    var sql = 'update CLIENTE set telefono_contacto=?,nombre=? where id_cliente=? '
    mysqlConnection.query(sql, [_telefono_contacto,_nombre,_id], (err, rows, fields) =>
    {
        if (!err)
            res.send('Updated successfully');
        else
            console.log(err);
            
    })
});

//Delete de cliente por id
app.delete('/cliente/deletefromid/:id', (req, res) =>
{
    var sql = 'DELETE FROM CLIENTE WHERE id_cliente = ?';
    mysqlConnection.query(sql, [req.params.id], (err, rows, fields) => {
        if (!err)
            res.send('Deleted successfully.');
        else
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
    })
});
// *********************FIN ZONA CLIENTES*******************

// **********************ZONA OPERADORES********************
//Get de Todos los operadores
app.get('/operador', (req, res) =>
{
    var sql = 'SELECT * FROM OPERADOR';
    mysqlConnection.query(sql, (err, rows, fields) => 
    {
        if (!err)
            res.send(rows);
        else
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
    })
});

//Get de operador por dni
app.get('/operador/:id', (req, res) => 
{
    var sql = 'SELECT * FROM OPERADOR WHERE dni = ?';
    mysqlConnection.query(sql, [req.params.id], (err, rows, fields) =>
     {
        if (!err)
        {
            res.send(rows);
            console.log("Operador(es) recibidos correctamente.");
        }
        else
            res.send('Ha ocurrido un error : ' + err);
    })
});

//Insert de operador
app.post('/operador', (req, res) => 
{
    var _dni = req.body.dni; 
    var _nombre = req.body.nombre;
    var _apellidos = req.body.apellidos;
    var _password = req.body.password;
    var sql = 'insert into OPERADOR(dni,nombre,apellidos,password) values (?,?,?,?);';
    mysqlConnection.query(sql,[_dni,_nombre,_apellidos,_password], (err, rows, fields) => 
    {
        if (!err)  
        {         
            res.send('Operador insertado correctamente.');

        }
        else
        {
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
        }       
    })
});

//Update de operador
app.put('/operador', (req, res) => 
{    
    var _dni = req.body.dni; 
    var _nombre = req.body.nombre;
    var _apellidos = req.body.apellidos;
    var _id = req.body.id_operador; 
    var sql = 'update OPERADOR set dni=?,nombre=?,apellidos=? where id_operador=? '
    mysqlConnection.query(sql, [_dni,_nombre,_apellidos,_id], (err, rows, fields) =>
    {
        if (!err)
            res.send('Updated successfully');
        else
            console.log(err);
            
    })
});

//Delete de operador por dni
app.delete('/operador/deletefromid/:id', (req, res) =>
{
    var sql = 'DELETE FROM OPERADOR WHERE id_operador = ?';
    mysqlConnection.query(sql, [req.params.id], (err, rows, fields) => {
        if (!err)
            res.send('Deleted successfully.');
        else
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
    })
});
// **********************FIN ZONA OPERADORES********************

// **********************ZONA PRODUCTOS********************
//Get de los productos
app.get('/producto', (req, res) =>
{
    var sql = 'SELECT * FROM PRODUCTO';
    mysqlConnection.query(sql, (err, rows, fields) => 
    {
        if (!err)
            res.send(rows);
        else
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
    })
});

//Insert de producto
app.post('/producto', (req, res) => 
{
    var _nombre = req.body.nombre; 
    var _descripcion = req.body.descripcion;
    var sql = 'insert into PRODUCTO(nombre,descripcion) values (?,?);';
    mysqlConnection.query(sql,[_nombre,_descripcion], (err, rows, fields) => 
    {
        if (!err)  
        {         
            res.send('Producto insertado correctamente.');
        }
        else
        {
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
        }       
    })
});

//update de producto
app.put('/producto', (req, res) => 
{    
    var _nombre = req.body.nombre; 
    var _descripcion = req.body.descripcion;
    var _id = req.body.id_producto; 
    var sql = 'update PRODUCTO set nombre=?,descripcion=? where id_producto=? '
    mysqlConnection.query(sql, [_nombre,_descripcion,_id], (err, rows, fields) =>
    {
        if (!err)
        {
            res.send('Updated successfully');
        }
        else
            console.log(err+rows+fields+"Ha ocurrido un error");
            
    })
});

//Delete de producto por id
app.delete('/producto/deletefromid/:id', (req, res) =>
{
    var sql = 'DELETE FROM PRODUCTO WHERE id_producto = ?';
    mysqlConnection.query(sql, [req.params.id], (err, rows, fields) => {
        if (!err)
            res.send('Deleted successfully.');
        else
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
    })
});
// **********************FIN ZONA PRODUCTOS********************

// **********************ZONA REPARACIONES********************