-- Table db_version
CREATE TABLE db_version (
  Id int unsigned NOT NULL,
  Version VARCHAR(32) NOT NULL,
  Description VARCHAR(1024) NOT NULL,
  DateApplied DATETIME NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE field (
	Id int unsigned NOT NULL AUTO_INCREMENT,
	Name varchar(100) NOT NULL,
	DataType TINYINT NOT NULL,
	PRIMARY KEY(Id),
	UNIQUE(Name)
);

