namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class points : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Destino", "X", c => c.Int(nullable: false));
            AlterColumn("dbo.Destino", "Y", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Destino", "Y", c => c.Double(nullable: false));
            AlterColumn("dbo.Destino", "X", c => c.Double(nullable: false));
        }
    }
}
