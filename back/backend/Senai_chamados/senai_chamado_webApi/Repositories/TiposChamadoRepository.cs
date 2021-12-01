using senai_chamado_webApi.Contexts;
using senai_chamado_webApi.Domains;
using senai_chamado_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_gufi_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos tipos de eventos
    /// </summary>
    public class TiposChamadoRepository : ITiposChamadoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        ChamadosContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoChamadoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, TiposEvento tipoEventoAtualizado)
        {
            // Busca um tipo de evento através do id
            TiposChamado tipoChamadoBuscado = ctx.TiposChamado.Find(id);

            // Verifica se o título do tipo de evento foi informado
            if (tipoChamadoAtualizado.TituloTipoChamado != null)
            {
                // Atribui os novos valores ao campos existentes
                tipoChamadoBuscado.TituloTipoChamado = tipoChamadoAtualizado.TituloTipoEvento;
            }

            // Atualiza o tipo de evento que foi buscado
            ctx.TiposChamados.Update(tipoChamadoBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de evento através do ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento buscado</returns>
        public TiposChamado BuscarPorId(int id)
        {
            // Retorna o primeiro tipo de evento encontrado para o ID informado
            return ctx.TiposChamados.FirstOrDefault(te => te.IdTipoChamado == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoChamado">Objeto novoTipoEvento que será cadastrado</param>
        public void Cadastrar(TiposEvento novoTipoChamado)
        {
            // Adiciona este novoTipoEvento
            ctx.TiposChamado.Add(novoTipoChamado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um tipo de evento através do id
            TiposChamado tipoChamadoBuscado = ctx.TiposChamado.Find(id);

            // Remove o tipo de evento que foi buscado
            ctx.TiposChamado.Remove(tipoChamadoBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Uma lista de tipos de eventos</returns>
        public List<TiposChamado> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de eventos
            return ctx.TiposChamados.ToList();
        }
    }
}
