namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arco2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Demora = c.String(),
                        Precio = c.Double(nullable: false),
                        Destino_Id = c.Int(),
                        Vertice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destino", t => t.Destino_Id)
                .ForeignKey("dbo.Vertice", t => t.Vertice_Id)
                .Index(t => t.Destino_Id)
                .Index(t => t.Vertice_Id);
            
            CreateTable(
                "dbo.Destino",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Boleto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                        Pago_Id = c.Int(),
                        Pasajero_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pago", t => t.Pago_Id)
                .ForeignKey("dbo.Cliente", t => t.Pasajero_ID)
                .Index(t => t.Pago_Id)
                .Index(t => t.Pasajero_ID);
            
            CreateTable(
                "dbo.Pago",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Boleto = c.Int(nullable: false),
                        Tipo = c.String(),
                        Titular = c.String(),
                        DNI = c.Long(nullable: false),
                        Correo = c.String(),
                        Tarjeta = c.String(),
                        NROTarjeta = c.Long(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        Precio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        FechaNac = c.String(),
                        DNI = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cuenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Contraseña = c.String(),
                        Correo = c.String(),
                        Fechanac = c.String(),
                        Fechareg = c.String(),
                        Sexo = c.String(),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Distribucion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnPiso = c.Boolean(nullable: false),
                        Nota = c.String(),
                        FilasPB = c.Int(nullable: false),
                        FilasPA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grafo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Directorio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vertice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Destino_Id = c.Int(),
                        Grafo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destino", t => t.Destino_Id)
                .ForeignKey("dbo.Grafo", t => t.Grafo_Id)
                .Index(t => t.Destino_Id)
                .Index(t => t.Grafo_Id);
            
            CreateTable(
                "dbo.Horario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hora = c.String(),
                        Distribucion_Id = c.Int(),
                        Viaje_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Distribucion", t => t.Distribucion_Id)
                .ForeignKey("dbo.Viaje", t => t.Viaje_Id)
                .Index(t => t.Distribucion_Id)
                .Index(t => t.Viaje_Id);
            
            CreateTable(
                "dbo.Viaje",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Destino_Id = c.Int(),
                        Grafo_Id = c.Int(),
                        Origen_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destino", t => t.Destino_Id)
                .ForeignKey("dbo.Grafo", t => t.Grafo_Id)
                .ForeignKey("dbo.Destino", t => t.Origen_Id)
                .Index(t => t.Destino_Id)
                .Index(t => t.Grafo_Id)
                .Index(t => t.Origen_Id);
            
        }
        
        public override void Down()
        {            
            DropForeignKey("dbo.Viaje", "Origen_Id", "dbo.Destino");
            DropForeignKey("dbo.Horario", "Viaje_Id", "dbo.Viaje");
            DropForeignKey("dbo.Viaje", "Grafo_Id", "dbo.Grafo");
            DropForeignKey("dbo.Viaje", "Destino_Id", "dbo.Destino");
            DropForeignKey("dbo.Horario", "Distribucion_Id", "dbo.Distribucion");
            DropForeignKey("dbo.Vertice", "Grafo_Id", "dbo.Grafo");
            DropForeignKey("dbo.Arco", "Vertice_Id", "dbo.Vertice");
            DropForeignKey("dbo.Vertice", "Destino_Id", "dbo.Destino");
            DropForeignKey("dbo.Boleto", "Pasajero_ID", "dbo.Cliente");
            DropForeignKey("dbo.Boleto", "Pago_Id", "dbo.Pago");
            DropForeignKey("dbo.Arco", "Destino_Id", "dbo.Destino");
            DropIndex("dbo.Viaje", new[] { "Origen_Id" });
            DropIndex("dbo.Viaje", new[] { "Grafo_Id" });
            DropIndex("dbo.Viaje", new[] { "Destino_Id" });
            DropIndex("dbo.Horario", new[] { "Viaje_Id" });
            DropIndex("dbo.Horario", new[] { "Distribucion_Id" });
            DropIndex("dbo.Vertice", new[] { "Grafo_Id" });
            DropIndex("dbo.Vertice", new[] { "Destino_Id" });
            DropIndex("dbo.Boleto", new[] { "Pasajero_ID" });
            DropIndex("dbo.Boleto", new[] { "Pago_Id" });
            DropIndex("dbo.Arco", new[] { "Vertice_Id" });
            DropIndex("dbo.Arco", new[] { "Destino_Id" });
            DropTable("dbo.Viaje");
            DropTable("dbo.Horario");
            DropTable("dbo.Vertice");
            DropTable("dbo.Grafo");
            DropTable("dbo.Distribucion");
            DropTable("dbo.Cuenta");
            DropTable("dbo.Cliente");
            DropTable("dbo.Pago");
            DropTable("dbo.Boleto");
            DropTable("dbo.Destino");
            DropTable("dbo.Arco");            
        }
    }
}
