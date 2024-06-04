using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionMateriel.DataAccess;
using GestionMateriel.Models;

namespace GestionMateriel.Forms
{
    public partial class FSupprPret : Form
    {
        public FSupprPret()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PretDetail> prets = DBInterface.GetPretDetail();

            if (prets != null)
            {
                foreach (PretDetail pret in prets)
                {
                    string[] row = {
                        pret.codePret.ToString(),
                        pret.numNageur.ToString(),
                        pret.codeMateriel.ToString(),
                        pret.libelle,
                        pret.dateDebutPret.ToString(),
                        pret.dateFinPret.ToString(),
                        pret.etatMateriel
                    };

                    ListViewItem listviewitem = new ListViewItem(row);

                    listView1.Items.Add(listviewitem);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CodePret = int.Parse(this.textBox1.Text);

            try
            {
                DBInterface.SupprPret(CodePret);

                MessageBox.Show("Suppression effectuée !");
                this.textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur");
            }
        }
    }
}
