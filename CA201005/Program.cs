using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201005
{
    class Program
    {
        static void Main()
        {
            //eljárás
            Console.WriteLine();
            Ugat();

            //függvény
            string str = Console.ReadLine();

            //saját eljárás
            var nap = Nap();
            Console.WriteLine(nap);

            //saját függvény
            string magyarNap = MagyarNap();
            Console.WriteLine(magyarNap);

            //függvényhívások hívás helyén visszatérési típusnak megfelelő literálként működnek
            //báz ez kerülendő, mert nem CC
            Console.WriteLine(MagyarNap());
            Console.WriteLine(MagyarNap() + " van");

            //paraméteres függvény
            var n = Math.Pow(2, 10);

            //paraméteres eljárás
            Console.WriteLine(n);

            //létezhet azonos nevű metódus (azaz függvény vagy eljárás)
            //ha különbözik a paraméterlista
            Console.WriteLine(EgyszeruOsszeadas(20, 30));
            Console.WriteLine(EgyszeruOsszeadas(20, 40, 40));

            //tetszőleges számú paraméter átadható pl. úgy, ha tömböt vár a metódus
            Console.WriteLine(OsszegA1(new int[] { 2, 3, 45, 6, 57,  }));

            //összetett adatszerkezet elemei közvetlenül átadhatóak
            //ha a params kulcsszó szerepel a metódus deffiníciójában
            Console.WriteLine(OsszegA2(53, 546, 456, 456 ,6,45 ,6456 ));

            //a ref és az out paramétereket sokan "design hibának" tartják a C#-ban
            //egy tisztán OOP nyelvben ezekre sokkal elegánsabb megoldások is léteznek.
            //használatuk nékülözhető, ismeretük nem (sok FCL osztály használja őket)
            //használatukat hívás ÉS deff. szinten IS jelezni kell!

            //referencia ttípusú paraméterátadás (vagyis "átmenő" paraméterátadás):
            //a ref-ként átadott paraméter a hívás helyén is megváltozik
            int x = 10;
            Valtoztagt(ref x);
            Console.WriteLine(x);

            //output vagy "kimenő" parmaméterátadás:
            //akár van, akár nincs inicializálva az out-os paraméter, az átmenő paraméterként átadható
            //a ref-hez hasonlóan a hívás helyén is változik az érték
            int m;
            Kimeno(out m);
            Console.WriteLine(m);


            Console.ReadKey();
        }

        static void Ugat()
        {
            Console.WriteLine("vau-vau");
        }
        static string Nap()
        {
            //függvényben feltétlen kell return a végére
            return DateTime.Now.DayOfWeek.ToString();
        }
        static string MagyarNap()
        {
            //MINDEN ágon vissza kell térni a föüggvényeknek
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday: return "Vasárnap";
                case DayOfWeek.Monday: return "Hétfő";
                case DayOfWeek.Tuesday: return "Kedd";
                case DayOfWeek.Wednesday: return "Szerda";
                case DayOfWeek.Thursday: return "Csütörtök";
                case DayOfWeek.Friday: return "Péntek";
                case DayOfWeek.Saturday: return "Szombat";
                //pl. default nélkül hibás
                default: return null;
            }
        }
        static int EgyszeruOsszeadas(int x, int y)
        {
            return x + y;
        }
        private static int EgyszeruOsszeadas(int x, int y, int z)
        {
            return x + y + z;
        }
        static int OsszegA1(int[] t)
        {
            return t.Sum();
        }
        static int OsszegA2(params int[] t)
        {
            return t.Sum();
        }
        private static void Valtoztagt(ref int x)
        {
            x = 33;
            //Console.WriteLine(x);
        }
        static void Kimeno(out int szam)
        {
            //mindenféleképpen [újra] értéketz kell adni az elején az out-os paraméternek
            //különben szintaktikailag hibás
            szam = 30;
        }
    }
}
