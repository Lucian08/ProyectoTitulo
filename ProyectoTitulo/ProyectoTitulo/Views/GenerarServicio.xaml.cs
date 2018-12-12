using ProyectoTitulo.Models;
using ProyectoTitulo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoTitulo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GenerarServicio : ContentPage
	{
		public GenerarServicio ()
		{
			InitializeComponent ();
            CargarAsesor();
		}
        private async Task CargarAsesor()
        {

            List<Asesor> listado = await ServiceConnect.GetAllAsync<Asesor>("Asesors");/*Aqui se cargan todas las comunas desde la DB*/
            Console.WriteLine(listado.Count());
            foreach (var asesor in listado)
            {
                //ControlXamarin
                Console.WriteLine(asesor.Nombre);
                AsesorPicker.Items.Add(asesor.Nombre);

            }
        }

        private void GuardarServicio(object sender, EventArgs e)
        {

        }
    }
}