using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMateriel.Models
{
    class Combinaison : Materiel
    {
        public string tailleCombinaison { get; set; }

        public int GetCode()
        {
            return codeMateriel;
        }

        public string GetLibelle()
        {
            return libelleMateriel;
        }

        public string GetEtat()
        {
            return etatMateriel;
        }
    }
}
