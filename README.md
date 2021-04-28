# Warehouse Manager in C#



## „SMK” Raktárkezelő alkalmazás



**Néhány pontban a rendszer alapvető tulajdonságairól:**

- A megrendelő által megadott információk alapján létre lehessen hozni egy új terméket.
- Ezután egy többszintű gyártást lehessen indítani rá.
- A félkész szintek átvehetők legyenek adott raktárakba és ki is lehessen őket adni további felhasználásra.
- Raktári tranzakció történet a teljes átláthatóság érdekében.
- A raktári készlet exportálása .xls fájlba.
- Selejtezés lehetősége.
- Szállítási opció és szállítólevél készítése.
- Maradék kezelés.




**Megjegyzés:**

A program által „.xls” formátumban kimentett állományok olvasásához Office alkalmazás szükséges. 





## Raktári cikk létrehozása

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 001](https://user-images.githubusercontent.com/82768146/116378025-0879a680-a812-11eb-9d52-08ff718336c0.jpeg)


Ezen a felületen lehet létrehozni egy új terméket. Itt szabadon megadható bármilyen „Cikkszám” és „Megnevezés” is. A „Tervező”-t egy ComboBox-ból lehet megadni, amit az adatbázis a [dbo].[TervezoTable] táblájából tölt fel. 

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 002](https://user-images.githubusercontent.com/82768146/116378252-3eb72600-a812-11eb-81b1-e844acd6e5e1.jpeg)


A „Mennyiség” TextBox csak számot fogad el, a hiba elkerülése végett. A CheckedTextBox-ot használtam. A többi ComboBoxot is az adatbázis tölti fel az aktuális táblából. A „Dop azonosító” és a „Rendelési szám” írása le van tiltva. Automatikusan generál mindkettőhöz egy számot 250 – 400 és 204501 – 207500 között.

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 003](https://user-images.githubusercontent.com/82768146/116378339-555d7d00-a812-11eb-83bf-6c6c018e193f.jpeg)


` `A számnak abból a szempontból nincs jelentősége, hogy mekkora, a lényeg, hogy egyedi legyen, és némi hasonlóság legyen köztük. Értem ezalatt azt, hogy ne legyen két szám között hatalmas különbség, egy szűk sorszámtartományban mozogjanak. A  „Mentés” gomb lenyomásakor az összes Box visszaad egy logikai értéket, és ha ez mindenhol „true”, akkor ment az adatbázisba. 

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 004](https://user-images.githubusercontent.com/82768146/116378478-76be6900-a812-11eb-8a4b-97e641ede2fa.jpeg)


A „Törlés” gombbal a Box-okat lehet törölni egyszerre. Továbbá beállítottam a gomboknak egy-egy label-t is, ami a „Mouse hover” és a „Mouse Leave” eseményre reagál. Egyiknél megjelenik, a másiknál eltűnik. Így egyértelmű, hogy melyik gomb mire való.

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 005](https://user-images.githubusercontent.com/82768146/116378562-8b026600-a812-11eb-8018-84abf58ede68.jpeg)




## Gyártási rendelés

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 006](https://user-images.githubusercontent.com/82768146/116378634-9eadcc80-a812-11eb-9d70-93423f6a1791.png)


Itt lehet egy létrehozott termékre gyártást indítani. A „Cikkszám” ComboBoxot feltölti az eddig létrehozott cikkszámokkal, a „Megnevezés” boxot pedig a hozzá tartozó megnevezéssel.

A „Művelet” box előre meghatározott értékekkel van feltöltve az adatbázisból.  A kezdés dátuma a munkafolyamat elkezdését jelöli a befejezés dátuma pedig, hogy mikorra kell elkészülnie az adott félkész vagy készterméknek. Nem korlátoztam a szintek létrehozásának mennyiségét, mert azt úgyis a helyzet kívánja meg. 








## Gyártási rendelés átvétele

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 007](https://user-images.githubusercontent.com/82768146/116378786-bab16e00-a812-11eb-8de7-477d974fe7a9.jpeg)



Itt lehet az elkészült termékeket bevételezni a megfelelő raktárba. 

A létrehozott cikkszámokkal feltölti a „Cikkszám” ComboBoxot. A megfelelő cikkszám kiválasztása után pedig elérhetővé válik a hozzá tartozó félkész szint kiválasztása. Miután ez is megtörtént aktívvá vállnak azok a Boxok, amelyekben az adatokat szükséges megadni. 

A Státusz automatikusan „Elindítva” lesz, ameddig nem teljesül a sorozatméret.

Az összes átvett mennyiség nem haladhatja meg a hátralévő mennyiséget (ezt a mennyiséget a sorozatméretből és az összes átvett mennyiségből határozza meg). Amennyiben mégis több anyagot akarok bevételezni, abban az esetben ez az ablak ugrik fel:

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 008](https://user-images.githubusercontent.com/82768146/116378946-dd438700-a812-11eb-8b7a-1dc4f686d7f4.jpeg)


Ahhoz, hogy be lehessen vételezni, minden mezőt ki kell tölteni. Ellenkező esetben a program figyelmeztet, hogy nincs minden érték megadva és jelzi, hogy hol nem adtunk meg értéket:

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 009](https://user-images.githubusercontent.com/82768146/116379037-ef252a00-a812-11eb-8aa8-d5b89cc65558.jpeg)



Amennyiben a hátralévő mennyiség 0, az adott gyártási szint státusza „Lezárva” lesz. Ezzel is jelezve, hogy már ezen a szinten nem lehet több anyagot átvenni. Amennyiben mégis többlet anyag készül el, azt a „Maradék kezelés” menüpontban lehet bevételezni. Úgy gondoltam, ha külön választom a kettőt, akkor átláthatóbb lesz a gyártási folyamat is. 








## Gyártási rendelés kiadás

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 010](https://user-images.githubusercontent.com/82768146/116379135-03692700-a813-11eb-8117-eda6d5a80fe5.jpeg)

Itt lehet az elkészült termékeket kiadni további gyártásra, amennyiben van belőlük raktáron.

Ahhoz, hogy ki lehessen adni valamit az előző menüpontban, először be kell vételezni. Kiadni csak annyit lehet, amennyi raktáron van. 

A létrehozott cikkszámokkal feltölti a „Cikkszám” ComboBoxot. Amennyiben az adott cikkszámra még nem lett gyártás indítva, tehát semmilyen szint nem lett létrehozva a „Gyártási rendelés”-en, abban az esetben ez az ablak jelenik meg és nem is oldja fel a boxokat:

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 011](https://user-images.githubusercontent.com/82768146/116379199-12e87000-a813-11eb-98cd-f10bea72b76a.jpeg)

` `A megfelelő cikkszám kiválasztása után pedig elérhetővé válik a hozzá tartozó félkész szint kiválasztása. Miután ez is megtörtént, aktívvá vállnak azok a Boxok, amelyekben az adatokat szükséges megadni. 

A Státusz automatikusan „Elindítva” lesz, ameddig nem teljesül a Sorozat méret.

Ha több anyagot szeretnénk kiadni, mint amennyi készleten van, az alábbi figyelmeztető ablak ugrik fel, és végrehajtódik a művelet:

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 012](https://user-images.githubusercontent.com/82768146/116379250-21368c00-a813-11eb-858b-eb553ab052f7.jpeg)

Természetesen itt is vannak kötelezően kitöltendő mezők, melyeket, ha nem adtunk meg, akkor figyelmeztet a program és nem hajt végre semmilyen műveletet, ameddig ezt nem tesszük meg:

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 013](https://user-images.githubusercontent.com/82768146/116379319-2eec1180-a813-11eb-8904-113f16d03527.jpeg)



## Tranzakció történet

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 014](https://user-images.githubusercontent.com/82768146/116379380-3c090080-a813-11eb-9e47-3ce547bd9077.jpeg)

Ebben a menüpontban egy DataGridView segítségével listázza az összes tranzakciót. A táblázatba nem lehet írni vagy szerkeszteni. Listázza a Gyártás átvétel/kiadás teljes tartalmát. Az „Irány” azt mutatja meg, hogy kiadás vagy bevételezés történt (+/-). A találatok számát úgy adja meg, hogy összeadja a DataGridView sorait.

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 015](https://user-images.githubusercontent.com/82768146/116379419-45926880-a813-11eb-8c28-0913b58dceb5.jpeg)

A keresés TextBox-ban azonnal elkezd szűrni, ha megváltozik a szövege és az nem egyenlő a „Keresés…” szöveggel. 

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 016](https://user-images.githubusercontent.com/82768146/116379510-5c38bf80-a813-11eb-906e-3b1044e0057b.jpeg)

Két oszlopban keres, az egyik a „Cikk megnevezése”, a másik a „Cikkszám”. Automatikusan lekicsinyíti a betűket, hogy ne okozzon gondot, ha valaki nagybetűt ír be.

Az Excel gomb megnyomásával ki lehet exportálni a DataGridview tartalmát egy „.xls” fájlba.

Ehhez a Microsoft.Office osztálykönyvtárat használtam segítségül.



## Készlet lekérdezés

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 017](https://user-images.githubusercontent.com/82768146/116379559-6955ae80-a813-11eb-95a9-6409375a2ea7.jpeg)

Ez a menüpont szinte megegyezik a Tranzakció történettel, annyi különbséggel, hogy „Gyártás” tábla teljes tartalmát listázza. Tehát a teljes készletet látjuk itt. A DatagridView itt sem szerkeszthető vagy módosítható. Kapott ez a rész egy Selejtezés gombot.

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 018](https://user-images.githubusercontent.com/82768146/116379602-76729d80-a813-11eb-8553-7c3a0eeef65a.jpeg)

A selejtezés úgy működik, hogy kijelöljük azt a sort, amelyiken selejtezni szeretnénk és rákattintunk a **Selejtezés** gombra. 

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 019](https://user-images.githubusercontent.com/82768146/116379654-838f8c80-a813-11eb-92c1-9bf6c76a9999.jpeg)

A felugró ablakban meg kell adnunk a selejtezni kívánt mennyiséget és a selejtezés okát. Az utóbbit egy ListBox-ból lehet kiválasztani. Minden kiválasztott elemhez tartozik egy rövidítés is, ami a mellette lévő TextBoxban jelenik meg. Úgy gondoltam, hogy a rövidítésekkel könnyebb statisztikát vezetni és szűrni, ha a későbbiekben szükség lenne rá. A **Megjegyzés** box kitöltése nem kötelező.

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 020](https://user-images.githubusercontent.com/82768146/116379682-8b4f3100-a813-11eb-8ef0-1c0d38f4d040.png)

Az **Ok** gomb megnyomásakor a rendszer levonja a készletből a selejtezett mennyiséget.

A **Mégsem** gomb lenyomásával bezárjuk az ablakot és további művelet nem hajtódik végre.


## Szállítmány létrehozása

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 021](https://user-images.githubusercontent.com/82768146/116379719-96a25c80-a813-11eb-97fc-a7e7e998ac25.jpeg)

Ebben a menüpontban tudunk egy új szállítmányt létrehozni. Ehhez az „Új” gombra kell kattintanunk:

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 022](https://user-images.githubusercontent.com/82768146/116379759-a02bc480-a813-11eb-9e7a-9ab436350b53.png)

Ezután kap egy **Szállítmány azonosítót,** amit a program random generál és feloldja a boxokat. Meg kell adnunk egy **Nevet**, **Szállító nevét, Cikkszámot.** A cikkszám esetében, ha beírtunk valamit és elkattintunk a Box-ból, akkor a rendszer ellenőrzi, hogy az adatbázisban szerepel-e ilyen cikkszám, amennyiben igen, automatikusan kitölti a **Cikk megnevezése** Box-ot. Ha az adott cikkszám nem létezik, akkor ezt a hibaüzenetet kapjuk: 

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 023](https://user-images.githubusercontent.com/82768146/116379804-a6ba3c00-a813-11eb-93a3-cae53a211d48.jpeg)

A **Cikkszám** box tartalma törlődik. Az **Értékesítési mennyiség**, **Mértékegység**, **Ország** és **Cím** megadása kötelező, ha valamelyiket nem adtuk meg akkor a program figyelmeztet minket.

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 024](https://user-images.githubusercontent.com/82768146/116379840-b0dc3a80-a813-11eb-8e6a-89f7d011ff73.jpeg)

A **Kapcsolattartó**nál annak a személynek az adatait kell megadnunk, aki az adott cégnél a kapcsolattartó. Ez a lépés kihagyható, ha nincs ilyen személy. A **Mezők törlése** gombbal az összes mezőt tudjuk kitörölni.


## Szállítás

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 025](https://user-images.githubusercontent.com/82768146/116379878-bafe3900-a813-11eb-8f87-58f943a0b129.jpeg)

Itt lehet a **Készterméket** kiszállítani. Ehhez meg kell adnunk a **Szállítmány azonosítót**, amit a program generált nekünk az előző menüpontban. Ha megfelelő azonosítót adtunk meg, akkor a rendszer kitölti a hozzá tartozó mezőket. Amennyiben nem, ezt a hibaüzenetet kapjuk:

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 026](https://user-images.githubusercontent.com/82768146/116379946-ce110900-a813-11eb-91d7-a379ac629bd3.jpeg)

A DataGridView-ban a **Kapcsolt értékesítési mennyiség** jelzi, hogy összesen mennyit kell kiszállítanunk az adott termékből, a **Készlet mennyiség** jelzi a raktárban lévő mennyiségünket, a **Foglalt mennyiség** azt mutatja, hogy az aktuális készletből mennyit foglaltunk le az adott szállítmányhoz, a **Szállított mennyiség** pedig, hogy mennyi lett kiszállítva. Ahhoz, hogy ki lehessen szállítani, előbb le kell foglalnunk a készletből. Ellenkező esetben a program nem enged kiszállítani:

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 027](https://user-images.githubusercontent.com/82768146/116379999-db2df800-a813-11eb-978e-7aa27f1febe3.jpeg)

Ha nincs készletmennyiségünk, akkor foglalni sem tudunk:

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 028](https://user-images.githubusercontent.com/82768146/116380059-e719ba00-a813-11eb-90cd-4a53d3264e33.jpeg)

Ha a **Szállított mennyiség** megegyezik az **Kapcsolt értékesítési mennyiséggel,** akkor a szállítmány **Státusz**a „lezárt” lesz.

Nyomtatásra is van lehetőségünk, ha rákattintunk a **Nyomtatás** gombra. 

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 029](https://user-images.githubusercontent.com/82768146/116380098-f0a32200-a813-11eb-83c7-37b470afe508.jpeg)

Ezt a PrintDialog és a PrintDocument-el oldottam meg. 

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 030](https://user-images.githubusercontent.com/82768146/116380145-fb5db700-a813-11eb-96b0-7be91554cb56.jpeg)

Készítettem neki egyedi fejlécet, és az adatokat adatbázisból, vagy az épp aktuális Box-okból tölti fel.

## Maradék kezelés

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 031](https://user-images.githubusercontent.com/82768146/116380191-044e8880-a814-11eb-8621-02f2701f7f54.jpeg)

Ide lehet minden olyan többlet terméket felvinni, amiket már a gyártásnál nem enged. Ha a **Cikkszám**-hoz beírjuk a megfelelő cikkszámot, akkor a hozzá tartozó mezőket automatikusan kitölti, ha pedig nem létező cikkszámot adunk meg, akkor azt jelzi a rendszer: 

![Aspose Words a67e8c88-b5d4-437b-89ea-5fe8e503cfd4 026](https://user-images.githubusercontent.com/82768146/116380326-26e0a180-a814-11eb-88e0-95c2b5449176.jpeg)

A cikkszám megadása után ki kell választanunk, hogy melyik félkész szintjén akarunk bevételezni. A **Megőrzési idő**-t is meg kell adnunk, ennek három opciója van (3, 6, 12, hónap). Miután kiválasztottuk a nekünk megfelelőt, a program kiszámolja és kitölti a **Lejárat idejét**. Ha a Lejárat ideje kisebb lesz, mint az aktuális dátum, akkor a készletre vett termék sora a DataGridView-ba piros színűre változik. Ez azt jelenti, hogy a termék megőrzési ideje lejárt és selejtezhető. Selejtezni ugyanúgy tudunk, mint a **Készlet lekérdezésnél.**
