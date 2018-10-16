// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ProyectoTitulo;
//
//    var clientesModel = ClientesModel.FromJson(jsonString);

namespace ProyectoTitulo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ClientesModel
    {
        [JsonProperty("clientes")]
        public Cliente[] Clientes { get; set; }
    }

    public partial class Cliente
    {
        [JsonProperty("$id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("Direccion")]
        public object[] Direccion { get; set; }

        [JsonProperty("Servicio")]
        public object[] Servicio { get; set; }

        [JsonProperty("Id")]
        public long ClientesModelId { get; set; }

        [JsonProperty("Rut")]
        public long Rut { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Apellido")]
        public string Apellido { get; set; }

        [JsonProperty("Foto")]
        public object Foto { get; set; }

        [JsonProperty("Correo")]
        public string Correo { get; set; }

        [JsonProperty("Contraseña")]
        public string Contraseña { get; set; }
    }

    public partial class ClientesModel
    {
        public static ClientesModel FromJson(string json) => JsonConvert.DeserializeObject<ClientesModel>(json, ProyectoTitulo.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ClientesModel self) => JsonConvert.SerializeObject(self, ProyectoTitulo.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
