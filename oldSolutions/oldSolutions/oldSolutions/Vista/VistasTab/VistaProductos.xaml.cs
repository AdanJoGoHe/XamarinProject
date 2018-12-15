using Newtonsoft.Json;
using oldSolutions.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace oldSolutions.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaProductos : ContentPage
	{
        public ObservableCollection<PostProducto> Posts { get; set; }
        private HttpCliente connection = new HttpCliente("producto/"); //Instancia de la clase HttpCliente

        public VistaProductos ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            string content = await connection.Response.GetStringAsync(connection.Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            List<PostProducto> posts = JsonConvert.DeserializeObject<List<PostProducto>>(content); //Deserializes or converts JSON String into a collection of Post
            Posts = new ObservableCollection<PostProducto>(posts); //Converting the List to ObservalbleCollection of Post            
            listProductsView.ItemsSource = Posts; //Assigning the ObservableCollection to MyListView in the XAML of this file           
            base.OnAppearing();
        }

        private async void AddProductoToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaProductoSeleccionado());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PostProducto;
            if (item == null)
                return;

            await Navigation.PushAsync(new VistaProductoSeleccionado(item));

            // Manually deselect item.
            listProductsView.SelectedItem = null;
        }


    }
}