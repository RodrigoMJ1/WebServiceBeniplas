namespace WebServiceBeniplas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegistroAperturaAdministradors", "FechaHora", c => c.String());
            AlterColumn("dbo.RegistroAperturaEmpleadoes", "FechaHora", c => c.String());
            AlterColumn("dbo.RegistroAperturaGerentes", "FechaHora", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegistroAperturaGerentes", "FechaHora", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RegistroAperturaEmpleadoes", "FechaHora", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RegistroAperturaAdministradors", "FechaHora", c => c.DateTime(nullable: false));
        }
    }
}
