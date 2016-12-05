namespace BooksBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryauthoradded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Author_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Categories", "Author_Id");
            AddForeignKey("dbo.Categories", "Author_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "Author_Id" });
            DropColumn("dbo.Categories", "Author_Id");
        }
    }
}
