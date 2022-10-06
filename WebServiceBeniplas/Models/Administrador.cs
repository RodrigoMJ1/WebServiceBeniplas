using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beniplas.Model
{
    public class Administrador
    {
        public int ID { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public long NumTel { get; set; }
        public string Contrasena { get; set; }
        public virtual List<RegistroAperturaAdministrador> RegistroAperturaAdministradores { get; set; }
    }
}
