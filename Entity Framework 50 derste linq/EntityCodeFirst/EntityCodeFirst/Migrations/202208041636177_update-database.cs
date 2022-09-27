namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urunlers", "Kategori_KategoriID", c => c.Int());
            CreateIndex("dbo.Urunlers", "Kategori_KategoriID");
            AddForeignKey("dbo.Urunlers", "Kategori_KategoriID", "dbo.Kategoris", "KategoriID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Urunlers", "Kategori_KategoriID", "dbo.Kategoris");
            DropIndex("dbo.Urunlers", new[] { "Kategori_KategoriID" });
            DropColumn("dbo.Urunlers", "Kategori_KategoriID");
        }
    }
}
