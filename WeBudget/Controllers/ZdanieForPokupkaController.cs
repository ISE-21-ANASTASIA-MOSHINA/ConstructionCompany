using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;
using WeBudget.Service;

namespace WeBudget.Controllers
{
    public class ZdanieForPokupkaController : Controller
    {
        CRUDManagerForPokupka zdanieForPokupkaService;

        public ZdanieForPokupkaController()
        {
            string dataStore = ConfigurationManager.AppSettings["DataStore"].ToString();
            switch (dataStore)
            {
                case "DB":
                    zdanieForPokupkaService = new ZdanieForPokupkaService();
                    break;
                case "File":
                    zdanieForPokupkaService = new ZdanieForPokupkaFileService();
                    break;
            }
        }

        [HttpGet]
        public ActionResult EditZdanieForPokupka(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
           
            if (zdanieForPokupkaService.findZdanieForPokupkaById(id) != null)
            {
                return View(zdanieForPokupkaService.findZdanieForPokupkaById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult UpdateZdanieForPokupka(ZdanieForPokupka zdanieForPokupka)
        {
            zdanieForPokupkaService.Edit(zdanieForPokupka);
            return RedirectToAction("ZdanieForPokupkas");
        }
   
        [HttpGet]
        public ActionResult CreateZdanieForPokupka()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateZdanieForPokupka(ZdanieForPokupka zdanieForPokupka)
        {
            zdanieForPokupkaService.Create(zdanieForPokupka);
            return RedirectToAction("ZdanieForPokupkas");
        }

        public ActionResult DeleteZdanieForPokupka(int id)
        {
            zdanieForPokupkaService.Delete(id);
            return RedirectToAction("ZdanieForPokupkas");
        }

        public ActionResult ZdanieForPokupkas()
        {
            return View(zdanieForPokupkaService.getList());
        }

        protected override void Dispose(bool disposing)
        {
            zdanieForPokupkaService.Dispose();
            base.Dispose(disposing);
        }
    }
}