using ProyectoTitulo.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoTitulo.ViewModel
{
    public class HomeClienteViewModel : ViewModelBase
    {
        public INavigation Navigation { get; set; }
        public ICommand LogoutCommand { get; set; }
        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public HomeClienteViewModel()
        {
            LogoutCommand = new Command(Logout);
            Message = "Bienvenido";
        }

        private async void Logout()
        {
            Settings.IsLoggedIn = false;
            await Navigation.PushModalAsync(new Login());
        }
    }
}