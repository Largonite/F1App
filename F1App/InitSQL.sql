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

set identity_insert "Teams" on
go

INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (1,'Ferrari','Italian')
INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (2,'Force India','Indian')
INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (3,'Haas F1 Team','American')
INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (4,'Manor','British')
INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (5,'Mclaren','British')
INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (6,'Mercedes','German')
INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (7,'Red Bull','Austrian')
INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (8,'Renault','French')
INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (9,'Sauber','Swiss')
INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (10,'Toro Rosso','Italian')
INSERT "Teams"("TeamId","TeamName","TeamNationality") VALUES (11,'Williams','British')

GO

set identity_insert "Teams" off
go
set identity_insert "Pilots" on
go

INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (1,'Fernando','Alonso',14,'ALO','Spanish',5)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (2,'Valtteri','Bottas',77,'BOT','Finnish',11)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (3,'Jenson','Button',22,'BUT','British',5)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (4,'Marcus','Ericsson',9,'ERI','Swedish',9)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (5,'Romain','Grosjean',8,'GRO','French',8)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (6,'Esteban','Gutièrrez',21,'GUT','Mexican',8)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (7,'Lewis','Hamilton',44,'HAM','British',6)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (8,'Rio','Haryanto',88,'HAR','Indonesian',4)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (9,'Nico','Hulkenberg',27,'HUL','German',2)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (10,'Daniil','Kvyat',26,'KVT','Russian',10)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (11,'Kevin','Magnussen',20,'MAG','Danish',8)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (12,'Felipe','Massa',19,'MAS','Brazilian',11)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (13,'Felipe','Nasr',12,'NSR','Brazilian',9)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (15,'Jolyon','Palmer',30,'PAL','British',8)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (14,'Esteban','Ocon',31,'OCN','French',4)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (16,'Sergio','Perez',11,'PER','Mexican',11)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (17,'Kimi','Raikkonen',7,'RAI','Finnish',1)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (18,'Daniel','Ricciardo',3,'RIC','Australian',7)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (19,'Nico','Rosberg',6,'ROS','German',6)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (20,'Carlos','Sainz',55,'SAI','Spanish',10)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (21,'Stoffel','Vandoorne',47,'VAN','Belgian',5)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (22,'Max','Vertappen',33,'VES','Dutch',7)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (23,'Sebastian','Vettel',5,'VET','German',1)
INSERT "Pilots"("PilotId", "PilotFName","PilotLName","PilotNumber","PilotAbv","PilotNationality","TeamId") VALUES (24,'Pascal','Wehrlein',94,'WEH','German',4)

GO

set identity_insert "Pilots" off
go