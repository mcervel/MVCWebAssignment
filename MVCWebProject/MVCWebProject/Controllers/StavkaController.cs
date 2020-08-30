using MatejCervelinMvcProjekt.BL;
using MatejCervelinMvcProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatejCervelinMvcProjekt.Controllers
{
    public class StavkaController : Controller
    {
        private Referada referada = new Referada();

        // GET: Stavka/PregledStavki
        [Authorize]
        public ActionResult PregledStavki(int? idRacun)
        {
            if (idRacun == null)
            {
                return RedirectToAction("PregledDrzava", "Drzava");
            }

            ViewBag.idRacun = idRacun.Value;
            return View();
        }

        // GET: Stavka/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.racuni = referada.DohvatiRacune();
            ViewBag.proizvodi = referada.DohvatiProizvode();
            return View();
        }

        // POST: Stavka/Create
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Stavka s, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    referada.UbaciStavku(s);
                    return RedirectToAction("PregledDrzava", "Drzava");
                }
                else
                {
                    ViewBag.racuni = referada.DohvatiRacune();
                    ViewBag.proizvodi = referada.DohvatiProizvode();
                    ViewBag.error = "Model state is not valid!";
                    return View(s);
                }
            }
            catch
            {
                ViewBag.racuni = referada.DohvatiRacune();
                ViewBag.proizvodi = referada.DohvatiProizvode();
                ViewBag.error = "Model state is not valid!";
                ViewBag.error = "Dogodila se greška!";
                return View(s);
            }
        }


        // GET: Stavka/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int idStavka)
        {
            ViewBag.racuni = referada.DohvatiRacune();
            ViewBag.proizvodi = referada.DohvatiProizvode();
            return View(referada.DohvatiStavku(idStavka));
        }

        // POST: Stavka/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Stavka s, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    referada.AzurirajStavku(s);
                    return RedirectToAction("PregledDrzava", "Drzava");
                }
                else
                {
                    ViewBag.racuni = referada.DohvatiRacune();
                    ViewBag.proizvodi = referada.DohvatiProizvode();
                    ViewBag.error = "Model state is not valid!";
                    return View(s);
                }

            }
            catch
            {
                ViewBag.racuni = referada.DohvatiRacune();
                ViewBag.proizvodi = referada.DohvatiProizvode();
                ViewBag.error = "Model state is not valid!";
                ViewBag.error = "Dogodila se greška!";
                return View(s);
            }
        }


    }
}
