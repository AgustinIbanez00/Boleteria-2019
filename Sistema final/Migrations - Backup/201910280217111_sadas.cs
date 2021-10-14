namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sadas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pago", "Nro_tarjeta", c => c.Long(nullable: false));
            AddColumn("dbo.Pago", "Fecha_vencimiento", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Pago", "NROTarjeta");
            DropColumn("dbo.Pago", "FechaVencimiento");
            DropColumn("dbo.Cliente", "DNI");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cliente", "DNI", c => c.Long(nullable: false));
            AddColumn("dbo.Pago", "FechaVencimiento", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Pago", "NROTarjeta", c => c.Long(nullable: false));
            DropIndex("dbo.Boleto", new[] { "Pasajero_ID" });
            DropColumn("dbo.Pago", "Fecha_vencimiento");
            DropColumn("dbo.Pago", "Nro_tarjeta");
        }
    }
}
