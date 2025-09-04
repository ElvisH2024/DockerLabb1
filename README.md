Jag har gjort en enkel webbapplikation byggd i ASP.NET Core. Den körs i en container och är kopplad till en SQL Server-databas i en separat container. På startsidan finns en länk till en Todo-sida där man kan lägga till och se uppgifter.

För att köra applikationen behöver man Docker Desktop. Man klonar projektet från GitHub, kör kommandot docker compose up --build och öppnar sidan på http://localhost:8080
.

Jag har valt ASP.NET Core som ramverk, SQL Server som databas och Entity Framework Core för databashantering. Docker och Docker Compose används för att köra containrarna. Projektet finns på GitHub där version 1.0 är första versionen och version 2.0 innehåller Todo-sidan och README.

Containrar är ofta billigare och snabbare än virtuella maskiner. På Azure kostar två små containrar runt 350–400 kr per månad, medan två VM med samma prestanda kostar cirka 500–600 kr. För lagring av 25 GB blir kostnaden ungefär 30–40 kr för två veckors het lagring och cirka 20 kr för sex månaders arkivering. Slutsatsen är att containrar är mer prisvärda och att man kan spara pengar genom att flytta data till arkivering när den inte längre behöver vara snabb.
