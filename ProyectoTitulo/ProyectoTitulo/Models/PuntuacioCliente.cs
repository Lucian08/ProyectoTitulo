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
   
    public partial class PuntuacioCliente
    {
        public int Id { get; set; }
        public Nullable<int> IdAsesor { get; set; }
        public Nullable<int> IdReserva { get; set; }
        public string Comentario { get; set; }
        public int Puntos { get; set; }
    
        public virtual Asesor Asesor { get; set; }
        public virtual Servicio Servicio { get; set; }
    }
}
