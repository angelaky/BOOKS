namespace BooksBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagsareadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagsPosts",
                c => new
                    {
                        Tags_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tags_Id, t.Post_Id })
                .ForeignKey("dbo.Tags", t => t.Tags_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tags_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagsPosts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.TagsPosts", "Tags_Id", "dbo.Tags");
            DropIndex("dbo.TagsPosts", new[] { "Post_Id" });
            DropIndex("dbo.TagsPosts", new[] { "Tags_Id" });
            DropTable("dbo.TagsPosts");
            DropTable("dbo.Tags");
        }
    }
}
