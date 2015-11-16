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

create table Positions (
	PositionID int identity(1,1) primary key,
	PositionName nvarchar(50) not null
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
	TeamID int references Teams(TeamID) not null,
	PositionID int references Positions(PositionID) not null
)
go



insert into Teams (TeamName, ManagerName)
	values ('Toronto Blue Jays', 'John Gibbons'),
		('New York Yankees', 'Joe Girardi'),
		('Baltimore Orioles', 'Buck Showalter'),
		('Tampa Bay Rays', 'Santos Phelps'),
		('Boston Red Sox', 'Oscar Webb'),

		('Kansas City Royals', 'Caleb Bird'),
		('Minnesota Twins', 'Patti Smith'),
		('Cleveland Indians', 'Aaron Potter'),
		('Chicago White Sox', 'Sherman Martin'),
		('Detroit Tigers', 'Beth Wagner')
go

insert into Positions (PositionName)
	values ('SP'),
		('RP'),
		('CP'),
		('C'),
		('1B'),
		('2B'),
		('SS'),
		('3B'),
		('LF'),
		('CF'),
		('RF'),
		('DH')
go

insert into Players(FirstName, LastName, JerseyNumber, YearsPlayed, BattingAvg, EarnedRunAvg, TeamID, PositionID)
	values ('Carlos', 'Gomez', 30, 8, .258, null, 1, 4),
		('Preston', 'Tucker', 20, 3, .203, null, 2, 5),
		('Scott', 'Benz', 7, 16, .172, 3.61, 3, 1),
		('Nate', 'Gurney', 6, 3, .344, null, 4, 6),
		('Jim', 'Shaw', 0, 9, .284, null, 5, 7),
		('Johnny', 'Baseball', 67, 3, .314, null, 6, 8),
		('Bob', 'Gibson', 42, 0, .301, null, 7, 9),
		('Abraham', 'Lincoln', 65, 17, .401, null, 8, 10),
		('Taylor', 'Moreno', 23, 2, .256, null, 9, 11),
		('Cory', 'Johnson', 36, 6, .213, null, 1, 12),
		('Darrin', 'Sunia', 31, 13, .137, null, 2, 4),
		('Shelia', 'Simpson', 17, 8, .372, null, 3, 5),
		('Joanna', 'Paul', 88, 5, .294, null, 4, 6),
		('Claude', 'Jacob', 27, 3, .222, null, 5, 7),
		('Jeff', 'Tebow', 55, 11, .118, null, 6, 8),
		('Felix', 'Ryan', 11, 6, .294, 4.12, 7, 2),
		('Kurt', 'Clapper', 7, 12, .302, 3.76, 8, 3),
		('Rick', 'Wise', 36, 15, .312, null, 9, 5),
		('Ben', 'King', 97, 5, .321, null, 1, 6),
		('Luke', 'Green', 10, 0, .189, null, 2, 7),
		('Spencer', 'Prince', 1, 18, .256, null, 3, 8)
go



