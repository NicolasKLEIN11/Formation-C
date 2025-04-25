using Projet.Partie2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine2
{
    public class Banque
    {
        public Banque()
        {
           

        }
        int compteurCrea = 0;
        int compteurTransaction = 0;
        int compteurTransactionOK = 0;
        int compteurTransactionKO = 0;
        decimal SommeMontant = 0;
       
        internal List<Gestionnaires> CreaGestionnaires(string inpout)
        {
            int idGestionnaire = 0;
            string typeGestionnaires = null;
            int nbTransactions = 0;
         //   decimal FraisGestions = 0;  

            List<Gestionnaires> gestionnaires = new List<Gestionnaires>();
            using (StreamReader reader = new StreamReader(inpout))
            {
                string ligne;
                while ((ligne = reader.ReadLine()) != null)
                {
                    string[] tableauGestionnaires  = ligne.Split(';');
                    idGestionnaire = int.Parse(tableauGestionnaires[0]);
                    typeGestionnaires = tableauGestionnaires[1];
                    nbTransactions = int.Parse(tableauGestionnaires[2]);

                    Gestionnaires gestionnaire = new Gestionnaires(idGestionnaire, typeGestionnaires, nbTransactions);
                    Console.WriteLine("Gestionnaire " + idGestionnaire + " de type " + typeGestionnaires + " avec " + nbTransactions + " transactions");
                    gestionnaires.Add(gestionnaire);
                }
            }
            return gestionnaires;
        }
        internal List<Comptes> CreaComptes(string inpout, List<Gestionnaires> gestionnaires)
        {
            using (StreamWriter writer = new StreamWriter("C:\\formation2\\StatutOperations.txt"))
                
            {
                int idCompte = 0;
                decimal soldeCompte = 0;
                DateTime dateCrea = DateTime.MinValue;
                DateTime dateCloture = DateTime.MaxValue;
                DateTime dateTransfert = DateTime.MaxValue;
                Gestionnaires Gestionnaire;
                List<Comptes> comptes = new List<Comptes>();
                using (StreamReader reader = new StreamReader(inpout))
                {
                    string ligne;
                    while ((ligne = reader.ReadLine()) != null)
                    {
                        string[] tableauComptes = ligne.Split(';');

                        idCompte = int.Parse(tableauComptes[0]);

                        if (tableauComptes[3] != " " && tableauComptes[3] != "" && tableauComptes[4] != " " && tableauComptes[4] != "")
                        {
                            dateTransfert = DateTime.Parse(tableauComptes[1]);
                            int CompteTransfert = -1;

                            for (int i = 0; i < comptes.Count; i++)
                            {
                                if (comptes[i].IdCompte == int.Parse(tableauComptes[0]))
                                {
                                    CompteTransfert = i;
                                }
                                else
                                {
                                    continue;
                                }

                                if (comptes[i].Gestionnaire.IdGestionnaire == int.Parse(tableauComptes[3]))

                                    if (dateTransfert > comptes[i].DateCrea)
                                    {

                                    }
                                    else
                                    {
                                        writer.WriteLine(idCompte + " " + tableauComptes[1] + " " + tableauComptes[3] + " " + tableauComptes[4] + " transfert KO");
                                        break;
                                    }
                                else
                                {
                                    writer.WriteLine(idCompte + " " + tableauComptes[1] + " " + tableauComptes[3] + " " + tableauComptes[4] + " transfert KO");
                                    break;
                                }

                                if (dateTransfert > comptes[i].DateCrea)
                                {


                                }
                                else
                                {
                                    writer.WriteLine(idCompte + " " + tableauComptes[1] + " " + tableauComptes[3] + " " + tableauComptes[4] + " transfert KO");
                                    break;
                                }

                                writer.WriteLine(idCompte + " " + tableauComptes[1] + " " + tableauComptes[3] + " " + tableauComptes[4] + " transfert OK");
                                comptes[i].DateTransfert = dateTransfert;
                            //    comptes[i].Gestionnaire.IdGestionnaire = int.Parse(tableauComptes[4]);
                                foreach(Gestionnaires gestionnaire in gestionnaires)
                                {
                                    if (gestionnaire.IdGestionnaire == int.Parse(tableauComptes[4]))
                                    {

                                        comptes[i].Gestionnaire = gestionnaire;
                                    }
                                }
                            }    
                            
                        }
                        else if (tableauComptes[3] != " " && tableauComptes[3] != "")
                        {

                            idCompte = int.Parse(tableauComptes[0]);

                            if (VerifCreaCompte(comptes, idCompte))
                            {
                                Console.WriteLine("erreur, le compte " + idCompte + " existe déjà");
                            }
                            else
                            {

                                if (tableauComptes[2] == " " || tableauComptes[2] == "") //string.IsNullOrWhiteSpace(tableauComptes[1])
                                {
                                    soldeCompte = 0;
                                }
                                else
                                {
                                    soldeCompte = decimal.Parse(tableauComptes[2]);

                                }

                                if (soldeCompte >= 0)
                                {
                                    dateCrea = DateTime.Parse(tableauComptes[1]);

                                    foreach (Gestionnaires gestionnaire in gestionnaires)
                                    { 
                                        if (gestionnaire.IdGestionnaire == int.Parse(tableauComptes[3]))
                                        {
                                            Gestionnaire = gestionnaire;
                                            Comptes compte = new Comptes(idCompte, dateCrea, dateCloture, dateTransfert, soldeCompte, Gestionnaire);
                                            Console.WriteLine(" compte numero " + idCompte + " date de creation " + dateCrea + " solde initial : " + soldeCompte);
                                            comptes.Add(compte);
                                            compteurCrea++;
                                            writer.WriteLine(compte.IdCompte + " " + tableauComptes[1] + " " + compte.SoldeCompte + " Crea OK");
                                        }
                                    }
                                   
                    //                Comptes compte = new Comptes(idCompte, dateCrea, dateCloture, soldeCompte, Gestionnaire);
                    //                Console.WriteLine(" compte numero " + idCompte + " date de creation " + dateCrea + " solde initial : " + soldeCompte);
                    //                comptes.Add(compte);
                    //                compteurCrea++;
                    //                writer.WriteLine(compte.IdCompte + " " + tableauComptes[1] + " " + compte.SoldeCompte + " Crea OK");

                                }
                                else
                                {
                                    Console.WriteLine(" erreur pour la création du compte " + idCompte + " : solde négatif");
                                }
                            }
                        }
                        else if (tableauComptes[4] != " " && tableauComptes[4] != "")
                        {
                            bool verif = false;
                            foreach (Comptes compte in comptes)
                            {
                                
                                if (compte.IdCompte == idCompte)
                                {
                                    dateCloture = DateTime.Parse(tableauComptes[1]);
                                    compte.DateCloture = dateCloture;
                                    writer.WriteLine(compte.IdCompte + " " + tableauComptes[1] + " Cloture OK");
                                    verif = true;
                                    break;
                                }
                                else
                                {
                                    
                                }
                               
                            }
                            if (verif == false)
                            {
                                Console.WriteLine("erreur, le compte " + idCompte + " n'existe pas ");
                                writer.WriteLine(idCompte + " " + tableauComptes[1] + " cloture KO");
                            }
                        }                     
                    }
                }
                return comptes;
            }
            
        }
    //     internal bool VerifTransfert(DateTime dateTransfert)
    //    {
    //        bool statut = false;
    //        if (dateTransfert < compte._dateCrea)
    //    }
        internal bool VerifCreaCompte(List<Comptes> comptes, int idCompte)
        {
            foreach (Comptes compte in comptes)
            {
                if (compte.IdCompte == idCompte)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            return false;
        }
        internal List<Transactions> CreaTransactions(string inpout)
        {
            int idTransaction = 0;
            DateTime dateTransaction = DateTime.MinValue;
            decimal montant = 0;
            int idExpediteur = 0;
            int idDestinataire = 0;

            List<Transactions> transactions = new List<Transactions>();
            using (StreamReader reader = new StreamReader(inpout))
            {
                string ligne;
                while ((ligne = reader.ReadLine()) != null)
                {
                    string[] tableauTransactions = ligne.Split(';');
                    idTransaction = int.Parse(tableauTransactions[0]);
                    dateTransaction = DateTime.Parse(tableauTransactions[1]);
                    montant = decimal.Parse(tableauTransactions[2]);
                    idExpediteur = int.Parse(tableauTransactions[3]);
                    idDestinataire = int.Parse(tableauTransactions[4]);

                    Transactions transaction = new Transactions(idTransaction, dateTransaction, montant, idExpediteur, idDestinataire);
                    Console.WriteLine("transaction entre " + idExpediteur + " et " + idDestinataire + " datant du " + dateTransaction + " d'un montant de " + montant);
                    transactions.Add(transaction);
                    compteurTransaction++;
                }
            }

            return transactions;
        }
        internal bool FaireTransaction(List<Comptes> comptes, List<Transactions> transactions, List<Gestionnaires> gestionnaires)
        {
            using (StreamWriter writer = new StreamWriter("C:\\formation2\\StatutTransactions.txt"))
            { 
                bool transactionOk = false;
                foreach (Transactions transaction in transactions)
                {
                transactionOk = false;

                     if (transaction.IDexpediteur == 0)
                     {
                           decimal montant = transaction.Montant;

                          foreach (Comptes compte in comptes)
                          {
                              if (compte.IdCompte == transaction.IDdestinataire)
                              {
                                  if (transaction.DateTransaction > compte.DateCrea && transaction.DateTransaction < compte.DateCloture)
                                  {
                                      if (compte.VerificationDepot(transaction.Montant, transaction.DateTransaction))
                                      {
                                        //compte.SoldeCompte += transaction.Montant;
                                        compte.Depot(transaction.Montant);
                                        transactionOk = true;
                                      }
                                  }
                                  else
                                  {
                                    transactionOk = false;
                                  }
            
                              }

                          }
                     }
                    if (transaction.IDdestinataire == 0)
                    {

                          foreach (Comptes compte in comptes)
                          {
                              if (compte.IdCompte == transaction.IDexpediteur)
                              {
                                  if (transaction.DateTransaction > compte.DateCrea && transaction.DateTransaction < compte.DateCloture)
                                  {
                                      if (compte.Verificationretrait(transaction.Montant, transaction.DateTransaction))
                                      {
                                        compte.Retrait(transaction.Montant);
                                        transactionOk = true;
                                      }
                                      else
                                      {
                                        transactionOk = false;
                                      }
                                  }
                              }

                          }

                    //if (comptes.VerificationDepot(montant) == true)
                    //{
                    //    Comptes.Depot(montant);
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                    }
                    if (transaction.IDexpediteur != 0 && transaction.IDdestinataire != 0)
                    {
                        int idExpediteur = -1;
                        int idDestinataire = -1;
                        for (int i = 0; i < comptes.Count; i++)
                        {
                            if (comptes[i].IdCompte == transaction.IDexpediteur)
                            {
                                idExpediteur = i;
                            }
                            if (comptes[i].IdCompte == transaction.IDdestinataire)
                            {
                                idDestinataire = i;
                            }

                        }
                            //Code 
                        if (comptes[idExpediteur].Verificationretrait(transaction.Montant, transaction.DateTransaction))
                        {
                                comptes[idExpediteur].Retrait(transaction.Montant);
                                

                             if (comptes[idDestinataire].VerificationDepot(transaction.Montant, transaction.DateTransaction))
                             {
                                 comptes[idDestinataire].Depot(transaction.Montant); 
                                 transactionOk = true;

                                  if (comptes[idDestinataire].Gestionnaire != comptes[idExpediteur].Gestionnaire)
                                  {
                                     if (transaction.DateTransaction > comptes[idExpediteur].DateTransfert || transaction.DateTransaction > comptes[idDestinataire].DateTransfert)
                                     {
                                        if (comptes[idExpediteur].Gestionnaire.TypeGestionnaire == "Particulier")
                                        {
                                            Console.WriteLine("frais de gestions de 10 euro");
                                            transaction.FraisGestions = 10;
                                        }
                                        else
                                        {
                                            Console.WriteLine("frais de gestions de 1%");
                                            transaction.FraisGestions = transaction.Montant / 100;
                                        }
                                     }
                                  }
                             }
                        }
                        
                       
                    }

                    if (transactionOk == true)
                    {
                        writer.WriteLine(transaction.IDTransaction + ";OK");
                        compteurTransactionOK++;
                        SommeMontant = SommeMontant + transaction.Montant;                 
                    }
                    else
                    {
                        writer.WriteLine(transaction.IDTransaction + ";KO");
                        compteurTransactionKO++;
                    }
                }
            }

/*            for (int i = 0; i < transactions.Count; i++)
            {
                if (transactions[i].IDexpediteur == 0)
                {
                    decimal montant = transaction.Montant;
                    if (Comptes.VerificationDepot(montant) == true)
                    {
                        Comptes.Depot(montant);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (transactions[i].IDdestinataire == 0)
                {
                    decimal montant = transactions.Montant;
                    if (Comptes.Verificationretrait(montant) == true)
                    {
                        Comptes.Retrait(montant);
                        return true;
                    }
                }
                else
                {


                }
            }*/
            
            return false;
            
        }

        internal void Compteur (List<Transactions> transactions)
        {
            using (StreamWriter writer = new StreamWriter("C:\\formation2\\Statistiques.txt"))
            {
                writer.WriteLine("Statistiques :");
                writer.WriteLine("Nombre de comptes : " + compteurCrea);
                writer.WriteLine("Nombre de transactions : " + compteurTransaction);
                writer.WriteLine("Nombre de réussites : " + compteurTransactionOK);
                writer.WriteLine("Nombre d'échecs : " + compteurTransactionKO);
                writer.WriteLine("Montant total des réussites : " + SommeMontant);
                writer.WriteLine("");
                writer.WriteLine("Frais de gestions :");

                foreach (Transactions transaction in transactions)
                {
                    writer.WriteLine(transaction.IDTransaction + " : " + transaction.FraisGestions + " euros ");
                }
            }
        }
    }
}
