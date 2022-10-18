using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beniplas.Model
{
    public class Sucursal
    {
        public int ID { get; set; }
        public int NumSucursal { get; set; }
        public string Direccion { get; set; }
        public virtual List<Empleado> Empleados { get; set; }
    }

    public class Sucursals
    {
        public int ID { set; get; }
        public int NumSucursal { set; get; }
        public string Direccion { set; get; }
        public int Gerente_ID { set; get; }
        public int Empresa_ID { set; get; }
        public string Empresa { set; get; }
    }

}
