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
            List<Comptes> comptes = new List<Comptes>();
            using (StreamReader reader = new StreamReader(inpout))
            {
                string ligne;
                while ((ligne = reader.ReadLine()) != null)
                {
                    string[] tableauComptes = ligne.Split(';');
                    idCompte = int.Parse(tableauComptes[0]);
                    if (tableauComptes[1] == " ") //string.IsNullOrWhiteSpace(tableauComptes[1])
                    {
                        soldeCompte = 0;
                    }
                    else
                    {
                        soldeCompte = decimal.Parse(tableauComptes[1]);
                    }

                    Comptes compte = new Comptes(idCompte, soldeCompte);
                    Console.WriteLine(" compte numero " + idCompte + " solde initial : " + soldeCompte);
                    comptes.Add(compte);
                }

            }

            return comptes;
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
                    montant = decimal.Parse(tableauTransactions[1]);
                    idExpediteur = int.Parse(tableauTransactions[2]);
                    idDestinataire = int.Parse(tableauTransactions[3]);

                    Transactions transaction = new Transactions(idCompte, montant, idExpediteur, idDestinataire);
                    Console.WriteLine("transaction entre " + idExpediteur + " et " + idDestinataire + " d'un montant de " + montant);
                    transactions.Add(transaction);
                }
            }

            return transactions;
        }
        internal bool FaireTransaction(List<Comptes> comptes, List<Transactions> transactions)
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
                    foreach(Comptes compte in comptes)
                        if (compte.IdCompte == transaction.IDexpediteur)
                        {
                            if (compte.Verificationretrait(transaction.Montant) == true) 
                            {
                                compte.Retrait(transaction.Montant);
                                transactionOk = true;


                            }
                            else
                            { 
                            }
                        }

                    foreach (Comptes compte in comptes)
                        if (compte.IdCompte == transaction.IDdestinataire)
                        {

                        //compte.SoldeCompte += transaction.Montant;
                        compte.Depot(transaction.Montant);
                        transactionOk = true;
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
            

            return transactionOk;
        }
    }
}
