using Microsoft.EntityFrameworkCore;
using senai_chamado_webApi.Contexts;
using senai_chamado_webApi.Domains;
using senai_chamado_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai_chamado_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos Chamados
    /// </summary>
    public class ChamadosRepository : IChamadoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        ChamadosContext ctx = new ChamadosContext();

        /// <summary>
        /// Atualiza um Chamado existente
        /// </summary>
        /// <param name="id">ID do Chamado que será atualizado</param>
        /// <param name="ChamadoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Chamados ChamadoAtualizado)
        {
            // Busca um evento através do id
            Evento ChamadoBuscado = ctx.Chamados.Find(id);

            // Verifica se o nome do evento foi informado
            if (chamadoAtualizado.NomeChamado != null)
            {
                // Atribui os novos valores ao campos existentes
                ChamadoBuscado.NomeChamado = ChamadoAtualizado.NomeChamado;
            }

            // Verifica se o tipo do Chamado foi informado
            if (ChamadoAtualizado.IdTipoChamado != null)
            {
                // Atribui os novos valores ao campos existentes
                ChamadoBuscado.IdTipoChamado = ChamadoAtualizado.IdTipoChamado;
            }

            // Verifica se o tipo do Chamado foi informado
            if (ChamadoAtualizado.IdTipoChamado > 0)
            {
                // Atribui os novos valores ao campos existentes
                ChamadoBuscado.IdTipoChamado = ChamadoAtualizado.IdTipoChamado;
            }

            // Verifica se a privacidade do evento foi informada
            if (ChamadoAtualizado.AcessoLivre == true || ChamadoAtualizado.AcessoLivre == false)
            {
                // Atribui os novos valores ao campos existentes
               ChamadoBuscado.AcessoLivre = ChamadoAtualizado.AcessoLivre;
            }

            // Verifica se a instituição do Chamado foi informada
            if (ChamadoAtualizado.IdInstituicao > 0)
            {
                // Atribui os novos valores ao campos existentes
                ChamadoBuscado.IdInstituicao = ChamadoAtualizado.IdInstituicao;
            }

            // Verifica se a descrição do evento foi informada
            if (ChamadoAtualizado.Descricao != null)
            {
                // Atribui os novos valores ao campos existentes
               ChamadoBuscado.Descricao = ChamadoAtualizado.Descricao;
            }

            // Verifica se a data do evento é superior ou igual à data de hoje
            if (ChamadoAtualizado.DataChamado >= DateTime.Today)
            {
                // Atribui os novos valores ao campos existentes
                ChamadoBuscado.DataEvento = ChamadoAtualizado.DataChamado;
            }

            // Atualiza o Chamado que foi buscado
            ctx.Chamado.Update(ChamadoBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Chamado através do ID
        /// </summary>
        /// <param name="id">ID do Chamado que será buscado</param>
        /// <returns>Um Chamado buscado</returns>
        public Chamados BuscarPorId(int id)
        {
            // Retorna o primeiro Chamado encontrado para o ID informado
            return ctx.Chamado.FirstOrDefault(e => e.Idchamado == id);
        }

        /// <summary>
        /// Cadastra um novo Chamado
        /// </summary>
        /// <param name="novoChamado">Objeto novoChamado que será cadastrado</param>
        public void Cadastrar(Chamado novoChamado)
        {
            // Adiciona este novoChamado
            ctx.Chamado.Add(novoChamado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Chamado existente
        /// </summary>
        /// <param name="id">ID do Chamado que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o Chamado que foi buscado
            ctx.Chamado.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Chamados
        /// </summary>
        /// <returns>Uma lista de Chamados</returns>
        public List<Chamado> Listar()
        {
            // Retorna uma lista com todas as informações dos Chamados
            return ctx.Chamado
                // Adiciona na busca as informações do tipo de Chamado
                .Include(e => e.IdTipoChamadoNavigation)
                // Adiciona na busca as informações da instituição
                .Include(e => e.IdInstituicaoNavigation)
                .ToList();
        }
    }
}
