using SalonBelleza.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace SalonBelleza.ViewModels
{
    public class ViewModelServicio : INotifyPropertyChanged
    {
        public ViewModelServicio()
        {
            AbrirArchivo();

            CrearServicio = new Command(() =>
            {
                Servicio servicio1 = new Servicio() 
                { 
                    servicio = this.Servicio,
                    precio = this.Precio,
                    fecha = this.Fecha,
                    hora = this.Hora
                };

                persona1.lista_servicio.Add(servicio1);

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, persona1);
                archivo.Close();

                Guardar = "";

                foreach (Servicio x in persona1.lista_servicio)
                {
                    Guardar += x.toString() + "\n\t";
                }
            });

            Limpiar = new Command(() => {

                persona1.lista_servicio = new ObservableCollection<Servicio>();

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Ciculos.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, persona1.lista_servicio);
                archivo.Close();

                Guardar = "";

            });
        }




        private void AbrirArchivo()
        {
            // Es una estructura 

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                persona1 = (Persona)formatter.Deserialize(archivo);
                archivo.Close();

                Guardar = "";

                foreach (Servicio x in persona1.lista_servicio)
                {

                    Guardar += x.toString();

                }
            }
            catch (Exception e)
            {


            }
        }

        Persona persona1 = new Persona();

        string servicio;
        public string Servicio
        {
            get => servicio;
            set
            {
                servicio = value;
                var arg = new PropertyChangedEventArgs(nameof(Servicio));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        double precio;
        public double Precio
        {
            get => precio;
            set
            {
                precio = value;
                var arg = new PropertyChangedEventArgs(nameof(Precio));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        DateTime fecha = DateTime.Today;
        public DateTime Fecha
        {
            get => fecha;
            set
            {
                fecha = value;
                var arg = new PropertyChangedEventArgs(nameof(Fecha));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        TimeSpan hora;
        public TimeSpan Hora
        {
            get => hora;
            set
            {
                hora = value;
                var arg = new PropertyChangedEventArgs(nameof(Hora));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        string guardar;

        public string Guardar
        {
            get => guardar;
            set
            {
                guardar = value;
                var arg = new PropertyChangedEventArgs(nameof(Guardar));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public Command CrearServicio { get; }

        public Command Limpiar { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
