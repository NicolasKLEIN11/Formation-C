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

        internal List<Comptes> CreaComptes(string inpout)
        {
            int idCompte = 0;
            decimal soldeCompte = 0;
            string dateCrea = null;
            string dateCloture = null;
            string dateTransfert = null;
            List<Comptes> comptes = new List<Comptes>();
            using (StreamReader reader = new StreamReader(inpout))
            {
                string ligne;
                while ((ligne = reader.ReadLine()) != null)
                {                                 

                    string[] tableauComptes = ligne.Split(';');
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
                            Comptes compte = new Comptes(idCompte, soldeCompte, dateCrea, dateCloture, dateTransfert);
                            Console.WriteLine(" compte numero " + idCompte + " solde initial : " + soldeCompte );
                            comptes.Add(compte);



                        //    if (tableaucomptes[3] != " "  && tableaucomptes[4] != " " )
                        //    {
                        //        datecrea = tableaucomptes[1];
                        //        comptes compte = new comptes(idcompte, soldecompte, datecrea, datecloture, datetransfert);
                        //        console.writeline(" compte numero " + idcompte + " solde initial : " + soldecompte + " crée le " + datecrea);
                        //        comptes.add(compte);
                        //    }
                        //    else if (tableaucomptes[4] != " " && tableaucomptes[3] != " ")
                        //    {
                        //        datecloture = tableaucomptes[1];
                        //        comptes compte = new comptes(idcompte, soldecompte, datecrea, datecloture, datetransfert);
                        //        console.writeline(" compte numero " + idcompte + " solde initial : " + soldecompte + " cloturé le " + datecloture);
                        //        comptes.add(compte);
                        //    }

                        }
                        else
                        {
                            Console.WriteLine(" erreur pour la création du compte " + idCompte + " : solde négatif");
                        }
                    }
                }

            }

            return comptes;
        }
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
            int idCompte = 0;
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
                    idCompte = int.Parse(tableauTransactions[0]);
                    montant = decimal.Parse(tableauTransactions[2]);
                    idExpediteur = int.Parse(tableauTransactions[3]);
                    idDestinataire = int.Parse(tableauTransactions[4]);

                    Transactions transaction = new Transactions(idCompte, montant, idExpediteur, idDestinataire);
                    Console.WriteLine("transaction entre " + idExpediteur + " et " + idDestinataire + " d'un montant de " + montant);
                    transactions.Add(transaction);
                }
            }

            return transactions;
        }
        internal bool FaireTransaction(List<Comptes> comptes, List<Transactions> transactions)
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

                            //compte.SoldeCompte += transaction.Montant;
                            compte.Depot(transaction.Montant);
                            transactionOk = true;

            
                        }

                    }
                }
                if (transaction.IDdestinataire == 0)
                {

                    foreach (Comptes compte in comptes)
                    {
                        if (compte.IdCompte == transaction.IDexpediteur)
                        {
                            if(compte.Verificationretrait(transaction.Montant))                                                        
                            {
                                compte.Retrait(transaction.Montant);
                                transactionOk = true;
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
                        if (comptes[idExpediteur].Verificationretrait(transaction.Montant))
                        {
                            comptes[idExpediteur].Retrait(transaction.Montant);
                            transactionOk = true;

                            if (comptes[idDestinataire].VerificationDepot(transaction.Montant))
                            {
                                comptes[idDestinataire].Depot(transaction.Montant); 
                                transactionOk = true;
                            }
                        }
                        
                       
                    }

                    if (transactionOk == true)
                    {
                        writer.WriteLine(transaction.IDcompte + ";OK");
                        
                    }
                    else
                    {
                        writer.WriteLine(transaction.IDcompte + ";KO");
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
    }
}
