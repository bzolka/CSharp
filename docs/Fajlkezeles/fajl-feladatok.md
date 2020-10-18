# Fájkezelés - Feladatok

## Feladat 1

Írj egy függvényt, mely egy szöveges fájl tartalmát átmásolja egy másik fájlba. Két paramétere van: útvonal a forrásfájlhoz, illetve útvonal a célfájlhoz. Felteheted, hogy a fájlok nem nagyok, vagyis használhatod a File.ReadAllText és File.WriteAllText függvényeket.

## Feladat 2

Ugyanaz, mint az első feladat, de ez a megoldás legyen takarékos a memóriával, működjön akkor is, ha óriási fájl kell másolni. Azt felteheted, hogy a fájl sok sorból áll (vagyis soronként célszerű a fájlt másolni). A megoldásod kétféleképpen is készítsd el:

1. A kódot külön osztályba tedd. A fájlmásolást legyen a lehető legegyszerűbb használni, ne kelljeken hozzá az osztályból példányt létrehozni.
2. A kódot külön osztályba tedd. A objektum létrehozáskor lehessen megadni a forrás és cél útvonalat, a másolást pedig egy külön Masol függvény hajtsa végre.
