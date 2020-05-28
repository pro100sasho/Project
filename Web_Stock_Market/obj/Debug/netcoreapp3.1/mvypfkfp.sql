  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
'__EFMigrationsHistory'' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

CREATE TABLE `Products` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` text NOT NULL,
    `Quantity` int NOT NULL,
    `Price` decimal(10, 2) NOT NULL,
    PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200528091359_InitialMigration', '3.1.4');

DROP INDEX EmailIndex ON AspNetUsers;

CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200528112246_AddedUser', '3.1.4');

