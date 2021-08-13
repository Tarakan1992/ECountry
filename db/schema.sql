-- Table db_version
CREATE TABLE db_version (
  Id int NOT NULL,
  Version varchar(32) NOT NULL,
  Description nvarchar(1024) NOT NULL,
  DateApplied datetime NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE property (
	Id int NOT NULL AUTO_INCREMENT,
	Name nvarchar(100) NOT NULL,
	Type TINYINT NOT NULL,
	PRIMARY KEY(Id),
	UNIQUE(Name)
);

CREATE TABLE form (
	Id int NOT NULL AUTO_INCREMENT,
	PublicId varchar(32) NOT NULL,
	Name nvarchar(100) NOT NULL,
	Description varchar(1024) NOT NULL,
	Definition json not NULL,
	PRIMARY KEY(Id),
	UNIQUE(PublicId)
);

CREATE TABLE `group` (
	Id int NOT NULL AUTO_INCREMENT,
	Name nvarchar(100) NOT NULL,
	PRIMARY KEY(Id)
);

CREATE TABLE `user` (
	Id int NOT NULL AUTO_INCREMENT,
	Email varchar(200) NOT NULL,
	FirstName varchar(100) NOT NULL,
	MiddleName varchar(100) DEFAULT NULL,
	LastName varchar(100) NOT NULL,
	DateOfBirth date NOT NULL,
	PhoneNumber varchar(50) DEFAULT NULL,
	Gender TINYINT NOT NULL,
	Status TINYINT NOT NULL,
	PRIMARY KEY(Id)
);

CREATE TABLE user_group (
	UserId int NOT NULL,
	GroupId int NOT NULL,
	CONSTRAINT FK_user_group_user
	  FOREIGN KEY (UserId)
	  REFERENCES `user` (Id),
		CONSTRAINT FK_user_group_group
	  FOREIGN KEY (GroupId)
	  REFERENCES `group` (Id)
);

