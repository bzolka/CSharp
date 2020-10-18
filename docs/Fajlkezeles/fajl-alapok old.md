## Fájlok (állományok)

A program futása során sokszor adatokat állít elő, adatokat kér be, ezekkel számításokat végez. Gyakran van igény arra, hogy ezen adatokat valamilyen formában kiírjuk egy fájlban háttértárra (diszkre). Míg a memóriában tárolt adatok az alkalmazás újraindulása során elvesznek, a háttértáron levő adatok megmaradnak, még akkor is, ha a számítógép újraindul. Ezen felül a fájlok segítségével nagyon egyszerű módon tudnak alkalmazások egymással kommunikálni, adatot megosztani. Pl. az egyik alkalmazás kiírja az adatot egy fájlba, egy másik pedig beolvassa.

Minden fájlt egy útvonal azonosít, mely megmondja, mely meghajtón, annak milyen mappájában van a fájl. Pl.: c:\work\temp\gyumolcsok.txt.

A fájl tartalma, ha nagyon szigorúan nézzük, akkor bitek (igaz/hamis, 0/1) egymásutánja, mint minden a digitális világban. A számítógépek alcsony szinten csak a biteket értik, illetve a háttértárak is biteket tudnak nyersen tárolni.

Pl. egy fájl nyers tartalma lehet a következő bithalmaz:

```
01100001 01101100 01101101 01100001 00001101 00001010 01110011 01111010 01101001 01101100 01110110 01100001
```

Szukjuk a gondolatot, hogy **minden** fájl a dolgok legmélyén hasonlóképpen bitek sorozatából áll... A bitek a háttértáron gyakran folytatólagosan helyezkednek el, de mivel számunka ez teljesen átláthatatlan lenne, így 8 bitenként csoportosítva jelenítettük meg fent.
A gyakorlatban soha nem szoktunk fájlok tartalmával bitenként dolgozni. A biteket 8-as csoportokban dolgozzuk fel. 8 bit egy bájt. Egy bájt 0 és 255 között vehet fel értékeket. pl. a 00000000 bitsorozat bájtértéke 0, a 00000001-é 1, a 00000010-é 2, a 00000011-é 3, az 11111111-é pedig 255. A lényeg, hogy a fájlok tartalmára most már nem mint bitek, hanem fájlok sorozatára gondolunk. A fenti fájl példánk így néz ki bájtokkal reprezentálva (minden 8-as binárist átszámoltunk bájtra, ebben pédául a Windows-ban levő Számológép alkalmazás is segítségünkre lehet, csak át kell kapcsolni Programozó üzemmódra - érdemes kipróbálni):

```
97 108 109 97 13 10 115 122 105 108 118 97
```

Ez így más sokkal átláthatóbb. Mostantól úgy gondolunk minden fájlra, mint bájtok egymás után következő sorozatára. Pl. amikor egy kép fájról van szó, ezekbe a számokban a kép pixeljeinek színei vannak "belekódolva". Egy egyszerű szövegfájl esetén pedig ezek a számok a szöveg egyes karaktereit jelentik (erre még visszatérünk). Amikor valamilyen programozási nyelven fájlokat írunk és olvasunk nyersen, akkor bájtokat írunk ki és bájtokat olvasunk be. Pl. C# nyelven ki tudjuk írni egy bájl tömb tartalmát, vagy be tudunk olvasni fájlból részeket egy bájt tömbbe.

## Fájlkezelés általánosságában

Amikor valamilyen programozási nyelven fájlokkal dolgozunk, akkor lehetőségünk van:
* A fájl tartalmát olvasni.
* A fájl tartalmát írni (ez módosítja a tartalmat)
* Fájlt létrehozni, törölni, átnevezni, mozgatni, stb.

A fájl tartalmának olvasása/írása az alábbiaknak megfelelően történik:

1. Fájlt megnyitása
2. Tartalom olvasása vagy írása
    * C# kódból be tudunk olvasni adott poziciótól adott darabszámú bájtot (pl. mondhajuk, hogy a 10-edik bájttól kérünk 100-at), és az pl. egy bájt tömbbe kerül. Onnan tudjuk tovább alakítani számmá, sztringé, vagy ahogy értelmezni kívánjuk az adatokat. Arra vigyázni kell, hogy a fájl végén ne akarjunk túlolvasni (pl. ha 1000 bájlt van egy fájlban, ne akarjuk az 1001-ediket beolvasni.)
    * Adott pozíciótól ki tudunk írni adott darab bájtot (pl. mondhajuk, hogy a 10-edik bájttól kiírunk 100 általunk mehatározott bájtot). Amikor nem bájtot/bájt tömböt írunk ki, fájlba, hanem pl. számot, sztringet, vagy más típust, azt is először bájtokká kell alakítani a fájlba írás előtt (szerencsére a .NET számunkra ezt sokszor elrejti).
3. Fájl lezárása. Ez is fontos, mert ha elmarad, akkor lehet ki sem íródnak a módosítások, vagy a fájl zárolva lesz, így nem tudjuk más alkalmazásokból megnyitni, módosítani, törölni (ez attól függ, hogy nyitottuk meg a fájlt).

