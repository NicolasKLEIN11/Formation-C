using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Partie2
{
    public class Gestionnaires
    {
        private int _idGestionnaire;
        private string _typeGestionnaire;
        private readonly int _nbTransaction;
        

        public int IdGestionnaire
        {
            get { return _idGestionnaire;}
            set { _idGestionnaire = value; }
        }

        public string TypeGestionnaire
        {
            get { return _typeGestionnaire;}
            set { _typeGestionnaire = "value"; }
        }

        public int nbTransaction
        {
            get { return _nbTransaction; }
           
        }

       
        public Gestionnaires(int IdGestionnaire, string TypeGestionnaire, int nbTransaction)
        {
            _idGestionnaire = IdGestionnaire;
            _typeGestionnaire = TypeGestionnaire;
            _nbTransaction = nbTransaction;
        }
    }
}
