using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMateriel.Models
{
    class Pret
    {
        public int codePret { get; set; }
        public int numNageur { get; set; }
        public int codeMateriel { get; set; }
        public DateTime dateDebutPret { get; set; }
        public DateTime? dateFinPret { get; set; }
        public string etatMateriel { get; set; }
    }
}
