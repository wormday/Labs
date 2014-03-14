namespace Hrm.BLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeEntities",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IDCard = c.String(),
                        Remark = c.String(),
                        JobNumber = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        LeaveDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeEntities");
        }
    }
}
