CREATE DATABASE IF NOT EXISTS gsb_ordonnances
DEFAULT CHARACTER SET utf8mb4
DEFAULT COLLATE utf8mb4_unicode_ci;

USE gsb_ordonnances;

DROP TABLE IF EXISTS ETRE_ALLERGIQUE;
DROP TABLE IF EXISTS CONTENIR;
DROP TABLE IF EXISTS ORDONNANCE;
DROP TABLE IF EXISTS ALLERGIE;
DROP TABLE IF EXISTS MEDICAMENT;
DROP TABLE IF EXISTS MEDECIN;
DROP TABLE IF EXISTS PATIENT;

CREATE TABLE PATIENT (
    numPatient INT NOT NULL AUTO_INCREMENT,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    dateNaissance DATE NOT NULL,
    numerosecu CHAR(13) NOT NULL UNIQUE,
    PRIMARY KEY (numPatient)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE MEDECIN (
    numMedecin INT NOT NULL AUTO_INCREMENT,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    dateNaissance DATE NOT NULL,
    numeroRPPS CHAR(11) NOT NULL UNIQUE,
    specialite VARCHAR(100) NOT NULL,
    motDePasse VARCHAR(255) NOT NULL,
    PRIMARY KEY (numMedecin)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE MEDICAMENT (
    codeMedicament INT NOT NULL AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL,
    dosage VARCHAR(50) NOT NULL,
    PRIMARY KEY (codeMedicament)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE ALLERGIE (
    codeAllergie INT NOT NULL AUTO_INCREMENT,
    libelle VARCHAR(100) NOT NULL UNIQUE,
    PRIMARY KEY (codeAllergie)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE ORDONNANCE (
    numOrdonnance INT NOT NULL AUTO_INCREMENT,
    dateEmission DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    numMedecin INT NOT NULL,
    numPatient INT NOT NULL,
    PRIMARY KEY (numOrdonnance),
    CONSTRAINT fk_ordonnance_medecin FOREIGN KEY (numMedecin) REFERENCES MEDECIN(numMedecin) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_ordonnance_patient FOREIGN KEY (numPatient) REFERENCES PATIENT(numPatient) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE CONTENIR (
    numOrdonnance INT NOT NULL,
    codeMedicament INT NOT NULL,
    posologie VARCHAR(255) NOT NULL,
    dureeJours SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (numOrdonnance, codeMedicament),
    CONSTRAINT fk_contenir_ordonnance FOREIGN KEY (numOrdonnance) REFERENCES ORDONNANCE(numOrdonnance) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_contenir_medicament FOREIGN KEY (codeMedicament) REFERENCES MEDICAMENT(codeMedicament) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE ETRE_ALLERGIQUE (
    numPatient INT NOT NULL,
    codeAllergie INT NOT NULL,
    PRIMARY KEY (numPatient, codeAllergie),
    CONSTRAINT fk_allergique_patient FOREIGN KEY (numPatient) REFERENCES PATIENT(numPatient) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_allergique_allergie FOREIGN KEY (codeAllergie) REFERENCES ALLERGIE(codeAllergie) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO MEDECIN (nom, prenom, dateNaissance, numeroRPPS, specialite, motDePasse) VALUES
('DURAND', 'Paul', '1970-01-15', '10101010101', 'Généraliste', 'secret'),
('MARTIN', 'Claire', '1982-06-20', '20202020202', 'Cardiologue', 'secret');

INSERT INTO PATIENT (nom, prenom, dateNaissance, numeroSecu) VALUES
('DUPONT', 'Marie', '1985-03-14', '2850314123456'),
('LEROY', 'Jean', '1960-07-22', '1600722123456');

INSERT INTO MEDICAMENT (nom, dosage) VALUES
('Doliprane', '1000 mg'),
('Amoxicilline', '1 g'),
('Aspirine', '500 mg');

INSERT INTO ALLERGIE (libelle) VALUES
('Pénicilline'),
('Aspirine'),
('Iode');

INSERT INTO ORDONNANCE (dateEmission, numMedecin, numPatient) VALUES
('2026-05-11 10:30:00', 1, 1);

INSERT INTO CONTENIR (numOrdonnance, codeMedicament, posologie, dureeJours) VALUES
(1, 1, '1 comprimé 3 fois par jour', 5),
(1, 2, '1 comprimé matin et soir', 7);

INSERT INTO ETRE_ALLERGIQUE (numPatient, codeAllergie) VALUES (1, 1);