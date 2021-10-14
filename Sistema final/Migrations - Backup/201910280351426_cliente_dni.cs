namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cliente_dni : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "DNI", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "DNI");
        }
    }
}
