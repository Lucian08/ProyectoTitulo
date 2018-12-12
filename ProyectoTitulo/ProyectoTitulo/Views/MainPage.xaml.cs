using ProyectoTitulo.Models;
using ProyectoTitulo.MyDataSource;
using ProyectoTitulo.Service;
using ProyectoTitulo.ViewModels;
using ProyectoTitulo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
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
            //BindingContext = new AsesorViewModel();

            CargarAsesorAsync();


        }

        private async Task<List<Asesor>> GetAsesorAsync()
        {
            return await ServiceConnect.GetAllAsync<Asesor>("Asesors");
        }

        private async Task CargarAsesorAsync()
        {

            this.BindingContext = new MyData
            {
                AsesorList = await GetAsesorAsync()
            };

            
        }



        /*Nuevo*/
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
