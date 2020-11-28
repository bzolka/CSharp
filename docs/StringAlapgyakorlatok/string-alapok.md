# Sztringkezelés alapok

## Alapjellemzők

A sztring típus neve `string` vagy `String`, a kettő ugyanazt jelenti.

### A string referencia típus

A sztring referencia típus, vagyis a sztring változók hivatkozások, melynek értéke lehet `null`, vagy több hivatkozás is hivatkozhat ugyanarra a sztringre.

```csharp
string s1 = "alma";
// Az s2 is az s1 által hivatkozott "alma" sztringre hivatkozik
string s2 = s1;

// Az s3 értéke null, nem hivatkozik semmilyen sztringre
string s3 = null;
```

Amikor egy függvényt meghívunk, csak a hivatkozás adódik át paraméterként (ez sokkal gyorsabb és hatékonyabb, mint a teljes sztring tartalmat átmásolni a függvény számára). A sztring ugyanakkor kicsit speciális, mert a többi referencia típussal (pl. osztályok) szemben nem kötelező a `new`-val létrehozni:

```csharp
// Lehet ugyan a new-val, de nem így szoktuk
string s1 = new string("alma");
// Így szoktuk, new nélkül
string s1 = "alma";
```

### Üres string

```csharp
// Lehet így: ""
string s1 = "";

// Vagy így, ez pontosan ""-nek felel meg
string s1 = string.Empty;
```

Lényeges, hogy az üres sztring és a null string teljesen mást jelent! Ha egy sztring hivatkozás `null`, akkor nem hivatkozik semmilyen sztringre, ha üres (""), akkor pedig egy nulla hosszú sztringre hivatkozik.

### String vs. char vs. char tömb

Egy string több karakterből áll. A string konstansokat dupla idézőjelbe tesszük (`"alma"`), a char konstansokat szimplába `'a'`);
A karakter tömb elemei megváltoztathatók, a string elemei nem (csak lekérdezhetők).

### A sztringek nem megváltoztathatók (immutable)

A sztringek **nem megváltoztathatók** (angolul úgy mondjuk, hogy a sztring "immutable" típus).

```csharp
string s1 = "alma";
// Ez nem működik, a []-szel csak olvasni lehet, írni nem!
s1[0] = 'b';
```

Ha meg kellene változtatni egy sztring tartalmát, két fő alternatív út van:

I. Az első lehetőség, ha **string helyett karakter tömböt (char[]) használunk**. Vagy már eleve `char[]`-öt hozunk létre, vagy ha sztringből kell kiindulni, akkor karakter tömbbé alakítjuk és a végén vissza (ha szükséges):

```csharp
// cseréljük le az első betűt b-re
string s1 = "alma";
// Alakítsuk char[]-re
char[] karakterek = s1.ToCharArray();
// Ez már módosítható
karakterek[0] = 'b';
// Alakítsuk a karakter tömböt sztringgé
string s2 = new string(karakterek);
// Írjuk ki, "blma" lesz a kimenet
Console.WriteLine(s2);
```

A fenti kód alapján jegyezd meg, hogyan lehet sztringet karakter tömbbé alakítani (`ToCharArray()` művelet), illetve karakter tömböt sztringgé (ehhez létre kell hozni egy új sztringet a new-val, lásd fent a példában)!

II. De ritkábban szoktunk karakter tömbbel dolgozni. A másik lehetőség: nem megváltoztatjuk a sztringet (mert az nem lehet), hanem egy újat hozunk létre, mely a módosításnak megfelelő karaktereket tartalmazza. Így működik pl. a string `Replace` művelete is. A neve becsapós, nem az eredeti sztringet módosítja, hanem mindig egy új sztringet állít elő és azzal tér vissza. Íme egy példa a `Replace`-re:

```csharp
string s1 = "alma körte szilva";
// Cseréljük ki a "körte" részt "barack"-ra a string Replace használatával.

// 1. Próba (nem jó):
// Ennek semmi értelme: nem az s1 sztringet változtatja, 
// hanem visszaad egy új sztringet, de azt nem tároljuk el:
s1.Replace("körte", "barack");

// 2. Próba (jó):
// Ez a jó, s2-ben eltároljuk az új sztringet
string s2 = s1.Replace("körte", "barack");
// Ezt írja ki: "alma barack szilva"
Console.WriteLine(s2); ;

// Nézzünk egy objektumon belül string tagra példát:
class Szemely
{
    public int Kor;
    public string Nev;
}
...
Szemely szemely1 = new Szemely();
szemely1.Kor = 10;
szemely1.Nev = "István";

// Cseréljük le a személy1 nevében az "á"-t "a"-ra
// Ez így értelmetlen, mert visszaadja az új sztringet, de nem 
// kezdünk vele semmit:
szemely1.Nev.Replace("á", "a");
// Így a jó:
szemely1.Nev = szemely1.Nev.Replace("á", "a");
```

