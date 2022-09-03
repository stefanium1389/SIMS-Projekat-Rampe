using SIMS_Projekat_Rampe.Models;
using System;
using System.Windows.Forms;

namespace SIMS_Projekat_Rampe.Views
{
    public partial class MenadzerMeniView : Form
    {

        public Form Predak { get; set; }
        public Korisnik Ulogovani { get; set; }
        public MenadzerMeniView()
        {
            InitializeComponent();
        }
        public MenadzerMeniView(Form predak, Korisnik korisnik)
        {
            Predak = predak;
            Ulogovani = korisnik;
            InitializeComponent();
        }

        private void MenadzerMeniView_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            label1.Text = "Trenutno Ulogovan: " + Ulogovani.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CenovniciView cenovnici = new CenovniciView(this, Ulogovani);
            cenovnici.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IzvestajiView izvestaji = new IzvestajiView(this, Ulogovani);
            izvestaji.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Predak.Visible = true;
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CenovniciView cenovnici = new CenovniciView(this, Ulogovani);
            cenovnici.Show();
            this.Visible = false;
        }
    }
}
