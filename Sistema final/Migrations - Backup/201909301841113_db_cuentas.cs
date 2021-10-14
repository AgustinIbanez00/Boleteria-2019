namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_cuentas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Destino", "Boton");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Destino", "Boton", c => c.String());
        }
    }
}
