using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace oldSolutions.Modelo
{
    public class PostCliente : INotifyPropertyChanged
    {
        private string _telefono_cliente;
        [JsonProperty("telefono_contacto")]
        public string Telefono
        {
            get => _telefono_cliente;
            set
            {
                _telefono_cliente = value;
                OnPropertyChanged();
            }
        }

        public string _nombre { get; set; }
        [JsonProperty("nombre")]
        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        private int _id_cliente { get; set; }
        [JsonProperty("id_cliente")]
        public int Id
        {
            get => _id_cliente;
            set
            {
                _id_cliente = value;
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
