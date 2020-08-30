using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatejCervelinMvcProjekt.Models.CustomHTMLHelpers
{
    public static class CustomHTMLHelpers
    {
        public static MvcHtmlString DDLGradovi(this HtmlHelper html, List<Grad> kolekcijaGradova)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "GradID");
            selectTag.MergeAttribute("name", "GradID");
            selectTag.AddCssClass("form-control");

            foreach (Grad grad in kolekcijaGradova)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", grad.IDGrad.ToString());
                optionTag.SetInnerText(grad.Naziv);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }


        public static MvcHtmlString DDLDrzave(this HtmlHelper html, List<Drzava> kolekcijaDrzava)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "DrzavaID");
            selectTag.MergeAttribute("name", "DrzavaID");
            selectTag.AddCssClass("form-control");

            foreach (Drzava drzava in kolekcijaDrzava)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", drzava.IDDrzava.ToString());
                optionTag.SetInnerText(drzava.Naziv);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }

        public static MvcHtmlString DDLKupci(this HtmlHelper html, List<Kupac> kolekcijaKupaca)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "KupacID");
            selectTag.MergeAttribute("name", "KupacID");
            selectTag.AddCssClass("form-control");

            foreach (Kupac kupac in kolekcijaKupaca)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", kupac.IDKupac.ToString());
                optionTag.SetInnerText(kupac.PunoIme);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }

        public static MvcHtmlString DDLKomercijalisti(this HtmlHelper html, List<Komercijalist> kolekcijaKomercijalista)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "KomercijalistID");
            selectTag.MergeAttribute("name", "KomercijalistID");
            selectTag.AddCssClass("form-control");

            foreach (Komercijalist komercijalist in kolekcijaKomercijalista)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", komercijalist.IDKomercijalist.ToString());
                optionTag.SetInnerText(komercijalist.PunoIme);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }

        public static MvcHtmlString DDLKreditneKartice(this HtmlHelper html, List<KreditnaKartica> kolekcijaKreditnihKartica)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "KreditnaKarticaID");
            selectTag.MergeAttribute("name", "KreditnaKarticaID");
            selectTag.AddCssClass("form-control");

            foreach (KreditnaKartica kreditnaKartica in kolekcijaKreditnihKartica)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", kreditnaKartica.IDKreditnaKartica.ToString());
                optionTag.SetInnerText(kreditnaKartica.Kreditna);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }

        public static MvcHtmlString DDLRacuni(this HtmlHelper html, List<Racun> kolekcijaRacuna)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "RacunID");
            selectTag.MergeAttribute("name", "RacunID");
            selectTag.AddCssClass("form-control");

            foreach (Racun racun in kolekcijaRacuna)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", racun.IDRacun.ToString());
                optionTag.SetInnerText(racun.BrojRacuna);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }

        public static MvcHtmlString DDLProizvodi(this HtmlHelper html, List<Proizvod> kolekcijaProizvoda)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "ProizvodID");
            selectTag.MergeAttribute("name", "ProizvodID");
            selectTag.AddCssClass("form-control");

            foreach (Proizvod proizvod in kolekcijaProizvoda)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", proizvod.IDProizvod.ToString());
                optionTag.SetInnerText(proizvod.Naziv);
                selectTag.InnerHtml += optionTag.ToString();
            }
            return new MvcHtmlString(selectTag.ToString());
        }


    }
}