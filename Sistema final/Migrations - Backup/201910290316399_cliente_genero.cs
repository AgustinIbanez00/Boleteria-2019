namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cliente_genero : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Genero", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "Genero");
        }
    }
}
