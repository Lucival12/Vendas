using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vendas.Models
{
    [Table("tb_pedidovendaitens")]
    public class PedidoVendaItem
    {

        [Key]
        public int idPedidoVendaItem { get; set; }


        public virtual int? idPedidoVenda { get; set; }
        public virtual PedidoVenda PedidoVenda { get; set; }

        public virtual int? idProduto { get; set; }
        public virtual Produto Produto { get; set; }   

        public decimal vQuantidade { get; set; }

        public decimal vValorUnitario { get; set; }

        public decimal vValorTotalProduto { get; set; }

    }
}