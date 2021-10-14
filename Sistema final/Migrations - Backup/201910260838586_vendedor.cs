namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boleto", "Vendedor_Id", c => c.Int());
            CreateIndex("dbo.Boleto", "Vendedor_Id");
            AddForeignKey("dbo.Boleto", "Vendedor_Id", "dbo.Cuenta", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boleto", "Vendedor_Id", "dbo.Cuenta");
            DropIndex("dbo.Boleto", new[] { "Vendedor_Id" });
            DropColumn("dbo.Boleto", "Vendedor_Id");
        }
    }
}
