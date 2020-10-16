using System;
using StaticDemo.T4;

namespace StaticDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Teglalap t1 = new Teglalap();
            //t1.Szelesseg = 10;
            //t1.Magassag = 20;
            //Console.WriteLine( t1.Terulet() );

            //Teglalap t2 = new Teglalap();
            //t2.Szelesseg = 20;
            //t2.Magassag = 30;
            //Console.WriteLine(t2.Terulet());

            //int teglalapokSzama = Teglalap.Szamlalo;
            //Console.WriteLine(teglalapokSzama);  // 0-t ír ki

            //Teglalap t1 = new Teglalap();
            //Console.WriteLine(Teglalap.Szamlalo); // 1-et ír ki
            //t1.Szelesseg = 10;
            //t1.Magassag = 20;
            //Console.WriteLine(t1.Terulet());

            //Teglalap t2 = new Teglalap();
            //Console.WriteLine(Teglalap.Szamlalo); // 2-t ír ki
            //t2.Szelesseg = 20;
            //t2.Magassag = 30;
            //Console.WriteLine(t2.Terulet());

            int teglalapokSzama = Teglalap.SzamlaloErtek();
            Console.WriteLine(teglalapokSzama);  // 0-t ír ki

            Teglalap t1 = new Teglalap();
            Console.WriteLine(Teglalap.SzamlaloErtek()); // 1-et ír ki
            t1.Szelesseg = 10;
            t1.Magassag = 20;
            Console.WriteLine(t1.Terulet());

            Teglalap t2 = new Teglalap();
            Console.WriteLine(Teglalap.SzamlaloErtek()); // 2-t ír ki
            t2.Szelesseg = 20;
            t2.Magassag = 30;
            Console.WriteLine(t2.Terulet());
        }
    }
}
