﻿using System;
using System.Linq;

namespace Stringek
{

    class Szemely
    {
        public int Kor;
        public string Nev;
        public override string ToString()
        {
            return "Kor: " + Kor + " Nev: " + Nev;
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            //string s1 = "alma körte szilva";
            //// Ennek semmi értelme: nem az s1 sztringet változtatja, 
            //// hanem visszaad egy új stringet, de azt nem tároljuk el:
            //s1.Replace("körte", "barack");

            //// Ez a jó, s2-ben eltároljuk az új stringet
            //string s2 = s1.Replace("körte", "barack");
            //// Ezt írja ki: "alma barack szilva"
            //Console.WriteLine(s2); ;


            //string s = string.Empty;

            //string s1 = "alma";
            //char[] karakterek = s1.ToCharArray();
            //karakterek[0] = 'b';
            //string s2 = new string(karakterek);
            //Console.WriteLine(s2);

            //string sor = "alma,körte,szilva";
            //string[] gyumolcsok = sor.Split(",");

            //string sor2 = "alma, körte, szilva";
            //string[] gyumolcsok2 = sor2.Split(',');


            //Szemely szemely1 = new Szemely();
            //szemely1.Kor = 10;
            //szemely1.Nev = "István";

            //string sz = szemely1.ToString();
            //Console.WriteLine(sz);

            //string[] gyumolcsok = new string[] { "alma", "körte", "szilva" };
            //string gyumolcsokEgyben = string.Join(",", gyumolcsok);
            //// Ezt írja ki: "alma,körte,szilva"
            //Console.WriteLine(gyumolcsokEgyben);

            int[] szamok = new int[] { 12, 23, 11 };
            string szamokEgyben = string.Join(",", szamok);
            // Ezt írja ki: "12,23,11"
            Console.WriteLine(szamokEgyben);

            Szemely[] szemelyek = new Szemely[]
            {
                new Szemely { Kor = 12, Nev = "István" },
                new Szemely { Kor = 15, Nev = "Géza" }
            };

            string szemelyekEgybenString =
                string.Join("\r\n", szemelyek.Select(sz => "Kor: " + sz.Kor + " Nev: " + sz.Nev).ToArray());
            Console.WriteLine(szemelyekEgybenString);

            string nev = "István";
            int kor = 35;
            // string formazottString = $"Név: {nev} , Kor: {kor}";

            string formazottString = string.Format("Név: {0}, Kor: {1}", nev, kor);

            // Ezt írja ki: "Név: István, Kor: 35"
            Console.WriteLine(formazottString);

            //string s1 = " színű";
            //string subString = s1.Substring(s1.Length - 6, 6);
            //Console.WriteLine(subString);

            //string s1 = "alma körte szilva";

            //// 6. -tól 4 darab karaktert vesz
            //string subString2 = s1.Substring(6, 4);
            //// Ezt írja ki: "örte"
            //Console.WriteLine(subString2);

            //string nev1 = "  Körte\t   ";
            //// az {1} helyébe az elsőt (esetünkben kor), stb.
            //string whitespaceNelkul = nev1.Trim();
            //// Ezt írja ki: "Körte"
            //Console.WriteLine(whitespaceNelkul);

            //char c = '0';

            //if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
            //    Console.WriteLine("Betű");

            //string s1 = "Alma";
            //string s2 = "alma";

            //if (string.Equals(s1, s2, StringComparison.CurrentCultureIgnoreCase))
            //    Console.WriteLine("Egyformák!");

            char c = 'a';

            // Írjuk a fenti c változó ASCII kódját
            Console.WriteLine((int)c);
        }
    }
}
