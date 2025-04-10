using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicOperation(4, 5, '+');
            IntegerDivision(13, -4);
            Pow(2, 4);
            GoodDay(16);
            PyramideConstruction(10, false);
            Console.WriteLine(Factorial(6));
            int[] tableau = new int[] { 1, -5, 10, -3, 0, 4, 2, -7 };
            LinearSearch(tableau, 2);
            BinarySearch(tableau, 4);
            int[] LeftVector = new int[] { 1, 2, 3 };
            int[] RightVector = new int[] { -1, -4, 0 };
            BuildingMatrix(LeftVector, RightVector);
            int[,] tabA = new int[3, 2] { { 1, 2 }, { 4, 6 }, { -1, 8 } }; 
            Console.ReadKey();
        }

        static void BasicOperation(int a, int b, char operateur)

        {
            int r = 0;
            switch (operateur)
            {
                case '+':
                    r = a + b;
                    Console.WriteLine(a + " + " + b + " = " + r);
                    break;
                case '-':
                    r = a - b;
                    Console.WriteLine(a + " - " + b + " = " + r);
                    break;
                case '*':
                    r = a * b;
                    Console.WriteLine(a + " * " + b + " = " + r);
                    break;
                case '/':
                    if (b != 0)
                    {
                        r = a / b;
                        Console.WriteLine(a + " / " + b + " = " + r);
                    }
                    else
                        Console.WriteLine(a + " / " + b + " = Opération invalide ");
                    break;
                default:
                    Console.WriteLine($"{a} {operateur} {b} = Opération invalide.");
                    break;
            }

        }

        static void IntegerDivision(int a, int b)
        {
            int q = 0;
            int r = 0;
            if (b != 0)
            {
                q = a / b;

                r = a % b;
                if (r != 0)
                    Console.WriteLine($"{a} = {q} * {b} + {r}");
                else
                    Console.WriteLine($"{a} = {q} * {b}");

            }
            else
                Console.WriteLine($" {a} : {b} = opération invalide.");

        }
        static void Pow(int a, int b)
        {
            int r = 0;
            if (b != 0)
            {
                r = (int)Math.Pow(a, b);
                Console.WriteLine($" {a} ^ {b} = {r} ");
            }
            else
            {
                Console.WriteLine(" Opération invalide");
            }
        }
        static void GoodDay(int heure)
        {
            switch (heure)
            {
                case int h when h < 6:
                    Console.WriteLine($"Il est {heure} heure, Merveilleuse nuit ! ");
                    break;
                case int h when h > 6 && h < 12:
                    Console.WriteLine($"Il est {heure} heure, Bonne matinée ! ");
                    break;
                case int h when h == 12:
                    Console.WriteLine($"Il est {heure} heure, Bon appétit ! ");
                    break;
                case int h when h > 12 && h < 18:
                    Console.WriteLine($"Il est {heure} heure, Profitez de votre après-midi ! ");
                    break;
                case int h when h > 18:
                    Console.WriteLine($"Il est {heure} heure, passez une bonne soirée ! ");
                    break;

            }
        }
        static void PyramideConstruction(int n, bool isSmooth)
        {
            int j = n;
            int nbDePlus = 1;
            int nbDeSpace = n - 1;
            if (isSmooth == true)
            {
                for (int etage = 1; etage <= n; etage++)
                {
                    for (int nbDeSpaceAff = n - etage - 1; nbDeSpaceAff >= 0; nbDeSpaceAff--)
                    {
                        Console.Write(' ');
                    }
                    for (int nbDePlusaAff = 1; nbDePlusaAff <= nbDePlus; nbDePlusaAff++)
                    {
                        Console.Write('+');

                    }
                    nbDePlus = nbDePlus + 2;
                    Console.WriteLine();
                }


            }
            else
            {
                for (int etage = 1; etage <= n; etage++)
                {
                    char symbole = '+';
                    int reste = (etage % 2);
                    if (reste == 0)
                    {
                        symbole = '-';

                    }
                    for (int nbDeSpaceAff = n - etage - 1; nbDeSpaceAff >= 0; nbDeSpaceAff--)
                    {
                        Console.Write(' ');
                    }
                    for (int nbDePlusaAff = 1; nbDePlusaAff <= nbDePlus; nbDePlusaAff++)
                    {
                        Console.Write(symbole);

                    }
                    nbDePlus = nbDePlus + 2;
                    Console.WriteLine();
                }

            }
        }
        static int Factorial(int n)
        {
            int Res = 1;
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return Factorial(n - 1) * n;

            }
            Console.WriteLine(Res);

        }

        //   static int Factorial(int n)
        //   {
        //       int Res = 1;
        //       for (int nb = 1; nb <= n; nb ++ )
        //       {
        //           Res = Res * nb;
        //       }
        //       Console.WriteLine(Res);
        //       return Res;
        //   }

        static int LinearSearch(int[] tableau, int valeur)
        {
            int indice = -1;
            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] == valeur)
                {
                    indice = i;

                    break;

                }
                else
                {

                }

            }
            Console.WriteLine(indice);
            return indice;

        }

        static int BinarySearch(int[] tableau, int valeur)
        {
            Array.Sort(tableau);
            int indice = -1;
            int i = (tableau.Length) / 2;
            if (tableau[i] == valeur)
            {
                indice = i;

            }
            else if (tableau[i] > valeur)
            {
                int[] tableau2 = new int[tableau.Length / 2];

                for (int j = 0; j < i; j++)
                {
                    int val = tableau[j];
                    tableau2[j] = val;

                }
                return BinarySearch(tableau2, valeur);
            }
            else
            {
                int[] tableau2 = new int[tableau.Length / 2];
                int indice2 = 0;
                for (int j = i; j < (tableau.Length); j++)
                {
                    int val = tableau[j];

                    tableau2[indice2] = val;
                    indice2 = indice2 + 1;

                }
                return BinarySearch(tableau2, valeur);
            }
            Console.WriteLine(indice);
            return indice;

        }

        static int[][] BuildingMatrix(int[] leftVector, int[] rightVector)
        {
            int[] Tab1 = new int[3];
            int[] Tab2 = new int[3];
            int[] Tab3 = new int[3];

            for (int i = 0; i < rightVector.Length; i++)
            {
                
                int res = 0;
                res = rightVector[i] * leftVector[0];
                Tab1[i] = res;

            }
            for (int i = 0; i < rightVector.Length; i++)
            {
                
                int res = 0;
                res = rightVector[i] * leftVector[1];
                Tab2[i] = res;

            }
            for (int i = 0; i < rightVector.Length; i++)
            {
                
                int res = 0;
                res = rightVector[i] * leftVector[2];
                Tab3[i] = res;

            }
            int[][] Matrix = new int[3][] { Tab1, Tab2, Tab3 };
            Console.WriteLine(Matrix);
            return Matrix;
        }
                                          
    }
}
