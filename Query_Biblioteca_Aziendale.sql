CREATE DATABASE Biblioteca_Aziendale;
USE Biblioteca_Aziendale;

CREATE TABLE Libri 
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    titolo VARCHAR(200),
    nPagine INT,
    genere VARCHAR(50),
    scaffale INT,
    annoPubblicazione INT
)

CREATE TABLE Autori
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(50),
    cognome VARCHAR(50),
    dob DATE
)

CREATE TABLE Utenti
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(40),
    cognome VARCHAR(40),
    dob DATE,
    indirizzo VARCHAR(100),
    userAdmin BIT,
    username VARCHAR(100),
    psw VARCHAR(100)
)

CREATE TABLE ScrittoDa
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    idLibro INT FOREIGN KEY REFERENCES Libri(id)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
    idAutore INT FOREIGN KEY REFERENCES Autori(id)
    ON UPDATE CASCADE
    ON DELETE CASCADE
)

CREATE TABLE inPrestito
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    idUtente INT FOREIGN KEY REFERENCES Utenti(id)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
    idLibro INT FOREIGN KEY REFERENCES Libri(id)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
    dataInizio DATE,
    dataFine DATE
)