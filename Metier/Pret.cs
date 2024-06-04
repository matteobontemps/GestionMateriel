using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMateriel.Metier
{
    class Pret
    {
        //MDM - Initialisation des variables
        private string _code_pret;
        private Nageur _num_nageur;
        private Materiel _num_materiel;
        private DateTime _datedebut_pret;
        private DateTime _datefin_pret;
        private string _etat_materiel;

        //MDM - Constructeur Pret
        public Pret(string code_pret, Nageur num_nageur, Materiel num_materiel, DateTime datedebut_pret, DateTime datefin_pret, string etat_materiel)
        {
            _code_pret = code_pret;
            _num_nageur = num_nageur;
            _num_materiel = num_materiel;
            _datedebut_pret = datedebut_pret;
            _datefin_pret = datefin_pret;
            _etat_materiel = etat_materiel;
        }

        //MDM - GET SET
        public string Code_pret { get => _code_pret; set => _code_pret = value; }
        public Nageur Num_nageur { get => _num_nageur; set => _num_nageur = value; }
        public DateTime Datedebut_pret { get => _datedebut_pret; set => _datedebut_pret = value; }
        public DateTime Datefin_pret { get => _datefin_pret; set => _datefin_pret = value; }
        public string Etat_materiel { get => _etat_materiel; set => _etat_materiel = value; }
        internal Materiel Num_materiel { get => _num_materiel; set => _num_materiel = value; }
    }
}
