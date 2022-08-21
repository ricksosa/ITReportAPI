CREATE TABLE CategoriaComputadora (
    Id int NOT NULL AUTO_INCREMENT,
    Nombre longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT CategoriaComputadora PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE Salas (
    Id int NOT NULL AUTO_INCREMENT,
    Edificio longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT Salas PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE Computadora (
    Id int NOT NULL AUTO_INCREMENT,
    Gabinete longtext CHARACTER SET utf8mb4 NOT NULL,
    SalaId int NOT NULL,
    CONSTRAINT Computadora PRIMARY KEY (Id),
    CONSTRAINT FK_Computadora_Salas_SalaId FOREIGN KEY (SalaId) REFERENCES Salas (Id) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE Componente (
    Id int NOT NULL AUTO_INCREMENT,
    Nombre longtext CHARACTER SET utf8mb4 NOT NULL,
    CategoriaId int NOT NULL,
    ComputadoraId int NULL,
    CONSTRAINT Componente PRIMARY KEY (Id),
    CONSTRAINT FK_Componente_CategoriaComputadora_CategoriaId FOREIGN KEY (CategoriaId) REFERENCES CategoriaComputadora (Id) ON DELETE CASCADE,
    CONSTRAINT FK_Componente_Computadora_ComputadoraId FOREIGN KEY (ComputadoraId) REFERENCES Computadora (Id)
) CHARACTER SET=utf8mb4;

CREATE INDEX IX_Componente_CategoriaId ON Componente (CategoriaId);

CREATE INDEX IX_Componente_ComputadoraId ON Componente (ComputadoraId);

CREATE INDEX IX_Computadora_SalaId ON Computadora (SalaId);

INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion)
VALUES ('20220821023006_InitialScript', '6.0.8');

COMMIT;

TART TRANSACTION;

ALTER TABLE Computadora ADD IdSala int NOT NULL DEFAULT 0;

INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion)
VALUES ('20220821024501_InitialScript2', '6.0.8');

COMMIT;

START TRANSACTION;

CREATE TABLE Admins (
    Id int NOT NULL AUTO_INCREMENT,
    Nombre longtext CHARACTER SET utf8mb4 NOT NULL,
    Apellido longtext CHARACTER SET utf8mb4 NOT NULL,
    Usuario longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT Admins PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE CategoriaReporte (
    Id int NOT NULL AUTO_INCREMENT,
    Nombre longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT CategoriaReporte PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE EstadoReporte (
    Id int NOT NULL AUTO_INCREMENT,
    Nombre longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT EstadoReporte PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE TipoDeIncidente (
    Id int NOT NULL AUTO_INCREMENT,
    Nombre longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT TipoDeIncidente PRIMARY KEY (Id)
) CHARACTER SET=utf8mb4;

CREATE TABLE Reportes (
    Id int NOT NULL AUTO_INCREMENT,
    FechaDeReporte datetime(6) NOT NULL,
    EstadoId int NOT NULL,
    ComentariosReporte longtext CHARACTER SET utf8mb4 NOT NULL,
    ComentariosAdmin longtext CHARACTER SET utf8mb4 NOT NULL,
    CategoriaId int NOT NULL,
    IdSala int NOT NULL,
    SalaId int NOT NULL,
    IdComputadora int NOT NULL,
    ComputadoraId int NOT NULL,
    FechaActualizacion datetime(6) NOT NULL,
    IncidenteId int NOT NULL,
    CONSTRAINT Reportes PRIMARY KEY (Id),
    CONSTRAINT FK_Reportes_CategoriaReporte_CategoriaId FOREIGN KEY (CategoriaId) REFERENCES CategoriaReporte (Id) ON DELETE CASCADE,
    CONSTRAINT FK_Reportes_Computadora_ComputadoraId FOREIGN KEY (ComputadoraId) REFERENCES Computadora (Id) ON DELETE CASCADE,
    CONSTRAINT FK_Reportes_EstadoReporte_EstadoId FOREIGN KEY (EstadoId) REFERENCES EstadoReporte (Id) ON DELETE CASCADE,
    CONSTRAINT FK_Reportes_Salas_SalaId FOREIGN KEY (SalaId) REFERENCES Salas (Id) ON DELETE CASCADE,
    CONSTRAINT FK_Reportes_TipoDeIncidente_IncidenteId FOREIGN KEY (IncidenteId) REFERENCES TipoDeIncidente (Id) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX IX_Reportes_CategoriaId ON Reportes (CategoriaId);

CREATE INDEX IX_Reportes_ComputadoraId ON Reportes (ComputadoraId);

CREATE INDEX IX_Reportes_EstadoId ON Reportes (EstadoId);

CREATE INDEX IX_Reportes_IncidenteId ON Reportes (IncidenteId);

CREATE INDEX IX_Reportes_SalaId ON Reportes (SalaId);

INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion)
VALUES ('20220821024750_InitialScript3', '6.0.8');

COMMIT;

