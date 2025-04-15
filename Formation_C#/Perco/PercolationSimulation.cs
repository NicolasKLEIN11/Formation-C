using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }
        /// <summary>
        /// Fraction
        /// </summary>
        public double Fraction { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {

            return new PclData();
        }

        public double PercolationValue(int size)
        {
            Percolation grille = new Percolation(size);

            Random seed = new Random();

            int randomi = seed.Next(0,size);
            int randomj = seed.Next(0,size);

            grille.Open(randomi,randomj);

            bool estOK = grille.Percolate();
            int NbCaseOuv = 0;

            while (estOK == false)
            {
                randomi = seed.Next(0, size);
                randomj = seed.Next(0, size);

                grille.Open(randomi,randomj);
               estOK =  grille.Percolate();
                NbCaseOuv++;
            }

            int CaseTot = size * size;
            double ValeurCase = (double)NbCaseOuv / CaseTot;
           
            
            
            return ValeurCase;
        }
    }
}
