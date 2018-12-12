using ProyectoTitulo.Models;
using ProyectoTitulo.MyDataSource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProyectoTitulo.ViewModels
{
    public class AsesorViewModel : INotifyPropertyChanged
    {
       

        /*private ObservableCollection<Asesor> asesors;



          public ObservableCollection<Asesor> Asesors
          {
              get { return asesors; }
              set
              {
                  asesors = value;
              }
          }

          public AsesorViewModel()
          {
              Asesors = new ObservableCollection<Asesor>();
              MyData _context = new MyData();

              foreach(var asesor in _context.Asesors)
              {
                  Asesors.Add(asesor);
              }
          }*/


        /*De Aqui se carga las comunas*/
        public event PropertyChangedEventHandler PropertyChanged;

        List<Comuna> comunaList;
        int id;
        string nombre;
        public string Nombre {
            get { return nombre; }
            set {
                if (nombre != value) {
                    nombre = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Id {
            get { return selectedComuna.Id; }
            set {
                if (id != value) {
                    id = value;
                    OnPropertyChanged();
                }


            }
        }
        public List<Comuna> ComunaList
        {
            get { return comunaList; }
            set
            {
                if (comunaList != value)
                {
                    comunaList = value;
                    OnPropertyChanged();
                }
            }
        }

        Comuna selectedComuna;
        public Comuna SelectedComuna
        {
            get { return selectedComuna; }
            set
            {
                if (selectedComuna != value)
                {
                    selectedComuna = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Id");
                    OnPropertyChanged("Nombre");

                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
       
    }
}
