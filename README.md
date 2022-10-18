# IndividuelltProjektBasic
Alternative project to "Individuellt-Projekt".

Den här github repon har jag skapat för ett slutprojekt i första kursen på Campus Varberg,
Systemutveckling.NET.

-----------------
#Introduktion till programmet
-----
Programiden ska simulera en enkel men funktionell internetbank/bankomat.
Programmet i korthet kunna hantera personuppgifter, bankkonton och hantering av inloggning.
Inloggning ska vara individuell för varje inloggad person och kunna
flytta över pengar, ta ut pengar.

Allt detta ska vi göra utan att använda objekt orienterad programmering.
Alltså utan klasser och object.

----------------
#Startguide
------
1. Välj en av 5 användare som du hittar i program.cs och använd dess
inloggningsuppgifter.

2. Starta programmet och mata in rätt uppgifter med stor och liten bokstav.

3. Nu har du full åtkomst till att föra över pengar, ta ut pengar, visa saldo och logga ut.

4. Programmet ska innehålla en bra felhantering.
----------------------------------

Alla metoder ligger i kör-ordning.

#Länk till uppgiften jag har kodat efter: https://qlok.notion.site/Individuellt-projekt-79489892b3cf4a12b64e4482860fde74
-----

-------------------------------------------------------------
#Egna reflektioner angående planering och koduppbyggnad.
-----

-Planering och förluster
------

Planeringen skulle ha varit mycket bättre, det fanns mer eller mindre ingen planering. 
Jag skrev programmet efter tankar hur jag tänkte och stötte sen på jobbiga problem som innebar att totalt 
ta bort eller skriva om metoder.

Det största problemet med bristande planering var att jag aldrig hade skapat någon riktigt "Login" metod. 
Loginen var inbakad i "DoesUserExist" vilket gjorde att användingsområdet för den metoden minska drastiskt.
Det gick inte att använda "DoesUserExist" för att då frågade den användaren om input vilket inte hade varit
relevant i de andra sammanhangen.

Hade jag planerat bättre så hade jag varit mer nogrann med att ha flera metoder som helst bara gör en uppgift.
Då hade användar området blivit mycket större.

-Det som gick bra.
----
Jag är väldigt nöjd över att all data ligger i en lista av arrayer. 
I listan så var alla värden string även kontosaldot vilket gjorde det till en utmaning
att ändra dem med ett decimaltal.

Jag löste det så att först ha en "InputConversion" som sparar string värdet som decimal i en separat 
array. Sen ändras värderna i programmet och när det ändrat färdigt så "OutputConversion" vilket skicka tillbaka
värdena som string i listan.

Det funkade verkligen jättebra och metoderna för konverteringen var enkel och kort.

Jag är också nöjd över min Main metod som blev relativt clean och inte någon logik. 
Det enda målet under projektet var att försöka hålla den så ren som bara möjligt.

-Varför har jag gjort så?
------------------------
Jag använde en lista av arrayer av typen string för att försöka hålla mig till ett enda samlingställe
för alla olika personuppgifter. Listan gjorde så att jag bara behövde hänvisa till enbart den, jag behövde inte ha 2-3 olika
arrayer i main metoden och behöver skifta och blanda ihop det. Nu har jag bara en "dold" decimal array i en av metoderna som är väldigt
kort och enkel.

Tänkte också att listan skulle vara mer rörlig i med att det är en list så att lägga till en 
till användare var planerat att vara enklare för att det bar bara att skapa en till array för
varje användare. Jag slutförde dock aldrig den funktionen.

Jag använder decimal för alla ekonomiska uträkningar så att användaren inte ska förlora några pengar
i mellan transaktionerna och hålla det så exakt som möjligt.

Jag har försökt att jobba med så mycket metoder som möjligt för att hålla koden
tydlig och ren. Det var också en av mina största mål med detta projektet att hålla det 
enkelt och läsbart.

På min tidigare labb fick jag kritik för att det var komplicerat och svårläst så nu
ville jag verkligen jobba med läsbarhet och enkelhet.

Tycker att jag lärde mig mycket på det och att det kommer bara bli ännu bättre på nästa
uppgift!

Tack för mig!
