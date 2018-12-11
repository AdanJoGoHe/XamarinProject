using Newtonsoft.Json;
using oldSolutions.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace oldSolutions.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaClienteSeleccionado : ContentPage
    {
        PostCliente pc;
        public ObservableCollection<PostCliente> _posts { get; set; }
        private HttpCliente connection = new HttpCliente("cliente/"); //Instancia de la clase HttpCliente
        private String Titulo
        {
            get { return Titulo; } set { Titulo = value; }
        }
        public VistaClienteSeleccionado(PostCliente postCliente)
        {
            pc = postCliente;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            idCliente.Text = pc.Id.ToString();
            nombreCliente.Text = pc.Nombre;
            telefonoCliente.Text = pc.Telefono;
        }
        private async void OnAdd(object sender, EventArgs e)
        {
            PostCliente post = new PostCliente { Telefono = telefonoCliente.Text, Nombre = nombreCliente.Text }; //Creating a new instane of Post with a Title Property and its value in a Timestamp format
            string content = JsonConvert.SerializeObject(new { telefono_contacto = telefonoCliente.Text, nombre = nombreCliente.Text }); //Serializes or convert the created Post into a JSON String
            await connection.Response.PostAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a POST request to the specified Uri as an asynchronous operation and with correct character encoding (utf9) and contenct type (application/json).
            //_posts.Insert(0, post); //Updating the UI by inserting an element into the first index of the collection 
        }
        /*
        private async void OnUpdate(object sender, EventArgs e)
        {
            Post post = _posts[0]; //Assigning the first Post object of the Post Collection to a new instance of Post
            post.Title += " [updated]"; //Appending an [updated] string to the current value of the Title property
            string content = JsonConvert.SerializeObject(post); //Serializes or convert the created Post into a JSON String
            await _client.PutAsync(Url + "/" + post.Id, new StringContent(content, Encoding.UTF8, "application/json")); //Send a PUT request to the specified Uri as an asynchronous operation.
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            Post post = _posts[0]; //Assigning the first Post object of the Post Collection to a new instance of Post
            await _client.DeleteAsync(Url + "/" + post.Id); //Send a DELETE request to the specified Uri as an asynchronous 
            _posts.Remove(post); //Removes the first occurrence of a specific object from the Post collection. This will be visible on the UI instantly
        }
        */
    }
}