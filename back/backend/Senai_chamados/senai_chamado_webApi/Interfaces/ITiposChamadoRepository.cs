using senai_chamado_webApi.Domains;
using System.Collections.Generic;

namespace senai_chamado_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TiposEventoRepository
    /// </summary>
    interface ITiposChamadoRepository
    {
        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Uma lista de tipos de eventos</returns>
        List<TiposChamado> Listar();

        /// <summary>
        /// Busca um tipo de Chamado através do ID
        /// </summary>
        /// <param name="id">ID do tipo de Chamado que será buscado</param>
        /// <returns>Um tipo de Chamado buscado</returns>
        TiposChamado BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de Chamado
        /// </summary>
        /// <param name="novoTipoEvento">Objeto novoTipoChamado que será cadastrado</param>
        void Cadastrar(TiposChamado novoTipoChamado);

        /// <summary>
        /// Atualiza um tipo de Chamado existente
        /// </summary>
        /// <param name="id">ID do tipo de Chamado que será atualizado</param>
        /// <param name="tipoChamadoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, TiposChamado tipoChamadoAtualizado);

        /// <summary>
        /// Deleta um tipo de Chamado existente
        /// </summary>
        /// <param name="id">ID do tipo de Chamado que será deletado</param>
        void Deletar(int id);
    }
}
