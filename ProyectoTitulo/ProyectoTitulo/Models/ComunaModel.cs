/*using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTitulo.Models
{
    public partial class comunaModel
    {
        [JsonProperty("$id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("Asesor")]
        public Asesor[] Asesor { get; set; }

        [JsonProperty("Region")]
        public Region Region { get; set; }

        [JsonProperty("Direccion")]
        public object[] Direccion { get; set; }

        [JsonProperty("Id")]
        public long ComunaId { get; set; }

        [JsonProperty("IdRegion")]
        public long IdRegion { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
    }
}*/
