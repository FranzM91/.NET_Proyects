namespace manilab.test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 36),
                        name = c.String(nullable: false, maxLength: 100),
                        password = c.String(nullable: false, maxLength: 50),
                        cel = c.String(nullable: false, maxLength: 15),
                        email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "email" });
            DropTable("dbo.Users");
        }
    }
}
