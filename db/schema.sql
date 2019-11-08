-- business partner db schema 
ALTER DATABASE CHARACTER SET utf8 COLLATE utf8_general_ci;

DROP PROCEDURE IF EXISTS AddColumnUnlessExists;
delimiter //

create procedure AddColumnUnlessExists(
	IN dbName tinytext,
	IN tableName tinytext,
	IN fieldName tinytext,
	IN fieldDef text)
begin
	IF NOT EXISTS (
		SELECT * FROM information_schema.COLUMNS
		WHERE column_name=fieldName
		and table_name=tableName
		and table_schema=dbName
		)
	THEN
		set @ddl=CONCAT('ALTER TABLE ',dbName,'.',tableName,
			' ADD COLUMN ',fieldName,' ',fieldDef);
		prepare stmt from @ddl;
		execute stmt;
	ELSE
		select CONCAT('COLUMN: ', fieldName, ' is already exists') AS output;
	END IF;
end//

delimiter ;

DROP PROCEDURE IF EXISTS DropForeignKeyIfExists;
DELIMITER $$
CREATE PROCEDURE DropForeignKeyIfExists(
	IN dbName tinytext,
	IN tableName VARCHAR(64), 
	IN constraintName VARCHAR(64))
BEGIN
    IF EXISTS(
        SELECT * FROM information_schema.table_constraints
        WHERE 
            table_schema    = dbName     AND
            table_name      = tableName      AND
            constraint_name = constraintName AND
            constraint_type = 'FOREIGN KEY')
    THEN
        SET @query = CONCAT('ALTER TABLE ', tableName, ' DROP FOREIGN KEY ', constraintName, ';');
        PREPARE stmt FROM @query; 
        EXECUTE stmt; 
        DEALLOCATE PREPARE stmt; 
    END IF; 
END$$
DELIMITER ;


DROP PROCEDURE IF EXISTS AddForeignKeyUnlessExists;
DELIMITER $$
CREATE PROCEDURE AddForeignKeyUnlessExists(
	IN dbName tinytext,
	IN foreignKeyTableName VARCHAR(64), 
	IN primaryKeyTableName VARCHAR(64), 
	IN foreignKeyFieldName VARCHAR(64), 
	IN primaryKeyFieldName VARCHAR(64), 
	IN constraintName VARCHAR(64))
BEGIN
	DECLARE idx VARCHAR(256);
    
    IF NOT EXISTS(
        SELECT * FROM information_schema.table_constraints
        WHERE 
            table_schema    = dbName					AND
            table_name      = foreignKeyTableName		AND
            constraint_name = constraintName			AND
            constraint_type = 'FOREIGN KEY')
    THEN
		SET idx = CONCAT(constraintName, '_idx');
		SET @query = CONCAT('ALTER TABLE ', foreignKeyTableName, ' ADD INDEX ', idx, ' ( ', foreignKeyFieldName , ' ASC);');PREPARE stmt FROM @query; 
        EXECUTE stmt; 
        DEALLOCATE PREPARE stmt; 

		SET @query = CONCAT('ALTER TABLE ', foreignKeyTableName, ' ADD CONSTRAINT ', constraintName, ' FOREIGN KEY ( ', foreignKeyFieldName, ') REFERENCES ', primaryKeyTableName, '(' , primaryKeyFieldName , ');');
		PREPARE stmt FROM @query; 
        EXECUTE stmt; 
	ELSE
		select CONCAT('FOREIGN KEY: ', constraintName, ' is already exists') AS output;
    END IF; 
END$$
DELIMITER ;

-- Table db_version
CREATE TABLE db_version (
  Id int(11) unsigned NOT NULL,
  Version VARCHAR(32) NOT NULL,
  Description VARCHAR(1024) NOT NULL,
  DateApplied DATETIME NOT NULL,
  PRIMARY KEY (id));
  

CREATE TABLE role (
  Id int(11) NOT NULL,
  Name varchar(256) NOT NULL,
  ConcurrencyStamp longtext,
  NormalizedName varchar(256) DEFAULT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE user (
  Id int(11) NOT NULL AUTO_INCREMENT,
  PublicId varchar(32) NOT NULL,
  Email varchar(256) DEFAULT NULL,
  UserName varchar(256) NOT NULL,
  EmailConfirmed tinyint(1) NOT NULL,
  PasswordHash longtext,
  SecurityStamp longtext,
  PhoneNumber varchar(256) DEFAULT NULL,
  PhoneNumberConfirmed tinyint(1) NOT NULL,
  TwoFactorEnabled tinyint(1) NOT NULL,
  LockoutEnd datetime DEFAULT NULL,
  LockoutEndDateUtc datetime DEFAULT NULL,
  LockoutEnabled tinyint(1) NOT NULL,
  AccessFailedCount int(11) NOT NULL,
  ConcurrencyStamp longtext,
  NormalizedEmail varchar(256) DEFAULT NULL,
  NormalizedUsername varchar(256) DEFAULT NULL,

  FirstName varchar(255) DEFAULT NULL,  
  LastName varchar(255) DEFAULT NULL,
  MiddleName varchar(255) DEFAULT NULL,
  PRIMARY KEY (Id),
  UNIQUE KEY PublicId (PublicId)
) AUTO_INCREMENT=1;

CREATE TABLE user_claim (
  Id int(11) NOT NULL AUTO_INCREMENT,
  UserId int(11) NOT NULL,
  ClaimType longtext,
  ClaimValue longtext,
  PRIMARY KEY (Id),
  UNIQUE KEY Id (Id),
  KEY UserId (UserId),
  CONSTRAINT FK_User_Claims FOREIGN KEY (UserId) REFERENCES user (Id)
);

CREATE TABLE user_login (
  LoginProvider int(11) NOT NULL,
  ProviderKey varchar(128) NOT NULL,
  UserId int(11) NOT NULL,
  PRIMARY KEY (LoginProvider,ProviderKey,UserId),
  KEY ApplicationUser_Logins (UserId),
  CONSTRAINT FK_User_Logins FOREIGN KEY (UserId) REFERENCES user (Id)
);

CREATE TABLE user_role (
  UserId int(11) NOT NULL,
  RoleId int(11) NOT NULL,
  PRIMARY KEY (UserId,RoleId),
  KEY IdentityRole_Users (RoleId),
  CONSTRAINT FK_User_Roles FOREIGN KEY (UserId) REFERENCES user (Id),
  CONSTRAINT FK_Role_Users FOREIGN KEY (RoleId) REFERENCES role (Id)
) ;

CREATE TABLE role_claim (
  Id int(11) NOT NULL AUTO_INCREMENT,
  RoleId int(11) NOT NULL,
  ClaimType longtext,
  ClaimValue longtext,
  PRIMARY KEY (Id),
  UNIQUE KEY Id (Id),
  KEY RoleId (RoleId),
  CONSTRAINT FK_Roles_Claims FOREIGN KEY (RoleId) REFERENCES role (Id)
);