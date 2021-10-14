namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cliente_create : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "FechaNac", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Cuenta", "Fechanac", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cuenta", "Fechanac", c => c.String());
            AlterColumn("dbo.Cliente", "FechaNac", c => c.String());
        }
    }
}
