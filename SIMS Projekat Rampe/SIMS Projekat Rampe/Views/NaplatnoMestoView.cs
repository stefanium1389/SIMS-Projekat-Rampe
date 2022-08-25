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
    public partial class NaplatnoMestoView : Form
    {

        public NaplatnoMestoController Kontroler {get; set;}
        public Form Predak { get; set; }
        public NaplatnoMestoView(Form predak, NaplatnaStanica ns, int rednibr)
        {
            Kontroler = new NaplatnoMestoController(ns, rednibr);
            InitializeComponent();
            Inicijalizuj();
        }

        private void btn_ucitaj_Click(object sender, EventArgs e)
        {

        }

        private void Inicijalizuj() 
        {
            this.Text = "Naplatno mesto " + Kontroler.RedniBrojMesta;
            tbx_rampa.Text = Kontroler.DobaviStanjeRampe();
            lab_displej.Text = Kontroler.DobaviStanjeDispleja();
            lab_citac_tablica.Text = Kontroler.DobaviStanjeCitacaTablica();
            lab_citac_tagova.Text = Kontroler.DobaviStanjeCitacaTagova();
            lab_semafor.Text = Kontroler.DobaviStanjeSemafora();
            osveziUredjaje();
            
            foreach (TipVozila tip in Enum.GetValues(typeof(TipVozila)))
            {
                cbx_kategorije.Items.Add(tip);
            }

            foreach (TipUredjaja tip in Enum.GetValues(typeof(TipUredjaja)))
            {
                cbx_uredjaj.Items.Add(tip);
            }

            cbx_kategorije.SelectedIndex = 0;
            cbx_uredjaj.SelectedIndex = 0;
        }

        private void btn_prijavi_Click(object sender, EventArgs e)
        {
            Kontroler.RegistrujKvar((TipUredjaja)cbx_uredjaj.SelectedItem);
            lab_displej.Text = Kontroler.DobaviStanjeDispleja();
            lab_citac_tablica.Text = Kontroler.DobaviStanjeCitacaTablica();
            lab_citac_tagova.Text = Kontroler.DobaviStanjeCitacaTagova();
            lab_semafor.Text = Kontroler.DobaviStanjeSemafora();
            tbx_rampa.Text = Kontroler.DobaviStanjeRampe();
            osveziUredjaje();
        }

        private void osveziUredjaje() 
        {
            if (lab_displej.Text == "pokvaren")
            {
                lab_displej.ForeColor = System.Drawing.Color.Red;
            }
            else 
            {
                lab_displej.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            }

            if (lab_semafor.Text == "pokvaren")
            {
                lab_semafor.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lab_semafor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            }

            if (lab_citac_tablica.Text == "pokvaren")
            {
                lab_citac_tablica.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lab_citac_tablica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            }

            if (lab_citac_tagova.Text == "pokvaren")
            {
                lab_citac_tagova.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lab_citac_tagova.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            }
        }

        private void NaplatnoMestoView_Load(object sender, EventArgs e)
        {

        }
    }
}
