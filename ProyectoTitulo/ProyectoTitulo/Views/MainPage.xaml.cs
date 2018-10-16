using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ProyectoTitulo
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void IrAlogin(Object sender, EventArgs e)/*Este es el evento del boton 
                                                            el cual cambia a la pagina login*/
        {
            Navigation.PushAsync(new Login());

        }

        private void IrAFormulario(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new Fomularios());

        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)/*Es el evento de busqueda*/
        {
            DisplayAlert("Buscando","Buscando resultados","Ok");

        }

       
    }
}
