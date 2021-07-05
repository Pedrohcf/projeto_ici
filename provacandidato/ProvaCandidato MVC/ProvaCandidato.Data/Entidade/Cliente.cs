using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaCandidato.Data.Entidade
{
  [Table("Cliente")]
  public class Cliente
  {
    [Key]
    [Column("codigo")]
    public int Codigo { get; set; }

    //Incluir uma validação obrigando que o tamanho no Nome do Cliente tenha no mínimo 3 caracteres e no máximo 50 ca racteres.
    [StringLength(50, MinimumLength = 3,ErrorMessage = "Nome do cliente deve ter 3 a 50 caracteres.")]
    [Required]
    [Column("nome")]
    public string Nome { get; set; }

    [Column("data_nascimento")]
    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date), Required]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DataNascimento { get; set; }

    [Column("codigo_cidade")]
    [Display(Name = "Cidade")]
    public int CidadeId { get; set; }

    public bool Ativo { get; set; }

    [ForeignKey("CidadeId")]
    public virtual Cidade Cidade { get; set; }

    [InverseProperty("Cliente")]
    public virtual ICollection<ClienteObservacao> Observacoes { get; set; }
  }
}