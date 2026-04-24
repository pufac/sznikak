Szia! Tanulas vagyok, az egyetemi oktatósegéded. Ahogy kérted, a második és harmadik előadás anyagát – mivel szorosan összefüggnek a C# nyelvi eszközeivel – egy közös, átfogó jegyzetben dolgozom fel számodra.

---

## 2. Előadás: Nyelvi eszközök 1.

### Property (Tulajdonság)
[cite_start]Az objektumorientált elvek szerint a tagváltozókat nem tesszük publikussá a konzisztencia védelme érdekében[cite: 824]. [cite_start]A C# erre a **property** (tulajdonság) eszközt kínálja, amely a klasszikus getter/setter metódusok egyszerűsített változata[cite: 825, 826].

* [cite_start]**Felépítése:** Egy `get {}` és egy `set {}` ágból áll[cite: 828].
* [cite_start]**Láthatóság:** A getter vagy setter láthatósága szigorítható (pl. `public` property, de `private set`), így kívülről csak olvasható lesz[cite: 917, 918].
* **Auto-implementált property:** Ha nincs szükség validációra, a fordító generálja a háttérváltozót: `public string Name { get; set; [cite_start]}` [cite: 902-908].
* [cite_start]**Csak olvasható (Readonly):** Ha csak `get` ága van, vagy a setter `private`[cite: 930]. [cite_start]C# 6-tól kezdőérték is adható neki deklarációkor[cite: 910].

### Delegate (Delegát, Metódusreferencia)
[cite_start]A delegát egy **típusos függvénypointer**, amely objektumorientált és egyszerre több metódusra is mutathat[cite: 944, 950].

* [cite_start]**Használata:** Elsőként definiálni kell a típust (szignatúra + visszatérési érték), majd példányosítani egy metódussal [cite: 951-953].
* [cite_start]**Multicast:** A `+=` operátorral több metódust is felfűzhetünk rá, amik a híváskor sorrendben lefutnak [cite: 1017-1019].
* [cite_start]**Példa:** Egy általános rendező algoritmus (`HyperSort`) paraméterként kaphat egy delegátot, ami eldönti, melyik elem kisebb, így a rendező bármilyen típussal működik[cite: 970, 971].

### Event (Esemény)
[cite_start]Az események a **Publisher/Subscriber** (Kiadó/Feliratkozó) mintára épülnek, és a háttérben delegátokat használnak[cite: 1052, 1056].

* [cite_start]**Különbség a delegáthoz képest:** Az `event` kulcsszó extra védelmet ad: csak a tartalmazó osztály sütheti el, és kívülről csak a `+=` (feliratkozás) vagy `-=` (leiratkozás) használható [cite: 1170-1174].
* [cite_start]**Működés:** Amikor az esemény "elsül" (invokálás), minden feliratkozott metódus meghívódik[cite: 1054, 1063].

### Attribute (Attribútum)
[cite_start]Deklaratív metaadatok, amiket osztályokhoz, metódusokhoz kötünk[cite: 1178, 1179].
* [cite_start]**Példák:** `[Serializable]` (sorosítható osztály), `[Obsolete]` (elavult metódus, fordítási figyelmeztetést ad)[cite: 1184, 1185, 1193].
* [cite_start]**Reflection:** Futásidőben kiolvasható információk a kód szerkezetéről[cite: 1180].

### Érték és Referencia típusok (!)
[cite_start]Ez az egyik legfontosabb alapfogalom a .NET-ben[cite: 1216].

| Jellemző | Érték típus (Value type) | Referencia típus (Reference type) |
| :--- | :--- | :--- |
| **Kulcsszó** | [cite_start]`struct`, `enum`, alap típusok (int, bool) [cite: 1220, 1224] | [cite_start]`class`, `interface`, `string`, tömbök [cite: 1230, 1231] |
| **Tárolás** | [cite_start]Magát az értéket tartalmazza, általában a vermen (stack) [cite: 1219, 1224] | [cite_start]Mutató a felügyelt heap-re (halom) [cite: 1229] |
| **Másolás** | [cite_start]Érték szerinti (teljes másolat készül) [cite: 1225] | [cite_start]Referencia szerinti (csak a mutató másolódik) [cite: 1229] |
| **Null érték** | [cite_start]Nem lehet null [cite: 1253] | [cite_start]Lehet null [cite: 1229] |

