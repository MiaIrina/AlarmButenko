namespace AlarmEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAlarm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alarms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OwnerGuid = c.Guid(nullable: false),
                        Hour = c.Int(nullable: false),
                        Minutes = c.Int(nullable: false),
                        AlarmUser_Guid = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerGuid, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.AlarmUser_Guid)
                .Index(t => t.OwnerGuid)
                .Index(t => t.AlarmUser_Guid);
            
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
                        DateOfLastLogin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alarms", "AlarmUser_Guid", "dbo.Users");
            DropForeignKey("dbo.Alarms", "OwnerGuid", "dbo.Users");
            DropIndex("dbo.Alarms", new[] { "AlarmUser_Guid" });
            DropIndex("dbo.Alarms", new[] { "OwnerGuid" });
            DropTable("dbo.Users");
            DropTable("dbo.Alarms");
        }
    }
}
