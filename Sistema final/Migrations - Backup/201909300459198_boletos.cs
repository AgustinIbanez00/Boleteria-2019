namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boletos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boleto", "Asiento", c => c.Int(nullable: false));
            AddColumn("dbo.Boleto", "FechaEmision", c => c.String());
            AddColumn("dbo.Boleto", "Fecha", c => c.String());
            AddColumn("dbo.Boleto", "Precio", c => c.String());
            AddColumn("dbo.Boleto", "HoraSalida", c => c.String());
            AddColumn("dbo.Boleto", "HoraSalidaAdicional", c => c.String());
            AddColumn("dbo.Boleto", "HoraLlegada", c => c.String());
            AddColumn("dbo.Boleto", "Destino_Id", c => c.Int());
            AddColumn("dbo.Boleto", "Origen_Id", c => c.Int());
            AddColumn("dbo.Boleto", "Recorrido_Id", c => c.Int());
            CreateIndex("dbo.Boleto", "Destino_Id");
            CreateIndex("dbo.Boleto", "Origen_Id");
            CreateIndex("dbo.Boleto", "Recorrido_Id");
            AddForeignKey("dbo.Boleto", "Destino_Id", "dbo.Destino", "Id");
            AddForeignKey("dbo.Boleto", "Origen_Id", "dbo.Destino", "Id");
            AddForeignKey("dbo.Boleto", "Recorrido_Id", "dbo.Viaje", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boleto", "Recorrido_Id", "dbo.Viaje");
            DropForeignKey("dbo.Boleto", "Origen_Id", "dbo.Destino");
            DropForeignKey("dbo.Boleto", "Destino_Id", "dbo.Destino");
            DropIndex("dbo.Boleto", new[] { "Recorrido_Id" });
            DropIndex("dbo.Boleto", new[] { "Origen_Id" });
            DropIndex("dbo.Boleto", new[] { "Destino_Id" });
            DropColumn("dbo.Boleto", "Recorrido_Id");
            DropColumn("dbo.Boleto", "Origen_Id");
            DropColumn("dbo.Boleto", "Destino_Id");
            DropColumn("dbo.Boleto", "HoraLlegada");
            DropColumn("dbo.Boleto", "HoraSalidaAdicional");
            DropColumn("dbo.Boleto", "HoraSalida");
            DropColumn("dbo.Boleto", "Precio");
            DropColumn("dbo.Boleto", "Fecha");
            DropColumn("dbo.Boleto", "FechaEmision");
            DropColumn("dbo.Boleto", "Asiento");
        }
    }
}
