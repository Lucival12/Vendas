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
    public class PedidoVendaController : Controller
    {
        private ContextVenda db = new ContextVenda();

        // GET: PedidoVenda
        public ActionResult Index()
        {
            return View(db.PedidoVendas.Include(a => a.Cliente).ToList());
        }

        // GET: PedidoVenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoVenda pedidoVenda = db.PedidoVendas.Find(id);
            if (pedidoVenda == null)
            {
                return HttpNotFound();
            }
            return View(pedidoVenda);
        }

        // GET: PedidoVenda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoVenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoVenda pedidoVenda)
        {
            if (ModelState.IsValid)
            {
                db.PedidoVendas.Add(pedidoVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedidoVenda);
        }

        // GET: PedidoVenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoVenda pedidoVenda = db.PedidoVendas.Find(id);
            if (pedidoVenda == null)
            {
                return HttpNotFound();
            }
            return View(pedidoVenda);
        }

        // POST: PedidoVenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedidoVenda,dtEmissao,vValorTotalPedido")] PedidoVenda pedidoVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedidoVenda);
        }

        // GET: PedidoVenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoVenda pedidoVenda = db.PedidoVendas.Find(id);
            if (pedidoVenda == null)
            {
                return HttpNotFound();
            }
            return View(pedidoVenda);
        }

        // POST: PedidoVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoVenda pedidoVenda = db.PedidoVendas.Find(id);
            db.PedidoVendas.Remove(pedidoVenda);
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
