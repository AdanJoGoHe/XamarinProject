﻿using Newtonsoft.Json;
using oldSolutions.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            string conexion = "conectando...";
            Boolean conexionBool = true;
            string content = null;
            try
            {
                content = await connection.Response.GetStringAsync(connection.Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
                List<PostProducto> posts = JsonConvert.DeserializeObject<List<PostProducto>>(content); //Deserializes or converts JSON String into a collection of Post
                Posts = new ObservableCollection<PostProducto>(posts); //Converting the List to ObservalbleCollection of Post 
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
            lista.ItemsSource = Posts;
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
            lista.SelectedItem = null;
        }


    }
}