### Fontosabb string műveletek

Console-ra írás, Console-ról olvasás

* `Console.Write(string)` - Ez nem kezd új sort, ritkábban használt, de fontos!!!
* `Console.WriteLine(string)`
* `Console.ReadLine()`

Sztring adott részének kinyerése - `Substring`. Van egy és kétparaméteres változata is, az alábbi példában mindkettő szerepel:

```csharp
string s1 = "alma körte szilva";
// Egyparaméteres SubString, adott indextől a végéig minden 
// karaktert visszaad. Pl.:Substring
string subString = s1.Substring(s1.Length - 6);
// Ezt írja ki: "szilva"
Console.WriteLine(subString);

// 6. -tól 4 darab karaktert vesz
string subString2 = s1.Substring(6, 4);
// Ezt írja ki: "örte"
Console.WriteLine(subString2);
```

Sztring részének lecserélése - `Replace`

```csharp
string s1 = "alma körte szilva";
// Minden "körte" előfordulás cseréje "barack"-ra
s1 = s1.Replace("körte", "barack");
// Ezt írja ki: "alma barack szilva"
Console.WriteLine(subString);
```

Keresés stringben: `IndexOf`, `LastIndexOf` - TODO PÉLDA

Tartalmazás vizsgálat - `Contains`, `StartsWidth`, `EndsWidth` - TODO PÉLDA

### Speciális karakterek, escape karakterek, speciális sztringek

Alapesetben a `'\'` egy escape szekvencia kezdetét jelzi. Példák:

* `'\t'`: egy tab karakter
* `"alma\tszilva"`: alma és szilva tabbal elválasztva
* `"\r\n"`: Sortörés Windows operációs rendszerben. Két karakterből áll (`'\r'` és egy `'\n'` egymás után, melyek bájtbeli értéke 13 és 10).
* `"alma\r\nszilva\r\nkörte" `: három gyümölcs külön sorban (vagyis sortörésekkel elválasztva).

Adódik a kérdés, hogyan tudunk akkor egyáltalán `'\'` karaktert megadni stringben. Két lehetőség van:

* Megduplázzuk minden előfordulási helyén, pl. `string fajlUtvonal = "c:\\temp\\gyumolcsok.txt"`
* A `'@'` karaktert a szting elé írva kikapcsoljuk az escape-elést, ekkor nem kell duplázni, pl.: `string fajlUtvonal = @"c:\temp\gyumolcsok.txt"`

### Konverzió sztringbe

C#-ban minden típusra meghívható a `ToString()` művelet, ami az adott változót/objektumot sztringgé alakítja:

* Az **egyszerű beépített típusoknál** (`int`, `double`, stb.) a `ToString()` magában is jól használható
* **Saját típusoknál (osztály, struktúra)**: a ToString nem tudja, hogyan kell az objektumokat sztringgé alakítani, így alapesetben a `ToString()` csak az objektum típusát írja ki. Ezen legelegánsabban úgy tudunk segíteni, ha me az igényünknek megfelelő felülírjuk a `ToString()` függvényt az osztályunkban/struktúránkban.

    ```csharp
    class Szemely
    {
        public int Kor;
        public string Nev;
    }
    ...
    Szemely szemely1 = new Szemely();
    szemely1.Kor = 10;
    szemely1.Nev = "István";
    string sz = szemely1.ToString();
    // Csak a típust írja ki, pl: Stringek.Szemely
    Console.WriteLine(sz);
    ```

    Most írjuk felül a `ToString()` műveletet a `Szemely` osztályban (publikus kell legyen és az **override** szót is ki kell írni):

    ```csharp hl_lines="6-11 17 19"
    class Szemely
    {
        public int Kor;
        public string Nev;

        // Fontos: az override szór is ki kell írni!!!
        public override string ToString()
        {
            // A saját igényünknem megfelelően formázzuk az adatokat
            return "Kor: " + Kor + ", Nev: " + Nev;
        }
    }
    ...
    Szemely szemely1 = new Szemely();
    szemely1.Kor = 10;
    szemely1.Nev = "István";
    // Az általunk megírt ToString()-et hívja
    string sz = szemely1.ToString();
    // Ezt írja ki: "Kor: 10, Nev: István"
    Console.WriteLine(sz);
    ```

