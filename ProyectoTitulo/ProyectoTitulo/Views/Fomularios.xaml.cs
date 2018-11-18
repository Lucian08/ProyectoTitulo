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
    public partial class Fomularios : TabbedPage
    {

        public Fomularios()
        {
            InitializeComponent();

            dtpFechaNacimiento.MinimumDate = new DateTime(1990, 1, 1);
            dtpFechaNacimiento.MaximumDate = new DateTime(2000, 12, 31);
        }


        private async void GuardarCliente(object sender, EventArgs e)
        {
            if (Rut.Text == "" || Nombre.Text == "" || Apellido.Text == "" || emailEntry.Text == "" || Clave.Text == "")
            {
                await DisplayAlert("ALERTA", "Por favor complete todos los campos ", "ok");

            }
            else
            {

                var cliente = new ClientesModel()
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

                }
                LimpiarFormulario();

                await DisplayAlert("Bienvenido", "Hola te has registrado exitosamente", "Ok");


            }


        }

        public void LimpiarFormulario()
        {

            Rut.Text = "";
            Nombre.Text = "";
            Apellido.Text = "";
            emailEntry.Text = "";
            Clave.Text = "";
        }

       

        private async void GuardarAsesor(object sender, EventArgs e)
        {
            if (Rut.Text == "" || NombreAsesor.Text == "" || ApellidoPaterno.Text == "")
            {
                await DisplayAlert("ALERTA", "Por favor complete todos los campos ", "ok");

            }
            else
            {

                var asesors = new AsesorModel()
                {
                    Rut = Convert.ToInt32(RutAsesor.Text),
                    Nombre = NombreAsesor.Text,
                    ApellidoPaterno = ApellidoPaterno.Text,
                    ApellidoMaterno = ApellidoMaterno.Text,
                    /*Sexo = Convert.ToInt32(SexoAsesor.),*/
                    /*FechaNacimiento = dtpFechaNacimiento.SetValue.Date, ¡¡¡Aun falta!!!*/
                    /*Guardar nacionalida falta*/
                    /*Comuna=Convert.ToInt32(Comuna.ItemsSource),*/
                    /*Guardar horario falta*/
                    Fono = Convert.ToInt32(Fono.Text),
                    Correo = CorreoAsesor.Text,
                    Contrasena=Clave.Text,


                };

                try
                {
                    HttpClient client = new HttpClient();
                    var url = new Uri("http://webapiproyectotitulo.azurewebsites.net/api/Asesors");

                    var response = await client.PostAsync(
                      url,
                      new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(asesors), Encoding.UTF8, "application/json")
                      );


                }
                catch (Exception es)
                {
                    Console.WriteLine("Exceptionb " + es.Message);

                }
                LimpiarFormulario();

                await DisplayAlert("Bienvenido", "Hola te has registrado exitosamente", "Ok");



            }
        }

        private void SexoAsesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sexoseleccionado = SexoAsesor.SelectedItem as string;
            DisplayAlert("Selección", sexoseleccionado, "Ok");
        }

       
    }
}


