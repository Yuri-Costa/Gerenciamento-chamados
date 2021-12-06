using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_chamado_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de instituições
    /// </summary>
    public partial class Instituico
    {
        public Instituico()
        {
            Eventos = new HashSet<Chamado>();
        }

        public int IdInstituicao { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o CNPJ da instituição")]
        public string Cnpj { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o nome fantasia")]
        public string NomeFantasia { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o endereço")]
        public string Endereco { get; set; }

        public virtual ICollection<Chamado> Chamados { get; set; }
    }
}
