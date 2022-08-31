
namespace SIMS_Projekat_Rampe.Views
{
    partial class IzvestajiView
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
            this.labelGreska = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonNazad = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TipVozila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VremeUlaska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UlaznaStanica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VremeNaplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IzlaznaStanica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.Vreme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IznosUplata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.labelGreska);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePickerDo);
            this.panel1.Controls.Add(this.dateTimePickerOd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(158, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 379);
            this.panel1.TabIndex = 0;
            // 
            // labelGreska
            // 
            this.labelGreska.AutoSize = true;
            this.labelGreska.ForeColor = System.Drawing.Color.Red;
            this.labelGreska.Location = new System.Drawing.Point(119, 356);
            this.labelGreska.Name = "labelGreska";
            this.labelGreska.Size = new System.Drawing.Size(42, 15);
            this.labelGreska.TabIndex = 7;
            this.labelGreska.Text = "Greska";
            this.labelGreska.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(105, 295);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 19);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Jedan dan";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Do";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Od";
            // 
            // dateTimePickerDo
            // 
            this.dateTimePickerDo.Location = new System.Drawing.Point(66, 226);
            this.dateTimePickerDo.Name = "dateTimePickerDo";
            this.dateTimePickerDo.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerDo.TabIndex = 3;
            this.dateTimePickerDo.ValueChanged += new System.EventHandler(this.dateTimePickerDo_ValueChanged);
            // 
            // dateTimePickerOd
            // 
            this.dateTimePickerOd.Location = new System.Drawing.Point(66, 150);
            this.dateTimePickerOd.Name = "dateTimePickerOd";
            this.dateTimePickerOd.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerOd.TabIndex = 2;
            this.dateTimePickerOd.ValueChanged += new System.EventHandler(this.dateTimePickerOd_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stanica";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(66, 83);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.buttonNazad);
            this.panel2.Location = new System.Drawing.Point(158, 467);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 47);
            this.panel2.TabIndex = 1;
            // 
            // buttonNazad
            // 
            this.buttonNazad.Location = new System.Drawing.Point(66, 0);
            this.buttonNazad.Name = "buttonNazad";
            this.buttonNazad.Size = new System.Drawing.Size(157, 47);
            this.buttonNazad.TabIndex = 0;
            this.buttonNazad.Text = "Nazad";
            this.buttonNazad.UseVisualStyleBackColor = true;
            this.buttonNazad.Click += new System.EventHandler(this.buttonNazad_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(516, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(706, 561);
            this.panel3.TabIndex = 2;
            this.panel3.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ukupno: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Prihodi od uplate ENP: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Prihodi od prolazaka: ";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vreme,
            this.IznosUplata});
            this.dataGridView2.Location = new System.Drawing.Point(25, 285);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(369, 227);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipVozila,
            this.VremeUlaska,
            this.UlaznaStanica,
            this.VremeNaplate,
            this.IzlaznaStanica,
            this.Iznos});
            this.dataGridView1.Location = new System.Drawing.Point(25, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(665, 227);
            this.dataGridView1.TabIndex = 0;
            // 
            // TipVozila
            // 
            this.TipVozila.HeaderText = "Tip Vozila";
            this.TipVozila.Name = "TipVozila";
            this.TipVozila.ReadOnly = true;
            // 
            // VremeUlaska
            // 
            this.VremeUlaska.HeaderText = "Vreme Ulaska";
            this.VremeUlaska.Name = "VremeUlaska";
            this.VremeUlaska.ReadOnly = true;
            // 
            // UlaznaStanica
            // 
            this.UlaznaStanica.HeaderText = "Ulazna Stanica";
            this.UlaznaStanica.Name = "UlaznaStanica";
            this.UlaznaStanica.ReadOnly = true;
            // 
            // VremeNaplate
            // 
            this.VremeNaplate.HeaderText = "Vreme Naplate";
            this.VremeNaplate.Name = "VremeNaplate";
            this.VremeNaplate.ReadOnly = true;
            // 
            // IzlaznaStanica
            // 
            this.IzlaznaStanica.HeaderText = "Izlazna Stanica";
            this.IzlaznaStanica.Name = "IzlaznaStanica";
            this.IzlaznaStanica.ReadOnly = true;
            // 
            // Iznos
            // 
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(70, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 28);
            this.label7.TabIndex = 8;
            this.label7.Text = "Pregled prihoda";
            // 
            // Vreme
            // 
            this.Vreme.HeaderText = "Vreme Uplate";
            this.Vreme.Name = "Vreme";
            this.Vreme.ReadOnly = true;
            this.Vreme.Width = 200;
            // 
            // IznosUplata
            // 
            this.IznosUplata.HeaderText = "Iznos";
            this.IznosUplata.Name = "IznosUplata";
            this.IznosUplata.ReadOnly = true;
            // 
            // IzvestajiView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 585);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "IzvestajiView";
            this.Text = "IzvestajiView";
            this.Load += new System.EventHandler(this.IzvestajiView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDo;
        private System.Windows.Forms.DateTimePicker dateTimePickerOd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonNazad;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label labelGreska;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipVozila;
        private System.Windows.Forms.DataGridViewTextBoxColumn VremeUlaska;
        private System.Windows.Forms.DataGridViewTextBoxColumn UlaznaStanica;
        private System.Windows.Forms.DataGridViewTextBoxColumn VremeNaplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IzlaznaStanica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vreme;
        private System.Windows.Forms.DataGridViewTextBoxColumn IznosUplata;
        private System.Windows.Forms.Label label7;
    }
}