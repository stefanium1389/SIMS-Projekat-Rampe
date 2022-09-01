﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIMS_Projekat_Rampe.Controlers;
using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.MongolDb;

namespace SIMS_Projekat_Rampe.Views
{
    public partial class CUStaniceView : Form
    {
        public CUStaniceController Kontroler {get; set;}
        public Form Predak { get; set; }
        public float VrednostIzmenePovezane { get; set; }
        public float VrednostIzmeneCene { get; set; }

        public CUStaniceView(Form predak, NaplatnaStanica stanica)
        {
            Predak = predak;
            Kontroler = new CUStaniceController(stanica);
            InitializeComponent();
            Inicijalizuj();
        }

        public void Inicijalizuj()
        {
            //Promena imena prozora u zavisnosti od akcije
            if (Kontroler.Kreiranje) 
            {
                this.Text = "Kreiranje stanice";
            }
            else 
            {
                this.Text = "Izmena stanice "+Kontroler.Stanica.Naziv;
            }

            //(izmena) popunjavanje tbx
            if (!Kontroler.Kreiranje) 
            {
                tbx_naziv.Text = Kontroler.Stanica.Naziv;
                tbx_obicnih.Text = Kontroler.DobaviBrojObicnih().ToString();
                tbx_elektronskih.Text = Kontroler.DobaviBrojElektronskih().ToString();
            }

            //popunjavanje cbx
            foreach (TipKorisnika tip in Enum.GetValues(typeof(TipKorisnika)))
            {
                if (tip == TipKorisnika.Admin || tip == TipKorisnika.Menadzer) 
                {
                    continue;
                }
                cbx_tip.Items.Add(tip);
            }

            cbx_tip.SelectedIndex = 0;
            //ovo triggeruje osvezavanje listbox-a

            //tabela zaposlenih
            table_zaposleni.RowHeadersVisible = false;
            
            table_zaposleni.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Ime";
            column.HeaderText = "Ime";
            table_zaposleni.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Prezime";
            column.HeaderText = "Prezime";
            table_zaposleni.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Tip";
            column.HeaderText = "Vrsta";
            table_zaposleni.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "UserName";
            column.HeaderText = "Korisničko ime";
            table_zaposleni.Columns.Add(column);

            table_zaposleni.DataSource = Kontroler.Zaposleni;

            //popunjavanje tabele povezanih
            table_deonice.ColumnCount = 2;
            table_deonice.Columns[0].Name = "Stanica";
            table_deonice.Columns[1].Name = "Daljina";
            table_deonice.RowHeadersVisible = false;
            table_deonice.Columns[0].ReadOnly = true;
            OsveziTabeluPovezanih();

            //popunjavanje tabele cena
            table_cene.ColumnCount = 2;
            table_cene.Columns[0].Name = "Tip Vozila";
            table_cene.Columns[1].Name = "Cena";
            table_cene.RowHeadersVisible = false;
            table_cene.Columns[0].ReadOnly = true;
            OsveziTabeluCena();

        }

        public void OsveziTabeluCena()
        {
            if (table_deonice.SelectedRows.Count < 1) 
            {
                System.Diagnostics.Debug.WriteLine("aaaaaaaaaaaaaaaaaaaaa");
                return;
            }
            table_cene.Rows.Clear();
            NaplatnaStanica st = Kontroler.PretvoriUStanicu((string)table_deonice.SelectedRows[0].Cells[0].Value);
            //System.Diagnostics.Debug.WriteLine(st.Id+" "+st.Naziv);
            foreach (var item in Kontroler.TabelaCenaPodaci)
            {
                if (item.Key.Id == st.Id) 
                {
                    foreach(var item2 in item.Value) 
                    {
                        var red = new string[] { item2.Key.ToString(), item2.Value.ToString() };
                        table_cene.Rows.Add(red);
                    }  
                }
                
            }
        }

