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
            Predak = predak;
            Kontroler = new NaplatnoMestoController(ns, rednibr);
            InitializeComponent();
            Inicijalizuj();
        }

        private void btn_ucitaj_Click(object sender, EventArgs e)
        {
            Kontroler.NapraviNoviProlazak();
            Kontroler.SelektovaniTip = (TipVozila)cbx_kategorije.SelectedIndex;
            cbx_kategorije.Enabled = true;
            btn_potvrdi.Enabled = true;
            lab_uspeh.Visible = false;
            OsveziProlazak();
        }

        private void Inicijalizuj() 
        {
            this.Text = "Naplatno mesto " + Kontroler.RedniBrojMesta;
            tbx_rampa.Text = Kontroler.DobaviStanjeRampe();
            lab_displej.Text = Kontroler.DobaviStanjeDispleja();
            lab_citac_tablica.Text = Kontroler.DobaviStanjeCitacaTablica();
            lab_citac_tagova.Text = Kontroler.DobaviStanjeCitacaTagova();
            lab_semafor.Text = Kontroler.DobaviStanjeSemafora();
            OsveziUredjaje();
            
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
            OsveziUredjaje();
        }
        private void OsveziProlazak() 
        {
            lab_prekoracena.Visible = false;
            tbx_vreme.Text = Kontroler.TrenutniProlazak.VremeUlaska.ToString("dd.MM.yyyy HH:mm:ss");
            tbx_mesto.Text = Kontroler.DobaviImeUlazneStanice();
            tbx_reg.Text = Kontroler.TrenutneTablice;
            tbx_prosek.Text = Kontroler.TrenutnaProsecnaBrzina.ToString();
            if (Kontroler.KaznaIzdata) 
            {
                lab_prekoracena.Visible = true;
            }
            tbx_iznos.Text = Kontroler.TrenutniIznos.ToString();
        }
        private void OsveziUredjaje() 
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

        private void NaplatnoMestoView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Predak.Visible = true;
        }

        private void NaplatnoMestoView_Load(object sender, EventArgs e)
        {

        }

        private void btn_potvrdi_Click(object sender, EventArgs e)
        {
            lab_greska.Visible = false;
            
            if (Kontroler.TrenutniProlazak is null) 
            {
                lab_greska.Text = "Greška - prolazak nije učitan";
                lab_greska.Visible = true;
            }

            float razlika = -1;
            try
            {
                razlika = Kontroler.ProveriUplatu(tbx_uplata.Text);
            }
            catch (NaplatnoMestoException exp)
            {
                lab_greska.Text = exp.Message;
                lab_greska.Visible = true;
            }
            
            if (razlika >= 0) 
            {
                tbx_povracaj.Text = razlika.ToString();
                Kontroler.FinalizujProlazak();
                cbx_kategorije.Enabled = false;
                btn_potvrdi.Enabled = false;
                lab_uspeh.Visible = true;
            }

            
        }

        private void cbx_kategorije_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kontroler.PrimeniNovTip((TipVozila)cbx_kategorije.SelectedItem);
            tbx_iznos.Text = Kontroler.TrenutniIznos.ToString();
        }
    }
}
