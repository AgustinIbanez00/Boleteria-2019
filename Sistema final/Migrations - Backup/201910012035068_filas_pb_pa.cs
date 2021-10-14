namespace Sistema_final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filas_pb_pa : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Celdas", newName: "Celda");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Celda", newName: "Celdas");
        }
    }
}
