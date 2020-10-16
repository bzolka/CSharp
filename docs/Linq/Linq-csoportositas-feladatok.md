# LINQ - feladatok

Irányelvek:

* Próbáld is ki a megoldásod!
* A feladat szövegét írd a megoldásod fölé egy megjegyzésben
* az előző feladatot megoldását írd át, ahogy haladsz, hanem legyen meg mind külön!

## Kiindulás

Az alábbi osztályt használd a feladatok megoldása során:

```csharp
class Szinesz
{
    public int Szulev;
    public string Nev;

    // Ne adjuk át a szül. évét, mert már megvan tagváltozóban!
    public int EletkorSzamolo()
    {
        return DateTime.Now.Year - szulev;
    }

    public Szinesz(int szulev, string nev)
    {
        this.szulev = szulev;
        this.nev = nev;
    }
}

```

## Feladat 1

Bővítsd ki a `Szinesz` osztályt, minden színésznek legyen egy új tulajdonsága, egy string orszag, ahol született.

## Feladat 2

Írj egy függvényt (ha még nincs), amelyik előállít és visszaad egy tömbben 6 színészt. Mindenkinek más a neve; 1 színész szülessen 1975-ben, 2 1998-ban, 3 1980-ban; 1 születési helye Spanyolország, 2 USA, 3 Kanada.
A tömböt inicializálással hozd létre, ha lehet, vagyis az elemeket a létrehozáskor {} között add meg, ahogy egyszer mutattam.
Ezt a függvényt a később arra használjuk, hogy a LINQ lekérdezésekhez visszaadja a 6 tesztadatot.

## Feladat 3

a) Írj egy LINQ kifejezést, ami visszaadja azon színészeket egy tömbben, akik 1990 után születtek

b) Írj egy LINQ kifejezést, ami visszaadja azon színészek neveit egy listában, akik 1990 után születtek.

c) Állíts elő egyetlen sztringet, mely vesszővel elválasztva azon színészek születési évét tartalmazza (egyetlen sztringben), akik 1990 után születtek.

## Feladat 4 - csoportosítások

### a) Egyszerű csoportosítás születési hely szerint

Csoportosítsd a színészeket születési hely szerint, és állíts elő egy tömböt, melyben a születési helyek szerepelnek (minden csoportra egyszer). Ezt követően írd ki, vesszővel elválasztva ezen születési helyeket (ezt a kiírást egyetlen sorban oldd meg)!

**Magyarázat**: Tfh van 6 színész, sz1, sz2, …sz6.
A `szineszek.GroupBy(sz => sz.Orszag)` után, ha ország szerint csoportosítunk, 3 színész csoport lesz:

* Csop1:
    * Key: Spanyolország
    * Elemek: [sz1]
* Csop2:
    * Key: USA
    * Elemek: [sz2, sz3]
* Csop3:
    * Key: Kanada
    * Elemek: [sz4, sz5, sz6]

**Lényeges: minden csoporthoz egy kulcs tartozik (az ország, mert eszerint csoportosítottunk), és egy gyűjtemény a csoportban levő színészekről (mert színészekre hívtuk a GroupBy-t)**

### b) Csoportosítás születési hely szerint,  a kimenet minden csoportra: színészek tömbje

Csoportosítsd a színészeket születési hely szerint, és állíts elő egy tömböt, melyben az egyes csoportokban levő színészek találhatók. Ezt próbált elképzelni magadtól, és csak utána olvass tovább, mert itt kicsit súgni fogok… Vagyis a tömb első eleme az első csoport színészeit tartalmazza egy tömbben, a második eleme a második csoport szineszeit tartalmazza egy tömbben, és így tovább. Vagyis a kimenet egy olyan tömb lesz, melynek az elemi szinész tömbök. Nincs ebben semmi varázslat: tömb eleme bármi lehet, szám, string, osztály, vagy akár mint esetünkben is, másik tömb is:
**Kb. ilyesmiként kell elképzelni:  [ [sz1, sz2],  [sz3, sz5, sz6], [sz7] ]. Ez olyan tömb, melynek elemei tömbök, tömbök tömbjének is szoktuk mondani.**

### c) Csoportosítás születési hely szerint,  a kimenet minden csoportra: színészek neve vesszővel elválasztva

