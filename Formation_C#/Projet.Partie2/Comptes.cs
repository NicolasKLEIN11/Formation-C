using Projet.Partie2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Semaine2
{
    public class Comptes
    {

        private readonly int _idCompte;
        private readonly DateTime _dateCrea;
        private DateTime _dateCloture;
        private DateTime _dateTransfert;
        private decimal _soldeCompte;
        private readonly List<decimal> _historiqueVir;
        private decimal _sommeVir;
        private Gestionnaires _gestionnaire;

        public int IdCompte
        {
            get { return _idCompte; }
        }

        public DateTime DateCrea
        {
            get { return _dateCrea; }
        }

        public DateTime DateCloture
        {
            get { return _dateCloture; }
            set { _dateCloture = value; }
        }
        public DateTime DateTransfert 
        {
            get { return _dateTransfert; }
            set { _dateTransfert = value; }
        }
        public decimal SoldeCompte
        {
            get { return _soldeCompte; }
            set { _soldeCompte =  value; }
        }

        public List<decimal> HistoriqueVir
        {
            get { return _historiqueVir; }

        }
        public decimal SommeVir
        {
            get { return _sommeVir; }
            set { _sommeVir = value; }
        }
        public Gestionnaires Gestionnaire
        {
            get { return _gestionnaire; }
            set { _gestionnaire = value; }
        }

        public Comptes(int idCompte, DateTime dateCrea, DateTime dateCloture, DateTime DateTransfert,decimal soldeCompte, Gestionnaires Gestionnaire)
        {
            _idCompte = idCompte;
            _dateCrea = dateCrea;
            _dateCloture = dateCloture;
            _soldeCompte = soldeCompte;
            _dateTransfert = DateTransfert;
            _historiqueVir = new List<decimal>();
            _sommeVir = SommeVir;
            _gestionnaire = Gestionnaire;
        }

        public decimal HistoriqueVirement(decimal montant)
        {
            decimal cumul = 0;
            int limite = 0;
                if (_historiqueVir.Count > 9)
                {
                    limite = 9;
                }
                else
                {
                    limite = _historiqueVir.Count;
                }
            for (int i = _historiqueVir.Count - limite; i < _historiqueVir.Count; i++)
            {
                cumul = cumul + _historiqueVir[i];
            }

            SommeVir = cumul;
            return SommeVir;
        }
           public bool VerificationDepot(decimal montant, DateTime DateTransaction)
        {

            if (montant <= 0)
            {
                return false;
            }
            else if (DateTransaction < _dateCrea || DateTransaction > _dateCloture)
            {
                return false;
            }

            else
            {
                return true;
            }

        }
        public bool Verificationretrait (decimal montant, DateTime DateTransaction)
        {
            if (montant <= 0)
            {
                return false;
            }
            else if (_soldeCompte < 0)
            {
                return false;
            }
            else if (_soldeCompte < montant)
            {
                return false;
            }
            else if (montant + _sommeVir > 1000)
            {
                return false;
            }
            else if (DateTransaction < _dateCrea || DateTransaction > _dateCloture)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Depot(decimal montant)
        {
            _soldeCompte = _soldeCompte + montant;
            //_soldeCompte += montant;

        }

        public void Retrait(decimal montant)
        {
            _soldeCompte = _soldeCompte - montant;
            _historiqueVir.Add(montant);
            HistoriqueVirement(montant);
        }
    }
}
