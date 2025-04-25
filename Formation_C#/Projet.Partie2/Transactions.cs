using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine2
{
    public class Transactions
    {
        private readonly int _idTransaction;
        private readonly DateTime _dateTransaction;
        private readonly decimal _montant;
        private readonly int _idExpediteur;
        private readonly int _idDestinataire;
        private bool _statut;
        private decimal _fraisGestions;

        public int IDTransaction
        {
            get { return _idTransaction; }
        }

        public DateTime DateTransaction
        { 
            get { return _dateTransaction; }
        }

        public decimal Montant
        { 
            get { return _montant; }
        }

        public int IDexpediteur
        {
            get { return _idExpediteur; }
        }

        public int IDdestinataire
        {
            get { return _idDestinataire; }
        }

        public bool Statut
        { 
            get { return _statut; }
            set { _statut = value; }
        }

        public decimal FraisGestions
        {
            get { return _fraisGestions; }
            set { _fraisGestions = value; }
        }

        public Transactions(int idTransaction, DateTime dateTransaction, decimal montant, int idExpediteur, int IdDestinataire)
        {
            _idTransaction = idTransaction;
            _dateTransaction = dateTransaction;
            _montant = montant;
            _idExpediteur = idExpediteur;
            _idDestinataire = IdDestinataire;
            _statut = false;
            _fraisGestions = FraisGestions;
        }             
    } 
}
