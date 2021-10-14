namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arcos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "Boton", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destino", "Boton");
        }
    }
}
