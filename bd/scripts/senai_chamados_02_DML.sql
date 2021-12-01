-- DML

-- Define o banco de dados que será utilizado
USE sis_chamado;
GO

-- Insere os tipos de usuários
INSERT INTO tiposUsuarios(tituloTipoUsuario)
VALUES					 ('Administrador')
						,('Comum');
GO

-- Insere os usuários
INSERT INTO usuarios(idTipoUsuario, nomeUsuario, email, senha)
VALUES				(1, 'Administrador', 'adm@adm.com', 'adm123')
				   ,(2, 'Yuri', 'yuri@email.com', 'yuri123')
				   ,(2, 'guilherme', 'guilherme@email.com', 'gui123');
GO

-- Insere a instituição
INSERT INTO instituicoes(cnpj, nomeFantasia, endereco)
VALUES					('99999999999999', 'Escola SENAI de Informática', 'Al. Barão de Limeira, 538');
GO

-- Insere os tipos de eventos
INSERT INTO tiposChamado(tituloTipoChamado)
VALUES					('limpeza no chão')
					   ,('assistencia')
					   ,('manutenção');
GO

-- Insere os eventos
INSERT INTO Chamados(idTipoChamados, idInstituicao, nomeChamado, acessoLivre, dataChamado, descricao)
VALUES			   (1, 1, 'Limpeza', 1, '07/04/2021', 'aluno acabou vomitando')
				  ,(2, 1, 'Manutenção', 0, '08/04/2021', 'O elevador parou de funcionar');
GO

-- Insere as presenças
INSERT INTO Presencas(idUsuario, idEvento, situacao)
VALUES				 (2, 2, 'não confirmada')
					,(3, 1, 'confirmada');
GO

-- Insere o evento
INSERT INTO chamados(idTipoEvento, idInstituicao, nomeChamado, dataChamado, descricao)
VALUES			   (3, 1, 'Manutenção', '09/04/2021', 'o elevador parou de funcionar');
GO

-- Insere a presença
INSERT INTO Presencas(idUsuario, idEvento, situacao)
VALUES				 (2, 3, 'confirmada');
GO