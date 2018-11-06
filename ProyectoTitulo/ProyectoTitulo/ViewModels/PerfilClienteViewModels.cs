using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ProyectoTitulo.ViewModels;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ProyectoTitulo.ViewModels
{
  
    public class ClientesModel
    {

        public ObservableCollection<ClientesModel> clientes { get; set; }

        public ClientesModel()
        {
            if(clientes==null)
            {
                clientes = new ObservableCollection<ClientesModel>();
            }
        }

        public ObservableCollection<ClientesModel> Consultar()
        {
            return clientes;

        }
        public void AgregarCliente(ClientesModel modelo)
        {
            clientes.Add(modelo);

        }
    }
}
