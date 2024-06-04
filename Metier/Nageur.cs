using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMateriel.Metier
{
    public class Nageur
    {
        //MDM - Initialisation des variables
        private string _num_nageur; 
        private string _nom_nageur;
        private string _prenom_nageur;
        private string _tel_nageur;
        private string _mail_nageur;

        //MDM - GET / SET
        public string Num_nageur { get => _num_nageur; set => _num_nageur = value; }
        public string Nom_nageur { get => _nom_nageur; set => _nom_nageur = value; }
        public string Prenom_nageur { get => _prenom_nageur; set => _prenom_nageur = value; }
        public string Tel_nageur { get => _tel_nageur; set => _tel_nageur = value; }
        public string Mail_nageur { get => _mail_nageur; set => _mail_nageur = value; }

        //MDM - Constructeur du Nageur
        #region Constructeur
        public Nageur (string num_nageur, string nom_nageur, string prenom_nageur, string tel_nageur, string mail_nageur)
        {
            _num_nageur = num_nageur;
            _nom_nageur = nom_nageur;
            _prenom_nageur = prenom_nageur;
            _tel_nageur = tel_nageur;
            _mail_nageur = mail_nageur;
        }
        #endregion

    }
}
