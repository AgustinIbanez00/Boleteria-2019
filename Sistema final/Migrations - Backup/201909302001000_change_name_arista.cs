namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_name_arista : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Arco2", newName: "Arista");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Arista", newName: "Arco2");
        }
    }
}
