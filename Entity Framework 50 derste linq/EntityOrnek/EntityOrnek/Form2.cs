﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DbSinavOgrenciEntities db = new DbSinavOgrenciEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                var degerler = db.TBLNOTLAR.Where(p => p.SINAV1 < 50);
                dataGridView1.DataSource = degerler.ToList();
            }
        }
    }
}
