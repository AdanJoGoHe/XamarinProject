using oldSolutions.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net;

namespace oldSolutions.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaCliente : ContentPage
    {
        public ObservableCollection<PostCliente> Posts { get; set; }
        private HttpCliente connection = new HttpCliente("cliente/"); //Instancia de la clase HttpCliente

        public VistaCliente()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Se llama a este metodo cuando aparece la ventana(antes de aparecer al usuario).
        /// </summary>
        protected override async void OnAppearing()
        {
            string conexion = "conectando...";
            Boolean conexionBool = true;
            string content = null;
            try
            {
                content = await connection.Response.GetStringAsync(connection.Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
                List<PostCliente> posts = JsonConvert.DeserializeObject<List<PostCliente>>(content); //Deserializes or converts JSON String into a collection of Post
                Posts = new ObservableCollection<PostCliente>(posts); //Converting the List to ObservalbleCollection of Post 
            }
            catch (HttpRequestException)
            {
                conexion = "No hay conexion con el servicio web, contacte con el administrador del servicio web";
                conexionBool = false;
            }
            catch (WebException)
            {
                conexion = "No hay conexión con el servicio web, contacte con el administrador del servicio web.";
                conexionBool = false;
                //TODO : implementar base de datos local.
            }
            catch (JsonReaderException)
            {
                conexion = "Hay un error en la base de datos, contacte con el administrador de la base de datos";
            }
            catch (ArgumentNullException)
            {
                conexion = "Ha ocurrido un error";
                conexionBool = false;
            }
            catch (Exception)
            {
                conexion = "Ha ocurrido un error";
                conexionBool = false;
            }
            finally
            {

                if (conexionBool)
                {
                    conexion = "Hay conexión";
                }
                labelErrorConexion.Text = conexion;
            }
            lista.ItemsSource = Posts; //Assigning the ObservableCollection to MyListView in the XAML of this file           
            base.OnAppearing();
        }


        private async void AddClienteToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaClienteSeleccionado());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PostCliente;
            if (item == null)
                return;

            await Navigation.PushAsync(new VistaClienteSeleccionado(item));

            // Manually deselect item.
            lista.SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                //thats all you need to make a search  

                if (string.IsNullOrEmpty(e.NewTextValue))
                {
                    lista.ItemsSource = Posts;
                }

                else 
                {
                    lista.ItemsSource = Posts.Where(x => x.Nombre.StartsWith(e.NewTextValue));
                }
            }
        }
    }
}