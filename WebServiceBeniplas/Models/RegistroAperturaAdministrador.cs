using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beniplas.Model
{
    public class RegistroAperturaAdministrador
    {
        public int ID { get; set; }
        public string Comentario { get; set; }
        public string FechaHora { get; set; }
    }
    public class RegistroAperturaAdministradorDTO
    {
        public int ID { get; set; }
        public string Comentario { get; set; }
        public string FechaHora { get; set; }
        public int Administrador_ID { get; set; }
    }

}
