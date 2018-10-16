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
	public partial class Fomularios : TabbedPage
	{
		public Fomularios ()
		{
			InitializeComponent ();

            dtp.MinimumDate=new DateTime(1990, 1, 1);
            dtp.MaximumDate = new DateTime(2000, 12, 31);
        }
	}
}