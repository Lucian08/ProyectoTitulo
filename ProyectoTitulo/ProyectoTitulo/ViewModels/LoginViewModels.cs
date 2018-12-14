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
        private Cliente _user = new Cliente();

        public Cliente Cliente
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
                if (String.IsNullOrEmpty(Cliente.Correo) || String.IsNullOrEmpty(Cliente.Contrasena))
                {
                    IsBusy = false;
                    Message = "Uno o 2 campos estan bacios";
                }
                else
                {
                    /*
                     * consulta a la base de datos
                     * segun pestaña
                     * si login viene de pestaña 1
                     * > haces la consulta a la tabla 1
                     * 
                     if (User.Email == "rescatado de base" && User.Password == "rescatado de base")

                    consultar a la base de datos. el nivel del usuario que hizo login

                    if (pestaña=1){
                    //asumes que es asesor
                    }else{
                    //pestaña = 2 -> cliente
                    }
                    */

                    /*var cliente = new ClientesModel()
                    {
                        Rut = Convert.ToInt32(Rut.Text),
                        Nombre = Nombre.Text,
                        Apellido = Apellido.Text,
                        Correo = emailEntry.Text,
                        Contrasena = Clave.Text
                    };

                    try
                    {
                        HttpClient client = new HttpClient();
                        var url = new Uri("http://webapiproyectotitulo.azurewebsites.net/api/Clientes");

                        var response = await client.PostAsync(
                          url,
                          new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json")
                          );


                    }
                    catch (Exception es)
                    {
                        Console.WriteLine("Exceptionb " + es.Message);

                    }*/

                    if (Cliente.Correo == "luciano@gmail.com" && Cliente.Contrasena == "123")
                        {
                            Settings.IsLoggedIn = true;
                            await Navigation.PushModalAsync (new HomeCliente());
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
