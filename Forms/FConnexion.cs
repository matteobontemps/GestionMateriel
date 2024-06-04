using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionMateriel.Forms
{
    public partial class FConnexion : Form
    {
        public FConnexion()
        {
            InitializeComponent();
        }

        private void FConnexion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = "respmat";
            string password = "C1Secret!";
            string id = this.textBox1.Text;
            string mdp = this.textBox2.Text;

            if (login == id && password == mdp)
            {
                FPret fPret = new FPret();
                fPret.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect !");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
