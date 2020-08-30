using MatejCervelinMvcProjekt.BL;
using MatejCervelinMvcProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatejCervelinMvcProjekt.Controllers
{
    public class GradController : Controller
    {
        private Referada referada = new Referada();

        // GET: PregledGradova
        [Authorize]
        public ActionResult PregledGradova(int? drzavaID)
        {
            if (drzavaID == null)
            {
                return RedirectToAction("PregledDrzava", "Drzava");
            }

            List<Grad> gradovi = referada.DohvatiGradove(drzavaID.Value);
            return View(gradovi);
        }


        [ChildActionOnly]
        public ActionResult DohvatiNazivDrzave(int drzavaId)
        {
            return Content(referada.DohvatiDrzavu(drzavaId).Naziv);
        }

        // GET: Grad/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int gradId)
        {
            ViewBag.drzave = referada.DohvatiDrzave();
            return View(referada.DohvatiGrad(gradId));
        }

        // POST: Grad/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Grad g, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    referada.AzurirajGrad(g);
                    return RedirectToAction("PregledDrzava", "Drzava");
                }
                else
                {
                    ViewBag.drzave = referada.DohvatiDrzave();
                    ViewBag.error = "Model state is not valid!";
                    return View(g);
                }
            }
            catch
            {
                ViewBag.drzave = referada.DohvatiDrzave();
                ViewBag.error = "Dogodila se greška!";
                return View(g);
            }
        }





        // GET: Grad/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.drzave = referada.DohvatiDrzave();
            return View();
        }

        // POST: Grad/Create
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Grad g, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    referada.UbaciGrad(g);
                    return RedirectToAction("PregledDrzava", "Drzava");
                }
                else
                {
                    ViewBag.drzave = referada.DohvatiDrzave();
                    ViewBag.error = "Model state is not valid!";
                    return View(g);
                }
            }
            catch
            {
                ViewBag.drzave = referada.DohvatiDrzave();
                ViewBag.error = "Dogodila se greška!";
                return View(g);
            }
        }
    }
}
