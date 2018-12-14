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

        public List<Asesor> tempdata;
        public MainPage()
		{
			InitializeComponent();
            //BindingContext = new AsesorViewModel();

            CargarAsesorAsync();


           //AsesorListView.ItemsSource = tempdata;

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

       /* private void AsesorSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                AsesorListView.ItemsSource = tempdata;
            }

            else
            {
                AsesorListView.ItemsSource = tempdata.Where(x => x.Nombre.StartsWith(e.NewTextValue));
            }

        }*/



        

        /* private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
         {
             // DisplayAlert("Buscando","Buscando resultados","Ok");

             var keyword = AsesorSearchBar.Text;


             AsesorListView.ItemsSource = nombre.Where(Nombre => nombre.Contains(keyword));



         }*/

        /*private void AsesorSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            var keyword = AsesorSearchBar.Text;

            var result = asesorList.Where(x => x.ToLower().Contains(keyword.ToLower));
            //AsesorList.ItemsSource = nombre.Where(Nombre => nombre.Contains(keyword));

            AsesorListView.ItemsSource = result;

        }*/
    }
}
