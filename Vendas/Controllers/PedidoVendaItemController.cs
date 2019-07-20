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
    public class PedidoVendaItemController : Controller
    {
        private ContextVenda db = new ContextVenda();

        // GET: PedidoVendaItem
        public ActionResult Index()
        {
            return View(db.PedidoVendaItens.ToList());
        }

        // GET: PedidoVendaItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoVendaItem pedidoVendaItem = db.PedidoVendaItens.Find(id);
            if (pedidoVendaItem == null)
            {
                return HttpNotFound();
            }
            return View(pedidoVendaItem);
        }

        // GET: PedidoVendaItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoVendaItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedidoVendaItem,vQuantidade,vValorUnitario,vValorTotalProduto")] PedidoVendaItem pedidoVendaItem)
        {
            if (ModelState.IsValid)
            {
                db.PedidoVendaItens.Add(pedidoVendaItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedidoVendaItem);
        }

        // GET: PedidoVendaItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoVendaItem pedidoVendaItem = db.PedidoVendaItens.Find(id);
            if (pedidoVendaItem == null)
            {
                return HttpNotFound();
            }
            return View(pedidoVendaItem);
        }

        // POST: PedidoVendaItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedidoVendaItem,vQuantidade,vValorUnitario,vValorTotalProduto")] PedidoVendaItem pedidoVendaItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoVendaItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedidoVendaItem);
        }

        // GET: PedidoVendaItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoVendaItem pedidoVendaItem = db.PedidoVendaItens.Find(id);
            if (pedidoVendaItem == null)
            {
                return HttpNotFound();
            }
            return View(pedidoVendaItem);
        }

        // POST: PedidoVendaItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoVendaItem pedidoVendaItem = db.PedidoVendaItens.Find(id);
            db.PedidoVendaItens.Remove(pedidoVendaItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
