namespace AnimalParadise.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Nerd", newName: "Comic");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Comic", newName: "Nerd");
        }
    }
}
