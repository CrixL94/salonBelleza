using System;
using System.Collections.Generic;
using System.Text;

namespace SalonBelleza.Models
{
    [Serializable]
    public class Cursos
    {
        public string curso { get; set; }
        public DateTime fechaInicio { get; set; }
        public double precio { get; set; }
        public string duracion { get; set; }

        public string toString()
        {
            return "Nombre del curso: " + curso + "\n" + "Precio: " + precio + "\n" + 
                "Fecha de inicio: " + fechaInicio.ToString("MM-dd-yyyy") + "\n" + "Tiempo de duración: " + duracion + "\n\t";
        }


    }
}