Kód és példa. Az alacsonyabb, bájtszintű fájlkezelésre ritkábban van szükség, így erre nem nézünk példákat. De itt van egyébként egy példa, az látszódik, hogy a File osztállyal nyitja meg a fájlt, és után byte tömbe teszi az adatot, és ezt írja ki a FileStream.Write műveletével (adott pozíciótól), az olvasás is bájtokkal dolgozik: https://docs.microsoft.com/en-us/dotnet/api/system.io.file.openwrite?view=netcore-3.1#examples  

## Szövegfájlok

A szövegfájlok is fájlok, csak éppen a tartalmuk szöveg, így pl. az egyszerű Jegyzettömb alkalmazással is meg lehet értelmesen jeleníteni a tartalmukat. Lényeges, hogy nem a fájl kiterjesztésétől lesz a fájl szöveges, hanem a tartalmától, bámilyen kiterjesztésű fájlba lehet szöveges tartalmat kiírni (de természetesen logikus ilyen esetben a .txt kiterjesztés használata, vagy pl. a csv, ha valamilyen szepatárorral elválasztott struktrált szöveges tartalom van a fájlban).
A szövegfájlban is bájtok vannak, csak ezek a bájtok szövegbeli karaktereket jelentenek. A klasszikus ASCII kódolású szövegfájlok esetén minden bájt pontosan egy karaktert jelent.

Nézzük a fenti példánkat, amikor a fájl tartalma a következő:

```
97 108 109 97 13 10 115 122 105 108 118 97
```

Próbáljuk ezt most szövegfájltként értelmezni, ennekmegfelelően egy ASCII táblázatban nézzük meg minden egyes bájtra, milyen karakter tartozik hozzá (pl. itt https://hu.wikipedia.org/wiki/ASCII):

```
a l m a CR LF s z i v l a
```


Vagyis egy CR+LF-vel elválasztott "alma" és "szilva". Egyben, ha mint C# string nézzük "alma\r\nszilva"
Ez bizony szöveges tartalom, vagyis egy szövegfájllal van dolgunk. Ha megnyitjuk a Jegyzettömb (Notepad) alkalmazásban, így néz ki:

![image](static-szamlalo.png)

 A tisztázandó még, hogy mia a 10 (CR) és 13 (LF) bájt a közepén. Egyszerűen arról van szó, hogy van egy sortörés is az alma után, amit Windows operációs rendszerben két speciális karakter jelöl. C#-ban '\r' és egy '\n' karakter, egy stringbe írva "\r\n". A '\r' számértéke 13, a '\n'-né 10.

Megjegyzés: Linux operációs rendszer alatt csak egy karakter használatos, a '\n'.

Megjegyzés: A '\n' és a '\n', bár C# nyelven a forráskódban két karakterrel jelöljük, csak egy bájt hosszú  mindkettő: a C# nyelven a \ egy escape szekvencia kezdetét jelöli, vagyis pl. a '\n' nem egy '\' és egy 'n' karakter egymásután, hanem a '\n' önmagában jelöl **egyetlen** speciális karaktert, melynek a számkódja 13.

A szövegfájlok írására/olvasására egyszerűbb lehetőségünk is van, mint bájtokkal, bájtömbökkel dolkgozni. A fájlt soronként írjuk (`StreamWriter` osztály `WriteLine` művelete) és olvassuk (`StreamReader` osztály `ReadLine` művelete). Mindig egyszerre egy sort írunk ki, illeve olvasunk be, string formájában.


A fájl tartalmának olvasása/írása az alábbiaknak megfelelően történik:

1. Fájlt megnyitása
2. A fájlban mindig van egy **aktuális fájlmutató**, mely alapesetben a fájl legelejére mutat, de bármelyik pozícióra rá tudjuk állítani (pl. célszerű a fájl végére állítani, ha a fájlhoz hozzáfűzni szeretnénk).
    * C# kódból be tudunk olvasni általunk meghatározott darabszámú bájtot, és az pl. egy bájt tömbbe kerül. Onnan tudjuk tovább alakítani számmá, sztringé, vagy ahogy értelmezni kívánjuk az adatokat. Arra vigyázni kell, hogy a fájl végén ne akarjunk túlolvasni (pl. ha 1000 bájlt van egy fájlban, ne akarjuk az 1001-ediket beolvasni.)
    * Amikor pl. C# kódból kiírunk N darab bájtot, az írás a fájlmutatótól kezdve történik, és a fájlmutató az kiírás végére kerül. Amikor nem bájtot/bájt tömböt írunk ki, fájlba, hanem pl. számot, sztringet, vagy más típust, azt is először bájtokká kell alakítani a fájlba írás előtt (szerencsére a .NET számunkra ezt sokszor elrejti).
3. Fájl lezárása. Ez is fontos, mert ha elmarad, akkor lehet ki sem íródnak a módosítások, vagy a fájl zárolva lesz, így nem tudjuk más alkalmazásokból megnyitni, módosítani, törölni (ez attól függ, hogy nyitottuk meg a fájlt).

Itt találsz jó magyarázatot és példákat szövegfájl írására és olvasására is: http://aries.ektf.hu/~hz/wiki7/mprog1ea/text_file

## További lényeges információk