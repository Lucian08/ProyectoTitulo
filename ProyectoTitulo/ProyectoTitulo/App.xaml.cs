using ProyectoTitulo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ProyectoTitulo
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            NavigationPage navPage = new NavigationPage(new ProyectoTitulo.MainPage());/*Ayuda en la navegacion de las paginas*/
            MainPage = navPage;

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
