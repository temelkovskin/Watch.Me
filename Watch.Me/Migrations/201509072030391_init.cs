namespace Watch.Me.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        UserPictures_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserPictures", t => t.UserPictures_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.UserPictures_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserPictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VideoTitle = c.String(),
                        Url = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        ApprovedBy = c.String(),
                        ApprovedOn = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmotionsAboutVideos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Love = c.Boolean(nullable: false),
                        Dislike = c.Boolean(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Video_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Videos", t => t.Video_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Video_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.TagLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Searched = c.Boolean(nullable: false),
                        SearchDate = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Tag_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Tags", t => t.Tag_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Tag_Id);
            
            CreateTable(
                "dbo.VideoComments",
                c => new
                    {
                        Video_Id = c.Int(nullable: false),
                        Comment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_Id, t.Comment_Id })
                .ForeignKey("dbo.Videos", t => t.Video_Id, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.Comment_Id, cascadeDelete: true)
                .Index(t => t.Video_Id)
                .Index(t => t.Comment_Id);
            
            CreateTable(
                "dbo.TagVideos",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Video_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Video_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.Video_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Video_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagLogs", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagLogs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EmotionsAboutVideos", "Video_Id", "dbo.Videos");
            DropForeignKey("dbo.EmotionsAboutVideos", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TagVideos", "Video_Id", "dbo.Videos");
            DropForeignKey("dbo.TagVideos", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.VideoComments", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.VideoComments", "Video_Id", "dbo.Videos");
            DropForeignKey("dbo.Videos", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "UserPictures_Id", "dbo.UserPictures");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TagVideos", new[] { "Video_Id" });
            DropIndex("dbo.TagVideos", new[] { "Tag_Id" });
            DropIndex("dbo.VideoComments", new[] { "Comment_Id" });
            DropIndex("dbo.VideoComments", new[] { "Video_Id" });
            DropIndex("dbo.TagLogs", new[] { "Tag_Id" });
            DropIndex("dbo.TagLogs", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.EmotionsAboutVideos", new[] { "Video_Id" });
            DropIndex("dbo.EmotionsAboutVideos", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Videos", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserPictures_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropTable("dbo.TagVideos");
            DropTable("dbo.VideoComments");
            DropTable("dbo.TagLogs");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.EmotionsAboutVideos");
            DropTable("dbo.Tags");
            DropTable("dbo.Videos");
            DropTable("dbo.UserPictures");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
        }
    }
}
