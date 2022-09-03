
namespace SIMS_Projekat_Rampe.Views
{
    partial class CUStaniceView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_odustani = new System.Windows.Forms.Button();
            this.btn_dodaj_zaposlenog = new System.Windows.Forms.Button();
            this.btn_sacuvaj = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.table_deonice = new System.Windows.Forms.DataGridView();
            this.table_cene = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.lab_greska = new System.Windows.Forms.Label();
            this.btn_ukloni_zaposlenog = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.table_zaposleni = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_tip = new System.Windows.Forms.ComboBox();
            this.lbx_zaposleni = new System.Windows.Forms.ListBox();
            this.tbx_naziv = new System.Windows.Forms.TextBox();
            this.tbx_elektronskih = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_obicnih = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_deonice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_cene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_zaposleni)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_odustani);
            this.panel1.Controls.Add(this.btn_dodaj_zaposlenog);
            this.panel1.Controls.Add(this.btn_sacuvaj);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.table_deonice);
            this.panel1.Controls.Add(this.table_cene);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lab_greska);
            this.panel1.Controls.Add(this.btn_ukloni_zaposlenog);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.table_zaposleni);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbx_tip);
            this.panel1.Controls.Add(this.lbx_zaposleni);
            this.panel1.Controls.Add(this.tbx_naziv);
            this.panel1.Controls.Add(this.tbx_elektronskih);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbx_obicnih);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 599);
            this.panel1.TabIndex = 0;
            // 
            // btn_odustani
            // 
            this.btn_odustani.Location = new System.Drawing.Point(13, 548);
            this.btn_odustani.Name = "btn_odustani";
            this.btn_odustani.Size = new System.Drawing.Size(75, 35);
            this.btn_odustani.TabIndex = 25;
            this.btn_odustani.Text = "Odustani";
            this.btn_odustani.UseVisualStyleBackColor = true;
            this.btn_odustani.Click += new System.EventHandler(this.btn_odustani_Click);
            // 
            // btn_dodaj_zaposlenog
            // 
            this.btn_dodaj_zaposlenog.Location = new System.Drawing.Point(198, 497);
            this.btn_dodaj_zaposlenog.Name = "btn_dodaj_zaposlenog";
            this.btn_dodaj_zaposlenog.Size = new System.Drawing.Size(75, 23);
            this.btn_dodaj_zaposlenog.TabIndex = 24;
            this.btn_dodaj_zaposlenog.Text = "Dodaj";
            this.btn_dodaj_zaposlenog.UseVisualStyleBackColor = true;
            this.btn_dodaj_zaposlenog.Click += new System.EventHandler(this.btn_dodaj_zaposlenog_Click);
            // 
            // btn_sacuvaj
            // 
            this.btn_sacuvaj.Location = new System.Drawing.Point(832, 548);
            this.btn_sacuvaj.Name = "btn_sacuvaj";
            this.btn_sacuvaj.Size = new System.Drawing.Size(88, 35);
            this.btn_sacuvaj.TabIndex = 23;
            this.btn_sacuvaj.Text = "Sačuvaj";
            this.btn_sacuvaj.UseVisualStyleBackColor = true;
            this.btn_sacuvaj.Click += new System.EventHandler(this.btn_sacuvaj_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(631, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Povezane stanice:";
            // 
            // table_deonice
            // 
            this.table_deonice.AllowUserToAddRows = false;
            this.table_deonice.AllowUserToDeleteRows = false;
            this.table_deonice.AllowUserToOrderColumns = true;
            this.table_deonice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_deonice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_deonice.Location = new System.Drawing.Point(631, 36);
            this.table_deonice.Name = "table_deonice";
            this.table_deonice.RowTemplate.Height = 25;
            this.table_deonice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_deonice.Size = new System.Drawing.Size(289, 185);
            this.table_deonice.TabIndex = 20;
            this.table_deonice.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.table_deonice_CellBeginEdit);
            this.table_deonice.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_deonice_CellEndEdit);
            this.table_deonice.SelectionChanged += new System.EventHandler(this.table_deonice_SelectionChanged);
            // 
            // table_cene
            // 
            this.table_cene.AllowUserToAddRows = false;
            this.table_cene.AllowUserToDeleteRows = false;
            this.table_cene.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_cene.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_cene.Location = new System.Drawing.Point(631, 263);
            this.table_cene.Name = "table_cene";
            this.table_cene.RowTemplate.Height = 25;
            this.table_cene.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.table_cene.Size = new System.Drawing.Size(289, 214);
            this.table_cene.TabIndex = 19;
            this.table_cene.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.table_cene_CellBeginEdit);
            this.table_cene.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_cene_CellEndEdit);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(631, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Cene:";
            // 
            // lab_greska
            // 
            this.lab_greska.AutoSize = true;
            this.lab_greska.ForeColor = System.Drawing.Color.Red;
            this.lab_greska.Location = new System.Drawing.Point(111, 568);
            this.lab_greska.Name = "lab_greska";
            this.lab_greska.Size = new System.Drawing.Size(41, 15);
            this.lab_greska.TabIndex = 12;
            this.lab_greska.Text = "greska";
            this.lab_greska.Visible = false;
            // 
            // btn_ukloni_zaposlenog
            // 
            this.btn_ukloni_zaposlenog.Location = new System.Drawing.Point(528, 497);
            this.btn_ukloni_zaposlenog.Name = "btn_ukloni_zaposlenog";
            this.btn_ukloni_zaposlenog.Size = new System.Drawing.Size(75, 23);
            this.btn_ukloni_zaposlenog.TabIndex = 11;
            this.btn_ukloni_zaposlenog.Text = "Ukloni";
            this.btn_ukloni_zaposlenog.UseVisualStyleBackColor = true;
            this.btn_ukloni_zaposlenog.Click += new System.EventHandler(this.btn_ukloni_zaposlenog_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Zaposleni na stanici:";
            // 
            // table_zaposleni
            // 
            this.table_zaposleni.AllowUserToAddRows = false;
            this.table_zaposleni.AllowUserToDeleteRows = false;
            this.table_zaposleni.AllowUserToOrderColumns = true;
            this.table_zaposleni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_zaposleni.Location = new System.Drawing.Point(293, 263);
            this.table_zaposleni.Name = "table_zaposleni";
            this.table_zaposleni.ReadOnly = true;
            this.table_zaposleni.RowTemplate.Height = 25;
            this.table_zaposleni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_zaposleni.Size = new System.Drawing.Size(310, 214);
            this.table_zaposleni.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tip radnika:";
            // 
            // cbx_tip
            // 
            this.cbx_tip.FormattingEnabled = true;
            this.cbx_tip.Location = new System.Drawing.Point(100, 151);
            this.cbx_tip.Name = "cbx_tip";
            this.cbx_tip.Size = new System.Drawing.Size(121, 23);
            this.cbx_tip.TabIndex = 7;
            this.cbx_tip.SelectedIndexChanged += new System.EventHandler(this.cbx_tip_SelectedIndexChanged);
            // 
            // lbx_zaposleni
            // 
            this.lbx_zaposleni.FormattingEnabled = true;
            this.lbx_zaposleni.ItemHeight = 15;
            this.lbx_zaposleni.Location = new System.Drawing.Point(13, 263);
            this.lbx_zaposleni.Name = "lbx_zaposleni";
            this.lbx_zaposleni.Size = new System.Drawing.Size(260, 214);
            this.lbx_zaposleni.TabIndex = 6;
            // 
            // tbx_naziv
            // 
            this.tbx_naziv.Location = new System.Drawing.Point(209, 18);
            this.tbx_naziv.Name = "tbx_naziv";
            this.tbx_naziv.Size = new System.Drawing.Size(100, 23);
            this.tbx_naziv.TabIndex = 5;
            // 
            // tbx_elektronskih
            // 
            this.tbx_elektronskih.Location = new System.Drawing.Point(209, 95);
            this.tbx_elektronskih.Name = "tbx_elektronskih";
            this.tbx_elektronskih.Size = new System.Drawing.Size(100, 23);
            this.tbx_elektronskih.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Broj elektroskih naplatnih mesta:";
            // 
            // tbx_obicnih
            // 
            this.tbx_obicnih.Location = new System.Drawing.Point(209, 57);
            this.tbx_obicnih.Name = "tbx_obicnih";
            this.tbx_obicnih.Size = new System.Drawing.Size(100, 23);
            this.tbx_obicnih.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Broj običnih naplatnih mesta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv stanice:";
            // 
            // CUStaniceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 624);
            this.Controls.Add(this.panel1);
            this.Name = "CUStaniceView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kreiranje i izmena stanice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CUStaniceView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_deonice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_cene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_zaposleni)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView table_deonice;
        private System.Windows.Forms.DataGridView table_cene;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lab_greska;
        private System.Windows.Forms.Button btn_ukloni_zaposlenog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView table_zaposleni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_tip;
        private System.Windows.Forms.ListBox lbx_zaposleni;
        private System.Windows.Forms.TextBox tbx_naziv;
        private System.Windows.Forms.TextBox tbx_elektronskih;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_obicnih;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_sacuvaj;
        private System.Windows.Forms.Button btn_dodaj_zaposlenog;
        private System.Windows.Forms.Button btn_odustani;
    }
}