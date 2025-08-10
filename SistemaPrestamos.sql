CREATE DATABASE SistemaPrestamo;
USE SistemaPrestamo;

CREATE TABLE Clientes (
    ClienteId int IDENTITY(1,1) NOT NULL,
    Nombre nvarchar(100) NOT NULL,
    Apellido nvarchar(100) NOT NULL,
    TipoDocumento nvarchar(50) NOT NULL,
    NumeroDocumento nvarchar(50) NOT NULL,
    FechaNacimiento date NOT NULL,
    Direccion nvarchar(200) NOT NULL,
    Ciudad nvarchar(100),
    Provincia nvarchar(100),
    CodigoPostal nvarchar(10),
    TelefonoPrincipal nvarchar(20) NOT NULL,
    TelefonoOpcional nvarchar(20),
    Email nvarchar(150) NOT NULL,
    Ocupacion nvarchar(100) NOT NULL,
    NotasAdicionales nvarchar(255),
    CONSTRAINT PK_Clientes PRIMARY KEY (ClienteId)
);
GO



CREATE TABLE Prestamos (
    PrestamoId int IDENTITY(1,1) NOT NULL,
    ClienteId int NOT NULL,
    MontoPrincipal decimal(18,2) NOT NULL,
    TasaInteresAnual decimal(5,2) NOT NULL,
    PlazoMeses int NOT NULL,
    FrecuenciaPago nvarchar(50) NOT NULL,
    FechaInicio date NOT NULL,
    FechaFinPrevista date,
    TasaInteresMoraAnual decimal(5,2) NOT NULL,
    Estado nvarchar(50) NOT NULL,
    SaldoPendiente decimal(18,2) NOT NULL,
    FechaUltimoPago date,
    TerminosAdicionales nvarchar(255),
    CONSTRAINT PK_Prestamos PRIMARY KEY (PrestamoId),
    CONSTRAINT FK_Prestamos_Clientes_ClienteId FOREIGN KEY (ClienteId) REFERENCES Clientes (ClienteId) ON DELETE CASCADE
);
GO


CREATE INDEX IX_Prestamos_ClienteId ON Prestamos (ClienteId);
GO


CREATE TABLE RecibosCobro (
    ReciboCobroId int IDENTITY(1,1) NOT NULL,
    PrestamoId int NOT NULL,
    ClienteId int NOT NULL,
    FechaPago date NOT NULL,
    MontoPagado decimal(18,2) NOT NULL,
    MontoCapital decimal(18,2) NOT NULL,
    MontoInteres decimal(18,2) NOT NULL,
    MontoMora decimal(18,2) NOT NULL,
    SaldoAnterior decimal(18,2) NOT NULL,
    SaldoActual decimal(18,2) NOT NULL,
    MetodoPago nvarchar(50) NOT NULL,
    NumeroTransaccion nvarchar(100),
    Notas nvarchar(255),
    CONSTRAINT PK_RecibosCobro PRIMARY KEY (ReciboCobroId),
    CONSTRAINT FK_RecibosCobro_Prestamos_PrestamoId FOREIGN KEY (PrestamoId) REFERENCES Prestamos (PrestamoId) ON DELETE CASCADE,
    CONSTRAINT FK_RecibosCobro_Clientes_ClienteId FOREIGN KEY (ClienteId) REFERENCES Clientes (ClienteId)
);
GO


CREATE INDEX IX_RecibosCobro_PrestamoId ON RecibosCobro (PrestamoId);
GO

CREATE INDEX IX_RecibosCobro_ClienteId ON RecibosCobro (ClienteId);
GO