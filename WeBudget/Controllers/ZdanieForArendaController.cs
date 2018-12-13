using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WeBudget.Models;
using WeBudget.Service;

namespace WeBudget.Controllers
{
    public class ZdanieForArendaController : Controller
    {
        CRUDManagerForArenda zdanieForArendaService;
         
        public ZdanieForArendaController()
        {
            string dataStore = ConfigurationManager.AppSettings["DataStore"].ToString();
            switch (dataStore)
            {
                case "DB":
                    zdanieForArendaService = new ZdanieForArendaService();
                    break;
                case "File":
                    zdanieForArendaService = new ZdanieForArendaFileService();
                    break;
            }
        }

        [HttpGet]
        public ActionResult EditZdanieForArenda(int? id)
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
        public ActionResult UpdateZdanieForArenda(ZdanieForArenda zdanieForArenda)

        {
            zdanieForArendaService.Edit(zdanieForArenda);
            return RedirectToAction("ZdanieForArendas");
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
            JavaScriptSerializer js = new JavaScriptSerializer();
            ConstructionCompanyContext db = new ConstructionCompanyContext();
            string json = js.Serialize(db.ZdanieForArendas);
            return Content(json, "application/json");
        }
    }
}