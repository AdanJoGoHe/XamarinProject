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

namespace oldSolutions.Vista.VistasTabSeleccionado
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaReparacionSeleccionado : ContentPage
	{
        Core core = new Core();
        PostReparacion pr;
        private ObservableCollection<PostReparacion> _posts { get; set; }
        private HttpCliente connection = new HttpCliente("reparacion/"); //Instancia de la clase HttpCliente

        public VistaReparacionSeleccionado ()
		{
			InitializeComponent ();
		}
        public VistaReparacionSeleccionado(PostReparacion postReparacion)
        {
            pr = postReparacion;
        }
        private async void OnAdd(object sender, EventArgs e)
        {

            bool error = false;
            Mensajerror.Text = null;
            if (idCliente.Text == null || idReparacion.Text == null || precioProducto.Text == null)
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
                string content = JsonConvert.SerializeObject(new { }); //Serializes or convert the created Post into a JSON String
                var eksudi = await connection.Response.PostAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a POST request to the specified Uri as an asynchronous operation and with correct character encoding (utf9) and contenct type (application/json).


                if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha modificado correctamente el producto", ToastLength.Long).Show(); }
                else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
                await Navigation.PopAsync();
            }
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            

            string content = JsonConvert.SerializeObject(pr); //Serializes or convert the created Post into a JSON String

            var eksudi = await connection.Response.PutAsync(connection.Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a PUT request to the specified Uri as an asynchronous operation.

            if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha modificado correctamente el producto", ToastLength.Long).Show(); }
            else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error", ToastLength.Long).Show(); }
            await Navigation.PopAsync();
        }

        private async void OnDelete(object sender, EventArgs e)
        {

            var rutaRelativa = "deletefromid/" + pr.Id_reparacion;
            var eksudi = await connection.Response.DeleteAsync(connection.Url + rutaRelativa); //Send a DELETE request to the specified Uri as an asynchronous             
            if (eksudi.IsSuccessStatusCode) { Toast.MakeText(Android.App.Application.Context, "Se ha eliminado correctamente el producto", ToastLength.Long).Show(); }
            else { Toast.MakeText(Android.App.Application.Context, "Ha ocurrido un error...", ToastLength.Long).Show(); }

            await Navigation.PopAsync();
        }
    }
}