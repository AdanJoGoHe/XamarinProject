using oldSolutions.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace oldSolutions.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaOperadorSeleccionado : ContentPage
	{
        public PostOperador op;
        public VistaOperadorSeleccionado (PostOperador postOperador)
		{
            op = postOperador;
            InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            idOperador.Text = op.Id.ToString();
            nombreOperador.Text = op.Nombre;
            apellidosOperador.Text = op.Apellidos;
            dniOperador.Text = op.Dni;
        }
            
	}
}