namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reInital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        UrlSlug = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 1024),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        ShortDescription = c.String(maxLength: 1024),
                        PostContent = c.String(),
                        UrlSlug = c.String(nullable: false, maxLength: 255),
                        Published = c.Boolean(nullable: false),
                        PostedOn = c.DateTime(),
                        Modified = c.Boolean(nullable: false),
                        CategoryId = c.Int(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        UrlSlug = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Count = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostTag",
                c => new
                    {
                        PostRefId = c.Int(nullable: false),
                        TagRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostRefId, t.TagRefId })
                .ForeignKey("dbo.Posts", t => t.PostRefId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagRefId, cascadeDelete: true)
                .Index(t => t.PostRefId)
                .Index(t => t.TagRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTag", "TagRefId", "dbo.Tags");
            DropForeignKey("dbo.PostTag", "PostRefId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.PostTag", new[] { "TagRefId" });
            DropIndex("dbo.PostTag", new[] { "PostRefId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropTable("dbo.PostTag");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
