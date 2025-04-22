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
            string inpoutComptes = "C:\\formation\\Comptes_1.txt";
            string inpoutTransactions = "C:\\formation\\Transactions_1.txt";
            Banque banque = new Banque();
            List<Comptes> comptes = banque.CreaComptes(inpoutComptes);
            List<Transactions> transactions = banque.CreaTransactions(inpoutTransactions);
            banque.FaireTransaction(comptes, transactions);
            Console.ReadKey();
        }

 

    }

}
