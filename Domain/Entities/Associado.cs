using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Associado", Schema = "dbo")]
   public class Associado
   {
        public long Id { get; set; }

        [Required]
        public long CPF { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string NomeMae { get; set; }

        public long? CNS { get; set; }

        public long? PisPasep { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public long? TitularId { get; set; }

        [NotMapped]
        public List<Associado> Dependentes { get; set; }

        [NotMapped]
        public List<Endereco> Enderecos { get; set; }

        [NotMapped]
        public List<Telefone> Telefones { get; set; }

        [NotMapped]
        public ContaBanco ContaBanco { get; set; }

        [NotMapped]
        public List<AssociadoPlano> AssociadoPlanos { get; set; }
    }
}
