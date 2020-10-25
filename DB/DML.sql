USE EduxProject

--Inserindo valores nos atributos de TipoUsuario
INSERT INTO Perfil (Permissao) VALUES 
	('Professor'),
	('Aluno');

--Inserindo valores nos atributos de Instituicao
INSERT INTO Instituicao (Nome,Logradouro,Numero,Complemento,Bairro,Cidade,UF,CEP) VALUES
	('Senai de Informatica','Alameda Barão de Limeira', '539', 'Prédio','Santa cecilia','Sao Paulo','SP','98078-077');

--Inserindo valores nos atributos de Categoria
INSERT INTO Categoria (Descricao) VALUES 
	('Facil'),
	('Medio'),
	('Dificil');

--Inserindo valores nos atributos de Curso
INSERT INTO Curso (Titulo, idInstituicao) VALUES 
	('Desenvolvimento de Sistemas', 1),
	('Rede de Computadores', 1),
	('MultiMidia', 1);

--Inserindo valores nos atributos de Usuario
INSERT INTO Usuario (Nome, Email, Senha, IdPerfil) VALUES
	('Georgia','Georgia@gmail.com','123456', 1),
	('Breno','Breno@gmail.com','123456', 2),
	('Gabriel','Gabriel@gmail.com','123456', 2),
	('Amanda','Amanda@gmail.com','123456', 1);

	--Inserindo valores nos atributos de Turma
INSERT INTO Turma (Descricao,IdCurso) VALUES 
	('Primeiro DEV Manha',1),
	('Segundo Redes Tarde',2),
	('Segundo MultiMidia Tarde',3);

INSERT INTO AlunoTurma (Matricula, IdUsuario, IdTurma) VALUES
	('', 2, 1),
	('', 3, 2);

INSERT INTO ProfessorTurma (Descricao, IdUsuario, IdTurma) VALUES
	('',1, 1),
	('',4, 2);

--Inserindo valores nos atributos de Dica
INSERT INTO Dica (Texto, UrlImagem, IdUsuario) VALUES 
    ('Estudar Genetica', '', 2);

--Inserindo valores nos atributos de Curtida
INSERT INTO Curtida (IdUsuario,IdDica) VALUES
	(2,1);	

--Inserindo valores nos atributos de Objetivo	
INSERT INTO Objetivo (Descricao, IdCategoria) VALUES
    ('Aplicacao de API em no React', 3),
	('Capacidade de criar um Banco de dados', 1);



--Inserindo valores nos atributos de Meta	
INSERT INTO ObjetivoAluno (Nota, DataAlcancado, IdAlunoTurma, IdObjetivo) VALUES
    (100,'2020-08-26T00:00:00',2,1),
	(100,'2020-08-27T00:00:00',3,2);

	select * from Usuario;