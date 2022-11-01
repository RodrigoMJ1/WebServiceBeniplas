﻿using System;
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
        public string Año { get; set; }
        public string Mes { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
    }
    public class RegistroAperturaAdministradorDTO
    {
        public int ID { get; set; }
        public string Comentario { get; set; }
        public string Año { get; set; }
        public string Mes { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
        public int Administrador_ID { get; set; }
        public int Sucursal_ID { get; set; }
        public int Empresa_ID { get; set; }
    }

}
