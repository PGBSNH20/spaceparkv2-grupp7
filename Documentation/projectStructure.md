1. Brainstorm
API
	- Vilka services ska vi ha?
		- Parking
			- POST (Starta ny parkering)
			- UPDATE (Departure, Cost)
			- GET (Aktuell status, Historik)
		- ParkingHouse
			- POST (Skapa nytt)
			- GET (Tillgängliga parkeringshus)
		- SpaceTraveller
			- (POST (via POST Parking))
			- GET (får ID och jämför mot parking för att se status och historik)
		- StarShip
			- (POST (via POST Parking))

		<-- Tidigare tankar -->
		- Checka ut
			- GET leaving starTraveller (Parking)
			- UPDATE - IsArchived
			- POST - till Archive
		- Kolla min egen parkeringsstatus
			- GET
		- Parkeringshistorik
			- GET
		- Skapa nytt parkeringshus
			- POST
		<--  -->


Databas
	Models:
		Parking
			- PH.ID
			- ST.ID
			- SS.ID
			- Arrival
			- Departure
			- Cost

		ParkingHouse
			- ID
			- Name

		SpaceTraveller
			- ID
			- Name

		StarShip
			- ID
			- StarShipModel
			- ShipLenght
