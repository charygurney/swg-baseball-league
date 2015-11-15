use master
go

create database BaseballLeague
go

use BaseballLeague
go

create table Teams (
	TeamID int identity(1,1) primary key,
	TeamName nvarchar(50) not null,
	ManagerName nvarchar(100) not null,
)
go

create table Players (
	PlayerID int identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	JerseyNumber int not null,
	YearsPlayed int not null,
	BattingAvg decimal(3,3) null,
	EarnedRunAvg decimal(5, 2) null,
  TeamID int references Teams(TeamID) not null
)
go

create table Positions (
	PositionID int identity(1,1) primary key,
	PositionName nvarchar(50) not null,
	PlayerID int references Players(PlayerID)
)
go

insert into Teams (TeamName, ManagerName)
	values ('Cleveland Indians', 'Tony La Russa'),
		('Houston Astros', 'Manny Ramiriz'),
		('New York Yankees', 'Joe Torre')
go

insert into Players(FirstName, LastName, JerseyNumber, YearsPlayed, BattingAvg, EarnedRunAvg, TeamID)
	values ('Carlos', 'Gomez', 30, 8, .258, null, 1),
		('Preston', 'Tucker', 20, 3, .203, null, 1),
		('Scott', 'Benz', 7, 16, .172, 3.61, 1),
		('Nate', 'Gurney', 6, 3, .344, null, 1),
		('Jim', 'Shaw', 0, 9, .284, null, 1),
		('Johnny', 'Baseball', 67, 3, .314, null, 1),
		('Bob', 'Gibson', 42, 0, .301, null, 1),
		('Abraham', 'Lincoln', 65, 17, .401, null, 1),
		('Babe', 'Ruth', 3, 20, .346, 2.89, 1)
go

insert into Positions (PositionName, PlayerID)
	values ('SP', 3),
		('C', 1),
		('1B', 2),
		('2B', 4),
		('SS', 5),
		('3B', 6),
		('LF', 7),
		('CF', 8),
		('RF', 9)
go

