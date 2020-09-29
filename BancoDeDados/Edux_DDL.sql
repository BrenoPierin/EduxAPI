CREATE DATABASE EduxAPI
Go

USE EduxAPI
Go

	-- Criação das tabelas

	CREATE TABLE Perfil (
		IdPerfil INT PRIMARY KEY IDENTITY,
		Permissao VARCHAR (50) NOT NULL UNIQUE
	);
	GO
	
		CREATE TABLE Instituicao (
		IdInstituicao INT PRIMARY KEY IDENTITY,
		Nome VARCHAR (255) NOT NULL,
		Logradouro VARCHAR (255) NOT NULL,
		Numero VARCHAR (255) NOT NULL,
		Complemento VARCHAR (255) NOT NULl,
		Bairro VARCHAR (255) NOT NULL,
		Cidade VARCHAR (255) NOT NULL,
		UF VARCHAR (2) NOT NULL,
		CEP VARCHAR (15) NOT NULL
	);
	GO
	
		CREATE TABLE Categoria (
		IdCategoria INT PRIMARY KEY IDENTITY,
		Tipo VARCHAR (255) NOT NULL
	);
	GO

	CREATE TABLE Objetivo (
	IdObjetivo INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR (255) NOT NULL,
		IdCategoria INT FOREIGN KEY REFERENCES Categoria (IdCategoria)
);
GO


	CREATE TABLE Curso (
	IdCurso INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR (255) NOT NULL,
		IdInstituicao INT FOREIGN KEY REFERENCES Instituicao (IdInstituicao)
);
GO

CREATE TABLE Turma (
	IdTurma INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR (255) NOT NULL,
		IdCurso INT FOREIGN KEY REFERENCES Curso (IdCurso)
);
GO

		CREATE TABLE Usuario (
		IdUsuario INT PRIMARY KEY IDENTITY,
		Nome VARCHAR (255) NOT NULL,
		Email VARCHAR (100) NOT NULL,
		Senha VARCHAR (255) NOT NULL,
		DataCadastro DATETIME,
		DataUltinoAcesso DATETIME,
			IdPerfil INT FOREIGN KEY REFERENCES Perfil (IdPerfil)
		);
	GO

		CREATE TABLE ProfessorTurma (
		IdProfessorTurma INT PRIMARY KEY IDENTITY,
		Descricao VARCHAR (255) NOT NULL,
					IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
					IdTurma INT FOREIGN KEY REFERENCES Turma (IdTurma)
		);
	GO

	CREATE TABLE Dica (
		IdDica INT PRIMARY KEY IDENTITY,
		Texto VARCHAR (255),
		Imagem VARCHAR (255),
			IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
		);
	GO

	CREATE TABLE Curtida (
		IdCurtida INT PRIMARY KEY IDENTITY,
			IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
			IdDica INT FOREIGN KEY REFERENCES Dica (IdDica),
		);
	GO

	CREATE TABLE AlunoTurma (
		IdAlunoTurma INT PRIMARY KEY IDENTITY,
		Matricula VARCHAR (50),
			IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
			IdTurma INT FOREIGN KEY REFERENCES Turma (IdTurma)
		);
	GO

	CREATE TABLE ObjetivoAluno (
		IdObjetivoAluno INT PRIMARY KEY IDENTITY,
		Nota DECIMAL DEFAULT NULL,
		DataAlcancado DATETIME,
			IdAlunoTurma INT FOREIGN KEY REFERENCES AlunoTurma (IdAlunoTurma),
			IdTurma INT FOREIGN KEY REFERENCES Turma (IdTurma),
			IdObjetivo INT FOREIGN KEY REFERENCES Objetivo (IdObjetivo)
		);
	GO

	SELECT * FROM Dica
	SELECT * FROM Curtida
	SELECT * FROM Perfil
	SELECT * FROM AlunoTurma
	SELECT * FROM Usuario
	SELECT * FROM ProfessorTurma
	SELECT * FROM ObjetivoAluno
	SELECT * FROM Turma
	SELECT * FROM Curso
	SELECT * FROM Objetivo
	SELECT * FROM Categoria
	SELECT * FROM Instituicao