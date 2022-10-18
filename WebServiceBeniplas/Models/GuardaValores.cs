using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceBeniplas.Models
{
    public class GuardaValores
    {
        public bool CajaIzquierda { get; set; }
        public bool CajaDerecha { get; set; }
    }

    public class Cajas
    {
        public bool Caja1 { get; set; }
        public bool Caja2 { get; set; }
        public bool Caja3 { get; set; }
        public bool Caja4 { get; set; }
    }
}