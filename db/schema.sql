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
	PRIMARY KEY(Id),
	UNIQUE(PublicId)
);

