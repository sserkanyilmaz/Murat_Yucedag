namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KategoriisimToKategoriAdiInKategorisTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoris", "KategoriAdi", c => c.String());
            Sql("Update kategoris Set Kategoriisim=KategoriAdi");
            DropColumn("dbo.Kategoris", "Kategoriisim");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoris", "Kategoriisim", c => c.String());
            Sql("Update kategoris Set KategoriAdi=Kategoriisim");
            DropColumn("dbo.Kategoris", "KategoriAdi");
        }
    }
}
