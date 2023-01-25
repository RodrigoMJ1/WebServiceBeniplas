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
        public string Codigo { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool Status { get; set; }
        public virtual List<RegistroAperturaEmpleado> RegistroAperturaEmpleados { get; set; }
    }
    public class EmpleadoDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Correo { get; set; }
        public bool Status { get; set; }
        public string Contrasena { get; set; }
        public int Sucursal_ID { get; set; }

    }
    
    public class EmpleadoDTO2
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Correo { get; set; }
        public bool Status { get; set; }
    }

}