---

## 3. Előadás: Nyelvi eszközök 2.

### A `var` kulcsszó
[cite_start]Lokális változóknál a típus megadása helyett használható, ha van inicializáló érték, amiből a fordító kitalálja a típust[cite: 1268, 1269]. [cite_start]Ez nem "gyenge típusosság", a típus a fordítás után fix marad[cite: 1271].

### Generics (Generikus típusok)
[cite_start]Lehetővé teszik, hogy egy osztályt vagy metódust úgy írjunk meg, hogy a felhasznált típust csak a használatkor adjuk meg[cite: 1275, 1278].

* [cite_start]**Miért jó?** Elkerülhető az `object` típussal járó kényszerű castolás, a futásidejű hibák és a **boxing/unboxing** (érték típusok heap-re csomagolása), ami lassítja a programot [cite: 1301-1318].
* [cite_start]**Kényszerek (Constraints):** A `where` kulcsszóval megköthetjük, milyen típusokat fogadunk el (pl. `where T : IComparable` – csak olyan T, ami tudja az összehasonlítást)[cite: 1511, 1514].


### Lambda kifejezések
[cite_start]Név nélküli (anonim) függvények, amiket a `=>` operátorral definiálunk[cite: 1537, 1545].
* [cite_start]**Szintaktika:** `(paraméterek) => törzs`[cite: 1546].
* **Típusai:**
    * [cite_start]*Expression lambda:* Egyetlen kifejezés, aminek az értékével visszatér: `x => x * x`[cite: 1557, 1558].
    * *Statement lambda:* Kapcsos zárójelek között több utasítás: `(x, y) => { return x + y; [cite_start]}`[cite: 1552, 1553].
* [cite_start]**Variable Capturing (Closure):** A lambda látja és használja a környezetében lévő lokális változókat, akkor is, ha az eredeti függvény már lefutott [cite: 1729-1732, 1762].

### Beépített delegátok: Func és Action
[cite_start]Nem kell saját delegát típusokat gyártani, a .NET ad kész megoldásokat[cite: 1652, 1696]:
* [cite_start]**`Func<T, TResult>`:** Mindig van visszatérési értéke (az utolsó típusparaméter)[cite: 1655, 1659].
* [cite_start]**`Action<T>`:** Mindig `void` (nincs visszatérési értéke)[cite: 1698].

### LINQ (Language-Integrated Query)
[cite_start]Gyűjtemények kezelése (szűrés, rendezés) deklaratív módon, lambda kifejezésekkel[cite: 1766, 1768].
* [cite_start]`Where()`: Szűrés[cite: 1779].
* [cite_start]`OrderBy()`: Sorbarendezés[cite: 1784].
* [cite_start]`Select()`: Transzformáció (projekció)[cite: 1786].

### További kényelmi eszközök
* [cite_start]**Partial Class:** Egy osztály definíciója több `.cs` fájlra vágható szét (hasznos generált kódnál)[cite: 1796, 1797, 1835].
* [cite_start]**Expression-bodied members:** Rövid propertyk/metódusok tömör megadása `=>` operátorral: `public int Age => DateTime.Now.Year - yearOfBirth;`[cite: 1836, 1849].
* [cite_start]**Object Initializer:** Objektum létrehozása és tulajdonságainak beállítása egyetlen utasításban: `new Person { Name = "Luke", Age = 17 };` [cite: 1855, 1856, 1862-1866].

Szeretnéd, hogy valamelyik részt (pl. az érték vs. referencia típusokat vagy a generikus kényszereket) jobban kifejtsem konkrét kódpéldákkal?