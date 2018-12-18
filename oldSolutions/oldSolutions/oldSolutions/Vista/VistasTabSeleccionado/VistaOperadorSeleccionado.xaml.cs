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
	public partial class VistaOperadorSeleccionado : ContentPage
	{
        /// <summary>
        /// Variables
        /// </summary>
        private Core core = new Core();
        public PostOperador op;
        public ObservableCollection<PostOperador> _posts { get; set; }
        private HttpCliente connection = new HttpCliente("operador/"); //Instancia de la clase HttpCliente
        /// <summary>
        /// Constructores
        /// </summary>
        public VistaOperadorSeleccionado (PostOperador postOperador)
		{
            op = postOperador;
            InitializeComponent ();
            addButon.IsVisible = false;
            idOperador.IsEnabled = false;
            idOperador.Text = op.Id.ToString();
            nombreOperador.Text = op.Nombre;
            apellidosOperador.Text = op.Apellidos;
            dniOperador.Text = op.Dni;
        }
        public VistaOperadorSeleccionado()
        {
            InitializeComponent();
            labelIdOperador.IsVisible = false;
            idOperador.IsVisible = false;
            updateButon.IsVisible = false;
            deleteButon.IsVisible = false;
        }
        /// <summary>
        /// Manejadores de eventos
        /// </summary>
        private async void OnAdd(object sender, EventArgs e)
        {
            bool error = false;
            Mensajerror.Text = null;
            // Control de errores
            if (nombreOperador.Text == null || apellidosOperador.Text == null || dniOperador == null || passwordOperador == null)
            {
                error = true;
                Mensajerror.Text += "Has dejado campos vacios";
            }
            else
            {
                if (!Regex.IsMatch(nombreOperador.Text, core.expresionRegularNombre) && !Regex.IsMatch(apellidosOperador.Text, core.expresionRegularNombre))
                {
                    error = true;
                    Mensajerror.Text = "El nombre o apellido no puede incluir numeros ni caracteres especiales " + Environment.NewLine;
                }
                if (!Regex.IsMatch(dniOperador.Text, core.expresionRegularDNI))
                {
                    error = true;
                    Mensajerror.Text += "El DNI no es correcto" + Environment.NewLine;
                }
            }
            if (error)
            { }
            else
            {
                /*
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    
                    if (Int32.TryParse(idOperador.Text, out int x))//comp errrores
                        op.Id = x;

                    conn.CreateTable<PostOperador>();
                    int rowsAdded = conn.Insert(op);
                }
                */
                string content = JsonConvert.SerializeObject(new { dni = dniOperador.Text, nombre = nombreOperador.Text, apellidos = apellidosOperador.Text, password = core.Hash(passwordOperador.Text) }); //Serializes or convert the created Post into a JSON String
                var eksudi = await connection.Response.PostAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a POST request to the specified Uri as an asynchronous operation and with correct character encoding (utf9) and contenct type (application/json).


                if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha añadido correctamente al operador", ToastLength.Long).Show(); }
                else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
                
                await Navigation.PopAsync();

            }
        }
        private async void OnUpdate(object sender, EventArgs e)
        {
            op.Dni = dniOperador.Text;
            op.Nombre = nombreOperador.Text;
            op.Apellidos = apellidosOperador.Text;
            if (Int32.TryParse(idOperador.Text, out int x))//comp errrores
                op.Id = x;

            string content = JsonConvert.SerializeObject(op); //Serializes or convert the created Post into a JSON String

            var eksudi = await connection.Response.PutAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a PUT request to the specified Uri as an asynchronous operation.
            
            if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha modificado correctamente al operador", ToastLength.Long).Show(); }
            else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
            
            await Navigation.PopAsync();
        }
        private async void OnDelete(object sender, EventArgs e)
        {

            var eksudi = await connection.Response.DeleteAsync(connection.Url + "DeleteFromId/" + op.Id); //Send a DELETE request to the specified Uri as an asynchronous 
            
            if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha eliminado correctamente al operador", ToastLength.Long).Show(); }
            else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
            
            await Navigation.PopAsync();
        }
    }
}