namespace AlarmEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlarmData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alarms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        BeginTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Hour = c.Int(nullable: false),
                        Minutes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserGuid, cascadeDelete: true)
                .Index(t => t.UserGuid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alarms", "UserGuid", "dbo.Users");
            DropIndex("dbo.Alarms", new[] { "UserGuid" });
            DropTable("dbo.Users");
            DropTable("dbo.Alarms");
        }
    }
}
