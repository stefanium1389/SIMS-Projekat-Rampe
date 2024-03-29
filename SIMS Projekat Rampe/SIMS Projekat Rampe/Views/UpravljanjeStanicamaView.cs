﻿using SIMS_Projekat_Rampe.Controlers;
using SIMS_Projekat_Rampe.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIMS_Projekat_Rampe.Views
{


    public partial class UpravljanjeStanicamaView : Form
    {
        public UpravljanjeStanicamaController Kontroler { get; set; }
        public Form Predak { get; set; }
        public UpravljanjeStanicamaView(Form predak, Korisnik admin)
        {
            Predak = predak;
            Kontroler = new UpravljanjeStanicamaController(admin);

            InitializeComponent();
            Inicijalizuj();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpravljanjeStanicamaView_Load(object sender, EventArgs e)
        {

        }

        private void UpravljanjeStanicamaView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Predak.Visible = true;
        }

        private void Inicijalizuj()
        {
            //login label
            lab_log.Text = "Ulogovani ste kao: " + Kontroler.DobaviUlogovanog();

            //postavi imena kolona za tabele
            table_opsti.ColumnCount = 2;
            table_opsti.Columns[0].Name = "Podatak";
            table_opsti.Columns[1].Name = "Vrednost";
            table_opsti.RowHeadersVisible = false;

            table_zaposleni.ColumnCount = 3;
            table_zaposleni.Columns[0].Name = "Ime";
            table_zaposleni.Columns[1].Name = "Prezime";
            table_zaposleni.Columns[2].Name = "Vrsta";
            table_zaposleni.RowHeadersVisible = false;

            table_cene.ColumnCount = 2;
            table_cene.Columns[0].Name = "Tip vozila";
            table_cene.Columns[1].Name = "Cena";
            table_cene.RowHeadersVisible = false;

            table_povezane.ColumnCount = 2;
            table_povezane.Columns[0].Name = "Stanica";
            table_povezane.Columns[1].Name = "Daljina";
            table_povezane.RowHeadersVisible = false;

            OsveziCbx();

        }
        private void OsveziCbx()
        {
            cbx_stanice.Items.Clear();
            List<NaplatnaStanica> stanice = Kontroler.DobaviStanice();
            foreach (var stanica in stanice)
            {
                cbx_stanice.Items.Add(stanica);
            }
            if (stanice.Count > 0)
            {
                cbx_stanice.SelectedIndex = 0;
                //nije potrebno da se osvezi jer se osvezava kad se promeni selektovani indeks
            }
        }

        private void OsveziTabele()
        {
            PopuniPodatkeOStanici();
            PopuniPodatkeOZaposlenima();
            PopuniPodatkeODeonicama();
            //i ovo moze biti problematicno
            if (table_povezane.Rows.Count > 0)
            {
                table_povezane.Rows[0].Selected = true;
            }
            //ovde bi islo popuni o cenama ali event to radi
        }

        private void PopuniPodatkeOStanici()
        {
            List<string[]> podaci = Kontroler.DobaviPodatkeOStanici((NaplatnaStanica)cbx_stanice.SelectedItem);

            foreach (var red in podaci)
            {
                table_opsti.Rows.Add(red);
            }
        }

        private void PopuniPodatkeOZaposlenima()
        {
            List<string[]> podaci = Kontroler.DobaviPodatkeOZaposlenima((NaplatnaStanica)cbx_stanice.SelectedItem);

            foreach (var red in podaci)
            {
                table_zaposleni.Rows.Add(red);
            }
        }

        private void PopuniPodatkeODeonicama()
        {
            List<string[]> podaci = Kontroler.DobaviPodatkeODeonicama((NaplatnaStanica)cbx_stanice.SelectedItem);

            foreach (var red in podaci)
            {
                table_povezane.Rows.Add(red);
            }
        }

        private void PopuniPodatkeOCenama()
        {
            NaplatnaStanica ns = Kontroler.DobaviStanicuIzTabele(table_povezane.SelectedRows[0].Cells[0].Value.ToString());
            string stanica_cbx = ((NaplatnaStanica)cbx_stanice.SelectedItem).Id;
            List<string[]> podaci = Kontroler.DobaviPodatkeOCenama(stanica_cbx, ns.Id);

            foreach (var red in podaci)
            {
                table_cene.Rows.Add(red);
            }
        }

        private void OcistiTabele()
        {
            table_opsti.Rows.Clear();
            table_cene.Rows.Clear();
            table_povezane.Rows.Clear();
            table_zaposleni.Rows.Clear();
        }

        private void cbx_stanice_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcistiTabele();
            OsveziTabele();
        }

        private void table_povezane_SelectionChanged(object sender, EventArgs e)
        {
            if (table_povezane.SelectedRows.Count > 0)
            {
                table_cene.Rows.Clear();
                PopuniPodatkeOCenama();
            }
        }

        private void btn_kreiraj_Click(object sender, EventArgs e)
        {
            CUStaniceView prozor = new CUStaniceView(this, null);
            if (prozor.ShowDialog() == DialogResult.OK)
            {
                string box_msg = "Kreiranje stanice uspešno izvršeno";
                string box_title = "Uspeh";
                MessageBox.Show(box_msg, box_title);
                //ideja za nadogradnju - kad se osveži cbx neka ostane selektovana stanica
                OsveziCbx();
            }
        }

        private void btn_izmeni_Click(object sender, EventArgs e)
        {
            CUStaniceView prozor = new CUStaniceView(this, (NaplatnaStanica)cbx_stanice.SelectedItem);
            if (prozor.ShowDialog() == DialogResult.OK)
            {
                string box_msg = "Izmena stanice uspešno izvršena";
                string box_title = "Uspeh";
                MessageBox.Show(box_msg, box_title);
                //ideja za nadogradnju - kad se osveži cbx neka ostane selektovana stanica
                OsveziCbx();
            }
        }

        private void btn_obrisi_Click(object sender, EventArgs e)
        {
            if (cbx_stanice.SelectedIndex > -1)
            {
                Kontroler.ObrisiStanicu((NaplatnaStanica)cbx_stanice.SelectedItem);
                OsveziCbx();
            }
        }

        private void btn_izadji_Click(object sender, EventArgs e)
        {
            this.Predak.Visible = true;
            this.Close();
        }
    }
}
