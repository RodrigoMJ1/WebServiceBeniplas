using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beniplas.Model
{
    public class RegistroAperturaEmpleado
    {
        public int ID { get; set; } 
        public string Comentario { get; set; }
        public string FechaHora  { get; set; }
    }

    public class RegistroAperturaEmpleadoDTO
    {
        public int ID { get; set; }
        public string Comentario { get; set; }
        public string FechaHora { get; set; }
        public int Empleado_ID { get; set; }
    }
}
