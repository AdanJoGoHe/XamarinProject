using System;
using System.Collections.Generic;
using System.Text;

namespace oldSolutions.Modelo
{
    class Operador
    {
        public int id_operador { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string dni { get; set; }

        public Operador(int id_operador,string nombre,string apellidos,string dni)
        {
            this.id_operador = id_operador;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.dni = dni;
        }

        public Operador()
        {
        }
    }
}
