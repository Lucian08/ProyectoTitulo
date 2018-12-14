using ProyectoTitulo.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace ProyectoTitulo.MyDataSource
{

    public class MyData
    {
        //List<Comuna> listado =   await ServiceConnect.GetAllAsync<Comuna>("Comunas");/*Aqui se cargan todas las comunas desde la DB*/
        //Console.WriteLine(listado.Count());
        //foreach (var comuna in listado) {
        //    //ControlXamarin
        //    Console.WriteLine(comuna.Nombre); 
        //    PickerComuna.Items.Add(comuna.Nombre);
        //}
        /*public List<Asesor> Asesors = new List<Asesor>()
        {
            new Asesor()
            {
                Id=1,
                Nombre="Luciano",
                ApellidoPaterno="Alvares"
            },
            new Asesor()
            {
                Id=2,
                Nombre="Lucianito",
                ApellidoPaterno="Alvares"
            }
        };*/

        List<Asesor> asesorList;
        int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;

                }
            }
        }
        public List<Asesor> AsesorList
        {
            get { return asesorList; }
            set
            {
                if (asesorList != value)
                {
                    asesorList = value;

                }
            }
        }
    }
}