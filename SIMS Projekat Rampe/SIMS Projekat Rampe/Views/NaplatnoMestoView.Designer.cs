
namespace SIMS_Projekat_Rampe.Views
{
    partial class NaplatnoMestoView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ucitaj = new System.Windows.Forms.Button();
            this.tbx_vreme = new System.Windows.Forms.TextBox();
            this.tbx_mesto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_kategorije = new System.Windows.Forms.ComboBox();
            this.btn_potvrdi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_iznos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_uplata = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_povracaj = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_uspeh = new System.Windows.Forms.Label();
            this.lab_greska = new System.Windows.Forms.Label();
            this.tbx_reg = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lab_prekoracena = new System.Windows.Forms.Label();
            this.tbx_prosek = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbx_rampa = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbx_semafor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btn_podigni = new System.Windows.Forms.Button();
            this.lab_citac_tagova = new System.Windows.Forms.Label();
            this.lab_semafor = new System.Windows.Forms.Label();
            this.lab_citac_tablica = new System.Windows.Forms.Label();
            this.lab_displej = new System.Windows.Forms.Label();
            this.btn_prijavi = new System.Windows.Forms.Button();
            this.cbx_uredjaj = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ucitaj
            // 
            this.btn_ucitaj.Location = new System.Drawing.Point(15, 14);
            this.btn_ucitaj.Name = "btn_ucitaj";
            this.btn_ucitaj.Size = new System.Drawing.Size(108, 65);
            this.btn_ucitaj.TabIndex = 0;
            this.btn_ucitaj.Text = "Učitaj Kod (QR)";
            this.btn_ucitaj.UseVisualStyleBackColor = true;
            this.btn_ucitaj.Click += new System.EventHandler(this.btn_ucitaj_Click);
            // 
            // tbx_vreme
            // 
            this.tbx_vreme.Location = new System.Drawing.Point(123, 109);
            this.tbx_vreme.Name = "tbx_vreme";
            this.tbx_vreme.ReadOnly = true;
            this.tbx_vreme.Size = new System.Drawing.Size(165, 23);
            this.tbx_vreme.TabIndex = 1;
            // 
            // tbx_mesto
            // 
            this.tbx_mesto.Location = new System.Drawing.Point(123, 151);
            this.tbx_mesto.Name = "tbx_mesto";
            this.tbx_mesto.ReadOnly = true;
            this.tbx_mesto.Size = new System.Drawing.Size(165, 23);
            this.tbx_mesto.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vreme ulaska";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mesto ulaska";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Odabir kategorije vozila";
            // 
            // cbx_kategorije
            // 
            this.cbx_kategorije.FormattingEnabled = true;
            this.cbx_kategorije.Location = new System.Drawing.Point(153, 194);
            this.cbx_kategorije.Name = "cbx_kategorije";
            this.cbx_kategorije.Size = new System.Drawing.Size(121, 23);
            this.cbx_kategorije.TabIndex = 6;
            this.cbx_kategorije.SelectedIndexChanged += new System.EventHandler(this.cbx_kategorije_SelectedIndexChanged);
            // 
            // btn_potvrdi
            // 
            this.btn_potvrdi.Location = new System.Drawing.Point(18, 311);
            this.btn_potvrdi.Name = "btn_potvrdi";
            this.btn_potvrdi.Size = new System.Drawing.Size(75, 23);
            this.btn_potvrdi.TabIndex = 7;
            this.btn_potvrdi.Text = "Potvrdi";
            this.btn_potvrdi.UseVisualStyleBackColor = true;
            this.btn_potvrdi.Click += new System.EventHandler(this.btn_potvrdi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Iznos :";
            // 
            // tbx_iznos
            // 
            this.tbx_iznos.Location = new System.Drawing.Point(95, 237);
            this.tbx_iznos.Name = "tbx_iznos";
            this.tbx_iznos.ReadOnly = true;
            this.tbx_iznos.Size = new System.Drawing.Size(100, 23);
            this.tbx_iznos.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Uplata:";
            // 
            // tbx_uplata
            // 
            this.tbx_uplata.Location = new System.Drawing.Point(95, 273);
            this.tbx_uplata.Name = "tbx_uplata";
            this.tbx_uplata.Size = new System.Drawing.Size(100, 23);
            this.tbx_uplata.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Povraćaj:";
            // 
            // tbx_povracaj
            // 
            this.tbx_povracaj.Location = new System.Drawing.Point(95, 351);
            this.tbx_povracaj.Name = "tbx_povracaj";
            this.tbx_povracaj.ReadOnly = true;
            this.tbx_povracaj.Size = new System.Drawing.Size(100, 23);
            this.tbx_povracaj.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lab_uspeh);
            this.panel1.Controls.Add(this.lab_greska);
            this.panel1.Controls.Add(this.tbx_reg);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lab_prekoracena);
            this.panel1.Controls.Add(this.tbx_prosek);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn_ucitaj);
            this.panel1.Controls.Add(this.tbx_povracaj);
            this.panel1.Controls.Add(this.tbx_vreme);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbx_mesto);
            this.panel1.Controls.Add(this.tbx_uplata);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbx_iznos);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbx_kategorije);
            this.panel1.Controls.Add(this.btn_potvrdi);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 425);
            this.panel1.TabIndex = 14;
            // 
            // lab_uspeh
            // 
            this.lab_uspeh.AutoSize = true;
            this.lab_uspeh.ForeColor = System.Drawing.Color.Blue;
            this.lab_uspeh.Location = new System.Drawing.Point(456, 394);
            this.lab_uspeh.Name = "lab_uspeh";
            this.lab_uspeh.Size = new System.Drawing.Size(153, 15);
            this.lab_uspeh.TabIndex = 20;
            this.lab_uspeh.Text = "Uspešno zabeležen prolazak";
            this.lab_uspeh.Visible = false;
            // 
            // lab_greska
            // 
            this.lab_greska.ForeColor = System.Drawing.Color.Red;
            this.lab_greska.Location = new System.Drawing.Point(16, 394);
            this.lab_greska.Name = "lab_greska";
            this.lab_greska.Size = new System.Drawing.Size(434, 15);
            this.lab_greska.TabIndex = 19;
            this.lab_greska.Text = "greska";
            this.lab_greska.Visible = false;
            // 
            // tbx_reg
            // 
            this.tbx_reg.Location = new System.Drawing.Point(436, 106);
            this.tbx_reg.Name = "tbx_reg";
            this.tbx_reg.ReadOnly = true;
            this.tbx_reg.Size = new System.Drawing.Size(100, 23);
            this.tbx_reg.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(321, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Registarska oznaka:";
            // 
            // lab_prekoracena
            // 
            this.lab_prekoracena.ForeColor = System.Drawing.Color.Red;
            this.lab_prekoracena.Location = new System.Drawing.Point(240, 280);
            this.lab_prekoracena.Name = "lab_prekoracena";
            this.lab_prekoracena.Size = new System.Drawing.Size(479, 16);
            this.lab_prekoracena.TabIndex = 16;
            this.lab_prekoracena.Text = "Prosečna brzina prekoračena - kazna poslata";
            this.lab_prekoracena.Visible = false;
            // 
            // tbx_prosek
            // 
            this.tbx_prosek.Location = new System.Drawing.Point(339, 234);
            this.tbx_prosek.Name = "tbx_prosek";
            this.tbx_prosek.ReadOnly = true;
            this.tbx_prosek.Size = new System.Drawing.Size(100, 23);
            this.tbx_prosek.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Prosečna brzina:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "Rampa:";
            // 
            // tbx_rampa
            // 
            this.tbx_rampa.Location = new System.Drawing.Point(71, 21);
            this.tbx_rampa.Name = "tbx_rampa";
            this.tbx_rampa.ReadOnly = true;
            this.tbx_rampa.Size = new System.Drawing.Size(100, 23);
            this.tbx_rampa.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.tbx_semafor);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.btn_podigni);
            this.panel2.Controls.Add(this.lab_citac_tagova);
            this.panel2.Controls.Add(this.lab_semafor);
            this.panel2.Controls.Add(this.lab_citac_tablica);
            this.panel2.Controls.Add(this.lab_displej);
            this.panel2.Controls.Add(this.btn_prijavi);
            this.panel2.Controls.Add(this.cbx_uredjaj);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.tbx_rampa);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(12, 487);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(816, 150);
            this.panel2.TabIndex = 15;
            // 
            // tbx_semafor
            // 
            this.tbx_semafor.Location = new System.Drawing.Point(247, 21);
            this.tbx_semafor.Name = "tbx_semafor";
            this.tbx_semafor.ReadOnly = true;
            this.tbx_semafor.Size = new System.Drawing.Size(100, 23);
            this.tbx_semafor.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(187, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 35;
            this.label8.Text = "Semafor:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(593, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 15);
            this.label20.TabIndex = 34;
            this.label20.Text = "Tip uredjaja:";
            // 
            // btn_podigni
            // 
            this.btn_podigni.Enabled = false;
            this.btn_podigni.Location = new System.Drawing.Point(16, 68);
            this.btn_podigni.Name = "btn_podigni";
            this.btn_podigni.Size = new System.Drawing.Size(107, 38);
            this.btn_podigni.TabIndex = 33;
            this.btn_podigni.Text = "Podigni Rampu";
            this.btn_podigni.UseVisualStyleBackColor = true;
            this.btn_podigni.Click += new System.EventHandler(this.btn_podigni_Click);
            // 
            // lab_citac_tagova
            // 
            this.lab_citac_tagova.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lab_citac_tagova.Location = new System.Drawing.Point(478, 109);
            this.lab_citac_tagova.Name = "lab_citac_tagova";
            this.lab_citac_tagova.Size = new System.Drawing.Size(109, 15);
            this.lab_citac_tagova.TabIndex = 32;
            this.lab_citac_tagova.Text = "stanje_tagova";
            // 
            // lab_semafor
            // 
            this.lab_semafor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lab_semafor.Location = new System.Drawing.Point(478, 80);
            this.lab_semafor.Name = "lab_semafor";
            this.lab_semafor.Size = new System.Drawing.Size(109, 15);
            this.lab_semafor.TabIndex = 31;
            this.lab_semafor.Text = "stanje_semafora";
            // 
            // lab_citac_tablica
            // 
            this.lab_citac_tablica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lab_citac_tablica.Location = new System.Drawing.Point(478, 53);
            this.lab_citac_tablica.Name = "lab_citac_tablica";
            this.lab_citac_tablica.Size = new System.Drawing.Size(109, 15);
            this.lab_citac_tablica.TabIndex = 30;
            this.lab_citac_tablica.Text = "stanje_tablica";
            this.lab_citac_tablica.Click += new System.EventHandler(this.lab_citac_tablica_Click);
            // 
            // lab_displej
            // 
            this.lab_displej.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lab_displej.Location = new System.Drawing.Point(478, 24);
            this.lab_displej.Name = "lab_displej";
            this.lab_displej.Size = new System.Drawing.Size(109, 15);
            this.lab_displej.TabIndex = 29;
            this.lab_displej.Text = "stanje_dispej";
            // 
            // btn_prijavi
            // 
            this.btn_prijavi.Location = new System.Drawing.Point(727, 68);
            this.btn_prijavi.Name = "btn_prijavi";
            this.btn_prijavi.Size = new System.Drawing.Size(75, 23);
            this.btn_prijavi.TabIndex = 28;
            this.btn_prijavi.Text = "Prijavi kvar";
            this.btn_prijavi.UseVisualStyleBackColor = true;
            this.btn_prijavi.Click += new System.EventHandler(this.btn_prijavi_Click);
            // 
            // cbx_uredjaj
            // 
            this.cbx_uredjaj.FormattingEnabled = true;
            this.cbx_uredjaj.Location = new System.Drawing.Point(681, 21);
            this.cbx_uredjaj.Name = "cbx_uredjaj";
            this.cbx_uredjaj.Size = new System.Drawing.Size(121, 23);
            this.cbx_uredjaj.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(397, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 15);
            this.label15.TabIndex = 25;
            this.label15.Text = "Semafor";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(396, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 15);
            this.label14.TabIndex = 24;
            this.label14.Text = "Čitač Tagova";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(397, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 15);
            this.label13.TabIndex = 23;
            this.label13.Text = "Čitač Tablica";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(397, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "Displej";
            // 
            // NaplatnoMestoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 640);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "NaplatnoMestoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Naplatno Mesto X";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NaplatnoMestoView_FormClosing);
            this.Load += new System.EventHandler(this.NaplatnoMestoView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ucitaj;
        private System.Windows.Forms.TextBox tbx_vreme;
        private System.Windows.Forms.TextBox tbx_mesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_kategorije;
        private System.Windows.Forms.Button btn_potvrdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_iznos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_uplata;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_povracaj;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lab_greska;
        private System.Windows.Forms.TextBox tbx_reg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lab_prekoracena;
        private System.Windows.Forms.TextBox tbx_prosek;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbx_rampa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_podigni;
        private System.Windows.Forms.Label lab_citac_tagova;
        private System.Windows.Forms.Label lab_semafor;
        private System.Windows.Forms.Label lab_citac_tablica;
        private System.Windows.Forms.Label lab_displej;
        private System.Windows.Forms.Button btn_prijavi;
        private System.Windows.Forms.ComboBox cbx_uredjaj;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lab_uspeh;
        private System.Windows.Forms.TextBox tbx_semafor;
        private System.Windows.Forms.Label label8;
    }
}