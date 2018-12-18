//using Android.Widget;
using Android.Widget;
using Newtonsoft.Json;
using oldSolutions.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
        private Core core = new Core();
        public String Titulo
        {
            get{ return Titulo; } set { Titulo = value; }
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

        protected override void OnAppearing()
        {
            idCliente.IsEnabled = false;

        }
        private async void OnAdd(object sender, EventArgs e)
        {
            bool error = false;
            Mensajerror.Text = null;
            if (nombreCliente.Text == null || telefonoCliente.Text == null || passCliente == null)
            {
                error = true;
                Mensajerror.Text += "Has dejado campos vacios";
            }
            else
            {
                if (!Regex.IsMatch(nombreCliente.Text, core.expresionRegularNombre))
                {
                    error = true;
                    Mensajerror.Text = "El nombre no puede incluir numeros ni caracteres especiales " + Environment.NewLine;
                }
                if (!Regex.IsMatch(telefonoCliente.Text, core.expresionRegularTelefono))
                {
                    error = true;
                    Mensajerror.Text += "El Telefono no es correcto";
                }
            }
            if(error)
            { }
            else
            {

                pc = new PostCliente();
                pc.Nombre = nombreCliente.Text;
                pc.password = core.Hash(passCliente.Text);
                pc.Telefono = telefonoCliente.Text;
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {                    
                    conn.CreateTable<PostCliente>();
                    int rowsAdded = conn.Insert(pc);
                }
                await Navigation.PopAsync();
                /*
                string content = null;
                content = JsonConvert.SerializeObject(new { telefono_contacto = telefonoCliente.Text, nombre = nombreCliente.Text, password = core.Hash(passCliente.Text) }); //Serializes or convert the created Post into a JSON String
                var eksudi = await connection.Response.PostAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a POST request to the specified Uri as an asynchronous operation and with correct character encoding (utf9) and contenct type (application/json).
                

                if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha añadido correctamente al cliente : " + nombreCliente.Text, ToastLength.Long).Show(); }
                else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
                */
            }
        }
        
        private async void OnUpdate(object sender, EventArgs e)
        {
            //Asignacion de variables
            bool error = false;
            Mensajerror.Text = null;
            if (!Regex.IsMatch(nombreCliente.Text, core.expresionRegularNombre))
            {
                error = true;
                Mensajerror.Text = "El nombre no puede incluir numeros ni caracteres especiales " + Environment.NewLine;
            }
            if (!Regex.IsMatch(telefonoCliente.Text, core.expresionRegularTelefono))
            {
                error = true;
                Mensajerror.Text += "El Telefono no es correcto";
            }
            if (nombreCliente.Text == null || telefonoCliente.Text == null || passCliente == null)
            {
                error = true;
                Mensajerror.Text += "Has dejado campos vacios";
            }
            if (error)
            { }
            else
            {
                pc.Nombre = nombreCliente.Text;
                pc.Telefono = telefonoCliente.Text;

                if (Int32.TryParse(idCliente.Text, out int x))//comp errrores
                    pc.Id = x;

                pc.password = passCliente.Text;

                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<PostCliente>();
                    int rowsAdded = conn.Update(pc);
                }
                await Navigation.PopAsync();
                /*
                //Conversion a Json
                string content = JsonConvert.SerializeObject(pc); //Serializes or convert the created Post into a JSON String
                //Llamada al servicio web
                var eksudi = await connection.Response.PutAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a PUT request to the specified Uri as an asynchronous operation.           

                if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha modificado correctamente al cliente " + nombreCliente.Text, ToastLength.Long).Show(); }
                else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
                */
            }
        }
        
        private async void OnDelete(object sender, EventArgs e)
        {
            
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                var posts = conn.CreateTable<PostCliente>();
                conn.Delete(pc);
            }
            await Navigation.PopAsync();
            /*
            var eksudi = await connection.Response.DeleteAsync(connection.Url + "DeleteFromId/" + pc.Id); //Send a DELETE request to the specified Uri as an asynchronous   
            
            if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha eliminado correctamente al cliente " + nombreCliente.Text, ToastLength.Long).Show(); }
            else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
            */
        }
        
    }
}