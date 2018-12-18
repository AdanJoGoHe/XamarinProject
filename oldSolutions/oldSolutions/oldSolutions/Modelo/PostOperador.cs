using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using SQLite;

namespace oldSolutions.Modelo
{
    public class PostOperador : INotifyPropertyChanged
    {

        private int _id;
        [JsonProperty("id_operador")] //This maps the element id_operador of your web service to your model
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private string _nombre;
        [JsonProperty("nombre")]
        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private string _apellidos;
        [JsonProperty("apellidos")]
        public string Apellidos
        {
            get => _apellidos;
            set
            {
                _apellidos = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private string _dni;
        [JsonProperty("dni")]
        public string Dni
        {
            get => _dni;
            set
            {          

                _dni = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        private string _password { get; set; }
        [JsonProperty("password")]
        public string password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        //This is how you create your OnPropertyChanged() method
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
