namespace Learn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserInfo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.String(),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
