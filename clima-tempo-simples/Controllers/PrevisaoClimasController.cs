using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clima_tempo_simples.Models;

namespace clima_tempo_simples.Controllers
{
    public class PrevisaoClimasController : Controller
    {
        private ClimaTempoSimplesEntities1 db = new ClimaTempoSimplesEntities1();

        // GET: PrevisaoClimas
        public ActionResult Index()
        {
            var previsaoClimas = db.PrevisaoClimas.Include(p => p.Cidade);
            return View(previsaoClimas.ToList());
        }

        // GET: PrevisaoClimas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrevisaoClima previsaoClima = db.PrevisaoClimas.Find(id);
            if (previsaoClima == null)
            {
                return HttpNotFound();
            }
            return View(previsaoClima);
        }

        // GET: PrevisaoClimas/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "Nome");
            return View();
        }

        // POST: PrevisaoClimas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CidadeId,DataPrevisao,Clima,TemperaturaMinima,TemperaturaMaxima")] PrevisaoClima previsaoClima)
        {
            if (ModelState.IsValid)
            {
                db.PrevisaoClimas.Add(previsaoClima);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "Nome", previsaoClima.CidadeId);
            return View(previsaoClima);
        }

        // GET: PrevisaoClimas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrevisaoClima previsaoClima = db.PrevisaoClimas.Find(id);
            if (previsaoClima == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "Nome", previsaoClima.CidadeId);
            return View(previsaoClima);
        }

        // POST: PrevisaoClimas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CidadeId,DataPrevisao,Clima,TemperaturaMinima,TemperaturaMaxima")] PrevisaoClima previsaoClima)
        {
            if (ModelState.IsValid)
            {
                db.Entry(previsaoClima).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "Nome", previsaoClima.CidadeId);
            return View(previsaoClima);
        }

        // GET: PrevisaoClimas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrevisaoClima previsaoClima = db.PrevisaoClimas.Find(id);
            if (previsaoClima == null)
            {
                return HttpNotFound();
            }
            return View(previsaoClima);
        }

        // POST: PrevisaoClimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrevisaoClima previsaoClima = db.PrevisaoClimas.Find(id);
            db.PrevisaoClimas.Remove(previsaoClima);
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
