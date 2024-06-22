-- Crear DB
Create Database PruebaCMI

-- Crear tablas Client con llave
CREATE TABLE Client_Header (
  ID int PRIMARY KEY,
  Name VARCHAR(50),
  Status VARCHAR(50),
);

CREATE TABLE Client_Detail (
  ClientID int UNIQUE NOT NULL,
  Name VARCHAR(50),
  Status VARCHAR(50),
  Location VARCHAR(50),
  Phone_Number VARCHAR(50),
  Date_Created DATE,
  Comments VARCHAR(50)
);

ALTER TABLE Client_Detail
ADD CONSTRAINT FK_Client_Detail_Head FOREIGN KEY (ClientID)
REFERENCES Client_Header (ID);

-- Crear tabla usuarios
CREATE TABLE Users (
  Username VARCHAR(50) PRIMARY KEY,
  Password VARCHAR(50),
  Name VARCHAR(50),
  Last_Name VARCHAR(50),
  Status VARCHAR(50)
);

-- Crear tabla transascciones y relaciones
CREATE TABLE Transactions (
  ID int PRIMARY KEY,
  Type VARCHAR(10),
  Created_By VARCHAR(50),
  ClientID int,
  Date_Created DATE,
  Comments VARCHAR(50)

);

ALTER TABLE Transactions
ADD CONSTRAINT FK_Transactions_Users FOREIGN KEY (Created_By)
REFERENCES Users (Username);

ALTER TABLE Transactions WITH NOCHECK
ADD FOREIGN KEY (ClientID) REFERENCES Client_Header (ID)

-- Insert usuarios
insert into Users values ('jdiego', '123', 'Juan Diego', 'Solorzano', 'HABILITADO')
insert into Users values ('user2', '321', 'Ejemplo', '2', 'HABILITADO')
insert into Client_Header values ('1', 'Client1', 'HABILITADO')
insert into Client_Detail values ('1', 'Client1', 'HABILITADO', 'Guatemala', '54321', '2024-06-21', 'C')

-- Crear procedimientos

CREATE PROC SP_ADD_CLIENT (@NAME NVARCHAR(50), @LOCATION NVARCHAR(50), @PHONE NVARCHAR(50), @COMMENTS NVARCHAR(50), @DATEC DATE)
AS
BEGIN

DECLARE @ID int = (select max(ID) from Client_Header) + 1
INSERT INTO Client_Header VALUES(@ID ,@NAME,'HABILITADO')
insert into Client_Detail values (@ID, @NAME, 'HABILITADO', @LOCATION, @PHONE, @DATEC, @COMMENTS)
END
EXEC SP_ADD_CLIENT



CREATE PROC SP_DELETE_CLIENT (@NAME VARCHAR(50))
AS
BEGIN

-- Solo deshabilita el usuario no lo elimina
update Client_Header set Status = 'DESHABILITADO' where Name = @NAME
update Client_Detail set Status = 'DESHABILITADO' where Name = @NAME
END
EXEC SP_DELETE_CLIENT

