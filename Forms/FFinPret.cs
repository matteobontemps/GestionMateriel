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
    public partial class FFinPret : Form
    {
        public FFinPret()
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

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Nageur> nageurs = DBInterface.GetNageurs();

            if (nageurs != null)
            {
                foreach (Nageur nageur in nageurs)
                {
                    string[] row = {
                        nageur.numNageur.ToString(),
                        nageur.nomNageur,
                        nageur.prenomNageur,
                        nageur.telNageur,
                        nageur.mailNageur
                    };

                    ListViewItem listviewitem = new ListViewItem(row);

                    listView2.Items.Add(listviewitem);
                }
            }
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MaterielPrete> materielPrete = DBInterface.GetMaterielLibre();

            if (materielPrete != null)
            {
                foreach (MaterielPrete materiel in materielPrete)
                {
                    string[] row = {
                        materiel.codeMateriel.ToString(),
                        materiel.marqueMateriel,
                        materiel.libelleMateriel,
                        materiel.etatMateriel,
                        materiel.tailleCombinaison,
                        materiel.pointureMonopalme.ToString()
                    };

                    ListViewItem listviewitem = new ListViewItem(row);

                    listView4.Items.Add(listviewitem);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int NumNageur = int.Parse(this.textBox1.Text);
            int CodeMateriel = int.Parse(this.textBox5.Text);
            DateTime DateDebutPret = this.dateTimePicker1.Value;
            DateTime DateFinPret = this.dateTimePicker2.Value;
            string Etat = this.textBox2.Text;

            try
            {
                DBInterface.AjoutPret(NumNageur, CodeMateriel, DateDebutPret, DateFinPret, Etat);

                MessageBox.Show("Ajout réussi !");
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.dateTimePicker1.Value = DateTime.Now;
                this.dateTimePicker2.Value = DateTime.Now;
                this.textBox5.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
