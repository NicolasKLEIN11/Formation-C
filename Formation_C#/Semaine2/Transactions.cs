using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine2
{
    public class Transactions
    {
        private readonly int _idCompte;
        private readonly decimal _montant;
        private readonly int _idExpediteur;
        private readonly int _idDestinataire;
        private bool _statut;

        public int IDcompte
        {
            get { return _idCompte; }
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

        public Transactions(int idCompte, decimal montant, int idExpediteur, int IdDestinataire)
        {
            _idCompte = idCompte;
            _montant = montant;
            _idExpediteur = idExpediteur;
            _idDestinataire = IdDestinataire;
           _statut = false;
        }             
    }
}
