using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_chamado_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de tipos de Chamados
    /// </summary>
    public partial class TiposChamado
    {
        public TiposChamado()
        {
            Eventos = new HashSet<Chamado>();
        }

        public int IdTipoChamado { get; set; }

        // Define que o campo é obrigatório

        [Required(ErrorMessage = "O título do tipo de chamado é obrigatório!")]
        public string TituloTipoChamado { get; set; }

        public virtual ICollection<Chamado> Chamado{ get; set; }
    }
}
