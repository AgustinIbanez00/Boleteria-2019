namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pasajeros : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cliente", newName: "Pasajero");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Pasajero", newName: "Cliente");
        }
    }
}
