using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vendas.Models
{
    [Table("tb_clientes")]
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }

        [DisplayName("Razão Social")]
        [Required]
        public string xRazaoSocialCliente { get; set; }

        [DisplayName("Rua")]
        [Required]
        public string xRua { get; set; }

        [DisplayName("Cidade")]
        [Required]
        public string xCidade { get; set; }

        public virtual List<PedidoVenda> PedidoVendas { get; set; }
    }
}