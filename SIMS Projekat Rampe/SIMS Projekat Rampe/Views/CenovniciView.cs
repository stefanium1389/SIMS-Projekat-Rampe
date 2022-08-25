using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIMS_Projekat_Rampe.Models;

namespace SIMS_Projekat_Rampe.Views
{
    public partial class CenovniciView : Form
    {
        public Form Predak { get; set; }
        public Korisnik Ulogovan { get; set; }
        public CenovniciView()
        {
            InitializeComponent();
        }

        public CenovniciView(Form predak, Korisnik korisnik)
        {
            Predak = predak;
            Ulogovan = korisnik;
            InitializeComponent();
        }

        private void CenovniciView_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Show();
            dataGridView1.Show();
            label3.Visible = !label3.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Predak.Show();
            this.Close();
        }
    }
}
