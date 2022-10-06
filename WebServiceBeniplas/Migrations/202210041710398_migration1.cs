namespace WebServiceBeniplas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(),
                        Nombre = c.String(),
                        ApellidoP = c.String(),
                        ApellidoM = c.String(),
                        NumTel = c.Long(nullable: false),
                        Contrasena = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RegistroAperturaAdministradors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comentario = c.String(),
                        FechaHora = c.DateTime(nullable: false),
                        Administrador_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Administradors", t => t.Administrador_ID)
                .Index(t => t.Administrador_ID);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Codigo = c.Long(nullable: false),
                        NombreUsuario = c.String(),
                        Nombre = c.String(),
                        ApellidoP = c.String(),
                        ApellidoM = c.String(),
                        NumTel = c.Long(nullable: false),
                        Contrasena = c.String(),
                        Status = c.Boolean(nullable: false),
                        Sucursal_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sucursals", t => t.Sucursal_ID)
                .Index(t => t.Sucursal_ID);
            
            CreateTable(
                "dbo.RegistroAperturaEmpleadoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comentario = c.String(),
                        FechaHora = c.DateTime(nullable: false),
                        Empleado_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empleadoes", t => t.Empleado_ID)
                .Index(t => t.Empleado_ID);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Gerentes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(),
                        Nombre = c.String(),
                        ApellidoP = c.String(),
                        ApellidoM = c.String(),
                        Region = c.String(),
                        NumTel = c.Long(nullable: false),
                        Contrasena = c.String(),
                        Status = c.Boolean(nullable: false),
                        Empresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .Index(t => t.Empresa_ID);
            
            CreateTable(
                "dbo.RegistroAperturaGerentes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comentario = c.String(),
                        FechaHora = c.DateTime(nullable: false),
                        Gerente_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gerentes", t => t.Gerente_ID)
                .Index(t => t.Gerente_ID);
            
            CreateTable(
                "dbo.Sucursals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumSucursal = c.Int(nullable: false),
                        Direccion = c.String(),
                        Gerente_ID = c.Int(),
                        Empresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gerentes", t => t.Gerente_ID)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .Index(t => t.Gerente_ID)
                .Index(t => t.Empresa_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sucursals", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.Gerentes", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.Sucursals", "Gerente_ID", "dbo.Gerentes");
            DropForeignKey("dbo.Empleadoes", "Sucursal_ID", "dbo.Sucursals");
            DropForeignKey("dbo.RegistroAperturaGerentes", "Gerente_ID", "dbo.Gerentes");
            DropForeignKey("dbo.RegistroAperturaEmpleadoes", "Empleado_ID", "dbo.Empleadoes");
            DropForeignKey("dbo.RegistroAperturaAdministradors", "Administrador_ID", "dbo.Administradors");
            DropIndex("dbo.Sucursals", new[] { "Empresa_ID" });
            DropIndex("dbo.Sucursals", new[] { "Gerente_ID" });
            DropIndex("dbo.RegistroAperturaGerentes", new[] { "Gerente_ID" });
            DropIndex("dbo.Gerentes", new[] { "Empresa_ID" });
            DropIndex("dbo.RegistroAperturaEmpleadoes", new[] { "Empleado_ID" });
            DropIndex("dbo.Empleadoes", new[] { "Sucursal_ID" });
            DropIndex("dbo.RegistroAperturaAdministradors", new[] { "Administrador_ID" });
            DropTable("dbo.Sucursals");
            DropTable("dbo.RegistroAperturaGerentes");
            DropTable("dbo.Gerentes");
            DropTable("dbo.Empresas");
            DropTable("dbo.RegistroAperturaEmpleadoes");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.RegistroAperturaAdministradors");
            DropTable("dbo.Administradors");
        }
    }
}
