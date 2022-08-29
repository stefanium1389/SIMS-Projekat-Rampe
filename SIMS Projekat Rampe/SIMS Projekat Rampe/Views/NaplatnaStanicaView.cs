using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.Controlers;

namespace SIMS_Projekat_Rampe.Views
{
    public partial class NaplatnaStanicaView : Form
    {
        public Form Predak { get; set; }
        public NaplatnaStanicaController Kontroler {get; set;}
        public bool SefRukovodi { get; set; }

        public NaplatnaStanicaView(Form predak, Korisnik ulogovani)
        {
            Predak = predak;
            Kontroler = new NaplatnaStanicaController(ulogovani);
            InitializeComponent();
            Inicijalizuj();
        }
        public void Inicijalizuj() 
        {
            //tekst forme
            string imeStanice = Kontroler.DobaviImeStanice();
            if (imeStanice != "") 
            {
                this.SefRukovodi = true;
                this.Text = "Naplatna stanica " + imeStanice; 
            }
            else 
            {
                this.SefRukovodi = false;
                this.Text = "Ulogovani ste kao šef stanice";
            }

            //tekst velike labele
            lab_log.Text = "Ulogovani ste kao: " + Kontroler.DobaviImeSefa();

            //tekst male labele
            if (imeStanice != "") 
            {
                lab_stanica.Text = imeStanice;
            }
            else 
            {
                lab_stanica.Text = "Trenutno ne rukovodite nijednu stanicu";
            }

            //popunjavanje tbx
            if (SefRukovodi) 
            {
                tbx_brradnika.Text = Kontroler.DobaviBrojRadnika().ToString();
                tbx_brobicnih.Text = Kontroler.DobaviBrojObicnih().ToString();
                tbx_brelektronskih.Text = Kontroler.DobaviBrojElektronskih().ToString();
                tbx_brenp.Text = Kontroler.DobaviBrojENP().ToString();
            }

            //popunjavanje cbx naplatnih mesta
            if (SefRukovodi == false) 
            {
                cbx_mesta.Enabled = false;
            }
            else 
            {
                List<string> imena = Kontroler.DobaviImenaMesta();
                foreach (string ime in imena)
                {
                    this.cbx_mesta.Items.Add(ime);
                }
                if (imena.Count > 0)
                {
                    this.cbx_mesta.SelectedIndex = 0;
                }
            }

            //popuni statuse
            OsveziNaplatnoMesto();

            //popuni cbx tipova uredjaja
            foreach (TipUredjaja tip in Enum.GetValues(typeof(TipUredjaja)))
            {
                cbx_tip.Items.Add(tip);
            }
            cbx_tip.SelectedIndex = 0;
            if (SefRukovodi == false) 
            {
                cbx_tip.Enabled = false;
            }

            //(ne)dozvoli dugme za popravku
            if (SefRukovodi == false)
            {
                btn_popravi.Enabled = false;
            }

        }

        private void OsveziNaplatnoMesto() 
        {
            if (SefRukovodi == false) 
            {
                lab_dispej.Text = "----";
                lab_rampa.Text = "----";
                lab_tablice.Text = "----";
                lab_tag.Text = "----";
                lab_semafor.Text = "----";
            }
            else 
            {
                int rednibr = Int32.Parse(cbx_mesta.SelectedItem.ToString().Replace("naplatno mesto ", ""));
                string stanjeDispleja = Kontroler.DobaviStanjeUredjaja(rednibr,TipUredjaja.Displej);
                string stanjeRampe = Kontroler.DobaviStanjeUredjaja(rednibr, TipUredjaja.Rampa);
                string stanjeTablice = Kontroler.DobaviStanjeUredjaja(rednibr, TipUredjaja.CitacTablice);
                string stanjeTagova = Kontroler.DobaviStanjeUredjaja(rednibr, TipUredjaja.CitacTagova);
                string stanjeSemafora = Kontroler.DobaviStanjeUredjaja(rednibr, TipUredjaja.Semafor);

                lab_dispej.Text = stanjeDispleja;
                lab_rampa.Text = stanjeRampe;
                lab_semafor.Text = stanjeSemafora;
                lab_tag.Text = stanjeTagova;
                lab_tablice.Text = stanjeTablice;

                if (stanjeDispleja == "radi") 
                {
                    this.lab_dispej.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    this.lab_dispej.ForeColor = System.Drawing.Color.Red;
                }

                if (stanjeRampe == "radi")
                {
                    this.lab_rampa.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    this.lab_rampa.ForeColor = System.Drawing.Color.Red;
                }

                if (stanjeTablice == "radi")
                {
                    this.lab_tablice.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    this.lab_tablice.ForeColor = System.Drawing.Color.Red;
                }

                if (stanjeTagova == "radi" || stanjeTagova =="----")
                {
                    this.lab_tag.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    this.lab_tag.ForeColor = System.Drawing.Color.Red;
                }

                if (stanjeSemafora == "radi")
                {
                    this.lab_semafor.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    this.lab_semafor.ForeColor = System.Drawing.Color.Red;
                }
                this.Refresh();
            }
        }

        private void NaplatnaStanicaView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Predak.Visible = true;
        }

        private void cbx_mesta_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsveziNaplatnoMesto();
        }

        private void btn_nazad_Click(object sender, EventArgs e)
        {
            Predak.Visible = true;
            this.Close();
        }

        private void NaplatnaStanicaView_Load(object sender, EventArgs e)
        {

        }

        private void btn_popravi_Click(object sender, EventArgs e)
        {
            int rednibr = Int32.Parse(cbx_mesta.SelectedItem.ToString().Replace("naplatno mesto ", ""));
            Kontroler.OznaciKaoPopravljeno((TipUredjaja)cbx_tip.SelectedIndex, rednibr);
            OsveziNaplatnoMesto();
        }
    }
}
