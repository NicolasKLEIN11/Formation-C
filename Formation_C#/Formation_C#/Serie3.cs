using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Formation_C_
{
    public class Serie3
    {

        public void serie3()
        {
            //          SchoolMeans("C:\\formation\\serie3ent.txt", "C:\\formation\\serie3sor.txt");
            int[] TabA = new int[] { 6, 4, 8, 2, 9, 3, 9, 4, 7, 6, 1 };
            AfficherTab(TabA);
            //          Array.Sort(TabA);
            // InsertionSort(TabA);
            //          Quicksort(TabA);
            UseInsertionSort(TabA);
            AfficherTab(TabA);

            string[] morseAlph = { "=.==", "==.=.=.=", "==.=.==.=", "==.=.=", "=", "=.=.==.=", "==.==.=", "=.=.=.=", "=.=", "=.==.==.==", "==.=.==", "=.==.=.=", "==.==", "==.=", "==.==.==", "=.==.==.=", "==.==.=.==", "=.==.=", "=.=.=", "==", "=.=.==", "=.=.=.==", "=.==.==", "==.=.=.==", "==.=.==.==", "==.==.=.=" };
            char[] alphabetAlph = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Dictionary<string, char> morse = new Dictionary<string, char>();
            morse[morseAlph[0]] = alphabetAlph[0];
            morse[morseAlph[1]] = alphabetAlph[1];
            morse[morseAlph[2]] = alphabetAlph[2];
            morse[morseAlph[3]] = alphabetAlph[3];
            morse[morseAlph[4]] = alphabetAlph[4];
            morse[morseAlph[5]] = alphabetAlph[5];
            morse[morseAlph[6]] = alphabetAlph[6];
            morse[morseAlph[7]] = alphabetAlph[7];
            morse[morseAlph[8]] = alphabetAlph[8];
            morse[morseAlph[9]] = alphabetAlph[9];
            morse[morseAlph[10]] = alphabetAlph[10];
            morse[morseAlph[11]] = alphabetAlph[11];
            morse[morseAlph[12]] = alphabetAlph[12];
            morse[morseAlph[13]] = alphabetAlph[13];
            morse[morseAlph[14]] = alphabetAlph[14];
            morse[morseAlph[15]] = alphabetAlph[15];
            morse[morseAlph[16]] = alphabetAlph[16];
            morse[morseAlph[17]] = alphabetAlph[17];
            morse[morseAlph[18]] = alphabetAlph[18];
            morse[morseAlph[19]] = alphabetAlph[19];
            morse[morseAlph[20]] = alphabetAlph[20];
            morse[morseAlph[21]] = alphabetAlph[21];
            morse[morseAlph[22]] = alphabetAlph[22];
            morse[morseAlph[23]] = alphabetAlph[23];
            morse[morseAlph[24]] = alphabetAlph[24];
            morse[morseAlph[25]] = alphabetAlph[25];
              
            string code = "==.=.==.=...==.==.==...==.=.=...=.....==.==...==.==.==...=.==.=...=.=.=...=";
            LettersCount(code);
            WordsCount(code);
            MorseTranslation(code);
            Console.ReadKey();
        }


        static void SchoolMeans(string inpout, string output)
        {
            double MoyMath = 0;
            double TotMath = 0;
            double iMath = 0;
            double MoyHist = 0;
            double TotHist = 0;
            double iHist = 0;
            double TotSport = 0;
            double iSport = 0;
            double MoySport = 0;
            List<string> lignes = new List<string>();
            using (StreamReader reader = new StreamReader("C:\\formation\\serie3ent.txt"))
            {
                string ligne;
                while ((ligne = reader.ReadLine()) != null)
                {
                    string[] tableauMoy = ligne.Split(';');
                    //                Console.WriteLine(tableauMoy);
                    for (int i = 0; i < tableauMoy.Length; i++)
                    {
                        switch (tableauMoy[1])
                        {
                            case "Math":

                                TotMath = TotMath + double.Parse(tableauMoy[2]);
                                iMath = iMath + 1;
                                break;
                            case "Histoire":
                                TotHist = TotHist + double.Parse(tableauMoy[2]);
                                iHist = iHist + 1;
                                break;
                            case "Sport":
                                TotSport = TotSport + double.Parse(tableauMoy[2]);
                                iSport = iSport + 1;
                                break;
                            default:
                                break;

                        }
                    }
                }
                MoyMath = TotMath / iMath;
                MoyHist = TotHist / iHist;
                MoySport = TotSport / iSport;

                Console.WriteLine(" matière   moyenne");
                Console.WriteLine(" Math      " + MoyMath);
                Console.WriteLine(" Histoire  " + MoyHist);
                Console.WriteLine(" Sport     " + MoySport);


                using (StreamWriter writer = new StreamWriter("C:\\formation\\serie3sor.txt"))
                {
                    writer.WriteLine(" matière   moyenne");
                    writer.WriteLine(" Math      " + MoyMath);
                    writer.WriteLine(" Histoire  " + MoyHist);
                    writer.WriteLine(" Sport     " + MoySport);
                }

                Console.ReadLine();

            }


        }
        static void AfficherTab(int[] TabA)
        {
             int n = TabA.Length;
             for (int i = 0; i <= n-1; i++) 
             System.Console.Write(TabA[i]+" , ");
             System.Console.WriteLine( );
        }
        static void InsertionSort(int[] TabA)
        {
            for (int i = 1; i < TabA.Length; i++)
            {
                if (TabA[i] < TabA[i-1])
                {
                   int a = 0;
                   a = TabA[i];
                   TabA[i] = TabA[i - 1];
                   TabA[i-1] = a;
                   i = 0;
                    
                }
                
            }
            
        }
        static void Quicksort(int[] TabA)
        {
            int Pivot = TabA[0];
            int j = 0;
            int k = 0;
            int[] TabB = new int[TabA.Length];
            int[] TabC = new int[TabA.Length];
            for (int i = 1; i < TabA.Length; i++)
            {
                if (TabA[i] <= Pivot)
                {                                        
                    TabB[j] = TabA[i];
                    j = j + 1;
                                        
                }
                else
                {                                        
                    TabC[k] = TabA[i];
                    k = k + 1;
                    
                }
                TabB[j] = Pivot;
               
            }
         //   Quicksort(TabB);
         //   Quicksort(TabC);
        }
        static long UseInsertionSort(int[] TabA)
        {
            long tps = 0;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 1; i < TabA.Length; i++)
            {
                if (TabA[i] < TabA[i - 1])
                {
                    int a = 0;
                    a = TabA[i];
                    TabA[i] = TabA[i - 1];
                    TabA[i - 1] = a;
                    i = 0;

                }

            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.ToString());

            
            return tps;
        }
        // il est important de réaliser plusieurs test car la durée d'execution peut varier d'un test à l'autre, il ets ainsi necessaire de faire une moyenne
        // le temps d'execution varie en fonction des autres programmes qui fonctionne en même temps sur l'ordinateur




        // ici commence la serie IV 

        // le dictionnaire permet de faire la correspondance entre une valeur en string et une valeur en char via les indices dans les tableaux

        static int LettersCount(string code)
        {
            int count = 0;

            string codemodif = code.Replace("...",";");
            string codemodi2 = codemodif.Replace(".....", ";");
            string[] Tablet = codemodi2.Split(';');

            for (int i = 0; i < Tablet.Length; i++)
            {
                count ++;
            }

            Console.WriteLine("nombre de lettres dans le code : " + count);
            return count;
        }
        static int WordsCount(string code)
        {
            int count = 0;

            string codemodif = code.Replace(".....", ";");
            string[] Tablet = codemodif.Split(';');
            for (int i = 0; i < Tablet.Length; i++)
            {
                count++;
            }

            Console.WriteLine("nombre de mots dans le code : " + count);

            return count;
        }
        static string MorseTranslation(string code)
        {
            string[] morseAlph = { "=.==", "==.=.=.=", "==.=.==.=", "==.=.=", "=", "=.=.==.=", "==.==.=", "=.=.=.=", "=.=", "=.==.==.==", "==.=.==", "=.==.=.=", "==.==", "==.=", "==.==.==", "=.==.==.=", "==.==.=.==", "=.==.=", "=.=.=", "==", "=.=.==", "=.=.=.==", "=.==.==", "==.=.=.==", "==.=.==.==", "==.==.=.=" };
            char[] alphabetAlph = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Dictionary<string, char> morse = new Dictionary<string, char>();
            morse[morseAlph[0]] = alphabetAlph[0];
            morse[morseAlph[1]] = alphabetAlph[1];
            morse[morseAlph[2]] = alphabetAlph[2];
            morse[morseAlph[3]] = alphabetAlph[3];
            morse[morseAlph[4]] = alphabetAlph[4];
            morse[morseAlph[5]] = alphabetAlph[5];
            morse[morseAlph[6]] = alphabetAlph[6];
            morse[morseAlph[7]] = alphabetAlph[7];
            morse[morseAlph[8]] = alphabetAlph[8];
            morse[morseAlph[9]] = alphabetAlph[9];
            morse[morseAlph[10]] = alphabetAlph[10];
            morse[morseAlph[11]] = alphabetAlph[11];
            morse[morseAlph[12]] = alphabetAlph[12];
            morse[morseAlph[13]] = alphabetAlph[13];
            morse[morseAlph[14]] = alphabetAlph[14];
            morse[morseAlph[15]] = alphabetAlph[15];
            morse[morseAlph[16]] = alphabetAlph[16];
            morse[morseAlph[17]] = alphabetAlph[17];
            morse[morseAlph[18]] = alphabetAlph[18];
            morse[morseAlph[19]] = alphabetAlph[19];
            morse[morseAlph[20]] = alphabetAlph[20];
            morse[morseAlph[21]] = alphabetAlph[21];
            morse[morseAlph[22]] = alphabetAlph[22];
            morse[morseAlph[23]] = alphabetAlph[23];
            morse[morseAlph[24]] = alphabetAlph[24];
            morse[morseAlph[25]] = alphabetAlph[25];


            string codemodif = code.Replace("...", ";");
            string codemodi2 = codemodif.Replace("..", "..;");
            string [] Tablet = codemodi2.Split(';');
            
            char[] TabTrad = new char[Tablet.Length];

            int i = 0;
            foreach (string s in Tablet)
            {
                if (s == "..")
                {
                    TabTrad[i] = ' ';
                    i++;

                }
                else
                {
                    foreach (KeyValuePair<string, char> kv in morse)
                    {
                        if (s == kv.Key)
                        {
                            TabTrad[i] = kv.Value;
                            i++;
                        }
                    }
                }

            }
            string CodeTrad = string.Concat(TabTrad);
            Console.WriteLine(CodeTrad);
            return CodeTrad;
        }
    }  
                             
}
