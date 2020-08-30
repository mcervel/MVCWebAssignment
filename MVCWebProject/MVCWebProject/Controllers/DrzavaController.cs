using MatejCervelinMvcProjekt.BL;
using MatejCervelinMvcProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatejCervelinMvcProjekt.Controllers
{
    public class DrzavaController : Controller
    {
        private Referada referada = new Referada();

        // GET: PregledDrzava
        [Authorize]
        public ActionResult PregledDrzava()
        {
            ViewBag.drzave = referada.DohvatiDrzave();
            return View();
        }


        // GET: Drzava/Edit/5
        [Authorize(Roles="Administrator")]
        public ActionResult Edit(int idDrzava)
        {
            return View(referada.DohvatiDrzavu(idDrzava));
        }

        // POST: Drzava/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Drzava d, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    referada.AzurirajDrzavu(d);
                    return RedirectToAction("PregledDrzava", "Drzava");
                }
                else
                {
                    ViewBag.error = "Model state is not valid!";
                    return View(d);
                }
            }
            catch
            {
                ViewBag.error = "Dogodila se greška!";
                return View(d);
            }
        }

        // GET: Drzava/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drzava/Create
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Drzava d, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    referada.UbaciDrzavu(d);
                    return RedirectToAction("PregledDrzava", "Drzava");
                }
                else
                {
                    ViewBag.error = "Model state is not valid!";
                    return View(d);
                }
            }
            catch
            {
                ViewBag.error = "Dogodila se greška!";
                return View(d);
            }
        }




    }
}
