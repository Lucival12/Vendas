using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vendas.Models
{
    [Table("tb_produtos")]
    public class Produto
    {
        [Key]
        public int idProduto { get; set; }

        [DisplayName("Nome")]
        [Required]
        public string xNomeProduto { get; set; }

        [DisplayName("Valor Unitário")]
        [Required]
        public decimal vValorVenda { get; set; }

        public virtual List<PedidoVendaItem> PedidoVendaItens { get; set; }
    }
}