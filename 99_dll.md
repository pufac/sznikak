A **DLL (Dynamic Link Library)**, magyarul **dinamikus csatolású könyvtár**, a .NET (és általában a Windows) egyik legfontosabb építőköve. Az előadás 43-54. diái alapján itt a pontos magyarázat:

### 1. Mi az a DLL?
A DLL egy olyan fájlformátum, amely **futtatható kódot, adatokat és erőforrásokat** (például képeket vagy szövegeket) tartalmaz, de önmagában – egy `.exe` fájllal ellentétben – nem indítható el. Egy vagy több program "kölcsönkéri" a benne lévő tudást, amikor szüksége van rá.



### 2. Hogyan működik a .NET-ben? (A "Szerelvény" fogalma)
A .NET világában a DLL-t **Szerelvénynek (Assembly)** nevezzük. Ez több, mint egy egyszerű kódtár, mert az alábbiakat tartalmazza:
* **IL kód:** A processzorfüggetlen köztes nyelv, amit a JIT fordító fog natív kóddá alakítani.
* **Metaadatok:** Leírják, hogy milyen osztályok és függvények vannak a fájlban (milyen paramétereket várnak, mit adnak vissza).
* **Manifest:** Ez a "tartalomjegyzék". Benne van a DLL neve, pontos verziószáma és az, hogy milyen más DLL-ekre van szüksége a futáshoz.

### 3. Miért "dinamikus"?
* **Static (Statikus):** A kód beleépül az `.exe`-be. Ha 10 program használja ugyanazt a funkciót, 10-szer foglalja a helyet a lemezen és a memóriában is.
* **Dynamic (Dinamikus):** A kód külön fájlban van. Csak akkor töltődik be a memóriába, amikor a programnak tényleg szüksége van rá. Több program is használhatja ugyanazt a DLL fájlt egyszerre, ami memóriát spórol.

### 4. Példa a működésre
Képzeld el, hogy írsz egy programot, ami PDF-eket generál:
1.  Nem írod meg a PDF-generálás bonyolult kódját, hanem használsz egy `PdfHelper.dll`-t.
2.  Amikor az alkalmazásod (`program.exe`) elindul és a felhasználó a "Mentés PDF-ként" gombra kattint, a **CLR (futtatókörnyezet)** megkeresi a `PdfHelper.dll`-t.
3.  Betölti a memóriába, és lefuttatja belőle a szükséges részt.

### 5. Mi az a "DLL Hell" és hogyan oldja meg a .NET?
Régen (a .NET előtt) ha egy új program feltelepített egy frissebb DLL-t a közös rendszermappába, az elronthatta a régi programokat, amik a régi verziót várták.
* **A .NET megoldása:** A Manifest segítségével a program pontosan tudja, melyik verziójú DLL-re van szüksége. Akár két különböző verzió is lehet ugyanabból a DLL-ből a gépen (**Side-by-Side execution**), a programod azt fogja használni, amelyikkel tesztelték.

**Összefoglalva:** A DLL egy közös "tudástár", amit a programok megosztva használnak, a .NET pedig gondoskodik róla, hogy ez a megosztás biztonságos és verzióhelyes legyen.