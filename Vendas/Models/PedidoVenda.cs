using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vendas.Models
{
    [Table("tb_pedidovenda")]
    public class PedidoVenda
    {
        [Key]
        public int idPedidoVenda { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório")]
        public virtual int? idCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("Data de Emissão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime dtEmissao { get; set; }

        [DisplayName("Valor Total")]
        public decimal vValorTotalPedido { get; set; }

        public virtual List<PedidoVendaItem> PedidoVendaItens { get; set; }
    }
}