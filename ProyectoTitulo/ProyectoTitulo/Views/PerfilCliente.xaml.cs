using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoTitulo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PerfilCliente : ContentPage
	{
		public PerfilCliente ()
		{
			InitializeComponent ();
            TraerCliente();
		}
        private async void TraerCliente()/*Este metodo trae la informacion ingresada del cliente*/
        {
            HttpClient cliente = new HttpClient();

            string url = "http://webapiproyectotitulo.azurewebsites.net/api/Clientes";

            var resultado = await cliente.GetAsync(url);

            var json = resultado.Content.ReadAsStringAsync().Result;

            ClientesModel modelo = ClientesModel.FromJson(json);

            

            

        }

    }
}