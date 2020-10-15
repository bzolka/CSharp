using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDemo
{
    namespace T1
    {
        class Teglalap
        {
            public double Szelesseg;
            public double Magassag;

            public double Terulet()
            {
                return Szelesseg * Magassag;
            }
        }
    }

    namespace T2
    {
        class Teglalap
        {
            public double Szelesseg;
            public double Magassag;

            public int Szamlalo;

            public Teglalap()
            {
                Szamlalo++;
            }

            public double Terulet()
            {
                return Szelesseg * Magassag;
            }
        }
    }


    namespace T3
    {
        class Teglalap
        {
            public double Szelesseg;
            public double Magassag;

            public static int Szamlalo;

            public Teglalap()
            {
                Szamlalo++;
            }

            public double Terulet()
            {
                return Szelesseg * Magassag;
            }
        }
    }

    namespace T4
    {
        class Teglalap
        {
            public double Szelesseg;
            public double Magassag;

            private static int Szamlalo;

            public static int SzamlaloErtek()
            {
                return Szamlalo;
            }

            public Teglalap()
            {
                Szamlalo++;
            }

            public double Terulet()
            {
                return Szelesseg * Magassag;
            }
        }
    }

}
