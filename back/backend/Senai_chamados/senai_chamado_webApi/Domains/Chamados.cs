using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_chamado_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de eventos
    /// </summary>
    public partial class Chamado
    {
        public Chamado()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdChamado { get; set; }
        public int? IdTipoChamado { get; set; }
        public int? IdInstituicao { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o título do Chamado")]
        public string NomeChamado { get; set; }
        public bool? AcessoLivre { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe a data do Chamado")]
        public DateTime DataChamado { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe a descrição do Chamado")]
        public string Descricao { get; set; }

        public virtual Instituico IdInstituicaoNavigation { get; set; }
        public virtual TiposChamado IdTipoChamadoNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
