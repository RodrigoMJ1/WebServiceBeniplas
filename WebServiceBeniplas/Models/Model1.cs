using beniplas.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebServiceBeniplas.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Administrador> Administradores { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Gerente> Gerentes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Sucursal> Sucursales { get; set; }
        public virtual DbSet<RegistroAperturaAdministrador> RegistroAperturaAdministradores { get; set; }
        public virtual DbSet<RegistroAperturaEmpleado> RegistroAperturaEmpleados { get; set; }
        public virtual DbSet<RegistroAperturaGerente> RegistroAperturaGerentes { get; set; }
    }
}
