using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace oldSolutions.Modelo
{
    public class PostProducto : INotifyPropertyChanged
    {
        

        private int _id_producto;
        [JsonProperty("id_producto")] 
        public int IdProducto
        {
            get => _id_producto;
            set

            {
                _id_producto = value;
                OnPropertyChanged(); 
            }
        }

        private String _nombre;
        [JsonProperty("nombre")]
        public String Nombre
        {
            get => _nombre;
            set

            {
                _nombre = value;
                OnPropertyChanged(); 
            }
        }

        private String _descripcion;
        [JsonProperty("descripcion")]
        public String Descripcion
        {
            get => _descripcion;
            set

            {
                _descripcion = value;
                OnPropertyChanged(); 
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    }

}

