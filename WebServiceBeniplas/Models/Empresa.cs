using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beniplas.Model
{
    public class Empresa
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public virtual List<Sucursal> Sucursales { get; set; }
        public virtual List<Gerente> Gerentes { get; set; }
    }
    public class EmpresaDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
}
