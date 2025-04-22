using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Partie2
{
    public class Gestionnaires
    {
        private readonly int _idGestionnaire;
        private readonly string _typeGestionnaire;
        private readonly int _nbTransaction;

        public int IdGestionnaire
        {
            get { return _idGestionnaire;}
        }

        public int TypeGestionnaire
        {
            get { return _idGestionnaire;}
        }

        public int nbTransaction
        {
            get { return _nbTransaction; }
        }

        public Gestionnaires(int IdGestionnaire, string TypeGestionnaire, int nbTransaction )
        {
            _idGestionnaire = IdGestionnaire;
            _typeGestionnaire = TypeGestionnaire;
            _nbTransaction = nbTransaction;
        }

    }
}
