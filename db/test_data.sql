INSERT INTO `property` (Id,`Name`,`Type`)
VALUES
( 1, 'FirstName', 1),
( 2,  'LastName', 1),
( 3,    'Gender', 1),
( 4,       'Age', 2);

INSERT INTO `group`
(`Id`, `Name`)
VALUES
(1, 'Client'),
(2, 'Manager'),
(3, 'Admin'),
(4, 'SuperAdmin');

INSERT INTO `ecountry_db`.`user`
(`Id`, `Email`, `FirstName`, `MiddleName`, `LastName`, `DateOfBirth`, `PhoneNumber`, `Gender`, `Status`)
VALUES
( 1,        'super-admin@s-test.it', 'Super Admin', NULL, 'Super Admin', '1980-01-01', '555-555-5555', 1, 1),
( 2,              'admin@s-test.it',       'Admin', NULL,       'Admin', '1980-01-01', '555-555-5555', 1, 1),
( 3,  'SaraEvangelista@teleworm.us',        'Sara', 'D.', 'Evangelista', '1949-06-01', '641-228-1658', 1, 1),
( 4,   'PamelaJEdwards@teleworm.us',      'Pamela', 'J.',     'Edwards', '1940-04-20', '315-924-4259', 1, 1),
( 5,    'ClaytonBAllen@teleworm.us',     'Clayton', NULL,       'Allen', '1983-06-30', '856-438-3863', 2, 1),
( 6,  'DavidCCaines@jourrapide.com',       'David', NULL,      'Caines', '1966-02-28', '216-267-9636', 2, 1),
( 7,    'RobertGJackson@dayrep.com',      'Robert', NULL,     'Jackson', '1988-12-30', '202-661-3819', 2, 1),
( 8,       'EdnaSRivera@dayrep.com',        'Edna', NULL,      'Rivera', '2000-10-22', '718-658-3838', 1, 2),
( 9,'AlejandraLSimpson@armyspy.com',   'Alejandra', 'L.',     'Simpson', '1992-02-15', '775-272-2757', 1, 1),
(10,       'AnneDMoore@armyspy.com',       'Anne ', NULL,       'Moore', '1991-09-27', '915-579-2871', 1, 1),
(11,'ArthurGRamirez@jourrapide.com',      'Arthur', NULL,     'Ramirez', '2010-10-13', '802-291-4408', 2, 1),
(12,     'JohnPPerkins@teleworm.us',        'John', NULL,     'Perkins', '1984-03-30', '843-527-0644', 2, 1),
(13,  'GriseldaVAustin@teleworm.us',    'Griselda', NULL,      'Austin', '1974-01-31', '617-688-8000', 1, 1),
(14,     'AngelaJLegge@armyspy.com',      'Angela', 'J.',       'Legge', '2004-10-20', '903-966-9496', 1, 2),
(15,  'FelipeRWilliams@armyspy.com',      'Felipe', NULL,    'Williams', '2004-02-28', '330-794-8749', 2, 1),
(16,       'WillieJBrown@rhyta.com',      'Willie', NULL,       'Brown', '1996-01-08', '541-687-6918', 2, 1),
(17,    'JerryJSheppard@dayrep.com',       'Jerry', NULL,    'Sheppard', '2011-11-02', '360-758-1738', 2, 1),
(18,    'TiaraRGosselin@dayrep.com',       'Tiara', NULL,    'Gosselin', '1968-09-07', '856-881-4221', 1, 2),
(19, 'JacelynHBrown@jourrapide.com',     'Jacelyn', NULL,       'Brown', '1974-07-28', '215-342-6523', 1, 1),
(20,      'SidneyDElls@armyspy.com',      'Sidney', 'D.',        'Ells', '2013-10-21', '248-479-6969', 2, 2);

INSERT INTO `ecountry_db`.`user_group`
(`UserId`,
`GroupId`)
VALUES
( 1, 3),
( 1, 4),
( 2, 3),
( 3, 2),
( 3, 3),
( 4, 2),
( 4, 3),
( 5, 2),
( 6, 2),
( 7, 2),
( 8, 2),
( 9, 1),
(10, 1),
(11, 1),
(12, 1),
(13, 1),
(14, 1),
(15, 1),
(16, 1),
(17, 1),
(18, 1),
(19, 1),
(20, 1);



   