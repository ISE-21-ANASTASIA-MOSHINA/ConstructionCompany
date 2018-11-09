using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;
using WeBudget.Service;

namespace WeBudget.Controllers
{
    public class ZdanieForArendaController : Controller
    {
        ZdanieForArendaFileService zdanieForArendaService = new ZdanieForArendaFileService();

        [HttpGet]
        public ActionResult EditRashod(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            if (zdanieForArendaService.findZdanieForArendaById(id) != null)
            {
                return View(zdanieForArendaService.findZdanieForArendaById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditZdanieForArenda(ZdanieForArenda zdanieForArenda)

        {
            zdanieForArendaService.Edit(zdanieForArenda);
            return RedirectToAction("EditZdanieForArendas");
        }

        [HttpGet]
        public ActionResult CreateZdanieForArenda()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateZdanieForArenda(ZdanieForArenda zdanieForArenda)
        {
            zdanieForArendaService.Create(zdanieForArenda);
            return RedirectToAction("ZdanieForArendas");
        }


        public ActionResult DeleteZdanieForArenda(int id)
        {
            zdanieForArendaService.Delete(id);
            return RedirectToAction("ZdanieForArendas");
        }


        public ActionResult ZdanieForArendas()
        {
            ConstructionCompanyContext db = new ConstructionCompanyContext();
            // return View(rashodservice.getList());
            return View(db.ZdanieForArendas);
        }
        protected override void Dispose(bool disposing)
        {
            zdanieForArendaService.Dispose();
            base.Dispose(disposing);
        }
    }
}