using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoTitulo.Behaviors
{
    public class SoloNumeroBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry cajaTexto)
        {
            cajaTexto.TextChanged += CambiaTexto;
            base.OnAttachedTo(cajaTexto);
        }
        protected override void OnDetachingFrom(Entry cajaTexto)
        {
            cajaTexto.TextChanged -= CambiaTexto;
            base.OnDetachingFrom(cajaTexto);
        }
        private void CambiaTexto(object sender, TextChangedEventArgs args)
        {
            bool valido = int.TryParse(args.NewTextValue, out int resultado);
            ((Entry)sender).TextColor = valido ? Color.Default : Color.Red;
        }

    }
}
