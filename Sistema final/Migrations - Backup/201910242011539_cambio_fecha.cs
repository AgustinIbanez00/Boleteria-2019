namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio_fecha : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boleto", "Fecha", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boleto", "Fecha", c => c.String());
        }
    }
}
