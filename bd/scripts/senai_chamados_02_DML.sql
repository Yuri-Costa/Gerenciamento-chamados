-- DML

-- Define o banco de dados que ser� utilizado
USE sis_chamado;
GO

-- Insere os tipos de usu�rios
INSERT INTO tiposUsuarios(tituloTipoUsuario)
VALUES					 ('Administrador')
						,('Comum');
GO

-- Insere os usu�rios
INSERT INTO usuarios(idTipoUsuario, nomeUsuario, email, senha)
VALUES				(1, 'Administrador', 'adm@adm.com', 'adm123')
				   ,(2, 'Yuri', 'yuri@email.com', 'yuri123')
				   ,(2, 'guilherme', 'guilherme@email.com', 'gui123');
GO

-- Insere a institui��o
INSERT INTO instituicoes(cnpj, nomeFantasia, endereco)
VALUES					('99999999999999', 'Escola SENAI de Inform�tica', 'Al. Bar�o de Limeira, 538');
GO

-- Insere os tipos de eventos
INSERT INTO tiposChamado(tituloTipoChamado)
VALUES					('limpeza no ch�o')
					   ,('assistencia')
					   ,('manuten��o');
GO

-- Insere os eventos
INSERT INTO Chamados(idTipoChamados, idInstituicao, nomeChamado, acessoLivre, dataChamado, descricao)
VALUES			   (1, 1, 'Limpeza', 1, '07/04/2021', 'aluno acabou vomitando')
				  ,(2, 1, 'Manuten��o', 0, '08/04/2021', 'O elevador parou de funcionar');
GO

-- Insere as presen�as
INSERT INTO Presencas(idUsuario, idEvento, situacao)
VALUES				 (2, 2, 'n�o confirmada')
					,(3, 1, 'confirmada');
GO

-- Insere o evento
INSERT INTO chamados(idTipoEvento, idInstituicao, nomeChamado, dataChamado, descricao)
VALUES			   (3, 1, 'Manuten��o', '09/04/2021', 'o elevador parou de funcionar');
GO

-- Insere a presen�a
INSERT INTO Presencas(idUsuario, idEvento, situacao)
VALUES				 (2, 3, 'confirmada');
GO