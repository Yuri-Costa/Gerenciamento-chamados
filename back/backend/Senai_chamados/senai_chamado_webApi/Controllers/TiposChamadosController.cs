using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_chamado_webApi.Domains;
using senai_chamado_webApi.Interfaces;
using senai_chamado_webApi.Repositories;
using System;

namespace senai_chamado_webApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints (URLs) referentes aos tipos de eventos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/tiposEventos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    [Authorize(Roles = "1")]
    public class TiposChamadosController : ControllerBase
    {
        /// <summary>
        /// Objeto _tiposChamadoRepository que irá receber todos os métodos definidos na interface ITiposChamadoRepository
        /// </summary>
        private ITiposChamadoRepository _tiposChamadoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tiposChamadoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public TiposEventosController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        /// <summary>
        /// Lista todos os tipos de Chamados
        /// </summary>
        /// <returns>Uma lista de tipos de Chamados e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposChamadoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um tipo de evento através do ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposChamadoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoChamado">Objeto novoTipoEvento que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TiposChamado novoTipoChamado)
        {
            try
            {
                // Faz a chamada para o método
                _tiposChamadoRepository.Cadastrar(novoTipoChamado);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoChamadoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposChamado tipoChamadoAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _tiposChamadoRepository.Atualizar(id, tipoChamadoAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _tiposChamadoRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
