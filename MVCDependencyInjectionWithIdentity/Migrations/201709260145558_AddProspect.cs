namespace MVCDependencyInjectionWithIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProspect : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prospects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prospects");
        }
    }
}
