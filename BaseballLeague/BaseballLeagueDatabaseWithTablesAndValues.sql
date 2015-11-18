use master
go

drop database BaseballLeague
go

create database BaseballLeague
go

use BaseballLeague
go

create table Leagues (
	LeagueID int identity(1,1) primary key,
	LeagueName nvarchar(50) not null
)
go

create table Teams (
	TeamID int identity(1,1) primary key,
	LeagueID int foreign key references Leagues (LeagueID),
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
	PositionID int foreign key references Positions(PositionID) not null,
	TeamID int foreign key references Teams(TeamID) not null,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	JerseyNumber int not null,
	YearsPlayed int not null,
	BattingAvg decimal(3,3) null,
	EarnedRunAvg decimal(5, 2) null
	
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
		('Detroit Tigers', 'Beth Wagner'),

		('Texas Rangers','Ben Reynolds'),
		('Houston Astros','Maria Parker'),
		('Los Angeles Angels','Lew Wolf'),
		('Seattle Mariners','Doug Wright'),
		('Oakland Athletics','Jack Stevenson')
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
		('Spencer', 'Prince', 1, 18, .256, null, 3, 8),
		('Tom', 'Hall', 43, 19, null, 3.08, 11, 1),
		('Matt', 'Philips', 27, 18, null, 2.14, 12, 2),
		('George', 'Mitchell', 20, 17, null, 1.99, 13, 3),
		('Scott', 'Allen', 39, 16, .218, null, 14, 4),
		('Lori', 'Anderson', 66, 15, .299, null, 15, 5),
		('Harry', 'Brown', 87, 14, .317, null, 1, 6),
		('Pat', 'Lee', 14, 13, .225, null, 2, 7),
		('Martin', 'Morris', 8, 12, .263, null, 3, 8),
		('Shawn', 'Smith', 16, 11, .239, null, 4, 9),
		('Jeremy', 'Rogers', 44, 10, .336, null, 5, 10),
		('Ruby', 'Diaz', 43, 9, .250, null, 6, 11),
		('Nick', 'Garcia', 66, 8, .300, null, 7, 12),
		('Craig', 'Ross', 82, 7, null, 2.61, 8, 1),
		('Virginia', 'Allen', 7, 6, null, 3.29, 9, 2),
		('Ralph', 'Allen', 3, 5, null, 2.22, 10, 3),
		('Bill', 'Dee', 28, 4, .340, null, 11, 4),
		('Eric', 'Hill', 74, 3, .322, null, 12, 5),
		('Annie', 'Clark', 54, 2, .288, null, 13, 6)
go

-------------------------------------------------------------------------------------------------------------
-----------------------
-- STORED PROCEDURES --
-----------------------

USE BaseballLeague
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure GetAllTeams
as
begin
	select *
	from Teams
end
GO
-----------------------

USE BaseballLeague
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure GetAllPlayersOnATeam
	@TeamID int
AS
BEGIN

SET NOCOUNT ON;

select pl.PlayerID,
		pl.FirstName,
		pl.LastName,
		pl.JerseyNumber,
		pl.YearsPlayed,
		pl.BattingAvg,
		pl.EarnedRunAvg,
		pl.TeamID,
		te.TeamName,
		pl.PositionID,
		po.PositionName 
	from players pl
		inner join teams te
			on pl.TeamID = te.TeamID
		inner join Positions po
			on pl.PositionID = po.PositionID
	where te.TeamID = @TeamID
END
GO

----------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE CreateTeam 

	@TeamName nvarchar(50), 
	@ManagerName nvarchar(100),
	@LeagueID int,
	@TeamID int output 
AS
BEGIN
	
	SET NOCOUNT ON;

	insert into Teams (LeagueID, TeamName, ManagerName)
	values(@LeagueID, @TeamName, @ManagerName)
	set @TeamID = Scope_Identity()
END
GO

--ADD NEW PLAYER

Go
Create procedure [dbo].[AddNewPlayer](
	@PositionID int,
	@TeamID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@JerseyNumber int,
	@YearsPlayed int,
	@BattingAverage decimal(3,3),
	@EarnedRunAvg decimal(5,2),
	@PlayerID int output
	)
	as
begin
	insert into Players (PositionID, TeamID, FirstName, LastName, JerseyNumber, YearsPlayed, BattingAvg, EarnedRunAvg)
	values (@PositionID, @TeamID, @FirstName, @LastName, @JerseyNumber, @YearsPlayed, @BattingAverage, @EarnedRunAvg)

	set @PlayerID = SCOPE_IDENTITY();
end

--TRADE PLAYER

go
create procedure [dbo].[TradePlayer](
	@PlayerID int,
	@NewTeamID int
	)
	as
begin
	update players
	set TeamID = @NewTeamID
	where PlayerID = @PlayerID
end

--DELETE PLAYER

go
create procedure [dbo].[DeletePlayer](
	@PlayerID int
	)
	as
begin
	delete from players
	where PlayerID = @PlayerID
end

--GET TEAM ID

go 
create procedure [dbo].[GetTeamID](
	@TeamName nvarchar(50)
	)
	as
begin
	select TeamID
	from Teams
	where TeamName = @TeamName
end

--GET POSITION ID

go
create procedure [dbo].[GetPositionID](
	@PositionName nvarchar(50)
	)
	as
begin
	select PositionID
	from Positions
	where PositionName = @PositionName
end

