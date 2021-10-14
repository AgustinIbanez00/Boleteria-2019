namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viajes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Viaje", "Destino_Id", "dbo.Destino");
            DropForeignKey("dbo.Vertice", "Destino_Id", "dbo.Destino");
            DropForeignKey("dbo.Arista", "Vertice_Id", "dbo.Vertice");
            DropForeignKey("dbo.Vertice", "Grafo_Id", "dbo.Grafo");
            DropForeignKey("dbo.Viaje", "Grafo_Id", "dbo.Grafo");
            DropForeignKey("dbo.Viaje", "Origen_Id", "dbo.Destino");
            DropIndex("dbo.Arista", new[] { "Vertice_Id" });
            DropIndex("dbo.Viaje", new[] { "Destino_Id" });
            DropIndex("dbo.Viaje", new[] { "Grafo_Id" });
            DropIndex("dbo.Viaje", new[] { "Origen_Id" });
            DropIndex("dbo.Vertice", new[] { "Destino_Id" });
            DropIndex("dbo.Vertice", new[] { "Grafo_Id" });
            AddColumn("dbo.Arista", "Origen_Id", c => c.Int());
            AddColumn("dbo.Arista", "Viaje_Id", c => c.Int());
            AddColumn("dbo.Horario", "Frecuencia_Id", c => c.Int());
            CreateIndex("dbo.Arista", "Origen_Id");
            CreateIndex("dbo.Arista", "Viaje_Id");
            CreateIndex("dbo.Horario", "Frecuencia_Id");
            AddForeignKey("dbo.Arista", "Origen_Id", "dbo.Destino", "Id");
            AddForeignKey("dbo.Arista", "Viaje_Id", "dbo.Viaje", "Id");
            AddForeignKey("dbo.Horario", "Frecuencia_Id", "dbo.Fila", "Id");
            DropColumn("dbo.Arista", "Vertice_Id");
            DropColumn("dbo.Viaje", "Destino_Id");
            DropColumn("dbo.Viaje", "Grafo_Id");
            DropColumn("dbo.Viaje", "Origen_Id");
            DropTable("dbo.Grafo");
            DropTable("dbo.Vertice");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Vertice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Destino_Id = c.Int(),
                        Grafo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grafo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Viaje", "Origen_Id", c => c.Int());
            AddColumn("dbo.Viaje", "Grafo_Id", c => c.Int());
            AddColumn("dbo.Viaje", "Destino_Id", c => c.Int());
            AddColumn("dbo.Arista", "Vertice_Id", c => c.Int());
            DropForeignKey("dbo.Horario", "Frecuencia_Id", "dbo.Fila");
            DropForeignKey("dbo.Arista", "Viaje_Id", "dbo.Viaje");
            DropForeignKey("dbo.Arista", "Origen_Id", "dbo.Destino");
            DropIndex("dbo.Horario", new[] { "Frecuencia_Id" });
            DropIndex("dbo.Arista", new[] { "Viaje_Id" });
            DropIndex("dbo.Arista", new[] { "Origen_Id" });
            DropColumn("dbo.Horario", "Frecuencia_Id");
            DropColumn("dbo.Arista", "Viaje_Id");
            DropColumn("dbo.Arista", "Origen_Id");
            CreateIndex("dbo.Vertice", "Grafo_Id");
            CreateIndex("dbo.Vertice", "Destino_Id");
            CreateIndex("dbo.Viaje", "Origen_Id");
            CreateIndex("dbo.Viaje", "Grafo_Id");
            CreateIndex("dbo.Viaje", "Destino_Id");
            CreateIndex("dbo.Arista", "Vertice_Id");
            AddForeignKey("dbo.Viaje", "Origen_Id", "dbo.Destino", "Id");
            AddForeignKey("dbo.Viaje", "Grafo_Id", "dbo.Grafo", "Id");
            AddForeignKey("dbo.Vertice", "Grafo_Id", "dbo.Grafo", "Id");
            AddForeignKey("dbo.Arista", "Vertice_Id", "dbo.Vertice", "Id");
            AddForeignKey("dbo.Vertice", "Destino_Id", "dbo.Destino", "Id");
            AddForeignKey("dbo.Viaje", "Destino_Id", "dbo.Destino", "Id");
        }
    }
}
