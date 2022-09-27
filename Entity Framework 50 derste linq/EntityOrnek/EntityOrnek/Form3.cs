using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityOrnek
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        DbSinavOgrenciEntities db = new DbSinavOgrenciEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                var degerler = db.TBLNOTLAR.Where(p => p.SINAV1 < 50);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton2.Checked == true)
            {
                var degerler = db.TBLOGRENCI.Where(p => p.AD == "Ali");
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton3.Checked == true)
            {
                var degerler = db.TBLOGRENCI.Where(p => p.AD == textBox1.Text);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton4.Checked == true)
            {
                var degerler = db.TBLOGRENCI.Select(x => new { Soyad = x.SOYAD });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton5.Checked == true)
            {
                var degerler = db.TBLOGRENCI.Select(x => new { Ad = x.AD.ToUpper(), Soyad = x.SOYAD.ToLower() });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton6.Checked == true)
            {
                var degerler = db.TBLOGRENCI.Select(x => new
                {   Ad = x.AD.ToUpper(),
                    Soyad = x.SOYAD.ToLower()
                }).Where(x => x.Ad != "Ali");
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton7.Checked == true)
            {
                var degerler = db.TBLNOTLAR.Select(x => new
                {
                    ogrenciAd = x.OGR,
                    ortalama = x.ORTALAMA,
                    durum = x.DURUM == true ? "Geçti" : "Kaldı"
                });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton8.Checked == true)
            {
                var degerler = db.TBLNOTLAR.SelectMany(x => db.TBLOGRENCI.Where(y => y.ID == x.OGR), (x, y) => new
                {
                    y.AD,
                    x.ORTALAMA,
                    Durum = x.ORTALAMA >= 50 ? "Geçti " : "Kaldı"
                });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton9.Checked == true)
            {
                var degerler = db.TBLOGRENCI.OrderBy(x => x.ID).Take(3);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton10.Checked == true)
            {
                var degerler = db.TBLOGRENCI.OrderByDescending(x => x.ID).Take(3);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton11.Checked == true)
            {
                var degerler = db.TBLOGRENCI.OrderBy(x => x.AD);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton12.Checked == true)
            {
                var degerler = db.TBLOGRENCI.OrderBy(x => x.AD).Skip(5);
                dataGridView1.DataSource = degerler.ToList();
            }

        }
    }
}
