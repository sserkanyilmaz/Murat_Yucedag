namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropMusteriSehirInMusterisTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Musteris", "MusteriSehir");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musteris", "MusteriSehir", c => c.String());
        }
    }
}
