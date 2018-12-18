using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using oldSolutions.Modelo;
using System.Collections;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Net;
using System.Linq;
using SQLite;

namespace oldSolutions.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaOperador : ContentPage
	{
        public ObservableCollection<PostOperador> Posts { get; set; }
        private HttpCliente connection = new HttpCliente("operador/"); //Instancia de la clase HttpCliente

        /// <summary>
        /// Constructor
        /// </summary>
        public VistaOperador()
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
                List<PostOperador> posts = JsonConvert.DeserializeObject<List<PostOperador>>(content); //Deserializes or converts JSON String into a collection of Post
                Posts = new ObservableCollection<PostOperador>(posts); //Converting the List to ObservalbleCollection of Post 
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

        private async void AddOperadorToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaOperadorSeleccionado());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PostOperador;
            if (item == null)
                return;

            await Navigation.PushAsync(new VistaOperadorSeleccionado(item));

            // Manually deselect item.
            lista.SelectedItem = null;
        }
    }

    /* ************ZONA ZERO *****************
    
            
            var lov = lista;
            var listaOperadores = new List<String>
            
            {
                "Adan","robert"
            };
            
            
            for (int i = 0; i < 10; i++)
            {
                Operador operador = new Operador(i, "Adan", "Gomez", "Hernandez");
                listaOperadores.Add(operador);
            }
            

            /// lov.ItemsSource = listaOperadores;
            
        

     */
}

