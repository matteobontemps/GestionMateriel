using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionMateriel.DataAccess;
using GestionMateriel.Models;
using GestionMateriel.Forms;
using System.Runtime.InteropServices;

namespace GestionMateriel
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<MaterielPrete> stocks2 = DBInterface.GetMaterielPrete();

            // Afficher les données dans la console
            


            Application.Run(new FConnexion());
        }
    }
}
