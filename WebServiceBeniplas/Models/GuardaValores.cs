using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceBeniplas.Models
{
    public class GuardaValores
    {
        public bool PuertaDerecha { get; set; }
        public bool Caja1D { get; set; }
        public bool Caja2D { get; set; }
        public bool Caja3D { get; set; }
        public bool Caja4D { get; set; }
        public bool PuertaIzquierda { get; set; }
        public bool Caja1I { get; set; }
        public bool Caja2I { get; set; }
        public bool Caja3I { get; set; }
        public bool Caja4I { get; set; }
        public int NumSucursal { get; set; }
        public string Empresa { get; set; }
    }
    public class GuardaValoresDTO
    {
        public bool PuertaDerecha { get; set; }
        public bool Caja1D { get; set; }
        public bool Caja2D { get; set; }
        public bool Caja3D { get; set; }
        public bool Caja4D { get; set; }
        public bool PuertaIzquierda { get; set; }
        public bool Caja1I { get; set; }
        public bool Caja2I { get; set; }
        public bool Caja3I { get; set; }
        public bool Caja4I { get; set; }
    }
    public class GuardaValoresSucursal
    {
        public bool PuertaDerecha { get; set; }
        public bool PuertaIzquierda { get; set; }
        public int NumSucursal { get; set; }
        public string Empresa {get; set; }
    }
}