namespace Dashboard.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDashboardData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DashboardDatas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DashboardDatas", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.DashboardDatas", new[] { "Id" });
            DropTable("dbo.DashboardDatas");
        }
    }
}
