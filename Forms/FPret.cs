using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionMateriel.Models;
using GestionMateriel.DataAccess;

namespace GestionMateriel.Forms
{
    public partial class FPret : Form
    {
        public FPret()
        {
            InitializeComponent();

        }

        private void LVPret_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FFinPret fFinPret = new FFinPret();
            fFinPret.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FSupprPret fSupprPret = new FSupprPret();
            fSupprPret.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FAjoutStock fAjoutStock = new FAjoutStock();
            fAjoutStock.Show();
        }
    }
}
