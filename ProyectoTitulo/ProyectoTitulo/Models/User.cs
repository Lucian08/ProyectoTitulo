using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTitulo.Models
{
    public class User: ClientesModel
    {

        public string Email { get; set; }
        public string Password { get; set; }
       
    }
}