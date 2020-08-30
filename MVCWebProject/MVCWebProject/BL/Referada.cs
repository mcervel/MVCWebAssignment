using MatejCervelinMvcProjekt.DAL;
using MatejCervelinMvcProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.BL
{
    public class Referada
    {
        private IRepo repo;

        public List<Drzava> DohvatiDrzave()
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiDrzave();
        }

        public List<Grad> DohvatiGradove(int idDrzava)
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiGradove(idDrzava);
        }

        public Drzava DohvatiDrzavu(int drzavaId)
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiDrzavu(drzavaId);
        }

        public List<Kupac> DohvatiKupce(int idGrad)
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiKupce(idGrad);
        }

        public Grad DohvatiGrad(int gradId)
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiGrad(gradId);
        }

        public IEnumerable<RowForTableRacun> DohvatiRacune(int idKupac)
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiRacune(idKupac);
        }

        public IEnumerable<RowForTableStavka> DohvatiStavke(int idRacun)
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiStavke(idRacun);
        }

        public void AzurirajDrzavu(Drzava d)
        {
            repo = RepoFactory.GetRepo();
            repo.AzurirajDrzavu(d);
        }

        public void AzurirajGrad(Grad g)
        {
            repo = RepoFactory.GetRepo();
            repo.AzurirajGrad(g);
        }

        public List<Grad> DohvatiGradoveZaKupca()
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiGradoveZaKupca();
        }

        public Kupac DohvatiKupca(int idKupac)
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiKupca(idKupac);
        }

        public void AzurirajKupca(Kupac kupac)
        {
            repo = RepoFactory.GetRepo();
            repo.AzurirajKupca(kupac);
        }

        public void UbaciDrzavu(Drzava drzava)
        {
            repo = RepoFactory.GetRepo();
            repo.UbaciDrzavu(drzava);
        }

        public void UbaciGrad(Grad grad)
        {
            repo = RepoFactory.GetRepo();
            repo.UbaciGrad(grad);
        }

        public void UbaciKupca(Kupac kupac)
        {
            repo = RepoFactory.GetRepo();
            repo.UbaciKupca(kupac);
        }

        public List<Kupac> DohvatiKupce()
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiKupce();
        }

        public List<Komercijalist> DohvatiKomercijaliste()
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiKomercijaliste();
        }

        public List<KreditnaKartica> DohvatiKreditneKartice()
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiKreditneKartice();
        }

        public List<Racun> DohvatiRacune()
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiRacune();
        }

        public List<Proizvod> DohvatiProizvode()
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiProizvode();
        }

        public void UbaciRacun(Racun racun)
        {
            repo = RepoFactory.GetRepo();
            repo.UbaciRacun(racun);
        }

        public void AzurirajRacun(Racun racun)
        {
            repo = RepoFactory.GetRepo();
            repo.AzurirajRacun(racun);
        }

        public void UbaciStavku(Stavka stavka)
        {
            repo = RepoFactory.GetRepo();
            repo.UbaciStavku(stavka);
        }

        public void AzurirajStavku(Stavka stavka)
        {
            repo = RepoFactory.GetRepo();
            repo.AzurirajStavku(stavka);
        }

        public Racun DohvatiRacun(int idRacun)
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiRacun(idRacun);
        }

        public Stavka DohvatiStavku(int idStavka)
        {
            repo = RepoFactory.GetRepo();
            return repo.DohvatiStavku(idStavka);
        }

    }
}