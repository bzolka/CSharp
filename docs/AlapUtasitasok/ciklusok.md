# Ciklusok

## foreach

A legkényelmesebb, legegyszerűbb módja annak, hogy bármiyen gyűjteményen egyesével sorban előre haladva elérjük az elemeket. A gyakorlatban messze ezt használjuk a leggyakrabban.

Példa int tömb elemein való végigiterálásra:

```csharp
int[] szamok = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// Az "in" kulcsszó után megadjuk a gyűjteményt, amin végig akarunk menni.
// Az "in" kulcsszó előtt bevezetünk egy ELEM TÍPUSÚ változót, ennek
// tetszőleges nevet adhatunk (a példában int sz), ez a ciklus törzsében
// minden iterációban az adott elemet fogja tartalmazni.
foreach (int sz in szamok)
{
    Console.WriteLine( sz.ToString() );
}
```

Most tegyük fel, hogy a Szemely egy osztály, és ebből van egy listánk, ezen menjünk végig egyesével:

```csharp
Szemely[] szemelyek = new Szemely[] {  ... itt megadjuk a személyeket ... };

// Itt az elem típusa Szemely, szemely neven vezettük be
foreach (Szemely szemely in szemelyek)
{
    Console.WriteLine( szemely.Nev );
}
```

!!! hint
    Legegyszerűbben így tudsz létrehozni Visual Studio alatt: foreach + tab + tab (be kell írni, hogy foreach, majd kétszer tab-ot kell nyomni), majd megadni a változó típusát és nevét.

Részletesebb magyarázat és példák:

* http://aries.ektf.hu/~hz/wiki7/mprog1ea/foreach

## for

Leggyakrabban arra használjuk, hogy tömbön, listán lehet végigmenni, az elemeket az indexével elérve.

Ezt már ismered.

Példa, részletesebb magyarázat:

* http://aries.ektf.hu/~hz/wiki7/mprog1ea/for
* https://www.tutorialsteacher.com/csharp/csharp-for-loop

## while

Elöltesztelős ciklus.

```csharp
while (<feltétel>)
{
  <utasítások>  
}
```

Példa, részletesebb magyarázat:

* http://aries.ektf.hu/~hz/wiki7/mprog1ea/while
* https://www.tutorialsteacher.com/csharp/csharp-while-loop

## do while

Hátultesztelős ciklus, ritkán használjuk.

```csharp
do
{
  <utasítások>  
} while(<feltétel>);
```

Példa, részletesebb magyarázat:

* https://www.tutorialsteacher.com/csharp/csharp-do-while-loop
