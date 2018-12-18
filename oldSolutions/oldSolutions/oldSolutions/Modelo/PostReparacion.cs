using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace oldSolutions.Modelo
{
    public class PostReparacion
    {
        private int _id_reparacion;
        [JsonProperty("id_reparacion")] //This maps the element id_operador of your web service to your model
        public int Id_reparacion
        {
            get => _id_reparacion;
            set
            {
                _id_reparacion = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private int _id_cliente;
        [JsonProperty("id_cliente")] //This maps the element id_operador of your web service to your model
        public int Id_cliente
        {
            get => _id_cliente;
            set
            {
                _id_cliente = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private int _id_operador;
        [JsonProperty("id_operador")] //This maps the element id_operador of your web service to your model
        public int Id_operador
        {
            get => _id_operador;
            set
            {
                _id_operador = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private DateTime _fecha_entrega;
        [JsonProperty("fecha_entrega")] //This maps the element id_operador of your web service to your model
        public DateTime Fecha_entrega
        {
            get => _fecha_entrega;
            set
            {
                _fecha_entrega = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private DateTime _fecha_estimada;
        [JsonProperty("fecha_estimada")] //This maps the element id_operador of your web service to your model
        public DateTime Fecha_estimada
        {
            get => _fecha_estimada;
            set
            {
                _fecha_estimada = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private DateTime _fecha_reparacion;
        [JsonProperty("fecha_reparacion")] //This maps the element id_operador of your web service to your model
        public DateTime Fecha_reparacion
        {
            get => _fecha_reparacion;
            set
            {
                _fecha_reparacion = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private DateTime _fecha_recogida;
        [JsonProperty("fecha_recogida")] //This maps the element id_operador of your web service to your model
        public DateTime Fecha_recogida
        {
            get => _fecha_recogida;
            set
            {
                _fecha_recogida = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private String _estado;
        [JsonProperty("estado")] //This maps the element id_operador of your web service to your model
        public String Estado
        {
            get => _estado;
            set
            {
                _estado = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private String _descripcion;
        [JsonProperty("descripcion")] //This maps the element id_operador of your web service to your model
        public String Descripcion
        {
            get => _descripcion;
            set
            {
                _descripcion = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private float _precio_total;
        [JsonProperty("precio_total")] //This maps the element id_operador of your web service to your model
        public float Precio_total
        {
            get => _precio_total;
            set
            {
                _precio_total = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
