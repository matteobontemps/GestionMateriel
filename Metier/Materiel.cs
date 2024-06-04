using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMateriel.Metier
{
    class Materiel
    {
        //MDM - Initialisation des variables
        private string _code_materiel;
        private string _marque_materiel;
        private string _libelle_materiel;
        private string _etat_materiel;

        //MDM - Constructeur Materiel
        public Materiel(string code_materiel, string marque_materiel, string libelle_materiel, string etat_materiel)
        {
            _code_materiel = code_materiel;
            _marque_materiel = marque_materiel;
            _libelle_materiel = libelle_materiel;
            _etat_materiel = etat_materiel;
        }

        //MDM - GET / SET
        public string Code_materiel { get => _code_materiel; set => _code_materiel = value; }
        public string Marque_materiel { get => _marque_materiel; set => _marque_materiel = value; }
        public string Libelle_materiel { get => _libelle_materiel; set => _libelle_materiel = value; }
        public string Etat_materiel { get => _etat_materiel; set => _etat_materiel = value; }
    }
}
