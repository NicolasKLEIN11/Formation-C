using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine2
{
    public class StatutTransactions
    {
        private readonly int _idCompte;
        private readonly bool _statut;

        public int IdCompte
        {
            get { return _idCompte; }
        }

        public bool Statut
        {
            get { return _statut; }
        }

        private StatutTransactions(int idCompte, bool statut)
        {
            _idCompte = idCompte;
            _statut = statut;
        }
    }
}
