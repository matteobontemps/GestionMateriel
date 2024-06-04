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
    public partial class FAjoutStock : Form
    {
        public FAjoutStock()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MaterielPrete> stock = DBInterface.GetMaterielLibre();

            if (stock != null)
            {
                foreach (MaterielPrete materiel in stock)
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

                    listView1.Items.Add(listviewitem);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Marque = this.textBox1.Text;
            string Libelle = this.textBox2.Text;
            string Etat = this.textBox3.Text;
            string Taille = this.textBox4.Text;

            if (Libelle == "combinaison")
            {
                try
                {
                    DBInterface.AjoutMateriel(Marque, Libelle, Etat, Taille, null);

                    MessageBox.Show("Ajout réussi !");
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur");
                }
            }
            else if (Libelle != "monopalme")
            {
                try
                {
                    DBInterface.AjoutMateriel(Marque, Libelle, Etat, null, null);

                    MessageBox.Show("Ajout réussi !");
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur");
                }
            }
            else
            {
                int Pointure = int.Parse(this.textBox5.Text);

                try
                {
                    DBInterface.AjoutMateriel(Marque, Libelle, Etat, Taille, Pointure);

                    MessageBox.Show("Ajout réussi !");
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur");
                }
            }
        }
    }
}
