using SIMS_Projekat_Rampe.Controlers;
using SIMS_Projekat_Rampe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace SIMS_Projekat_Rampe.Views
{
    public partial class IzvestajiView : Form
    {
        Form Predak;
        Korisnik Ulogovan;

        public IzvestajiView(Form form, Korisnik ulogovan)
        {
            Predak = form;
            Ulogovan = ulogovan;
            InitializeComponent();
        }

        private void IzvestajiView_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            comboBox1.Items.Add("Sve stanice");
            NaplatnaStanicaController controller = new NaplatnaStanicaController();
            foreach (var stanica in controller.DobaviSveStanice())
            {
                comboBox1.Items.Add(stanica.Naziv);
            }
            Debug.WriteLine(comboBox1.SelectedItem);
            comboBox1.SelectedIndex = 0;
        }

        private void buttonNazad_Click(object sender, EventArgs e)
        {
            Predak.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerDo.Enabled = !dateTimePickerDo.Enabled;
            if (checkBox1.Checked)
            {
                dateTimePickerDo.Value = dateTimePickerOd.Value;
            }
        }

        private void dateTimePickerOd_ValueChanged(object sender, EventArgs e)
        {
            labelGreska.Visible = false;
            if (checkBox1.Checked)
            {
                dateTimePickerDo.Value = dateTimePickerOd.Value;
            }
            ShowIzvestaji();
        }

        private void dateTimePickerDo_ValueChanged(object sender, EventArgs e)
        {
            ShowIzvestaji();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //ShowIzvestaji();
        }
        private void ShowIzvestaji()
        {
            labelGreska.Visible = false;
            panel3.Visible = false;

            if (dateTimePickerOd.Value > dateTimePickerDo.Value)
            {
                labelGreska.Visible = true;
                labelGreska.Text = "Izabrani datumi nisu validni!";
                return;
            }
            else
            {
                ProlazakControler pc = new ProlazakControler();
                UplataENPControler uc = new UplataENPControler();
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                int prolasciZbir = 0;
                int enpZbir = 0;
                panel3.Visible = true;
                List<Prolazak> prolasci = pc.DobaviProlaske(dateTimePickerOd.Value, dateTimePickerDo.Value, comboBox1.SelectedItem.ToString());
                List<UplataENP> uplate = uc.DobaviUplate(dateTimePickerOd.Value, dateTimePickerDo.Value);
                foreach (Prolazak p in prolasci)
                {
                    List<string> podaci = pc.DobaviPodatkeOProlasku(p);
                    dataGridView1.Rows.Add(podaci[0], podaci[1], podaci[2], podaci[3], podaci[4], podaci[5]);
                    prolasciZbir += int.Parse(podaci[5]);
                }
                label4.Text = "Prihodi od prolazaka: " + prolasciZbir;
                foreach (UplataENP uplata in uplate)
                {
                    dataGridView2.Rows.Add(uplata.Vreme, uplata.Iznos);
                    enpZbir += uplata.Iznos;
                }
                label5.Text = "Prihodi od uplata ENP: " + enpZbir;
                label6.Text = "Ukupni prihodi: " + (enpZbir + prolasciZbir);
            }

        }
    }
}
