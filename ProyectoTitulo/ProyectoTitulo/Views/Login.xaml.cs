using ProyectoTitulo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoTitulo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{


        private LoginViewModels viewModel;
        public Login()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModels();
            viewModel.Navigation = this.Navigation;
        }

      

        protected override bool OnBackButtonPressed()
        {
            // This prevents a user from being able to hit the back button and leave the login page.
            return true;
        }

        private void Ir_Formularios(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Fomularios());
        }

        



        /*private void IrAHome(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomeCliente());
        }*/
    }
}