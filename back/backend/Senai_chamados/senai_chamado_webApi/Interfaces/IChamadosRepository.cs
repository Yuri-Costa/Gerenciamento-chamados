using senai_chamado_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_chamado_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ChamadoRepository
    /// </summary>
    interface IChamadoRepository
    {
        /// <summary>
        /// Lista todos os Chamados
        /// </summary>
        /// <returns>Uma lista de Chamados</returns>
        List<Chamado> Listar();

        /// <summary>
        /// Busca um Chamado através do ID
        /// </summary>
        /// <param name="id">ID do Chamado que será buscado</param>
        /// <returns>Um evento buscado</returns>
        Chamado BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Chamado
        /// </summary>
        /// <param name="novoChamado">Objeto novoChamado que será cadastrado</param>
        void Cadastrar(Chamado novoChamado);

        /// <summary>
        /// Atualiza um Chamado existente
        /// </summary>
        /// <param name="id">ID do Chamado que será atualizado</param>
        /// <param name="ChamadoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Chamado ChamadoAtualizado);

        /// <summary>
        /// Deleta um Chamado existente
        /// </summary>
        /// <param name="id">ID do Chamado que será deletado</param>
        void Deletar(int id);
    }
}
