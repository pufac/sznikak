Szia! Tanulas vagyok, az egyetemi oktatósegéded. Ahogy kérted, a második és harmadik előadás anyagát – mivel szorosan összefüggnek a C# nyelvi eszközeivel – egy közös, átfogó jegyzetben dolgozom fel számodra.

---

## 2. Előadás: Nyelvi eszközök 1.

### Property (Tulajdonság)
Az objektumorientált elvek szerint a tagváltozókat nem tesszük publikussá a konzisztencia védelme érdekében. A C# erre a **property** (tulajdonság) eszközt kínálja, amely a klasszikus getter/setter metódusok egyszerűsített változata.

* **Felépítése:** Egy `get {}` és egy `set {}` ágból áll.
* **Láthatóság:** A getter vagy setter láthatósága szigorítható (pl. `public` property, de `private set`), így kívülről csak olvasható lesz.
* **Auto-implementált property:** Ha nincs szükség validációra, a fordító generálja a háttérváltozót: `public string Name { get; set; }` .
* **Csak olvasható (Readonly):** Ha csak `get` ága van, vagy a setter `private`. C# 6-tól kezdőérték is adható neki deklarációkor.

### Delegate (Delegát, Metódusreferencia)
A delegát egy **típusos függvénypointer**, amely objektumorientált és egyszerre több metódusra is mutathat.

* **Használata:** Elsőként definiálni kell a típust (szignatúra + visszatérési érték), majd példányosítani egy metódussal .
* **Multicast:** A `+=` operátorral több metódust is felfűzhetünk rá, amik a híváskor sorrendben lefutnak .
* **Példa:** Egy általános rendező algoritmus (`HyperSort`) paraméterként kaphat egy delegátot, ami eldönti, melyik elem kisebb, így a rendező bármilyen típussal működik.

### Event (Esemény)
Az események a **Publisher/Subscriber** (Kiadó/Feliratkozó) mintára épülnek, és a háttérben delegátokat használnak.

* **Különbség a delegáthoz képest:** Az `event` kulcsszó extra védelmet ad: csak a tartalmazó osztály sütheti el, és kívülről csak a `+=` (feliratkozás) vagy `-=` (leiratkozás) használható .
* **Működés:** Amikor az esemény "elsül" (invokálás), minden feliratkozott metódus meghívódik.

### Attribute (Attribútum)
Deklaratív metaadatok, amiket osztályokhoz, metódusokhoz kötünk.
* **Példák:** `[Serializable]` (sorosítható osztály), `[Obsolete]` (elavult metódus, fordítási figyelmeztetést ad).
* **Reflection:** Futásidőben kiolvasható információk a kód szerkezetéről.

### Érték és Referencia típusok (!)
Ez az egyik legfontosabb alapfogalom a .NET-ben.

| Jellemző | Érték típus (Value type) | Referencia típus (Reference type) |
| :--- | :--- | :--- |
| **Kulcsszó** | `struct`, `enum`, alap típusok (int, bool)  | `class`, `interface`, `string`, tömbök  |
| **Tárolás** | Magát az értéket tartalmazza, általában a vermen (stack)  | Mutató a felügyelt heap-re (halom)  |
| **Másolás** | Érték szerinti (teljes másolat készül)  | Referencia szerinti (csak a mutató másolódik)  |
| **Null érték** | Nem lehet null  | Lehet null  |

---

## 3. Előadás: Nyelvi eszközök 2.

### A `var` kulcsszó
Lokális változóknál a típus megadása helyett használható, ha van inicializáló érték, amiből a fordító kitalálja a típust. Ez nem "gyenge típusosság", a típus a fordítás után fix marad.

### Generics (Generikus típusok)
Lehetővé teszik, hogy egy osztályt vagy metódust úgy írjunk meg, hogy a felhasznált típust csak a használatkor adjuk meg.

* **Miért jó?** Elkerülhető az `object` típussal járó kényszerű castolás, a futásidejű hibák és a **boxing/unboxing** (érték típusok heap-re csomagolása), ami lassítja a programot .
* **Kényszerek (Constraints):** A `where` kulcsszóval megköthetjük, milyen típusokat fogadunk el (pl. `where T : IComparable` – csak olyan T, ami tudja az összehasonlítást).


### Lambda kifejezések
Név nélküli (anonim) függvények, amiket a `=>` operátorral definiálunk.
* **Szintaktika:** `(paraméterek) => törzs`.
* **Típusai:**
    * *Expression lambda:* Egyetlen kifejezés, aminek az értékével visszatér: `x => x * x`.
    * *Statement lambda:* Kapcsos zárójelek között több utasítás: `(x, y) => { return x + y; }`.
* **Variable Capturing (Closure):** A lambda látja és használja a környezetében lévő lokális változókat, akkor is, ha az eredeti függvény már lefutott .

### Beépített delegátok: Func és Action
Nem kell saját delegát típusokat gyártani, a .NET ad kész megoldásokat:
* **`Func<T, TResult>`:** Mindig van visszatérési értéke (az utolsó típusparaméter).
* **`Action<T>`:** Mindig `void` (nincs visszatérési értéke).

### LINQ (Language-Integrated Query)
Gyűjtemények kezelése (szűrés, rendezés) deklaratív módon, lambda kifejezésekkel.
* `Where()`: Szűrés.
* `OrderBy()`: Sorbarendezés.
* `Select()`: Transzformáció (projekció).

### További kényelmi eszközök
* **Partial Class:** Egy osztály definíciója több `.cs` fájlra vágható szét (hasznos generált kódnál).
* **Expression-bodied members:** Rövid propertyk/metódusok tömör megadása `=>` operátorral: `public int Age => DateTime.Now.Year - yearOfBirth;`.
* **Object Initializer:** Objektum létrehozása és tulajdonságainak beállítása egyetlen utasításban: `new Person { Name = "Luke", Age = 17 };` .

Szeretnéd, hogy valamelyik részt (pl. az érték vs. referencia típusokat vagy a generikus kényszereket) jobban kifejtsem konkrét kódpéldákkal?