//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTitulo.Models
{
    using System;
    
    
    public partial class Cliente
    {
        
        public Cliente()
        {
            
        }
    
        public int Id { get; set; }
        public int Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte[] Foto { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    
        
    }
}