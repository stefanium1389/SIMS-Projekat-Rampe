﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIMS_Projekat_Rampe.Controlers;


namespace SIMS_Projekat_Rampe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KorisnikController.CheckLogin(textBox1.Text, textBox2.Text) == true)
            {
                button1.Text = "xdddd";
                
            }
            else button1.Text = "yuluz";
            {
               
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
