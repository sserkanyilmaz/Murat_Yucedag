using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntitySonKısım
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbSinavOgrenciEntities db = new DbSinavOgrenciEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //ORDER BY KULLANIMI
            //var degerler = db.TBLOGRENCIs.OrderBy(x => x.SEHIR).GroupBy(y=>y.SEHIR).Select(z=>new
            //{
            //    sehır=z.Key,
            //    toplam=z.Count()
            //}).OrderByDescending(s=>s.toplam);
            // MİN BULMA var degerler = db.TBLNOTLARs.Max(x => x.ORTALAMA);
            // ODEV var degerler = db.TBLNOTLARs.Where(x=>x.DURUM==false).Max(y=>y.ORTALAMA);
            // aggregate fonksiyonlar var degerler = db.TBLURUNLERs.Sum(x=>x.STOK);
            label1.Text = (from x in db.TBLURUNLERs
                           orderby x.STOK
                           select x.AD).First();
            dataGridView1.DataSource = db.kuluplerleGetir();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
