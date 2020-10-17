# Inicializálás feladatok

## Feladat 1

Írj egy `Kerek` (mint járműkerék) osztályt. Két tulajdonsága van: `int Atmero`, `double Nyomas`. Írj egy `Auto` osztály, melynek van négy kereke (`Kerek` tömb) és színe (`string Szin`).

Hozz létre egy Auto objektumot egyetlen inicializáló kifejezéssel (mind a négy kerekével egyszerre). Az autó színe kék, van négy kereke. A kerekek átmérője legyen ugyanaz, de a nyomás legyen mindnél kicsit más.

## Feladat 2

Adott az alábbi kód:

```csharp
public class Szampar
{
    public int Szam1;
    public int Szam2;
}

// A Main függvényben:

Szampar[] szamparok = new Szampar[]
{
    new Szampar() { Szam1 = 2, Szam2 = 3},
    new Szampar() { Szam1 = 4, Szam2 = 8},
    new Szampar() { Szam1 = 10, Szam2 = 20}
};

```

Írj egy `Teglalap` oszályt, melynek van `Szelesseg` és `Magassag` tagja. Konstruktort ne írj hozzá.
A `Main` függvényben a fenti szamparok mindegyike alapján állíts elő egy tégalalapot egy `Tegalap` listában, minden téglalap esetén a szelesség az adott számpár első tagjának duplája, a magasság pedig az adott számpár második tagjának négyzete legyen.
A megoldásodban ne használj semmilyen ciklust! (gondolj arra, hogy egy számpár gyűjteményt kell leképezni egy másik gyűjteményre, mit is szoktunk erre használni).