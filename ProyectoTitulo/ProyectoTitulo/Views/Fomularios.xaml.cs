using ProyectoTitulo.Models;
using ProyectoTitulo.Service;
using ProyectoTitulo.ViewModels;
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


        Dictionary<int, string> comunaList = new Dictionary<int, string>();

        public Fomularios()
        {
            InitializeComponent();

            dtpFechaNacimiento.MinimumDate = new DateTime(1990, 1, 1);
            dtpFechaNacimiento.MaximumDate = new DateTime(2000, 12, 31);

            CargarComunaAsync();
            CargarSexoPicker();
            CargarNacionalidadPicker();

        }

         
        private async Task<List<Comuna>> GetComunasAsync()
        {
            return await ServiceConnect.GetAllAsync<Comuna>("Comunas"); 
        }

        private async Task CargarComunaAsync() {

          this.BindingContext = new AsesorViewModel
          {
                ComunaList = await GetComunasAsync()
          };

            //List<Comuna> listado =   await ServiceConnect.GetAllAsync<Comuna>("Comunas");/*Aqui se cargan todas las comunas desde la DB*/
            //Console.WriteLine(listado.Count());
            //foreach (var comuna in listado) {
            //    //ControlXamarin
            //    Console.WriteLine(comuna.Nombre); 
            //    PickerComuna.Items.Add(comuna.Nombre);
            //}
        }

        private void CargarSexoPicker()/*Carga el picker mostrando los sexo*/
        {

            var listadoSexo = new List<string>();
            listadoSexo.Add("Femenino");
            listadoSexo.Add("Masculino");
           
            SexoAsesorPicker.ItemsSource = listadoSexo;
        }

        private void CargarNacionalidadPicker()
        {
            var listadoNacionalidad = new List<string>();
            listadoNacionalidad.Add("Chilena");
            listadoNacionalidad.Add("Argentina");
            listadoNacionalidad.Add("Peruana");
            listadoNacionalidad.Add("Boliviana");

            NacionalidadPicker.ItemsSource = listadoNacionalidad;
        }

        public void LimpiarFormulario()
        {

            Rut.Text = "";
            Nombre.Text = "";
            Apellido.Text = "";
            emailEntry.Text = "";
            Clave.Text = "";
        }



        private async void GuardarCliente(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Rut.Text)||String.IsNullOrEmpty(Nombre.Text)||String.IsNullOrEmpty(emailEntry.Text)
                ||String.IsNullOrEmpty(Clave.Text))
            {
                await DisplayAlert("ALERTA", "Por favor complete todos los campos ", "Ok");

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

        
        private async void GuardarAsesor(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RutAsesor.Text) || String.IsNullOrEmpty(NombreAsesor.Text)|| String.IsNullOrEmpty(ApellidoPaternoAs.Text)
                
                || String.IsNullOrEmpty(IdComunaLabel.Text) || String.IsNullOrEmpty(ApellidoMaternoAs.Text) || String.IsNullOrEmpty(IdComunaLabel.Text)
                || String.IsNullOrEmpty(PrecioHora.Text) || String.IsNullOrEmpty(SobreMi.Text)|| String.IsNullOrEmpty(Fono.Text)
                || String.IsNullOrEmpty(CorreoAsesor.Text) || String.IsNullOrEmpty( ClaveAsesor.Text)){

                await DisplayAlert("ALERTA", "Por favor complete todos los campos ", "ok");

            }
            else
            {

                var asesor = new Asesor()
                {
                    Rut = Convert.ToInt32(RutAsesor.Text),
                    Nombre = NombreAsesor.Text,
                    ApellidoPaterno = ApellidoPaternoAs.Text,
                    ApellidoMaterno = ApellidoMaternoAs.Text,
                    Sexo = SexoAsesorPicker.SelectedItem.ToString(),
                    FechaNacimiento = dtpFechaNacimiento.Date,
                    Nacionalidad = NacionalidadPicker.SelectedItem.ToString(),
                    IdComuna=  Convert.ToInt32(IdComunaLabel.Text ),
                    ValorHora = Convert.ToInt32(PrecioHora.Text),
                    Comentario = SobreMi.Text,
                    Fono = Convert.ToInt32(Fono.Text),
                    Correo = CorreoAsesor.Text,
                    Contrasena= ClaveAsesor.Text,
                };


                /* await DisplayAlert("ciudad", "id " + IdComuna.Text, "ok");*/

                await ServiceConnect.PostAsync("Asesors", asesor);


                await DisplayAlert("Bienvenido" + NombreAsesor.Text, "te has registrado exitosamente", "Ok");


            }
        }
    }

       /* private void SexoAsesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sexoseleccionado = SexoAsesor.SelectedItem as string;
            DisplayAlert("Selección", sexoseleccionado, "Ok");
        }*/

       
    
}


