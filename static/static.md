# Statikus tagok

Induljunk ki egy olyan osztályból, melynek van két közönséges tagváltozója és tagfüggvénye (művelete):

```csharp
class Teglalap
{
    public double Szelesseg;
    public double Magassag;

    public double Terulet()
    {
        return Szelesseg * Magassag;
    }
}
```

Az alábbiakban létrehozuk a Téglalap osztályból két egymástól független `t1` és `t2` nevű téglalap objektumot, eltérő szélesség és magasság értékekkel, majd kiírjuk ezek területét a konzolra.

```csharp
static void Main(string[] args)
{
    Teglalap t1 = new Teglalap();       // #1
    t1.Szelesseg = 10;
    t1.Magassag = 20;
    Console.WriteLine( t1.Terulet() );

    Teglalap t2 = new Teglalap();       // #2
    t2.Szelesseg = 20;
    t2.Magassag = 30;
    Console.WriteLine(t2.Terulet());

}
```

### Statikus tagváltozó

A feladat legyen a következő. Tartsuk nyilván egy számlálóban, hogy hány objektumot hoztunk létre a Teglalap osztályból. Ha bárhol a programban létrehozunk egy új Téglalap objektumot, akkor ennek a számlálónak eggyel nőnie kell. A fenti Main függvény példát nézve, amíg a `// #1` megjegyzéssel ellátott sorban az objektumot nem hoztuk létre, addig a számláló értéke 0, ezt követően 1, majd a `// #2` sor után 2 kell legyen.
Egy nagy, komplex alkalmazásban sok ezer helyen hozhatunk létre Teglalap objektumot, nem akarunk minden helyen számlálót növelni, csak egy központi helyen. Így tegyük bele ezt a számlálót magába a Teglalap osztályba, és növeljük annak konstruktorában, hiszen a konstruktor pont akkor hívódik, amikor egy új objektum létrejön:

```csharp
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
```

Ez így még nem lesz jó. A probléma az, hogy a Szamlalo egy közönséges tagváltozó, minden téglalap objektumhoz külön értéke lesz 0 kezdőértékkel (a fenti példánkban a `t1` és `t2` objektumoknál külön-külön), pont úgy, mint a Szelesseg és Magassag tagváltozók esetén. Ehelyett nekünk egy olyan változó kell, ami nem Teglalap objektumonként van, hanem minden Teglalap objektumra közös, magához az osztályhoz tartozik egyetlen érték, és már akkor is létezik, amikor még egyetlen objektumot sem hoztunk létre (ekkor az értéke esetünkben 0).
Ehhez a Szamlalo tagot statikussá kell tenni, elé kell írni a static kulcsszót:

```csharp
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
```

Így a `Szamlalo` már az osztályhoz tartozik  (nem objektumonként foglalódik neki tárhely), minden objektumára közös, és akkor is léterzik, ha még egy `Teglalap` objektumot sem hoztunk létre.

Az ilyen változók eléréséhez nem kell objektumot létrehozni, hanem az osztály nevén keresztül érjük el a "."-tal, a példánkban így: `Teglalap.Szamlalo`

A teljes példa, mely ki is írja több helyen is a számláló értékét.

```csharp
static void Main(string[] args)
{
    int teglalapokSzama = Teglalap.Szamlalo;
    Console.WriteLine(teglalapokSzama);  // 0-t ír ki

    Teglalap t1 = new Teglalap();
    Console.WriteLine(Teglalap.Szamlalo); // 1-et ír ki
    t1.Szelesseg = 10;
    t1.Magassag = 20;
    Console.WriteLine(t1.Terulet());

    Teglalap t2 = new Teglalap();
    Console.WriteLine(Teglalap.Szamlalo); // 2-t ír ki
    t2.Szelesseg = 20;
    t2.Magassag = 30;
    Console.WriteLine(t2.Terulet());

}
```

### Statikus tagfüggény

A megoldásunk még nem tökéletes. A `Szamlalo` tag publikus a `Teglalap` osztályban. Így bárhol  valaki véletlen vagy szándéskosan elronthatja a számláló értékét, pl. ki tudja nullázni az alábbis sorral, akkor is, ha már volt belőle objektum, így értéke hamis lesz:
`Teglalap.Szamlalo = 0;`

Ezt úgy tudjuk megakadályozni, hogy a `Szamlalo`-t a `Teglalap` osztályban védetté, priváttá tesszük, ekkor ha más osztályban próbáljuk megváltoztatni az értékét, akkor a kód le sem fordul (a privát tagokhoz csak az adott osztály férhet hozzá, esetünkben `Teglalap`, ez persze a normál, nem statikus tagokra is igaz).

```csharp
class Teglalap
{
    public double Szelesseg;
    public double Magassag;

    private static int Szamlalo;

    public Teglalap()
    {
        Szamlalo++;
    }

    public double Terulet()
    {
        return Szelesseg * Magassag;
    }
}
```

