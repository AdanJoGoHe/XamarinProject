using Newtonsoft.Json;
using oldSolutions.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Net;
using oldSolutions.Vista.DrawMenu;

namespace oldSolutions.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaLogin : ContentPage
	{
        public ObservableCollection<PostOperador> Posts { get; set; }
        private HttpCliente connection = new HttpCliente("operador/"); //Instancia de la clase HttpCliente
        
        private Core core = new Core();
        public VistaLogin ()
		{
			InitializeComponent ();
            

        }

        protected override async void OnAppearing()
        {
            logoEmpresa.Source = core.logoEmpresa;
            botonEnviar.IsEnabled=false;
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
                
                if(conexionBool)
                {
                    botonEnviar.IsEnabled = true;
                    conexion = "Hay conexión";
                }
                TestConexion.Text = conexion;
            }
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Boolean error = false;
            failMsg.IsVisible = false;
            string msgerror = " ";
            if(passInput.Text==null)
            {
                error = true;                
            }
            if(dniEntry.Text==null)
            {
                error = true;
            }
            if(error==false)
            {
                PostOperador po = null;
                try
                {
                    po = Posts.FirstOrDefault(o => o.Dni == dniEntry.Text);
                }
                catch(Exception)
                {
                    Test.Text = "Ha ocurrido un error";
                }
                
                if(po!=null)
                {
                    Test.Text = "ESTOY AQUI";
                    var aux = core.Hash(passInput.Text);
                    if (aux == po.password)
                    {
                        Test.Text = "Viva - " + aux + " - " + po.password;
                        await Navigation.PushModalAsync(new DrawPage());
                    }
                    else
                        Test.Text = "Nooo..  - " + aux + " - " + po.password;
                        failMsg.IsVisible = true;
                        msgerror = "No existe el usuario o la contraseñá";
                        failMsg.Text = msgerror;
                }
                else
                {
                    failMsg.IsVisible = true;
                    msgerror = "No existe el usuario o la contraseñá";
                    failMsg.Text = msgerror;
                }
            }
            else
            {
                failMsg.IsVisible = true;
                msgerror = "Hay campos vacios...";
                failMsg.Text = msgerror;
            }
            


        }

       
    }
}