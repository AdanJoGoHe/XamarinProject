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
            string content = await connection.Response.GetStringAsync(connection.Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            List<PostOperador> posts = JsonConvert.DeserializeObject<List<PostOperador>>(content); //Deserializes or converts JSON String into a collection of Post
            Posts = new ObservableCollection<PostOperador>(posts); //Converting the List to ObservalbleCollection of Post            
            listOperatorsView.ItemsSource = Posts; //Assigning the ObservableCollection to MyListView in the XAML of this file           
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
            listOperatorsView.SelectedItem = null;
        }
    }

    /* ************ZONA ZERO *****************
    
            
            var lov = listOperatorsView;
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