Csoportosítsd a színészeket születési hely szerint, és állíts elő egy tömböt, mely elemei a csoportban levő színészek neveit tartalmazzák, vesszővel elválasztva. Először próbáld ezt magadtól elképzelni, csak utána olvasd tovább, súgok …
A tömb elemei itt most stringek, ilyesmi kimenetet várunk, három elemű string tömböt: ["Béla, Józsi", "Jani, Juli, Géza", "Misi" ]

### d) Csoportosítás születési hely szerint,  a kimenet minden csoportra: ország (csoport kulcs) és a benne levő színészek

Hasonló, mint a b) volt, vagyis most is születési hely szerint csoportosítunk. A b)-nél, ha megnézed, megvolt a kimenetben a három csoport, mert a kimenet három elemű tömb volt, de nem tudtuk, melyik tömb elem/csoport melyik országhoz tartozott. Pl. a kimeneti tömb nulladik elemében volt két színész, **de nem tudtuk megmondani, mely ország csoportjába tartoztak**. Ezt fontos lenne, hogy értsd, ha nem, beszéljük meg! Mindenesetre ez így sokszor nem szerencsés. A cél az, hogy a kimenetben azt is tudjuk, mely csoporthoz tartoznak az elemek (esetünkben mely országhoz).
Ezt többféleképpen is meg lehet oldani. Picit gondolkozz azon, van-e ötleted… 
Meg lehet oldani KeyValuePair használatával is, de az a következő feladat lesz, most még hagyjuk. Első körben egy „nyersebb” megoldást nézünk, mert az sokszor általánosabb és jobban használható, csak egy kicsit munkásabb. A megoldás alapelve az, hogy bevezetünk egy új osztály, mely a kimenet egy csoportját (ami a tömb egy eleme) fogja reprezentálni. Mire is van szükség minden egyes csoportnál: az országnévre, illetve hozzá tartozó szinészek tömbjére. vagyis egy ilyen osztályt kell bevezetni:

```csharp
class SzineszCsoport
{
   public string Orszag;
   public Szinesz[] Szineszek;

   <Írj még egy konstruktort, minek van két paramétere,
    az ország és a szineszek, erre szükség lesz>
}
```

Ha ez megvan, akkor hasonlóan kell dolgozni, mint a b)-nél, csak a Select-ben a csoportokat nem Szinesz tömbre, hanem SzineszCsoport osztályra kell lepezni, egy ilyet kell a new-val létrehozni.
Egy picit próbálkozz, és beszéljük meg, ebben sokminden volt.

### e) Csoportosítás születési hely szerint,  a kimenet minden csoportra: ország (csoport kulcs) és a benne levő színészek életkora vesszővel elválasztva

Ugyanaz, mint az előző, csak a kimenetben az országokhoz nem a szinészek tömbjét, hanem a színészek életkorának vesszővel összefűzött évszámát szeretnénk látni. Tipp: vezess be egy SzineszCsoportEvekkel osztályt, ebben a string Orszag mellett nem szinesz tömb, hanem string evek legyen.

### f) Csoportosítás születési hely szerint,  a kimenet minden csoportra: ország (csoport kulcs) és a benne levő színészek, de most a beépített KeyValuePair-rel

Hasonló, mint a d) előző, csak itt nem akarunk új osztályt (SzineszCsoport osztály) bevezetni. De a célunk ugyanaz, vagyis legyen meg minden csoportra az ország is, valamint a benne levő színészek is. A megoldás elve az, hogy nem vezetünk be SzineszCsoport osztályt, hanem helyette a beépített KeyValuePair-t használjuk. Minden csoportnál a kulcs (vagyis a Key) az ország, hiszen eszerint csoportosítunk, a Value, a kulcshoz tartozó érték pedig … ezt próbáld kitalálni, hogy érdemes.

### g) Csoportosítás színésznév kezdőbetű alapján, sorrendezve

Csoportosítsd a színészeket aszerint, hogy milyen betűvel kezdődik a nevük. KeyValuePair-rel dolgozz. Az egyes csoportokban ne a csoportban levő színészeket, hanem a csoportban levő színészek neveit címeit tárold tömbben. A kimenet legyen sorrendezve a név kezdőbetű alapján!
