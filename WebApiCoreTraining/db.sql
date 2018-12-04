CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Clients" (
    "ClientId" INTEGER NOT NULL CONSTRAINT "PK_Clients" PRIMARY KEY,
    "DateTimeRegister" TEXT NOT NULL,
    "Name" TEXT NULL
);

CREATE TABLE "Properties" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Properties" PRIMARY KEY,
    "Adress" TEXT NULL,
    "ClientId" INTEGER NOT NULL,
    "Name" TEXT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20181204110335_Initial', '2.2.0-rtm-35687');

