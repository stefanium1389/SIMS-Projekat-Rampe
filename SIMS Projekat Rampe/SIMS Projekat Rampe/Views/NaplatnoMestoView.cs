﻿using SIMS_Projekat_Rampe.Controlers;
using SIMS_Projekat_Rampe.Models;
using System;
using System.Windows.Forms;

namespace SIMS_Projekat_Rampe.Views
{
    public partial class NaplatnoMestoView : Form, IObserver
    {
        public NaplatnoMestoController Kontroler { get; set; }
        public Form Predak { get; set; }
        public NaplatnoMestoView(Form predak, NaplatnaStanica ns, int rednibr)
        {
            Predak = predak;
            Kontroler = new NaplatnoMestoController(ns, rednibr);
            Kontroler.PrijaviViewKaoObserver(this);
            InitializeComponent();
            Inicijalizuj();
        }

        public void Perform(string s)
        {

            if (s == "osvezi")
            {
                OsveziRampuISemafor();
            }

        }
        private void btn_ucitaj_Click(object sender, EventArgs e)
        {
            try
            {
                Kontroler.NapraviNoviProlazak();
            }
            catch (NaplatnoMestoException exp)
            {
                lab_greska.Text = exp.Message;
                lab_greska.Visible = true;
            }
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
            tbx_semafor.Text = Kontroler.DobaviProlazakSemafora();
            if (Kontroler.DobaviStanjeRampe() == "spuštena")
            {
                btn_podigni.Enabled = true;
            }
            OsveziUredjaje();

            foreach (TipVozila tip in Enum.GetValues(typeof(TipVozila)))
            {
                cbx_kategorije.Items.Add(tip);
            }

            bool elektronsko = Kontroler.IsElektronsko();
            foreach (TipUredjaja tip in Enum.GetValues(typeof(TipUredjaja)))
            {
                if (!elektronsko && tip == TipUredjaja.CitacTagova)
                {
                    continue;
                }
                cbx_uredjaj.Items.Add(tip);
            }

            cbx_kategorije.SelectedIndex = 0;
            cbx_uredjaj.SelectedIndex = 0;
        }

        private void btn_prijavi_Click(object sender, EventArgs e)
        {
            btn_podigni.Enabled = false;
            Kontroler.RegistrujKvar((TipUredjaja)cbx_uredjaj.SelectedItem);
            OsveziUredjaje();
            OsveziRampuISemafor();
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

        private void OsveziRampuISemafor()
        {
            tbx_rampa.Text = Kontroler.DobaviStanjeRampe();
            tbx_semafor.Text = Kontroler.DobaviProlazakSemafora();
            if (Kontroler.DobaviStanjeRampe() == "spuštena")
            {
                btn_podigni.Enabled = true;
            }
            Kontroler.ZabeleziPromene();
            OsveziUredjaje();
            this.Refresh();
        }
        private void OsveziUredjaje()
        {
            lab_displej.Text = Kontroler.DobaviStanjeDispleja();
            lab_citac_tablica.Text = Kontroler.DobaviStanjeCitacaTablica();
            lab_citac_tagova.Text = Kontroler.DobaviStanjeCitacaTagova();
            lab_semafor.Text = Kontroler.DobaviStanjeSemafora();
            tbx_rampa.Text = Kontroler.DobaviStanjeRampe();

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

        private void lab_citac_tablica_Click(object sender, EventArgs e)
        {

        }

        private void btn_podigni_Click(object sender, EventArgs e)
        {
            btn_podigni.Enabled = false;
            Kontroler.PodigniRampu();
            OsveziRampuISemafor();
        }

        private void btn_izadji_Click(object sender, EventArgs e)
        {
            this.Predak.Visible = true;
            this.Close();
        }
    }
}
