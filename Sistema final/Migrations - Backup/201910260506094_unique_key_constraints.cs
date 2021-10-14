namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique_key_constraints : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Destino", "Nombre", unique: true);
            CreateIndex("dbo.Cliente", "DNI", unique: true);
            CreateIndex("dbo.Viaje", "Nombre", unique: true);
            CreateIndex("dbo.Distribucion", "Nota", unique: true);
            CreateIndex("dbo.Cuenta", "Usuario", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cuenta", new[] { "Usuario" });
            DropIndex("dbo.Distribucion", new[] { "Nota" });
            DropIndex("dbo.Viaje", new[] { "Nombre" });
            DropIndex("dbo.Cliente", new[] { "DNI" });
            DropIndex("dbo.Destino", new[] { "Nombre" });
        }
    }
}
