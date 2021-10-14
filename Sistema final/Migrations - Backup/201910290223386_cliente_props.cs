namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cliente_props : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Nacionalidad", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "Nacionalidad");
        }
    }
}
