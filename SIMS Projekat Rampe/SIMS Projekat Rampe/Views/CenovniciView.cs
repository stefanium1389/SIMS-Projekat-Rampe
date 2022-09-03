using SIMS_Projekat_Rampe.Controlers;
using SIMS_Projekat_Rampe.Models;
using System;
using System.Windows.Forms;

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
            var controller = new CenovnikControler();
            var deonicaController = new DeonicaController();
            dataGridView1.Rows.Clear();
            try
            {
                var cenovnik = controller.DobaviCenovnik(dateTimePicker1.Value);

                foreach (var stavka in cenovnik.Stavke)
                {
                    dataGridView1.Rows.Add(deonicaController.MestaDeonice(stavka.DeonicaId)[0], deonicaController.MestaDeonice(stavka.DeonicaId)[1], deonicaController.DuzinaDeonice(stavka.DeonicaId), stavka.TipVozila.ToString(), stavka.Iznos);
                }
                dataGridView1.Visible = true;
                label2.Text = "Cenovnik validan za dan: " + dateTimePicker1.Value.Date.ToString();
                label2.Visible = true;
            }
            catch (CenovnikException exp)
            {
                label2.Visible = false;
                dataGridView1.Visible = false;
                label3.Text = exp.Message;
                label3.Visible = true;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Predak.Show();
            this.Close();
        }
    }
}
