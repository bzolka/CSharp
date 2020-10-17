# Inicializálás alapok

## Objektumok inicializálása (object initilizer)

Részletes angol leírás: [Object initilizers](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers)

Alepelve: a **az objektum new-val történő létrehozásakor { } között kell megadni a tagváltozók/tulajdonságok értékét**.
Ezzel azt nyerjük, hogy ha nincs az osztálynak ezen tagokat inizializáló konstruktora, akkor is kezdőértéket tudunk adni ezen tagoknak a létrehozáskor.

A példákban ezen osztályokat használjuk:

```csharp
public class Cim
{
    public string Varos;
    public string Utca;
}

// Ebből fogunk gyűjteményeket létrehozni
public class Szemely
{
    public string Nev;
    public int Kor;
    public Cim Cim; // A fenti Cim osztály objektuma !!!
}
```

Példák
```csharp

// Pont úgy hozzuk létre a new-val az objektumot, mint eddig
// csak folytatjuk a sort {}-lel, és közte megadjuk a tagok értékét
Cim cim1 = new Cim() { Varos = "Budapest", Utca = "Diófa" } ;
Cim cim2 = new Cim() { Varos = "Szeged", Utca = "Tiszafa" } ;

// Ugyanez, de több sorba törve (általában így szoktuk)
Cim cim1 = new Cim()
{
    Varos = "Budapest",
    Utca = "Diófa"
};
Cim cim2 = new Cim()
{
    Varos = "Szeged",
    Utca = "Tiszafa",
} ;

// A Szemely osztálynak van Cim tagja, ezt is tudjuk beágyazott módon inicializálni:

```csharp
Szemely sz1 = new Szemely()
{
    Nev = "Joe",
    Kor = 12
    Cim = cim1; // a cim1-et már fent létrehoztuk!
}

// Lehetőség van a beágyazott objektumot (Cim) helyben inicializálni
// Nagyon gyakran így dolgozunk! Ezt tetszőleges mélységben lehetséges,
// itt egyszintű a mélység.
Szemely sz1 = new Szemely()
{
    Nev = "Joe",
    Kor = 12
    Cim = new Cim ()
    {
        Varos = "Miskolc",
        Utca = "Szeretet",
    };
}
```

### Összefoglaló

Arra, hogy objektumokat adott állapottal, tagváltozó kezdőértékekkel hozzunk létre, két lehetőségünk is van:

* **Konstruktort** írunk és abban állíjuk be a tagváltozók kezdőértékét. Ez a klasszikus, rugalmas, minden körülmények között jól használható megoldás.
* Az itt ismertetett **objektum inicilizálást** használjuk. Ez egyszerűbb tud lennni (nem kell konstruktort írni), de korlátozottabban használható:

    * Csak akkor működik, ha a tagváltozók/tulajdonságok publikusak, amit viszont a gyakorlatban sokszor elkerülünk, és inkább védett tagokkal dolgozunk (azért, hogy az objektumot ne lehessen inkonzisztensé tenni)
    * Míg a konstruktorba tetszőleges inicializáló kódot tudunk tenni (pl. validálni, más függvényeket hívni, stb.), itt csak a tagváltozók kezdőértékét tudjuk megadni.
    * A kontruktorral jobban ki tudjuk kényszeríteni a konzisztenciát. Pl. egy Kör oszály esetében el tudjuk várni, hogy létrehozáskor kötelező legyen megadni a sugarat, sőt, ha a létrehozó a new paraméterében negatív értéket ad meg, akkor ezt tudjuk ellenőrizni és hibával (kivétellel) jelezni.

### Megjegyzés

A LINQ Select használatakor is jól tud jönni az objektum inicializálás, amikor a => után új, de már adott módon inicializált objektumokat kell létrehozni, és az osztályban nincs ehhez konstruktor. Pl.:

```csharp
// Ezek csak egyszerű stringek!
string[] varosNevek = new string[] { "Budapest", "Szeged", "Miskolc" };

// Minden városnévhez gyártsunk le egy a városnak megfelelő címet, az utca legyen "ismeretlen".
Cim[] cimek = varosNevek
                .Select( varosnev => new Cim()
                {
                    Varos = varosnev,
                    Utca = "ismeretlen"
                }
            );


```

## Gyűjtemények inicializálása

Részletes angol leírás: [Collection initializers](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#collection-initializers)

Alepelve: a **tömb, lista, stb. new-val történő létrehozásakor { } között kell megadni az elemeket**.

Int tömb példa:

```csharp
int[] szamok = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
```

Int lista példa:

```csharp
List<int> szamok = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
```

A gyűjtemény elemei lehetnek objektumok is:

```csharp
// Ebből fogunk gyűjteményeket létrehozni
public class Szemely
{
    public string Nev;
    public int Kor;


    public Szemely()
    {
    }

    public Szemely(string nev, int kor)
    {
        this.Nev = nev;
        this.Kor = kor;
    }
}

...

// Minden egy sorban
Szemely[] szemelyek = new Szemely[] { new Szemely("Joe", 20), new Szemely("Jill", 23) };

// Általában több sorba törve szoktuk írni, jobban átlátható
Szemely[] szemelyek = new Szemely[]
{ 
    new Szemely("Joe", 20),
    new Szemely("Jill", 23)
};

// Az egyes elemeket objektum inicializálással is létre lehet hozni (kombináljuk a
// gyűjtemény és objektum inicializálást)
Szemely[] szemelyek = new Szemely[]
{
    new Szemely()
    {
        Nev = "Joe",
        Kor = 20
    },
    new Szemely()
    {
        Nev = "Jill",
        Kor = 23
    }
};

```