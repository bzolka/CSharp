string immutable

http://csharptk.ektf.hu/download/csharp-ekf.pdf
Fontos megemlíteni, hogy a C alapú nyelvekben a \ (backslash) karakter ún.: escape
szekvencia. Az s="C:\hello" karakter sorozat hibás eredményt szolgáltat, ha elérési útként
szeretnénk felhasználni, mivel a \h -nak nincs jelentése, viszont a rendszer megpróbálja
értelmezni. Ilyen esetekben vagy s="C:\\hello" vagy s=@"C:\hello" formulát használjuk! Az
elsı megoldásban az elsı \ jel elnyomja a második \ jel hatását. A második megoldásnál a @
jel gondoskodik arról, hogy az utána írt string a "C:\hello" formában megmaradjon az
értékadásnál, vagy a kiíró utasításokban.

http://aries.ektf.hu/~hz/wiki7/mprog1ea/adattipusok
A kezdeti időkben úgy találták, hogy 256 féle karakter elég sokmindenre elég, ezért az ASCII kódtábla 0..255 közötti számkódokat tartalmaz. Idővel ennyi karakter, szimbólum kevésnek bizonyult, ezért másik kódtáblát készítettek, melyet UNICODE-nak neveznek. Ez az eredeti ASCII tábla bővítményének fogható fel. A UNICODE táblázatban nem áll meg a sorszámozás 255-nél, hanem újabb szimbólumok felvezetése mellett tart 65535-ig (alap UNICODE tábla). A UNICODE kódolás ennél a valóságban sokkal összetettebb, további információk az alábbi linken olvashatók.

Mivel unicode sorszámok már 65535-ig tartanak, ezen sorszámok leírására nem elég 1 byte, hanem 2 byte kell. A C# char típusa a unicode kódtábla alapján működik, ezért egy karakterérték tárolásához 2 byte-ra van szükség a memóriában.