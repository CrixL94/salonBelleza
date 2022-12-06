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
    public class ViewModelCurso : INotifyPropertyChanged
    {
        public ViewModelCurso()
        {
            AbrirArchivo();

            CrearCurso = new Command(() =>
            {
                Cursos curso1 = new Cursos()
                {
                    curso = this.Curso,
                    precio = this.Precio,
                    fechaInicio = this.Fecha,
                    duracion = this.Duracion
                };

                persona1.lista_cursos.Add(curso1);

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, persona1);
                archivo.Close();

                Guardar = "";

                foreach (Cursos x in persona1.lista_cursos)
                {
                    Guardar += x.toString() + "\n\t";
                }
            });

            Limpiar = new Command(() => {

                persona1.lista_cursos = new ObservableCollection<Cursos>();

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Ciculos.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, persona1.lista_cursos);
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

                foreach (Cursos x in persona1.lista_cursos)
                {

                    Guardar += x.toString();

                }
            }
            catch (Exception e)
            {


            }
        }

        Persona persona1 = new Persona();

        string curso;
        public string Curso
        {
            get => curso;
            set
            {
                curso = value;
                var arg = new PropertyChangedEventArgs(nameof(Curso));
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

        string duracion;
        public string Duracion
        {
            get => duracion;
            set
            {
                duracion = value;
                var arg = new PropertyChangedEventArgs(nameof(Duracion));
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

        public Command CrearCurso { get; }

        public Command Limpiar { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
