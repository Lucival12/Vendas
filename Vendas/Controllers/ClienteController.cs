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
    public class ClienteController : Controller
    {
        private ContextVenda db = new ContextVenda();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCliente,xRazaoSocialCliente,xRua,xCidade")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCliente,xRazaoSocialCliente,xRua,xCidade")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (db.PedidoVendas.Where(x => x.idCliente == id).FirstOrDefault() == null)
            {
                Cliente cliente = db.Clientes.Find(id);
                db.Clientes.Remove(cliente);
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
        public JsonResult Buscar(Cliente cliente)
        {
            List<Cliente> list = db.Clientes.Where(x => x.xRazaoSocialCliente.ToLower().Contains(cliente.xRazaoSocialCliente.ToLower())).ToList();            
            return Json(new
            {
                Lista = list.Select(x => new
                {
                    Id = x.idCliente,
                    Nome = x.xRazaoSocialCliente,
                    Rua = x.xRua,
                    Cidade = x.xCidade
                })
            });
        }
    }
}
