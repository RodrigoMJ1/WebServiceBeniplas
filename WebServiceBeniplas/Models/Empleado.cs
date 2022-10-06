using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beniplas.Model
{
    public class Empleado
    {
        public int ID { get; set; }
        public long Codigo { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public long NumTel { get; set; }
        public string Contrasena { get; set; }
        public bool Status { get; set; }
        public virtual List<RegistroAperturaEmpleado> RegistroAperturaEmpleados { get; set; }
    }
    public class EmpleadoDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public long NumTel { get; set; }
        public bool Status { get; set; }
    }
}
