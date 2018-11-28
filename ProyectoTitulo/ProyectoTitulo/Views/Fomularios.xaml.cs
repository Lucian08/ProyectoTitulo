using ProyectoTitulo.Models;
using ProyectoTitulo.Service;
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
            CargarComunaAsync();
        }
        private async Task CargarComunaAsync() {
            
            List<Comuna> listado =   await ServiceConnect.GetAllAsync<Comuna>("Comunas");/*Aqui se cargan todas las comunas desde la DB*/
            Console.WriteLine(listado.Count());
            foreach (var comuna in listado) {
                //ControlXamarin
                Console.WriteLine(comuna.Nombre);
                PickerComuna.Items.Add(comuna.Nombre);
               
            }
        }

        

        private async void GuardarCliente(object sender, EventArgs e)
        {
            if (Rut.Text == "" || Nombre.Text == "" || Apellido.Text == "" || emailEntry.Text == "" || Clave.Text == "")
            {
                await DisplayAlert("ALERTA", "Por favor complete todos los campos ", "ok");

            }
            else
            {

                var cliente = new Cliente()
                {
                    Rut = Convert.ToInt32(Rut.Text),
                    Nombre = Nombre.Text,
                    Apellido = Apellido.Text,
                    Correo = emailEntry.Text,
                    Contrasena = Clave.Text
                };

                await ServiceConnect.PostAsync("Clientes", cliente);
                 
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

                var asesors = new Asesor()
                {
                    Rut = Convert.ToInt32(RutAsesor.Text),
                    Nombre = NombreAsesor.Text,
                    ApellidoPaterno = ApellidoPaterno.Text,
                    ApellidoMaterno = ApellidoMaterno.Text,
                    Sexo = (SexoAsesor.SelectedIndex == 0) ? "Femenino" : "Masculino",
                    /*FechaNacimiento = dtpFechaNacimiento.SetValue.Date,*/
                    Nacionalidad = Nacionalidad.SelectedItem.ToString(),
                    /*Comuna= Convert.ToInt32(PickerComuna.SelectedItem),*/
                    /*Guardar horario falta*/
                    Fono = Convert.ToInt32(Fono.Text),
                    Correo = CorreoAsesor.Text,
                    Contrasena=Clave.Text,


                };
                await DisplayAlert ("Prueba" , "su sexo" + SexoAsesor, "ok");

                await ServiceConnect.PostAsync("Asesors", asesors);

                LimpiarFormulario();

                await DisplayAlert("Bienvenido", "Hola te has registrado exitosamente", "Ok");



            }
        }

       /* private void SexoAsesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sexoseleccionado = SexoAsesor.SelectedItem as string;
            DisplayAlert("Selección", sexoseleccionado, "Ok");
        }*/

       
    }
}


