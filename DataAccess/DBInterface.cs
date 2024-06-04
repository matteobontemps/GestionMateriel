using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using GestionMateriel.Tools;
using GestionMateriel.Models;


namespace GestionMateriel.DataAccess
{
    class DBInterface
    {
        public static void AjoutMateriel(string marque, string libelle, string etat, string taille, int? pointure)
        {
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("LP_pAjoutStock", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Ajouter les paramètres à la procédure stockée
                    sqlCommand.Parameters.AddWithValue("@pMarque", marque);
                    sqlCommand.Parameters.AddWithValue("@pLibelle", libelle);
                    sqlCommand.Parameters.AddWithValue("@pEtat", etat);

                    if (taille != null)
                    {
                        sqlCommand.Parameters.AddWithValue("@pTaille", taille);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@pTaille", DBNull.Value);
                    }

                    if (pointure != 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@pPointure", pointure);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@pPointure", DBNull.Value);
                    }

                    // Exécuter la procédure stockée
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
        }


        public static void PreterMateriel(int numnageur, int codemateriel, DateTime datedebutpret, string etat)
        {
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("LP_pPretMateriel", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Ajouter les paramètres à la procédure stockée
                    sqlCommand.Parameters.AddWithValue("@pNumNageur", numnageur);
                    sqlCommand.Parameters.AddWithValue("@pCodeMateriel", codemateriel);
                    sqlCommand.Parameters.AddWithValue("@pDateDebutPret", datedebutpret);
                    sqlCommand.Parameters.AddWithValue("@pEtat", etat);

                    // Exécuter la procédure stockée
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
        }

        public static List<MaterielPrete> GetMaterielPrete()
        {
            List<MaterielPrete> materielsPretes = new List<MaterielPrete>();
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("LP_pListerMaterielPrete", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            
                            if (!sqlDataReader.IsDBNull(4))
                            {
                                MaterielPrete materiel = new MaterielPrete();
                                materiel.codeMateriel = sqlDataReader.GetInt32(0);
                                materiel.marqueMateriel = sqlDataReader.GetString(1);
                                materiel.libelleMateriel = sqlDataReader.GetString(2);
                                materiel.etatMateriel = sqlDataReader.GetString(3);
                                materiel.tailleCombinaison = sqlDataReader.GetString(4);
                                materielsPretes.Add(materiel);
                            }
                            else if (!sqlDataReader.IsDBNull(5))
                            {
                                MaterielPrete materiel = new MaterielPrete();
                                materiel.codeMateriel = sqlDataReader.GetInt32(0);
                                materiel.marqueMateriel = sqlDataReader.GetString(1);
                                materiel.libelleMateriel = sqlDataReader.GetString(2);
                                materiel.etatMateriel = sqlDataReader.GetString(3);
                                materiel.pointureMonopalme = sqlDataReader.GetInt32(5);
                                materielsPretes.Add(materiel);
                            }
                            else
                            {
                                MaterielPrete materiel = new MaterielPrete();
                                materiel.codeMateriel = sqlDataReader.GetInt32(0);
                                materiel.marqueMateriel = sqlDataReader.GetString(1);
                                materiel.libelleMateriel = sqlDataReader.GetString(2);
                                materiel.etatMateriel = sqlDataReader.GetString(3);
                                materiel.pointureMonopalme = null;
                                materielsPretes.Add(materiel);
                            }
                            
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return materielsPretes;
        }

        public static List<MaterielPrete> GetMaterielLibre()
        {
            List<MaterielPrete> materielsLibres = new List<MaterielPrete>();
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("LP_pVisualiserStock", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {

                            if (!sqlDataReader.IsDBNull(4))
                            {
                                MaterielPrete materiel = new MaterielPrete();
                                materiel.codeMateriel = sqlDataReader.GetInt32(0);
                                materiel.marqueMateriel = sqlDataReader.GetString(1);
                                materiel.libelleMateriel = sqlDataReader.GetString(2);
                                materiel.etatMateriel = sqlDataReader.GetString(3);
                                materiel.tailleCombinaison = sqlDataReader.GetString(4);
                                materielsLibres.Add(materiel);
                            }
                            else if (!sqlDataReader.IsDBNull(5))
                            {
                                MaterielPrete materiel = new MaterielPrete();
                                materiel.codeMateriel = sqlDataReader.GetInt32(0);
                                materiel.marqueMateriel = sqlDataReader.GetString(1);
                                materiel.libelleMateriel = sqlDataReader.GetString(2);
                                materiel.etatMateriel = sqlDataReader.GetString(3);
                                materiel.pointureMonopalme = sqlDataReader.GetInt32(5);
                                materielsLibres.Add(materiel);
                            }
                            else
                            {
                                MaterielPrete materiel = new MaterielPrete();
                                materiel.codeMateriel = sqlDataReader.GetInt32(0);
                                materiel.marqueMateriel = sqlDataReader.GetString(1);
                                materiel.libelleMateriel = sqlDataReader.GetString(2);
                                materiel.etatMateriel = sqlDataReader.GetString(3);
                                materiel.pointureMonopalme = null;
                                materielsLibres.Add(materiel);
                            }

                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return materielsLibres;
        }

        public static List<PretDetail> GetPretDetail()
        {
            List<PretDetail> prets = new List<PretDetail>();
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("LP_pAfficherPrets", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {

                            PretDetail pret = new PretDetail();
                            pret.codePret = sqlDataReader.GetInt32(0);
                            pret.numNageur = sqlDataReader.GetInt32(1);
                            pret.codeMateriel = sqlDataReader.GetInt32(2);
                            pret.libelle = sqlDataReader.GetString(3);
                            pret.dateDebutPret = sqlDataReader.GetDateTime(4);
                            pret.dateFinPret = sqlDataReader.GetDateTime(5);
                            pret.etatMateriel = sqlDataReader.GetString(6);
                            prets.Add(pret);

                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return prets;
        }

        public static List<Nageur> GetNageurs()
        {
            List<Nageur> nageurs = new List<Nageur>();
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("LP_pAfficherNageurs", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {

                            Nageur nageur = new Nageur();
                            nageur.numNageur = sqlDataReader.GetInt32(0);
                            nageur.nomNageur = sqlDataReader.GetString(1);
                            nageur.prenomNageur = sqlDataReader.GetString(2);
                            nageur.telNageur = sqlDataReader.GetString(3);
                            nageur.mailNageur = sqlDataReader.GetString(4);
                            nageurs.Add(nageur);

                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return nageurs;
        }

        public static void AjoutPret(int numNageur, int codeMateriel, DateTime dateDebutPret, DateTime dateFinPret, string etat)
        {
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("LP_pPretMateriel", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Ajouter les paramètres à la procédure stockée
                    sqlCommand.Parameters.AddWithValue("@pNumNageur", numNageur);
                    sqlCommand.Parameters.AddWithValue("@pCodeMateriel", codeMateriel);
                    sqlCommand.Parameters.AddWithValue("@pDateDebutPret", dateDebutPret);
                    sqlCommand.Parameters.AddWithValue("@pDateFinPret", dateFinPret);
                    sqlCommand.Parameters.AddWithValue("@pEtat", etat);

                    // Exécuter la procédure stockée
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
        }

        public static void SupprPret(int codePret)
        {
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("LP_pSupprPret", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Ajouter les paramètres à la procédure stockée
                    sqlCommand.Parameters.AddWithValue("@pCode", codePret);

                    // Exécuter la procédure stockée
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
        }

        public static List<MaterielPrete> GetStock()
        {
            List<MaterielPrete> stock = new List<MaterielPrete>();
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("LP_pAfficherStock", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            MaterielPrete materiel = new MaterielPrete();
                            materiel.codeMateriel = sqlDataReader.GetInt32(0);
                            materiel.marqueMateriel = sqlDataReader.GetString(1);
                            materiel.libelleMateriel = sqlDataReader.GetString(2);
                            materiel.etatMateriel = sqlDataReader.GetString(3);
                            if (!sqlDataReader.IsDBNull(5))
                            {
                                materiel.pointureMonopalme = sqlDataReader.GetInt32(5);
                            }
                            if (!sqlDataReader.IsDBNull(4))
                            {
                                materiel.tailleCombinaison = sqlDataReader.GetString(4);
                            }
                            
                            stock.Add(materiel);
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return stock;
        }
    }
}
