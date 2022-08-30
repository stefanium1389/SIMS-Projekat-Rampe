using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIMS_Projekat_Rampe.Controlers;
using SIMS_Projekat_Rampe.Models;

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
            //ShowIzvestaji();
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
                panel3.Visible = true;
            }

        }
    }
}
