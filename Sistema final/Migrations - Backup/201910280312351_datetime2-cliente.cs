namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime2cliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "FechaReg", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Cuenta", "Fechareg", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cuenta", "Fechareg", c => c.String());
            DropColumn("dbo.Cliente", "FechaReg");
        }
    }
}
