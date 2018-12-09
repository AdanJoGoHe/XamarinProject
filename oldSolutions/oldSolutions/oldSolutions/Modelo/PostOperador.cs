using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace oldSolutions.Modelo
{
    public class PostOperador : INotifyPropertyChanged
    {

        public int _id;

        [JsonProperty("id_operador")] //This maps the element title of your web service to your model
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }
        public string _nombre;

        [JsonProperty("nombre")] //This maps the element title of your web service to your model
        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }
        public string _apellidos;

        [JsonProperty("apellidos")] //This maps the element title of your web service to your model
        public string Apellidos
        {
            get => _apellidos;
            set
            {
                _apellidos = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        public string _dni;

        [JsonProperty("dni")] //This maps the element title of your web service to your model
        public string Dni
        {
            get => _dni;
            set
            {
                if(value == null)
                {
                    throw new Exception();
                } 

                _dni = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
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
