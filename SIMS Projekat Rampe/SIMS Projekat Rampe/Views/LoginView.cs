using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIMS_Projekat_Rampe.Controlers;
using SIMS_Projekat_Rampe.Models;
using SIMS_Projekat_Rampe.Views;


namespace SIMS_Projekat_Rampe
{
    public partial class LoginView : Form
    {
        
        private LoginController loginController;
        public LoginView()
        {
            InitializeComponent();
            loginController = new LoginController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label_error.Visible = false;
            Korisnik ulogovani;
            
            try
            {
                loginController.ProveriSpam(textBox1.Text);
                ulogovani = loginController.CheckLogin(textBox1.Text, textBox2.Text);
                if (ulogovani.Tip == TipKorisnika.Radnik) 
                {
                    OdabirMestaView odabir = new OdabirMestaView(ulogovani, this);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    odabir.Show();
                    this.Visible = false;
                }
                if (ulogovani.Tip == TipKorisnika.Menadzer)
                {
                    MenadzerMeniView menadzer = new MenadzerMeniView(this, ulogovani);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    menadzer.Show();
                    this.Visible = false;
                }
                if (ulogovani.Tip == TipKorisnika.SefStanice)
                {
                    NaplatnaStanicaView nsv = new NaplatnaStanicaView(this, ulogovani);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    nsv.Show();
                    this.Visible = false;
                }

            }
            catch (LoginException exp)
            {
                label_error.Text = exp.Message;
                label_error.Visible = true;
                
            }
        }

        private void LoginView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
