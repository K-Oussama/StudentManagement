CREATE TABLE Module (
    Id_Module INT IDENTITY(1, 1) NOT NULL,
    Name NVARCHAR(50) NULL,
    PRIMARY KEY (Id_Module)
);

CREATE TABLE Evaluation (
    Id_Evaluation INT IDENTITY(1, 1) NOT NULL,
    type NVARCHAR(50) NULL,
    Id_Cour INT FOREIGN KEY REFERENCES Cour(Id_Cour),
    PRIMARY KEY (Id_Evaluation)
);

CREATE TABLE NoteModule (
    Id_Note_Mod INT IDENTITY(1, 1) NOT NULL,
    Name NVARCHAR(50) NULL,
    Id_module INT FOREIGN KEY REFERENCES Module(Id_Module),
    PRIMARY KEY (Id_Note_Mod)
);

CREATE TABLE Cour (
    Id_Cour INT IDENTITY(1, 1) NOT NULL,
    Name NVARCHAR(50) NULL,
    Id_module INT FOREIGN KEY REFERENCES Module(Id_Module),
    PRIMARY KEY (Id_Cour)
);

CREATE TABLE NoteExam (
    Id_Note INT IDENTITY(1, 1) NOT NULL,
    Name NVARCHAR(50) NULL,
    Id_evaluation INT FOREIGN KEY REFERENCES Evaluation(Id_Evaluation),
    PRIMARY KEY (Id_Note)
);

CREATE TABLE Etudiant (
    Id INT IDENTITY(1, 1) NOT NULL,
    FirstName NVARCHAR(50) NULL,
    LastName NVARCHAR(50) NULL,
    EmailAddress NVARCHAR(50) NULL,
    Id_note_module INT FOREIGN KEY REFERENCES NoteModule(Id_Note_Mod),
    Id_note_evaluation INT FOREIGN KEY REFERENCES Evaluation(Id_Evaluation),
    PRIMARY KEY (Id)
);