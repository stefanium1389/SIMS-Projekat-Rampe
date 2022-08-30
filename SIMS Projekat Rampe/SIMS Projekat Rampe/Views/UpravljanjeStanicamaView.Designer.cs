
namespace SIMS_Projekat_Rampe.Views
{
    partial class UpravljanjeStanicamaView
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
            this.lab_log = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_obrisi = new System.Windows.Forms.Button();
            this.btn_izmeni = new System.Windows.Forms.Button();
            this.btn_kreiraj = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.table_cene = new System.Windows.Forms.DataGridView();
            this.table_povezane = new System.Windows.Forms.DataGridView();
            this.table_zaposleni = new System.Windows.Forms.DataGridView();
            this.table_opsti = new System.Windows.Forms.DataGridView();
            this.cbx_stanice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_cene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_povezane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_zaposleni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_opsti)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_log
            // 
            this.lab_log.AutoSize = true;
            this.lab_log.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lab_log.Location = new System.Drawing.Point(25, 25);
            this.lab_log.Name = "lab_log";
            this.lab_log.Size = new System.Drawing.Size(220, 25);
            this.lab_log.TabIndex = 0;
            this.lab_log.Text = "Ulogovani ste kao admin";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_obrisi);
            this.panel1.Controls.Add(this.btn_izmeni);
            this.panel1.Controls.Add(this.btn_kreiraj);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.table_cene);
            this.panel1.Controls.Add(this.table_povezane);
            this.panel1.Controls.Add(this.table_zaposleni);
            this.panel1.Controls.Add(this.table_opsti);
            this.panel1.Controls.Add(this.cbx_stanice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lab_log);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 609);
            this.panel1.TabIndex = 1;
            // 
            // btn_obrisi
            // 
            this.btn_obrisi.Location = new System.Drawing.Point(119, 547);
            this.btn_obrisi.Name = "btn_obrisi";
            this.btn_obrisi.Size = new System.Drawing.Size(75, 33);
            this.btn_obrisi.TabIndex = 13;
            this.btn_obrisi.Text = "Obriši";
            this.btn_obrisi.UseVisualStyleBackColor = true;
            // 
            // btn_izmeni
            // 
            this.btn_izmeni.Location = new System.Drawing.Point(25, 547);
            this.btn_izmeni.Name = "btn_izmeni";
            this.btn_izmeni.Size = new System.Drawing.Size(75, 33);
            this.btn_izmeni.TabIndex = 12;
            this.btn_izmeni.Text = "Izmeni";
            this.btn_izmeni.UseVisualStyleBackColor = true;
            // 
            // btn_kreiraj
            // 
            this.btn_kreiraj.Location = new System.Drawing.Point(214, 547);
            this.btn_kreiraj.Name = "btn_kreiraj";
            this.btn_kreiraj.Size = new System.Drawing.Size(97, 33);
            this.btn_kreiraj.TabIndex = 11;
            this.btn_kreiraj.Text = "Kreiraj novu";
            this.btn_kreiraj.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cene";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Povezane stanice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Zaposleni";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Opšti podaci";
            // 
            // table_cene
            // 
            this.table_cene.AllowUserToAddRows = false;
            this.table_cene.AllowUserToDeleteRows = false;
            this.table_cene.AllowUserToOrderColumns = true;
            this.table_cene.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_cene.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_cene.Location = new System.Drawing.Point(315, 345);
            this.table_cene.Name = "table_cene";
            this.table_cene.ReadOnly = true;
            this.table_cene.RowTemplate.Height = 25;
            this.table_cene.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_cene.Size = new System.Drawing.Size(271, 170);
            this.table_cene.TabIndex = 6;
            // 
            // table_povezane
            // 
            this.table_povezane.AllowUserToAddRows = false;
            this.table_povezane.AllowUserToDeleteRows = false;
            this.table_povezane.AllowUserToOrderColumns = true;
            this.table_povezane.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_povezane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_povezane.Location = new System.Drawing.Point(25, 345);
            this.table_povezane.Name = "table_povezane";
            this.table_povezane.ReadOnly = true;
            this.table_povezane.RowTemplate.Height = 25;
            this.table_povezane.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_povezane.Size = new System.Drawing.Size(240, 170);
            this.table_povezane.TabIndex = 5;
            this.table_povezane.SelectionChanged += new System.EventHandler(this.table_povezane_SelectionChanged);
            // 
            // table_zaposleni
            // 
            this.table_zaposleni.AllowUserToAddRows = false;
            this.table_zaposleni.AllowUserToDeleteRows = false;
            this.table_zaposleni.AllowUserToOrderColumns = true;
            this.table_zaposleni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_zaposleni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_zaposleni.Location = new System.Drawing.Point(315, 134);
            this.table_zaposleni.Name = "table_zaposleni";
            this.table_zaposleni.ReadOnly = true;
            this.table_zaposleni.RowTemplate.Height = 25;
            this.table_zaposleni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_zaposleni.Size = new System.Drawing.Size(271, 170);
            this.table_zaposleni.TabIndex = 4;
            // 
            // table_opsti
            // 
            this.table_opsti.AllowUserToAddRows = false;
            this.table_opsti.AllowUserToDeleteRows = false;
            this.table_opsti.AllowUserToOrderColumns = true;
            this.table_opsti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_opsti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_opsti.Location = new System.Drawing.Point(25, 134);
            this.table_opsti.Name = "table_opsti";
            this.table_opsti.ReadOnly = true;
            this.table_opsti.RowTemplate.Height = 25;
            this.table_opsti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_opsti.Size = new System.Drawing.Size(240, 170);
            this.table_opsti.TabIndex = 3;
            // 
            // cbx_stanice
            // 
            this.cbx_stanice.FormattingEnabled = true;
            this.cbx_stanice.Location = new System.Drawing.Point(92, 67);
            this.cbx_stanice.Name = "cbx_stanice";
            this.cbx_stanice.Size = new System.Drawing.Size(121, 23);
            this.cbx_stanice.TabIndex = 2;
            this.cbx_stanice.SelectedIndexChanged += new System.EventHandler(this.cbx_stanice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stanica:";
            // 
            // UpravljanjeStanicamaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 633);
            this.Controls.Add(this.panel1);
            this.Name = "UpravljanjeStanicamaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upravljanje stanicama";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpravljanjeStanicamaView_FormClosing);
            this.Load += new System.EventHandler(this.UpravljanjeStanicamaView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_cene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_povezane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_zaposleni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_opsti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lab_log;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView table_zaposleni;
        private System.Windows.Forms.DataGridView table_opsti;
        private System.Windows.Forms.ComboBox cbx_stanice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_obrisi;
        private System.Windows.Forms.Button btn_izmeni;
        private System.Windows.Forms.Button btn_kreiraj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView table_cene;
        private System.Windows.Forms.DataGridView table_povezane;
    }
}