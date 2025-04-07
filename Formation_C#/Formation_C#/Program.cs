using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
           // PyramideConstruction(10, "Smooth");
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
            switch(heure)
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
        //static void PyramideConstruction(int n, bool is Smooth)

    }
}
