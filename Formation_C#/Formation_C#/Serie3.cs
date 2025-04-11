using System;
using System.Collections.Generic;
using System.Data;
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
            SchoolMeans("C:\\formation\\serie3ent.txt", "C:\\formation\\serie3sor.txt");
            int[] TabA = new int[] { 4, 8, 2, 9, 3, 9, 4, 7, 6, 1};
           
            InsertionSort(TabA);
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
                    for(int i = 0; i < tableauMoy.Length; i++)
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
        static void InsertionSort(int[] array)
        {
            for (int i = 0; i < TabA.lenght )
        }
    }
}
