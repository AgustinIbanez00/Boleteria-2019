namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdas1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pasajero", newName: "Cliente");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Cliente", newName: "Pasajero");
        }
    }
}
