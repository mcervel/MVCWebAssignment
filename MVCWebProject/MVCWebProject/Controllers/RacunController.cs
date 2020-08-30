using MatejCervelinMvcProjekt.BL;
using MatejCervelinMvcProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatejCervelinMvcProjekt.Controllers
{
    public class RacunController : Controller
    {
        private Referada referada = new Referada();

        // GET: Racun/PregledRacuna
        [Authorize]
        public ActionResult PregledRacuna(int? idKupac)
        {
            if (idKupac == null)
            {
                return RedirectToAction("PregledDrzava", "Drzava");
            }

            ViewBag.idKupac = idKupac.Value;
            return View();
        }


        // GET: Racun/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.kupci = referada.DohvatiKupce();
            ViewBag.komercijalisti = referada.DohvatiKomercijaliste();
            ViewBag.kreditneKartice = referada.DohvatiKreditneKartice();
            return View();
        }

        // POST: Racun/Create
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Racun r, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    referada.UbaciRacun(r);
                    return RedirectToAction("PregledDrzava", "Drzava");
                }
                else
                {
                    ViewBag.kupci = referada.DohvatiKupce();
                    ViewBag.komercijalisti = referada.DohvatiKomercijaliste();
                    ViewBag.kreditneKartice = referada.DohvatiKreditneKartice();
                    ViewBag.error = "Model state is not valid!";
                    return View(r);
                }
            }
            catch
            {
                ViewBag.kupci = referada.DohvatiKupce();
                ViewBag.komercijalisti = referada.DohvatiKomercijaliste();
                ViewBag.kreditneKartice = referada.DohvatiKreditneKartice();
                ViewBag.error = "Dogodila se greška!";
                return View(r);
            }
        }


        // GET: Racun/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int idRacun)
        {
            ViewBag.kupci = referada.DohvatiKupce();
            ViewBag.komercijalisti = referada.DohvatiKomercijaliste();
            ViewBag.kreditneKartice = referada.DohvatiKreditneKartice();
            return View(referada.DohvatiRacun(idRacun));
        }

        // POST: Racun/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Racun r, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    referada.AzurirajRacun(r);
                    return RedirectToAction("PregledDrzava", "Drzava");
                }
                else
                {
                    ViewBag.kupci = referada.DohvatiKupce();
                    ViewBag.komercijalisti = referada.DohvatiKomercijaliste();
                    ViewBag.kreditneKartice = referada.DohvatiKreditneKartice();
                    ViewBag.error = "Model state is not valid!";
                    return View(r);
                }

            }
            catch
            {
                ViewBag.kupci = referada.DohvatiKupce();
                ViewBag.komercijalisti = referada.DohvatiKomercijaliste();
                ViewBag.kreditneKartice = referada.DohvatiKreditneKartice();
                ViewBag.error = "Dogodila se greška!";
                return View(r);
            }
        }

    }
}
