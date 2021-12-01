using Microsoft.EntityFrameworkCore;
using senai_chamado_webApi.Contexts;
using senai_chamado_webApi.Domains;
using senai_chamado_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai_gufi_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos Chamados
    /// </summary>
    public class ChamadosRepository : IEventoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        ChamadosContext ctx = new ChamadosContext();

        /// <summary>
        /// Atualiza um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será atualizado</param>
        /// <param name="chamadosAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Chamados chamadosAtualizado)
        {
            // Busca um evento através do id
            Evento chamadosBuscado = ctx.Eventos.Find(id);

            // Verifica se o nome do evento foi informado
            if (chamadoAtualizado.NomeChamado != null)
            {
                // Atribui os novos valores ao campos existentes
                chamadoBuscado.NomeChamado = chamadoAtualizado.NomeChamado;
            }

            // Verifica se o tipo do evento foi informado
            if (chamadoAtualizado.IdTipoChamado != null)
            {
                // Atribui os novos valores ao campos existentes
                chamadoBuscado.IdTipoChamado = chamadoAtualizado.IdTipoChamado;
            }

            // Verifica se o tipo do evento foi informado
            if (chamadoAtualizado.IdTipoChamado > 0)
            {
                // Atribui os novos valores ao campos existentes
                chamadoBuscado.IdTipoChamado = chamadoAtualizado.IdTipoChamado;
            }

            // Verifica se a privacidade do evento foi informada
            if (chamadoAtualizado.AcessoLivre == true || chamadoAtualizado.AcessoLivre == false)
            {
                // Atribui os novos valores ao campos existentes
                chamadoBuscado.AcessoLivre = chamadoAtualizado.AcessoLivre;
            }

            // Verifica se a instituição do evento foi informada
            if (chamadoAtualizado.IdInstituicao > 0)
            {
                // Atribui os novos valores ao campos existentes
                chamadoBuscado.IdInstituicao = chamadoAtualizado.IdInstituicao;
            }

            // Verifica se a descrição do evento foi informada
            if (chamadoAtualizado.Descricao != null)
            {
                // Atribui os novos valores ao campos existentes
                chamadoBuscado.Descricao = chamadoAtualizado.Descricao;
            }

            // Verifica se a data do evento é superior ou igual à data de hoje
            if (chamadoAtualizado.DataEvento >= DateTime.Today)
            {
                // Atribui os novos valores ao campos existentes
                chamadoBuscado.DataEvento = chamadoAtualizado.DataChamado;
            }

            // Atualiza o evento que foi buscado
            ctx.Chamado.Update(chamadoBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um evento através do ID
        /// </summary>
        /// <param name="id">ID do evento que será buscado</param>
        /// <returns>Um evento buscado</returns>
        public Chamados BuscarPorId(int id)
        {
            // Retorna o primeiro evento encontrado para o ID informado
            return ctx.ChamadoS.FirstOrDefault(e => e.Idchamado == id);
        }

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoChamado">Objeto novoEvento que será cadastrado</param>
        public void Cadastrar(Chamado novoChamado)
        {
            // Adiciona este novoEvento
            ctx.Chamado.Add(novoChamado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o evento que foi buscado
            ctx.Chamado.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Uma lista de eventos</returns>
        public List<Chamado> Listar()
        {
            // Retorna uma lista com todas as informações dos eventos
            return ctx.Chamado
                // Adiciona na busca as informações do tipo de evento
                .Include(e => e.IdTipoChamadoNavigation)
                // Adiciona na busca as informações da instituição
                .Include(e => e.IdInstituicaoNavigation)
                .ToList();
        }
    }
}
