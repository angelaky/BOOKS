namespace BooksBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolesandadminareadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropTable("dbo.Comments");
        }
    }
}
