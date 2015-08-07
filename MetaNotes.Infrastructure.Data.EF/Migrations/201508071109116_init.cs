namespace MetaNotes.Infrastructure.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_id = c.Guid(nullable: false),
                        Changed_by = c.Guid(),
                        Create_time = c.DateTime(nullable: false),
                        Change_time = c.DateTime(),
                        Delete_time = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Title = c.String(maxLength: 100),
                        Body = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Changed_by)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.User_id)
                .Index(t => t.Changed_by);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(maxLength: 20),
                        Password = c.String(maxLength: 4000),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "User_id", "dbo.Users");
            DropForeignKey("dbo.Notes", "Changed_by", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "Changed_by" });
            DropIndex("dbo.Notes", new[] { "User_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Notes");
        }
    }
}
