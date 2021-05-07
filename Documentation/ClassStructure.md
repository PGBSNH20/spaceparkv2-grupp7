### Klassbeskrivning:

## docker-compose
* .dockerignore
* docker-compose.yml: Innehåller våra docker-compose properties. Vi har kommenterat ut första raderna då dessa förhindrade oss från att använda containern som körde databasen samtidigt som varandra. Även .gitignorad då den innehåller lösenord till databasen

## Service: 
Projektet som innehåller vår funktionalitet som relaterar to SwApi.dev. 
* Contracts:
	- ISwApi: Interface för metoderna inne i SwApi
* SwApi.cs: Innehåller metoder för att skicka request och ta emot respons ifrån SwApi.dev för att sedan kunna använda detta i vårat API
* SearchResultStarShip.cs: Håller temporära sökreslutat från requestet till swapi
* SearchResultTraveller.cs: --||--
* SpaceTraveller.cs: Modell för objektet spacetraveller
* StarShip.cs: Modell för objektet starship

### SpacePark2
## Controllers: Innehåller våra controllers som hanterar requests till APIet
* ParkingController.cs: POST ter emot API nyckel samt namn, model, och önskat parkeringshur för uppstart av ny parkering.
* ParkingHouseController.cs: Hanterar POST (Kräver Admin Nyckel för användning), i denna kan man starta upp ett nytt parkeringshus, man väljer namn samt storlek på paerkeringhus, och GET för att kunna få fram vilka olika parkeringshus som man har möjlihet att parkera i.
* SpaceTravellersController.cs: Innhåller logik för en PUT i form av checkout som uppdaterar depaturetime samt cost på tabellerna, samt en GET för att få historik om tidigare parkeringar.

## Filter:
* AdminApiKeyAuthAttribute.cs: Middleware för Admin API nyckel 
* ApiKeyAuthAttribute.cs: Middleware för API nyckel
	
## Migrations:
-EF Migrations

## Models: 
* HistoryDTO.cs : Temp DTO modell för att endast få ut informationen vi vill ha när man ska hämta sin historik
* Parking.cs
* ParkingHouse.cs
* ParkingHouseDTO.cs: Nedskalad version av ParkingHouse utan känslig information (Guid)
* SpaceTraveller.cs
* StarShip.cs

## Repositories:Innehåller interfaces och repon för ett repository pattern.
*	## Contracts: Håller våra interfaces
   	* IParkingHouseRepository.cs
   	* IParkingRepository.cs
   	* IRepository.cs: Håller kontrakt för metoder som används i hela programmet
   	* ISpaceTravellerRepository.cs
* ParkingHouseRepository.cs: Innehåller metoder kopplade till ParkingHouse requests.
* ParkingRepository.cs: Innehåller de metoder som kopplas till ParkingControllern.
* Repository.cs: Håller metoder som används överallt i programmet, 
* SpacetravellerRepository.cs: SpaceTraveller metoder		

	
## appsettings.json: .gitignorad för att inte ladda upp lösenord till publika github repot
* Dockerfile:
* Program.cs: Skapar en default hostbuilder 
* SpacePark2.xml: Xml fil för xml comments i request metoderna
* Startup.cs: Kopplar på våra repon och interfaces, xml fil och definerar programmets struktur

### SpacePark2Test: Projekt för testing med Xunit, innehåller testklasser med stub för våra repon.

* Obi-WanKenobi.txt: Spacetraveller objekt för testing
* ParkingHouseRepositoryTest.cs : Äver av IParkingHouseRepository
* ParkingRepositoryTest.cs : Ärver av IParkingRepository
* SpaceTravellerRepositoryTest.cs : Ärver av ISpaceTravellerRepository
* SwApiTest.cs: Testar våra metoder för att prata med APIet via en mockad SpaceTraveller (Obi-WanKenobi.txt)
* UnitTest1.cs: Håller tester för metoder relaterade till requests
	
