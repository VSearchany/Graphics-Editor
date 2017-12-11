namespace Realt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Advertisements", new[] { "User_Id" });
            DropColumn("dbo.Advertisements", "UserId");
            RenameColumn(table: "dbo.Advertisements", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Advertisements", "Date", c => c.String());
            AlterColumn("dbo.Advertisements", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Advertisements", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Advertisements", new[] { "UserId" });
            AlterColumn("dbo.Advertisements", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Advertisements", "Date");
            RenameColumn(table: "dbo.Advertisements", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Advertisements", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Advertisements", "User_Id");
        }
    }
}
