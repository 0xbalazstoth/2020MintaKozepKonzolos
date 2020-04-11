using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020KozepKonzolos
{
    class Jatek
    {
        public static List<Jatek> Adat = new List<Jatek>();
        public string Neve { get; set; }
        public List<int> SzamTippek { get; set; }
        public static int megadottFordulo { get; set; }

        public Jatek(string sor)
        {
            SzamTippek = new List<int>();
            string[] split = sor.Split(' ');
            Neve = split[0];
            for (int i = 1; i < split.Length; i++)
            {
                SzamTippek.Add(Convert.ToInt32(split[i]));
            }
        }

        public static void MasodikFeladat(string fajl)
        {
            using (StreamReader olvas = new StreamReader(fajl))
            {
                while (!olvas.EndOfStream)
                {
                    Jatek jatek = new Jatek(olvas.ReadLine());

                    Adat.Add(jatek);
                }
            }
        }

        public static void HarmadikFeladat() => Console.WriteLine($"3. feladat: Játékosok száma: {Adat.Count} fő");
        public static void NegyedikFeladat()
        {
            Console.Write("4. feladat: Kérem a forduló sorszámát: ");
            megadottFordulo = Convert.ToInt32(Console.ReadLine());
        }
        public static void OtodikFeladat()
        {
            double ossz = 0;
            foreach (var item in Adat)
            {
                ossz += item.SzamTippek[megadottFordulo - 1];
            }

            Console.WriteLine($"5. feladat: A megadott forduló tippjeinek átlaga: {Math.Round((double)ossz / (double)Adat.Count, 2)}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Feladatok();

            Console.ReadKey();
        }

        private static void Feladatok()
        {
            Jatek.MasodikFeladat("egyszamjatek1.txt");
            Jatek.HarmadikFeladat();
            Jatek.NegyedikFeladat();
            Jatek.OtodikFeladat();
        }
    }
}