* **Gyűjtemény (tömb/lista/stb.)**: alapesetben csak tömb/lista típusát írja ki a `ToString()`. Vagy `foreach`-csel menjünk végig az elemeken és egyesével hívjunk `ToString()`-et, vagy sok esetben jól használható a `string.Join(szeparátor, elemek)`:

    * A `szeparátor` egy string vagy karakter (a string nem minden esetben támogatott?).
    * Az `elemek` lehet
       * sztring gyűjtemény (pl. tömb, lista).
       ```csharp
        string[] gyumolcsok = new string[] { "alma", "körte", "szilva" };
        string gyumolcsokEgyben = string.Join(",", gyumolcsok);
        // Ezt írja ki: "alma,körte,szilva"
        Console.WriteLine(gyumolcsokEgyben);
       ```
       * Vagy lehet bármilyen elemtípusú, akkor ToString()-et fog minden elemre hívni. Ez egyszerű típusok (pl. int, double) teljesen jól működik.
       ```csharp
        int[] szamok = new int[] { 12, 23, 11 };
        string szamokEgyben = string.Join(",", szamok);
        // Ezt írja ki: "12,23,11"
        Console.WriteLine(szamokEgyben);
       ```
       * Ha az elemek típusa valamilyen saját osztály/struktúra, egy jó irány ebben az esetben `ToString()` felülírása az osztályunkban, erre fent láttunk példát.
       * Ha az elemtípus nem string, a `Select()`-tel is leképezheted őket sztringre (ha nem írod meg pl. a ToString-et). 
       ```csharp
       class Szemely
        {
            public int Kor;
            public string Nev;
        }
        ...

        // A szemelyek tömbbe két személyt felveszünk:
        Szemely[] szemelyek = new Szemely[]
        {
            new Szemely { Kor = 12, Nev = "István" },
            new Szemely { Kor = 15, Nev = "Géza" }
        };

        // Gyársunk egy sztringet, melyben minden személy adata benne van külön 
        // sorokban, de egyetlen stringben
        // Belülről kifele érdemes haladni:
        // * a Select-tel a minden személyt egyesével leképezünk stringre
        // * majd a string.Joinnal egyetlen sztringbe fűzzük
        string szemelyekEgybenString =
            string.Join("\r\n", szemelyek.Select(sz => "Kor: " + sz.Kor + " Nev: " + sz.Nev).ToArray());
        // Ezt írja ki:
        // Kor: 12 Nev: István
        // Kor: 15 Nev: Géza
        Console.WriteLine(szemelyekEgybenString);
       ```

### Beolvasás/konverzió sztringből

Az elemi típusok (`int`, `double`, stb.) többsége a `Convert` osztály segítségévek állítható elő sztringből.

Ha egy sztringben szeparátorral elválaszott egyszerű elemek vannak, akkor a Split művelettel lehet a szeparátor mentén vágni és egy string tömbben az elemeket megkapni:

```csharp
string sor = "alma,körte,szilva";
// A gyumolcsok egy háromelemű tömb
string[] gyumolcsok = sor.Split(',');
```

FONTOS: a szeparátort **karakterben** kell megadni, ez minden C# változatban működik. A legújabb C# változatok már sztringet is elfogadnak, ez különösen jól jön akkor, ha pl. sortörések mentén kell vágni:

```csharp
string sor = "alma\r\nkörte\r\nszilva";
// A gyumolcsok egy háromelemű tömb
string[] gyumolcsok = sor.Split('\r\n');
```

Megjegyzés haladóknak: a régi C#-ban is lehet sztring a szeparátor, egy string[]-öt és egy plusz opció paramétert is meg kell adni, az online leírásban érdemes megnézni, ha szükség lenne rá.

### Formázott sztringek (sztringek összefűzése, formázása)

Gyakran van igény arra, hogy egy sztringbe több adatot belefűzzünk, "formázzunk".  A legegyszerűbb megoldás, ha a `'+'`-szal összefűzzük a sztring részeket, íme egy példa:

```csharp
string nev = "István";
int kor = 35;
string formazottString = "Név: " + nev + ", Kor: " + kor;
// Ezt írja ki: "Név: István, Kor: 35"
Console.WriteLine(formazottString);
```

A fenti megoldás működik, de kicsit nehezen átlátható, könnyű elrontani. Egy alternatív, modern megoldás a string interpoláció használata. A hangzatos néz mögött egy nagyon egyszerű a mechanizmusa , könnyű megszeretni. Az alábbi példa illusztrálja a használatát. A lényege az, hogy egyetlen sztringet használunk, melyben **{}** között beírjuk a **változókat**, amiket az adott helyre be akarunk kell helyettesíteni. Az fontos még, hogy a sztring elé ki kell írni a `'$'` jelet:

