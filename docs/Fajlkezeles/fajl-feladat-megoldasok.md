# Fájlkezelés - Feladatok megoldása

## Feladat 1

Itt csak egy egyszerű, a `Main` függvényből is használható statikus függvényt írunk magában a Porgram.cs fájlban:

``` csharp
public static FileAtmasolo(string fajlutvonalbe, string fajlutvonalki)
{
    string szoveg = File.ReadAllText(fajlutvonalbe);
    File.WriteAllText(fajlutvonalki, szoveg);
}
```

## Feladat 2

### 2.1

Mivel itt az volt a kérés, hogy a lehető legegyszerűbben, példányosítás nélkül lehessen használni, a Masol függvényt statikussá tettük:

``` csharp
class FileAtmasolo
{
    public static void Masol(string fajlutvonalbe, string fajlutvonalki)
    {
        StreamReader olvaso = new StreamReader(fajlutvonalbe);
        StreamWriter iro = new StreamWriter(fajlutvonalki);

        string tar;
        while (!olvaso.EndOfStream)
        {
            tar = olvaso.ReadLine();
            iro.WriteLine(tar);
        }

        olvaso.Close();
        iro.Close();
    }
}
```

Használat:

``` csharp
string fajlutvonalbe = @"C:\4_Tarsalgo\ajto.txt";
string fajlutvonalki = @"C:\4_Tarsalgo\ajto2.txt";
// Mivel statikus, nem kell példányosítani, az osztály nevén keresztül hívható a `Masol` függvény:
FileAtmasolo.Masol(fajlutvonalbe, fajlutvonalki);
```

### 2.2

Itt az a cél, hogy a létrehozáskor me tudjuk adni az útvonalakat: ehhez kell egy megfelelő kontruktor. Ez két tagváltozóban eltárolja az útvonalakat. Azért, hogy a `Masol` függvényben, ami a tényleges másolást végzi, elérhető legyen. 

``` csharp
class FileAtmasolo
{
    string fajlutvonalbe;
    string fajlutvonalki;

    public FileAtmasolo(string fajlutvonalbe, string fajlutvonalki)
    {
        this.fajlutvonalbe = fajlutvonalbe;
        this.fajlutvonalki = fajlutvonalki;
    }

    public void Masol()
    {
        StreamReader olvaso = new StreamReader(fajlutvonalbe);
        StreamWriter iro = new StreamWriter(fajlutvonalki);

        string tar;
        while (!olvaso.EndOfStream)
        {
            tar = Console.ReadLine();
            iro.WriteLine(tar);
        }
        olvaso.Close();
        iro.Close();
    }
}

```

Használat:

``` csharp
string fajlutvonalbe = @"C:\4_Tarsalgo\ajto.txt";
string fajlutvonalki = @"C:\4_Tarsalgo\ajto2.txt";

// Mivel itt semmi nem statikus, létre kell hozni egy objektumot.
// A létehozás során átadjuk a két útvonalat, ezt az objektum
// tagváltozókban eltárolja
FileAtmasolo fileAtmasolo = new FileAtmasolo(fajlutvonalbe, fajlutvonalki);
// Az objektumra meghívjuk a Masol() műveletet, ez végzi a másolást
// Itt már nem adjuk meg az útvonalakat, mert a fileAtmasolo objektum a 
// a tagváltozóiban eltárolta, a Masol művelet ezt eléri.
fileAtmasolo.Masol();
```
