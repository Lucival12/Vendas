using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vendas.Context;
using Vendas.Models;

namespace Vendas.Controllers
{
    public class ProdutoController : Controller
    {
        private ContextVenda db = new ContextVenda();

        // GET: Produto
        public ActionResult Index()
        {
            return View(db.Produtos.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProduto,xNomeProduto,vValorVenda")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProduto,xNomeProduto,vValorVenda")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (db.PedidoVendaItens.Where(x => x.idProduto == id).FirstOrDefault()  == null)
            {
                Produto produto = db.Produtos.Find(id);
                db.Produtos.Remove(produto);
                db.SaveChanges();

                return Json(new { Status = 0, Message = Util.Mensagens.REMOVIDO_SUCESSO }, JsonRequestBehavior.AllowGet);
            }
            else            
                return Json(new { Status = -1, Message = "Não é possível remover pois existe referência em Pedido de Venda ." }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpPost]
        public JsonResult Buscar(Produto produto)
        {
            List<Produto> list = db.Produtos.Where(x => x.xNomeProduto.ToLower().Contains(produto.xNomeProduto.ToLower())).ToList();
            return Json(new
            {
                Lista = list.Select(x => new
                {
                    Id = x.idProduto,
                    Nome = x.xNomeProduto,
                    ValorUnitario = x.vValorVenda                   

                })
            });
        }
    }
}
