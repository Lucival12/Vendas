using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vendas.Models;

namespace Vendas.Context
{
    public class ContextVenda : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PedidoVenda> PedidoVendas { get; set; }
        public DbSet<PedidoVendaItem> PedidoVendaItens { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PedidoVenda>()
        //                    .HasRequired<Cliente>(s => s.Cliente)
        //                    .WithMany(g => g.PedidoVendas)
        //                    .HasForeignKey<int>(s => s.idCliente)
        //                    .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<PedidoVendaItem>()
        //                    .HasRequired<PedidoVenda>(s => s.PedidoVenda)
        //                    .WithMany(g => g.PedidoVendaItens)
        //                    .HasForeignKey<int>(s => s.idPedidoVenda)
        //                    .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<PedidoVendaItem>()
        //                   .HasRequired<Produto>(s => s.Produto)
        //                   .WithMany(g => g.PedidoVendaItens)
        //                   .HasForeignKey<int>(s => s.idProduto)
        //                   .WillCascadeOnDelete(false);
        //}

    }
 }