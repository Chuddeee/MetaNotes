namespace MetaNotes.Infrastructure.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsPublic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "IsPublic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "IsPublic");
        }
    }
}
