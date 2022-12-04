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
    public class ViewModelPersona : INotifyPropertyChanged
    {
        public ViewModelPersona()
        {

            AbrirArchivo();


            CrearPersona = new Command(() => {

                persona1 = new Persona()
                {

                    nombre = this.nombre,
                    apellido = this.apellido,
                    celular = this.celular,
                    correo = this.correo,

                };

                //Rutina de Serializacion
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, persona1);
                archivo.Close();

                listaPersona.Add(persona1);

                Guardar = "";
                foreach (Persona tmp in listaPersona)
                {

                    Guardar += tmp.toString() + "\r\n";
                }

            });

            Limpiar = new Command(() => {

                listaPersona = new ObservableCollection<Persona>();

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Ciculos.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, listaPersona);
                archivo.Close();

                Guardar = "";

            });
        }

        private void AbrirArchivo()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                persona1 = (Persona)formatter.Deserialize(archivo);
                archivo.Close();

                Nombre = persona1.nombre;
                Apellido = persona1.apellido;
                Celular = persona1.celular;
                Correo = persona1.correo;

                Guardar += persona1.toString();
            }
            catch (Exception e)
            {


            }
        }


            Persona persona1 = new Persona();

        ObservableCollection<Persona> listaPersona = new ObservableCollection<Persona>();




        string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string apellido;
        public string Apellido
        {
            get => apellido;
            set
            {
                apellido = value;
                var arg = new PropertyChangedEventArgs(nameof(Apellido));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        double celular;
        public double Celular
        {
            get => celular;
            set
            {
                celular = value;
                var arg = new PropertyChangedEventArgs(nameof(Celular));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string correo;
        public string Correo
        {
            get => correo;
            set
            {
                correo = value;
                var arg = new PropertyChangedEventArgs(nameof(Correo));
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


        public Command CrearPersona { get; }

        public Command Limpiar { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
