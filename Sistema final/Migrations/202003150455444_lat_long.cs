namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lat_long : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "Latitud", c => c.Double(nullable: false));
            AddColumn("dbo.Destino", "Longitud", c => c.Double(nullable: false));
            DropColumn("dbo.Destino", "X");
            DropColumn("dbo.Destino", "Y");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Destino", "Y", c => c.Int(nullable: false));
            AddColumn("dbo.Destino", "X", c => c.Int(nullable: false));
            DropColumn("dbo.Destino", "Longitud");
            DropColumn("dbo.Destino", "Latitud");
        }
    }
}
