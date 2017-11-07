namespace exp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fname = c.String(nullable: false),
                        mname = c.String(nullable: false),
                        lname = c.String(nullable: false),
                        email_id = c.String(nullable: false),
                        cemail = c.String(),
                        pwd = c.String(nullable: false, maxLength: 15),
                        cpwd = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registers");
        }
    }
}
