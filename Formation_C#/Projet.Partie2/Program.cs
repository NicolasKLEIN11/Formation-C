using Projet.Partie2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Semaine2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inpoutComptes = "C:\\formation2\\comptesP2.txt";
            string inpoutTransactions = "C:\\formation2\\transactionsP2.txt";
            string inpoutGestionnaires = "C:\\formation2\\gestionnaires.txt";
            Banque banque = new Banque();
            List<Gestionnaires> gestionnaires = banque.CreaGestionnaires(inpoutGestionnaires);
            List<Comptes> comptes = banque.CreaComptes(inpoutComptes, gestionnaires);
            List<Transactions> transactions = banque.CreaTransactions(inpoutTransactions);
            banque.FaireTransaction(comptes, transactions, gestionnaires);
            banque.Compteur(transactions);
            Console.ReadKey();
        }

 

    }

}
