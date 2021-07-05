using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ProvaCandidato.Data.Entidade
{
  [Table("Cidade")]
  public class Cidade
  {
    [Key]
    [Column("codigo")]
    public int Codigo { get; set; }

    [Column("nome")]

    //Incluir uma validação obrigando que o tamanho no Nome da Cidade tenha no mínimo 3 caracteres e no máximo 50 caracteres
    [StringLength(50, MinimumLength = 3,ErrorMessage = "Nome da cidade deve ter 3 a 50 caracteres.")]
    [Required]
    public string Nome { get; set; }
  }
}
