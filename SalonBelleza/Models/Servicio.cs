using System;
using System.Collections.Generic;
using System.Text;

namespace SalonBelleza.Models
{
    [Serializable]
    public class Servicio
    {
        public string servicio { get; set; } 
        public double precio { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }

        public string toString()
        {
            return "Servicio: " + servicio + "\n" + "Precio del servicio: " + precio + "\n" + 
                "Fecha: " + fecha.ToString("MM-dd-yyyy") + "\n" + "Hora: " + hora;
        }

    }
}
