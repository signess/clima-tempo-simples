using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using clima_tempo_simples.Models;

namespace clima_tempo_simples.Controllers
{
    public class HomeController : Controller
    {
        private ClimaTempoSimplesEntities1 db = new ClimaTempoSimplesEntities1();

        public ActionResult Index()
        {
            ViewData["MaioresTemperaturas"] = (from p in db.PrevisaoClimas
                                               orderby p.TemperaturaMaxima descending
                                               
                                               select p).Take(3);
            ViewData["MenoresTemperaturas"] = (from p in db.PrevisaoClimas
                                               orderby p.TemperaturaMinima ascending
                                       
                                               select p).Take(3);
            ViewData["Cidades"] = db.Cidades.ToList();
            return View();
        }

        public JsonResult Search(string term)
        {
            var cidadesList = db.Cidades.ToList();

            if(term != null)
            {
                cidadesList = db.Cidades.Where(x => x.Nome.Contains(term)).ToList();
            }

            var modifiedData = cidadesList.Select(x => new
            {
                id = x.Id,
                text = x.Nome
            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}