        public void OsveziTabeluPovezanih() 
        {
            table_deonice.Rows.Clear();
            foreach (var item in Kontroler.TabelaPovezanihPodaci)
            {
                var red = new string[] { item.Key.Naziv + " [" + item.Key.Id + "]", item.Value.ToString() };
                table_deonice.Rows.Add(red);
            }

            if (table_deonice.Rows.Count > 0) 
            {
                table_deonice.Rows[0].Selected = true;
            }
            
        }

        public void OsveziListBox() 
        {
            //nije lep način ali radi
            lbx_zaposleni.DataSource = null;
            lbx_zaposleni.DataSource = Kontroler.ListBoxPodaci[(TipKorisnika)cbx_tip.SelectedItem];
        }

        private void cbx_tip_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsveziListBox();
        }

        private void btn_ukloni_zaposlenog_Click(object sender, EventArgs e)
        {
            Korisnik odabrani = (Korisnik)table_zaposleni.CurrentRow.DataBoundItem;
            Kontroler.Zaposleni.Remove(odabrani);
            Kontroler.ListBoxPodaci[odabrani.Tip].Add(odabrani);
            OsveziZaposlene();
            OsveziListBox();
        }

        private void btn_dodaj_zaposlenog_Click(object sender, EventArgs e)
        {
            if (lbx_zaposleni.SelectedIndex != -1)
            {
                Kontroler.Zaposleni.Add((Korisnik)lbx_zaposleni.SelectedItem);
                Kontroler.ListBoxPodaci[(TipKorisnika)cbx_tip.SelectedItem].Remove((Korisnik)lbx_zaposleni.SelectedItem);
                OsveziZaposlene();
                OsveziListBox();
            }
        }
        private void OsveziZaposlene()
        {   
            //nije lep način ali radi
            table_zaposleni.DataSource = null;
            table_zaposleni.DataSource = Kontroler.Zaposleni;
        }

        private void table_deonice_SelectionChanged(object sender, EventArgs e)
        {
            if(table_cene.Columns.Count > 0) 
            {
                OsveziTabeluCena();
            }
            
        }

        private void table_deonice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            float rez = -1;
            if (!float.TryParse(table_deonice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out rez))
            {
                table_deonice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = VrednostIzmenePovezane.ToString();
                return;
            }
            
            if (rez <= 0) 
            {
                table_deonice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = VrednostIzmenePovezane.ToString();
                return;
            }

            // nije testirano! moze biti uzrok buduceg bug-a!
            NaplatnaStanica st = Kontroler.PretvoriUStanicu((string)table_deonice.SelectedRows[0].Cells[0].Value);
            Kontroler.TabelaPovezanihPodaci[st] = rez;
            System.Diagnostics.Debug.WriteLine(Kontroler.TabelaPovezanihPodaci[st]);

        }

        private void table_deonice_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            VrednostIzmenePovezane = float.Parse(table_deonice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //System.Diagnostics.Debug.WriteLine(VrednostIzmenePovezane);
        }

        private void table_cene_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            VrednostIzmeneCene = float.Parse(table_cene.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //System.Diagnostics.Debug.WriteLine(VrednostIzmenePovezane);
        }

        private void table_cene_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            float rez = -1;
            if (!float.TryParse(table_cene.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out rez))
            {
                table_cene.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = VrednostIzmeneCene.ToString();
                return;
            }

            if (rez <= 0)
            {
                table_cene.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = VrednostIzmeneCene.ToString();
                return;
            }

            NaplatnaStanica st = Kontroler.PretvoriUStanicu((string)table_deonice.SelectedRows[0].Cells[0].Value);
            TipVozila tip = Kontroler.PretvoriUTipVozila((string)table_cene.Rows[e.RowIndex].Cells[0].Value.ToString());
            foreach (var item in Kontroler.TabelaCenaPodaci)
            {
                if (item.Key.Id == st.Id)
                {
                    item.Value[tip] = rez;
                }

            }
        }
    }
}
