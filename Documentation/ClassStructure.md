Klassbeskrivning:

docker-compose:
	- .dockerignore
	- docker-compose.yml: Innehåller våra docker-compose properties. Vi har kommenterat ut första raderna då dessa förhindrade oss från att använda containern som körde databasen samtidigt som varandra.

Service: Projektet som innehåller vår funktionalitet som relaterar to SwApi.dev. 
	- Contracts:
		- ISwApi: Interface för metoderna inne i SwApi
	- SwApi.cs: Innehåller de olika inläsningsmetoderna för SwApi.dev
	- Program.cs: Finns för att säkerställa kommunikationen med SwApi
	- SearchResultStarShip.cs: Håller sökreslutaten från requestet
	- SearchResultTraveller.cs:
	- SpaceTraveller.cs: Modell för objektet spacetraveller
	- StarShip.cs: Modell för objektet starship

SpacePark2
	- Controllers: Innehåller våra controllers som hanterar requests till APIet
		- ParkingController.cs: Kontrollerar POST request angående uppstart av ny parkering.
		- ParkingHouseController.cs: Hanterar POST och GET i relation till parkeringshus.
		- SpaceTravellersController.cs: Innhåller logik för en PUT i form av checkout, samt en GET angående resenärens historik.
		- TestController.cs: TestKlass för Authorization med ApiKey

	- Filter:
		- AdminApiKeyAuthAttribute.cs:
		- ApiKeyAuthAttribute.cs:
	
	- Migrations: EF Migrations

	- Models: 
		- Parking.cs
		- ParkingHouse.cs
		- ParkingHouseDTO.cs: Nedskalad version av ParkingHouse utan känslig information (Guid)
		- SpaceTraveller.cs
		- StarShip.cs

	- Repositories: Innehåller interfaces och repon för ett repository pattern.
		
		- Contracts: Håller våra interfaces
			- IParkingHouseRepository.cs
			- IParkingRepository.cs
			- IRepository.cs: Håller kontrakt för metoder som används i hela programmet
			- ISpaceTravellerRepository.cs
		- ParkingHouseRepository.cs: Innehåller metoder kopplade till ParkingHouse requests.
		- ParkingRepository.cs: Innehåller de metoder som kopplas till ParkingControllern.
		- Repository.cs: Håller metoder som används överallt i programmet, 
	