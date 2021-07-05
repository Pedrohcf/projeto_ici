using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCandidato.Data.Entidade
{
    public class ClienteObservacao
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }
        public string Observacao { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}
