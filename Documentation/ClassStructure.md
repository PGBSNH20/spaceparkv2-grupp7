Klassbeskrivning:

docker-compose:
	- .dockerignore
	- docker-compose.yml: Inneh�ller v�ra docker-compose properties. Vi har kommenterat ut f�rsta raderna d� dessa f�rhindrade oss fr�n att anv�nda containern som k�rde databasen samtidigt som varandra. �ven .gitignorad d� den inneh�ller l�senord till databasen

Service: Projektet som inneh�ller v�r funktionalitet som relaterar to SwApi.dev. 
	- Contracts:
		- ISwApi: Interface f�r metoderna inne i SwApi
	- SwApi.cs: Inneh�ller de olika inl�sningsmetoderna f�r SwApi.dev
	- Program.cs: Finns f�r att s�kerst�lla kommunikationen med SwApi
	- SearchResultStarShip.cs: H�ller s�kreslutaten fr�n requestet
	- SearchResultTraveller.cs:
	- SpaceTraveller.cs: Modell f�r objektet spacetraveller
	- StarShip.cs: Modell f�r objektet starship

SpacePark2
	- Controllers: Inneh�ller v�ra controllers som hanterar requests till APIet
		- ParkingController.cs: Kontrollerar POST request ang�ende uppstart av ny parkering.
		- ParkingHouseController.cs: Hanterar POST och GET i relation till parkeringshus.
		- SpaceTravellersController.cs: Innh�ller logik f�r en PUT i form av checkout, samt en GET ang�ende resen�rens historik.
		- TestController.cs: TestKlass f�r Authorization med ApiKey

	- Filter:
		- AdminApiKeyAuthAttribute.cs:
		- ApiKeyAuthAttribute.cs:
	
	- Migrations: EF Migrations

	- Models: 
		- Parking.cs
		- ParkingHouse.cs
		- ParkingHouseDTO.cs: Nedskalad version av ParkingHouse utan k�nslig information (Guid)
		- SpaceTraveller.cs
		- StarShip.cs

	- Repositories: Inneh�ller interfaces och repon f�r ett repository pattern.
		
		- Contracts: H�ller v�ra interfaces
			- IParkingHouseRepository.cs
			- IParkingRepository.cs
			- IRepository.cs: H�ller kontrakt f�r metoder som anv�nds i hela programmet
			- ISpaceTravellerRepository.cs
		- ParkingHouseRepository.cs: Inneh�ller metoder kopplade till ParkingHouse requests.
		- ParkingRepository.cs: Inneh�ller de metoder som kopplas till ParkingControllern.
		- Repository.cs: H�ller metoder som anv�nds �verallt i programmet, 
		- SpacetravellerRepository.cs: SpaceTraveller metoder
	- appsettings.json: .gitignorad f�r att inte ladda upp l�senord till publika github repot
	- Dockerfile:
	- Program.cs: Skapar en default hostbuilder 
	- SpacePark2.xml: Xml fil f�r xml comments i request metoderna
	- Startup.cs: Kopplar p� v�ra repon och interfaces, xml fil och definerar programmets struktur

SpacePark2Test: Projekt f�r testing med Xunit, inneh�ller testklasser med stub f�r v�ra repon.

	- Obi-WanKenobi.txt: Spacetraveller objekt f�r testing
	- ParkingHouseRepositoryTest.cs
	- ParkingRepositoryTest.cs
	- SpaceTravellerRepositoryTest.cs
	- SwApiTest.cs: Testar v�ra metoder f�r att prata med APIet via en mockad SpaceTraveller (Obi-WanKenobi.txt)
	- UnitTest1.cs: H�ller tester f�r metoder relaterade till requests
	