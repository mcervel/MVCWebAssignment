using MatejCervelinMvcProjekt.BL;
using MatejCervelinMvcProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatejCervelinMvcProjekt.Controllers
{
    public class KupacController : Controller
    {
        private Referada referada = new Referada();

        // GET: PregledKupaca
        [Authorize]
        public ActionResult PregledKupaca(int? gradId)
        {
            if (gradId == null)
            {
                return RedirectToAction("PregledDrzava", "Drzava");
            }

            List<Kupac> kupci = referada.DohvatiKupce(gradId.Value);
            return View(kupci);
        }

        [ChildActionOnly]
        public ActionResult DohvatiNazivGrada(int gradId)
        {
            return Content(referada.DohvatiGrad(gradId).Naziv);
        }


        // GET: Kupac/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int idKupac)
        {
            ViewBag.gradovi = referada.DohvatiGradoveZaKupca();
            return View(referada.DohvatiKupca(idKupac));
        }

        // POST: Kupac/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Kupac k, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    referada.AzurirajKupca(k);
                    return RedirectToAction("PregledDrzava", "Drzava");
                }
                else
                {
                    ViewBag.gradovi = referada.DohvatiGradoveZaKupca();
                    ViewBag.error = "Model state is not valid!";
                    return View(k);
                }

            }
            catch
            {
                ViewBag.gradovi = referada.DohvatiGradoveZaKupca();
                ViewBag.error = "Dogodila se greška!";
                return View(k);
            }
        }



        // GET: Kupac/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.gradovi = referada.DohvatiGradoveZaKupca();
            return View();
        }

        // POST: Kupac/Create
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Kupac k, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    referada.UbaciKupca(k);
                    return RedirectToAction("PregledDrzava", "Drzava");
                }
                else
                {
                    ViewBag.gradovi = referada.DohvatiGradoveZaKupca();
                    ViewBag.error = "Model state is not valid!";
                    return View(k);
                }
            }
            catch
            {
                ViewBag.gradovi = referada.DohvatiGradoveZaKupca();
                ViewBag.error = "Dogodila se greška!";
                return View(k);
            }
        }

    }
}
