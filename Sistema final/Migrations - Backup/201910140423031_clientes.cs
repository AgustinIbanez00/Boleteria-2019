namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boleto", "Pasajero_ID", "dbo.Cliente");
            DropIndex("dbo.Boleto", new[] { "Pasajero_ID" });
            DropPrimaryKey("dbo.Cliente");
            AlterColumn("dbo.Boleto", "Pasajero_Id", c => c.Int());
            AlterColumn("dbo.Cliente", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cliente", "DNI", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Cliente", "Id");
            CreateIndex("dbo.Boleto", "Pasajero_Id");
            AddForeignKey("dbo.Boleto", "Pasajero_Id", "dbo.Cliente", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boleto", "Pasajero_Id", "dbo.Cliente");
            DropIndex("dbo.Boleto", new[] { "Pasajero_Id" });
            DropPrimaryKey("dbo.Cliente");
            AlterColumn("dbo.Cliente", "DNI", c => c.String());
            AlterColumn("dbo.Cliente", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Boleto", "Pasajero_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Cliente", "ID");
            CreateIndex("dbo.Boleto", "Pasajero_ID");
            AddForeignKey("dbo.Boleto", "Pasajero_ID", "dbo.Cliente", "ID");
        }
    }
}
