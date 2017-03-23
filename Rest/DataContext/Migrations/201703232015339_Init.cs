namespace Rest.DataContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserId)
                .Index(t => t.FriendId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(maxLength: 20),
                        Password = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.PhoneNumber);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "PhoneNumber" });
            DropIndex("dbo.UserRelations", new[] { "FriendId" });
            DropIndex("dbo.UserRelations", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRelations");
        }
    }
}
