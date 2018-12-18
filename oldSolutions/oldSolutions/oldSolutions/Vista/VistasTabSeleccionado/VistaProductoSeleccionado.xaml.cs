using Android.Widget;
using Newtonsoft.Json;
using oldSolutions.Modelo;
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
	public partial class VistaProductoSeleccionado : ContentPage
	{
        private Core core = new Core();
        private PostProducto pp;
        private ObservableCollection<PostProducto> _posts { get; set; }
        private HttpCliente connection = new HttpCliente("producto/"); //Instancia de la clase HttpCliente

        public VistaProductoSeleccionado(PostProducto postProducto)
        {
            pp = postProducto;
            InitializeComponent();
            addButon.IsVisible = false;
            idProducto.IsEnabled = false;
            idProducto.Text = pp.IdProducto.ToString();
            nombreProducto.Text = pp.Nombre;
            descripcionProducto.Text = pp.Descripcion;
            
        }
        public VistaProductoSeleccionado()
        {
            InitializeComponent();
            labelIdProducto.IsVisible = false;
            idProducto.IsVisible = false;
            updateButon.IsVisible = false;
            deleteButon.IsVisible = false;
        }

        private async void OnAdd(object sender, EventArgs e)
        {

            bool error = false;
            Mensajerror.Text = null;
            if (nombreProducto.Text == null || descripcionProducto.Text == null || precioProducto.Text == null )
            {
                error = true;
                Mensajerror.Text += "Has dejado campos vacios";
            }
            else
            {
                if (!Regex.IsMatch(precioProducto.Text, core.expresionRegularNumero))
                {
                    error = true;
                    Mensajerror.Text += "El precio no puede contener letras ni caracteres especiales" + Environment.NewLine;
                }                
            }
            if (error)
            { }
            else
            {
                string content = JsonConvert.SerializeObject(new { nombre = nombreProducto.Text, descripcion = descripcionProducto.Text }); //Serializes or convert the created Post into a JSON String
                var eksudi = await connection.Response.PostAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a POST request to the specified Uri as an asynchronous operation and with correct character encoding (utf9) and contenct type (application/json).


                if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha modificado correctamente el producto", ToastLength.Long).Show(); }
                else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
                await Navigation.PopAsync();
            }
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            pp.Nombre = nombreProducto.Text;
            pp.Descripcion = descripcionProducto.Text ;
            if (Int32.TryParse(idProducto.Text, out int x))//comp errrores
                pp.IdProducto = x;

            string content = JsonConvert.SerializeObject(pp); //Serializes or convert the created Post into a JSON String

            var eksudi = await connection.Response.PutAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a PUT request to the specified Uri as an asynchronous operation.
            
            if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha modificado correctamente el producto", ToastLength.Long).Show(); }
            else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }            
            await Navigation.PopAsync();
        }

        private async void OnDelete(object sender, EventArgs e)
        {

            var rutaRelativa = "deletefromid/" + pp.IdProducto;
            var eksudi = await connection.Response.DeleteAsync(connection.Url + rutaRelativa); //Send a DELETE request to the specified Uri as an asynchronous             
            if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha eliminado correctamente el producto", ToastLength.Long).Show(); }
            else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error...", ToastLength.Long).Show(); }
            
            await Navigation.PopAsync();
        }
    }
}