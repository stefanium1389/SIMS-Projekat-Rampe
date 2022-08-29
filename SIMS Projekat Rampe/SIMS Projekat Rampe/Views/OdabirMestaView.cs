using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIMS_Projekat_Rampe.Controlers;
using SIMS_Projekat_Rampe.Models;

namespace SIMS_Projekat_Rampe.Views
{
    public partial class OdabirMestaView : Form
    {
        public Form Predak { get; set; }
        public OdabirMestaController OdabirController {get; set;}
        public OdabirMestaView(Korisnik ulogovani, Form predak)
        {
            Predak = predak;
            OdabirController = new OdabirMestaController(ulogovani);
            InitializeComponent();
            this.loginLabel.Text = "Ulogovani ste kao: " + OdabirController.DobaviImeUlogovanog();
            this.labelStanica.Text = OdabirController.DobaviImeStanice();
            List<string> imena = OdabirController.DobaviImenaMesta();
            foreach (string ime in imena)
            {
                this.comboBox1.Items.Add(ime);
            }
            if (imena.Count > 0) 
            {
                this.comboBox1.SelectedIndex = 0;
            }
            else 
            {
                comboBox1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void OdabirMestaView_Load(object sender, EventArgs e)
        {

        }

        private void OdabirMestaView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Predak.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Predak.Visible = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == -1) 
            {
                //todo: prikazi neku poruku
            }
            else 
            {
                string rednibr = comboBox1.Text.Replace("naplatno mesto ","");
                int rednibrint = Int32.Parse(rednibr);
                NaplatnoMestoView nmv = new NaplatnoMestoView(this,OdabirController.DobaviStanicu(),rednibrint);
                nmv.Show();
                this.Visible = false;
            }
        }
    }
}
