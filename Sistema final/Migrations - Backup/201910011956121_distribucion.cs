namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class distribucion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Celdas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Columna_id = c.Int(nullable: false),
                        Fila_id = c.Int(nullable: false),
                        Cell_value = c.Int(nullable: false),
                        Distribucion_Id = c.Int(),
                        Distribucion_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Distribucion", t => t.Distribucion_Id)
                .ForeignKey("dbo.Distribucion", t => t.Distribucion_Id1)
                .Index(t => t.Distribucion_Id)
                .Index(t => t.Distribucion_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Celdas", "Distribucion_Id1", "dbo.Distribucion");
            DropForeignKey("dbo.Celdas", "Distribucion_Id", "dbo.Distribucion");
            DropIndex("dbo.Celdas", new[] { "Distribucion_Id1" });
            DropIndex("dbo.Celdas", new[] { "Distribucion_Id" });
            DropTable("dbo.Celdas");
        }
    }
}
