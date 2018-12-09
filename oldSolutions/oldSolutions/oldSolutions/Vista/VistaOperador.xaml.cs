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
        
        private HttpCliente hc = new HttpCliente("operador/");
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
            string content = await hc.Response.GetStringAsync(hc.Url+"listar"); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            List<PostOperador> posts = JsonConvert.DeserializeObject<List<PostOperador>>(content); //Deserializes or converts JSON String into a collection of Post
            hc.Posts = new ObservableCollection<PostOperador>(posts); //Converting the List to ObservalbleCollection of Post            
            listOperatorsView.ItemsSource = hc.Posts; //Assigning the ObservableCollection to MyListView in the XAML of this file           
            base.OnAppearing();            
        }

        private void AddOperadorToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PostOperador;
            if (item == null)
                return;

            await Navigation.PushAsync(new VistaOperadorSeleccionado());

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
            
    private async void OnAdd(object sender, EventArgs e)
        {
            Post post = new Post { Title = $"Title: Timestamp {DateTime.UtcNow.Ticks}" }; //Creating a new instane of Post with a Title Property and its value in a Timestamp format
            string content = JsonConvert.SerializeObject(post); //Serializes or convert the created Post into a JSON String
            await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json")); //Send a POST request to the specified Uri as an asynchronous operation and with correct character encoding (utf9) and contenct type (application/json).
            _posts.Insert(0, post); //Updating the UI by inserting an element into the first index of the collection 
        }

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