Most már nem lehet elrontani más osztályból a számlálót. De mivel private, lekérdezni sem lehet már. Ez probléma, hiszen az pont célunk volt, hogy az aktuális számláló értéket le lehessen kérdezni, bárhonnan, pl. a Main függvényből is, ahogy azt eddig is tettük. A megoldás egyszerű: vezezzünk be egy tagfüggvényt (legyen a neve SzamlaloErtek), ami publikus, és le lehet vele kérdezni a védett Szamlalo értékét:

```csharp
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
```

A `SzamlaloErtek` tagfüggvényt **statikussá** is tettük a `static` kulcsszóval! Ez nagyon fontos, hiszen a statikus tagváltozókhoz hasonlóan csak így tudjuk meghívni objektumok nélkül az osztály nevén keresztül (akár akkor is, ha még egy objektum sem létezik belőle): `Teglalap.SzamlaloErtek()`

A Main függvényt is alakítsuk át, hogy ezt a statikus tagfüggvényt használja:

```csharp
static void Main(string[] args)
{
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
```

Statikus tagfüggvényt már jópár alkalommal használtunk. Pl. a Console.WriteLine() esetén. A Console egy beépített osztály, a WriteLine ennek egy statikus tagfüggvénye. Ha nem lenne statikus, akkor csak objektumra lehetne hívni, vagyis előbb létre kellene hozni a new-val egy Console objektumot, így:

```csharp
Console c1 = new Console();
c1.WriteLine();
```

Ez itt feleslegesen macerás lenne, mi nem akarunk különböző `Console` objektumokkal bajlódni.
Hasonló a beépített `Math` osztály is, ennek is egy csomós statikus tagfüggvénye van, így kényelmesen a `Math.Abs(-12)`, nem kell `Math` objektumokat létrehozni. Ez így kényelmesebb, és értelmesebb is, hiszen a Math osztálynak nincsenek állapotot adó tagváltozói, szemben pl. a `Teglalap` osztályunkkal, aminek van, hiszen a `Szelesseg` és `Magassag` esetén fontos, hogy az minden `Tegalalap` objektumra külön tárolódjon.

Ilyen a `string.Join(",", elemek)`, ahol a '.'-t előtt a string a string osztály neve (Megjegyzés: C#-ban a kis és nagybetűvel kezdődő string/String ugyanazt jelenti.)

Az alkalmazások belépési pontja, a Program osztály Main függénye is statikus.

### Szabályok

Fontos: **Statikus tagfüggvényből a normál (vagyis nem statikus) tagváltozókat és tagfüggvényeket nem lehet elérni.**

Ezt meg kell tanulni, mert különben gyakran beleszalad az ember. De egy példa érthetővé is teszi:

```csharp
class Teglalap
{
    public double Szelesseg;
    public double Magassag;

      public static double Terulet()
    {
        return Szelesseg * Magassag;
    }
}
```

A példában a Terulet() statikus tagfüggvény, ebből próbálunk elérni két nem statikus tagot (Szelesseg, és Magassag). Mivel a Terulet() statikus, nem objektumokre, hanem a Teglalap osztályra tudjuk meghívni:

```csharp
double ter = Teglalap.Terulet();
```

A probléma az, hogy a `Terulet()` előtt nem objektum, hanem osztály áll, így amikor a Terulet() függvényben hivatkozunk a nem statikus Szelesseg és Magassag tagokra, akkor azok melyik tégalalap objektum szélességét és magasságát is jelentenék? Még az is lehet, egyetlen Teglalap objektum sem létezik ekkor. Ha a Terület() hívásakor a '.' előtt egy adott teglalap objektum állna, akkor adná magát, de így ennek nincs értelme.

A másik irányba nincs ilyen megkötés (ez is logikus): **nem statikus tagfüggvényből statikus tagváltozókat és tagfüggvényeket el lehet érni.**

### Feladat

1. Írj egy Matek osztályt, melynek van egy Osszead és Kivon művelete (melyek visszatérnek két eégsz szám összegével, ill. különbségével). A Matek osztályt kényelmesen lehessen használni, ne kelljen ehhez objektumokat a new-val létrehozni. Mutass példákat a kér művelet használatára.

2. Írj egy Bomba osztályt. Minden bombáról rátolni kell a robbanóerejét (int) és fel felrobbant-e (bool). Egy bombát felrobbantan a Robban() műveletével lehet, ez a felrobbant állapotát igazba teszi. Az alkalmazásban lekérdezhetővé kell tenni, hogy összesen hány bomba robbant fel! Ennek nyilvántartását/lekérdezhetőségét rá lehetne bízni egy külön osztályba, de a gyakorlás kedvéért építsd be magába a Bomba osztályba. A megoldásod teszteld a Main függvényben: hozz létre pár bombát, robbantsd fel és pár helyen írd ki a felrobbant bombák darabszámát!