```csharp
string nev = "István";
int kor = 35;
// $-ral kezdjük, és {} között bármilyen változót megadva behelyettesítődik
// a változó értéke
string formazottString = $"Név: {nev}, Kor: {kor}";
// Ezt írja ki: "Név: István, Kor: 35"
Console.WriteLine(formazottString);
```

Egy harmadik lehetőség a `string.Format` statikus művelet használata. Ennél elegánsabb a fenti sztring interpoláció, de régebbi kódokban még találkozhatunk vele:

```csharp
string nev = "István";
int kor = 35;
// {} között számot adunk meg, a {0} helyébe a 0. paramétert írja be
//  (esetünkben nev), 
// az {1} helyébe az elsőt (esetünkben kor), stb.
string formazottString = string.Format("Név: {0}, Kor: {1}", nev, kor);
// Ezt írja ki: "Név: István, Kor: 35"
Console.WriteLine(formazottString);
```

## Egyebek (tisztázandó)

### ASCII karakterekkel munka (minden karakter egy szám is)

C#-ban minden karakter egy szám is, az adott karakter ASCII kódja. Erre építve hatékonyan lehet pár "trükkös" feladatot megoldani.
Pl. Az `'a'` ASCII kódja 97, az `'A'` kódja pedig 65.
Példa  annak eldöntése, valami betű-e (és nem szám, vagy speciális karakter), ha nem foglalkozunk az ékezetes karakterekkel:

```csharp
char c = 'a';

if ( (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') )
    Console.WriteLine("Betű");
```

```csharp
// Írjuk az alábbi c változó ASCII kódját
char c = 'a';
// 97-et ír ki
Console.WriteLine( (int)c );
```

### Case sensitive + ToLower/ToUpper

A sztringek ú.n. case sensitive-ek, vagyis a kis és nagybetűk megkülönböztetettek. Vagyis az `'a'` nem egyenlő az `'A'` karakterrel, vagy az "Alma" sem az "alma" sztringgel.
Egy sztringet csupa nagybetűssé alakítani a `ToUpper()`-rel, csupa kisbetűssé a `ToLower()`-rel lehet.

Ha például két sztringre a kis és nagybetűket nem megkülönböztetve szeretnénk eldönteni, egyenlők-e, akkor alakítsuk mindkettőt csupa kis vagy nagybetűssé, és így hasonlítsuk össze őket. Pl.:

```csharp
string s1 = "Alma";
string s2 = "alma";

if (s1.ToUpper() == s2.ToUpper())
   Console.WriteLine("Egyformák");
```

Ez azonban nem a leghatékonyabb módja a probléma megoldásának, helyette ez, vagy ehhez hasonló megoldás javasolt:

```csharp
string s1 = "Alma";
string s2 = "alma";

if (string.Equals(s1, s2, StringComparison.CurrentCultureIgnoreCase))
    Console.WriteLine("Egyformák");
```

### whitespace-ek eltávolítása

Gyakran van szükség arra, hogy a szting elején/végén levő space/tab karaktereket (ezek ún. whitespace kaarkterek) eltávolítsuk. Erre a string osztály `Trim` művelete való:

```csharp
string nev = "  Körte\t   ";
string whitespaceNelkul = nev.Trim();
// Ezt írja ki: "Körte"
Console.WriteLine(whitespaceNelkul);
```

### Sztring hossz

A sztring `Length` tulajdonsága adja vissza.


## Extra

http://csharptk.ektf.hu/download/csharp-ekf.pdf
http://aries.ektf.hu/~hz/wiki7/mprog1ea/adattipusok
A kezdeti időkben úgy találták, hogy 256 féle karakter elég sok mindenre elég, ezért az ASCII kódtábla 0..255 közötti számkódokat tartalmaz. Idővel ennyi karakter, szimbólum kevésnek bizonyult, ezért másik kódtáblát készítettek, melyet UNICODE-nak neveznek. Ez az eredeti ASCII tábla bővítményének fogható fel. A UNICODE táblázatban nem áll meg a sorszámozás 255-nél, hanem újabb szimbólumok felvezetése mellett tart 65535-ig (alap UNICODE tábla). A UNICODE kódolás ennél a valóságban sokkal összetettebb, további információk az alábbi linken olvashatók.

Mivel unicode sorszámok már 65535-ig tartanak, ezen sorszámok leírására nem elég 1 byte, hanem 2 byte kell. A C# char típusa a unicode kódtábla alapján működik, ezért egy karakterérték tárolásához 2 byte-ra van szükség a memóriában.
