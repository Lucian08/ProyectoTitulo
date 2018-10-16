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
	public partial class HomeCliente : MasterDetailPage
	{

        private HomeClienteViewModel viewModel;
        public HomeCliente ()
		{
            InitializeComponent();
            BindingContext = viewModel = new HomeClienteViewModel();
            viewModel.Navigation = this.Navigation;
        }

        protected override bool OnBackButtonPressed()
        {
            // This prevents a user from being able to hit the back button and leave the login page.
            return true;

        }

        private void IrAPerfilCliente(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PerfilCliente());
        }
    }
}