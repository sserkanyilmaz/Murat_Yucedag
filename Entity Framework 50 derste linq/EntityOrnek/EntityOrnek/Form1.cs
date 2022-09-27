using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EntityOrnek
{
    public partial class Form1 : Form
    {

        DbSinavOgrenciEntities db = new DbSinavOgrenciEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDersListele_Click(object sender, EventArgs e)
        {
            SqlConnection bgl = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbSinavOgrenci;Integrated Security=True");
            SqlCommand komut = new SqlCommand("select * from tbldersler", bgl);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonOgrenciListele_Click(object sender, EventArgs e)
        {
            DbSinavOgrenciEntities db = new DbSinavOgrenciEntities();
            dataGridView1.DataSource = db.TBLOGRENCI.ToList();
        }

        private void buttonNotListele_Click(object sender, EventArgs e)
        {
            var query = from item in db.TBLNOTLAR
                        select new { item.NOTID, item.OGR, item.SINAV1, item.SINAV2, item.SINAV3, item.ORTALAMA, item.DURUM };
            dataGridView1.DataSource = query.ToList();
            //dataGridView1.DataSource = db.TBLNOTLAR.ToList();
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            TBLOGRENCI t = new TBLOGRENCI();
            t.AD = txtOgrenciAd.Text;
            t.SOYAD = txtOgrenciSoyad.Text;
            db.TBLOGRENCI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci listeye eklenmiştir.");
        }

        private void buttonDersEkle_Click(object sender, EventArgs e)
        {
            TBLDERSLER d = new TBLDERSLER();
            d.DERSAD = txtDersAd.Text;
            db.TBLDERSLER.Add(d);
            db.SaveChanges();
            MessageBox.Show("Ders listeye eklenmiştir.");
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOgrenciId.Text);
            var x = db.TBLOGRENCI.Find(id);
            db.TBLOGRENCI.Remove(x);
            db.SaveChanges();

            MessageBox.Show("Ögrenci listeden silinmiştir.");

        }

        private void buttonGüncele_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOgrenciId.Text);
            var x = db.TBLOGRENCI.Find(id);
            x.AD = txtOgrenciAd.Text;
            x.SOYAD = txtOgrenciSoyad.Text;
            x.FOTOGRAF = txtOgrenciFoto.Text;
            db.SaveChanges();
            MessageBox.Show("Ögrenci güncellendi.");
        }

        private void buttonprosedur_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.NOTLISTESI().ToList();
        }

        private void buttonBul_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=db.TBLOGRENCI.Where(x=>x.AD==txtOgrenciAd.Text&&x.SOYAD==txtOgrenciSoyad.Text ).ToList();
        }

        private void txtOgrenciAd_TextChanged(object sender, EventArgs e)
        {   
            string aranan = txtOgrenciAd.Text;
            var degerler = from item in db.TBLOGRENCI where item.AD.Contains(aranan) select item;
            
            dataGridView1.DataSource = degerler.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked== true)
            {
                //asc
                List<TBLOGRENCI> liste1 = db.TBLOGRENCI.OrderBy(t => t.AD).ToList();
                dataGridView1.DataSource = liste1;
            }
            if (radioButton2.Checked == true)
            {
                //desc
                List<TBLOGRENCI> liste2 = db.TBLOGRENCI.OrderByDescending(t => t.AD).ToList();
                dataGridView1.DataSource = liste2;
            }
            if (radioButton3.Checked == true)
            {
                //desc
                List<TBLOGRENCI> liste3 = db.TBLOGRENCI.OrderByDescending(t => t.AD).Take(3).ToList();
                dataGridView1.DataSource = liste3;
            }
            if(radioButton4.Checked == true)
            {
                List<TBLOGRENCI> liste4 = db.TBLOGRENCI.Where(x => x.ID ==5).ToList();
                dataGridView1.DataSource = liste4;
            }
            if(radioButton5.Checked == true)
            {
                List<TBLOGRENCI> liste5 = db.TBLOGRENCI.Where(p => p.AD.StartsWith("a")).ToList();
                dataGridView1.DataSource = liste5;
            }
            if (radioButton6.Checked == true)
            {
                List<TBLOGRENCI> liste6 = db.TBLOGRENCI.Where(p => p.AD.EndsWith("a")).ToList();
                dataGridView1.DataSource = liste6;
            }
            if (radioButton7.Checked == true)
            {
                bool deger = db.TBLOGRENCI.Any();
                MessageBox.Show(deger.ToString() , "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            if (radioButton8.Checked == true)
            {
                int sayi = db.TBLOGRENCI.Count();
                MessageBox.Show(sayi.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton9.Checked == true)
            {
                var toplam = db.TBLNOTLAR.Sum(p => p.SINAV1);
                MessageBox.Show("Toplam puan :"+ toplam.ToString());
            }
            if(radioButton10.Checked==true)
            {
                var ortalama = db.TBLNOTLAR.Average(p => p.SINAV1);
                MessageBox.Show("Sınav1 ortalama :" + ortalama.ToString());
            }
            if(radioButton11.Checked==true)
            {
                dataGridView1.DataSource = db.ortalamaOgrencileriGetir();
            }
            if (radioButton12.Checked == true)
            {
                dataGridView1.DataSource = db.enYuksekNotAlanOgrenciyiGetir();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            var sorgu = from d1 in db.TBLNOTLAR
                        join d2 in db.TBLOGRENCI on d1.OGR equals d2.ID
                        join d3 in db.TBLDERSLER on d1.DERS equals d3.DERSID
                        select new
                        {
                            ÖĞRENCİ = d2.AD,
                            SOYAD=d2.SOYAD,
                            Sınav1 = d1.SINAV1,
                            SINAV2 = d1.SINAV2,
                            SINAV3 = d1.SINAV3,
                            ORTALAMA = d1.ORTALAMA
                        };
            dataGridView1.DataSource = sorgu.ToList();
        }
    }
}
