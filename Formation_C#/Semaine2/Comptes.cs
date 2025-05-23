﻿using System;
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
        private decimal _soldeCompte;
        private readonly List<decimal> _historiqueVir;
        private decimal _sommeVir;

        public int IdCompte
        {
            get { return _idCompte; }
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

        public Comptes(int idCompte, decimal soldeCompte)
        {
            _idCompte = idCompte;
            _soldeCompte = soldeCompte;
            _historiqueVir = new List<decimal>();
            _sommeVir = SommeVir;
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
           public bool VerificationDepot(decimal montant)
        {
            
            if (montant == 0)
            { 
                return false; 
            }
            else 
            { 
                return true; 
            }

        }
        public bool Verificationretrait (decimal montant)
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
            else if (montant + _sommeVir >= 1000)
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
