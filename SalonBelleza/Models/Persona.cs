using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SalonBelleza.Models
{

    [Serializable]
    public class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public double celular { get; set; }
        public string correo { get; set; }

        public ObservableCollection<Cursos> lista_cursos { get; set; } = new ObservableCollection<Cursos>();
        public ObservableCollection<Servicio> lista_servicio { get; set; } = new ObservableCollection<Servicio>();

        public string toString()
        {
            return "Nombre: " + nombre + "\n" + "Apellido: " + apellido + "\n" +
                "Celular: " + celular + "\n" + "Correo electronico: " + correo + "\n\t";
        }


    }
}
