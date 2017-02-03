namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToOffers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "OfferedByUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "OfferedByUserId");
        }
    }
}
