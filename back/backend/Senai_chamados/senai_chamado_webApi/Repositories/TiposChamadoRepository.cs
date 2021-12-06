using senai_chamado_webApi.Contexts;
using senai_chamado_webApi.Domains;
using senai_chamado_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_chamado_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos tipos de Chamados
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
        /// <param name="id">ID do tipo de Chamado que será atualizado</param>
        /// <param name="tipoChamadoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, TiposChamado tipoEventoAtualizado)
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
        /// <param name="id">ID do tipo de Chamado que será buscado</param>
        /// <returns>Um tipo de Chamado buscado</returns>
        public TiposChamado BuscarPorId(int id)
        {
            // Retorna o primeiro tipo de Chamado encontrado para o ID informado
            return ctx.TiposChamados.FirstOrDefault(te => te.IdTipoChamado == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de Chamado
        /// </summary>
        /// <param name="novoTipoChamado">Objeto novoTipoChamadoque será cadastrado</param>
        public void Cadastrar(TiposChamado novoTipoChamado)
        {
            // Adiciona este novoTipoChamado
            ctx.TiposChamado.Add(novoTipoChamado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de Chamado existente
        /// </summary>
        /// <param name="id">ID do tipo de Chamado que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um tipo de Chamado através do id
            TiposChamado tipoChamadoBuscado = ctx.TiposChamado.Find(id);

            // Remove o tipo de Chamado que foi buscado
            ctx.TiposChamado.Remove(tipoChamadoBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de Chamados
        /// </summary>
        /// <returns>Uma lista de tipos de Chamados</returns>
        public List<TiposChamado> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de Chamados
            return ctx.TiposChamados.ToList();
        }
    }
}
