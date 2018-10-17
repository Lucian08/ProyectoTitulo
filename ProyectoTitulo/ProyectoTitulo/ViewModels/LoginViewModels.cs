using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using ProyectoTitulo.Helpers;
using ProyectoTitulo.Models;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoTitulo.ViewModel
{
    public class LoginViewModels : ViewModelBase
    {

        #region Commands
        public INavigation Navigation { get; set; }
        public ICommand LoginCommand { get; set; }
        #endregion

        #region Properties
        private User _user = new User();

        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        #endregion

        public LoginViewModels()
        {
            LoginCommand = new Command(Login);
        }
        public async void Login()
        {
           IsBusy = true;
            Title = string.Empty;
            try
            {
                if (User.Email == ("") || User.Password == (""))
                {
                    IsBusy = false;
                    Message = "Uno o 2 campos estan bacios";
                }
                else
                {
                    if (User.Email == "luciano@gmail.com" && User.Password == "123456")
                    {
                        Settings.IsLoggedIn = true;
                        await Navigation.PushModalAsync(new HomeCliente());
                    }
                    else
                    {
                       
                        Message = "Usuario o contraseña incorrecta";
                    }
                    IsBusy = false;

                }  
                 
            }
            catch (Exception e)
            {
                IsBusy = false;
                await App.Current.MainPage.DisplayAlert("Error de conexión", e.Message, "Ok");
            }
        }
    }
}
