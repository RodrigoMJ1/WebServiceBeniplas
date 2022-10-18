using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beniplas.Model
{
    public class Gerente
    {
        public int ID { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Region { get; set; }
        public long NumTel { get; set; }
        public string Contrasena { get; set; }
        public bool Status { get; set; }
        public virtual List<Sucursal> Sucursales { get; set; }
        public virtual List<RegistroAperturaGerente> RegistroAperturaGerentes { get; set; }

    }

    public class GerenteDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Region { get; set; }
        public long NumTel { get; set; }
        public bool Status { get; set; }

    }

    public class GerenteDTO2
    {
        public int ID { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Region { get; set; }
        public long NumTel { get; set; }
        public string Contrasena { get; set; }
        public bool Status { get; set; }
        public int Empresa_ID { get; set; }
    }
}