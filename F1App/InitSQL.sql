SET NOCOUNT ON
GO

USE F1App
GO

set quoted_identifier on
GO

CREATE TABLE "Teams"(
	"TeamId" "int" IDENTITY (1,1) NOT NULL,
	"TeamName" nvarchar(50) NOT NULL,
	"TeamNationality" nvarchar(20) NOT NULL,
	"TeamUrl" nvarchar(100) ,
	CONSTRAINT "PK_Teams" PRIMARY KEY CLUSTERED(
		"TeamId"
	)
)
GO
	CREATE INDEX "TeamName" ON "Teams"("TeamName")
GO

CREATE TABLE "Pilots"(
	"PilotId" "int" IDENTITY (1,1) NOT NULL,
	"PilotFName" nvarchar (20) NOT NULL,
	"PilotLName" nvarchar (20) NOT NULL,
	"PilotNumber" "int" NOT NULL,
	"PilotAbv" nvarchar (5) NOT NULL,
	"PilotNationality" nvarchar(20) NOT NULL,
	"PilotUrl" nvarchar(100),
	"PilotDOB" nvarchar(20) NOT NULL,
	"TeamId" "int" NOT NULL,
	CONSTRAINT "PK_Pilots" PRIMARY KEY CLUSTERED(
		"PilotId"
	),
	CONSTRAINT "FK_Pilots_Teams" FOREIGN KEY(
		"TeamId"
	) REFERENCES "Teams" (
		"TeamId"
	)
)

GO
	CREATE INDEX "PilotAbv" ON "Pilots"("PilotAbv")
GO

CREATE TABLE "Locations"(
	"LocationId" "int" IDENTITY(1,1) NOT NULL,
	"LocationLat" nvarchar(25),
	"LocationLong" nvarchar(25),
	"LocationLocality" nvarchar(50) NOT NULL,
	"LocationCountry" nvarchar(50) NOT NULL,
	CONSTRAINT "PK_Locations" PRIMARY KEY(
		"LocationId"
	)
)

GO

CREATE TABLE "Circuits"(
	"CircuitId" "int" IDENTITY(1,1) NOT NULL,
	"CircuitUrl" nvarchar(100),
	"CircuitName" nvarchar(50) NOT NULL,
	"LocationId" "int" NOT NULL,
	CONSTRAINT "PK_Circuits" PRIMARY KEY CLUSTERED(
		"CircuitId"
	),
	CONSTRAINT "FK_Circuits_Location" FOREIGN KEY(
		"LocationId"
	)REFERENCES "Locations"(
		"LocationId"
	)
)

GO

CREATE TABLE "Races"(
	"RaceId" "int" IDENTITY(1,1) NOT NULL,
	"RaceSeason" "int" NOT NULL,
	"RaceRound" "int" NOT NULL,
	"RaceUrl" nvarchar(100),
	"RaceName" nvarchar(50) NOT NULL,
	"CircuitId" "int" NOT NULL,
	"RaceDate" nvarchar(20),
	"RaceTime" nvarchar(20),
	CONSTRAINT "PK_Races" PRIMARY KEY CLUSTERED(
		"RaceId"
	),
	CONSTRAINT "FK_Races_Circuit" FOREIGN KEY(
		"CircuitId"
	)REFERENCES "Circuits"(
		"CircuitId"
	)
)
GO

CREATE TABLE "Results"(
	"ResultId" "int" IDENTITY(1,1) NOT NULL,
	"RaceId" "int" NOT NULL,
	"ResultPosition" "int" NOT NULL,
	"ResultPoints" "int" NOT NULL,
	"ResultGrid" "int" NOT NULL,
	"ResultStatus" nvarchar(20),
	"ResultTime" nvarchar(20),
	"PilotId" "int" NOT NULL,
	CONSTRAINT "PK_Results" PRIMARY KEY CLUSTERED(
		"ResultId"
	),
	CONSTRAINT "FK_Results_Race" FOREIGN KEY(
		"RaceId"
	)REFERENCES "Races"(
		"RaceId"
	),
	CONSTRAINT "FK_Results_Pilot" FOREIGN KEY(
		"PilotId"
	)REFERENCES "Pilots"(
		"PilotId"
	)	 
)

GO

CREATE TABLE "PilotStandings"(
	"StandingId" "int" IDENTITY(1,1) NOT NULL,
	"StandingSeason" "int" NOT NULL,
	"StandingPosition" "int" NOT NULL,
	"StandingPoints" "int" NOT NULL,
	"StandingWins" "int" NOT NULL,
	"PilotId" "int" NOT NULL,
	CONSTRAINT "PK_PilotStandings" PRIMARY KEY CLUSTERED(
		"StandingId"
	),
	CONSTRAINT "FK_PilotStandings_Pilot" FOREIGN KEY(
		"PilotId"
	)REFERENCES "Pilots"(
		"PilotId"
	)
)

GO
CREATE TABLE "TeamStandings"(
	"StandingId" "int" IDENTITY(1,1) NOT NULL,
	"StandingSeason" "int" NOT NULL,
	"StandingPosition" "int" NOT NULL,
	"StandingPoints" "int" NOT NULL,
	"StandingWins" "int" NOT NULL,
	"TeamId" "int" NOT NULL,
	CONSTRAINT "PK_DriverStandings" PRIMARY KEY CLUSTERED(
		"StandingId"
	),
	CONSTRAINT "FK_TeamStandings_Team" FOREIGN KEY(
		"TeamId"
	)REFERENCES "Teams"(
		"TeamId"
	)
)

GO