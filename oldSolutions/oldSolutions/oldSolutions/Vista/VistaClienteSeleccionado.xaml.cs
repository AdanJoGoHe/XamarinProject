using Android.Widget;
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
        private HttpCliente connection = new HttpCliente("cliente"); //Instancia de la clase HttpCliente
        private String Titulo
        {
            get { return Titulo; } set { Titulo = value; }
        }
        public VistaClienteSeleccionado(PostCliente postCliente)
        {
            pc = postCliente;
            InitializeComponent();
            nombreCliente.Text = pc.Nombre;
            telefonoCliente.Text = pc.Telefono;
            idCliente.Text = pc.Id.ToString();           
            addButon.IsVisible = false;
        }
        public VistaClienteSeleccionado()
        {
            InitializeComponent();
            updateButon.IsVisible = false;
            deleteButon.IsVisible = false;
            idCliente.IsVisible = false;
            idLabel.IsVisible = false;
        }

        protected override async void OnAppearing()
        {
            idCliente.IsEnabled = false;

        }
        private async void OnAdd(object sender, EventArgs e)
        {
            string content = JsonConvert.SerializeObject(new { telefono_contacto = telefonoCliente.Text, nombre = nombreCliente.Text }); //Serializes or convert the created Post into a JSON String
            await connection.Response.PostAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a POST request to the specified Uri as an asynchronous operation and with correct character encoding (utf9) and contenct type (application/json).
        }
        
        private async void OnUpdate(object sender, EventArgs e)
        {            
            pc.Nombre = nombreCliente.Text;
            pc.Telefono = telefonoCliente.Text;            
            if(Int32.TryParse(idCliente.Text,out int x))//comp errrores
            pc.Id = x;
            string content = JsonConvert.SerializeObject(pc); //Serializes or convert the created Post into a JSON String

            var eksudi = await connection.Response.PutAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a PUT request to the specified Uri as an asynchronous operation.
            if(eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha modificado correctamente al cliente", ToastLength.Long).Show();  }
            else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
            await Navigation.PushAsync(new VistaCliente());
        }
        
        private async void OnDelete(object sender, EventArgs e)
        {                        
            
            var eksudi = await connection.Response.DeleteAsync(connection.Url + "/DeleteFromId/" + pc.Id); //Send a DELETE request to the specified Uri as an asynchronous   
            if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha eliminado correctamente al cliente", ToastLength.Long).Show(); }
            else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
            await Navigation.PushAsync(new VistaCliente());
        }
        
    }
}