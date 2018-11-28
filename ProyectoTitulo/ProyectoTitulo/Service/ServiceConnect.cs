using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ProyectoTitulo.Service
{
    public class ServiceConnect
    {
        private const string BASE = "http://webapiproyectotitulo.azurewebsites.net/api/";
        //public static int PORT = 80;


        public static async System.Threading.Tasks.Task<HttpResponseMessage> PostAsync(string path, object objeto){

            var url = new Uri($"{BASE}{path}");

            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                response = await httpClient.PostAsync(
                                                          url,
                                                          new StringContent(
                                                                Newtonsoft.Json.JsonConvert.SerializeObject(objeto),
                                                                Encoding.UTF8,
                                                                "application/json")
                                                          ); 
            }
            return response;

        } 

        public static async System.Threading.Tasks.Task<List<T>> GetAllAsync<T>(string path)//path = "comunas"
        {
            Console.WriteLine($"{BASE}{path}");

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync($"{BASE}{path}");
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }

        public static async System.Threading.Tasks.Task<T> GetByIdAsync<T>(string path, int id)//path = "comunas"
        {

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync($"{BASE}{path}/{id}");
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

    }
}
