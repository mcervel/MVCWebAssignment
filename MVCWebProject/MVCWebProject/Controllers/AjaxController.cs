using MatejCervelinMvcProjekt.BL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatejCervelinMvcProjekt.Controllers
{
    public class AjaxController : Controller
    {
        private Referada referada = new Referada();

        public ActionResult DohvatiRacuneKupca (int idKupac)
        {
            return Json(referada.DohvatiRacune(idKupac), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DohvatiStavkeRacuna(int idRacun)
        {
            return Json(referada.DohvatiStavke(idRacun), JsonRequestBehavior.AllowGet);
        }



    }
}