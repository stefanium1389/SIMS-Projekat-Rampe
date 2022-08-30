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


    public partial class UpravljanjeStanicamaView : Form
    {
        public UpravljanjeStanicamaController Kontroler { get; set; }
        public Form Predak { get; set; }
        public UpravljanjeStanicamaView (Form predak, Korisnik admin)
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


            //popunjavanje cbx za stanice
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
            table_povezane.Rows[0].Selected = true;
            //ovde bi islo popuni o cenama ali event to radi
        }

        private void PopuniPodatkeOStanici()
        {
            List <string[]> podaci = Kontroler.DobaviPodatkeOStanici((NaplatnaStanica)cbx_stanice.SelectedItem);

            foreach(var red in podaci) 
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
            System.Diagnostics.Debug.WriteLine(table_povezane.SelectedRows.Count);
            System.Diagnostics.Debug.WriteLine(table_povezane.SelectedRows[0].Cells.Count);
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

        
    }
}
