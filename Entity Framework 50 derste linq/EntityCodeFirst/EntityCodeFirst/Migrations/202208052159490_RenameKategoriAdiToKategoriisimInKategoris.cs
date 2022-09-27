namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameKategoriAdiToKategoriisimInKategoris : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoris", "Kategoriisim", c => c.String());
            DropColumn("dbo.Kategoris", "KategoriAd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoris", "KategoriAd", c => c.String());
            DropColumn("dbo.Kategoris", "Kategoriisim");
        }
    }
}
