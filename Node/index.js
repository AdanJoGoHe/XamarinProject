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

//Insert un operador, orden : dni-nombre-apelllidos
app.post('/cliente/insertar', (req, res) => 
{
    var _dni = req.body.cliente.telefono_contacto; 
    var _nombre = req.body.cliente.nombre;
    var sql = 'insert into OPERADOR(telefono_contacto,nombre) values (?,?);';
    mysqlConnection.query(sql,[_dni,_nombre,_apellidos], (err, rows, fields) => 
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

//Get Todos los clientes
app.get('/cliente/listar', (req, res) =>
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
app.get('/cliente/listar/:id', (req, res) => 
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
// *********************FIN ZONA CLIENTES*******************
// **********************ZONA OPERADORES********************
//Get Todos los operadores
app.get('/operador/listar', (req, res) =>
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

//Get operador por dni
app.get('/operador/listar/:id', (req, res) => 
{
    var sql = 'SELECT * FROM OPERADOR WHERE dni = ?';
    mysqlConnection.query(sql, [req.params.id], (err, rows, fields) =>
     {
        if (!err)
            res.send(rows);
        else
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
    })
});

//Delete un operador por dni
app.delete('/operador/borrar/:id', (req, res) =>
{
    var sql = 'DELETE FROM OPERADOR WHERE dni = ?';
    mysqlConnection.query(sql, [req.params.id], (err, rows, fields) => {
        if (!err)
            res.send('Deleted successfully.');
        else
            res.send('Ha ocurrido un error : ' + err);
            console.log(err);
    })
});

//Insert un operador, orden : dni-nombre-apelllidos
app.post('/operador/insertar', (req, res) => 
{
    var _dni = req.body.operador.dni; 
    var _nombre = req.body.operador.nombre;
    var _apellidos = req.body.operador.apellidos;
    var sql = 'insert into OPERADOR(dni,nombre,apellidos) values (?,?,?);';
    mysqlConnection.query(sql,[_dni,_nombre,_apellidos], (err, rows, fields) => 
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

app.put('/operador/editar', (req, res) => 
{    
    var _dni = req.body.operador.dni; 
    var _nombre = req.body.operador.nombre;
    var _apellidos = req.body.operador.apellidos;
    var _dni_a_cambiar = req.body.operador.dni_a_cambiar; 
    var sql = 'update operador set dni=?,nombre=?,apellidos=? where dni=? '
    mysqlConnection.query(sql, [_dni,_nombre,_apellidos,_dni_a_cambiar], (err, rows, fields) =>
    {
        if (!err)
            res.send('Updated successfully');
        else
            console.log(err);
            
    })
});
// **********************FIN ZONA OPERADORES********************
//Update an employees
app.put('/employees', (req, res) => 
{
    let emp = req.body;
    var sql = "SET @EmpID = ?;SET @Name = ?;SET @EmpCode = ?;SET @Salary = ?; \
    CALL EmployeeAddOrEdit(@EmpID,@Name,@EmpCode,@Salary);";
    mysqlConnection.query(sql, [emp.EmpID, emp.Name, emp.EmpCode, emp.Salary], (err, rows, fields) =>
    {
        if (!err)
            res.send('Updated successfully');
        else
            console.log(err);
    })
});
